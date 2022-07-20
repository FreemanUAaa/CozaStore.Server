#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Users/CozaStore.Server.Users.Consumers.SendConfirmEmailMessage/CozaStore.Server.Users.Consumers.SendConfirmationEmailMessage.csproj", "Services/Users/CozaStore.Server.Users.Consumers.SendConfirmEmailMessage/"]
COPY ["Messages/CozaStore.Server.Messages/CozaStore.Server.Messages.csproj", "Messages/CozaStore.Server.Messages/"]
RUN dotnet restore "Services/Users/CozaStore.Server.Users.Consumers.SendConfirmEmailMessage/CozaStore.Server.Users.Consumers.SendConfirmationEmailMessage.csproj"
COPY . .
WORKDIR "/src/Services/Users/CozaStore.Server.Users.Consumers.SendConfirmEmailMessage"
RUN dotnet build "CozaStore.Server.Users.Consumers.SendConfirmationEmailMessage.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CozaStore.Server.Users.Consumers.SendConfirmationEmailMessage.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CozaStore.Server.Users.Consumers.SendConfirmationEmailMessage.dll"]