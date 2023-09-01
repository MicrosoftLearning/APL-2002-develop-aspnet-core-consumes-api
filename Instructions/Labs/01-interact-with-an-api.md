---
lab:
    title: 'Exercise: Interact with an ASP.NET Core minimal API'
    module: 'Module: Interact with an ASP.NET Core minimal API'
---

In this exercise, you'll run an ASP.NET Core minimal API locally and explore the API and the underlying code. 

After you complete this exercise, you'll be able to:

* Navigate a documented API
* Determine endpoints for HTTP operations
* Identify API requirements for HTTP operations

## Prerequisites

To complete the exercise you need to have the following installed on your system:

* [Visual Studio Code](https://www.visualstudio.com/downloads).
* [The latest .NET 7.0 SDK](https://dotnet.microsoft.com/download/dotnet/7.0).
* [The C# extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) for Visual Studio Code

## Exercise scenario

Image showing the layout of the API


## Instructions

### Download and run the Fruit API code

In this you'll ...

#### Task 1: Download the code

1. Right-click the following link and select the **Save link as** option. 

    * [FruitAPI project code](https://github.com/MicrosoftLearning/APL-2002-develop-aspnet-core-consumes-api/blob/development/Allfiles/Downloads/FruitAPI.zip) code

1. Launch **File Explorer** and navigate to the location the file was saved.

1. Unzip the file into it's own folder.

#### Task 2: Build and run the project

1. Launch Visual Studio Code and select **File** and then **Open Folder...** in the menu bar.

1. Navigate to the location where you unzipped the project files and select the *FruitAPI* folder.

1. The project structure in the **Explorer** pane should be similar the following screenshot. If the **Explorer** pane isn't visible, select **View** then select **Explorer** in the menu bar.

    ![Screenshot showing the FruitAPI project structure.](media/api-project-structure.png)

1. Open a Terminal by selecting **Terminal** and then **New Terminal**, or use the keyboard shortcut **Ctrl+Shift+`**.

1. In the **Terminal** pane run the following `dotnet` command:

    ```
    dotnet run
    ```

1. Following is an example of the output you'll see in the **Terminal** pane. Note the `Now listening on: http://localhost:5050` line in the output. It identifies the host and port for the API.

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

### Explore the API

In this section you'll explore the documentation in the Fruit API. The API interacts with an in-memory database that contains the following fields:

Field | Type | Description
--- | --- | ---
`id` | integer | Key for the data
`name` | string | Name of the fruit
`instock` | boolean | Indicates if the fruit is instock

The Swagger documentation was created using the Swashbuckle package.

#### Task 1: Launch the API in a browser

1. To view the API you can either your browser and enter `http://localhost:5050` the address bar, or you can **Ctrl+Click** on the `Now listening on: http://localhost:5050` link in the **Terminal**. The page will display a "This localhost page can't be found" message.

1. Append the URL in the browser with `/swagger`. Your browser should now display a web page similar to the following screenshot:

    ![Screenshot of the API documentation page.](media/api-home-page.png)

#### Task 2: Identify elements of the API



### Third grouping of tasks

#### Review
