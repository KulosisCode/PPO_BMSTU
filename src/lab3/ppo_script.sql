--Rooms
drop table Rooms cascade;
create table if not exists Rooms(
	id_room serial primary key, 
	number int not null,
	status varchar not null
);

insert into Rooms(number, status) values 
				(102, 'None'), 
				(203, 'None');

select * from Rooms;
--
--update Rooms
--set status =  
--CASE  
--	when status = 'Free' then 'Busy' 
--	when status = 'Busy' then 'Free'
--	else 'Free' 
--END --where id_room = 2;
--
--delete from Rooms where id_room = 3;
--
--update Rooms 
--set number = 203,
--	status = 'Free'
--where id_room  = 2;


--User
drop table Users cascade;
create table if not exists Users(
	id serial primary key,
	login varchar not null,
	password varchar not null,
	role varchar not null
);

insert into Users(login, password, role) values
	('kulosis', 'pass01',   'Guest'),
	('saber',   'pass02',   'Staff'),
	('admin',   'password', 'Admin');
select * from Users;

--Guest
drop table Guests cascade;
create table if not exists Guests(
	id serial primary key,
	id_login int,
	foreign key (id_login) references Users(id),
	name varchar not null,
	age int not null,
	email varchar not null,
	address varchar not null
);
insert into Guests(id_login, name, age, email, address) values
	(1, 'Alex', 20, 'alex@mail.com', 'Moscow'),
	(2, 'Huntress', 23, 'huntress@mail.com','NewYork');
--select * from Guests;

--Staffs
drop table Staffs cascade;
delete from Staffs;
create table if not exists Staffs(
	id serial primary key,
	id_login int,
	foreign key (id_login) references Users(id),
	name varchar not null,
	age int not null,
	email varchar not null,
	address varchar not null
);

insert into Staffs(id_login, name, age, email, address) values
	(1, 'Alex', 20, 'alex@mail.com', 'Moscow'),
	(2, 'Huntress', 23, 'huntress@mail.com','NewYork');

--select * from Staffs;

--Request
drop table Requests cascade;
create table if not exists Requests(
	id serial primary key,
	id_guest int not null,
	id_room int not null,
	foreign key (id_guest) references Guests(id),
	foreign key (id_room) references Rooms(id_room),
	price int,
	timeIn date not null,
	timeOut date not null,
	status varchar not null	
);
insert into Requests(id_guest, id_room, price, timeIn, timeOut, status) values
	(1, 1, 2000,'2023-01-01', '2023-01-02', 'None'),
	(2, 2, 1000,'2023-03-03', '2023-03-05', 'None');
--select * from Requests;

--History
drop table Histories;
create table if not exists Histories(
	id serial primary key,
	id_request int not null,
	id_staff int not null,
	foreign key (id_request) references Requests(id),
	foreign key (id_staff) references Staffs(id),
	timeAdded date not null
);
insert into Histories(id_request, id_staff, timeAdded) values
	(1, 2, '2023-01-01'),
	(2, 1, '2023-01-02');
--select * from Histories;
