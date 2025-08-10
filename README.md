# SkillSnap 

SkillSnap is a full-stack Blazor WebAssembly application that lets users showcase their skills and personal projects. Built with ASP.NET Core and powered by modern authentication, caching, and responsive UI.

## eatures

- 🔐 Secure login & registration with JWT and ASP.NET Identity
- ✏️ Full CRUD on Projects and Skills (create, read, update, delete)
- 🔒 Role-based access control (`User`, `Admin`)
- ⚡ In-memory caching with `IMemoryCache`
- 🧠 Blazor session state management via `UserSessionService`
- 🧪 Verified performance using `Stopwatch` and cache logging

## Technologies

- .NET 9, ASP.NET Core Web API
- Blazor WebAssembly (client-side)
- Entity Framework Core
- SQL Server (local or cloud-based)
- Swagger for API testing

## How to Run

```bash
# From project root
dotnet build

# Run API
dotnet run --project SkillSnap.Api

# Run Client (if standalone)
dotnet run --project SkillSnap.Client
