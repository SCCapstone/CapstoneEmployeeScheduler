﻿create table Roles (
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

create table Schedule (
    ID varchar(255) not null,
    User_ID int not null,
    Role_ID int not null,
    ScheduleDate date not null
);

create table Permission (
	Employee_Page bit not null,
	Role_Page bit not null,
	History_Page bit not null,
	Todays_Schedule bit not null,
	Generate_Schedule bit not null
);