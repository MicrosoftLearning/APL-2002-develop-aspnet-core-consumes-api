---
lab:
    title: 'Exercise: Implement HTTP operations in ASP.NET Core Razor Pages'
    module: 'Module: Implement HTTP operations in ASP.NET Core Razor Pages'
---

In this exercise, you learn how to add code to an ASP.NET Core Razor Pages app to create the HTTP client and perform `GET`, `POST`, `PUT`, and `DELETE` operations. This code is added to the *.cshtml.cs* code-behind files. The code to render the data in the *.cshtml* files is complete.

## Objectives

After you complete this exercise, you will be able to:

* Implement `IHttpClientFactory` as the HTTP client
* Implement HTTP operations in ASP.NET Core Razor Pages

## Prerequisites

To complete the exercise you need to have the following installed on your system:

* [Visual Studio Code](https://www.visualstudio.com/downloads).
* [The latest .NET 7.0 SDK](https://dotnet.microsoft.com/download/dotnet/7.0).
* [The C# extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) for Visual Studio Code

**Estimated exercise completion time**: 45 minutes

## Exercise scenario

In this exercise has two components:

* An app that sends HTTP requests to an API. The app runs on `http://localhost:5010`
* An API that responds to HTTP requests. The API runs on `http://localhost:5050`

![Decorative](media/02-architecture.png)


## Download the code

In this section you download the code for the Fruit web app and the Fruit API. You also run the Fruit API locally so it is available for the web app.

### Task 1: Download and run the API code

1. Right-click the following link and select the **Save link as** option. 

    * [FruitAPI project code](https://github.com/MicrosoftLearning/APL-2002-develop-aspnet-core-consumes-api/blob/development/Allfiles/Downloads/FruitAPI.zip) code

1. Launch **File Explorer** and navigate to the location the file was saved.

1. Unzip the file into it's own folder.

1. Open **Windows Terminal**, or a **Command Prompt**, and navigate to the location you extracted the code for the API.

1. In **Windows Terminal** pane run the following `dotnet` command:

    ```
    dotnet run
    ```

1. Following is an example of the generated output. Note the `Now listening on: http://localhost:5050` line in the output. It identifies the host and port for the API.

    ```
    info: Microsoft.EntityFrameworkCore.Update[30100]
          Saved 3 entities to in-memory store.
    info: Microsoft.Hosting.Lifetime[14]
          Now listening on: http://localhost:5050
    info: Microsoft.Hosting.Lifetime[0]
          Application started. Press Ctrl+C to shut down.
    info: Microsoft.Hosting.Lifetime[0]
          Hosting environment: Development
    info: Microsoft.Hosting.Lifetime[0]
          Content root path: 
          <project location>
    ```

### Task 2: Download and open web app project

1. Right-click the following link and select the **Save link as** option. 

    * [Fruit web app project code](https://github.com/MicrosoftLearning/APL-2002-develop-aspnet-core-consumes-api/blob/development/Allfiles/Downloads/FruitWebApp-CodeBehind.zip) code

1. Launch **File Explorer** and navigate to the location the file was saved.

1. Unzip the file into it's own folder.

1. Open **Windows Terminal**, or a **Command Prompt**, and navigate to the location you extracted the code for the API.

1. Run the following command to start Visual Studio Code and open the project.

    ```
    code .
    ```

1. The project structure in the **Explorer** pane should be similar the following screenshot. If the **Explorer** pane isn't visible, select **View** then select **Explorer** in the menu bar.

    ![Screenshot showing the Fruit web app project structure.](media/02-web-app-cb-struture.png)

## Implement the HTTP client


