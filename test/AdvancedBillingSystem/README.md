# Advanced Billing System

## Overview
The Advanced Billing System is a multi-tenant billing application designed to manage invoices, billing strategies, and discounts efficiently. It leverages Entity Framework Core for data management and provides a flexible architecture to accommodate various billing needs.

## Features
- **Multi-Tenant Support**: The system is designed to handle multiple tenants, ensuring data isolation and security.
- **Billing Strategies**: Implement various billing strategies, including fixed fee and usage-based billing.
- **Invoice State Management**: Manage the lifecycle of invoices with state transitions.
- **Flexible Discount System**: Apply different discount policies, including percentage-based and tiered discounts.

## Project Structure
The project is organized into several key components:
- **Controllers**: Handle HTTP requests and responses.
- **Data**: Contains the Entity Framework Core context and migrations.
- **Entities**: Defines the core data models used in the application.
- **Repositories**: Interfaces and implementations for data access.
- **Services**: Business logic for billing and tenant management.
- **Billing Strategies**: Interfaces and implementations for different billing calculations.
- **Discounts**: Interfaces and implementations for discount policies.
- **Invoicing**: Manages invoice states and transitions.
- **Middleware**: Handles multi-tenant requests.
- **DTOs**: Data transfer objects for communication between layers.
- **Utilities**: Helper classes for tenant resolution.

## Getting Started
1. Clone the repository:
   ```
   git clone <repository-url>
   ```
2. Navigate to the project directory:
   ```
   cd AdvancedBillingSystem/src/AdvancedBillingSystem
   ```
3. Restore the dependencies:
   ```
   dotnet restore
   ```
4. Update the `appsettings.json` file with your database connection string.
5. Run the application:
   ```
   dotnet run
   ```

## Testing
- Integration tests are located in the `AdvancedBillingSystem.IntegrationTests` project.
- Unit tests can be found in the `AdvancedBillingSystem.UnitTests` project.
- To run tests, use the following command:
   ```
   dotnet test
   ```

## License
This project is licensed under the MIT License. See the LICENSE file for details.