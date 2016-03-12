CREATE TABLE dbo.Pokemon(
	NationalDexId int PRIMARY KEY,
	GermanName nvarchar(50) NOT NULL,
	EnglishName nvarchar(50) NOT NULL,
	Frenchname nvarchar(50) NOT NULL,
	Thumbnail varbinary(max) NULL,
	Sprite varbinary(max) NULL,
	FirstType int NOT NULL,
	SecondType int NULL,
	BaseHP int NOT NULL,
	BaseAttack int NOT NULL,
	BaseDefense int NOT NULL,
	SpecialAttack int NOT NULL,
	SpecialDefense int NOT NULL,
	Speed int NOT NULL,
	BaseXp int NOT NULL,
	XpType int NOT NULL
)

CREATE TABLE dbo.Attack(
	Id int PRIMARY KEY,
	EnglishName nvarchar(50) NOT NULL,
	GermanName nvarchar(50) NOT NULL,
	FrenchName nvarchar(50) NOT NULL,
	DamageClass int NOT NULL,
	Type int NOT NULL,
	Accuracy int NOT NULL,
	Strength int NOT NULL
)