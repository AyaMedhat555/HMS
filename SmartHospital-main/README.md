# SmartHospital
<hr>

## Features added so far:
- **registring a new patient into the localdb.**
- **logining in with the registered patient's username and password.**

<br>

#### you might try and skip the next section, and go directly to "How to run the api?" section. since most of the tools are probably already installed on your machines.
## Tools required to run and test the .NET 6.0 API:
- .NET 6.0 SDK - includes the .NET runtime and command line tools ([link to download](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)).
- sql server express ([link to download](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)).
- Visual Studio Code **(You obviously have it)**
- C# extension for Visual Studio Code - adds support to VS Code for developing .NET applications **(Probably will not need it but just in case)**
- postman ([link to download](https://www.postman.com/downloads/)).


## How to run the api?

1. Download or clone the project code
2. go to the project root folder (where the SmartHospital.csproj file is located) and open the "appsettings.json" file, and in the connection strings section (highlighted in the image) replace the connection strings with "Server=.\\\SQLEXPRESS; Integrated Security=true"
![image](https://user-images.githubusercontent.com/58495398/156941750-7a6eec83-eecf-4995-adac-65cd6c873445.png)

3. Start the api by running "dotnet run" from the command line in the project root folder.

a message like the following should appear which mean the application is running
![image](https://user-images.githubusercontent.com/58495398/156858655-ddd4fe18-0291-4900-8d4e-1c517d83d091.png)
<hr>

## Test the .NET 6.0 API with Postman:
### 1. adding new patient:
  - copy the first url that appeared in the command line to postman, in my case that was "https://localhost:7163".
  - to register a new patient add "/api/Authentication/register" to the url, (make sure the method's type is post).
  - in the body section of the http request check the "RAW" radio button, and select "JSON" from the dropdwon selector to the right.
  an example of the data that you can enter:

```json
{
  "firstName": "mohab",
  "lastName": "mohammad",
  "age": 0,
  "nationalId": "2093708109123312",
  "image": "00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000",
  "bloodType": "-O",
  "phoneNumber": "01115672829",
  "address": "fayoum",
  "gender": "male",
  "userName": "mohab",
  "mail": "mm3247@fayoum.edu.eg",
  "password": "mohab"
}
```
### 2. logging in with the new patient:
  - copy the first url that appeared in the command line to postman, in my case that was "https://localhost:7163".
  - to login add "/api/Authentication/login" to the url, (make sure the method's type is post).
  - in the body section of the http request check the "RAW" radio button, and select "JSON" from the dropdwon selector to the right.
  an example of the data that you can enter:
  
```json
{
  "userName": "mohab",
  "password": "mohab"
}
```

<br>

# "that's all folks!"


