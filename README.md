# Dr. Sillystringz' Silly String Supply

#### Contributors: Anthony DiFalco

#### A site where Dr. Sillystringz can keep track of their engineers and equipment

## Technologies Used

* C#
* .NET
* ASP.NET Core
* MySQL
* HTML

## Description

This project uses ASP.NET Core to simulate a program that allows a factory to keep track of their engineers and machines, and which engineers are licensed to repair which machines.

The home page links to a list of engineers and a list of machines. On the list pages, each engineer/machine links to their respective details page. Details pages display the object's basic information, as well as the list of the object's repair relationships. Each repair relationship can be removed by clicking the corresponding delete button.

Buttons at the bottom of the page link to add a repair relationship, edit the object, and delete the object. 

Each link functions like so:

Add:
  * Select an existing engineer to add to a machine, and vice-versa

Edit:
  * Object's basic information can be adjusted here
  * Engineers have a name
  * Machines have a name and a description

Delete:
  * Deletes the selected engineer/machine from the database
  * Clicking the button redirects to a confirmation page

## Setup/Installation Requirements

Installation from GitHub:

* To run this program you will need to install VSCode, along with C# and .NET
* From your terminal run&emsp;`git clone https://github.com/Di-Falco/code-review-10`
* From the Factory directory run&emsp;`dotnet restore`

SQL setup:

* In the Factory directory, create an appsetting.json file. The terminal command for this is&emsp;`touch appsetting.json`
* Within appsetting.json, insert the following:

`"ConnectionStrings": {`

&emsp;`  "DefaultConnection": "Server=localhost;Port=3306;database=anthony_difalco;uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];"`

`}`
* Replace&ensp;`[YOUR-USERNAME-HERE]`&ensp;and&ensp;`[YOUR-PASSWORD-HERE]`&ensp;with your username and password for MySqlWorkbench
* Launch MySQLWorkbench
* From the administration tab, select&ensp;`Data Import/Restore`
* Select&ensp;`Import from Self-Contained File`
* From the field on the right, navigate to the location of&ensp;`anthony_difalco.sql`&ensp;in this project's&ensp;`/code-review-10`&ensp;directory on your computer
* Under&ensp;`Default Schema to be Imported`&ensp;select&ensp;`New`
* Name the schema `anthony_difalco` and click `OK`
* Click&ensp;`Start Import`&ensp; at the bottom of the menu

To Run the Program:
* Navigate to the&ensp;`/Factory`&ensp;directory from your terminal
* Enter the command `dotnet run`
* The program should launch on&ensp;`localhost:5000`

## Known Bugs

* None

## License

## Contact Information