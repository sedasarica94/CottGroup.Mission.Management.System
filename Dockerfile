FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
 
COPY ["CottGroup.Mission.Management.System.WebApi/CottGroup.Mission.Management.System.WebApi.csproj", "CottGroup.Mission.Management.System.WebApi/"]
COPY ["CottGroup.Mission.Management.System.Core/CottGroup.Mission.Management.System.Core.csproj", "CottGroup.Mission.Management.System.Core/"]
COPY ["CottGroup.Mission.Management.System.Infrastructure/CottGroup.Mission.Management.System.Infrastructure.csproj", "CottGroup.Mission.Management.System.Infrastructure/"]
COPY ["CottGroup.Mission.Management.System.Services/CottGroup.Mission.Management.System.Services.csproj", "CottGroup.Mission.Management.System.Services/"]
 
RUN dotnet restore "CottGroup.Mission.Management.System.WebApi/CottGroup.Mission.Management.System.WebApi.csproj"
 
COPY . .
 
WORKDIR "/src/CottGroup.Mission.Management.System.WebApi"
RUN dotnet publish -c Release -o /app
 
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app
COPY --from=build /app .
 
ENTRYPOINT ["dotnet", "CottGroup.Mission.Management.System.WebApi.dll"]
