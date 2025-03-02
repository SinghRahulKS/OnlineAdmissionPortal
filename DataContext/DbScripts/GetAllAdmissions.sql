create procedure GetAllAdmissions
as
begin
    set nocount on;
    
    select  Id,  StudentName,  StudentId,  Cource,   Email,   Phone,  InstituteName,  InstituteType, 
				Created,   CreatedBy,  LastUpdated,  LastUpdatedBy
    from Admission;
end;
