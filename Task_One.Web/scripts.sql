create database Task1
use Task1

create table Product
(
	ProductId int identity primary key,
	ProductName nvarchr(50) not null
)

create table Store
(
	StoreId int identity primary key,
	StoreName nvarchr(50) not null
)

create table Sells
(
	Id int identity primary key,
	ProductId int foreign key references Product(ProductId),
	StoreId int foreign key references Store(StoreId),
	Price decimal(17,2),
	SoldDate datetime,
)

create procedure GetChartData @sid int,@pid int as 
begin
select Price,SoldDate from Sells
where Sells.ProductId=@pid and Sells.StoreId=@sid
order by SoldDate
end

create procedure GetProductName @pid int as
begin
select ProductName from Product where ProductId=@pid
end

create procedure GetStoreName @sid int as
begin
select StoreName from Store where StoreId=@sid
end

create procedure GetStores as
begin
select StoreId,StoreName from Store
end

create procedure GetSoldDates as
begin
	select SoldDate from Sells group by SoldDate
end

create procedure GetPrices as
begin
	select Price from Sells group by Price
end

create procedure GetProductsSells @price decimal(17,2),@sid int,@date datetime as
begin
	select Product.ProductName,Sells.ProductId,Sells.StoreId,Store.StoreName,SoldDate,Price from Sells 
	inner join Product on Sells.ProductId=Product.ProductId
	inner join Store on Store.StoreId=Sells.StoreId
	where Sells.SoldDate=ISNULL(@date,SoldDate) 
	and Sells.StoreId=ISNULL(@sid,Sells.StoreId) 
	and Sells.Price=ISNULL(@price,Sells.Price)
order by SoldDate desc
end