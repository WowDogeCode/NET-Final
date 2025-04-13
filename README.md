# NET-Final 🎯

A modular .NET 8 Web API project built using layered architecture and modern development practices, powered by the classic **Northwind** database.

![.NET Version](https://img.shields.io/badge/.NET-8.0-blueviolet)
![License](https://img.shields.io/badge/license-MIT-green)

---

## ✅ Tech Stack

- **.NET 8**
- **Entity Framework Core**
- **Autofac** for Dependency Injection
- **Redis** for distributed caching
- **In-memory caching**
- **FluentValidation** for robust validation
- **JWT Authentication & Authorization**
- **Aspect-Oriented Programming (AOP)** for cross-cutting concerns
- **Docker** support (with docker-compose)

---

## 🧱 Architecture

This project follows a **Layered Architecture** with the following layers:

- `API` - Exposes HTTP endpoints  
- `Business` - Contains business rules  
- `DataAccess` - Contains repositories using EF Core  
- `Entities` - Contains core domain models & DTOs  
- `Core` - Shared utilities like Result wrappers, caching, Ef base repository & security interfaces  

> ⚙️ **Database:** Uses the classic **Northwind** schema for demo & testing purposes.  
> For authentication & authorization, the `OperationClaim`, `User`, and `UserOperationClaim` tables have been added on top of the classic Northwind schema.

---

## 🚀 Features

- 🔐 **JWT Authentication & Authorization**  
  Secure endpoints with role-based access

- ♻️ **Extensible Repository Pattern**  
  A flexible and DRY base class for EF repositories, easily extended per entity

- 🔁 **Caching**  
  Redis-backed cache service with configurable keys  
  Supports both in-memory and distributed caching strategies

- 🔍 **Validation**  
  FluentValidation integration for validation

- 🧩 **Dependency Injection with Autofac**

- ✅ **AOP**  
  Clean separation of logging, caching, validation via interceptors

- 📘 **Swagger UI**  
  Built-in interactive API for testing endpoints

- 🐳 **Docker Support**  
  Includes `docker-compose.yml` with Redis & SQL Server configuration

---

## ⚙️ Development

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [Docker](https://www.docker.com/)

### Running the App

docker-compose up --build

## 🙌 Acknowledgements

This project was made possible with the help and inspiration from:

- 🎓 [Engin Demiroğ’s YouTube Series](https://youtube.com/playlist?list=PLqG356ExoxZVN7rC0KmMo0lvECK97VRZg&si=On0aeDN_U47ZFXHB) & [GitHub](https://github.com/engindemirog) — for the foundational structure and concepts  
- 💬 [Stack Overflow](https://stackoverflow.com/) — for solving issues and bugs  
- 🤖 [ChatGPT](https://chat.openai.com/) — for guidance, code reviews, design decisions
