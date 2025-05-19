# ✈️ Travelport Registration API

A simple and extensible ASP.NET Core 9 Web API to register people with basic personal information and selected airport in Spain.

> ⏱️ Duration: 60–90 mins  
> ✅ Focused on: Clean Architecture, TDD, testing practices, and design clarity.

---

## 🧱 Architecture

This project follows **Clean Architecture** principles and separates responsibilities across layers:

Travelport.Registration/
├── src/
│ ├── Travelport.Domain/ # Domain entities and constants
│ ├── Travelport.Application/ # DTOs, validators, interfaces, business logic
│ ├── Travelport.Infrastructure/ # EF Core repository and DbContext
│ └── Travelport.API/ # API layer with controllers and DI
└── tests/
└── Travelport.Tests/ # xUnit unit tests (validators, services)


---

## 🚀 How to Run the App

1. **Clone the repo**  
2. Ensure you have [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0) (Preview or RC)
3. From root, run:

```bash
dotnet run --project src/Travelport.API

Now listening on: http://localhost:5201

📄 Sample Request
json
Copiar
Editar
{
  "name": "Julieta",
  "surname": "Pérez",
  "email": "julieta@example.com",
  "passportNumber": "PA1234567",
  "phone": "+34600000000",
  "airportCode": "MAD"
}
✈️ Valid airport codes:
text
Copiar
Editar
MAD, BCN, AGP, PMI, ALC, LPA, TFS, VLC, SVQ, BIO, IBZ, MAH, SCQ, OVD, GRO
✅ Tests
Run unit tests with:

bash
Copiar
Editar
dotnet test tests/Travelport.Tests
Coverage includes:

Passport format validator

Airport code validator

Business logic (registering person) using mock repository

⚙️ Tech Stack
.NET 9 Preview

ASP.NET Core Web API

EF Core InMemory

FluentValidation

Swagger UI

xUnit + Moq + FluentAssertions