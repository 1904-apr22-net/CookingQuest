INSERT INTO cq.Player(Name) 
VALUES
('Paul'),
('Sadiki'),
('Justin'),
('Batman');

INSERT INTO cq.Account
(Username,Password,PlayerId)
VALUES
('Paul','password', 1),
('Sadiki','password', 2),
('Justin','password', 3),
('Batman','password', 4);

INSERT INTO cq.Equipment
(Modifier,Name,Price,Type,Difficulty)
Values
(1,'Spoon',10,'Cooking',1),
(2,'Knife',100,'Cooking',2),
(1,'Trowel',10,'Dungeon',1),
(2,'Spade',100,'Dungeon',2);

INSERT INTO cq.Location
(Name,Difficulty,Description)
Values
('Brinewater Grotto', 1, 'Avoid the Frostbite Spiders'),
('Ravenscar Hollow', 2, 'Home of the mighty Cave Trolls');

INSERT INTO cq.Loot
(Name,Price,Description)
Values
('Apple',1,'A Simple Apple'),
('Orange',2,'Unleash the Power'),
('Cranberries',5,'Needs Sugar'),
('Blueberry',10,'Zesty and Fun'),
('Salt',50,'Makes everything better');

INSERT INTO cq.Recipe
(Name,Description)
Values
('Fruit Combo', 'A Tasty Snack'),
('Salted Snack', 'Everything is better with Salt');

INSERT INTO cq.Flavor
(Name,Description)
Values
('Sweet','Sweet to the taste. Good for desserts and candies.'),
('Salty','Good old sodium. Used well with meat dishes.'),
('Sour','Mouth-puckering goodness. Citrus fruits and vinegar'),
('Bitter', 'When your tongue needs a challenge. Coffee, olives and the like'),
('Unami', 'The ultimate in savory. Key for meat dishes.');

INSERT INTO cq.Store
(Name,Description)
Values
('Walmart','They are cheap, but they always buy'),
('Blackmarket','Darkest and the Dankest');

INSERT INTO cq.Player_Equipment
(PlayerId,EquipmentId)
Values
(1,3),
(1,4),
(1,5),
(1,6),
(2,3),
(2,5);

INSERT INTO cq.Player_Location
(PlayerId,LocationId)
Values
(1,1),
(1,2),
(2,1);

INSERT INTO cq.Player_Loot
(PlayerId,LootId,Quantity)
Values
(1,1,10),
(1,2,5),
(1,5,10);

INSERT INTO cq.Store_Equipment
(StoreId,EquipmentId)
Values
(1,3),
(1,5),
(2,4),
(2,6);

INSERT INTO cq.Location_Loot
(LocationId,LootId,DropRate)
Values
(1,1,3),
(1,2,2),
(1,3,1),
(2,1,5),
(2,2,4),
(2,3,3),
(2,4,2),
(2,5,1);

INSERT INTO cq.Recipe_Loot
(RecipeId, LootId)
Values
(1,2),
(1,3),
(2,5),
(2,4);

INSERT INTO cq.Flavor_Loot
(FlavorId,LootId)
Values
(1,1),
(1,2),
(1,3),
(1,4),
(2,5);

INSERT INTO cq.Store_Flavor
(StoreId, FlavorId, Bonus)
Values
(1,1,2),
(2,2,2);