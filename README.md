# Database Management Application

The Database Management Application is a console-based tool designed to interact with a database for managing information related to machines and related entities.

## Features

- View existing records
- Add new records
- Delete existing records
- Update existing records
- Import data from external files

## Getting Started

### Prerequisites

- .NET Core SDK installed on your machine
- Access to a SQL Server database

### Installation

1. Clone or download the repository to your local machine.
2. Open the solution in your preferred IDE (e.g., Visual Studio, Visual Studio Code).

### Configuration

1. Open the `App.config` file.
2. Update the connection string with your SQL Server database credentials and database name.

### Usage

1. Navigate to the project directory in your command-line interface.
2. Build the solution using the following command:
    ```
    dotnet build
    ```
3. Run the application using the following command:
    ```
    dotnet run
    ```
4. Follow the on-screen instructions to perform various database operations:
    - Select one of the options provided in the main menu.
    - Follow the prompts to execute specific actions such as viewing, adding, deleting, updating, or importing data.

### Examples

Below is an example of how to use the application:

1. Start the application.
2. Choose the desired operation from the main menu (e.g., "Print").
3. Follow the prompts to view, add, delete, update, or import data as needed.



## How to use import
```xml
<data>
    <manufacturer>
        <name>Jecna.inc</name>
    </manufacturer>
    <manufacturer>
        <name>Zitna.inc</name>
    </manufacturer>
    <manufacturer>
        <name>Panska.inc</name>
    </manufacturer>
</data>
```



## Dependencies

- .NET Core SDK
- Entity Framework Core
- SQL Server database


## License

This project is licensed under the [MIT License](https://github.com/git/git-scm.com/blob/main/MIT-LICENSE.txt).

