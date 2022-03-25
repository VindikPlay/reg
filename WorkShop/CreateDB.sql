Create table [dbo].[users]
(
	[id] int not null primary key identity,
	[login] text not null,
	[password] text not null,
	[email] text not null
)

create table [dbo].[orders]
(
	[id] int not null primary key identity,
	[serialnumber] text not null,
	[userId] int not null,
	[orderDate] date default getdate() not null,
	[fixeddate] date not null,
	[employeeSurname] text not null,
	[status] text not null
)

Alter table [dbo].[orders]
add
foreign key(userId) references users (id)
Go