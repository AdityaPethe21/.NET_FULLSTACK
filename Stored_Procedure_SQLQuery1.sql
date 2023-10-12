create proc InsertE_SP
@Emp_ID int,
@Emp_Name nvarchar(50),
@Emp_City nvarchar(50),
@Emp_Age int,
@Sex nvarchar(20),
@Joining_Date datetime,
@Contact nvarchar(50)
as
begin
Insert into Adi_Table(Emp_ID,Emp_Name,Emp_City,Emp_Age,Sex,Joining_Date,Contact)
values (@Emp_ID,@Emp_Name,@Emp_City,@Emp_Age,@Sex,@Joining_Date,@Contact)
end

exec InsertE_SP  3,'Jay','Pune',23,'Male','2/2/2019','5645788945'

create proc ListE_SP
as
begin
Select * from  Adi_Table
end

exec ListE_SP
--Update
create proc UpdateE_SP
@Emp_ID int,
@Emp_Name nvarchar(50),
@Emp_City nvarchar(50),
@Emp_Age int,
@Sex nvarchar(20),
@Joining_Date datetime,
@Contact nvarchar(50)
as
begin
Update Adi_Table set Emp_Name=@Emp_Name,Emp_City=@Emp_City,Emp_Age=@Emp_Age,Sex=@Sex,Joining_Date=@Joining_Date,Contact=@Contact where Emp_ID=@Emp_ID
end

--Delete

create proc DeleteE_SP
@Emp_ID int
as
begin
Delete Adi_Table where Emp_ID=@Emp_ID
end
--Load Specific Record
create proc LoadE_SP
@Emp_ID int
as
begin
Select * from  Adi_Table where Emp_ID=@Emp_ID
end
