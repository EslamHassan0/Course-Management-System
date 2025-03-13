# Course Enrollment System

## Overview
The **Course Enrollment System** is a web application built with **ASP.NET MVC** and **Entity Framework (Code-First)**, using an **in-memory database** to manage students, courses, and enrollments. It follows an **n-tier architecture** with services handling business logic.

## System Requirements
### Backend (ASP.NET MVC)
- **.NET SDK** (Latest stable version)
- **Entity Framework Core** (for database management)
- **Visual Studio 2022** or later (recommended)

### Database
- **Entity Framework Core In-Memory Database** (for development and testing)
- Sample data seeding enabled

### Frontend
- **jQuery** (for dynamic UI updates)
- **Bootstrap** (for responsive UI design)
- **Modern Web Browser** (Chrome, Edge, Firefox, etc.)

---

## Installation Instructions
### 1. Clone the Repository
```bash
git clone https://github.com/EslamHassan0/Course-Management-System.git
cd Course-Enrollment-System
```

### 2. Backend Setup
Navigate to the backend directory:
```bash
cd Backend
```

#### Restore dependencies
```bash
dotnet restore
```

#### Run the Application
```bash
dotnet run
```
The backend will run at:
```
https://localhost:7030
```

### 3. Database Setup
Since the system uses an in-memory database, no explicit setup is needed. Sample data is seeded automatically.

---

## Project Structure
```
Course-Management-System/
│── Application/          # Business Logic Layer
│   ├── Services/         # Business Logic Services
│   ├── Interfaces/       # Interface Definitions
│   ├── DTO/              # Data Transfer Object (DTO)
|   ├── Common/          # Common Services
|
│── DataAccess/           # EF Core Data Access Layer
│   ├── Entities/         # Database Entities
│   ├── Context/          # EF Core DbContext
│   ├── Migrations/       # Database Migrations
│   ├── Repositories/     # Generic Repository
|   ├── SeedingData/      # Data Seed of Memory 
|
│── Web/                 # ASP.NET MVC Application
│   ├── Controllers/      # MVC Controllers
│   ├── Views/            # Razor Views
│   ├── wwwroot/         # Static Files (CSS, JS, Images)
│
│── README.md             # Project Documentation
│── .gitignore            # Files to Ignore in Git
```
---
## Contact
For any issues or inquiries, reach out to `hassaneslam613@gmail.com`.

