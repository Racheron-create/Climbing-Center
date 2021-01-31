CREATE TABLE Centres(
	centreID INT IDENTITY(1,1) NOT NULL,
	centreName VARCHAR(50),
	centreType VARCHAR(50),
	numOfCustomers INT,
	numOfRoutes INT
	PRIMARY KEY (centreID)
);

CREATE TABLE CentrePass(
	centreID INT NOT NULL FOREIGN KEY REFERENCES Centres(centreID),
	accountPass varbinary(50)
	PRIMARY KEY (centreID)
);

CREATE TABLE CircuitRoutes(
	routeNumber INT IDENTITY(1,1) NOT NULL,
	colour varchar(50),
	centreNumber INT NOT NULL FOREIGN KEY REFERENCES Centres(centreID),
	technical varchar(50) NULL,
	grade varchar(50) 
	PRIMARY KEY (routeNumber, centreNumber)
);

CREATE TABLE Circuit(
	colour VARCHAR(50) NOT NULL,
	centreNumber INT NOT NULL FOREIGN KEY REFERENCES Centres(centreID),
	routeNUmber INT NOT NULL FOREIGN KEY REFERENCES CircuitRoutes(routeNumber)
	PRIMARY KEY (colour, centreNumber, routeNumber)
);


CREATE TABLE Customer(
    centereNumber INT NOT NULL FOREIGN KEY REFERENCES Centres(centreID),
    accountID INT NOT NULL,
	IsStudent BIT,
	customerName VARCHAR(50)
	PRIMARY KEY (accountID, centreNumber)
); 

CREATE TABLE Account(
	accountID INT NOT NULL FOREIGN KEY REFERENCES Customer(accountID),
	username VARCHAR(50) NOT NULL,
	firstName VARCHAR(50),
	lastName VARCHAR(50),
	DOB DATE NULL,
	email VARCHAR(50),
	IsStudent BIT,
	sessionNumber INT
	PRIMARY KEY (accountID, username)
);

CREATE TABLE AccountPass(
	accountID INT NOT NULL FOREIGN KEY REFERENCES Account(accountID),
	username VARCHAR(50) NOT NULL FOREIGN KEY REFERENCES Account(username),
	accountPass varbinary(50)
	PRIMARY KEY (accountID, username)
);

CREATE TABLE LeaderBoard(
	centerNumber INT NOT NULL FOREIGN KEY REFERENCES Centres(centreID),
	accountID INT NOT NULL FOREIGN KEY REFERENCES Customer(accountID),
	routeNUmber INT NOT NULL FOREIGN KEY REFERENCES CircuitRoutes(routeNumber),
	username varchar(50) FOREIGN KEY REFERENCES Account(username),
	points int,
	duration time(7)
	PRIMARY KEY (centreNumber, accountID, routeNumber)
)