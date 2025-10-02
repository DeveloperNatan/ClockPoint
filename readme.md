[Usuário / Cliente]
|
| HTTP Request (GET, POST, PUT, DELETE)
v
[ASP.NET Core Middleware]
|
| Trata autenticação, logs, roteamento e erros
v
[Controllers / Endpoints] <-- Seu código C# que responde às requisições
|
| Usa serviços injetados (Dependency Injection)
v
[Serviços / Business Logic]
|
| Lógica da aplicação, validações, regras de negócio
v
[Entity Framework Core (DbContext)]
|
| ORM converte objetos C# em comandos SQL
v
[PostgreSQL Database] <-- Banco de dados onde os dados são armazenados

