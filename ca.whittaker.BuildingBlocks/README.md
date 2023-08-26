# ca.whittaker.buildingblocks Data Models

Welcome to the `ca.whittaker.buildingblocks` Data Models project! This project defines the core data models for your Architecture Building Blocks Management API.

## Models

### Block

Represents an architecture building block.

Attributes:
- `Id`: Identifier for the block.
- `Name`: Name of the block.
- `Domain`: Domain information for the block.
- `Description`: Description of the block.
- Other attributes like colors, types, etc.

### BlockType

Represents a type of architecture building block.

Attributes:
- `Id`: Identifier for the block type.
- `Name`: Name of the block type.
- Other attributes if applicable.

## Example Usage

Here's how you can use the defined data models together:

```csharp
// Create a new BlockType
BlockType blockType = new BlockType
{
    Name = "Technology"
};

// Create a new Block
Block block = new Block
{
    Name = "Database",
    Domain = "Data Storage",
    Description = "Stores application data",
    BlockType = blockType // Assign the block type
};

```

These data models provide the foundation for managing Architecture Building Blocks in your application.