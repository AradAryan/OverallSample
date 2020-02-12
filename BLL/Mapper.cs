using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using vm = BusinessModel;
namespace BLL
{
    public class Mapper
    {
        internal static vm.SyndromeRegisterModel Map(GetSyndromRegisterNotSepas_Result entity)
        {
            if (entity == null)
                return null;
            return new vm.SyndromeRegisterModel
           {
               AdmissionType = entity.AdmissionType,
               Age = entity.Age,
               CenterGUID = entity.CenterGUID,
               CenterName = entity.Name,
               Dates = entity.Dates,
               IsOutRegister = entity.IsOutRegister,
               PatientID = entity.PatientID,
               PatientName = entity.PatientName,
               SyndromeName = entity.SyndromeName,
               SyndromeRegisterId = entity.SyndromeRegisterId,
               Times = entity.Times,
               UserID = entity.UserID,
               SyndromicId = entity.SyndromicId

           };
        }
        internal static vm.RelativeValueVM Map(GetRelativeValue_Result entity)
        {
            if (entity == null)
                return null;

            return new vm.RelativeValueVM
            {
                CityId = entity.CityId,
                Count = entity.Count
            };
        }

        internal static vm.StatisCutofPointValueVM Map(GetStatisticalCutoffPointValue_Result entity)
        {
            if (entity == null)
                return null;

            return new vm.StatisCutofPointValueVM
            {
                CityId = entity.CityId,
                Count = entity.Count,
                PersianDate = entity.PersianDate

            };
        }

        internal static vm.CusumModel Map(GetCusumValue_Result entity)
        {
            if (entity == null)
                return null;

            return new vm.CusumModel
            {
                CityId = entity.CityId,
                Count = entity.Count,
                PersianDate = entity.PersianDate

            };
        }

        internal static vm.AbsoluteValueVM Map(GetAbsolutValue_Result entity)
        {
            if (entity == null)
                return null;

            return new vm.AbsoluteValueVM
            {
                CityId = entity.CityId,
                Count = entity.Count
            };
        }

        internal static vm.SyndromicModel Map(Syndromic entity)
        {
            if (entity == null)
                return null;

            return new vm.SyndromicModel
            {
                SyndromicCode = entity.SyndromicCode,
                SyndromicId = entity.SyndromicId,
                SyndromicName = entity.SyndromicName,
                TerminologyID = entity.TerminologyID

            };
        }

        internal static vm.TherosholdModel Map(GetAllThrosholds_Result entity)
        {
            if (entity == null)
                return null;
            return new vm.TherosholdModel
            {
                Row = entity.Row.GetValueOrDefault(),
                FixNumber = entity.FixNumber,
                MethodID = entity.MethodID,
                MethodName = entity.MethodName,
                SyndromicId = entity.SyndromicId,
                SyndromicName = entity.SyndromicName,
                TherosholdID = entity.TherosholdID,
                ProvinceName = entity.ProvinceName,
                ProvinceId = entity.ProvinceId,
                UniversityId = entity.UniversityId,
                NetworkId = entity.NetworkId,
                PreProcessMethod = entity.PreProcessMethod,
                Factor = entity.Factor,
                PercentBased = entity.PercentBased,
                NetworkName = entity.NetworkName,
                PreProcessMethodTitle = entity.PreProcessMethodTitle,
                UniversityName = entity.UniversityName,
                TotalCount = entity.TotalCount.GetValueOrDefault(),
                Deleted = entity.Deleted,
                MinAbsoluteLimit = entity.MinAbsoluteLimit
            };
        }

        internal static Syndromic Map(vm.SyndromicModel model)
        {
            if (model == null)
                return null;

            return new Syndromic
            {
                SyndromicCode = model.SyndromicCode,
                SyndromicId = model.SyndromicId,
                SyndromicName = model.SyndromicName,
                TerminologyID = model.TerminologyID
            };
        }

        internal static Theroshold Map(vm.TherosholdModel model)
        {
            if (model == null)
                return null;

            return new Theroshold
            {
                FixNumber = model.FixNumber,
                MethodID = model.MethodID,
                SyndromicId = model.SyndromicId,
                TherosholdID = model.TherosholdID,
                ProvinceId = model.ProvinceId,
                PreProcessMethod = model.PreProcessMethod,
                Factor = model.Factor,
                UniversityId = model.UniversityId,
                NetworkId = model.NetworkId,
                PercentBased = model.PercentBased.GetValueOrDefault(),
                Deleted = model.Deleted
            };
        }


        internal static vm.TherosholdModel Map(Theroshold model)
        {
            if (model == null)
                return null;

            return new vm.TherosholdModel
            {
                FixNumber = model.FixNumber,
                MethodID = model.MethodID,
                SyndromicId = model.SyndromicId,
                TherosholdID = model.TherosholdID,
                ProvinceId = model.ProvinceId,
                PreProcessMethod = model.PreProcessMethod,
                Factor = model.Factor,
                UniversityId = model.UniversityId,
                NetworkId = model.NetworkId,
                PercentBased = model.PercentBased,
                Deleted = model.Deleted,
                MinAbsoluteLimit = model.MinAbsoluteLimit
            };
        }

        internal static visitCount Map(vm.VisitCountModel model)
        {
            if (model == null)
                return null;

            return new visitCount
            {
                Number = model.Number,
                PersianDate = model.PersianDate,
                RegisterDateTime = model.RegisterDateTime,
                UserId = model.UserId,
                VisitID = model.VisitID

            };
        }
        internal static vm.PatientModel Map(Patient entity)
        {
            if (entity == null)
                return null;

            return new vm.PatientModel
            {
                Age = entity.Age,
                BirthCityID = entity.BirthCityID,
                BirthDate = entity.BirthDate,
                BirthProvinceID = entity.BirthProvinceID,
                CardCityID = entity.CardCityID,
                CardProvinceID = entity.CardProvinceID,
                CellPhone = entity.CellPhone,
                //  CityId=entity.CityId,
                Confirmed = entity.Confirmed,
                //    DistrictId=entity.DistrictId,
                EducationID = entity.EducationID,
                Email = entity.Email,
                FatherNationalCode = entity.FatherNationalCode,
                FileNumber = entity.FileNumber,
                FirstName = entity.FirstName,
                FirstNameFather = entity.FirstNameFather,
                FirstNameMother = entity.FirstNameMother,
                FullAddress = entity.FullAddress,
                GenderID = entity.GenderID,
                IdentityNo = entity.IdentityNo,
                InsurerCode = entity.InsurerCode,
                InsurerExpireDate = entity.InsurerExpireDate,
                InsurerID = entity.InsurerID,
                JobID = entity.JobID,
                LastName = entity.LastName,
                LastNameFather = entity.LastNameFather,
                LastNameMother = entity.LastNameMother,
                MaritalID = entity.MaritalID,
                MotherNationalCode = entity.MotherNationalCode,
                NationalCode = entity.NationalCode,
                NationalityID = entity.NationalityID,
                PatientID = entity.PatientID,
                PatientUID = entity.PatientUID,
                Picture = entity.Picture,
                PostalCode = entity.PostalCode,
                //    ProvinceId=entity.ProvinceId,
                //   RaceID=entity.RaceID,
                RegisterDate = entity.RegisterDate,
                //   ReligionID=entity.ReligionID,
                //   RuralAreaId=entity.RuralAreaId,
                TelPhone = entity.TelPhone,
                //  TownId=entity.TownId,
                UserID = entity.UserID


            };
        }

        internal static vm.WarningThresholdModel Map(spSearchThresholdWarnings_Result entity)
        {
            if (entity == null)
                return null;
            return new vm.WarningThresholdModel
            {
                Row = entity.Row.GetValueOrDefault(),
                Threshold = new vm.TherosholdModel()
                {
                    FixNumber = entity.FixNumber,
                    MethodID = entity.MethodID,
                    MethodName = entity.MethodName,
                    SyndromicId = entity.SyndromicId,
                    SyndromicName = entity.SyndromicName,
                    TherosholdID = entity.TherosholdID,
                    ProvinceName = entity.ProvinceName,
                    ProvinceId = entity.ProvinceId,
                    UniversityId = entity.UniversityId,
                    NetworkId = entity.NetworkId,
                    PreProcessMethod = entity.PreProcessMethod,
                    Factor = entity.Factor,
                    PercentBased = entity.PercentBased,
                    NetworkName = entity.NetworkName,
                    NetworkGuid = entity.NetworkGuid,
                    PreProcessMethodTitle = entity.PreProcessMethodTitle,
                    ProvinceEnglishName = entity.ProvinceEnglishName,
                    UniversityName = entity.UniversityName,
                    Deleted = entity.Deleted,
                    MinAbsoluteLimit = entity.MinAbsoluteLimit
                },
                TotalCount = entity.TotalCount.GetValueOrDefault(),
                CurrentValue = entity.CurrentValue,
                ThresholdValue = entity.ThresholdValue,
                PersianDate = entity.PersianDate,
                LastStatusId = entity.LastStatusId,
                LastStatusTitle = entity.LastStatusTitle,
                WarningId = entity.WarningThresholdId,
                Unverified = entity.Unverified.GetValueOrDefault()
            };
        }

        internal static vm.UsersReceiveTherosholdVM Map(spGetThresholdWarningReceivers_Result entity)
        {
            return new vm.UsersReceiveTherosholdVM()
            {
                Id = entity.Id,
                Mobile = entity.Mobile,
                UserName = entity.UserName,
                Firstname = entity.FirstName,
                Lastname = entity.LastName
            };
        }

        internal static List<vm.LabResultVM> Map(List<SpGetAdmissionLabResults_Result> list)
        {
            List<vm.LabResultVM> result = new List<vm.LabResultVM>();
            foreach (var item in list)
            {
                result.Add(new vm.LabResultVM()
                {
                    LabResultId = item.LabResultId,
                    LabName = item.LabName,
                    DiseaseId = item.DiseaseId.GetValueOrDefault(),
                    LabResultDate = item.LabResultDate,
                    PrimaryLabResultTitle = item.PrimaryLabResultTitle,
                    SampleReceiveDate = item.SampleReceiveDate,
                    SamplingDate = item.SamplingDate,
                    SyndromName = item.SyndromName,
                    TestQualityTitle = item.TestQualityTitle,
                    DiseaseCode = item.DiseaseCategoryCode.GetValueOrDefault(),
                    DiseaseName = item.DiseaseName,
                    LabDiseaseLevel = item.LabDiseaseLevel,
                    LevelCode = item.LevelCode
                });
            }
            return result;
        }

        internal static List<vm.LabResultDetailVM> Map(List<SpGetAdmissionLabResultDetails_Result> dbLabDetails)
        {
            List<vm.LabResultDetailVM> result = new List<vm.LabResultDetailVM>();
            foreach (var item in dbLabDetails)
            {
                result.Add(new vm.LabResultDetailVM()
                {
                    LabResultId = item.LabResultId,
                    DetailCode = item.DetailCode,
                    DetailTitle = item.DetailTitle,
                    TypeCode = item.TypeCode.GetValueOrDefault(),
                    TypeTitle = item.TypeTitle,
                    Value = item.Value
                });
            }
            return result;
        }

        internal static Corporate Map(vm.LabCorporateModel lab)
        {
            var corp = new Corporate()
            {
                Id = lab.CorporateId,
                ClientName = "Lab",
                Description = "",
                IP = "",
                FirstDateReg = "",
                FirstUserReg = 0,
                EnName = lab.CorporateGuid,
                Code = lab.CorporateId.ToString(),
                Name = lab.CorporateName,
                Provience = lab.ProvinceName,
                City = lab.CityName
            };
            if (lab.CenterId != 0)
                corp.ParentId = lab.CenterId;
            else if (lab.NetworkId != 0)
                corp.ParentId = lab.NetworkId;
            else if (lab.UniversityId != 0)
                corp.ParentId = lab.UniversityId;

            return corp;
        }

        internal static vm.LabCorporateModel Map(Corporate corp)
        {
            // todo: بقیه فیلدها هم پر شوند
            var result = new vm.LabCorporateModel()
            {
                CorporateId = corp.Id,
                CorporateName = corp.Name,
                ProvinceName = corp.Provience
            };
            return result;
        }

        internal static vm.TherosholdModel Map(spThresholdSearch_Result entity)
        {
            if (entity == null)
                return null;
            return new vm.TherosholdModel
            {
                Row = entity.Row.GetValueOrDefault(),
                FixNumber = entity.FixNumber,
                MethodID = entity.MethodID,
                MethodName = entity.MethodName,
                SyndromicId = entity.SyndromicId,
                SyndromicName = entity.SyndromicName,
                TherosholdID = entity.TherosholdID,
                ProvinceName = entity.ProvinceName,
                ProvinceId = entity.ProvinceId,
                UniversityId = entity.UniversityId,
                NetworkId = entity.NetworkId,
                PreProcessMethod = entity.PreProcessMethod,
                Factor = entity.Factor,
                PercentBased = entity.PercentBased,
                NetworkName = entity.NetworkName,
                PreProcessMethodTitle = entity.PreProcessMethodTitle,
                UniversityName = entity.UniversityName,
                TotalCount = entity.TotalCount.GetValueOrDefault(),
                Deleted = entity.Deleted,
                MinAbsoluteLimit = entity.MinAbsoluteLimit
            };
        }

        internal static BusinessModel.CorporateModel MapCorp(Corporate model)
        {
            BusinessModel.CorpTypeCode corpType = 0;
            using (UnitOfWork uow = new UnitOfWork())
            {
                Enum.TryParse<BusinessModel.CorpTypeCode>(model.ClientName, out corpType);
                var result = new vm.CorporateModel()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Guid = Guid.Parse(model.EnName),
                    CorpType = corpType,
                    ProvinceId = uow.AreaLocationRepository.GetProvinceId(model.Provience)
                };

                var corpHierarchy = uow.CorporatesHierarchyRepository.GetByCorporateId(model.Id);
                if (corpHierarchy != null)
                {
                    result.UniversityId = corpHierarchy.UniversityCorporateId.GetValueOrDefault();
                    result.NetworkId = corpHierarchy.NetworkCorporateId.GetValueOrDefault();
                    result.CenterId = corpHierarchy.CenterCorporateId.GetValueOrDefault();

                    // todo: uncomment below lines
                    // result.SubCenterId = corpHierarchy.SubCenterId.GetValueOrDefault();
                    // result.CityId = corpHierarchy.CityId.GetValueOrDefault();
                }

                // موقعیت جغرافیایی
                double pos = 0;
                double.TryParse(model.Longitude, out pos);
                result.Longitude = pos;
                double.TryParse(model.Latitude, out pos);
                result.Latitude = pos;

                return result;
            }
        }

        internal static vm.PositionModel Map(Position dbPosition)
        {
            return new vm.PositionModel()
            {
                Id = dbPosition.Id,
                Name = dbPosition.Name,
                ParentId = dbPosition.ParentId.GetValueOrDefault()
            };
        }

        internal static vm.PermissionModel Map(Permission item)
        {
            return new vm.PermissionModel()
            {
                Code = item.Code,
                Id = item.Id,
                FarsiName = item.FarsiName,
                Name = item.Name
            };
        }

        internal static vm.UserModel Map(User dbUser)
        {
            return new vm.UserModel()
            {
                CorporateId = dbUser.CorporateId,
                Email = dbUser.Email,
                Firstname = dbUser.FirstName,
                Id = dbUser.Id,
                Lastname = dbUser.LastName,
                Mobile = dbUser.Mobile,
                Username = dbUser.UserName,
                PositionId = dbUser.PositionId.GetValueOrDefault()
            };
        }

        internal static vm.UsersReceiveTherosholdVM Map(spGetThresholdWarningReceivers_Managers_Result entity)
        {
            return new vm.UsersReceiveTherosholdVM()
            {
                Id = entity.Id,
                Mobile = entity.Mobile,
                UserName = entity.UserName,
                Firstname = entity.FirstName,
                Lastname = entity.LastName
            };
        }

        //internal static vm.PhoneVM Map(Phone dbModel)
        //{
        //    return new vm.PhoneVM()
        //    {
        //        Id = dbModel.Id,
        //        Firstname = dbModel.Firstname,
        //        Lastname = dbModel.Lastname,
        //        Mobile = dbModel.Mobile
        //    };
        //}
    }
}
