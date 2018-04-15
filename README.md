# CapstoneEmployeeScheduler
Windows Application to assign Employees and Roles in an efficient manner

#### To login to the application: 
##### username = "admin" /t password = "admin" 

There may be a short wait after you hit submit because the login gets all the users information from the database. There may also be a short delay when displaying the schedule and displaying the employees. If a schedule has already been created for the current day, the generate schedule button will fail. This is a known bug that we will fix in the next release.

## Testing
### Unit Tests
We are using a built-in unit test framework in Visual Studio. To set this up we had to make a unit test C# project and add our project as a Reference. Then we were able to make unit tests for our code. In order to run our tests in Visual Studio: Click Build -> Build Solution, then click View -> Test Explorer, then click Run All Tests in the test explorer.

### Behavioral Tests

For behavior tests we are using a feature offered in Visual Studio Enterprise edition called CodedUI Tests. To set this up we had to make sure the CodedUI framework was installed, then adding a new project of the CodedUI type. When that is done, you can record going through the application and set different values and conditions to simulate user input. Testing these behavior tests is very similar to testing Unit Tests. Click Build -> Build Solution, then click View -> Test Explorer, then click the names of the UI tests you created. You can also run all tests if you want to run both the unit tests and the behavior tests.
