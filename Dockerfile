# build our image, this is the first stage 
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base    
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

# next stage of bulid from another base image 
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Catalog.csproj", "./"]
RUN dotnet restore "Catalog.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Catalog.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Catalog.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Catalog.dll"]
