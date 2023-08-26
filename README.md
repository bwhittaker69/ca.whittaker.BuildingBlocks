# Architecture Building Blocks Management API

This repository contains a RESTful API for managing Architecture Building Blocks. The API provides endpoints to represent and manage various types of building blocks and their relationships.

## Table of Contents

- [Introduction](#introduction)
- [Setup](#setup)
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

The Architecture Building Blocks Management API allows you to manage different types of building blocks such as Line of Business, Enterprise, Segment, Initiative, Architecture, Technology, and Solution. It provides endpoints to create, read, update, and delete these blocks, along with their types and relationships.

## Setup

1. Clone this repository to your local machine.
2. Ensure you have a PostgreSQL database set up with the schema and tables as defined in the provided SQL schema script.
3. Open the solution file and configure the `appsettings.json` with your database connection settings.
4. Build and run the application.

## Endpoints

### Blocks

- `GET /blocks` - Get all blocks.
- `GET /blocks/{id}` - Get a block by ID.
- `POST /blocks` - Create a new block.
- `PUT /blocks/{id}` - Update an existing block.
- `DELETE /blocks/{id}` - Delete a block.

### Block Types

- `GET /blocktypes` - Get all block types.
- `GET /blocktypes/{id}` - Get a block type by ID.
- `POST /blocktypes` - Create a new block type.
- `PUT /blocktypes/{id}` - Update an existing block type.
- `DELETE /blocktypes/{id}` - Delete a block type.

## Models

The API uses the following data models:

- `Block` - Represents a building block with attributes like name, domain, description, etc.
- `BlockType` - Represents a type of building block with attributes like name, icon, colors, etc.
- `CreateRequest` - Data model for creating new blocks or block types.
- `UpdateRequest` - Data model for updating existing blocks or block types.

## Services

The API services handle the business logic:

- `BlockService` - Provides methods to manage blocks.
- `BlockTypeService` - Provides methods to manage block types.

## Controllers

Controllers handle incoming requests and interact with the services:

- `BlocksController` - Handles endpoints related to blocks.
- `BlockTypesController` - Handles endpoints related to block types.

## Repositories

Repositories provide data access to the database:

- `BlockRepository` - Provides methods to interact with the Blocks table.
- `BlockTypeRepository` - Provides methods to interact with the BlockTypes table.

## Helpers

- `DataContext` - Represents the database context.
- `AutoMapperProfile` - Configures AutoMapper mappings.

## Configuration

- Update the `appsettings.json` file with your database connection settings.

## Usage

1. Run the application.
2. Access the API using the provided endpoints.
3. Swagger documentation is available at `/swagger` for API reference.

## Contributing

Contributions are welcome! If you find any issues or have suggestions for improvements, please open an issue or create a pull request.

## License

This project is licensed under the [MIT License](LICENSE).

---

**Note:** This README is a template and should be customized to match your project's specific details and structure.
