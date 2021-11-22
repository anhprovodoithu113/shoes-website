FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app
# EXPOSE 80
# EXPOSE 5000

# ENV ASPNETCORE_URLS=http://+:80
# ENV ASPNETCORE_URLS=http://+:5000

# copy csproj and restore as distinct layers
COPY *.sln .
COPY Shoes-Website-Project/*.csproj ./Shoes-Website-Project/
COPY Shoes-Website.API.IntegrationTests/*.csproj ./Shoes-Website.API.IntegrationTests/
COPY Shoes-Website.Application/*.csproj ./Shoes-Website.Application/
COPY Shoes-Website.Application.UnitTests/*.csproj ./Shoes-Website.Application.UnitTests/
COPY Shoes-Website.Domain/*.csproj ./Shoes-Website.Domain/
COPY Shoes-Website.Infrastructure/*.csproj ./Shoes-Website.Infrastructure/

RUN dotnet restore

# copy everything else and build app
COPY Shoes-Website-Project/. ./Shoes-Website-Project/
COPY Shoes-Website.API.IntegrationTests/. ./Shoes-Website.API.IntegrationTests/
COPY Shoes-Website.Application/. ./Shoes-Website.Application/
COPY Shoes-Website.Application.UnitTests/. ./Shoes-Website.Application.UnitTests/
COPY Shoes-Website.Domain/. ./Shoes-Website.Domain/
COPY Shoes-Website.Infrastructure/. ./Shoes-Website.Infrastructure/

WORKDIR /app/Shoes-Website-Project

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS runtime
WORKDIR /app
RUN mkdir /app/resources
COPY --from=build /app/Shoes-Website-Project/out ./
# ENTRYPOINT ["dotnet", "Shoes-Website.API.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Shoes-Website.API.dll