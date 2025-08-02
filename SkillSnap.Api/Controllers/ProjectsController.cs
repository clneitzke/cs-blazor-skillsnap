using Microsoft.AspNetCore.Mvc;
using SkillSnap.Api.Data;
using SkillSnap.Shared.Models;

namespace SkillSnap.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly SkillSnapContext _context;

    public ProjectsController(SkillSnapContext context)
    {
        _context = context;
    }

    // GET: api/Projects
    [HttpGet]
    public ActionResult<IEnumerable<Project>> GetProjects()
    {
        return Ok(_context.Projects.ToList());
    }

    // POST: api/Projects
    [HttpPost]
    public ActionResult<Project> AddProject(Project project)
    {
        _context.Projects.Add(project);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetProjects), new { id = project.Id }, project);
    }
}