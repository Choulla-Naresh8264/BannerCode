if exists (select 1 from sys.objects o where UPPER(o.name)='LOGIN' and o.type='U')
begin
	drop table LOGIN;
end


create table LOGIN(UserName varchar(50)not null,Password varchar(50) not null);


insert into LOGIN values('seenu','seenu');
insert into LOGIN values('umar','umar');