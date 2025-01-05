## Authentication
### OIDC (OpenID Connect) Workds
1. The RP (Client) sends a request to the OpenID Provider (OP).
2. The OP authenticates the End-User and obtains authorization.
3. The OP responds with an ID Token and usually an Access Token.
4. The RP can send a request with the Access Token to the UserInfo Endpoint.
5. The UserInfo Endpoint returns Claims about the End-User.

+--------+                                   +--------+
|        |                                   |        |
|        |---------(1) AuthN Request-------->|        |
|        |                                   |        |
|        |  +--------+                       |        |
|        |  |        |                       |        |
|        |  |  End-  |<--(2) AuthN & AuthZ-->|        |
|        |  |  User  |                       |        |
|   RP   |  |        |                       |   OP   |
|        |  +--------+                       |        |
|        |                                   |        |
|        |<--------(3) AuthN Response--------|        |
|        |                                   |        |
|        |---------(4) UserInfo Request----->|        |
|        |                                   |        |
|        |<--------(5) UserInfo Response-----|        |
|        |                                   |        |
+--------+                                   +--------+

Flow Token
  +--------+                                           +---------------+
  |        |--(A)------- Authorization Grant --------->|               |
  |        |                                           |               |
  |        |<-(B)----------- Access Token -------------|               |
  |        |               & Refresh Token             |               |
  |        |                                           |               |
  |        |                            +----------+   |               |
  |        |--(C)---- Access Token ---->|          |   |               |
  |        |                            |          |   |               |
  |        |<-(D)- Protected Resource --| Resource |   | Authorization |
  | Client |                            |  Server  |   |     Server    |
  |        |--(E)---- Access Token ---->|          |   |               |
  |        |                            |          |   |               |
  |        |<-(F)- Invalid Token Error -|          |   |               |
  |        |                            +----------+   |               |
  |        |                                           |               |
  |        |--(G)----------- Refresh Token ----------->|               |
  |        |                                           |               |
  |        |<-(H)----------- Access Token -------------|               |
  +--------+           & Optional Refresh Token        +---------------+


### Publish IIS:
- web.config contains local module (AspNetCoreModuleV2), the module refer from <globalModules> in %windir%\System32\inetsrv\config\applicationHost.config.
- AspNetCoreModuleV2 in C:\Program Files\IIS\Asp.Net Core Module\V2, by install dotnet hosting server
- Other module is installed by **appCmd** or **Turn Windows features on or off**

## Docker, .NET and DB
### .NET and Docker:
Dockerfile uses Docker multiple stage:
- Build: `dotnet/sdk`. The image contains the **.NET SDK (include CLI)**
- Run: `dotnet/aspnet`. The image contains the **ASP.NET Core runtime and libraries**

Build and deploy manually
1. Publish .net app: `dotnet publish -c Release -o published`.
2. Run app: `dotnet published\aspnetapp.dll` and browse to `http://localhost:[local port]` to test the home page.
3. Deploy to Docker
	- Create **Dockerfile**
		```Dockerfile
			FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime			WORKDIR /app				COPY published/ ./
			ENTRYPOINT ["dotnet", "aspnetapp.dll"]
		```
	- Build image: `docker build .`. Aliases: `docker image build`, `docker build`, `docker builder build`
		+ OR build with name image: `docker build -t [image name] .`. build image with tag name at build context `.` 
		  (Build context is the directory containing the Dockerfile and any files needed for the image)
	- Run container from image: `docker run -it --rm -p [local port]:[container port] --name [container name] [image name]`
		+ `-it`: Allocate a pseudo-TTY and keep it open even if not attached
		+ `--rm`: Remove the container when it exits
	- Go to `http://localhost:[local port` in a browser to test the app.

### DB and Docker:
Start mysql: `docker run --name [container name] -p [local port]:[container port] -e MYSQL_ROOT_PASSWORD=[pass] -e MYSQL_DATABASE=[DB name] -d mysql:latest`

### .NET and DB
1. Add `ConnectionStrings` in appsetting.json (FridgeBE.Api)
2. Add Connection in `Startup` (FridgeBE.Infrastructure)

1. 
### Compose up .NET and DB in Docker
Follow: https://learn.microsoft.com/en-us/aspnet/core/security/docker-compose-https?view=aspnetcore-9.0
[Maybe] Setting on top in **appsettings.json**
```
"http_ports": "5091",
"https_ports": "7160",
```
1. Create Self-signed development certificates
```
dotnet dev-certs https -ep ./https/aspnetapp.pfx -p YourPassword
dotnet dev-certs https --trust
```
2. In **appsettings.json**
- Add `Server=host.docker.internal` in connection string to identity Mysql host in docker
3. In **compose.yaml** 
- Set server: target final stage in Dockerfile
	- Add **ports**, **environment** and **volumes** to mount certificate
	- Add **extra_hosts** = `host.docker.internal:host-gateway`
- Set migrator: to execute migration in target build stage 
3. Build: `docker-compose up --build -d`
- To remove image and container: `docker-compose down --volumes --remove-orphans`
