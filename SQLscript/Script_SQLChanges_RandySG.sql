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
go