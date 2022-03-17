1 - Num caso de vida real, o modelo de caminhão seria um value object com propriedades Name e YearModel
3 - O correto seria criar um appsettings.json no projeto Volvo.Application, pulei para economizar tempo
4 - Existem outras técnicas que seriam bem úteis como uso de swagger, AutoMapper
5 - O projeto é levemente baseado em DDD. Precisaria implementar os aggregates, value objects, mas o projeto é bem pequeno
6 - Implementa algumas patterns bem interessantes Solid, layered pattern, repository, dependency injection, etc...


ambiente com sdk .net 6


para preparar o projeto altere as strings de conexão em:

src/Volvo.EntityFramework.Test/BaseTest.cs
src/Volvo.EntityFramework/Context/ContextFactory.cs

dentro do projeto src/Volvo.EntityFramework, execute o comando: dotnet ef database update

para executar o projeto:

na pasta src/Volvo.Application/ -> execute dotnet run

para rodar o teste:

na pasta src/Volvo.EntityFramework.Test -> execute dotnet test

 


1 - In a real life case, the truck model would be a value object with Name and YearModel properties
3 - The right way would be to create an appsettings.json in the Volvo.Application project, I skipped it to save time
4 - There are other techniques that would be very useful such as using swagger, AutoMapper
5 - The project is lightly based on DDD. I would need to implement aggregates, value objects, but the project is very small
6 - Implements some patterns like Solid, layered pattern, repository, dependency injection, etc...

environment with .net 6 sdk

to prepare the project change the connection strings in:

src/Volvo.EntityFramework.Test/BaseTest.cs
src/Volvo.EntityFramework/Context/ContextFactory.cs

inside the src/Volvo.EntityFramework project, run the command: dotnet ef database update

to execute the project:

in the src/Volvo.Application/ folder -> run dotnet run

to run the test:

in src/Volvo.EntityFramework.Test folder -> run dotnet test




DELETE http://localhost:xxxx/api/Trucks/{GUID}

GET http://localhost:xxxx/api/Trucks/

GET http://localhost:xxxx/api/Trucks/{GUID}

PUT http://localhost:xxxx/api/Trucks/
{
    "id": {GUID},
    "SerialNumber": "AAA12312412VCXZ",
    "Model": "FH",
    "YearModel":"2022",
    "Manufactured":"01/01/2021"
}

POST http://localhost:xxxx/api/Trucks/
{
    "SerialNumber": "AAA12312412VCXZ",
    "Model": "FH",
    "YearModel":"2022",
    "Manufactured":"01/01/2021"
}










