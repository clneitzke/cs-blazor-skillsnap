using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillSnap.Shared.Models;


public class Skill
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Skill name is required")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Skill level is required")]
    public string Level { get; set; } = string.Empty;

    public int PortfolioUserId { get; set; }
    
    [ForeignKey("PortfolioUserId")]
    public PortfolioUser PortfolioUser { get; set; }
}