create database ZadaniaDB;
go

create table tblZadania (
id int identity(1,1) not null primary key,
tytul nvarchar(200) not null,
termin datetime,
wykonane bit
);
go

insert tblZadania 
values ('Zadanie 1', '20190615',0),
('Zadanie 2', '20190620',0),
('Zadanie 1b', '20190513', 1),
('Zadanie 1c', '20190520', 0)
go

select * from tblZadania