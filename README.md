<div align="center">

<!--<img src="https://raw.githubusercontent.com/your_username/your_repo/main/assets/logo.png" style="width: 40%; max-width: 250px;" />-->

---

<h3>Library WebServer</h3>

<p>ASP.NET Core Web API for managing library operations such as books, users, rentals, and reservations. Built with Entity Framework Core and PostgreSQL.</p>

---

### Navigation

[Overview](#overview) • [Tech Stack](#tech-stack) • [How to Run](#how-to-run) • [Features](#features)

</div>

## Overview

This backend project is a modular, RESTful API built using **ASP.NET Core 7.0**. It enables full management of a digital library <br>system - supporting publication browsing, user authentication, book rentals, reservations, and comments.

It uses **Entity Framework Core** as ORM and supports PostgreSQL as the default relational database engine.


## Tech Stack

| Category        | Technology                            |
|----------------|----------------------------------------|
| Language        | C#                                     |
| Framework       | ASP.NET Core 7.0                       |
| ORM             | Entity Framework Core (7.0.14)         |
| Database        | PostgreSQL (via Npgsql)                |
| API Docs        | Swashbuckle / Swagger                  |
| Hosting         | Kestrel (built-in)                     |

## How to Run

<details>
<summary>🛠️ Development Setup</summary>

```bash
# Ensure you have .NET 7.0 SDK installed
dotnet --version

# Navigate to the main project folder
cd Library_WebServer

# Restore dependencies
dotnet restore

# Apply migrations (if using PostgreSQL)
dotnet ef database update

# Run the server
dotnet run
```

The app will start by default on: https://localhost:5001<br>
API docs available at: https://localhost:5001/swagger
</details>

## Features

| Feature                                  | Status |
|------------------------------------------|--------|
| User registration and authentication     | ✅     |
| Manage authors and publications          | ✅     |
| Book reservation system                  | ✅     |
| Book rental logic                        | ✅     |
| Comments for publications                | ✅     |
| Swagger documentation                    | ✅     |
| PostgreSQL database integration          | ✅     |
| Entity Framework Core ORM                | ✅     |
| Database seeding (`DbInitializer`)       | ✅     |

<br>
✅ done 🛠️ in progress 🕒 planned
