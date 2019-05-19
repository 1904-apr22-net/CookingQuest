--Create Database

CREATE DATABASE CookingQuest;
GO

--Refresh then Select DB and Create Schema

CREATE SCHEMA cq;
GO


CREATE Table cq.Player(
	PlayerId INT NOT NULL IDENTITY,
	Name NVARCHAR(200) NOT NULL,
	Gold INT NOT NULL DEFAULT 0,
	CONSTRAINT PK_PlayerId PRIMARY KEY(PlayerId),
);

CREATE TABLE cq.Account(
	AccountId INT NOT NULL IDENTITY,
	Username NVARCHAR(200) NOT NULL UNIQUE,
	Password NVARCHAR(200) NOT NULL,
	PlayerId INT NOT NULL,
	CONSTRAINT PK_AccountId PRIMARY KEY(AccountId),
	CONSTRAINT FK_Player FOREIGN KEY(PlayerId) REFERENCES cq.Player(PlayerId),
);

CREATE TABLE cq.Equipment(
	EquipmentId INT NOT NULL IDENTITY,
	Modifier INT NOT NULL DEFAULT 1,
	Name NVARCHAR(200) NOT NULL,
	Price INT NOT NULL,
	Type NVARCHAR(200) NOT NULL DEFAULT 'Dungeon',
	Difficulty INT NOT NULL CHECK (Difficulty >= 1 AND Difficulty <= 9),
	CONSTRAINT PK_EquipmentId PRIMARY KEY(EquipmentId),
)

CREATE TABLE cq.Location(
	LocationId INT NOT NULL IDENTITY,
	Name NVARCHAR(200) NOT NULL,
	Difficulty INT NOT NULL CHECK (Difficulty >= 1 AND Difficulty <= 9),
	Description NVARCHAR(200) NOT NULL,
	CONSTRAINT PK_LocationId PRIMARY KEY(LocationId),
);

CREATE TABLE cq.Loot(
	LootId INT NOT NULL IDENTITY,
	Name NVARCHAR(200) NOT NULL,
	Price INT NOT NULL DEFAULT 0,
	Description NVARCHAR(200) NOT NULL,
	CONSTRAINT PK_LootId PRIMARY KEY(LootId),
);

CREATE TABLE cq.Recipe(
	RecipeId INT NOT NULL IDENTITY,
	Name NVARCHAR(200) NOT NULL,
	Description NVARCHAR(200) NOT NULL,
	CONSTRAINT PK_RecipeId PRIMARY KEY(RecipeId),
);

CREATE TABLE cq.Flavor(
	FlavorId INT NOT NULL IDENTITY,
	Name NVARCHAR(200) NOT NULL,
	Description NVARCHAR(200) NOT NULL,
	CONSTRAINT PK_FlavorId PRIMARY KEY(FlavorId),
);

CREATE TABLE cq.Store(
	StoreId INT NOT NULL IDENTITY,
	Name NVARCHAR(200) NOT NULL,
	Description NVARCHAR(200) NOT NULL,
	CONSTRAINT PK_StoreId PRIMARY KEY(StoreId),
);


--Join Tables
CREATE TABLE cq.Player_Equipment(
	Player_EquipmentId INT NOT NULL IDENTITY,
	PlayerId INT NOT NULL,
	EquipmentId INT NOT NULL,
	CONSTRAINT PK_Player_EquipmentId PRIMARY KEY(Player_EquipmentId),
	CONSTRAINT FK_PlayerId_EquipmentId FOREIGN KEY(PlayerId) REFERENCES cq.Player(PlayerId),
	CONSTRAINT FK_EquipmentId_PlayerId FOREIGN KEY(EquipmentId) REFERENCES cq.Equipment(EquipmentId)
);

CREATE TABLE cq.Player_Location(
	Player_Location INT NOT NULL IDENTITY,
	PlayerId INT NOT NULL,
	LocationId INT NOT NULL,
	CONSTRAINT PK_Player_Location PRIMARY KEY(Player_Location),
	CONSTRAINT FK_Player_Location FOREIGN KEY(PlayerId) REFERENCES cq.Player(PlayerId),
	CONSTRAINT FK_Location_Player FOREIGN KEY(LocationId) REFERENCES cq.Location(LocationId)
);

CREATE TABLE cq.Player_Loot(
	Player_LootId INT NOT NULL IDENTITY,
	PlayerId INT NOT NULL,
	LootId INT NOT NULL,
	Quantity INT NOT NULL,
	CONSTRAINT PK_Player_Loot PRIMARY KEY(Player_LootId),
	CONSTRAINT FK_Player_Loot FOREIGN KEY(PlayerId) REFERENCES cq.Player(PlayerId),
	CONSTRAINT FK_Loot_Player FOREIGN KEY(LootId) REFERENCES cq.Loot(LootId)
);

CREATE TABLE cq.Store_Equipment(
	Store_EquipmentId INT NOT NULL IDENTITY,
	StoreId INT NOT NULL,
	EquipmentId INT NOT NULL,
	CONSTRAINT PK_Store_Equipment PRIMARY KEY(Store_EquipmentId),
	CONSTRAINT FK_Store_Equipment FOREIGN KEY(StoreId) REFERENCES cq.Store(StoreId),
	CONSTRAINT FK_EquipmentId_Store FOREIGN KEY(EquipmentId) REFERENCES cq.Equipment(EquipmentId)
);

CREATE TABLE cq.Location_Loot(
	Location_LootId INT NOT NULL IDENTITY,
	LocationId INT NOT NULL,
	LootId INT NOT NULL,
	DropRate INT NOT NULL,
	CONSTRAINT PK_Location_Loot PRIMARY KEY(Location_LootId),
	CONSTRAINT FK_Location_Loot FOREIGN KEY(LocationId) REFERENCES cq.Location(LocationId),
	CONSTRAINT FK_Loot_Location FOREIGN KEY(LootId) REFERENCES cq.Loot(LootId)
);

CREATE TABLE cq.Recipe_Loot(
	Recipe_LootId INT NOT NULL IDENTITY,
	RecipeId INT NOT NULL,
	LootId INT NOT NULL,
	CONSTRAINT PK_Recipe_Loot PRIMARY KEY(Recipe_LootId),
	CONSTRAINT FK_Recipe_Loot FOREIGN KEY(RecipeId) REFERENCES cq.Recipe(RecipeId),
	CONSTRAINT FK_Loot_Recipe FOREIGN KEY(LootId) REFERENCES cq.Loot(LootId)
);

CREATE TABLE cq.Flavor_Loot(
	Flavor_LootId INT NOT NULL IDENTITY,
	FlavorId INT NOT NULL,
	LootId INT NOT NULL,
	CONSTRAINT PK_Flavor_Loot PRIMARY KEY(Flavor_LootId),
	CONSTRAINT FK_Flavor_Loot FOREIGN KEY(FlavorId) REFERENCES cq.Flavor(FlavorId),
	CONSTRAINT FK_Loot_Flavor FOREIGN KEY(LootId) REFERENCES cq.Loot(LootId)
);

CREATE TABLE cq.Store_Flavor(
	Store_FlavorId INT NOT NULL IDENTITY,
	StoreId INT NOT NULL,
	FlavorId INT NOT NULL,
	Bonus INT NOT NULL, 
	CONSTRAINT PK_Store_Flavor PRIMARY KEY(Store_FlavorId),
	CONSTRAINT FK_Store_Flavor FOREIGN KEY(StoreId) REFERENCES cq.Store(StoreId),
	CONSTRAINT FK_Flavor_Store FOREIGN KEY(FlavorId) REFERENCES cq.Flavor(FlavorId)
);


