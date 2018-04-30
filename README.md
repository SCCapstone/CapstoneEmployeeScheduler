# Capstone Employee Scheduler
Windows Application to assign Employees and Roles in an efficient manner

# Download:
CapstoneEmployeeScheduler_setup.msi

If the user does not specify, this will install under:
C:\Program Files (x86)\Default Company Name\CapstoneEmployeeScheduler_setup

# Login:
To login as a generic admin, you can use the fields Username = "admin" Password = "admin"
To login as a user in the database, you can use the email of that user and set the password as "Password". This will prompt them to make a new password for the user.

# Using the Application 
If the user is an admin, all the pages should be able to be accessed, and they should be able to generate schedules and edit employees and roles.

If the user is not an admin, they will only be able to access the pages specified by the admin. 


## Testing
### Unit Tests
We are using a built-in unit test framework in Visual Studio. To set this up we had to make a unit test C# project and add our project as a Reference. Then we were able to make unit tests for our code. In order to run our tests in Visual Studio: Click Build -> Build Solution, then click View -> Test Explorer, then click Run All Tests in the test explorer.

### Behavioral Tests

For behavior tests we are using a feature offered in Visual Studio Enterprise edition called CodedUI Tests. To set this up we had to make sure the CodedUI framework was installed, then adding a new project of the CodedUI type. When that is done, you can record going through the application and set different values and conditions to simulate user input. Testing these behavior tests is very similar to testing Unit Tests. Click Build -> Build Solution, then click View -> Test Explorer, then click the names of the UI tests you created. You can also run all tests if you want to run both the unit tests and the behavior tests.
