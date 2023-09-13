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

## API information

The API interacts with an in-memory database that contains the following fields:

Field | Type | Description
--- | --- | ---
`id` | integer | Key for the data
`name` | string | Name of the fruit
`instock` | boolean | Indicates if the fruit is instock

The Swagger documentation was created by using the Swashbuckle package.

>**Note:** Sample data is created every time the API is started.


## Download and run the Fruit API code

In this section you:

* Download the API code
* Run the API locally
* Open the API documentation in a browser

### Task 1: Download the API code

1. Right-click the following link and select the **Save link as** option. 

    * [FruitAPI project code](https://github.com/MicrosoftLearning/APL-2002-develop-aspnet-core-consumes-api/blob/development/Allfiles/Downloads/FruitAPI.zip) code

1. Launch **File Explorer** and navigate to the location the file was saved.

1. Unzip the file into it's own folder.

#### Task 2: Run the API locally

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

### Task 3: Open the API documentation in a browser

1. To view the API you can either enter `http://localhost:5050` the address bar, or you can **Ctrl+Click** on the `Now listening on: http://localhost:5050` link in the **Terminal** shown previously. The page will display a "This localhost page can't be found" message.

1. Append the URL in the browser with `/swagger`. The `/swagger` endpoint is typically where you will find the documentation for a  Swagger API. The full URL for Swagger documentation is `http://localhost:5050/swagger`. Your browser should now display a web page similar to the following screenshot:

    ![Screenshot of the API documentation page.](media/api-home-page.png)

## Perform operations in the API

In this section you:

* Perform several operations on the sample data
* Identify endpoint and data requirements for operations

### Task 1: Perform a `GET` operation

1. Expand the **GET** operation in the **Get all fruit** section by clicking anywhere in the **GET** operation box.

1. Explore the sections of the operation and note the information shown in the following table.

    | Section | Description |
    |---|--|
    | **Endpoint** | Shown in the header of the operation. The endpoint is shown as `/fruitlist`. The full URI is the base URL for the API appended with the specified endpoint, `http://localhost:5050/fruitlist` in our example. |
    | **Parameters** | None required for this operation. |
    | **Media type** | Specifies the media type encoding the operation will return. |
    | **Example Value** | Displays the schema of the data returned by the operation. Note that this operation returns a JSON array. |

1. Run the operation by selecting the **Try it out** button and then selecting **Execute**.

1. The **Responses** section of the operation has been updated with new information. Note the following:

    * **Request URL:** The URL accessed in the operation.
    * **Server response:**  Shows the success code from the operation and the  **Response body** displays the three sample records.

### Task 2: Perform a `POST` operation

1. Expand the **POST** operation in the **Add fruit to list** section by clicking anywhere in the **POST** operation box.

1. Explore the sections of the operation and note the information shown in the following table.

    | Section | Description |
    |---|--|
    | **Endpoint** | The endpoint is shown as `/fruitlist`. The full URI is the base URL for the API appended with the specified endpoint, `http://localhost:5050/fruitlist` in our example. |
    | **Parameters** | None required for this operation. |
    | **Request body** | The **Request body** is required since the API is expecting data to add to the list and it is expecting the media type `application/json`. |
    | **Example Value** | Displays the schema of the data the API is expecting to receive. |  

1. To run the operation select the **Try it out** button. 

1. Replace the JSON in the input box under the **Request body** section with the following:

    ```json
    {
        "id": 0,
        "name": "Pear",
        "instock": true
    }
    ```

    >**Note:** The database will assign it's own index value when adding data so there just needs to be a value in the `id` field.

1. The **Responses** section of the operation has been updated with new information. Note the following:

    * **Request URL:** The URL accessed in the operation.
    * **Server response:**  Shows the success code from the operation and the **Response body** displays the record added to the database.

1. Run the `GET` command in the **Get all fruit in list** section and note that a record for *Pear* is now included.

### Task 3: Perform a `DELETE` operation

1. Expand the **DELETE** operation in the **Delete fruit by Id** section by clicking anywhere in the **DELETE** operation box.

1. Explore the sections of the operation and note the information shown in the following table.

    | Section | Description |
    |---|--|
    | **Endpoint** | The endpoint is shown as `/fruitlist/{id}`. The full URI is the base URL for the API appended with the specified `id` for deletion. For example, `http://localhost:5050/fruitlist/1` points to the record where `id` equals `1`.
    | **Parameters** | Requires the `id` of the record to be passed in the request URL. |

1. To run the operation select the **Try it out** button. 

1. Delete the `Apple` record in the sample data by entering a `1` in the `id` field in the **Parameters** section and then selecting **Execute**.

1. The **Responses** section of the operation has been updated with new information. Note the following:

    * **Request URL:** The URL accessed in the operation.
    * **Response body:** Displays the deleted record.
    * **Code:**  Shows the success code from the operation.

1. Run the `GET` command in the **Get all fruit in list** section and note that the record for *Apple* is now deleted.

## Review

In this exercise you learned how to:

* Navigate a documented API
* Determine endpoints for HTTP operations
* Identify API requirements for HTTP operations
