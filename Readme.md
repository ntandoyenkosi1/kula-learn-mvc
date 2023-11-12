# kula-learn
Kula Learn is a learning management system. It allows instructors to add courses and other users can enroll and learn the available courses. 

### Production environment

This application is currently not deployed on a production environment.

### Features

Authentication

- User registration.

- Login.

- Token based authentication.

- Persistent session that is active for 12 hours.

Authorization

Users, Courses and Modules

- All CRUD functionality present.

- Role-based authorization on all functionality

Features

- Markdown support for individual modules to support for rich content delivery.

- Optional video explanations where they apply.

- Responsive Design.
  

### Run Development environment

Restore packages
```shell
dotnet restore
```
Run project
```shell
dotnet run
```
Then navigate to https://localhost:7009 to start the application