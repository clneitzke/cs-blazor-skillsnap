using Microsoft.AspNetCore.Mvc;
using SkillSnap.Api.Data;
using SkillSnap.Shared.Models;

namespace SkillSnap.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SkillsController(SkillSnapContext context) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Project>> GetProjects()
    {
        return Ok(context.Skills.ToList());
    }

    [HttpPost]
    public ActionResult<Project> AddSkill(Skill skill)
    {
        context.Skills.Add(skill);
        context.SaveChanges();
        return CreatedAtAction(nameof(GetProjects), new { id = skill.Id }, skill);
    }
}