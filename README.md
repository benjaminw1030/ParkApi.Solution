# National/State Park API

An application that creates an API to store data about various state and national parks.

---

## By Ben Wilson

---

## Technologies Used

- _C#_
- _ASP.NET Core MVC_
- _.NET 5_
- _NuGet_
- _Microsoft.EntityFrameworkCore_
- _Dotnet EntityFramework Tool_
- _Microsoft.EntityFrameworkCore.Design_
- _MySQL_
- _Swagger_
- _Postman_

---

## Description

This web application will allow the user to add content to a database of US state and national parks through various API endpoints, with the use of a program like Postman or simply through the Swagger interface. The properties stored are as follows:

- ParkId - The primary key associated with the park.
- Name - The park's name.
- Category - Whether the park is considered a State or National park.
- State - The state the park is located in.
- Longitude - The longitude of the park; positive values are E, negative values are W.
- Latitude - The latitude of the park; positive values are N, negative values are S.
- Area - The park's area in square kilometers.
- Visitors - The park's yearly visitors.
- EstDate - The date the park was established.

The Swagger page located at the index contains documentation and explanation of all implemented endpoints.

---

### Technology Requirements

- [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0)
- A text editor like [VS Code](https://code.visualstudio.com/)

---

## Setup/Installation Requirements

1. Install the [.NET framework](https://docs.microsoft.com/en-us/dotnet/core/install/windows?tabs=net50).
2. If on MacOS, Install [MySQL Community Server](https://dev.mysql.com/downloads/file/?id=484914) and [MySQL Workbench](https://dev.mysql.com/downloads/file/?id=484391). If on Windows 10 download the [MySQL Web Installer](https://downloads.mysql.com/archives/get/p/25/file/mysql-installer-web-community-8.0.19.0.msi) and follow installation instructions.
3. During installation, note the password used for your server.
4. [Clone](https://docs.github.com/en/github/creating-cloning-and-archiving-repositories/cloning-a-repository-from-github/cloning-a-repository) this repository from GitHub to your local machine.
5. Open the new directory.
6. Create a new file called "appsettings.json" in the ParkApi directory.
7. Copy the following code into this file (noting where to insert your password):

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning",
      "Microsoft": "Information",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=benjamin_wilson;uid=root;pwd=epicodus;"
  }
}
```

8. Open a new terminal instance in the ParkApi.Solution/ParkApi directory.
9. Open MySQL Workbench and connect to localhost:3306 at root.
10. Type "dotnet build" in the terminal to create the file structure and install packages.
11. Apply the included Migration file by typing "dotnet ef database update"
12. To view, type "dotnet watch run" in the terminal and navigate to http://localhost:5000 or https://localhost:5001 in any web browser.

### Additonal Notes:
* This program uses [Swagger](https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-6.0&viewFallbackFrom=aspnetcore-50). Check the linked resource to see how it was implemented. 
* This program has [CORS](https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-5.0) (Cross-Origin Resource Sharing) enabled globally. The linked resource explains how it was done in Startup.cs.  
<br>
---

## API Endpoints
* GET - Returns parks utilizing a query of name, category, state, minArea and maxArea.
  Example:
  
  ```
  GET http://localhost:5000/api/parks?name=grand&category=national&state=arizona&minarea=500&maxarea=5000
  ```
  Will return all parks in the database whose names start with "grand", that are classified as a National park, are located in Arizona, and are between 500 and 5000 square km in area.  
<br>
* POST - Posts a new park.
  Example:
  ```
  POST http://localhost:5000/api/parks
  {
        "name": "Silver Falls",
        "category": "State",
        "state": "Oregon",
        "longitude": -122.65,
        "latitude": 44.85,
        "area": 36,
        "visitors": 1100000,
        "estDate": "1933-07-23T00:00:00"
    }
  ```
  Will create a new park with those properties and return the park.  
<br>
* GET("{id}") - Returns the park with that ID.
  Example:
  ```
  GET http://localhost:5000/api/parks/1
  ```
  Will return the park with a ParkId of 1.  
<br>
* PUT - Edits a specific park at an id with PUT.
  Example:
  ```
  PUT http://localhost:5000/api/parks/1
  {
      "name": "Everglades",
      "category": "National",
      "state": "Florida",
      "longitude": -80.93,
      "latitude": 25.32,
      "area": 6106.5,
      "visitors": 702319,
      "estDate": "1934-05-30T00:00:00"
  }
  ```
  Will edit the park with a ParkId of 1 with the above values.  
<br>
* PATCH - Edits a specific park at an id with PATCH (does not require all values).
  Example:
  ```
  PATCH http://localhost:5000/api/parks/1
  {
      "name": "Everglades",
      "category": "National",
      "state": "Florida",
      "longitude": -80.93,
      "latitude": 25.32,
      "area": 6106.5,
      "visitors": 702319,
      "estDate": "1934-05-30T00:00:00"
  }
  ```
  Will edit the park with a ParkId of 1 with the above values.  
<br>
* DELETE - Deletes a specific park at an id.
  Example:
  ```
  DELETE http://localhost:5000/api/parks/1
  ```
  Will delete the park with a ParkId of 1.  
  <br>
## Known Bugs

- None

---



## License

[MIT License](https://opensource.org/licenses/MIT)

```
Copyright 2021 Benjamin Wilson

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

```

---

## Contact Information

Ben Wilson: <benjaminw1030@gmail.com>
