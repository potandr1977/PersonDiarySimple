Данный проект написан в ходе чтения книги Марка Симана "Внедрение зависимостей в .Net".
Цель: реализовать бизнес логику, к которой можно было бы подключать различные реализации уровня доступа к данным и 
различные реализации клиентов без переписывания самой бизнес логики, т.е. создать систему со слабо связанным кодом.
Так же учтены некоторые рекомендации из "Асинхронного программирования в  C# 5.0" Алекса Дэвиса и "Предметно ориентированное проектирование" Эрика Эванса. 

Предметная область:
Человек/Персона (имя, фамилия, .doc-файл биографии) и события его жизни (название события, дата события). 

Реализация:
1) PersonDiary.WebClient.Angular   - клиентское приложение, Asp.Net core web application Angular 6, с data-сервисами.
2) PersonDiary.WebClient.React     - клиентское приложение, Asp.Net core web application ReactJS and Redux.
3) PersonDiary.Business    - Net.Core библиотека бизнес логики, с которой работают оба клиентских приложения, 
в конструкторы которой впрыскиваются зависимости уровня доступа к данным
4) PersonDiary.DataAccess.EfCore - Net.Core библиотека уровня доступа к данным (MS SQL/EF Core).
5) PersonDiary.Domain  - Net.Core библиотека, домен предметной области. 
6) PersonDiary.Infrastructure.Domain - домен слоя инфраструктуры 
7) PersonDiary.Business.Test    - Юнит-тесты бизнес логики.

This project was writen during reading Mark Seeman "Dependency Injection in .Net" book.
The goal: to implement business logic, which could be able to work with different implementation of data layer and MVVM clients. i.e. the main goal is to implement system with loosely coupled code. Also this project implements some recomendations of "Asyc in C# 5.0" Alex Davies's book and "Domain Driven Design" by Eric Evans

Domain:
Person (his name, surname and biography file) and his life events list (event name adn event date). 

Projects list:
1) PersonDiary.WebClient.Angular   - client application, Asp.Net core web application Angular 6.
2) PersonDiary.WebClient.React     - client application, Asp.Net core web application ReactJS and Redux.
3) PersonDiary.Business    - Net.Core library of business logic, both client applications (angular and react) works with only BL. 
4)  PersonDiary.DataAccess.EfCore - Net.Core data access level library based on MS SQL/EF Core. The other implementations of DA layer will be added later.
5) PersonDiary.Domain       - Net.Core library, project domain interfaces
6) PersonDiary.Business.Test- nUnit test of business logic.
7) PersonDiary.Infrastructure.Domain       - infrastructure domain layer
