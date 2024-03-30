**ASP.NET Core Web API with JWT Authentication**

This repository contains a sample ASP.NET Core Web API project that demonstrates how to create a secure API with JWT authentication. JWT (JSON Web Tokens) are a popular method for securely transmitting information between parties as JSON objects.

**Features**
Authentication: Users can authenticate using JWT tokens.
Authorization: Secure endpoints with role-based access control.
Swagger: Explore and test the API endpoints using Swagger UI.
Logging: Log requests, responses, and errors for debugging purposes.

**Prerequisites**
Before running this application, ensure you have the following installed:

.NET Core SDK version X.X or later
Visual Studio Code or any preferred code editor

**Getting Started**

1.Clone this repository to your local machine:
git clone https://github.com/your-username/your-repository.git

2.Navigate to the project directory:
cd your-repository

3.Configure the JWT settings in the appsettings.json file:

{
  "JwtSettings": {
    "SecretKey": "YourSecretKeyHere",
    "Issuer": "YourIssuerHere",
    "Audience": "YourAudienceHere",
    "ExpirationInMinutes": 1440
  }
}

4.Run the application:
dotnet run

5.Once the application is running, you can explore the API endpoints using Swagger UI. Open your web browser and navigate to:
https://localhost:5001/swagger

**Authentication**
To authenticate and access secure endpoints, follow these steps:

**Register User**: Send a POST request to /api/account/register with the user's credentials in the request body.
**Login**: Send a POST request to /api/account/login with the user's credentials in the request body. This will return a JWT token.
**Authorization**: Add the JWT token to the Authorization header in subsequent requests to access secure endpoints.

**API Endpoints**
The following endpoints are available:

POST /api/account/register: Register a new user.
POST /api/account/login: Login and receive a JWT token.
Secure Endpoints: Secure endpoints require authentication with a JWT token. Examples include:
GET /api/resource: Retrieve a list of resources.
GET /api/resource/{id}: Retrieve a specific resource by ID.
POST /api/resource: Create a new resource.
PUT /api/resource/{id}: Update an existing resource.
DELETE /api/resource/{id}: Delete a resource.

**Testing**
Unit tests and integration tests are located in the tests directory. You can run the tests using the following command:
dotnet test

**Contributing**
Contributions are welcome! Feel free to open an issue or submit a pull request for any improvements or features you'd like to add.

**License**
This project is licensed under the MIT License.
