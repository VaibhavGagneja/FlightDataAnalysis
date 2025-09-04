# Flight Chain Analysis

## Overview
This is simple web api project using .NET8.0 which anlyzes the flight chain.
The Web Service exposes several APIs. The APIs are related to flights and flight chain inconsistency analysis.

## API Endpoints
### Flight API

* Get All Flights : `GET /api/v1/flights`
* Get Specific Flight by ID : `GET /api/v1/flights/{id}`
* Get Flight Options(returns only id and flight number) : `GET /api/v1/flights/options`
* Get Flights by Pagination : `GET /api/v1/flights/paged?pageNumber=1&pageSize=10`

### Flight Inconsistency API
* Get Inconsistent Flight Chain : `GET /api/v1/flight-analysis`
  
## Table of Contents
- [Flight Chain Analysis](#flight-chain-analysis)
  - [Overview](#overview)
  - [API Endpoints](#api-endpoints)
    - [Flight API](#flight-api)
    - [Flight Inconsistency API](#flight-inconsistency-api)
  - [Prerequisites](#prerequisites)
  - [Getting Started](#getting-started)
    - [Installation](#installation)
    - [Running the Application](#running-the-application)
  - [Testing](#testing)
    - [Unit Tests](#unit-tests)
    - [SpecFlow BDD Tests](#specflow-bdd-tests)

## Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Git](https://git-scm.com/downloads)
- [Docker](https://www.docker.com/products/docker-desktop/)

## Getting Started
### Installation
1. Unzip the source code in a directory
### Running the Application
1. Open project in Visual Studio
2. Step start up project as FlightDataAnalysis
3. Run the project 
4. Or On directory where the docker file exists run command 
```bash
docker build -t flight_chain_analysis .
docker run -d -p 8080:8080 flight_chain_analysis
```

## Testing
Both unit tests and integration tests are added part of development.
### Unit Tests
Unit tests are added only for business classes to validate business logic in isolated environment.
### SpecFlow BDD Tests
BDD tests are added part of API testing. It validates the acceptance criteria of each feature by running the application and testing the APIs.