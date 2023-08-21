# PortfolioApp

Welcome to the repository for **PortfolioApp**! This project showcases the use of modern technologies to build a robust web application.

## Technology Stack

### Minimal API in .NET 7
We've utilized the latest features of .NET 7 to build a clean and minimal API for this project. .NET 7 brings a host of improvements to help streamline development and enhance performance.

### Entity Framework Core
Entity Framework Core is our chosen ORM (Object-Relational Mapping) framework. It simplifies database interactions, providing a high-level abstraction over database operations and allowing us to work with databases using C# code.

### CQRS (Command Query Responsibility Segregation)
We've adopted the CQRS architectural pattern to separate the concerns of reading data (queries) and writing data (commands) into separate components. This approach can help improve scalability, maintainability, and performance in complex applications.

### Custom Command and Query Handling
Instead of using a library like MediatR, we've implemented our own command and query handling mechanisms. This allows us to have more control over the interactions between different parts of the application and tailor them to our specific requirements.

## Getting Started

To get started with the project, follow these steps:

1. Clone this repository to your local machine.
2. Make sure you have .NET 7 SDK installed. You can download it from [here](https://dotnet.microsoft.com/download/dotnet/7.0).
3. Set up your database connection string in the `appsettings.json` file.
4. Run the database migrations using the following command:

`dotnet ef database update`

5. Build and run the application:

`dotnet run`

6. Access the API at `http://localhost:5000`.

## Contributing

We welcome contributions to improve and expand upon this project. If you'd like to contribute, please follow our [contribution guidelines](CONTRIBUTING.md).

## License

This project is licensed under the [MIT License](LICENSE).
Feel free to customize the content to better suit your project and repository structure. Make sure to add any relevant additional sections, such as installation instructions, usage examples, or deployment guidelines.






