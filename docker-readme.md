### sfmc-restapi-demo

This is a *prototype* of a simple RESTful API for Salesforce Marketing Cloud created using [ASP.NET Core 2.0](https://docs.microsoft.com/en-us/aspnet/core/getting-started).

Demo walkthrough + source code is here: <https://github.com/sanagama/sfmc-restapi-demo>

### Run locally in Docker

1. Type the commands below in a ```Terminal``` window to run the REST API web app in Docker.

    >*TIP:* See the demo walkthrough at <https://github.com/sanagama/sfmc-restapi-demo>
    
    ```
    docker pull sanagama/sfmc-restapi-demo

    docker run -it -p 5000:5000 sanagama/sfmc-restapi-demo
    ```

1. Launch your browser and navigate to <http://localhost:5000/>

### Run in Heroku

To use this Docker image in Heroku, see: <https://devcenter.heroku.com/articles/container-registry-and-runtime>
