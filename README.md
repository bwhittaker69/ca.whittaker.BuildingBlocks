# Architecture Building Blocks Management

This repository contains a data model and a minimal RESTful API for representing and managing Architecture Building Blocks. The data model includes definitions for both blocks and block types, and the associated REST API allows you to create, read, update, and delete these building blocks.

## Project Structure

The project is structured into two main components:

1. **ca.whittaker.BuildingBlocks**: This project contains the DTO (Data Transfer Object) model for the Architecture Building Blocks. It defines the structure of both blocks and block types.

2. **ca.whittaker.blocks**: This project contains the minimal RESTful API for managing the Architecture Building Blocks. It provides endpoints for interacting with the blocks and block types data.

## Data Model

The data model consists of two main entities: `blocktypes` and `blocks`.

### Block Types (Table: buildingblocks.blocktypes)

Block types represent the various categories or types that architecture building blocks can belong to. Each block type has attributes like a name, icon, background color, border color, font color, border size, and margin size.


### Blocks (Table: buildingblocks.blocks)

Blocks represent the individual architecture building blocks. Each block has attributes such as a name, domain, description, icon, associated block type, background color, border color, font color, border size, margin size, parent block ID, and child block ID. Blocks can be organized in a hierarchical structure using the parent-child relationship.

## Setting up the Database

The SQL script `schema.sql` in the repository contains the necessary SQL commands to create the required schema and tables for the data model. The script sets up the `buildingblocks` schema and creates the `blocktypes` and `blocks` tables with their respective attributes. It also defines foreign key constraints and checks for valid color codes.

To set up the database schema, follow these steps:

1. Copy the contents of the `schema.sql` script.

2. Open your PostgreSQL database management tool.

3. Create a new query window and paste the copied script into the window.

4. Execute the script to create the schema and tables.

This will set up the database structure required to work with the Architecture Building Blocks.

> Note: Make sure to customize the database connection settings in the script if needed.

### ca.whittaker.blocks Minimal API

Blocks represent the individual architecture building blocks. Each block has attributes such as a name, domain, description, icon, associated block type, background color, border color, font color, border size, margin size, parent block ID, and child block ID. Blocks can be organized in a hierarchical structure using the parent-child relationship.

To represent and manage blocks, the repository is organized as follows:

- **Controllers**: Contains the BlocksController.cs file responsible for handling API requests related to blocks.

- **Entities**: Contains the Block.cs file, which defines the structure of the Block entity.

- **Repositories**: Contains the BlockRepository.cs file, responsible for database operations related to blocks.

- **Services**: Contains the BlockService.cs file, which provides business logic and interacts with the repository.
