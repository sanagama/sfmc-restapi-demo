# What's here?

This is a *prototype* of a simple RESTful API for Salesforce Marketing Cloud created using [ASP.NET Core 2.0](https://docs.microsoft.com/en-us/aspnet/core/getting-started).

## Try it out!

- Launch your browser and navigate to <https://sfmc-restapi-demo.herokuapp.com>
- Click on the various links to see the JSON response.

> *TIP:* [Google Chrome](https://www.google.com/chrome/) with the [JSON Formatter](https://github.com/callumlocke/json-formatter) extension is a great way to play with REST APIs.

> That's it, all done!

> Keep reading if you want to get the source code and compile and run locally.

## Run locally on your computer

You can run this prototype locally on Linux, macOS, Windows or Docker.

### Run locally in Docker

This REST API web app is available on Docker hub: <https://hub.docker.com/r/sanagama/sfmc-restapi-demo>

Copy & paste the commands below in a ```Terminal``` window to run the REST API web app in Docker on your computer.

```
docker run -it -p 5000:5000 sanagama/sfmc-restapi-demo

```

#### Play with the REST API

- Launch your browser and navigate to <http://localhost:5000/>
- Click on the various links to see the JSON response.


### Run locally with .NET Core

#### Get the source code

Download and install .NET Core for your operating system: <https://www.microsoft.com/net/core>

> *TIP:* If you have ```Git``` installed then you can do ```git clone https://github.com/sanagama/sfmc-restapi-demo.git``` instead.

- Browse to <https://github.com/sanagama/sfmc-restapi-demo>
- Click ```Clone or Download``` then click ```Download ZIP```
- Save the ZIP file to your ```HOME``` directory as ```~/sfmc-restapi-demo.zip```
- Extract the zip file to your ```HOME``` directory ```~/sfmc-restapi-demo```

#### Compile and run the web app

Type the following commands in the ```Terminal``` window to run the REST API web app locally:

```
cd ~/sfmc-restapi-demo
dotnet restore
dotnet build
dotnet run
```

#### Play with the REST API

- Launch your browser and navigate to <http://localhost:5000/>
- Click on the various links to see the JSON response.
