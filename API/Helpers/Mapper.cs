
using AutoMapper;
namespace API.Helpers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Entity.Grade, DTO.Grade>();
            CreateMap<DTO.Grade, Entity.Grade>()
              .AfterMap((source, destination) =>
              {
                  if (destination.ID == 0)
                  {
                      destination.ModifyUserID = null;
                      destination.ModifyDate = null;
                      destination.DeleteUserID = null;
                      destination.DeleteDate = null;
                      destination.IsDeleted = false;
                  }
              });
            CreateMap<Entity.SalaryInfo, DTO.SalaryInfo>();
            CreateMap<DTO.SalaryInfo, Entity.SalaryInfo>()
              .AfterMap((source, destination) =>
              {
                  if (destination.ID == 0)
                  {
                      destination.ModifyUserID = null;
                      destination.ModifyDate = null;
                      destination.DeleteUserID = null;
                      destination.DeleteDate = null;
                      destination.IsDeleted = false;
                  }
              });

            CreateMap<Entity.EmployeeDependent, DTO.EmployeeDependent>();
            CreateMap<DTO.EmployeeDependent, Entity.EmployeeDependent>()
              .AfterMap((source, destination) =>
              {
                  if (destination.ID == 0)
                  {
                      destination.ModifyUserID = null;
                      destination.ModifyDate = null;
                      destination.DeleteUserID = null;
                      destination.DeleteDate = null;
                      destination.IsDeleted = false;
                  }
              });

            CreateMap<Entity.EmployeeShift, DTO.EmployeeShift>();
            CreateMap<DTO.EmployeeShift, Entity.EmployeeShift>()
              .AfterMap((source, destination) =>
              {
                  if (destination.ID == 0)
                  {
                      destination.ModifyUserID = null;
                      destination.ModifyDate = null;
                      destination.DeleteUserID = null;
                      destination.DeleteDate = null;
                      destination.IsDeleted = false;
                  }
              });
            CreateMap<Entity.TimeAttendance, DTO.TimeAttendance>();
            CreateMap<DTO.TimeAttendance, Entity.TimeAttendance>()
              .AfterMap((source, destination) =>
              {
                  if (destination.ID == 0)
                  {
                      destination.ModifyUserID = null;
                      destination.ModifyDate = null;
                      destination.DeleteUserID = null;
                      destination.DeleteDate = null;
                      destination.IsDeleted = false;
                  }
              });

        
            CreateMap<Entity.TimeAttendanceStatus, DTO.TimeAttendanceStatus>();
            CreateMap<DTO.TimeAttendanceStatus, Entity.TimeAttendanceStatus>()
              .AfterMap((source, destination) =>
              {
                    if (destination.ID == 0)
                    {
                        destination.ModifyUserID = null;
                        destination.ModifyDate = null;
                        destination.DeleteUserID = null;
                        destination.DeleteDate = null;
                        destination.IsDeleted = false;
                    }
              });

            CreateMap<Entity.JobDescription, DTO.JobDescription>();
            CreateMap<DTO.JobDescription, Entity.JobDescription>()
              .AfterMap((source, destination) =>
              {
                  if (destination.ID == 0)
                  {
                      destination.ModifyUserID = null;
                      destination.ModifyDate = null;
                      destination.DeleteUserID = null;
                      destination.DeleteDate = null;
                      destination.IsDeleted = false;
                  }
              });

            CreateMap<Entity.Nationality, DTO.Nationality>();
            CreateMap<DTO.Nationality, Entity.Nationality>()
              .AfterMap((source, destination) =>
              {
                  if (destination.ID == 0)
                  {
                      destination.ModifyUserID = null;
                      destination.ModifyDate = null;
                      destination.DeleteUserID = null;
                      destination.DeleteDate = null;
                      destination.IsDeleted = false;
                  }
              });

                CreateMap<Entity.Country, DTO.Country>();
                CreateMap<DTO.Country, Entity.Country>()
                  .AfterMap((source, destination) =>
                  {
                      if (destination.ID == 0)
                      {
                          destination.ModifyUserID = null;
                          destination.ModifyDate = null;
                          destination.DeleteUserID = null;
                          destination.DeleteDate = null;
                          destination.IsDeleted = false;
                      }
                  });

            CreateMap<Entity.Relationship, DTO.Relationship>();
            CreateMap<DTO.Relationship, Entity.Relationship>()
              .AfterMap((source, destination) =>
              {
                  if (destination.ID == 0)
                  {
                      destination.ModifyUserID = null;
                      destination.ModifyDate = null;
                      destination.DeleteUserID = null;
                      destination.DeleteDate = null;
                      destination.IsDeleted = false;
                  }
              });

            CreateMap<Entity.Company, DTO.Company>();
            CreateMap<DTO.Company, Entity.Company>()
              .AfterMap((source, destination) =>
              {
                  if (destination.ID == 0)
                  {
                      destination.ModifyUserID = null;
                      destination.ModifyDate = null;
                      destination.DeleteUserID = null;
                      destination.DeleteDate = null;
                      destination.IsDeleted = false;
                  }
              });

            CreateMap<Entity.ShiftType, DTO.ShiftType>();
            CreateMap<DTO.ShiftType, Entity.ShiftType>()
              .AfterMap((source, destination) =>
              {
                  if (destination.ID == 0)
                  {
                      destination.ModifyUserID = null;
                      destination.ModifyDate = null;
                      destination.DeleteUserID = null;
                      destination.DeleteDate = null;
                      destination.IsDeleted = false;
                  }
              });

            CreateMap<Entity.Bank, DTO.Bank>();
            CreateMap<DTO.Bank, Entity.Bank>()
              .AfterMap((source, destination) =>
              {
                  if (destination.ID == 0)
                  {
                      destination.ModifyUserID = null;
                      destination.ModifyDate = null;
                      destination.DeleteUserID = null;
                      destination.DeleteDate = null;
                      destination.IsDeleted = false;
                  }
              });

            CreateMap<Entity.BankBranch, DTO.BankBranch>();
            CreateMap<DTO.BankBranch, Entity.BankBranch>()
              .AfterMap((source, destination) =>
              {
                  if (destination.ID == 0)
                  {
                      destination.ModifyUserID = null;
                      destination.ModifyDate = null;
                      destination.DeleteUserID = null;
                      destination.DeleteDate = null;
                      destination.IsDeleted = false;
                  }
              });

            CreateMap<Entity.MaritalStatus, DTO.MaritalStatus>();
            CreateMap<DTO.MaritalStatus, Entity.MaritalStatus>()
              .AfterMap((source, destination) =>
              {
                  if (destination.ID == 0)
                  {
                      destination.ModifyUserID = null;
                      destination.ModifyDate = null;
                      destination.DeleteUserID = null;
                      destination.DeleteDate = null;
                      destination.IsDeleted = false;
                  }
              });


            CreateMap<Entity.GeneralRequest, DTO.GeneralRequest>();
            CreateMap<DTO.GeneralRequest, Entity.GeneralRequest>()
              .AfterMap((source, destination) =>
              {
                  if (destination.ID == 0)
                  {
                      destination.ModifyUserID = null;
                      destination.ModifyDate = null;
                      destination.DeleteUserID = null;
                      destination.DeleteDate = null;
                      destination.IsDeleted = false;
                  }
              });

            CreateMap<Entity.GeneralRequestType, DTO.GeneralRequestType>();
            CreateMap<DTO.GeneralRequestType, Entity.GeneralRequestType>()
              .AfterMap((source, destination) =>
              {
                  if (destination.ID == 0)
                  {
                      destination.ModifyUserID = null;
                      destination.ModifyDate = null;
                      destination.DeleteUserID = null;
                      destination.DeleteDate = null;
                      destination.IsDeleted = false;
                  }
              });

            CreateMap<Entity.Gender, DTO.Gender>();
            CreateMap<DTO.Gender, Entity.Gender>()
              .AfterMap((source, destination) =>
              {
                  if (destination.ID == 0)
                  {
                      destination.ModifyUserID = null;
                      destination.ModifyDate = null;
                      destination.DeleteUserID = null;
                      destination.DeleteDate = null;
                      destination.IsDeleted = false;
                  }
              });

            CreateMap<Entity.AllowanceType, DTO.AllowanceType>();
            CreateMap<DTO.AllowanceType, Entity.AllowanceType>()
              .AfterMap((source, destination) =>
              {
                  if (destination.ID == 0)
                  {
                      destination.ModifyUserID = null;
                      destination.ModifyDate = null;
                      destination.DeleteUserID = null;
                      destination.DeleteDate = null;
                      destination.IsDeleted = false;
                  }
              });

            CreateMap<Entity.Employee, DTO.Employee>();
            CreateMap<DTO.Employee, Entity.Employee>()
              .AfterMap((source, destination) =>
              {
                  if (destination.ID == 0)
                  {
                      destination.ModifyUserID = null;
                      destination.ModifyDate = null;
                      destination.DeleteUserID = null;
                      destination.DeleteDate = null;
                      destination.IsDeleted = false;
                  }
              });


        }
    }


    
}
