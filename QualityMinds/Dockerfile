FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app
COPY *.sln .
COPY ["QualityMinds/QualityMinds.csproj", "QualityMinds/"]
RUN dotnet restore QualityMinds/QualityMinds.csproj

# copy full solution over
COPY . .
RUN dotnet build

WORKDIR /app/QualityMinds

ENTRYPOINT ["dotnet", "test", "QualityMinds.csproj"]
