use product
Create table Products
(
Id int primary key identity(1,1) not null,
ProName nvarchar(50) not null,
ProDesc nvarchar(100) not null,
OnDate datetime default getdate()
)
select * from products
create procedure sp_AddProducts
(
@ProName nvarchar(50), @Prodesc nvarchar(100)
)
as
begin
insert into Products (ProName,ProDesc) values (@ProName,@ProDesc)
end