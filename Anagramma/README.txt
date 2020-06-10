1. Создание таблиц БД:

CREATE TABLE [dbo].[DICTSet] 
(
    [Id]     INT        IDENTITY (1, 1) NOT NULL,
    [NAME]   NVARCHAR(30) NULL,
    [ABC]    NVARCHAR(30) NULL, //Строка в алфавитном порядке для ускорения поиска
    [TYPE]   INT        NULL DEFAULT 0, //Устарело. Использовалось для выбора только существительных
    PRIMARY KEY CLUSTERED (ID ASC)
);

CREATE TABLE [dbo].DictCatResSet
(
	[Id] INT IDENTITY (1, 1) NOT NULL, 
    [DictId] INT NULL,
	PRIMARY KEY CLUSTERED (ID ASC)
);

CREATE TABLE [dbo].DictCatQRSet
(
	[Id] INT IDENTITY (1, 1) NOT NULL, 
    [DictId] INT NULL,
	PRIMARY KEY CLUSTERED (ID ASC)
);

CREATE TABLE [dbo].DictCatVariaSet
(
	[Id] INT IDENTITY (1, 1) NOT NULL, 
    [DictId] INT NULL,
	PRIMARY KEY CLUSTERED (ID ASC)
);

2. Вызовы библиотеки:

new Dict();
IEnumerable<DICTSet> Initialize(); //возвращает пустое перечисление
Dictionary<int, string>  GetCategory();//Список категорий
IEnumerable<DICTSet> Anagramma(string word, int category); //Ограничение длины строки 15 символов
IEnumerable<DICTSet> Mask(string word, int category);
IEnumerable<DICTSet> Generator(string word, int category);