<h1>📘 Sozluk Project</h1>
  <p>
    This project is a dictionary application developed by applying modern software development principles and techniques.
    It incorporates a robust architectural design and leverages popular software development tools and frameworks.
  </p>
  
  <h2>🛠️ Technologies and Tools Used</h2>
  <h3>Architectural Design</h3>
  <ul>
    <li><strong>Onion Architecture:</strong> Provides a layered and decoupled structure, domain-centric, organizing dependencies outward.</li>
    <li><strong>CQRS:</strong> Separates read and write operations for better scalability and maintainability.</li>
    <li><strong>Event-Driven Architecture:</strong> Implements asynchronous workflows using RabbitMQ.</li>
  </ul>
  
  <h3>Libraries and Frameworks</h3>
  <ul>
    <li><strong>Entity Framework Core:</strong> ORM for database operations.</li>
    <li><strong>Dapper:</strong> Micro ORM for performance-critical tasks.</li>
    <li><strong>MediatR:</strong> Facilitates CQRS and mediator design patterns.</li>
    <li><strong>AutoMapper:</strong> Object-to-object mapping.</li>
    <li><strong>FluentValidation:</strong> Simplifies input validation processes.</li>
    <li><strong>RabbitMQ:</strong> Messaging system for event-driven architecture.</li>
  </ul>
  
  <h3>Database</h3>
  <p><strong>Microsoft SQL Server:</strong> Relational database management system used in the project.</p>
  
  <h3>Projections and Handlers</h3>
  <p>
    Projections and other operations are processed via worker services.
    Messages sent through RabbitMQ are consumed by these worker services to execute tasks.
  </p>
  
  <h3>Programming Language</h3>
  <p><strong>C#:</strong> The entire project is developed in C#.</p>
  
  <h2>🚀 Features</h2>
  <ul>
    <li>User Management: Register, log in, and manage profiles.</li>
    <li>Entry and Comment Management: Create dictionary entries and comments.</li>
    <li>Voting System: Vote on entries and comments.</li>
    <li>Asynchronous Operations: Message-based workflows using RabbitMQ.</li>
    <li>Validation: Simplified input and data validation with FluentValidation.</li>
  </ul>
  
  <h2>📂 Project Structure</h2>
  <ul>
    <li><strong>API Layer:</strong> Entry point for user interactions.</li>
    <li><strong>Application Layer:</strong> Manages business logic and CQRS operations.</li>
    <li><strong>Domain Layer:</strong> Core business logic.</li>
    <li><strong>Infrastructure Layer:</strong> Manages external dependencies like the database and RabbitMQ.</li>
  </ul>
  
  <h2>🛠️ Installation and Running</h2>
  <ol>
    <li><strong>Clone the repository:</strong>
      <pre><code>git clone https://github.com/Yusuftmle/Sozluk.git</code></pre>
    </li>
    <li><strong>Configure the SQL Server database connection:</strong>
      Update the <code>ConnectionStrings</code> section in <code>appsettings.json</code>.
    </li>
    <li><strong>Install project dependencies:</strong>
      <pre><code>dotnet restore</code></pre>
    </li>
    <li><strong>Start the RabbitMQ server:</strong>
      Ensure RabbitMQ is installed and running on your system.
    </li>
    <li><strong>Run the application:</strong>
      <pre><code>dotnet run</code></pre>
    </li>
  </ol>
  
  <h2>💡 Developer Notes</h2>
  <p>
    The project is designed in adherence to <strong>SOLID principles</strong>, ensuring extensibility and maintainability.
    The combination of CQRS, Event-driven architecture, and Onion Architecture provides a modular and scalable foundation for business logic separation.
  </p>
  
  <h2>📖 References</h2>
  <ul>
    <li><a href="https://www.amazon.com/Clean-Architecture-Craftsmans-Software-Structure/dp/0134494164" target="_blank">Clean Architecture Principles</a></li>
    <li><a href="https://martinfowler.com/bliki/CQRS.html" target="_blank">CQRS Design Pattern</a></li>
    <li><a href="https://github.com/jbogard/MediatR" target="_blank">MediatR Documentation</a></li>
    <li><a href="https://docs.automapper.org/en/stable/" target="_blank">AutoMapper Documentation</a></li>
  </ul>
