FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 7184

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HomeCafeteriaApp/HomeCafeteriaApp.csproj", "HomeCafeteriaApp/"]
RUN dotnet restore "HomeCafeteriaApp/HomeCafeteriaApp.csproj"
COPY . .
WORKDIR "/src/HomeCafeteriaApp"
RUN dotnet build "HomeCafeteriaApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HomeCafeteriaApp.csproj" -c Release -o /app/publish

FROM nginx:alpine
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot ./