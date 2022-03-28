FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app
COPY *.csproj ./

RUN dotnet restore --disable-parallel

COPY . .
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .

# ENTRYPOINT [ "dotnet", "KulaLearnMVC.dll" ]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet KulaLearnMVC.dll
