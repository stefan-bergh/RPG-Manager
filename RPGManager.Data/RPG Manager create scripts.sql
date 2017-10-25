CREATE TABLE [dbo].[Logging] (
	[LoggingID]	INT	IDENTITY(1, 1) NOT NULL,
	[Table]	VARCHAR (30) NOT NULL,
    [Type]	VARCHAR (10) NOT NULL,
	PRIMARY KEY CLUSTERED ([LoggingID] ASC));

CREATE TABLE [dbo].[UserAccount] (
	[UserAccountID]	INT	IDENTITY(1, 1) NOT NULL,
	[Name]	VARCHAR (30) NOT NULL,
    [Password]	VARCHAR (200) NOT NULL,
	[Mail] VARCHAR (30) NOT NULL,
	[RefUserAccountID] INT NULL,
    PRIMARY KEY CLUSTERED ([UserAccountID] ASC),
	CONSTRAINT [FK_User_RefUserAccountID] FOREIGN KEY ([RefUserAccountID]) REFERENCES [dbo].[UserAccount] ([UserAccountID]));

CREATE TABLE [dbo].[Tools](
	[ToolsID]	INT	IDENTITY(1, 1) NOT NULL,
	[UserAccountID]	INT NOT NULL,
    [Name]	VARCHAR(50) NOT NULL,
    [Price]	INT NOT NULL,
    [Type]	INT NOT NULL,
    PRIMARY KEY CLUSTERED ([ToolsID] ASC),
	CONSTRAINT [FK_Tools_UserAccountID] FOREIGN KEY ([UserAccountID]) REFERENCES [dbo].[UserAccount] ([UserAccountID]));

CREATE TABLE [dbo].[Weapon] (
	[WeaponID]	INT	IDENTITY(1, 1) NOT NULL,
	[ToolsID]	INT NOT NULL,
    [Name]	VARCHAR(50) NOT NULL,
    [Price]	INT NOT NULL,
    [Type]	INT NOT NULL,
    [Damage]	INT NOT NULL,
	PRIMARY KEY CLUSTERED ([WeaponID] ASC),
	CONSTRAINT [FK_Weapon_ToolsID] FOREIGN KEY ([ToolsID]) REFERENCES [dbo].[Tools] ([ToolsID]));

CREATE TABLE [dbo].[Armor] (
	[ArmorID]	INT	IDENTITY(1, 1) NOT NULL,
	[ToolsID]	INT NOT NULL,
    [Defense]	INT NOT NULL,
	PRIMARY KEY CLUSTERED ([ArmorID] ASC),
	CONSTRAINT [FK_Armor_ToolsID] FOREIGN KEY ([ToolsID]) REFERENCES [dbo].[Tools] ([ToolsID]));

CREATE TABLE [dbo].[Item] (
	[ItemID]	INT	IDENTITY(1, 1) NOT NULL,
	[ToolsID]	INT NOT NULL,
    [Effect]	INT NOT NULL,
    [Repeat]	INT NOT NULL,
    PRIMARY KEY CLUSTERED ([ItemID] ASC),
	CONSTRAINT [FK_Item_ToolsID] FOREIGN KEY ([ToolsID]) REFERENCES [dbo].[Tools] ([ToolsID]));

CREATE TABLE [dbo].[Equipment] (
	[EquipmentID]	INT	IDENTITY(1, 1) NOT NULL,
	[UserAccountID]	INT NOT NULL,
    [Name]	VARCHAR(50) NOT NULL,
    [Defense]	INT NOT NULL,
    [Slot]	INT NOT NULL,
    [Type]	INT NOT NULL,
    PRIMARY KEY CLUSTERED ([EquipmentID] ASC),
	CONSTRAINT [FK_Equipment_UserAccountID] FOREIGN KEY ([UserAccountID]) REFERENCES [dbo].[UserAccount] ([UserAccountID]));

CREATE TABLE [dbo].[SkillType] (
	[SkillTypeID]	INT	IDENTITY(1, 1) NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
    PRIMARY KEY CLUSTERED ([SkillTypeID] ASC));

CREATE TABLE [dbo].[Skill] (
	[SkillID]	INT	IDENTITY(1, 1) NOT NULL,
	[UserAccountID]	INT NOT NULL,
	[SkillTypeID]	INT NOT NULL,
    [Type]	INT NOT NULL,
    [Description]	NVARCHAR(MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([SkillID] ASC),
	CONSTRAINT [FK_Skill_UserAccountID] FOREIGN KEY ([UserAccountID]) REFERENCES [dbo].[UserAccount] ([UserAccountID]),
	CONSTRAINT [FK_Skill_SkillTypeID] FOREIGN KEY ([SkillTypeID]) REFERENCES [dbo].[SkillType] ([SkillTypeID]));

CREATE TABLE [dbo].[Stat] (
	[StatID]	INT	IDENTITY(1, 1) NOT NULL,
	[UserAccountID]	INT NOT NULL,
	[Type] INT NOT NULL,
	[Description] NVARCHAR(MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([StatID] ASC),
	CONSTRAINT [FK_Stat_UserAccountID] FOREIGN KEY ([UserAccountID]) REFERENCES [dbo].[UserAccount] ([UserAccountID]));
	
CREATE TABLE [dbo].[ClassCategory] (
	[ClassCategoryID]	INT	IDENTITY(1, 1) NOT NULL,
	[Name]	VARCHAR(30) NOT NULL,
    PRIMARY KEY CLUSTERED ([ClassCategoryID] ASC));
	
CREATE TABLE [dbo].[Class] (
	[ClassID]	INT	IDENTITY(1, 1) NOT NULL,
	[UserAccountID]	INT NOT NULL,
	[ClassCategoryID]	INT	NOT NULL,
	[Name]	VARCHAR(30) NOT NULL,
	[StartingLevel] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([ClassID] ASC),
	CONSTRAINT [FK_Class_UserAccountID] FOREIGN KEY ([UserAccountID]) REFERENCES [dbo].[UserAccount] ([UserAccountID]),
	CONSTRAINT [FK_Class_ClassCategoryID] FOREIGN KEY ([ClassCategoryID]) REFERENCES [dbo].[ClassCategory] ([ClassCategoryID]));

CREATE TABLE [dbo].[Character] (
	[CharacterID]	INT	IDENTITY(1, 1) NOT NULL,
	[UserAccountID]	INT NOT NULL,
	[Name] VARCHAR(60) NOT NULL,
	[StartingLevel] INT NOT NULL,
    [ClassID] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([CharacterID] ASC),
	CONSTRAINT [FK_Character_UserAccountID] FOREIGN KEY ([UserAccountID]) REFERENCES [dbo].[UserAccount] ([UserAccountID]),
	CONSTRAINT [FK_Character_ClassID] FOREIGN KEY ([ClassID]) REFERENCES [dbo].[Class] ([ClassID]));
	
CREATE TABLE [dbo].[CharacterEquipment] (
	[CharacterEquipmentID]	INT	IDENTITY(1, 1) NOT NULL,
	[CharacterID]	INT NOT NULL,
	[EquipmentID] INT NOT NULL,
	PRIMARY KEY CLUSTERED ([CharacterEquipmentID] ASC),
	CONSTRAINT [FK_CharacterEquipment_CharacterID] FOREIGN KEY ([CharacterID]) REFERENCES [dbo].[Character] ([CharacterID]),
	CONSTRAINT [FK_CharacterEquipment_EquipmentID] FOREIGN KEY ([EquipmentID]) REFERENCES [dbo].[Equipment] ([EquipmentID]));
	
CREATE TABLE [dbo].[CharacterStat] (
	[CharacterStatID]	INT	IDENTITY(1, 1) NOT NULL,
	[StatID] INT NOT NULL,
	[CharacterID]	INT NOT NULL,
	[GrowthChance]	INT NOT NULL,
	PRIMARY KEY CLUSTERED ([CharacterStatID] ASC),
	CONSTRAINT [FK_CharacterStat_CharacterID] FOREIGN KEY ([CharacterID]) REFERENCES [dbo].[Character] ([CharacterID]),
	CONSTRAINT [FK_CharacterStat_StatID] FOREIGN KEY ([StatID]) REFERENCES [dbo].[Stat] ([StatID]));
	
CREATE TABLE [dbo].[CharacterSkill] (
	[CharacterSkillID]	INT	IDENTITY(1, 1) NOT NULL,
	[SkillID] INT NOT NULL,
	[CharacterID]	INT NOT NULL,
	[Level]	INT NOT NULL,
	PRIMARY KEY CLUSTERED ([CharacterSkillID] ASC),
	CONSTRAINT [FK_CharacterSkill_CharacterID] FOREIGN KEY ([CharacterID]) REFERENCES [dbo].[Character] ([CharacterID]),
	CONSTRAINT [FK_CharacterSkill_SkillID] FOREIGN KEY ([SkillID]) REFERENCES [dbo].[Skill] ([SkillID]));
	
CREATE TABLE [dbo].[ClassEquipment] (
	[ClassEquipmentID]	INT	IDENTITY(1, 1) NOT NULL,
	[ClassID]	INT NOT NULL,
	[EquipmentID] INT NOT NULL,
	PRIMARY KEY CLUSTERED ([ClassEquipmentID] ASC),
	CONSTRAINT [FK_ClassEquipment_ClassID] FOREIGN KEY ([ClassID]) REFERENCES [dbo].[Class] ([ClassID]),
	CONSTRAINT [FK_ClassEquipment_EquipmentID] FOREIGN KEY ([EquipmentID]) REFERENCES [dbo].[Equipment] ([EquipmentID]));
	
CREATE TABLE [dbo].[ClassStat] (
	[ClassStatID]	INT	IDENTITY(1, 1) NOT NULL,
	[StatID] INT NOT NULL,
	[ClassID]	INT NOT NULL,
	[GrowthChance]	INT NOT NULL,
	PRIMARY KEY CLUSTERED ([ClassStatID] ASC),
	CONSTRAINT [FK_ClassStat_ClassID] FOREIGN KEY ([ClassID]) REFERENCES [dbo].[Class] ([ClassID]),
	CONSTRAINT [FK_ClassStat_StatID] FOREIGN KEY ([StatID]) REFERENCES [dbo].[Stat] ([StatID]));
	
CREATE TABLE [dbo].[ClassSkill] (
	[ClassSkillID]	INT	IDENTITY(1, 1) NOT NULL,
	[SkillID] INT NOT NULL,
	[ClassID]	INT NOT NULL,
	[Level]	INT NOT NULL,
	PRIMARY KEY CLUSTERED ([ClassSkillID] ASC),
	CONSTRAINT [FK_ClassSkill_ClassID] FOREIGN KEY ([ClassID]) REFERENCES [dbo].[Class] ([ClassID]),
	CONSTRAINT [FK_ClassSkill_SkillID] FOREIGN KEY ([SkillID]) REFERENCES [dbo].[Skill] ([SkillID]));
	
