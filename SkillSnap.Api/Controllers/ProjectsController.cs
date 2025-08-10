using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using SkillSnap.Api.Data;
using SkillSnap.Shared.Models;

namespace SkillSnap.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly SkillSnapContext _context;
        private readonly IMemoryCache _cache;

        public ProjectsController(SkillSnapContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            if (!_cache.TryGetValue("projects", out List<Project>? projects))
            {
                var sw = System.Diagnostics.Stopwatch.StartNew();

                projects = await _context.Projects
                                         .AsNoTracking()
                                         .ToListAsync();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(5));

                _cache.Set("projects", projects, cacheOptions);

                sw.Stop();
                Console.WriteLine($"[PERF] Projects retrieved from DB in {sw.ElapsedMilliseconds}ms");
            }
            else
            {
                Console.WriteLine("[CACHE HIT] Projects served from memory cache.");
            }

            return Ok(projects);
        }

        [Authorize] // Requires authenticated user
        [HttpPost]
        public async Task<ActionResult<Project>> Create(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProjects), new { id = project.Id }, project);
        }

        [Authorize(Roles = "Admin")] // Requires user in Admin role
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null) return NotFound();

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
