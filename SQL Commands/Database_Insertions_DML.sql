INSERT INTO cq.Player(Name, Gold) 
VALUES
('Paul',100000),
('Sadiki',500),
('Justin',0),
('Batman',0);

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
(1,11,10),
(1,14,10),
(1,9,1),
(2,7,3),
(2,1,3),
(2,3,3),
(2,14,3),
(3,17,1),
(3,1,3),
(3,2,3),
(3,8,3),
(3,9,3),
(4,15,3),
(4,16,3),
(4,12,3),
(4,15,3),
(5,1,10),
(5,2,10),
(5,3,10),
(5,4,10),
(5,5,10),
(5,6,10),
(5,7,10),
(5,8,10),
(5,9,10),
(5,10,10),
(5,11,10),
(5,12,10),
(5,13,10),
(5,14,10),
(5,15,10),
(5,16,10),
(5,17,10);

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