use employee
 Create table EMP_DB
(
Id int primary key identity(1,1) not null,
EMP_Name nvarchar(50) not null,
EMP_Desc nvarchar(100) not null
)
select * from EMP_DB
create procedure sp_EMP
(
@EMP_Name nvarchar(50), @EMP_Desc nvarchar(100)
)
as
begin
insert into EMP_DB (EMP_NAME,EMP_DESC) values (@EMP_Name,@EMP_Desc)
end