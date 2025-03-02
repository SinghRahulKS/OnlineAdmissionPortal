create procedure InsertAdmission
(  
	@StudentName nvarchar(255),
    @StudentId int,
    @Cource nvarchar(255),
    @Email nvarchar(255),
    @Phone nvarchar(20),
    @InstituteName nvarchar(255),
    @InstituteType int,
    @CreatedBy nvarchar(255)
)
as
begin
    set nocount on;
    insert into Admission (StudentName,  StudentId,   Cource,  Email,  Phone,  InstituteName,  InstituteType,  CreatedBy ) 
    values ( @StudentName,  @StudentId, @Cource,   @Email,  @Phone,  @InstituteName,  @InstituteType,  @CreatedBy)
end;
