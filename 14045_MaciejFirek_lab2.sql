/* tworzenie bazy danych */ 
CREATE DATABASE SalonSamochodowy69
COLLATE Polish_100_CI_AS; 

/* tworzenie tabel */ 

	CREATE TABLE [dbo].[Klienci](
	[ID] [int] PRIMARY KEY IDENTITY,
	[Imie] [nvarchar] (50) NOT NULL,
	[Nazwisko] [nvarchar] (100) NOT NULL,
	[PESEL] [nvarchar] (20) NULL,
	[Email] [nvarchar] (250) NULL,
	[Telefon] [nvarchar] (20) NULL)
	

	CREATE TABLE [dbo].[Marka](
	[ID] [int] PRIMARY KEY IDENTITY,
	[nazwa] [nvarchar] (50) UNIQUE NOT NULL)

	CREATE TABLE [dbo].[Model](
	[ID] [int] PRIMARY KEY IDENTITY,
	[Model] [nvarchar] (500) NOT NULL,
	[MarkaID] [int] FOREIGN KEY REFERENCES Marka(ID),
	[cena] [money] NOT NULL,
	[KlientID] [int] FOREIGN KEY REFERENCES Klienci(ID))
	

	CREATE TABLE [dbo].[Statusy](
	[ID] [int] PRIMARY KEY IDENTITY,
	[Nazwa] [nvarchar] (250) UNIQUE NOT NULL)

	CREATE TABLE [dbo].[Rezerwacje](
	[ID] [int] PRIMARY KEY IDENTITY,
	[KlientID] [int] FOREIGN KEY REFERENCES Klienci(ID),
	[DataOdbioru] [datetime] NOT NULL,
	[StatusID] [int] FOREIGN KEY REFERENCES Statusy(ID))
	

	

	CREATE TABLE [dbo].[Dostawcy](
	[ID] [int] PRIMARY KEY IDENTITY,
	[Nazwa] [nvarchar] (500) NOT NULL,
	[MarkaID] [int] FOREIGN KEY REFERENCES Marka(ID),
	[NIP] [nvarchar] (20) NOT NULL,
	[KodPocztowy] [nvarchar] (20) NULL,
	[Miasto] [nvarchar] (250) NULL,
	[Adres] [nvarchar] (1000) NULL)

	

	CREATE TABLE [dbo].[Pracownicy](
	[ID] [int] PRIMARY KEY IDENTITY,
	[Imie] [nvarchar] (500) NOT NULL,
	[Nazwisko] [nvarchar] (20) NOT NULL,
	[Email] [nvarchar] (20) NULL,
	[telefon] [nvarchar] (250) NULL,
	[Adres] [nvarchar] (1000) NULL)

	CREATE TABLE [dbo].[Wyposazenie](
	[ID] [int] PRIMARY KEY IDENTITY,
	[Nazwa] [nvarchar] (1000) NULL,
	[NazwaID] [int] FOREIGN KEY REFERENCES Marka(ID),
	[Model] [nvarchar] (1000) NULL,
	[ModelID] [int] FOREIGN KEY REFERENCES Model(ID),
	[Rodzajwyposazenia] [nvarchar] (20) NULL)


/* DODAWANIE WARTOSCI DO TABEL */																																	
	INSERT INTO Statusy (Nazwa)
	VALUES  ('Wolny'),
			('Zajêty'),
			('Niepotwierdzona'),
			('Potwierdzona'),
			('Anulowana'),
			('Zrealizowana')

	INSERT INTO Klienci (Imie, Nazwisko, PESEL, Email, Telefon) 
	VALUES ('Barbara', 'Fibiana', '75092908342', 'barbara.fibiana@onet.pl', '884317743'),
		('Barbara', 'Gruda', '83110523423', 'barbara.gruda@gmail.com', '513518635'),
		('Jadwiga', 'Bilecka', '70101023456', 'jadwiga.bilecka@onet.pl', '884815648')

	INSERT INTO Marka(Nazwa)
	VALUES  ('Audi'), 
			('BMW'),
			('TOYOTA')
	
	INSERT INTO model
	VALUES('A5',1,'350000',1),
	('M5',2,'500000',2),
	('YARIS',3,'100000',3)
	
	
	INSERT INTO Rezerwacje(klientID,Dataodbioru,StatusID) VALUES  (1,'2022-02-25',4),
	(2,'2022-04-13',3),
	(3,'2022-01-14',6)

	INSERT INTO Dostawcy (nazwa,MarkaID,NIP,KodPocztowy,Miasto,Adres) VALUES ('Audi Select Plus',1,'5466549871','33-410','Krakow','ul. Zakopianska 169a'),
	('BMW M-Cars',2,'2662548871','33-410','Krakow','Gora libertowska'),
	('Toyota Dobrygowski Kraków Modlnica',3,'3253658541','33-410','Krakow','ul. Czestochowska 30')
	
	INSERT INTO Pracownicy(imie,nazwisko,email,telefon,adres) VALUES ('Jan','Kowalski','Kowalski@gmail.com','321654987','ul. D³uga 12'),
	('Kamil','Kromka','Kromka@gmail.com','654987485','ul. Krakowska 38'),
	('Krystian','Baton','Baton@gmail.com','842964587','ul. Zakopianska 64')

	INSERT INTO Wyposazenie (nazwa,nazwaID,Model,ModelID,Rodzajwyposazenia) VALUES ('Audi',1,'A5',1,'Normalny'),
	('BMW',2,'M5',2,'Bogaty'),
	('TOYOTA',3,'Yaris',3,'Ubogi')
	

			



	