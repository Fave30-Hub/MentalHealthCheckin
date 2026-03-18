# Mental Health Check-In Mini App

A modern full-stack mini application to track and submit employee mental health check-ins. Built using **ASP.NET Core (.NET 10)** for the backend and **Next.js + React + TailwindCSS** for the frontend, with **PostgreSQL** as the database. The application supports CRUD operations for check-ins, real-time feedback using toast notifications, and modern UI design.  

-------------------------------------------------------------------------------------

## **Table of Contents**

- [Features](#features)  
- [Technologies & Tools](#technologies--tools)  
- [Setup & Installation](#setup--installation)  
  - [Backend](#backend)  
  - [Frontend](#frontend)  
- [Running the Application](#running-the-application)  
- [Testing](#testing)  
- [Folder Structure](#folder-structure)  
- [Contributing](#contributing)  
- [License](#license)  

-------------------------------------------------------------------------------------

## **Features**

- Submit mental health check-ins (Mood, Score, Comment)  
- Auto-generated or user-defined Employee ID  
- Modern UI with TailwindCSS  
- Real-time toast notifications for feedback  
- View previously submitted check-ins  
- Full backend validation with ASP.NET Core  
- Supports PostgreSQL persistence  

-------------------------------------------------------------------------------------

## **Technologies & Tools**

**Backend:**  
- ASP.NET Core (.NET 10)  
- Entity Framework Core (EF Core)  
- PostgreSQL  
- C# with Clean Architecture (Domain, Application, Infrastructure, API layers)  
- Swagger / OpenAPI for API testing  
- Dependency Injection & Repository Pattern  

**Frontend:**  
- Next.js 16 (React 18)  
- TypeScript  
- TailwindCSS for modern responsive design  
- React Query (TanStack Query) for data fetching & mutations  
- React Hot Toast for notifications  
- UUID for Employee ID generation
- Axios HTTP client for API requests

**Testing:**  
- Jest + React Testing Library (Frontend)  
- xUnit / NUnit (Backend)  
- Integration tests for API endpoints  
- Unit tests for services and repositories  

**Other Tools:**  
- VS Code / Visual Studio  

-------------------------------------------------------------------------------------

## **Setup & Installation**

### **Backend**

1. Clone the repository:

git clone <https://github.com/Fave30-Hub/MentalHealthCheckin.git>
cd MentalHealthCheckin

2. Open MentalHealthCheckin.sln in Visual Studio 2022+ or VS Code.

3. Configure PostgreSQL connection in appsettings.json.

4. Apply migrations and create the database.

5. Run the backend.
- The backend API will be available at https://localhost:7003 (or your configured port). Swagger UI is available at /swagger.

### **Frontend**

1. Navigate to the frontend folder.

2. Install dependencies.

3. Run the frontend development server.
- The frontend will be available at http://localhost:3000.

-------------------------------------------------------------------------------------

## **Running Application**

1. Start the backend (dotnet run)

2. Start the frontend (npm run dev)

3. Open http://localhost:3000 in your browser

5. Submit check-ins using the form. Previously submitted check-ins are displayed below.

6. Toast notifications indicate submission success or failure.

-------------------------------------------------------------------------------------

## **Testing** 

### **Frontend**

1. Run tests with Jest

### **Backend**

1. Run unit & integration tests
2. Includes tests for repositories, services, and API endpoints.

-------------------------------------------------------------------------------------

## **Folder Structure**

MentalHealthCheckin/
├── MentalHealthCheckin.Api             # ASP.NET Core API
├── MentalHealthCheckin.Application     # Application layer (services, DTOs, interfaces)
├── MentalHealthCheckin.Domain          # Domain entities, value objects, enums
├── MentalHealthCheckin.Infrastructure  # Repositories, DbContext, EF Core setup
├── MentalHealthCheckin.Tests           # Backend unit & integration tests
├── frontend/                           # Next.js frontend
│   ├── src/
│   │   ├── app/features/checkin/       # Check-in features (hooks, API, UI)
│   │   └── app/layout.tsx              # Root layout
│   └── package.json
└── README.md

-------------------------------------------------------------------------------------

## **UI Notes**

1. Form fields: Employee ID (auto-generated or editable), Mood (1–3), Score (1–5), Comment.

2. Labels: Clearly indicate Mood and Score for clarity.

3. Button: Shows loading state while submitting.

4. Check-in list: Displays Employee ID, Mood, Score, Comment, and formatted date.

5. Notifications: Modern toast notifications.

-------------------------------------------------------------------------------------

