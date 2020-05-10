# Case Campeonato
Case API Net Core Clean Architeture SOLID

*Tecnologias*
* .NET Core 3.1
* ASP.NET Core 3.1
* Entity Framework Core 3.1
* C# 8.0
* Serilog
* XUnit 

*Praticas*
* Clean Code
* SOLID Principles
* DDD (Domain-Driven Design)
* Separation of Concerns
* Logging

*Camadas*

* Web: Rest API - Campeonato.Api
* DataBase: Entity Framework Core *SQLite* - Campeonato.Data
* Services: Regras de negocio - Campeonato.Service
* Model: Data transfer objets - Campeonato.Model
* Resources: algumas classes auxiliares - Campeonato.Resourses
* Test: XUnit - Campeonato.Test

*Configurações e utilização*

 *Entrada*
 
 O projeto está configurado para usar a url: http://localhost:5000/
 Possui um entrada de dados que é uma listagem de campeaonatos de futebol do ano de 2015 a 2019, contendo os resultados por times. O formato do arquivo é Json que está localizado na raiz do projeto com o nome de JsonCaseCampeonato.json.
 Para se fazer o upload  do arquivo o usuário deverá utilizar o seguinte API via post:
 
 http://localhost:5000/api/File
 
 Os dados serão armazenados em uma base de dados SQLite (Campeonato.db)
 
 *Saida*
 
 O projeto possui três chamdas GET para listagem de dados:
 * http://localhost:5000/api/campeonato/portime - fornece uma lista em json com os dados consolidados de todos os times dos campeonatos que participaram de 2015 a 2019 por time.
 
 * http://localhost:5000/api/campeonato/porestado - fornece uma lista em json com os dados consolidados de todos os times dos campeonatos que participaram de 2015 a 2019 por Estado.
 
 * http://localhost:5000/api/campeonato/info - forne uma lisa em json com alguns dados sobre os times no campeonato.
 
 *Testes*
 
 Foi utilizado o framework XUnit para realizar alguns testes da aplicação.
 Os testes são realizados usando uma base de dados InMemory do Entity. É feito um Seed nesta base de dados carregando o arquivo JsonCaseCampeonato.json que esta armazenado na pasta Rerourses do projeto de teste.
 
 Foi criado testes para as três operações na classe CampeonatoControllerTest:
 * CanGetInfo()
 * CanGetPerTime()
 * CanGetPorEstado()
 
 
 
