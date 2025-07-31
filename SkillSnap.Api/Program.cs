using Microsoft.EntityFrameworkCore;
using SkillSnap.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddDbContext<SkillSnapContext>(options =>
    options.UseSqlite("Data Source=skillsnap.db"));

// Run EF Core commands:dotnet ef migrations add InitialCreate
// dotnet ef database update


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseRouting();
app.MapControllers();

app.UseHttpsRedirection();

app.Run();

