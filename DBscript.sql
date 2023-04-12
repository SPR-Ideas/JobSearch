IF Exists(
    SELECT * from sysobjects 
    where name = 'UserLogin' and xtype='U'
)Drop TABLE USERLOGIN

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
