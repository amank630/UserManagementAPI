# User Management API (.NET)

## Features
- User Registration & Login
- JWT Authentication
- Secure APIs with Authorization
- SQL Server with Entity Framework Core
- Repository Pattern + Service Layer
- DTO-based Architecture

## Tech Stack
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT Authentication

## How to Run
1. Clone repository
2. Update connection string
3. Run migrations
4. Run project

## API Endpoints
- POST /api/user/register

## Architecture
Controller → Service → Repository → Database

## Security
- JWT Authentication
- Password Hashing (BCrypt)

## Future Improvements
- Role-based authorization
- Refresh tokens
- Docker deployment
- POST /api/user/login
- GET /api/user (Protected)

## Screenshots

### Swagger UI
![Swagger](./screenshots/UserManagementAPI.jpeg)

### Login Response (JWT Token)
![Login](./screenshots/Login.jpeg)

### Add User
![Add User](./screenshots/Add User.jpeg)

### Users List
![Users List](./screenshots/User List.jpeg)

### Get User By ID
![Get User By ID](./screenshots/Get User By ID.jpeg)