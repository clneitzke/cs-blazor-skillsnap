using System.ComponentModel.DataAnnotations;

namespace SkillSnap.Api.Models;


public class Skill
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Level { get; set; }

    public int PortfolioUserId { get; set; }
    public PortfolioUser PortfolioUser { get; set; }
}