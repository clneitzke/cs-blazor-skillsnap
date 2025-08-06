using Microsoft.AspNetCore.Mvc;
using SkillSnap.Api.Data;
using SkillSnap.Shared.Models;

namespace SkillSnap.Api.Controllers;

public class SkillsController: ControllerBase
{
    private readonly SkillSnapContext _context;

    public SkillsController(SkillSnapContext context)
    {
        _context = context;
    }

    // GET: api/Skills
    [HttpGet]
    public ActionResult<IEnumerable<Project>> GetProjects()
    {
        return Ok(_context.Skills.ToList());
    }

    // POST: api/Skills
    [HttpPost]
    public ActionResult<Project> AddSkill(Skill skill)
    {
        _context.Skills.Add(skill);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetProjects), new { id = skill.Id }, skill);
    }
}