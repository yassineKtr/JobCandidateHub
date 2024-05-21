# JobCandidateHub

This document explains the design and implementation of the `JobCandidateHub` project, outlining the configuration, operations, and assumptions made during development.

## Application Section

### Database Configuration

I used a local PostgreSQL database for this project. The configuration classes define the necessary parameters to establish the connection to the database.

### ORM Choice

I chose Dapper as the ORM for this project to have more control over the queries.

### Core Operations

#### Set Operation

The `Set` operation is an upsert operation, which handles both the creation and updating of candidate records. This method ensures that if a candidate with the given email exists, their information is updated; otherwise, a new record is created.

#### Get Operation

The `Get` operation is primarily used for unit tests to verify that the data was properly inserted or updated in the database.

### Dependency Injection

I implemented a dependency injection container to manage application dependencies. This approach makes it easier to extend or modify the application's dependencies in the future if needed.

### Assumptions

- The email is the unique identifier for a candidate and is used as the primary key in the database table.
- Only upsert operations are required, focusing on creating and updating records.

## Unit Tests

### Framework

I used XUnit for unit testing.

### Test Design

- **Create and Update Tests**: The tests focus on verifying the `Set` operation. A dedicated reader method checks if the data was correctly inserted or updated in the database.

### Dependency Injection in Unit Tests

Dependency injection was also used in the test project to manage services and configurations.

### Assumptions in Unit Tests

- Only create and update operations are required for testing.

## API Controller

### Design

I created a simple API controller with one endpoint to handle both the creation and update of candidate information. Dependency injection is leveraged to provide the necessary services to the controller.

## General Notes

### Caching

Caching is not implemented since the current scope only includes create and update operations. If read operations are added in the future, a caching mechanism can be introduced using the decorator design pattern to create a separate class for cached services.

### Configuration

The configuration for the local PostgreSQL database is provided in the `appsettings.json` file.

## Database Table Creation

The following SQL query was used to create the `candidates` table:

```sql
CREATE TABLE IF NOT EXISTS public.candidates
(
    firstname text COLLATE pg_catalog."default" NOT NULL,
    lastname text COLLATE pg_catalog."default" NOT NULL,
    phonenumber text COLLATE pg_catalog."default",
    email text COLLATE pg_catalog."default" NOT NULL,
    calltimeinterval text COLLATE pg_catalog."default",
    linkedinurl text COLLATE pg_catalog."default",
    githuburl text COLLATE pg_catalog."default",
    comment text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT candidates_pkey PRIMARY KEY (email)
);
