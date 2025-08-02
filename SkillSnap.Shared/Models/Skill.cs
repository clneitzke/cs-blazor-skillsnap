using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillSnap.Shared.Models;


public class Skill
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Level { get; set; }

    public int PortfolioUserId { get; set; }
    
    [ForeignKey("PortfolioUserId")]
    public PortfolioUser PortfolioUser { get; set; }
}