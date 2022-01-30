# Define base image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS builder
EXPOSE 7292

WORKDIR /source

# Copy all source code
COPY . .

# Restore
RUN dotnet restore "HomeCafeteriaApi.sln"

# Publish

WORKDIR /source
RUN dotnet publish "HomeCafeteriaApi.sln" -c Release -o /publish

# Runtime
FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /app
COPY --from=builder /publish .
ENTRYPOINT ["dotnet", "HomeCafeteriaApi.dll"]
