# _Hair Salon_

#### _03.01.2019_

#### By _**Pavel Zanchuk**_

## Description

_This program allows user to keep track of Clients and Stylists._

## Specifications

* _Program will accept user input for Stylist._

* _Program will accept user input for clients._

* _Program stores the data in two database with two tables(relationship one to many type)._

* _Program will display in browser information for each stylist that is currently available from DB._


## Setup/Installation Requirements
* _Navigate your web browser to https://github.com/pzanchuk/HairSalon.Solution_
* _Click the green button "Clone or download" on the repository page._
* _To download the repository choose "Open in Desktop" or "Download Zip"._
* _Alternatively, to clone the repository, type "git clone https://github.com/pzanchuk/HairSalon.Solution_ in the terminal". (Note!: git should be installed on your PC).  For more information visit GitHub Help section Cloning a repository from GitHub:
https://help.github.com/articles/cloning-a-repository-from-github/_
* _To run the project in browser: navigate to ../WordCounter.Solution/WordCounter and ran these lines to restore files "dotnet restore" and "dotnet build", then "dotnet run".(Note!: Mono and .NET Core SDK 1.1.4 must be installed on your machine". Open up web browser and connect to (http://localhost:5000/)_
* _To create database(MySQL should be installed): open up terminal and type in next lines:(Database is also included if you'd like to import it.)
CREATE DATABASE pavel_zanchuk;
USE pavel_zanchuk;
CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255));
CREATE TABLE clients (id serial PRIMARY KEY, name VARCHAR(255), stylist_id INT);_

## Support and contact details

_For support please contact:_
_Pavel Zanchuk - buzzik@yahoo.com_

## Technologies Used

_This program was created using C# and MySql_

### License

*MIT License*

*Copyright (c) 2019 Pavel Zanchuk*

*Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:*

*The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.*

*THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.*
