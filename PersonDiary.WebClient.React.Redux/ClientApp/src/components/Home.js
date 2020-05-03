import React from 'react';
import { connect } from 'react-redux';

const Home = props => (
  <div>
        <h1>Person's Diary (React/Redux cient)</h1>
        <p>
            Данный проект написан в ходе чтения книги Марка Симана "Внедрение зависимостей в .Net". Цель: реализовать бизнес логику, к которой можно было бы подключать различные реализации уровня доступа к данным и различные реализации клиентов без переписывания самой бизнес логики, т.е. создать систему со слабо связанным кодом. Так же учтены некоторые рекомендации из "Асинхронного программирования в C# 5.0" Алекса Дэвиса
        </p>

        <p>  Предметная область: Человек/Персона (имя, фамилия, .doc-файл биографии) и события его жизни (название события, дата события).</p>

        <p> Реализация:</p>
        <ul>
        <li>PersonDiary.Angular.EFCore - клиентское приложение, Asp.Net core web application Angular 6, с data-сервисами.</li>
        <li>PersonDiary.React.EFCore - клиентское приложение, Asp.Net core web application ReactJS and Redux.</li>
        <li>PersonDiary.BusinessLogic - Net.Core библиотека бизнес логики, с которой работают оба клиентских приложения, в конструкторы моделей которой впрыскиваются зависимости уровня доступа к данным и архиватора .doc файлов</li>
        <li>PersonDiary.DataLayer.EFCore - Net.Core библиотека уровня доступа к данным (MS SQL/EF Core).</li>
        <li>PersonDiary.Interfaces - Net.Core библиотека, в которой описаны интерфейсы, которые должны реализовывать зависимости, так же тут находятся сущности.</li>
        <li>PersonDiary.BusinessLogic - Юнит-тесты бизнес логики.</li>
        <li>PersonDiary.Archivator - Net.Core библиотека архиватора .doc файлов (находится в разработке)</li>
        </ul>
  </div>
);

export default connect()(Home);
