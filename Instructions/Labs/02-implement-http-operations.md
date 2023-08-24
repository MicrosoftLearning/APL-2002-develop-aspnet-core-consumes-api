---
lab:
    title: 'Exercise: Implement HTTP operations in an ASP.NET Core Razor Pages app'
    module: 'Module: Implement HTTP operations in an ASP.NET Core Razor Pages app'
---

In this exercise, you learn how to add the necessary code to an ASP.NET Core Razor Pages app to create the HTTP client and perform `GET`, `POST`, `PUT`, and `DELETE` operations to manage a list of fruit. The code to render the data in the **.cshtml* files is complete, and you will be updating the **.cshtml.cs* code-behind files.

## Objectives

After you complete this lab, you will be able to:

* Deploy an API to Azure App Service
* Implement HTTP operations in an ASP.NET Core Razor Pages app

## Prerequisites

To complete the exercise you need to have the following installed on your system:

* An Azure account with an active subscription. [Create an account for free](https://azure.microsoft.com/free/dotnet).
* [Visual Studio Code](https://www.visualstudio.com/downloads).
* [The latest .NET 7.0 SDK](https://dotnet.microsoft.com/download/dotnet/7.0).
* [The C# extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) for Visual Studio Code
* [The C# Dev Kit extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) for Visual Studio Code
* The [Azure Tools](https://marketplace.visualstudio.com/items?itemName=ms-vscode.vscode-node-azure-pack) extension.

## Lab scenario
https://learn.microsoft.com/en-us/azure/app-service/quickstart-dotnetcore?tabs=net70&pivots=development-environment-vscode

* [Download the FruitAPI](https://github.com/MicrosoftLearning/develop-aspnet-core-consumes-api/raw/master/Allfiles/Downloads/FruitAPI.zip) code

  - **Estimated Time**: 00 minutes

## Instructions

### Before you start

#### Setup Task

As part of setting up the App Service, you create:

* A new resource group to contain all of the Azure resources for the service.
* A new Hosting Plan that specifies the location, size, and features of the web server farm that hosts your app.

Follow these steps to create your App Service resources and publish your project:

1. In Visual Studio Code, open the **Command Palette** by selecting **View > Command Palette**.
1. Search for and select **Azure App Service: Create New Web App (Advanced)**.

3. Respond to the prompts as follows:

    1. If prompted, sign in to your Azure account.
    1. Select your **Subscription**.
    1. Select **Create new Web App... Advanced**.
    1. For **Enter a globally unique name**, use a name that's unique across all of Azure (valid characters are `a-z`, `0-9`, and `-`). A good pattern is to use a combination of your company name and an app identifier.
    1. Select Create new resource group and provide a name like `myResourceGroup`.
    1. When prompted to **Select a runtime stack**, select **.NET 7 (STS)**.
    1. **Select an operating system** (Windows or Linux).
    1. Select a location near you.
    1. Select **Create a new App Service plan**, provide a name, and select the **F1 Free** pricing tier.
    1. Select **Skip for now** for the **Application Insights** resource.
    1. When prompted, select **Deploy**.
    1. Select **MyFirstAzureWebApp** as the folder to deploy.
    1. Select Add Config when prompted.

1. In the popup **Always deploy the workspace "MyFirstAzureWebApp" to \<app-name\>**, select **Yes** so that Visual Studio Code deploys to the same App Service app every time you're in that workspace.

1. When publishing completes, select **Browse Website** in the notification and select Open when prompted.

You see the ASP.NET Core 7.0 web app displayed in the page.



### Exercise 0: 



#### Task 0: 


#### Review

Maecenas fringilla ac purus non tincidunt. Aenean pellentesque velit id suscipit tempus. Cras at ullamcorper odio.
