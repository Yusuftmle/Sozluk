Sozluk Project
This project is a dictionary application developed by applying modern software development principles and techniques. It incorporates a robust architectural design and leverages popular software development tools and frameworks.

🛠️ Technologies and Tools Used
Architectural Design
Onion Architecture: Provides a layered and decoupled structure. It is domain-centric and organizes dependencies outward.
CQRS (Command Query Responsibility Segregation): Separates read and write operations on the data for better scalability and maintainability.
Event-Driven Architecture: Implements asynchronous messaging workflows using RabbitMQ.
Libraries and Frameworks
Entity Framework Core: Used as an ORM tool for database operations.
Dapper: Selected as a micro ORM solution for performance-critical operations.
MediatR: Facilitates CQRS and mediator design patterns.
AutoMapper: Used for object-to-object mapping.
FluentValidation: Simplifies input validation processes.
RabbitMQ: Utilized as a messaging system for the event-driven architecture.

Database
Microsoft SQL Server: The relational database management system used in the project.
Projections and Handlers
Projections and other operations are processed via worker services.
Messages sent through RabbitMQ are consumed by these worker services to execute the corresponding tasks.
Programming Language
C#: The entire project is developed in C#.



🚀 Features
User Management: Allows users to register, log in, and manage their profiles.
Entry and Comment Management: Enables users to create dictionary entries and comments.
Voting System: Provides the ability to vote on entries and comments.
Asynchronous Operations: Implements message-based workflows using RabbitMQ.
Validation: Simplifies user input and data validation with FluentValidation.


📂 Project Structure
The project is structured into the following layers:

API Layer: Entry point for user interactions.
Application Layer: Manages business logic and CQRS operations.
Domain Layer: Contains the core business logic.
Infrastructure Layer: Manages external dependencies like the database and RabbitMQ.
🛠️ Installation and Running
Clone the repository:


git clone https://github.com/Yusuftmle/Sozluk.git
Configure the SQL Server database connection:
Update the ConnectionStrings section in the appsettings.json file.

Install project dependencies:


dotnet restore
Start the RabbitMQ server:
Ensure RabbitMQ is installed and running on your system.

Run the application:

dotnet run


💡 Developer Notes
The project is designed in adherence to SOLID principles to ensure easy extensibility and maintainability.
The combination of CQRS, Event-driven architecture, and Onion Architecture provides a modular and scalable foundation for business logic separation.
