FROM mcr.microsoft.com/dotnet/aspnet:5.0 as base
COPY bin/Release/net5.0/publish/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "PersonasConsoleRegister.dll"]
CMD ["entrar"]