# kula-learn
Kula Learn is a learning management system. It allows instructors to add courses and other users can enroll and learn the available courses. 

### Production environment

This application is currently deployed via Cloud Run here: https://kula-learn-mvc-cck37mrz7a-ue.a.run.app/.

### Screenshots

![Welcome Page](https://res.cloudinary.com/db1z5jvko/image/upload/v1700090150/msedge_cIDE6Gy3bb_oylxld.png)
![All Courses View - Instructor](https://res.cloudinary.com/db1z5jvko/image/upload/v1700090150/msedge_KlgaJWFqyE_xjend1.png)
![Single Course View](https://res.cloudinary.com/db1z5jvko/image/upload/v1700090404/msedge_29uZJS7OvH_lp4en3.png)
![Registration Page](https://res.cloudinary.com/db1z5jvko/image/upload/v1700090150/msedge_WPiQ1LoEQ8_ebgyhe.png)


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
Then navigate to https://localhost:44344/ to start the application