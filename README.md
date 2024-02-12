# IdAMDb

cd VSCodeProjects

dotnet new blazor --interactivity Auto --auth Individual --name IdAM

cd IAM

code .

Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.SqlServer.Design
Microsoft.EntityFrameworkCore.Sqlite

docker exec -it c28b83ff5aac2beb29362348fcd621dba4a8582534cf73d39a92c679ed96ae9a /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P 'ComplexP@ssw0rd'
-- Connect to the SQL Server instance
-- (This is done outside of the SQL script, using your SQL Server client tools)

-- Create a new database
CREATE DATABASE IDAMDb;

-- Create a new login
CREATE LOGIN IDAMDbAdmin WITH PASSWORD = 'ComplexP@ssw0rd';

-- Switch to the new database
USE IDAMDb;

-- Create a new user for the login
CREATE USER IDAMDbAdmin FOR LOGIN IDAMDbAdmin;

-- Grant the necessary permissions to the user
EXEC sp_addrolemember 'db_owner', 'IDAMDbAdmin';

"Server=localhost,1433;Database=IDAMDb;User Id=sa;Password=ComplexP@ssw0rd;Encrypt=False;"

***for the server programs.cs errors, just delete and re-add the using statements***

admin@example.com

Password


############################################################################################################
IdAM Documentation
Based on the `ApplicationDbContext` code and the schema details provided, here is the inferred business logic at the application level:

1. **User Management**:
    - Users (`ApplicationUser`) can be created, with standard identity fields such as username, email, etc.
    - Users can have roles (`ApplicationRole`), which likely control their permissions within the system.

2. **Role Management**:
    - Roles are extendable (perhaps for different applications), and can have claims (`AppRoleClaim`), 
      allowing for fine-grained access control where roles can carry specific permissions or settings.

3. **Application Management**:
    - The system manages multiple applications (`App`), each identifiable by name and likely representing different components or services available to users.
    - Users can be associated with specific applications (`UserApplication`), suggesting that users may have access to a subset of all available applications.

4. **Application-Specific Roles**:
    - Roles can be scoped to specific applications (`AppRole`), implying that the system supports defining roles that 
      are only applicable within the context of a single application. This could be used to grant a user admin rights in one application but not in others.

5. **Claims-Based Authorization**:
    - The presence of user claims (`AspNetUserClaims`) and role claims (`AppRoleClaims`) indicates that the application 
      likely uses claims-based authorization, where access to resources is controlled based on claims associated with the user and their roles.

6. **Authentication Tokens and External Logins**:
    - The system supports storing OAuth tokens (`AspNetUserTokens`) and external login information (`AspNetUserLogins`), 
      suggesting integration with third-party authentication providers.

7. **Security and User Verification**:
    - Fields like `EmailConfirmed`, `PhoneNumberConfirmed`, and `TwoFactorEnabled` in `AspNetUsers` suggest mechanisms for user verification and two-factor authentication, enhancing security.

8. **User State Management**:
    - The presence of fields like `LockoutEnd`, `LockoutEnabled`, and `AccessFailedCount` indicates that the 
      application tracks failed access attempts and can lock users out to prevent brute-force attacks.

The business logic implies a multi-application environment with a need for centralized user management, 
role-based access control with the potential for fine-grained permissions per application, support for external 
authentication services, and robust security practices. This setup would be typical for an enterprise-level system 
where users interact with multiple services and require different permissions and roles within those services.

The  Modal  component is a customized wrapper around the Bootstrap modal.

From the  Blazorise library:
The  QuickGrid component provides a grid with sorting, pagination, and filtering.
The  EditForm  component is used to handle the form inside the modal.
The  DataAnnotationsValidator  component is used to validate the form.
The  InputText  component is used to bind the app name to the form.

You should adjust these records to match your app's model:
The  App  and  AppList  records are used to represent the data returned from the server.
The  TemplateColumn  components are used to display the roles and actions for each app.

The  appsProvider  is a delegate that provides the data for the grid. It's a function that takes a  GridItemsRequest  and returns a  GridItemsProviderResult .
The  GridItemsRequest  contains the current page, items per page, and sort information.
The  GridItemsProviderResult  contains the items to display and the total count of items.
The  OnInitializedAsync  method sets up the  appsProvider  to fetch the data from the server.
The  NewAppModal  method is called when the "New App" button is clicked. It opens the modal and sets the  currentApp  to a new instance of the  App  record.
The  EditApp  method is called when the "Edit" button is clicked. It opens the modal and sets the  currentApp  to the app that was clicked.
The  DeleteAppAsync  method is called when the "Delete" button is clicked. It sends a DELETE request to the server to delete the app.
The  SaveApp  method is called when the "Save" button is clicked. It saves the app to the server and refreshes the grid.
The  HandleValidSubmit  method is called when the form inside the modal is submitted. You should implement the logic to handle the form submission here.
The  Search  input is used to filter the apps by name.
The  Paginator  component is used to display the pagination controls.
