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
git clone https://github.com/your-username/Course-Enrollment-System.git
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
https://localhost:5001
```

### 3. Database Setup
Since the system uses an in-memory database, no explicit setup is needed. Sample data is seeded automatically.

---

## Running Tests
### Backend Tests
To run unit tests for the .NET backend:
```bash
dotnet test
```

---

## Project Structure
```
Course-Enrollment-System/
│── Backend/              # .NET MVC Backend
│   ├── Controllers/      # API Controllers
│   ├── Services/         # Business Logic Layer
│   ├── Models/           # Entity Models
│   ├── Data/             # EF Core Database Context
│   ├── Views/            # MVC Views
│   ├── appsettings.json  # Configuration File
│
│── README.md             # Project Documentation
│── .gitignore            # Files to Ignore in Git
```

---

## Features Implemented
### 1. Student Management
- Add, edit, delete, and list students.
- Fields:
  - Full Name (required)
  - Email (unique, required)
  - Birthdate (required)
  - National ID No (required, max 14 characters)
  - Phone Number (optional, max 11 characters)

### 2. Course Management
- Add, edit, delete, and list courses.
- Fields:
  - Title (required)
  - Description (optional)
  - Maximum Capacity (required)

### 3. Enrollment Management
- Enroll students in courses.
- Restrictions:
  - Prevent enrollment if the course is full.
  - Prevent duplicate enrollments.

### 4. UI Enhancements
- jQuery-powered **dynamic course slot display** in the enrollment form.
- Pagination for course listing (Bonus feature).
- Partial views for improved UI structure.

---

## Contribution Guidelines
1. Fork the repository
2. Create a feature branch (`git checkout -b feature-branch`)
3. Commit changes (`git commit -m "Your message"`)
4. Push to the branch (`git push origin feature-branch`)
5. Open a pull request

---

## License
This project is licensed under the **MIT License**.

---

## Contact
For any issues or inquiries, reach out to `your-email@example.com`.

