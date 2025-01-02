# Online Course Management System

## Table of Contents
1. [Project Overview](#project-overview)
2. [Features](#features)
3. [Getting Started](#getting-started)
   - [Prerequisites](#prerequisites)
   - [Installation](#installation)
4. [Usage](#usage)
5. [API Endpoints](#api-endpoints)
6. [Contributing](#contributing)
7. [Authors](#authors)
8. [License](#license)
9. [FAQ](#faq)

## Project Overview

The Online Course Management System is an ASP.NET Core web application designed to manage courses, instructors, students, and classrooms. It provides a RESTful API for interacting with the data, facilitating easy integration with front-end applications or other services.

## Features

- **Course Management:** CRUD operations for courses, including adding descriptions, assigning instructors, and associating classrooms.
- **Instructor Management:** CRUD operations for instructors, including managing the courses they teach.
- **Student Management:** CRUD operations for students, including managing the courses they are enrolled in.
- **Classroom Management:** CRUD operations for classrooms, including managing the courses that take place in them.
- **Data Validation:** Ensures data entered into the system adheres to defined constraints.
- **Database Integration:** Uses Entity Framework Core for database operations, with SQL Server as the backend.

## Getting Started

### Prerequisites

- [.NET SDK 8.0](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/sql-server)
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

### Installation

1. **Clone the repository:**

   ```bash
   git clone https://github.com/yourusername/Online-Course-Management-System.git
   ```

2. **Navigate to the project directory:**

   ```bash
   cd Online-Course-Management-System/Online\ Course\ Management\ System
   ```

3. **Restore NuGet packages:**

   ```bash
   dotnet restore
   ```

4. **Update the connection string in `appsettings.json` to match your SQL Server instance.**

5. **Run database migrations:**

   ```bash
   dotnet ef database update
   ```

6. **Run the application:**

   ```bash
   dotnet run
   ```

   The application will be available at `http://localhost:5050`.

## Usage

The application provides a RESTful API for managing courses, instructors, students, and classrooms. You can interact with the API using tools like [Postman](https://www.postman.com/) or [Swagger](https://swagger.io/).

### Swagger UI

To explore the API endpoints and try them out, navigate to:

```
http://localhost:5050/swagger
```

## API Endpoints

### Courses

- **Get all courses:**

  ```http
  GET /api/course
  ```

- **Get a course by ID:**

  ```http
  GET /api/course/{id}
  ```

- **Add a new course:**

  ```http
  POST /api/course
  ```

- **Update a course:**

  ```http
  PUT /api/course/{id}
  ```

- **Delete a course:**

  ```http
  DELETE /api/course/{id}
  ```

### Instructors

- **Get all instructors:**

  ```http
  GET /api/instructor
  ```

- **Get an instructor by ID:**

  ```http
  GET /api/instructor/{id}
  ```

- **Add a new instructor:**

  ```http
  POST /api/instructor
  ```

- **Update an instructor:**

  ```http
  PUT /api/instructor/{id}
  ```

- **Delete an instructor:**

  ```http
  DELETE /api/instructor/{id}
  ```

### Students

- **Get all students:**

  ```http
  GET /api/student
  ```

- **Get a student by ID:**

  ```http
  GET /api/student/{id}
  ```

- **Add a new student:**

  ```http
  POST /api/student
  ```

- **Update a student:**

  ```http
  PUT /api/student/{id}
  ```

- **Delete a student:**

  ```http
  DELETE /api/student/{id}
  ```

### Classrooms

- **Get all classrooms:**

  ```http
  GET /api/classroom
  ```

- **Get a classroom by ID:**

  ```http
  GET /api/classroom/{id}
  ```

- **Add a new classroom:**

  ```http
  POST /api/classroom
  ```

- **Update a classroom:**

  ```http
  PUT /api/classroom/{id}
  ```

- **Delete a classroom:**

  ```http
  DELETE /api/classroom/{id}
  ```

## Contributing

Contributions are welcome! Please read the [CONTRIBUTING.md](CONTRIBUTING.md) document for guidelines on how to contribute to this project.

## Authors

- **Hosny Mohammed** - *SWE* - [Hosny-Mohammed](https://github.com/Hosny-Mohammed)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.

## FAQ

- **Q:** How do I run the application?
  - **A:** Follow the "Getting Started" section in the README.

- **Q:** How do I interact with the API?
  - **A:** Use Swagger UI at `http://localhost:5050/swagger` to explore and test the API endpoints.

- **Q:** Can I use this project for my own purposes?
  - **A:** Yes, under the terms of the MIT License.

- **Q:** How do I report an issue or suggest a feature?
  - **A:** Please open an issue on the [GitHub repository](https://github.com/Hosny-Mohammed/Online-Course-Management-System/issues).
