
using Microsoft.AspNetCore.Mvc;
using SkillSnap.Api.Data;
using SkillSnap.Shared.Models;

namespace SkillSnap.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PortfolioUserController(SkillSnapContext context) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Project>> GetPortfolioUsers()
    {
        return Ok(context.PortfolioUsers.ToList());
    }

    [HttpPost]
    public ActionResult<Project> AddProject(PortfolioUser portfolioUser)
    {
        context.PortfolioUsers.Add(portfolioUser);
        context.SaveChanges();
        return CreatedAtAction(nameof(GetPortfolioUsers), new { id = portfolioUser.Id }, portfolioUser);
    }
}