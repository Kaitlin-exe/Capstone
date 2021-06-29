-- --------------------------------------------------------------------------------
-- Name: Reciplease Database
-- Class: CPDM-290
-- --------------------------------------------------------------------------------

-- --------------------------------------------------------------------------------
-- Options
-- --------------------------------------------------------------------------------
USE [CPDM-GroupA];   -- Get out of the master database
SET NOCOUNT ON;		-- Report only errors
-- --------------------------------------------------------------------------------
-- Drop Tables
-- --------------------------------------------------------------------------------
IF OBJECT_ID('TUserFavorites')					IS NOT NULL DROP TABLE TUserFavorites
IF OBJECT_ID('TRecipeIngredientShoppingLists')	IS NOT NULL DROP TABLE TRecipeIngredientShoppingLists
IF OBJECT_ID('TRecipeIngredients')				IS NOT NULL DROP TABLE TRecipeIngredients
IF OBJECT_ID('TRatings')						IS NOT NULL DROP TABLE TRatings
IF OBJECT_ID('TLast10')							IS NOT NULL DROP TABLE TLast10
IF OBJECT_ID('TRecipes')						IS NOT NULL DROP TABLE TRecipes
IF OBJECT_ID('TUsers')							IS NOT NULL DROP TABLE TUsers
IF OBJECT_ID('TShoppingList')					IS NOT NULL DROP TABLE TShoppingList
IF OBJECT_ID('TTaste')							IS NOT NULL DROP TABLE TTaste
IF OBJECT_ID('TDifficulty')						IS NOT NULL DROP TABLE TDifficulty
IF OBJECT_ID('TIngredients')					IS NOT NULL DROP TABLE TIngredients

-- --------------------------------------------------------------------------------
-- Step #1: Create Tables
-- --------------------------------------------------------------------------------
CREATE TABLE TUsers
(
	 intUserID			INTEGER	IDENTITY	NOT NULL
	,strFirstName		VARCHAR(50)			NOT NULL
	,strLastName		VARCHAR(50)			NOT NULL 
	,strEmail			VARCHAR(50)			NOT NULL
	,strPassword		VARCHAR(50)			NOT NULL
	,strUserName		VARCHAR(50)			NOT NULL
	,intShoppingListID	INTEGER				NULL
	,CONSTRAINT TUsers_PK PRIMARY KEY ( intUserID )
)

CREATE TABLE TRecipes
(
	 intRecipeID		INTEGER	  IDENTITY	NOT NULL
	,strName			VARCHAR(50)			NOT NULL
	,strDescription		VARCHAR(300)		NOT NULL
	,strInstructions	VARCHAR(3000)		NOT NULL
	,intUserID			INTEGER				NULL
	,CONSTRAINT TRecipes_PK PRIMARY KEY ( intRecipeID )
)

CREATE TABLE TRecipeIngredients
(
	 intRecipeIngredientID	INTEGER IDENTITY	NOT NULL
	,intRecipeID			INTEGER				NOT NULL
	,intIngredientID		INTEGER				NOT NULL
	,intIngredientQuantity	INTEGER				NOT NULL
	,CONSTRAINT RecipeIngredient_UQ UNIQUE ( intRecipeID, intIngredientID )
	,CONSTRAINT TRecipeIngredients_PK PRIMARY KEY ( intRecipeIngredientID )
)

CREATE TABLE TIngredients
(
	 intIngredientID	INTEGER				NOT NULL
	,strName			VARCHAR(50)			NOT NULL
	,CONSTRAINT TIngredients_PK PRIMARY KEY ( intIngredientID )
)

CREATE TABLE TRecipeIngredientShoppingLists
(
	 intRecipeIngredientShoppingListID		INTEGER IDENTITY	NOT NULL
	,intRecipeIngredientID					INTEGER				NOT NULL
	,intShoppingListID						INTEGER				NOT NULL
	,CONSTRAINT TRecipeIngredientShoppingLists_PK PRIMARY KEY ( intRecipeIngredientShoppingListID )
)

CREATE TABLE TShoppingList
(
	 intShoppingListID	INTEGER			NOT NULL
	,CONSTRAINT TShoppingList_PK PRIMARY KEY ( intShoppingListID )
)

CREATE TABLE TUserFavorites
(
	 intUserFavoriteID	INTEGER IDENTITY	NOT NULL
	,intUserID			INTEGER				NOT NULL
	,intRecipeID		INTEGER				NOT NULL
	,CONSTRAINT UserID_RecipeID_UQ UNIQUE ( intUserID, intRecipeID )
	,CONSTRAINT TUserFavorites_PK PRIMARY KEY ( intUserFavoriteID )
)

CREATE TABLE TRatings
(
	 intRatingID		INTEGER				NOT NULL
	,intUserID			INTEGER				NOT NULL
	,intDifficultyID	INTEGER				NOT NULL
	,intTasteID			INTEGER				NOT NULL
	,intRecipeID		INTEGER				NOT NULL
	,CONSTRAINT RecipeUser_UQ UNIQUE ( intRecipeID, intUserID )
	,CONSTRAINT TRatings_PK PRIMARY KEY ( intRatingID )
)

CREATE TABLE TTaste
(
	 intTasteID			INTEGER	IDENTITY	NOT NULL
	,intTasteRating		INTEGER				NOT NULL
	,CONSTRAINT TTaste_PK PRIMARY KEY ( intTasteID )
)

CREATE TABLE TDifficulty
(
	 intDifficultyID		INTEGER	IDENTITY NOT NULL
	,intDifficultyRating	INTEGER			 NOT NULL
	,CONSTRAINT TDifficulty_PK PRIMARY KEY ( intDifficultyID )
)

CREATE TABLE TLast10
(
	 intLast10ID			INTEGER				NOT NULL
	,intUserID				INTEGER				NOT NULL
	,intRecipeID			INTEGER				NOT NULL
	,CONSTRAINT TLast10_PK PRIMARY KEY ( intLast10ID )
)

-- --------------------------------------------------------------------------------
-- Step #2: Identify and Create Foreign Keys
-- --------------------------------------------------------------------------------
--
-- #	Child								Parent						Column(s)
-- -	-----								------						---------
-- 1	TUserFavorites						TUsers						intUserID
-- 2	TUserFavorites						TRecipes					intRecipeID
-- 5	TRecipeIngredientsShoppingLists		TRecipeIngredients			intRecipeIngredientsID			
-- 6	TRecipeIngredientsShoppingLists		TShoppingList				intShoppingListID
-- 3	TRecipeIngredients					TRecipes					intRecipeID
-- 4	TRecipeIngredients					TIngredients				intIngredientID
-- 7	TRatings							TTaste						intTasteID						
-- 8	TRatings							TDifficulty					intDifficultyID
-- 9	TRatings							TUsers						intUserID
-- 10	TRatings							TRecipe						intRecipeID
-- 11	TUsers								TShoppingList				intShoppingListID
-- 12	TLast10								TUsers						intUserID
-- 13	TRecipes							TUsers						intUserID
-- 14	TLast10								TRecipes					intRecipeID



---- 1
ALTER TABLE TUserFavorites ADD CONSTRAINT TUserFavorites_TUsers_FK
FOREIGN KEY ( intUserID ) REFERENCES TUsers ( intUserID )

-- 2
ALTER TABLE TUserFavorites ADD CONSTRAINT TUserFavorites_TRecipes_FK
FOREIGN KEY ( intRecipeID ) REFERENCES TRecipes ( intRecipeID )

-- 5
ALTER TABLE TRecipeIngredientShoppingLists ADD CONSTRAINT TRecipeIngredientsShoppingLists_TRecipeIngredients_FK
FOREIGN KEY ( intRecipeIngredientID ) REFERENCES TRecipeIngredients ( intRecipeIngredientID )

-- 6
ALTER TABLE TRecipeIngredientShoppingLists ADD CONSTRAINT TRecipeIngredientsShoppingLists_TShoppingList_FK
FOREIGN KEY ( intShoppingListID ) REFERENCES TShoppingList ( intShoppingListID )

-- 3
ALTER TABLE TRecipeIngredients ADD CONSTRAINT TRecipeIngredients_TRecipes_FK
FOREIGN KEY ( intRecipeID ) REFERENCES TRecipes ( intRecipeID )

-- 4
ALTER TABLE TRecipeIngredients ADD CONSTRAINT TRecipeIngredients_TIngredients_FK
FOREIGN KEY ( intIngredientID ) REFERENCES TIngredients ( intIngredientID )

-- 7
ALTER TABLE TRatings ADD CONSTRAINT TRatings_TTaste_FK
FOREIGN KEY ( intTasteID ) REFERENCES TTaste ( intTasteID )

-- 8
ALTER TABLE TRatings ADD CONSTRAINT TRatings_TDifficulty_FK
FOREIGN KEY ( intDifficultyID ) REFERENCES TDifficulty ( intDifficultyID )

-- 9
ALTER TABLE TRatings ADD CONSTRAINT TRatings_TUsers_FK
FOREIGN KEY ( intUserID ) REFERENCES TUsers ( intUserID )

-- 10
ALTER TABLE TRatings ADD CONSTRAINT TRatings_TRecipe_FK
FOREIGN KEY ( intRecipeID ) REFERENCES TRecipes ( intRecipeID )

-- 11
ALTER TABLE TUsers ADD CONSTRAINT TUsers_TShoppingList_FK
FOREIGN KEY ( intShoppingListID ) REFERENCES TShoppingList ( intShoppingListID )

-- 12
ALTER TABLE TLast10 ADD CONSTRAINT TLast10_TUsers_FK
FOREIGN KEY ( intUserID ) REFERENCES TUsers ( intUserID )

-- 13
ALTER TABLE TUsers ADD CONSTRAINT TRecipes_TUsers_FK
FOREIGN KEY ( intUserID ) REFERENCES TUsers ( intUserID )

-- 14
ALTER TABLE TLast10 ADD CONSTRAINT TLast10_TRecipes_FK
FOREIGN KEY ( intRecipeID ) REFERENCES TRecipes ( intRecipeID )

-- 15
ALTER TABLE TUsers ALTER COLUMN intShoppingListID INTEGER NULL

 --------------------------------------------------------------------------------
 --Step #3: INSERT INTO TABLES
 --------------------------------------------------------------------------------

 INSERT INTO TShoppingList ( intShoppingListID )
VALUES						 (1)
							,(2)
							,(3)
							,(4)
							,(5)

 INSERT INTO TDifficulty ( intDifficultyRating )
 VALUES					 (1)
						,(2)
						,(3)
						,(4)
						,(5)

 INSERT INTO TTaste ( intTasteRating )
 VALUES					 (1)
						,(2)
						,(3)
						,(4)
						,(5)

 INSERT INTO TUsers		(strFirstName, strLastName, strEmail, strPassword, strUserName, intShoppingListID)
 VALUES					 ('Isaak', 'Galle', 'isaakgalle@gmail.com', 'reciplease1', 'Falcawn', 1)
						,('Brandon', 'Wernke', 'brandon.wernke@gmail.com', 'reciplease2', 'Brawer', 2)
						,('Kaitlin', 'Cordell', 'Kaitlin.cordell@gmail.com', 'reciplease3', 'asapneko', 3)
						,('Omonigho', 'Odairi', 'obodairi@cincinnatistate.edu', 'reciplease4', 'Omoh', 4)

INSERT INTO TRecipes	(strName, strDescription, strInstructions, intUserID)
VALUES					 ('Rosemary Garlic Butter Steak', 'Ribeye Steak pan seared in a cast iron with butter allowing the rosemary and garlic to infuse into the butter and steak itself.'
							, 'Step 1: Let steak rest to room temperature and pat dry before cooking to get a proper sear. Allow pan to get hot at a Medium High - High heat. Sear each side including the "rim" of the steak, about 2-3mins a side until golden brown.
							   Step 2; Once the steak is seared reduce heat to Medium - Medium High add butter to the pan and let it melt. Once the butter has melted put in 2-3 "sticks" of rosemary and 3-4 garlic cloves quartered or halved in the butter. Cook the steak an additional 3 - 5 minutes depending on how rare youd like it, while cooking spoon the melted butter over the steak.
							   Step 3; Enjoy :)', 1 )
						,('Recipe Test 2', 'Recipe Test 2 Desc', 'Recipe Test 2 Instructions', 1)
						,('Recipe Test 3', 'Recipe Test 3 Desc', 'Recipe Test 3 Instructions', 3)
						,('Recipe Test 4', 'Recipe Test 4 Desc', 'Recipe Test 4 Instructions', 4)

 INSERT INTO TRatings		(intRatingID, intUserID, intDifficultyID, intTasteID, intRecipeID)
 VALUES					 (1, 1, 1, 5, 1)
						,(2, 2, 2, 3, 2)
						,(3, 3, 5, 2, 1)
						,(4, 1, 5, 5, 2)

 INSERT INTO TUserFavorites( intUserID, intRecipeID )
 VALUES					 (2, 2)
						,(2, 1)
						,(3, 1)
						,(4, 3)
						,(4, 1)
						,(3, 2)
						,(3, 3)

INSERT INTO TIngredients ( intIngredientID, strName )
VALUES					 (1, 'Sweet White Onion' )
						,(2, 'Red Onion')
						,(3, 'Chicken Breast Bone-In')
						,(4, 'Chicken Breast Boneless')
						,(5, 'Chicken Thigh')
						,(6, 'Ribeye')
						,(7, 'Cabbage')
						,(8, 'Butter')
						,(9, 'Salt')
						,(10, 'Peper')
						,(11, 'Garlic Clove')
						,(12, 'Rosemary')
						,(13, 'Potatoe')
						,(14, 'Celery')
						,(15, 'Red-Snapper')
						,(16, 'Lemon')
						,(17, 'All-Spice')

 INSERT INTO TRecipeIngredients (intRecipeID, intIngredientID, intIngredientQuantity )
 VALUES					 (1, 6, 1)
						,(1, 8, 1)
						,(1, 9, 1)
						,(1, 10, 1)
						,(1, 11, 3)
						,(1, 12, 3)
						,(2, 3, 2)
						,(2, 9, 1)
						,(2, 10, 1)
						,(2, 8, 1)

INSERT INTO TRecipeIngredientShoppingLists( intRecipeIngredientID, intShoppingListID )
 VALUES					 (1, 1)
						,(2, 1)
						,(3, 1)
						,(4, 1)
						,(5, 1)
						,(6, 1)

