using Microsoft.AspNetCore.Mvc;
using SkillSnap.Api.Data;
using SkillSnap.Shared.Models;

namespace SkillSnap.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController(SkillSnapContext context) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Project>> GetProjects()
    {
        return Ok(context.Projects.ToList());
    }

    [HttpPost]
    public ActionResult<Project> AddProject(Project project)
    {
        context.Projects.Add(project);
        context.SaveChanges();
        return CreatedAtAction(nameof(GetProjects), new { id = project.Id }, project);
    }
}