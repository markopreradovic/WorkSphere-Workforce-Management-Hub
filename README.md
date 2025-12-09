# WorkSphere - Workforce Management Hub

A comprehensive web application built with **.NET 8 Blazor WebAssembly** and **ASP.NET Core Web API** for managing workforce records.  
This project demonstrates modern full-stack development practices, including CRUD operations, data export, printing, and a clean separation of concerns between client and server.

---

## Overview

WorkSphere provides an intuitive interface for HR teams and administrators to manage workforce data efficiently.  
It highlights best practices in **Blazor WASM client development**, **RESTful API design**, and **Entity Framework Core** integration.

---

## Key Features

- **Employee CRUD**: Create, Read, Update, Delete employee records
- **Search & Filtering**: Quickly locate employees by name, department, or status
- **Data Export**: Generate reports in **PDF** and **Excel**
- **Print Functionality**: Print employee details directly from the application
- **Responsive UI**: Optimized for desktop and mobile devices
- **Validation & Error Handling**: Client-side and server-side validation with clear feedback
- **Modular Architecture**: Clean separation of layers for scalability and maintainability

---

## Technologies & Tools

- **Frontend**: Blazor WebAssembly (.NET 8), Bootstrap, CSS
- **Backend**: ASP.NET Core Web API (.NET 8)
- **Database**: Entity Framework Core, SQL Server
- **Utilities**: AutoMapper (DTO mapping), FluentValidation (validation), ClosedXML/iText (Excel/PDF export), Serilog (logging)

| Category         | Technology / Tool                   | Details / Purpose                                                                                   |
|-----------------|------------------------------------|----------------------------------------------------------------------------------------------------|
| Backend          | .NET 8 Web API                      | Backend logic and exposing API endpoints.                                                         |
| Frontend         | Blazor WebAssembly Standalone       | Client interface, uses Razor components.                                                          |
| Database         | SQL Server / EF Core                | Relational database, using Code First approach for creating tables and migrations.                |
| Architecture     | Layered                             | Project separation into: Client, Server, Base Library (models/DTOs), Client Library (services), and Server Library (repositories/data access). |
| Security         | JWT Bearer Authentication           | Token-based authentication.                                                                       |
| Object Mapping   | AutoMapper                          | Used for converting between database entities and DTOs (Data Transfer Objects).                   |
| UI Components    | Syncfusion (SF Dialogue, SF Grid)   | Used for advanced UI elements such as dialogs, notifications, and data grid components (with PDF export support). |


---

## Project Structure


```
EmployeeManagement/
├─ src/
│  ├─ Client/                # Blazor WASM frontend
│  │  ├─ Pages/              # Razor pages for managing employees (e.g., Employees, EmployeeForm)
│  │  ├─ Components/         # Reusable UI components (e.g., Table, Filters, Modal)
│  │  ├─ Services/           # API service layer for handling HTTP requests (HttpClient wrappers)
│  │  ├─ Models/             # Data Transfer Objects (DTOs) and view models for data representation
│  │  └─ State/              # State management for employee data (EmployeeStore)
│  ├─ Server/                # ASP.NET Core Web API backend
│  │  ├─ Controllers/        # REST controllers for handling API requests (e.g., EmployeesController)
│  │  ├─ Application/        # Business logic services implementing core functionalities
│  │  ├─ Domain/             # Core entities representing the data model (e.g., Employee, Department)
│  │  ├─ Infrastructure/     # EF Core DbContext, repositories, and database migrations
│  │  └─ Mappings/           # AutoMapper profiles for mapping between entities and DTOs
│  └─ Shared/                # Shared DTOs and contracts used by both client and server
```

## Directory Explanations

- **src/**: Contains the source code for both the client and server applications.
  - **Client/**: 
    - **Pages/**: Contains Razor pages that define the user interface for managing employee records, such as listing employees and forms for adding or editing employee details.
    - **Components/**: Includes reusable UI components that can be used across different pages, enhancing the user experience.
    - **Services/**: Implements the API service layer, which wraps around `HttpClient` to facilitate communication between the client and the server.
    - **Models/**: Defines Data Transfer Objects (DTOs) and view models that represent the data exchanged between the client and server.
    - **State/**: Manages the application state for employee data, ensuring the UI updates reactively based on user interactions.

  - **Server/**:
    - **Controllers/**: Contains RESTful controllers that process incoming API requests and return appropriate responses.
    - **Application/**: Houses business logic services that implement the core functionalities of the application, such as validating and processing employee data.
    - **Domain/**: Defines the core entities of the application, such as `Employee` and `Department`, that represent the data model.
    - **Infrastructure/**: Manages database interactions using Entity Framework Core, including the `DbContext`, repositories, and migrations for database schema changes.
    - **Mappings/**: Contains AutoMapper profiles that define how to map between domain entities and DTOs.
---


## Data Flow & Functionality

1. **User Action**: A user interacts with the Blazor UI (e.g., adding an employee).
2. **Client Service**: The Blazor client sends a request via `HttpClient` to the API.
3. **API Controller**: The server validates input and delegates to business services.
4. **Business Logic**: Services handle domain rules and interact with the database.
5. **Persistence**: EF Core saves changes to SQL Server.
6. **Response**: The API returns a standardized response (success or error).
7. **UI Update**: The client updates state and re-renders components dynamically.

---

## API Endpoints

- `GET /api/employees` — Retrieve employee list (supports filters & pagination)
- `GET /api/employees/{id}` — Get employee details
- `POST /api/employees` — Create new employee
- `PUT /api/employees/{id}` — Update existing employee
- `DELETE /api/employees/{id}` — Delete employee
- `GET /api/employees/export/pdf` — Export employee list to PDF
- `GET /api/employees/export/excel` — Export employee list to Excel
