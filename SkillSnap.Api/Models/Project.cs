using System.ComponentModel.DataAnnotations;

namespace SkillSnap.Api.Models;

public class Project
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }

    public int PortfolioUserId { get; set; }
    public PortfolioUser PortfolioUser { get; set; }
}