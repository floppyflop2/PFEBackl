Drop table users
Drop table machines
Drop table problems

CREATE TABLE Users
(UserId int NOT NULL IDENTITY(1,1),
UserEmail varchar(255) NOT NULL,
AspNetUserId nvarchar(128) NOT NULL,
CONSTRAINT PK_UserId PRIMARY KEY NONCLUSTERED (UserId),     
--CONSTRAINT FK_AspNetUsers FOREIGN KEY (AspNetUserId)     
--    REFERENCES AspNetUsers (Id),     
UNIQUE (UserEmail))

CREATE TABLE Machines
(MachineId int NOT NULL IDENTITY(1,1),
MachineName varchar(255) NOT NULL,
MacAddress varchar(255) NOT NULL,
Comment varchar(255) NOT NULL,
Statut varchar(255) NOT NULL,
CONSTRAINT PK_MachineId PRIMARY KEY NONCLUSTERED (MachineId),
UNIQUE (MacAddress))


CREATE TABLE Problems
(ProblemId int NOT NULL IDENTITY(1,1),
ProbDescription varchar(255) NOT NULL,
Photo varchar(max),
MachineId int NOT NULL,
StudentId int NOT NULL,
DateProb Date NOT NULL,
Statut varchar(255) NOT NULL,
Fixed Bit NOT NULL,
CONSTRAINT PK_ProblemID PRIMARY KEY NONCLUSTERED (ProblemId),     
CONSTRAINT FK_MachineIdProblem FOREIGN KEY (MachineId)     
    REFERENCES Machines (MachineId))