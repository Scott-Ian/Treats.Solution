# <h1 align = "center"> Sweet and Savory Treats

## <h3 align = "center"> Entity Framework in ASP.NET MVC, 8.4.20

## <h2 align = "center"> About

<p align = "center"> This application manages the relationship between flavors and treats. It further incorporates user accounts and authorization, only allowing creating, updating, and deleteing of entries to logged in users. 

## **✅REQUIREMENTS**
* Install [Git v2.62.2+](https://git-scm.com/downloads/)
* Install [.NET version 3.1 SDK v2.2+](https://dotnet.microsoft.com/download/dotnet-core/2.2)
* Install [Visual Studio Code](https://code.visualstudio.com/)
* Install [MySql Workbench](https://www.mysql.com/products/workbench/)

## **💻SETUP**
* to clone this content, copy the url provided by the 'clone or download' button in GitHub
* in command line use the command 'git clone (GitHub url)'
* open the program in a code editor
* In the project folder (Treats) enter the following terminal commands:
  1. dotnet restore
  2. dotnet ef database update
* To launch the program run the following:
  1. dotnet run
* Open http://localhost:5000 in your web browser to access the application
* You must create a new user to access all features of this project.
  * Please note that password requirements have been significantly parred down for testing, and will not require numbers, capital letters, symbols, or a minimum length.  

__

## User Stories

* As a store manager, I need to be able to see a list of all flavors, and I need to be able to see a list of all treats. 
* As the store manager, I need to be able to select a flavor, see their details, and see a list of all treats that the flavor is associated with. I also need to be able to select a treat, see its details, and see a list of all flavors it is associated with.
* As the store manager, I need to add new flavors to our system. I also need to add new treats to our system when they are created.
* As the store manager, I should be able to add new treats even if no flavors are listed. I should also be able to add new flavors even if no treats are listed.
* As the store manager, I need to be able to add or remove flavors that a specific treat is associated with. I also need to be able to modify this relationship from the other side, and add or remove treats from a specific flavor.
* I should be able to navigate to a splash page that lists all treats and flavors. Users should be able to click on an individual treat or flavor to see all the treats/flavors that belong to it.
* As the store manager, I want the ability to add, create, delete, or edit flavors and treats to be limited to logged in users. 

## Known Bugs

_Currently there are no known bugs._

## Support and contact details

* Contact : Ian Scott
* [IanScottDeveloper@gmail.com](IanScottDeveloper@gmail.com)

## Technologies Used

* C#
* ASP.NET MVC
* Entity Framework
* SQL Database
* Many-to-Many database relationships with join tables
* HTML
* CSS
* User Login and Authentication
* NewtonSoft
* RestSharp


## **📘 License**
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)