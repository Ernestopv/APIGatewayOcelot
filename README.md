# APIGatewayOcelot 

The project demonstrates the basic concepts of APIGateway using Ocelot and was built on top of asp.net core 5, it contains the following:
 
#### 3 microServices :
 
* MicroServices.Customer Port:3001
```
http://localhost:3001/api/Customer
http://localhost:3001/api/Customer/{id}
```
* MicroServices.Coffee,  Port:3002
```
http://localhost:3002/Coffee
```

* MicroServices.Tea,     Port:3003
```
http://localhost:3003/Tea
```


#### 1 Library:
* MicroServices.Model

#### 1 APIGateway:
* APIGateWay.Ocelot     Port:3004
```
http://localhost:3004/api/Customer/{id}
http://localhost:3004/Coffee
http://localhost:3004/Tea
```

##### Request Aggregation:
```
http://localhost:3004/customer-process-Coffee/{id}

http://localhost:3004/customer-process-Tea/{id}
```


## Configuration

Go to ==>  APIgateway.Ocelot/appsettings.json and change "isDockerEnabled:" value set to true if docker-compose is used, set false to run on your localhost from the visual studio:

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",

  "isDockerEnabled": true 
}

```
The project by default is set to `true` to run on Docker-compose

### Docker

To build and run on docker go to APIGatewatOcelot/  where docker-compose.yml is located and type the following command  :
```
Docker-compose up --build
```
