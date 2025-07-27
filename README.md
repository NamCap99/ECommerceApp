# ECommerce Web API (.NET 9 – Clean Architecture)

A real-world, production-grade **E-Commerce Web API** built with **ASP.NET Core 9**, following **Clean Architecture**, **SOLID principles**, and modern backend practices.

---

## Tech Stack

- ASP.NET Core 8 (Web API)
- Entity Framework Core
- SQL Server (via EF Core)
- JWT Authentication & Role-based Authorization
- FluentValidation
- Stripe (Payment Integration)
- Swagger (OpenAPI)
- xUnit, Moq (Testing)

---

## Folder Structure

```text
ECommerce/
│
├── Application/       # Business logic layer
│   ├── Interfaces/    # Service + Repository contracts
│   ├── DTOs/          # Request & Response models
│   ├── Services/      # Core business rules
│   └── Validators/    # FluentValidation for input models
│
├── Domain/            # Domain entities and enums (pure C#)
│   ├── Entities/      # Product, Order, Cart, User, etc.
│   └── Enums/         # OrderStatus, PaymentMethod, etc.
│
├── Infrastructure/    # Data access & 3rd-party integrations
│   ├── Persistence/   # EF Core DbContext & Repositories
│   ├── Config/        # DB seeding, config options
│   └── External/      # Stripe, EmailService, etc.
│
├── API/               # ASP.NET Core Web API layer
│   ├── Controllers/   # REST endpoints
│   ├── Middlewares/  # Custom exception logging, auth
│   ├── Filters/       # Request validation, auth filters
│   └── Program.cs     # Main entrypoint (top-level API wiring)
│
├── Shared/            # Shared utilities across layers
│   ├── Responses/     # Standard API response format
│   └── Extensions/    # Common helpers (e.g. LINQ, string)
│
├── Tests/             # Unit & integration test projects
│   ├── Application.Tests/
│   ├── API.Tests/
│
├── ECommerce.sln      # Solution file
