IF Exists(
    SELECT * from sysobjects 
    where name = 'USERLOGIN' and xtype='U'
)Drop TABLE USERLOGIN

IF Exists(
    SELECT * from sysobjects 
    where name = 'JOB_DETAILS' and xtype='U'
)Drop TABLE JOB_DETAILS


IF Exists(
    SELECT * from sysobjects 
    where name = 'JOB_IRST' and xtype='U'
)Drop TABLE JOB_IRST


Create Table UserLogin(
	id int primary Key identity,
	username varchar(20),
	password varchar(128),
	isAdmin BIT,
	emailId varchar(50),
	contact varchar(15),
	address varchar(40),
)

INSERT INTO USERLOGIN (UserName,Password,isAdmin,emailId,Contact,Address)
VALUES
( 'user1','123123', 1, 'user1@example.com', 123456, '123 Main St'),
( 'user2','123123', 0, 'user2@example.com', 234567, '456 Elm St'),
( 'user3','123123', 1, 'user3@example.com', 345678, '789 Oak Ave'),
( 'user4','123123', 0, 'user4@example.com', 45678, '1011 Pine Blvd'),
( 'user5','123123', 0, 'user5@example.com', 567890, '1213 Maple Rd'),
( 'user6','123123', 1, 'user6@example.com', 678901, '1415 Birch Ln'),
( 'user7','123123', 0, 'user7@example.com', 789012, '1617 Cedar Dr'),
( 'user8','123123', 0, 'user8@example.com', 890123, '1819 Spruce St'),
( 'user9','123123', 1, 'user9@example.com', 901234, '2021 Oakwood Rd'),
( 'user10','123123', 0, 'user10@example.com', 12345, '2223 Chestnut Ave');


CREATE TABLE JOB_DETAILS (
JOB_ID INT IDENTITY (1,1) PRIMARY KEY,
JOB_ROLE NCHAR (20),
SALARY_PCK FLOAT,
CMPY_NAME NCHAR(25),
CMPY_LOCATION NCHAR (10),
REQ_EXP INT,
PLACED_EMP INT
);


--USER INTERSETED DB

CREATE TABLE JOB_IRST(
JOB_ID INT,
USER_ID INT
);


--Inserting values to the Job Values

INSERT INTO dbo.JOB_DETAILS(JOB_ROLE,SALARY_PCK,CMPY_NAME,CMPY_LOCATION,REQ_EXP,PLACED_EMP)
VALUES ('Jr Cloud Engineer', 1000000,'VD Corp', 'Chennai', 0 ,0 ),
('Data Engineer', 800000,'XD Solution', 'Coimbatore', 0 ,0 ),
('Software Engineer', 1100000,'MIN Pvt ltd', 'Mumbai', 2 ,0 ),
('Intern', 600000,'ABC Corp', 'Coimbatore', 0 ,0 ),
('jr Software develper', 900000,'XYZ Corp', 'Hyderabad', 0 ,0 ),
('Software develper', 1400000,'Global Solution', 'Noida', 4 ,0 ),
('Software Engineer', 1200000,'Delite', 'Bangalore', 3 ,0 ),
('HR Manager', 1500000,'Global Solution', 'Chennai', 6,0 ),
('Cloud Engineer', 1600000,'VD Corp', 'Bangalore', 3 ,0 ),
('Intern', 600000,'Delite', 'Bangalore', 0 ,0 );