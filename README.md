# Park Lookup

#### _A web site were you can add and check list of National Parks of different states can give reviews and check review and avager rating.- August 23, 2019_

#### _By **Saswati Patra**_

## Description

On this webpage one can create national parks in different states and give review and check out other people reviews and average rating of a national park.


## Setup/Installation Requirements

* This application requires MySQL.

1. Clone this repository:
    ```
    $ git clone https://github.com/saswatipatra/Park-API
                https://github.com/saswatipatra/Park-MVC
    ```
2. Open the database context file (Park-API/Models/ParkContext.cs) and replace `password=epicodus` with a string containing your MySQL password (ex: `"abcd123"`).

3. Log onto MySQL:
    ```
    $ mysql -u USERNAME -p PASSWORD
    ```
5. Navigate to the project directory (Park-API). Restore dependencies, update your local database, and run the API:
    ```
    $ dotnet restore
    $ dotnet ef database update
    $ dotnet run
    ```
7. The API is now up and running. For full schema and a sample request body for POST, navigate to the Swagger documentation at http://localhost:5001.

## Using the API

### **Basic CRUD**
| Endpoint | HTTP Method | Description |
| :------------- | :------------- | :------------- |
| `api/NationalParks` | GET | Return all NationalParks |
| `api/NationalParks/{id}` | GET | Returns a specific Park |
| `api/NationalParks` | POST | Creates a new Park |
| `api/NationalParks/{id}` | PUT | Edits a specific Park |
| `api/NationalParks/{id}` | DELETE | Deletes a specific Park |


## Known Bugs
* No known bugs at this time.

## Technologies Used
* C#
* Asp.Net Core
* Css
* bootstrap
* Mysql Workbench

## Support and contact details

_Please contact  Saswati with questions and comments._

### License

*GNU GPLv3*

Copyright (c) 2019 **_Saswati Patra_**
