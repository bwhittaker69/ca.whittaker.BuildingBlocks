# ca.whittaker.blocks Project

Welcome to the `ca.whittaker.blocks` project! This project houses the backend API for managing Architecture Building Blocks, providing endpoints to create, read, update, and delete various types of blocks and their relationships.

## Table of Contents

- [Introduction](#introduction)
- [Setup](#setup)
- [Project Structure](#project-structure)
- [Endpoints](#endpoints)
- [Models](#models)
- [Services](#services)
- [Controllers](#controllers)
- [Repositories](#repositories)
- [Helpers](#helpers)
- [Configuration](#configuration)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Introduction

The `ca.whittaker.blocks` project is the core of the Architecture Building Blocks Management API. It encompasses all the necessary components to handle building blocks and their types, from data models to services and controllers.

## Setup

1. Clone this repository to your local machine.
2. Ensure you have a PostgreSQL database set up with the schema and tables as defined in the provided SQL schema script.
3. Open the solution file and configure the `appsettings.json` with your database connection settings.
4. Build and run the `ca.whittaker.blocks` project.

## Project Structure

The project is structured as follows:

- `Controllers` - Contains API endpoints handling requests and responses.
- `Entities` - Holds entity classes that represent data structures.
- `Models` - Defines data models for creating and updating entities.
- `Repositories` - Provides data access to the database.
- `Services` - Implements business logic and interacts with repositories.
- `Helpers` - Contains utility classes and configuration settings.
- `appsettings.json` - Configuration file for database connection settings.
- `Program.cs` - Entry point of the application.
- `Startup.cs` - Configuration for dependency injection, middleware, and more.

## Endpoints

The `ca.whittaker.blocks` project provides various endpoints for managing building blocks and their types. Refer to the [Endpoints](#endpoints) section in the main repository README for a complete list of available endpoints.

## Models

The data models in the `ca.whittaker.blocks.Models` namespace represent the structure for creating and updating entities. These models are used to validate and handle incoming request data.

## Services

The `ca.whittaker.blocks.Services` namespace contains the service classes that implement the business logic for managing building blocks and their types.

## Controllers

The `ca.whittaker.blocks.Controllers` namespace contains the controller classes responsible for handling incoming HTTP requests and returning appropriate responses.

## Repositories

The `ca.whittaker.blocks.Repositories` namespace contains repository classes responsible for database interaction.

## Helpers

The `ca.whittaker.blocks.Helpers` namespace contains utility classes such as the `DataContext` for database context management and `AutoMapperProfile` for configuring AutoMapper mappings.

## Configuration

Update the `appsettings.json` file with your database connection settings before running the project.

## Usage

1. Build and run the `ca.whittaker.blocks` project.
2. Access the API using the provided endpoints.
3. Swagger documentation is available at `/swagger` for API reference.

## Contributing

Contributions are welcome! If you find any issues or have suggestions for improvements, please open an issue or create a pull request.

## License

This project is licensed under the [MIT License](LICENSE).

---

**Note:** This README is specific to the `ca.whittaker.blocks` project within the repository and should be customized further if necessary.
