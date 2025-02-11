# Task Management System

## Overview
The Task Management System is a simple application for creating, managing, and tracking tasks. It allows users to add comments, set reminders, and search for tasks and comments.

## Features
- Create and manage tasks with various attributes (created date, required by date, description, status, type, assigned to, next action date).
- Add, edit, and delete comments on tasks with attributes (date added, comment, comment type, reminder date).
- Search functionality to find tasks and comments.
- Dashboard to display opened, closed, and due tasks.

## Architecture
The application follows a multi-layered architecture and the MVVM design pattern. It is built using WPF in C# and uses MSSQL as the database.

## Dependencies
- .NET 9.0
- WPF
- MSSQL
- LINQ

## Setup Instructions
1. **Prerequisites**:
   - Install .NET 9.0 SDK.
   - Install MSSQL.

2. **Clone the Repository**:
   ```bash
   git clone https://github.com/BorislavEnchev/TtaskManagementSystem.git
   cd TaskManagementSystem

3. **Set Up the Database/ Configure the Connection String**:
   - Open the DesignTimeDbContextFactory class located in TaskManagementSystem.DAL.Contexts   
   - Update the connectionString to point to your database

4. **Run EF Core Migrations**:
    - Open a terminal in the project directory. 
    - Run the following commands to apply migrations and create the database:
        dotnet ef migrations add InitialCreate
        dotnet ef database update   

5. **Build and Run the Application**:
   - Open the solution file (`TaskManagementSystem.sln`) in Visual Studio.
   - Restore NuGet packages.
   - Build and run the application.

## Usage
### Creating user
- First you need to add a User.
- User Create (Test User) button on the main window.

### Creating Tasks
- Navigate to the "Create Task" page.
- Fill in the required fields and click "Save" to create a new task.

### Managing Tasks
- Navigate to the "Task Dashboard" page.
- Open Task details by dobule click on it or,
- Select a task and click Update to view/edit its details.
- Edit or delete the task as needed.

### Adding Comments
- Navigate to the task details page.
- Add a comment in the "Comments" section.
- Edit comments anytime then click Update to save.
- Delete comment as needed from the button next to it.

### Editing Comments
- Navigate to the task details page.
- Select comment from the "Comments" section.
- Click on the content and change as needed.

### Searching Tasks
- Use the search bar on the "Search" page to find tasks and comments.
- Search for certain word or perform empty search to reset.

## FAQ
### How do I install the required dependencies?
Refer to the setup instructions provided above.

### How do I create a new task?
Navigate to the "Create Task" page, fill in the required fields, and click "Save".

### How do I add a comment to a task?
Go to the task details page, enter your comment in the "Comments" section, and click "Add Comment".

## Additional Information
This application uses the following libraries and frameworks:
- **CommunityToolkit.Mvvm**: For MVVM pattern and data binding.
- **Entity Framework Core**: For ORM and database interactions.

For more detailed technical documentation, please refer to the `ARCHITECTURE.md`.
---
