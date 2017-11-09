create table Roles (
ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
RoleName varchar(255),
);

create table Users (
ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
UserName varchar(255) NOT NULL,
Email varchar(255),
Shift varchar(255) NOT NULL,
RoleOneDayAgo int FOREIGN KEY REFERENCES Roles(ID),
RoleTwoDaysAgo int FOREIGN KEY REFERENCES Roles(ID),
RoleThreeDaysAgo int FOREIGN KEY REFERENCES Roles(ID),
OutOfWork bit,
Disabled bit,
Admin bit,
Password varchar(255)
);

create table User_Roles (
User_ID int NOT NULL FOREIGN KEY REFERENCES Users(ID),
Role_ID int NOT NULL FOREIGN KEY REFERENCES Roles(ID)
);