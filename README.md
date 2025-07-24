# Finit-assignement

 **Design Principles**:
  - Use Clean Architecure
  - Apply CQRS pattern using MediatR
  - Follow Domain-Driven Design (DDD)
  - Apply SOLID, KISS, YAGNI principles for clean and maintainable code.

- **Logging**:
  - User Serilog to log console and file, be able to extend to write to other platforms like DataDog, ...
  
- **Dependency Injection**:
  - Apply for Services, Repositories, ... be able to replace, change the implementation or technical easily

## How to Run
To run easily, we can use Visual Studio and Angular CLI to serve/build
(or we can run/deploy each service/app by dotnet CLI and Angular CLI)
1. Clone Repo
2. Use Visual Studio to open the solution file **Finit.sln**
3. Run the project using Visual Studio
4. Run the Angular app by open **FrontEnd** and run / build by angular cli, or follow:
   open **FrontEnd** with visual studio code
   - step 1: run "npm install"
   - step 2: run "npm start"
