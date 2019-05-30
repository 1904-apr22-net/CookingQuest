DROP TABLE IF EXISTS cq.Store_Flavor
GO
DROP TABLE IF EXISTS cq.Store_Equipment
GO
DROP TABLE IF EXISTS cq.Store
GO
DROP TABLE IF EXISTS cq.Recipe_Loot
GO
DROP TABLE IF EXISTS cq.Recipe
GO
DROP TABLE IF EXISTS cq.Player_Loot
GO
DROP TABLE IF EXISTS cq.Player_Location
GO
DROP TABLE IF EXISTS cq.Player_Equipment
GO
DROP TABLE IF EXISTS cq.Location_Loot
GO
DROP TABLE IF EXISTS cq.Flavor_Loot
GO
DROP TABLE IF EXISTS cq.Location
GO
DROP TABLE IF EXISTS cq.Flavor
GO
DROP TABLE IF EXISTS cq.Equipment
GO
DROP TABLE IF EXISTS cq.Account
GO
DROP TABLE IF EXISTS cq.Loot
GO
DROP TABLE IF EXISTS cq.Player
GO


/****** Object:  Table [cq].[Account]    Script Date: 5/26/2019 6:59:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cq].[Account](
	[AccountId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](200) NOT NULL,
	[Password] [nvarchar](200) NOT NULL,
	[PlayerId] [int] NOT NULL,
	[IsAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_AccountId] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [cq].[Equipment]    Script Date: 5/26/2019 6:59:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cq].[Equipment](
	[EquipmentId] [int] IDENTITY(1,1) NOT NULL,
	[Modifier] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Price] [int] NOT NULL,
	[Type] [nvarchar](200) NOT NULL,
	[Difficulty] [int] NOT NULL,
 CONSTRAINT [PK_EquipmentId] PRIMARY KEY CLUSTERED 
(
	[EquipmentId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [cq].[Flavor]    Script Date: 5/26/2019 6:59:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cq].[Flavor](
	[FlavorId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_FlavorId] PRIMARY KEY CLUSTERED 
(
	[FlavorId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [cq].[Flavor_Loot]    Script Date: 5/26/2019 6:59:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cq].[Flavor_Loot](
	[Flavor_LootId] [int] IDENTITY(1,1) NOT NULL,
	[FlavorId] [int] NOT NULL,
	[LootId] [int] NOT NULL,
 CONSTRAINT [PK_Flavor_Loot] PRIMARY KEY CLUSTERED 
(
	[Flavor_LootId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [cq].[Location]    Script Date: 5/26/2019 6:59:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cq].[Location](
	[LocationId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Difficulty] [int] NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_LocationId] PRIMARY KEY CLUSTERED 
(
	[LocationId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [cq].[Location_Loot]    Script Date: 5/26/2019 6:59:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cq].[Location_Loot](
	[Location_LootId] [int] IDENTITY(1,1) NOT NULL,
	[LocationId] [int] NOT NULL,
	[LootId] [int] NOT NULL,
	[DropRate] [int] NOT NULL,
 CONSTRAINT [PK_Location_Loot] PRIMARY KEY CLUSTERED 
(
	[Location_LootId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [cq].[Loot]    Script Date: 5/26/2019 6:59:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cq].[Loot](
	[LootId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Price] [int] NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_LootId] PRIMARY KEY CLUSTERED 
(
	[LootId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [cq].[Player]    Script Date: 5/26/2019 6:59:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cq].[Player](
	[PlayerId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Gold] [int] NOT NULL,
 CONSTRAINT [PK_PlayerId] PRIMARY KEY CLUSTERED 
(
	[PlayerId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [cq].[Player_Equipment]    Script Date: 5/26/2019 6:59:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cq].[Player_Equipment](
	[Player_EquipmentId] [int] IDENTITY(1,1) NOT NULL,
	[PlayerId] [int] NOT NULL,
	[EquipmentId] [int] NOT NULL,
 CONSTRAINT [PK_Player_EquipmentId] PRIMARY KEY CLUSTERED 
(
	[Player_EquipmentId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [cq].[Player_Location]    Script Date: 5/26/2019 6:59:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cq].[Player_Location](
	[Player_Location] [int] IDENTITY(1,1) NOT NULL,
	[PlayerId] [int] NOT NULL,
	[LocationId] [int] NOT NULL,
 CONSTRAINT [PK_Player_Location] PRIMARY KEY CLUSTERED 
(
	[Player_Location] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [cq].[Player_Loot]    Script Date: 5/26/2019 6:59:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cq].[Player_Loot](
	[Player_LootId] [int] IDENTITY(1,1) NOT NULL,
	[PlayerId] [int] NOT NULL,
	[LootId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_Player_Loot] PRIMARY KEY CLUSTERED 
(
	[Player_LootId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [cq].[Recipe]    Script Date: 5/26/2019 6:59:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cq].[Recipe](
	[RecipeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_RecipeId] PRIMARY KEY CLUSTERED 
(
	[RecipeId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [cq].[Recipe_Loot]    Script Date: 5/26/2019 6:59:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cq].[Recipe_Loot](
	[Recipe_LootId] [int] IDENTITY(1,1) NOT NULL,
	[RecipeId] [int] NOT NULL,
	[LootId] [int] NOT NULL,
 CONSTRAINT [PK_Recipe_Loot] PRIMARY KEY CLUSTERED 
(
	[Recipe_LootId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [cq].[Store]    Script Date: 5/26/2019 6:59:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cq].[Store](
	[StoreId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[Difficulty] [int] NOT NULL,
 CONSTRAINT [PK_StoreId] PRIMARY KEY CLUSTERED 
(
	[StoreId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [cq].[Store_Equipment]    Script Date: 5/26/2019 6:59:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cq].[Store_Equipment](
	[Store_EquipmentId] [int] IDENTITY(1,1) NOT NULL,
	[StoreId] [int] NOT NULL,
	[EquipmentId] [int] NOT NULL,
 CONSTRAINT [PK_Store_Equipment] PRIMARY KEY CLUSTERED 
(
	[Store_EquipmentId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [cq].[Store_Flavor]    Script Date: 5/26/2019 6:59:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cq].[Store_Flavor](
	[Store_FlavorId] [int] IDENTITY(1,1) NOT NULL,
	[StoreId] [int] NOT NULL,
	[FlavorId] [int] NOT NULL,
	[Bonus] [int] NOT NULL,
 CONSTRAINT [PK_Store_Flavor] PRIMARY KEY CLUSTERED 
(
	[Store_FlavorId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [cq].[Account] ADD  DEFAULT ((0)) FOR [IsAdmin]
GO
ALTER TABLE [cq].[Equipment] ADD  DEFAULT ((1)) FOR [Modifier]
GO
ALTER TABLE [cq].[Equipment] ADD  DEFAULT ('Dungeon') FOR [Type]
GO
ALTER TABLE [cq].[Loot] ADD  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [cq].[Player] ADD  DEFAULT ((0)) FOR [Gold]
GO
ALTER TABLE [cq].[Store] ADD  DEFAULT ((1)) FOR [Difficulty]
GO
ALTER TABLE [cq].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Player] FOREIGN KEY([PlayerId])
REFERENCES [cq].[Player] ([PlayerId])
GO
ALTER TABLE [cq].[Account] CHECK CONSTRAINT [FK_Player]
GO
ALTER TABLE [cq].[Flavor_Loot]  WITH CHECK ADD  CONSTRAINT [FK_Flavor_Loot] FOREIGN KEY([FlavorId])
REFERENCES [cq].[Flavor] ([FlavorId])
GO
ALTER TABLE [cq].[Flavor_Loot] CHECK CONSTRAINT [FK_Flavor_Loot]
GO
ALTER TABLE [cq].[Flavor_Loot]  WITH CHECK ADD  CONSTRAINT [FK_Loot_Flavor] FOREIGN KEY([LootId])
REFERENCES [cq].[Loot] ([LootId])
GO
ALTER TABLE [cq].[Flavor_Loot] CHECK CONSTRAINT [FK_Loot_Flavor]
GO
ALTER TABLE [cq].[Location_Loot]  WITH CHECK ADD  CONSTRAINT [FK_Location_Loot] FOREIGN KEY([LocationId])
REFERENCES [cq].[Location] ([LocationId])
GO
ALTER TABLE [cq].[Location_Loot] CHECK CONSTRAINT [FK_Location_Loot]
GO
ALTER TABLE [cq].[Location_Loot]  WITH CHECK ADD  CONSTRAINT [FK_Loot_Location] FOREIGN KEY([LootId])
REFERENCES [cq].[Loot] ([LootId])
GO
ALTER TABLE [cq].[Location_Loot] CHECK CONSTRAINT [FK_Loot_Location]
GO
ALTER TABLE [cq].[Player_Equipment]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentId_PlayerId] FOREIGN KEY([EquipmentId])
REFERENCES [cq].[Equipment] ([EquipmentId])
GO
ALTER TABLE [cq].[Player_Equipment] CHECK CONSTRAINT [FK_EquipmentId_PlayerId]
GO
ALTER TABLE [cq].[Player_Equipment]  WITH CHECK ADD  CONSTRAINT [FK_PlayerId_EquipmentId] FOREIGN KEY([PlayerId])
REFERENCES [cq].[Player] ([PlayerId])
GO
ALTER TABLE [cq].[Player_Equipment] CHECK CONSTRAINT [FK_PlayerId_EquipmentId]
GO
ALTER TABLE [cq].[Player_Location]  WITH CHECK ADD  CONSTRAINT [FK_Location_Player] FOREIGN KEY([LocationId])
REFERENCES [cq].[Location] ([LocationId])
GO
ALTER TABLE [cq].[Player_Location] CHECK CONSTRAINT [FK_Location_Player]
GO
ALTER TABLE [cq].[Player_Location]  WITH CHECK ADD  CONSTRAINT [FK_Player_Location] FOREIGN KEY([PlayerId])
REFERENCES [cq].[Player] ([PlayerId])
GO
ALTER TABLE [cq].[Player_Location] CHECK CONSTRAINT [FK_Player_Location]
GO
ALTER TABLE [cq].[Player_Loot]  WITH CHECK ADD  CONSTRAINT [FK_Loot_Player] FOREIGN KEY([LootId])
REFERENCES [cq].[Loot] ([LootId])
GO
ALTER TABLE [cq].[Player_Loot] CHECK CONSTRAINT [FK_Loot_Player]
GO
ALTER TABLE [cq].[Player_Loot]  WITH CHECK ADD  CONSTRAINT [FK_Player_Loot] FOREIGN KEY([PlayerId])
REFERENCES [cq].[Player] ([PlayerId])
GO
ALTER TABLE [cq].[Player_Loot] CHECK CONSTRAINT [FK_Player_Loot]
GO
ALTER TABLE [cq].[Recipe_Loot]  WITH CHECK ADD  CONSTRAINT [FK_Loot_Recipe] FOREIGN KEY([LootId])
REFERENCES [cq].[Loot] ([LootId])
GO
ALTER TABLE [cq].[Recipe_Loot] CHECK CONSTRAINT [FK_Loot_Recipe]
GO
ALTER TABLE [cq].[Recipe_Loot]  WITH CHECK ADD  CONSTRAINT [FK_Recipe_Loot] FOREIGN KEY([RecipeId])
REFERENCES [cq].[Recipe] ([RecipeId])
GO
ALTER TABLE [cq].[Recipe_Loot] CHECK CONSTRAINT [FK_Recipe_Loot]
GO
ALTER TABLE [cq].[Store_Equipment]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentId_Store] FOREIGN KEY([EquipmentId])
REFERENCES [cq].[Equipment] ([EquipmentId])
GO
ALTER TABLE [cq].[Store_Equipment] CHECK CONSTRAINT [FK_EquipmentId_Store]
GO
ALTER TABLE [cq].[Store_Equipment]  WITH CHECK ADD  CONSTRAINT [FK_Store_Equipment] FOREIGN KEY([StoreId])
REFERENCES [cq].[Store] ([StoreId])
GO
ALTER TABLE [cq].[Store_Equipment] CHECK CONSTRAINT [FK_Store_Equipment]
GO
ALTER TABLE [cq].[Store_Flavor]  WITH CHECK ADD  CONSTRAINT [FK_Flavor_Store] FOREIGN KEY([FlavorId])
REFERENCES [cq].[Flavor] ([FlavorId])
GO
ALTER TABLE [cq].[Store_Flavor] CHECK CONSTRAINT [FK_Flavor_Store]
GO
ALTER TABLE [cq].[Store_Flavor]  WITH CHECK ADD  CONSTRAINT [FK_Store_Flavor] FOREIGN KEY([StoreId])
REFERENCES [cq].[Store] ([StoreId])
GO
ALTER TABLE [cq].[Store_Flavor] CHECK CONSTRAINT [FK_Store_Flavor]
GO
ALTER TABLE [cq].[Equipment]  WITH CHECK ADD CHECK  (([Difficulty]>=(1) AND [Difficulty]<=(9)))
GO
ALTER TABLE [cq].[Location]  WITH CHECK ADD CHECK  (([Difficulty]>=(1) AND [Difficulty]<=(9)))
GO
ALTER TABLE [cq].[Store]  WITH CHECK ADD CHECK  (([Difficulty]>=(1) AND [Difficulty]<=(9)))
GO

INSERT INTO cq.Player(Name, Gold) 
VALUES
('Paul',100000),
('Sadiki',500),
('Justin',0),
('Batman',0);

INSERT INTO cq.Account
(Username,Password,PlayerId)
VALUES
('pauls_awesome@hotmail.com','password', 1),
('paul_grimes8@hotmail.com','password', 2),
('Justin','password', 3),
('Batman','password', 4);



INSERT INTO cq.Equipment
(Modifier,Name,Price,Type,Difficulty)
Values
(1,'Spoon',10,'Cooking',1),
(2,'Knife',100,'Cooking',2),
(3,'Chef Hat', 500, 'Cooking', 3),
(4,'Stove', 2500, 'Cooking',4),
(5,'Fridge',10000, 'Cooking', 5),
(1,'Trowel',10,'Dungeon',1),
(2,'Spade',100,'Dungeon',2),
(3,'Hard Hat', 500, 'Dungeon',3),
(4,'Lawn Mower', 2500, 'Dungeon', 4),
(5,'Chain Saw', 10000, 'Dungeon',5),
(1,' Bronze Pass',10 , 'Voucher',1 ),
(2,' Silver Pass',100 , 'Voucher',2 ),
(3,' Gold Pass',500 , 'Voucher',3 ),
(4,' Platinum Pass',2500 , 'Voucher',4 ),
(5,' Diamond Pass',10000 , 'Voucher',5 ),
(6,' God Pass',50000 , 'Voucher',6 );



INSERT INTO cq.Location
(Name,Difficulty,Description)
Values
('Brinewater Grotto', 1, 'Avoid the Frostbite Spiders. Bitter foods common here.'),
('Ravenscar Hollow', 2, 'Home of the mighty Cave Trolls. Known for its cave salt.'),
('Azeroth', 3, 'It is a Warzone... Better Move Quickly. Chance for an Epic Fruit'), 
('Bearzone', 4, 'Endless bear vortex. High number of unami drops.'),
('Flavortown', 5, 'Home of the Flavor Gods. All flavors common here.');
INSERT INTO cq.Loot
(Name,Price,Description)
Values
('Apple',1,'A Simple Apple'),
('Blueberries',10,'Zesty and Fun'),
('Sugarcane', 50, 'Chewy & Sweet'),
('Bell Pepper', 1, 'Mildly spicy'),
('Japaleño Pepper', 10, 'Pretty spicy'),
('Habanero Pepper', 50, 'Flaming breath levels of spicy'),
('Rock salt',50,'An honest day''s wages.'),
('Orange',1,'Citrus Blast'),
('Cranberries',10,'More Sour Than Sweet'),
('Pickle',50, 'A Cucumber, Irrevocably Tainted'),
('Coffee Beans',1,'Who Needs Sleep?'),
('Kale',10,'Gotta Get Healthy.'),
('Arugula',50, 'Twice As Healthy As Kale, & Twice As Bitter.'),
('Mushrooms',1,'The Fungus Among Us'),
('Dried Meat',10,'Portable, If Not Delicious.'),
('Steak',50, 'Worth Killing a Cow Over.'),
('Epic Fruit', 100, 'It is as Large as it is Tasty');

INSERT INTO cq.Recipe
(Name,Description)
Values
('Sweet Combo', 'A Tasty Snack'),
('Salted Snack', 'Everything is better with Salt'),
('Spicy Treat', 'It will burn your taste buds off');

INSERT INTO cq.Flavor
(Name,Description)
Values
('Sweet','Sweet to the taste. Good for desserts and candies.'),
('Spicy','The hotter the better. Best found in peppers.'),
('Sour','Mouth-puckering goodness. Mostly fruits, but also vinegar.'),
('Bitter', 'When your tongue needs a challenge. Coffee, olives and the like'),
('Unami', 'The ultimate in savory. Key for meat dishes.');

INSERT INTO cq.Store
(Name,Description, Difficulty)
Values
('Walmarket','The Market of Commoners. They''ll take anything.',1),
('Blackmarket','The Market of Thieves. Fond of spices.',2),
('Highmarket','The Market of Kings. Nobility craves delicate, sweet things.',3),
('Bookmarket','The Market of Mages. Bitter food improves their magic.',4),
('Faemarket','The Market of Pixies. Sour amuses them.',5),
('Bloodmarket','The Market of Hunters. Only umani can satisfy them.',6);

INSERT INTO cq.Player_Equipment
(PlayerId,EquipmentId)
Values
(1,1),
(1,2),
(1,3),
(1,4),
(1,5),
(1,6),
(1,7),
(1,8),
(1,9),
(1,10),
(1,11),
(1,12),
(1,13),
(1,14),
(1,15),
(1,16),
(2,1),
(2,2),
(2,6),
(2,7),
(2,11),
(2,12),
(3,1),
(3,6),
(3,11),
(3,1),
(3,6),
(3,11);

INSERT INTO cq.Player_Location
(PlayerId,LocationId)
Values
(1,1),
(1,2),
(1,3),
(1,4),
(1,5),
(2,1),
(2,2),
(3,1),
(3,2);

INSERT INTO cq.Player_Loot
(PlayerId,LootId,Quantity)
Values
(1,1,10),
(1,2,5),
(1,3,1),
(1,4,100),
(1,5,2),
(1,6,3),
(1,7,8),
(1,8,20),
(1,9,21),
(1,10,5),
(1,17,10),
(2,1,3),
(2,2,5),
(3,1,1),
(4,2,1);

INSERT INTO cq.Store_Equipment
(StoreId,EquipmentId)
Values
(1,1),
(1,6),
(1,11),
(2,2),
(2,7),
(2,12),
(3,3),
(3,8),
(3,13),
(4,4),
(4,9),
(4,14),
(5,5),
(5,10),
(5,15);

INSERT INTO cq.Location_Loot
(LocationId,LootId,DropRate)
Values
(1,11,80),
(1,14,80),
(1,9,10),
(2,7,30),
(2,1,30),
(2,3,30),
(2,14,30),
(3,17,10),
(3,1,30),
(3,2,30),
(3,8,30),
(3,9,30),
(4,15,30),
(4,16,30),
(4,12,30),
(4,15,30),
(5,1,80),
(5,2,80),
(5,3,80),
(5,4,80),
(5,5,80),
(5,6,80),
(5,7,80),
(5,8,80),
(5,9,80),
(5,10,80),
(5,11,80),
(5,12,80),
(5,13,80),
(5,14,80),
(5,15,80),
(5,16,80),
(5,17,80);

INSERT INTO cq.Recipe_Loot
(RecipeId, LootId)
Values
(1,1),
(1,2),
(2,7),
(2,14),
(3,15),
(3,16);


INSERT INTO cq.Flavor_Loot
(FlavorId,LootId)
Values
(1,1),
(1,2),
(1,3),
(2,4),
(2,5),
(2,6),
(3,7),
(3,8),
(3,9),
(4,10),
(4,11),
(4,12),
(5,13),
(5,14),
(5,15),
(5,16),
(5,17);

INSERT INTO cq.Store_Flavor
(StoreId, FlavorId, Bonus)
Values
(1,1,2),
(1,2,2),
(1,3,2),
(1,4,2),
(1,5,2),
(2,1,2),
(2,2,4),
(2,3,2),
(2,4,2),
(2,5,3),
(3,1,4),
(3,2,1),
(3,3,2),
(3,4,2),
(3,5,2),
(4,1,2),
(4,2,2),
(4,3,2),
(4,4,4),
(4,5,2),
(5,1,2),
(5,2,2),
(5,3,4),
(5,4,2),
(5,5,2),
(6,1,2),
(6,2,2),
(6,3,2),
(6,4,2),
(6,5,4);
