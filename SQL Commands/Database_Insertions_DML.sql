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
('Brinewater Grotto', 1, 'Avoid the Frostbite Spiders. Bitter foods common here.'),
('Ravenscar Hollow', 2, 'Home of the mighty Cave Trolls. Known for its cave salt.'),
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
('Steak',50, 'Worth Killing a Cow Over.');

INSERT INTO cq.Recipe
(Name,Description)
Values
('Fruit Combo', 'A Tasty Snack'),
('Salted Snack', 'Everything is better with Salt');

INSERT INTO cq.Flavor
(Name,Description)
Values
('Sweet','Sweet to the taste. Good for desserts and candies.'),
('Spicy','The hotter the better. Best found in peppers.'),
('Sour','Mouth-puckering goodness. Mostly fruits, but also vinegar.'),
('Bitter', 'When your tongue needs a challenge. Coffee, olives and the like'),
('Unami', 'The ultimate in savory. Key for meat dishes.');

INSERT INTO cq.Store
(Name,Description)
Values
('Walmarket','The Market of Commoners. They''ll take anything.'),
('Blackmarket','The Market of Thieves. Fond of spices.'),
('Highmarket','The Market of Kings. Nobility craves delicate, sweet things.'),
('Bookmarket','The Market of Mages. Bitter food improves their magic.'),
('Faemarket','The Market of Pixies. Sour amuses them.'),
('Bloodmarket','The Market of Hunters. Only umani can satisfy them.');

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
(5,15)
;

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