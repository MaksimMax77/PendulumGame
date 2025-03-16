<div align="center">
# PendulumGame
<p align="center">
   <a href="https://learn.microsoft.com/ru-ru/dotnet/csharp/">
   <img src="https://img.shields.io/badge/C%23-.NET Standart 2.1-blue"/></a>
     <img src="https://img.shields.io/badge/Unity-2022.3.33f1-blue"/></a>
</p>
  
# Информация о проекте
На проект ушло в целом часов 5. 
Ядром приложения являются следующие классы: Installer, GlobalUpdate, Disposer.
Приложение стартует в Installer, где инициализируется объекты, прокидываются зависимости. 
В GlobalUpdate вызывается апдейт, в него прокидываются объекты, которым требуется обновляться каждый кадр.
В Disposer вызывается Dispose метод объектов, которым это нужно. 
