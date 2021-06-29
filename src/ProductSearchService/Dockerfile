FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

ENV APP_HOME /opt/app
RUN mkdir $APP_HOME
WORKDIR $APP_HOME


COPY ProductSearchService/ProductSearchService.csproj $APP_HOME/ProductSearchService/
COPY ProductService/ProductService.csproj $APP_HOME/ProductService/
RUN  cd $APP_HOME/ProductSearchService && dotnet restore

COPY ProductSearchService/. $APP_HOME/ProductSearchService/
COPY ProductService/. $APP_HOME/ProductService/
RUN cd $APP_HOME/ProductSearchService && dotnet build


FROM build AS publish
WORKDIR $APP_HOME/ProductSearchService
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS final
WORKDIR /app
COPY --from=publish /opt/app/ProductSearchService/out ./
ENTRYPOINT ["dotnet", "ProductSearchService.dll"]