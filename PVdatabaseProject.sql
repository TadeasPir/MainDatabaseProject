create database Machines;


use Machines;


create table PhoneNumber(
id int primary key identity(1,1),
phoneNumber varchar(20) not null unique,
manufacturer_id int not null foreign key references Manufacturer(id)
);

create table Manufacturer(
id int primary key identity(1,1),
name varchar(50) not null,
);

create table Machine(
id int primary key identity(1,1),
type varchar(50) not null,
name varchar(50) not null,
dimenX varchar(50) not null,
dimenY varchar(50) not null,
dimenZ varchar(50) not null,
price int not null,
 value decimal(3, 2),
manufacturer_id int not null foreign key references Manufacturer(id),
isNew bit not null
);


create table SpareParts(
id int primary key identity(1,1),
type varchar(50) not null,
name varchar(50) not null,
dimenX varchar(50) not null,
dimenY varchar(50) not null,
dimenZ varchar(50) not null,
price int not null
);

create table  Replacement(
id int primary key identity(1,1),
spareParts_id int not null foreign key references SpareParts(id),
machine_id int not null foreign key references Machine(id),
date date not null 
);

INSERT INTO Manufacturer (name) VALUES 
('Manufacturer A'),
('Manufacturer B'),
('Manufacturer C'),
('Manufacturer D'),
('Manufacturer E'),
('Manufacturer F'),
('Manufacturer G'),
('Manufacturer H'),
('Manufacturer I'),
('Manufacturer J');

-- Sample data for Machine table
INSERT INTO Machine (type, name, dimenX, dimenY, dimenZ, price, value, manufacturer_id, isNew) VALUES 
('Type A', 'Machine 1', '10', '20', '30', 1000, 9.99, 1, 1),
('Type B', 'Machine 2', '15', '25', '35', 1500, 9.99, 2, 0),
('Type C', 'Machine 3', '20', '30', '40', 2000, 9.99, 3, 1),
('Type D', 'Machine 4', '25', '35', '45', 2500, 9.99, 4, 0),
('Type E', 'Machine 5', '30', '40', '50', 3000, 9.99, 5, 1),
('Type F', 'Machine 6', '35', '45', '55', 3500, 9.99, 6, 0),
('Type G', 'Machine 7', '40', '50', '60', 4000, 9.99, 7, 1),
('Type H', 'Machine 8', '45', '55', '65', 4500, 9.99, 8, 0),
('Type I', 'Machine 9', '50', '60', '70', 5000, 9.99, 9, 1),
('Type J', 'Machine 10', '55', '65', '75', 5500, 9.99, 10, 0);

-- Sample data for SpareParts table
INSERT INTO SpareParts (type, name, dimenX, dimenY, dimenZ, price) VALUES 
('Type A', 'Spare Part 1', '5', '5', '5', 50),
('Type B', 'Spare Part 2', '10', '10', '10', 100),
('Type C', 'Spare Part 3', '15', '15', '15', 150),
('Type D', 'Spare Part 4', '20', '20', '20', 200),
('Type E', 'Spare Part 5', '25', '25', '25', 250),
('Type F', 'Spare Part 6', '30', '30', '30', 300),
('Type G', 'Spare Part 7', '35', '35', '35', 350),
('Type H', 'Spare Part 8', '40', '40', '40', 400),
('Type I', 'Spare Part 9', '45', '45', '45', 450),
('Type J', 'Spare Part 10', '50', '50', '50', 500);

-- Sample data for PhoneNumber table
INSERT INTO PhoneNumber (phoneNumber, manufacturer_id) VALUES 
('1234567890', 1),
('2345678901', 2),
('3456789012', 3),
('4567890123', 4),
('5678901234', 5),
('6789012345', 6),
('7890123456', 7),
('8901234567', 8),
('9012345678', 9),
('0123456789', 10);

-- Sample data for Replacement table
INSERT INTO Replacement (spareParts_id, machine_id, date) VALUES 
(1, 7, '2023-01-01'),
(2, 8, '2023-02-01'),
(3, 9, '2023-03-01'),
(4, 10, '2023-04-01'),
(5, 11, '2023-05-01'),
(6, 12, '2023-06-01'),
(7, 13, '2023-07-01'),
(8, 14, '2023-08-01'),
(9, 15, '2023-09-01'),
(10, 16, '2023-10-01');

