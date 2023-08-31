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
* [The C# Dev Kit extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) for Visual Studio Code

## Exercise scenario

Image showing the layout of the API


## Instructions

### Download and run the Fruit API code

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

1. In the **Terminal** pane run the following `dotnet` commands:

```ps
dotnet clean
```


#### Review
