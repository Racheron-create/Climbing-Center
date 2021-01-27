CREATE TABLE Centres(
	centreID INT IDENTITY NOT NULL PRIMARY KEY,
	centreName VARCHAR(50),
	centreType VARCHAR(50),
	numOfCustomers INT,
	numOfRoutes INT
);
INSERT INTO Centres(centreName, centreType, numOfCustomers, numOfRoutes) VALUES('Depot', 'Boulder', 20, 50);
SELECT * FROM Centres;

CREATE TABLE CentrePass(
	centerID INT NOT NULL PRIMARY KEY FOREIGN KEY REFERENCES Centres(centreID),
	accountPass varbinary(50)
);

CREATE TABLE CircuitRoutes(
	routeNumber INT NOT NULL PRIMARY KEY,
	colour varchar(50),
	centerNumber INT NOT NULL FOREIGN KEY REFERENCES Centres(centreID),
	technical varchar(50) NULL,
	grade varchar(50) 
);

CREATE TABLE Circuit(
	colour VARCHAR(50) PRIMARY KEY,
	centerNumber INT NOT NULL FOREIGN KEY REFERENCES Centres(centreID),
	routeNUmber INT FOREIGN KEY REFERENCES CircuitRoutes(routeNumber)
);


CREATE TABLE Customer(
    centerNumber INT NOT NULL FOREIGN KEY REFERENCES Centres(centreID),
    accountID INT NOT NULL PRIMARY KEY,
	IsStudent BIT,
	customerName VARCHAR(50)
); 

CREATE TABLE Account(
	accountID INT NOT NULL FOREIGN KEY REFERENCES Customer(accountID),
	username VARCHAR(50) NOT NULL PRIMARY KEY,
	firstName VARCHAR(50),
	lastName VARCHAR(50),
	DOB DATE NULL,
	email VARCHAR(50),
	IsStudent BIT,
	sessionNumber INT
);

CREATE TABLE AccountPass(
	accountID INT NOT NULL,
	username VARCHAR(50) FOREIGN KEY REFERENCES Account(username),
	accountPass varbinary(50)
);

CREATE TABLE LeaderBoard(
	centerNumber INT NOT NULL FOREIGN KEY REFERENCES Centres(centreID),
	accountID INT NOT NULL FOREIGN KEY REFERENCES Customer(accountID),
	username varchar(50) FOREIGN KEY REFERENCES Account(username),
	points int,
	duration time(7)
)