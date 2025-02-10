# Architecture

## Overview
The Task Management System is designed with a multi-layered architecture and follows the MVVM (Model-View-ViewModel) design pattern to ensure separation of concerns and maintainability. This document provides an overview of the system's architecture.

## Layers
### 1. Presentation Layer
- This layer contains the WPF views and view models. The views are responsible for the UI, while the view models handle the presentation logic.

#### Components:
- **ViewModels**:
  - BaseViewModel.cs
  - CommentViewModel.cs
  - MainViewModel.cs
  - TaskCreationViewModel.cs
  - TaskDetailsViewModel.cs
  - TaskViewModel.cs
  - ViewModelLocator.cs
- **Views**:
  - CommentView.xaml
  - TaskCreationView.xaml
  - TaskDetailsView.xaml
  - TaskView.xaml
- **Other**:
  - App.config
  - App.xaml
  - App.xaml.cs
  - AssemblyInfo.cs
  - MainWindow.xaml
  - MainWindow.xaml.cs
  - RequiredValidationRule.cs

### 2. Business Logic Layer
- This layer contains the business logic of the application. It processes the data and applies business rules.

#### Components:
- **Services**:
  - Interfaces
  - CommentService.cs
  - TaskService.cs
  - UserService.cs

### 3. Data Access Layer
- This layer interacts with the database. It includes the Entity Framework Core context and repository classes.

#### Components:
- **Contexts**:
  - Contains the database context classes.
- **Enums**:
  - Contains enumeration types used in the application.
- **Migrations**:
  - Contains migration scripts for setting up and updating the database schema.
- **Models**:
  - Comment.cs
  - Task.cs
  - User.cs
- **Repositories**:
  - Interfaces
  - CommentRepository.cs
  - TaskRepository.cs
  - UserRepository.cs

## Design Pattern: MVVM
- **Model**: Represents the data and business logic. In this application, the models correspond to the entities such as Task and Comment.
- **View**: Represents the UI. In this application, views are the XAML files.
- **ViewModel**: Acts as an intermediary between the view and the model. It handles the presentation logic and data binding.

## Diagrams
Include any relevant architecture or database schema diagrams here.

## Database Schema
Provide an overview of your database schema here, including diagrams if necessary.

### Entities
1. **Task**
   - Attributes: CreatedDate, RequiredByDate, Description, Status, Type, AssignedTo, NextActionDate
2. **Comment**
   - Attributes: DateAdded, Comment, CommentType, ReminderDate

---
