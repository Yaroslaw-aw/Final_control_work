# 7. Работа с MySQL (Задача выполняется в случае успешного выполнения задачи “Работа с MySQL в Linux. “Установить MySQL на вашу машину”

## 7.1. После создания диаграммы классов в 6 пункте, в 7 пункте база данных "Human Friends" должна быть структурирована в соответствии с этой диаграммой. Например, можно создать таблицы, которые будут соответствовать классам "Pets" и "Pack animals", и в этих таблицах будут поля, которые характеризуют каждый тип животных (например, имена, даты рождения, выполняемые команды и т.д.). 
## 7.2   - В ранее подключенном MySQL создать базу данных с названием "Human Friends".
   - Создать таблицы, соответствующие иерархии из вашей диаграммы классов.
   - Заполнить таблицы данными о животных, их командах и датами рождения.
   - Удалить записи о верблюдах и объединить таблицы лошадей и ослов.
   - Создать новую таблицу для животных в возрасте от 1 до 3 лет и вычислить их возраст с точностью до месяца.
   - Объединить все созданные таблицы в одну, сохраняя информацию о принадлежности к исходным таблицам.

Пример заполненной таблицы для теста:
Лист "Pets"
ID	Name	Type	BirthDate	Commands
1	Fido	Dog	2020-01-01	Sit, Stay, Fetch
2	WhiskersCat	2019-05-15	Sit, Pounce
3	Hammy	Hamster	2021-03-10	Roll, Hide
4	Buddy	Dog	2018-12-10	Sit, Paw, Bark
5	Smudge	Cat	2020-02-20	Sit, Pounce, Scratch
6	Peanut	Hamster	2021-08-01	Roll, Spin
7	Bella	Dog	2019-11-11	Sit, Stay, Roll
8	Oliver	Cat	2020-06-30	Meow, Scratch, Jump

 Лист "PackAnimals"
ID	Name	Type	BirthDate	Commands
1	Thunder	Horse	2015-07-21	Trot, Canter, Gallop
2	Sandy	Camel	2016-11-03	Walk, Carry Load
3	Eeyore	Donkey	2017-09-18	Walk, Carry Load, Bray
4	Storm	Horse	2014-05-05	Trot, Canter
5	Dune	Camel	2018-12-12	Walk, Sit
6	Burro	Donkey	2019-01-23	Walk, Bray, Kick
7	Blaze	Horse	2016-02-29	Trot, Jump, Gallop
8	Sahara	Camel	2015-08-14	Walk, Run