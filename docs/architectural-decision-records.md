# Architectural Decision Records
Explanation of some decision made during development process.

## Backend

1. **Framework**
.NET C# and ASP.NET because it fits to the problem and there is the best competence in team for that tools. 
2. **Docker**
It's easy to run project in encapsulated environment. Docker provide such possibility and it's easy to use. 
3. **Project architecture**
Ports and Adapters (hexagonal architecture). Mostly because layered architecture may violate some OOP and SOLID principles. Also there are two explicit adapters in project: Controller (incoming) and SpotifyService (outcoming). It's easy to switch outcoming adapter if there is a need to use another service since use case service utilizes contract instead of service dependency. In this architecture we have clear view of Domain (Recommendation), Application (ports and use cases) and Adapter layers. Easy to main and extend. 
4. **Memory Cache** Used for token storage. Token has it's own time until it's expired. It may be not the best idea to request token every time. If it's possible it's better to cache it and use until it's valid. 
5. **CORS** API has configured CORS policy for http://localhost:3000 only. If some another address in needed it should be changed inside `Startup.cs` class.
6. **appSettings.json** For required configuration appSettings.json is used. In real production env all secrets, passwords, connection strings should be stored in some vault like KeyVault in Azure.