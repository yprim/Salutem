--Add constraint to avoid duplicated identityCards
alter table userr add constraint UK_Userr unique(identityCard)
go

--Returns one user or all users, depending if the optional parameter is set or not.
create procedure sp_getUserr
	@identityCard		varchar(200) = null
as begin
	select *
	  from userr
	 where identityCard = case when @identityCard is null then identityCard else @identityCard end
end
go

--Returns user info if email and password are correct. Used for login.
create procedure sp_getUserrLogin
	@email		varchar(200),
	@password	varchar(20)
as begin
	select *
	  from userr
	 where email = @email and password = @password
end
go