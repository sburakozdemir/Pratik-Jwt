# Pratik JWT Authentication API

This project is a simple implementation of JSON Web Token (JWT) based authentication in an ASP.NET Core API. It includes user registration and login functionality using ASP.NET Core Identity and JWT for secure token generation.

## Features

- **User Registration**: Allows new users to register.
- **User Login**: Validates user credentials and issues JWT tokens for authentication.
- **JWT-based Authentication**: Protects API endpoints using JWT tokens.
- **ASP.NET Core Identity**: Manages user authentication and authorization.
- **Swagger Documentation**: Built-in Swagger for API exploration.

## Technologies Used

- ASP.NET Core 8.0
- ASP.NET Core Identity
- Entity Framework Core (EF Core) with SQL Server
- JWT for secure authentication
- Swagger for API documentation

## Project Structure

- **Controllers**: Contains `AuthController` for handling authentication-related actions (register, login, get users).
- **ViewModels**: Contains `RegisterViewModel` and `LoginViewModel` for handling user input.
- **Helpers**: Contains `Helper` class for generating JWT tokens.
- **Data**: Contains `JwtDbContext` which uses Entity Framework for data access.

## Endpoints

1. **Register**: `POST /api/auth/register`
   - Registers a new user with an email and password.
   - Sample request body:
     ```json
     {
       "email": "user@example.com",
       "password": "password123"
     }
     ```

2. **Login**: `POST /api/auth/login`
   - Logs in a user with email and password, returning a JWT token.
   - Sample request body:
     ```json
     {
       "email": "user@example.com",
       "password": "password123",
       "rememberMe": true
     }
     ```

3. **Get Users**: `GET /api/auth/get`
   - Retrieves a list of users. This endpoint is protected by JWT authentication and requires a valid token in the request header.
