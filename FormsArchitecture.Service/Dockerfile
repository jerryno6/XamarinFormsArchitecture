FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["FormsArchitecture.Service/FormsArchitecture.Service.csproj", "FormsArchitecture.Service/"]
RUN dotnet restore "FormsArchitecture.Service/FormsArchitecture.Service.csproj"
COPY . .
WORKDIR "/src/FormsArchitecture.Service"
RUN dotnet build "FormsArchitecture.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FormsArchitecture.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FormsArchitecture.Service.dll"]
