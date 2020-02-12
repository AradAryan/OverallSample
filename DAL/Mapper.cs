using BusinessModel.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DAL
{
    internal class Mapper
    {

        internal static BusinessModel.Statistics.MaxRespiratory Map(spGetMaxRespiratoryReport_Result dbResult)
        {
            var result = new BusinessModel.Statistics.MaxRespiratory()
            {
                AdmitedCount = dbResult.AdmitedCount,
                TotalSampledCount = dbResult.SampledCount,
                DiedCount = dbResult.DiedCount,
                DiedCountWithPositiveResult = dbResult.DiedCountWithPositiveResult,
                DiedGroupedByVirus = new List<KeyValuePair<string, double>>(),
                Female = dbResult.Female,
                GroupedByAge = new List<KeyValuePair<string, int>>(),
                GroupedByVirus = new List<KeyValuePair<string, double>>(),
                Male = dbResult.Male,
                PositiveItemsCount = dbResult.PositiveItemsCount,
                ReportedHospitalsCount = dbResult.ReportedHospitalsCount,
                PositiveGroupedByAge = new List<KeyValuePair<string, int>>(),
                DiedPositiveGroupedByAge = new List<KeyValuePair<string, int>>(),
                DiedGroupedByAge = new List<KeyValuePair<string, int>>()
            };

            result.GroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup1Title, dbResult.AgeGroup1Count));
            result.GroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup2Title, dbResult.AgeGroup2Count));
            result.GroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup3Title, dbResult.AgeGroup3Count));
            result.GroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup4Title, dbResult.AgeGroup4Count));
            result.GroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup5Title, dbResult.AgeGroup5Count));
            result.GroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup6Title, dbResult.AgeGroup6Count));
            result.GroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup7Title, dbResult.AgeGroup7Count));
            result.GroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup8Title, dbResult.AgeGroup8Count));
            result.GroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup9Title, dbResult.AgeGroup9Count));

            result.PositiveGroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup1Title, dbResult.PositiveAgeGroup1Count));
            result.PositiveGroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup2Title, dbResult.PositiveAgeGroup2Count));
            result.PositiveGroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup3Title, dbResult.PositiveAgeGroup3Count));
            result.PositiveGroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup4Title, dbResult.PositiveAgeGroup4Count));
            result.PositiveGroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup5Title, dbResult.PositiveAgeGroup5Count));
            result.PositiveGroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup6Title, dbResult.PositiveAgeGroup6Count));
            result.PositiveGroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup7Title, dbResult.PositiveAgeGroup7Count));
            result.PositiveGroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup8Title, dbResult.PositiveAgeGroup8Count));
            result.PositiveGroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup9Title, dbResult.PositiveAgeGroup9Count));

            result.DiedPositiveGroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup1Title, dbResult.DiedPositiveAgeGroup1Count));
            result.DiedPositiveGroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup2Title, dbResult.DiedPositiveAgeGroup2Count));
            result.DiedPositiveGroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup3Title, dbResult.DiedPositiveAgeGroup3Count));
            result.DiedPositiveGroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup4Title, dbResult.DiedPositiveAgeGroup4Count));
            result.DiedPositiveGroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup5Title, dbResult.DiedPositiveAgeGroup5Count));
            result.DiedPositiveGroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup6Title, dbResult.DiedPositiveAgeGroup6Count));
            result.DiedPositiveGroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup7Title, dbResult.DiedPositiveAgeGroup7Count));
            result.DiedPositiveGroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup8Title, dbResult.DiedPositiveAgeGroup8Count));
            result.DiedPositiveGroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup9Title, dbResult.DiedPositiveAgeGroup9Count));

            result.DiedGroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup1Title, dbResult.DiedAgeGroup1Count));
            result.DiedGroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup2Title, dbResult.DiedAgeGroup2Count));
            result.DiedGroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup3Title, dbResult.DiedAgeGroup3Count));
            result.DiedGroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup4Title, dbResult.DiedAgeGroup4Count));
            result.DiedGroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup5Title, dbResult.DiedAgeGroup5Count));
            result.DiedGroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup6Title, dbResult.DiedAgeGroup6Count));
            result.DiedGroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup7Title, dbResult.DiedAgeGroup7Count));
            result.DiedGroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup8Title, dbResult.DiedAgeGroup8Count));
            result.DiedGroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup9Title, dbResult.DiedAgeGroup9Count));

            // درصد گونه ویروس مثبت
            XmlDocument xPositiveDoc = new XmlDocument();
            xPositiveDoc.LoadXml(dbResult.PositiveItems);
            int total = 0;
            foreach (XmlNode item in xPositiveDoc.DocumentElement.ChildNodes)
            {
                int groupCount = int.Parse(item.SelectSingleNode("Count").InnerText);
                total += groupCount;
            }
            foreach (XmlNode item in xPositiveDoc.DocumentElement.ChildNodes)
            {
                string groupTitle = item.SelectSingleNode("VirusSubVirus").InnerText.Replace('#', ' ');
                int groupCount = int.Parse(item.SelectSingleNode("Count").InnerText);

                // result.GroupedByVirus.Add(new KeyValuePair<string, int>(groupTitle, groupCount * 100 / dbResult.PositiveItemsCount));
                result.GroupedByVirus.Add(new KeyValuePair<string, double>(groupTitle, groupCount * 100.0 / total));
            }

            total = 0;
            #region درصد گونه ویروس مثبت فوت شده

            XmlDocument xDiedDoc = new XmlDocument();
            xDiedDoc.LoadXml(dbResult.DiedItemsWithPositiveResult);
            foreach (XmlNode item in xDiedDoc.DocumentElement.ChildNodes)
            {
                int groupCount = int.Parse(item.SelectSingleNode("Count").InnerText);
                total += groupCount;
            }
            foreach (XmlNode item in xDiedDoc.DocumentElement.ChildNodes)
            {
                string groupTitle = item.SelectSingleNode("VirusSubVirus").InnerText.Replace('#', ' ');
                int groupCount = int.Parse(item.SelectSingleNode("Count").InnerText);

                // result.DiedGroupedByVirus.Add(new KeyValuePair<string, int>(groupTitle, groupCount * 100 / dbResult.DiedCountWithPositiveResult));
                result.DiedGroupedByVirus.Add(new KeyValuePair<string, double>(groupTitle, groupCount * 100.0 / total));
            }

            #endregion

            XmlDocument xDoc = new XmlDocument();

            #region بیماری زمینه ای به تفکیک سن

            result.MedicalHistoryGroups = new List<BusinessModel.Statistics.AgeGroup>();
            if (!string.IsNullOrEmpty(dbResult.MedicalHistoryGroups))
            {
                xDoc.LoadXml(dbResult.MedicalHistoryGroups);
                foreach (XmlNode item in xDoc.DocumentElement.ChildNodes)
                {
                    string ageGroupTitle = item.SelectSingleNode("AgeGroup").InnerText;
                    if (string.IsNullOrEmpty(ageGroupTitle))
                        continue;
                    int ageGroup = int.Parse(ageGroupTitle);
                    int count = int.Parse(item.SelectSingleNode("Count").InnerText);
                    string title = item.SelectSingleNode("Title").InnerText;

                    var pItem = result.MedicalHistoryGroups.FirstOrDefault(x => x.Title == title);
                    if (pItem == null)
                    {
                        pItem = new BusinessModel.Statistics.AgeGroup()
                        {
                            Title = title,
                            Values = new List<decimal>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                        };
                        result.MedicalHistoryGroups.Add(pItem);
                    }
                    pItem.Values[ageGroup - 1] = count;
                }
            }

            #endregion

            #region بیماری زمینه ای به تفکیک سن - موارد مثبت

            result.PositiveMedicalHistoryGroups = new List<BusinessModel.Statistics.AgeGroup>();
            if (!string.IsNullOrEmpty(dbResult.PositiveMedicalHistoryGroups))
            {
                xDoc = new XmlDocument();
                xDoc.LoadXml(dbResult.PositiveMedicalHistoryGroups);
                foreach (XmlNode item in xDoc.DocumentElement.ChildNodes)
                {
                    string ageGroupTitle = item.SelectSingleNode("AgeGroup").InnerText;
                    if (string.IsNullOrEmpty(ageGroupTitle))
                        continue;
                    int ageGroup = int.Parse(ageGroupTitle);
                    int count = int.Parse(item.SelectSingleNode("Count").InnerText);
                    string title = item.SelectSingleNode("Title").InnerText;

                    var pItem = result.PositiveMedicalHistoryGroups.FirstOrDefault(x => x.Title == title);
                    if (pItem == null)
                    {
                        pItem = new BusinessModel.Statistics.AgeGroup()
                        {
                            Title = title,
                            Values = new List<decimal>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                        };
                        result.PositiveMedicalHistoryGroups.Add(pItem);
                    }
                    pItem.Values[ageGroup - 1] = count;
                }
            }

            #endregion

            #region بیماری زمینه ای به تفکیک سن - موارد فوت شده

            result.DiedMedicalHistoryGroups = new List<BusinessModel.Statistics.AgeGroup>();
            if (!string.IsNullOrEmpty(dbResult.DiedMedicalHistoryGroups))
            {
                xDoc = new XmlDocument();
                xDoc.LoadXml(dbResult.DiedMedicalHistoryGroups);
                foreach (XmlNode item in xDoc.DocumentElement.ChildNodes)
                {
                    string ageGroupTitle = item.SelectSingleNode("AgeGroup").InnerText;
                    if (string.IsNullOrEmpty(ageGroupTitle))
                        continue;
                    int ageGroup = int.Parse(ageGroupTitle);
                    int count = int.Parse(item.SelectSingleNode("Count").InnerText);
                    string title = item.SelectSingleNode("Title").InnerText;

                    var pItem = result.DiedMedicalHistoryGroups.FirstOrDefault(x => x.Title == title);
                    if (pItem == null)
                    {
                        pItem = new BusinessModel.Statistics.AgeGroup()
                        {
                            Title = title,
                            Values = new List<decimal>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                        };
                        result.DiedMedicalHistoryGroups.Add(pItem);
                    }
                    pItem.Values[ageGroup - 1] = count;
                }
            }

            #endregion

            #region بیماری زمینه ای به تفکیک سن - موارد فوت شده مثبت

            result.DiedPositiveMedicalHistoryGroups = new List<BusinessModel.Statistics.AgeGroup>();
            if (!string.IsNullOrEmpty(dbResult.DiedPositiveMedicalHistoryGroups))
            {
                xDoc = new XmlDocument();
                xDoc.LoadXml(dbResult.DiedPositiveMedicalHistoryGroups);
                foreach (XmlNode item in xDoc.DocumentElement.ChildNodes)
                {
                    string ageGroupTitle = item.SelectSingleNode("AgeGroup").InnerText;
                    if (string.IsNullOrEmpty(ageGroupTitle))
                        continue;
                    int ageGroup = int.Parse(ageGroupTitle);
                    int count = int.Parse(item.SelectSingleNode("Count").InnerText);
                    string title = item.SelectSingleNode("Title").InnerText;

                    var pItem = result.DiedPositiveMedicalHistoryGroups.FirstOrDefault(x => x.Title == title);
                    if (pItem == null)
                    {
                        pItem = new BusinessModel.Statistics.AgeGroup()
                        {
                            Title = title,
                            Values = new List<decimal>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                        };
                        result.DiedPositiveMedicalHistoryGroups.Add(pItem);
                    }
                    pItem.Values[ageGroup - 1] = count;
                }
            }

            #endregion


            #region عوارض به تفکیک سن

            result.ComplicationGroups = new List<BusinessModel.Statistics.AgeGroup>();
            if (!string.IsNullOrEmpty(dbResult.ComplicationGroups))
            {
                xDoc = new XmlDocument();
                xDoc.LoadXml(dbResult.ComplicationGroups);
                foreach (XmlNode item in xDoc.DocumentElement.ChildNodes)
                {
                    string ageGroupTitle = item.SelectSingleNode("AgeGroup").InnerText;
                    if (string.IsNullOrEmpty(ageGroupTitle))
                        continue;
                    int ageGroup = int.Parse(ageGroupTitle);
                    int count = int.Parse(item.SelectSingleNode("Count").InnerText);
                    string title = item.SelectSingleNode("Title").InnerText;

                    var pItem = result.ComplicationGroups.FirstOrDefault(x => x.Title == title);
                    if (pItem == null)
                    {
                        pItem = new BusinessModel.Statistics.AgeGroup()
                        {
                            Title = title,
                            Values = new List<decimal>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                        };
                        result.ComplicationGroups.Add(pItem);
                    }
                    pItem.Values[ageGroup - 1] = count;
                }
            }

            #endregion

            #region عوارض به تفکیک سن - موارد مثبت

            result.PositiveComplicationGroups = new List<BusinessModel.Statistics.AgeGroup>();
            if (!string.IsNullOrEmpty(dbResult.PositiveComplicationGroups))
            {
                xDoc = new XmlDocument();
                xDoc.LoadXml(dbResult.PositiveComplicationGroups);
                foreach (XmlNode item in xDoc.DocumentElement.ChildNodes)
                {
                    string ageGroupTitle = item.SelectSingleNode("AgeGroup").InnerText;
                    if (string.IsNullOrEmpty(ageGroupTitle))
                        continue;
                    int ageGroup = int.Parse(ageGroupTitle);
                    int count = int.Parse(item.SelectSingleNode("Count").InnerText);
                    string title = item.SelectSingleNode("Title").InnerText;

                    var pItem = result.PositiveComplicationGroups.FirstOrDefault(x => x.Title == title);
                    if (pItem == null)
                    {
                        pItem = new BusinessModel.Statistics.AgeGroup()
                        {
                            Title = title,
                            Values = new List<decimal>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                        };
                        result.PositiveComplicationGroups.Add(pItem);
                    }
                    pItem.Values[ageGroup - 1] = count;
                }
            }

            #endregion

            #region عوارض به تفکیک سن - موارد فوت شده

            result.DiedComplicationGroups = new List<BusinessModel.Statistics.AgeGroup>();
            if (!string.IsNullOrEmpty(dbResult.DiedComplicationGroups))
            {
                xDoc = new XmlDocument();
                xDoc.LoadXml(dbResult.DiedComplicationGroups);
                foreach (XmlNode item in xDoc.DocumentElement.ChildNodes)
                {
                    string ageGroupTitle = item.SelectSingleNode("AgeGroup").InnerText;
                    if (string.IsNullOrEmpty(ageGroupTitle))
                        continue;
                    int ageGroup = int.Parse(ageGroupTitle);
                    int count = int.Parse(item.SelectSingleNode("Count").InnerText);
                    string title = item.SelectSingleNode("Title").InnerText;

                    var pItem = result.DiedComplicationGroups.FirstOrDefault(x => x.Title == title);
                    if (pItem == null)
                    {
                        pItem = new BusinessModel.Statistics.AgeGroup()
                        {
                            Title = title,
                            Values = new List<decimal>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                        };
                        result.DiedComplicationGroups.Add(pItem);
                    }
                    pItem.Values[ageGroup - 1] = count;
                }
            }

            #endregion

            #region عوارض به تفکیک سن - موارد فوت شده مثبت

            result.DiedPositiveComplicationGroups = new List<BusinessModel.Statistics.AgeGroup>();
            if (!string.IsNullOrEmpty(dbResult.DiedPositiveComplicationGroups))
            {
                xDoc = new XmlDocument();
                xDoc.LoadXml(dbResult.DiedPositiveComplicationGroups);
                foreach (XmlNode item in xDoc.DocumentElement.ChildNodes)
                {
                    string ageGroupTitle = item.SelectSingleNode("AgeGroup").InnerText;
                    if (string.IsNullOrEmpty(ageGroupTitle))
                        continue;
                    int ageGroup = int.Parse(ageGroupTitle);
                    int count = int.Parse(item.SelectSingleNode("Count").InnerText);
                    string title = item.SelectSingleNode("Title").InnerText;

                    var pItem = result.DiedPositiveComplicationGroups.FirstOrDefault(x => x.Title == title);
                    if (pItem == null)
                    {
                        pItem = new BusinessModel.Statistics.AgeGroup()
                        {
                            Title = title,
                            Values = new List<decimal>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                        };
                        result.DiedPositiveComplicationGroups.Add(pItem);
                    }
                    pItem.Values[ageGroup - 1] = count;
                }
            }

            #endregion

            return result;
        }

        internal static BusinessModel.Statistics.ILISentinel Map(spGetILISentinelReport_Result dbResult)
        {
            var result = new BusinessModel.Statistics.ILISentinel()
            {
                TotalCount = dbResult.TotalCount,
                Female = dbResult.Female,
                GroupedByAge = new List<KeyValuePair<string, int>>(),
                Male = dbResult.Male,
                ReportedHospitalsCount = dbResult.ReportedHospitalsCount,
                TotalVisitedCount = dbResult.TotalVisitedCount,
                DubiousPercent = dbResult.DubiousPercent
            };

            result.GroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup1Title, dbResult.AgeGroup1Count));
            result.GroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup2Title, dbResult.AgeGroup2Count));
            result.GroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup3Title, dbResult.AgeGroup3Count));
            result.GroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup4Title, dbResult.AgeGroup4Count));
            result.GroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup5Title, dbResult.AgeGroup5Count));
            result.GroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup6Title, dbResult.AgeGroup6Count));
            result.GroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup7Title, dbResult.AgeGroup7Count));
            result.GroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup8Title, dbResult.AgeGroup8Count));
            result.GroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup9Title, dbResult.AgeGroup9Count));

            return result;
        }

        internal static BusinessModel.Statistics.ILIFlow Map(spGetILIFlowReport_Result dbResult)
        {
            var result = new BusinessModel.Statistics.ILIFlow()
            {
                PersianDate = dbResult.PersianDate,
                Amount = dbResult.Amount
            };
            return result;
        }

        internal static BusinessModel.ProvinceAndCity Map(spGetProvinceAndCity_Result item)
        {
            var result = new BusinessModel.ProvinceAndCity();
            if (item == null)
                return result;
            result.CityId = item.CityId.GetValueOrDefault();
            result.CityName = item.CityName;
            result.ProvinceId = item.ProvinceId.GetValueOrDefault();
            result.ProvinceName = item.ProvinceName;
            return result;
        }

        internal static List<BusinessModel.Statistics.Map> Map(List<spGetMapReport_Result> dbResult)
        {
            var result = new List<BusinessModel.Statistics.Map>();
            if (dbResult == null || dbResult.Count == 0)
                return result;
            foreach (var item in dbResult)
            {
                result.Add(new BusinessModel.Statistics.Map()
                {
                    Amount = item.Amount,
                    Province = item.Province
                });
            }
            return result;
        }

        internal static List<KeyValuePair<long, string>> Map(List<spGetCorporatesNotEnteredVisitCount_Result> dbResult)
        {
            var result = new List<KeyValuePair<long, string>>();
            if (dbResult != null)
                foreach (var item in dbResult)
                    result.Add(new KeyValuePair<long, string>(item.Id, item.Name));
            return result;
        }

        internal static BusinessModel.UserCorporateInfo Map(spGetUserCorporateInfo_Result item)
        {
            var result = new BusinessModel.UserCorporateInfo()
            {
                Center = item.CenterCorporateName,
                CenterId = item.CenterCorporateId,
                Network = item.NetworkCorporateName,
                NetworkId = item.NetworkCorporateId,
                Province = item.Province,
                University = item.UniversityCorporateName,
                UniversityId = item.UniversityCorporateId
            };
            return result;
        }

        internal static List<Disease> Map(List<spGetLabSupportedDiseases_Result> dbItems)
        {
            var result = new List<Disease>();
            foreach (var item in dbItems)
            {
                result.Add(new Disease()
                {
                    Comment = item.Comment,
                    DiseaseCategoryId = item.DiseaseCategoryId,
                    DiseasesName = item.DiseasesName,
                    DiseasesPersianName = item.DiseasesPersianName,
                    Id = item.Id,
                    PositiveTitle = item.PositiveTitle,
                    SnomedCode = item.SnomedCode,
                    SyndromId = item.SyndromId
                });
            }
            return result;
        }

        internal static BusinessModel.UserModel Map(spSaveUser_Result dbUser)
        {
            return new BusinessModel.UserModel()
            {
                Id = dbUser.Id,
                CorporateId = dbUser.CorporateId,
                Email = dbUser.Email,
                Mobile = dbUser.Mobile,
                Firstname = dbUser.FirstName,
                Lastname = dbUser.LastName,
                Username = dbUser.UserName,
                PositionId = dbUser.PositionId.GetValueOrDefault()
            };
        }

        internal static BusinessModel.PermissionModel Map(spGetNonSystemPermissions_Result item)
        {
            return new BusinessModel.PermissionModel()
            {
                Id = item.Id,
                Name = item.Name,
                Code = item.Code,
                FarsiName = item.FarsiName
            };
        }

        internal static Permission Map(spGetPermissionsByPositionId_Result item)
        {
            return new Permission()
            {
                Id = item.Id,
                ClientName = item.ClientName,
                Code = item.Code,
                // FarsiName = item.FarsiName,
                // FirstDateReg = item.FirstDateReg,
                // FirstUserReg = item.FirstUserReg,
                // IP = item.IP,
                Name = item.Name
            };
        }

        internal static BusinessModel.Statistics.EpidemicMin Map(spGetEpidemicMinReport_Result dbResult, List<Syndromic> syndroms)
        {
            var result = new BusinessModel.Statistics.EpidemicMin()
            {
                TotalCount = dbResult.TotalCount,
                TotalVisitCount = dbResult.TotalVisitCount,

                GroupedBySyndrom = new List<KeyValuePair<string, int>>(),

                Female = dbResult.Female,
                Male = dbResult.Male,
                IranianMale = dbResult.IranaianMale,
                IranianFemale = dbResult.IranaianFemale,
                ReportedHospitalsCount = dbResult.ReportedHospitalsCount,
                GroupedByAge = new List<KeyValuePair<string, int>>(),
                MaleAgeGroups = new List<KeyValuePair<string, int>>(),
                FemaleAgeGroups = new List<KeyValuePair<string, int>>(),
                ForeignerMale = dbResult.ForeignerMale,
                ForeignerFemale = dbResult.ForeignerFemale,

                Iranian = dbResult.Iranaian,
                Foreigner = dbResult.Foreigner,

                IranianAgeGroups = new List<KeyValuePair<string, int>>(),
                ForeignerAgeGroups = new List<KeyValuePair<string, int>>(),


                GroupedBySyndromPercent = new List<KeyValuePair<string, double>>(),
                GroupedByAgePercent = new List<KeyValuePair<string, double>>(),
                MaleAgeGroupsPercent = new List<KeyValuePair<string, double>>(),
                FemaleAgeGroupsPercent = new List<KeyValuePair<string, double>>(),
                IranianAgeGroupsPercent = new List<KeyValuePair<string, double>>(),
                ForeignerAgeGroupsPercent = new List<KeyValuePair<string, double>>()
            };

            #region تعداد


            result.GroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup1Title, dbResult.AgeGroup1Count));
            result.GroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup2Title, dbResult.AgeGroup2Count));
            result.GroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup3Title, dbResult.AgeGroup3Count));
            result.GroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup4Title, dbResult.AgeGroup4Count));
            result.GroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup5Title, dbResult.AgeGroup5Count));
            result.GroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup6Title, dbResult.AgeGroup6Count));
            result.GroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup7Title, dbResult.AgeGroup7Count));
            result.GroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup8Title, dbResult.AgeGroup8Count));
            result.GroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup9Title, dbResult.AgeGroup9Count));

            result.MaleAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup1Title, dbResult.MaleAgeGroup1Count));
            result.MaleAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup2Title, dbResult.MaleAgeGroup2Count));
            result.MaleAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup3Title, dbResult.MaleAgeGroup3Count));
            result.MaleAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup4Title, dbResult.MaleAgeGroup4Count));
            result.MaleAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup5Title, dbResult.MaleAgeGroup5Count));
            result.MaleAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup6Title, dbResult.MaleAgeGroup6Count));
            result.MaleAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup7Title, dbResult.MaleAgeGroup7Count));
            result.MaleAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup8Title, dbResult.MaleAgeGroup8Count));
            result.MaleAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup9Title, dbResult.MaleAgeGroup9Count));

            result.FemaleAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup1Title, dbResult.FemaleAgeGroup1Count));
            result.FemaleAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup2Title, dbResult.FemaleAgeGroup2Count));
            result.FemaleAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup3Title, dbResult.FemaleAgeGroup3Count));
            result.FemaleAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup4Title, dbResult.FemaleAgeGroup4Count));
            result.FemaleAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup5Title, dbResult.FemaleAgeGroup5Count));
            result.FemaleAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup6Title, dbResult.FemaleAgeGroup6Count));
            result.FemaleAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup7Title, dbResult.FemaleAgeGroup7Count));
            result.FemaleAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup8Title, dbResult.FemaleAgeGroup8Count));
            result.FemaleAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup9Title, dbResult.FemaleAgeGroup9Count));

            result.IranianAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup1Title, dbResult.IranaianAgeGroup1Count));
            result.IranianAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup1Title, dbResult.IranaianAgeGroup2Count));
            result.IranianAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup1Title, dbResult.IranaianAgeGroup3Count));
            result.IranianAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup1Title, dbResult.IranaianAgeGroup4Count));
            result.IranianAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup1Title, dbResult.IranaianAgeGroup5Count));
            result.IranianAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup1Title, dbResult.IranaianAgeGroup6Count));
            result.IranianAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup1Title, dbResult.IranaianAgeGroup7Count));
            result.IranianAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup1Title, dbResult.IranaianAgeGroup8Count));
            result.IranianAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup1Title, dbResult.IranaianAgeGroup9Count));

            result.ForeignerAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup1Title, dbResult.ForeignerAgeGroup1Count));
            result.ForeignerAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup1Title, dbResult.ForeignerAgeGroup2Count));
            result.ForeignerAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup1Title, dbResult.ForeignerAgeGroup3Count));
            result.ForeignerAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup1Title, dbResult.ForeignerAgeGroup4Count));
            result.ForeignerAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup1Title, dbResult.ForeignerAgeGroup5Count));
            result.ForeignerAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup1Title, dbResult.ForeignerAgeGroup6Count));
            result.ForeignerAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup1Title, dbResult.ForeignerAgeGroup7Count));
            result.ForeignerAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup1Title, dbResult.ForeignerAgeGroup8Count));
            result.ForeignerAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup1Title, dbResult.ForeignerAgeGroup9Count));

            // به تفکیک سندروم
            result.GroupedBySyndrom.Add(new KeyValuePair<string, int>(syndroms.FirstOrDefault(x => x.SyndromicId == 1).SyndromicName, dbResult.SyndromCount_1));
            result.GroupedBySyndrom.Add(new KeyValuePair<string, int>(syndroms.FirstOrDefault(x => x.SyndromicId == 2).SyndromicName, dbResult.SyndromCount_2));
            result.GroupedBySyndrom.Add(new KeyValuePair<string, int>(syndroms.FirstOrDefault(x => x.SyndromicId == 3).SyndromicName, dbResult.SyndromCount_3));
            result.GroupedBySyndrom.Add(new KeyValuePair<string, int>(syndroms.FirstOrDefault(x => x.SyndromicId == 4).SyndromicName, dbResult.SyndromCount_4));
            result.GroupedBySyndrom.Add(new KeyValuePair<string, int>(syndroms.FirstOrDefault(x => x.SyndromicId == 5).SyndromicName, dbResult.SyndromCount_5));
            result.GroupedBySyndrom.Add(new KeyValuePair<string, int>(syndroms.FirstOrDefault(x => x.SyndromicId == 6).SyndromicName, dbResult.SyndromCount_6));
            result.GroupedBySyndrom.Add(new KeyValuePair<string, int>(syndroms.FirstOrDefault(x => x.SyndromicId == 7).SyndromicName, dbResult.SyndromCount_7));
            result.GroupedBySyndrom.Add(new KeyValuePair<string, int>(syndroms.FirstOrDefault(x => x.SyndromicId == 8).SyndromicName, dbResult.SyndromCount_8));
            result.GroupedBySyndrom.Add(new KeyValuePair<string, int>(syndroms.FirstOrDefault(x => x.SyndromicId == 9).SyndromicName, dbResult.SyndromCount_9));
            result.GroupedBySyndrom.Add(new KeyValuePair<string, int>(syndroms.FirstOrDefault(x => x.SyndromicId == 10).SyndromicName, dbResult.SyndromCount_10));
            result.GroupedBySyndrom.Add(new KeyValuePair<string, int>(syndroms.FirstOrDefault(x => x.SyndromicId == 11).SyndromicName, dbResult.SyndromCount_11));
            result.GroupedBySyndrom.Add(new KeyValuePair<string, int>(syndroms.FirstOrDefault(x => x.SyndromicId == 12).SyndromicName, dbResult.SyndromCount_12));
            result.GroupedBySyndrom.Add(new KeyValuePair<string, int>(syndroms.FirstOrDefault(x => x.SyndromicId == 13).SyndromicName, dbResult.SyndromCount_13));
            result.GroupedBySyndrom.Add(new KeyValuePair<string, int>(syndroms.FirstOrDefault(x => x.SyndromicId == 14).SyndromicName, dbResult.SyndromCount_14));
            result.GroupedBySyndrom.Add(new KeyValuePair<string, int>(syndroms.FirstOrDefault(x => x.SyndromicId == 15).SyndromicName, dbResult.SyndromCount_15));


            #endregion


            #region درصد

            if (dbResult.TotalVisitCount != 0)
            {
                result.FemalePercent = result.Female * 100.0 / dbResult.TotalVisitCount;
                result.MalePercent = result.Male * 100.0 / dbResult.TotalVisitCount;

                result.IranianPercent = result.Iranian * 100.0 / dbResult.TotalVisitCount;
                result.ForeignerPercent = result.Foreigner * 100.0 / dbResult.TotalVisitCount;

                result.IranianFemalePercent = result.IranianFemale * 100.0 / dbResult.TotalVisitCount;
                result.IranianMalePercent = result.IranianMale * 100.0 / dbResult.TotalVisitCount;

                result.ForeignerFemalePercent = result.ForeignerFemale * 100.0 / dbResult.TotalVisitCount;
                result.ForeignerMalePercent = result.ForeignerMale * 100.0 / dbResult.TotalVisitCount;
            }

            result.GroupedByAgePercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup1Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.AgeGroup1Count * 100.0 / dbResult.TotalVisitCount));
            result.GroupedByAgePercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup2Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.AgeGroup2Count * 100.0 / dbResult.TotalVisitCount));
            result.GroupedByAgePercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup3Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.AgeGroup3Count * 100.0 / dbResult.TotalVisitCount));
            result.GroupedByAgePercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup4Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.AgeGroup4Count * 100.0 / dbResult.TotalVisitCount));
            result.GroupedByAgePercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup5Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.AgeGroup5Count * 100.0 / dbResult.TotalVisitCount));
            result.GroupedByAgePercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup6Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.AgeGroup6Count * 100.0 / dbResult.TotalVisitCount));
            result.GroupedByAgePercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup7Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.AgeGroup7Count * 100.0 / dbResult.TotalVisitCount));
            result.GroupedByAgePercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup8Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.AgeGroup8Count * 100.0 / dbResult.TotalVisitCount));
            result.GroupedByAgePercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup9Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.AgeGroup9Count * 100.0 / dbResult.TotalVisitCount));

            result.MaleAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup1Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.MaleAgeGroup1Count * 100.0 / dbResult.TotalVisitCount));
            result.MaleAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup2Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.MaleAgeGroup2Count * 100.0 / dbResult.TotalVisitCount));
            result.MaleAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup3Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.MaleAgeGroup3Count * 100.0 / dbResult.TotalVisitCount));
            result.MaleAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup4Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.MaleAgeGroup4Count * 100.0 / dbResult.TotalVisitCount));
            result.MaleAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup5Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.MaleAgeGroup5Count * 100.0 / dbResult.TotalVisitCount));
            result.MaleAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup6Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.MaleAgeGroup6Count * 100.0 / dbResult.TotalVisitCount));
            result.MaleAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup7Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.MaleAgeGroup7Count * 100.0 / dbResult.TotalVisitCount));
            result.MaleAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup8Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.MaleAgeGroup8Count * 100.0 / dbResult.TotalVisitCount));
            result.MaleAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup9Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.MaleAgeGroup9Count * 100.0 / dbResult.TotalVisitCount));

            result.FemaleAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup1Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.FemaleAgeGroup1Count * 100.0 / dbResult.TotalVisitCount));
            result.FemaleAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup2Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.FemaleAgeGroup2Count * 100.0 / dbResult.TotalVisitCount));
            result.FemaleAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup3Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.FemaleAgeGroup3Count * 100.0 / dbResult.TotalVisitCount));
            result.FemaleAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup4Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.FemaleAgeGroup4Count * 100.0 / dbResult.TotalVisitCount));
            result.FemaleAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup5Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.FemaleAgeGroup5Count * 100.0 / dbResult.TotalVisitCount));
            result.FemaleAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup6Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.FemaleAgeGroup6Count * 100.0 / dbResult.TotalVisitCount));
            result.FemaleAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup7Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.FemaleAgeGroup7Count * 100.0 / dbResult.TotalVisitCount));
            result.FemaleAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup8Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.FemaleAgeGroup8Count * 100.0 / dbResult.TotalVisitCount));
            result.FemaleAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup9Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.FemaleAgeGroup9Count * 100.0 / dbResult.TotalVisitCount));

            result.IranianAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup1Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.IranaianAgeGroup1Count * 100.0 / dbResult.TotalVisitCount));
            result.IranianAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup1Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.IranaianAgeGroup2Count * 100.0 / dbResult.TotalVisitCount));
            result.IranianAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup1Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.IranaianAgeGroup3Count * 100.0 / dbResult.TotalVisitCount));
            result.IranianAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup1Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.IranaianAgeGroup4Count * 100.0 / dbResult.TotalVisitCount));
            result.IranianAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup1Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.IranaianAgeGroup5Count * 100.0 / dbResult.TotalVisitCount));
            result.IranianAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup1Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.IranaianAgeGroup6Count * 100.0 / dbResult.TotalVisitCount));
            result.IranianAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup1Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.IranaianAgeGroup7Count * 100.0 / dbResult.TotalVisitCount));
            result.IranianAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup1Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.IranaianAgeGroup8Count * 100.0 / dbResult.TotalVisitCount));
            result.IranianAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup1Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.IranaianAgeGroup9Count * 100.0 / dbResult.TotalVisitCount));

            result.ForeignerAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup1Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.ForeignerAgeGroup1Count * 100.0 / dbResult.TotalVisitCount));
            result.ForeignerAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup1Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.ForeignerAgeGroup2Count * 100.0 / dbResult.TotalVisitCount));
            result.ForeignerAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup1Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.ForeignerAgeGroup3Count * 100.0 / dbResult.TotalVisitCount));
            result.ForeignerAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup1Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.ForeignerAgeGroup4Count * 100.0 / dbResult.TotalVisitCount));
            result.ForeignerAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup1Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.ForeignerAgeGroup5Count * 100.0 / dbResult.TotalVisitCount));
            result.ForeignerAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup1Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.ForeignerAgeGroup6Count * 100.0 / dbResult.TotalVisitCount));
            result.ForeignerAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup1Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.ForeignerAgeGroup7Count * 100.0 / dbResult.TotalVisitCount));
            result.ForeignerAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup1Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.ForeignerAgeGroup8Count * 100.0 / dbResult.TotalVisitCount));
            result.ForeignerAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup1Title, dbResult.TotalVisitCount == 0 ? 0 : dbResult.ForeignerAgeGroup9Count * 100.0 / dbResult.TotalVisitCount));

            // به تفکیک سندروم
            result.GroupedBySyndromPercent.Add(new KeyValuePair<string, double>(syndroms.FirstOrDefault(x => x.SyndromicId == 1).SyndromicName, dbResult.TotalVisitCount == 0 ? 0 : dbResult.SyndromCount_1 * 100.0 / dbResult.TotalVisitCount));
            result.GroupedBySyndromPercent.Add(new KeyValuePair<string, double>(syndroms.FirstOrDefault(x => x.SyndromicId == 2).SyndromicName, dbResult.TotalVisitCount == 0 ? 0 : dbResult.SyndromCount_2 * 100.0 / dbResult.TotalVisitCount));
            result.GroupedBySyndromPercent.Add(new KeyValuePair<string, double>(syndroms.FirstOrDefault(x => x.SyndromicId == 3).SyndromicName, dbResult.TotalVisitCount == 0 ? 0 : dbResult.SyndromCount_3 * 100.0 / dbResult.TotalVisitCount));
            result.GroupedBySyndromPercent.Add(new KeyValuePair<string, double>(syndroms.FirstOrDefault(x => x.SyndromicId == 4).SyndromicName, dbResult.TotalVisitCount == 0 ? 0 : dbResult.SyndromCount_4 * 100.0 / dbResult.TotalVisitCount));
            result.GroupedBySyndromPercent.Add(new KeyValuePair<string, double>(syndroms.FirstOrDefault(x => x.SyndromicId == 5).SyndromicName, dbResult.TotalVisitCount == 0 ? 0 : dbResult.SyndromCount_5 * 100.0 / dbResult.TotalVisitCount));
            result.GroupedBySyndromPercent.Add(new KeyValuePair<string, double>(syndroms.FirstOrDefault(x => x.SyndromicId == 6).SyndromicName, dbResult.TotalVisitCount == 0 ? 0 : dbResult.SyndromCount_6 * 100.0 / dbResult.TotalVisitCount));
            result.GroupedBySyndromPercent.Add(new KeyValuePair<string, double>(syndroms.FirstOrDefault(x => x.SyndromicId == 7).SyndromicName, dbResult.TotalVisitCount == 0 ? 0 : dbResult.SyndromCount_7 * 100.0 / dbResult.TotalVisitCount));
            result.GroupedBySyndromPercent.Add(new KeyValuePair<string, double>(syndroms.FirstOrDefault(x => x.SyndromicId == 8).SyndromicName, dbResult.TotalVisitCount == 0 ? 0 : dbResult.SyndromCount_8 * 100.0 / dbResult.TotalVisitCount));
            result.GroupedBySyndromPercent.Add(new KeyValuePair<string, double>(syndroms.FirstOrDefault(x => x.SyndromicId == 9).SyndromicName, dbResult.TotalVisitCount == 0 ? 0 : dbResult.SyndromCount_9 * 100.0 / dbResult.TotalVisitCount));
            result.GroupedBySyndromPercent.Add(new KeyValuePair<string, double>(syndroms.FirstOrDefault(x => x.SyndromicId == 10).SyndromicName, dbResult.TotalVisitCount == 0 ? 0 : dbResult.SyndromCount_10 * 100.0 / dbResult.TotalVisitCount));
            result.GroupedBySyndromPercent.Add(new KeyValuePair<string, double>(syndroms.FirstOrDefault(x => x.SyndromicId == 11).SyndromicName, dbResult.TotalVisitCount == 0 ? 0 : dbResult.SyndromCount_11 * 100.0 / dbResult.TotalVisitCount));
            result.GroupedBySyndromPercent.Add(new KeyValuePair<string, double>(syndroms.FirstOrDefault(x => x.SyndromicId == 12).SyndromicName, dbResult.TotalVisitCount == 0 ? 0 : dbResult.SyndromCount_12 * 100.0 / dbResult.TotalVisitCount));
            result.GroupedBySyndromPercent.Add(new KeyValuePair<string, double>(syndroms.FirstOrDefault(x => x.SyndromicId == 13).SyndromicName, dbResult.TotalVisitCount == 0 ? 0 : dbResult.SyndromCount_13 * 100.0 / dbResult.TotalVisitCount));
            result.GroupedBySyndromPercent.Add(new KeyValuePair<string, double>(syndroms.FirstOrDefault(x => x.SyndromicId == 14).SyndromicName, dbResult.TotalVisitCount == 0 ? 0 : dbResult.SyndromCount_14 * 100.0 / dbResult.TotalVisitCount));
            result.GroupedBySyndromPercent.Add(new KeyValuePair<string, double>(syndroms.FirstOrDefault(x => x.SyndromicId == 15).SyndromicName, dbResult.TotalVisitCount == 0 ? 0 : dbResult.SyndromCount_15 * 100.0 / dbResult.TotalVisitCount));



            #endregion

            return result;
        }

        internal static BusinessModel.Statistics.EpidemicMax Map(spGetEpidemicMaxReport_Result dbResult, List<Disease> diseases)
        {
            var result = new BusinessModel.Statistics.EpidemicMax()
            {
                TotalCount = dbResult.TotalCount,
                SampledCount = dbResult.SampledCount,

                TotalVisitCount = dbResult.TotalVisitCount,
                GroupedBySyndrom = new List<KeyValuePair<string, int>>(),

                Female = dbResult.Female,
                Male = dbResult.Male,
                IranianMale = dbResult.IranaianMale,
                IranianFemale = dbResult.IranaianFemale,
                ReportedHospitalsCount = dbResult.ReportedHospitalsCount,
                GroupedByAge = new List<KeyValuePair<string, int>>(),
                MaleAgeGroups = new List<KeyValuePair<string, int>>(),
                FemaleAgeGroups = new List<KeyValuePair<string, int>>(),
                GroupedByDisease = new List<KeyValuePair<string, int>>(),

                ForeignerMale = dbResult.ForeignerMale,
                ForeignerFemale = dbResult.ForeignerFemale,

                Iranian = dbResult.Iranaian,
                Foreigner = dbResult.Foreigner,

                IranianAgeGroups = new List<KeyValuePair<string, int>>(),
                ForeignerAgeGroups = new List<KeyValuePair<string, int>>(),

                PositiveCount = dbResult.PositiveCount,

                GroupedBySyndromPercent = new List<KeyValuePair<string, double>>(),
                GroupedByAgePercent = new List<KeyValuePair<string, double>>(),
                MaleAgeGroupsPercent = new List<KeyValuePair<string, double>>(),
                FemaleAgeGroupsPercent = new List<KeyValuePair<string, double>>(),
                GroupedByDiseasePercent = new List<KeyValuePair<string, double>>(),
                DiseaseAgeGroupPercent = new List<BusinessModel.Statistics.DiseaseGenderAgeGroup>(),
                DiseaseAgeGroupPercentInTheSameAge = new List<BusinessModel.Statistics.DiseaseGenderAgeGroup>(),
                DiseaseAgeGroup = new List<BusinessModel.Statistics.DiseaseGenderAgeGroup>(),
                DiseaseGenderGroup = new List<BusinessModel.Statistics.DiseaseGenderAgeGroup>(),
                DiseaseGenderGroupPercent = new List<BusinessModel.Statistics.DiseaseGenderAgeGroup>(),
                DiseaseGenderGroupPercentInTheSameGender = new List<BusinessModel.Statistics.DiseaseGenderAgeGroup>(),

                DiseaseGenderAgeGroup = new List<BusinessModel.Statistics.DiseaseGenderAgeGroup>(),
                DiseaseGenderAgeGroupPercent = new List<BusinessModel.Statistics.DiseaseGenderAgeGroup>(),
                DiseaseGenderAgeGroupPercentInTheSameGenderAgeGroup = new List<BusinessModel.Statistics.DiseaseGenderAgeGroup>(),

                // میزان کشندگی
                CFR_DiedDiseaseGenderAgeGroup = new List<BusinessModel.Statistics.DiseaseGenderAgeGroup>(),
                CFR_DiedDiseaseGender = new List<BusinessModel.Statistics.DiseaseGenderAgeGroup>(),
                CFR_DiedDiseaseAgeGroup = new List<BusinessModel.Statistics.DiseaseGenderAgeGroup>(),
            };

            Func<XmlNode, string> fnDiseaseTitle = xmlNode =>
            {
                if (xmlNode == null)
                    return "";
                return xmlNode.InnerText;

                // string diseaseIdString = xmlNode.InnerText;
                // if (string.IsNullOrEmpty(diseaseIdString))
                //     return "";
                // int diseaseId = 0;
                // int.TryParse(diseaseIdString, out diseaseId);
                // return diseases.Where(x => x.Id == diseaseId).Select(x => x.DiseasesName).FirstOrDefault() ?? "";
            };



            #region تعداد


            result.GroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup1Title, dbResult.AgeGroup1Count));
            result.GroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup2Title, dbResult.AgeGroup2Count));
            result.GroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup3Title, dbResult.AgeGroup3Count));
            result.GroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup4Title, dbResult.AgeGroup4Count));
            result.GroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup5Title, dbResult.AgeGroup5Count));
            result.GroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup6Title, dbResult.AgeGroup6Count));
            result.GroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup7Title, dbResult.AgeGroup7Count));
            result.GroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup8Title, dbResult.AgeGroup8Count));
            result.GroupedByAge.Add(new KeyValuePair<string, int>(dbResult.AgeGroup9Title, dbResult.AgeGroup9Count));

            result.MaleAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup1Title, dbResult.MaleAgeGroup1Count));
            result.MaleAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup2Title, dbResult.MaleAgeGroup2Count));
            result.MaleAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup3Title, dbResult.MaleAgeGroup3Count));
            result.MaleAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup4Title, dbResult.MaleAgeGroup4Count));
            result.MaleAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup5Title, dbResult.MaleAgeGroup5Count));
            result.MaleAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup6Title, dbResult.MaleAgeGroup6Count));
            result.MaleAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup7Title, dbResult.MaleAgeGroup7Count));
            result.MaleAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup8Title, dbResult.MaleAgeGroup8Count));
            result.MaleAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup9Title, dbResult.MaleAgeGroup9Count));

            result.FemaleAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup1Title, dbResult.FemaleAgeGroup1Count));
            result.FemaleAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup2Title, dbResult.FemaleAgeGroup2Count));
            result.FemaleAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup3Title, dbResult.FemaleAgeGroup3Count));
            result.FemaleAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup4Title, dbResult.FemaleAgeGroup4Count));
            result.FemaleAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup5Title, dbResult.FemaleAgeGroup5Count));
            result.FemaleAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup6Title, dbResult.FemaleAgeGroup6Count));
            result.FemaleAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup7Title, dbResult.FemaleAgeGroup7Count));
            result.FemaleAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup8Title, dbResult.FemaleAgeGroup8Count));
            result.FemaleAgeGroups.Add(new KeyValuePair<string, int>(dbResult.AgeGroup9Title, dbResult.FemaleAgeGroup9Count));

            #endregion

            #region تعدادها برای کمک به محاسبه درصد

            List<GenderAgeGroup> genderAgeGroups = new List<GenderAgeGroup>();
            XmlDocument xDoc = new XmlDocument();
            if (!string.IsNullOrEmpty(dbResult.AgeGenderGroups))
            {
                xDoc.LoadXml(dbResult.AgeGenderGroups);
                foreach (XmlNode item in xDoc.DocumentElement.ChildNodes)
                {
                    string ageGroupTitle = item.SelectSingleNode("a").InnerText;
                    if (string.IsNullOrEmpty(ageGroupTitle))
                        continue;
                    int ageGroup = int.Parse(ageGroupTitle);
                    var gender = (BusinessModel.Service.Gender)int.Parse(item.SelectSingleNode("g").InnerText);
                    int count = int.Parse(item.SelectSingleNode("c").InnerText);

                    genderAgeGroups.Add(new GenderAgeGroup()
                    {
                        Gender = gender,
                        AgeGroup = ageGroup,
                        Count = count
                    });
                }
            }

            #endregion

            #region درصد

            if (dbResult.TotalCount != 0)
            {
                result.SampledPercent = result.SampledCount * 100.0 / dbResult.TotalCount;

                result.FemalePercent = result.Female * 100.0 / dbResult.TotalCount;
                result.MalePercent = result.Male * 100.0 / dbResult.TotalCount;
            }

            result.GroupedByAgePercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup1Title, dbResult.TotalCount == 0 ? 0 : safeDiv(dbResult.AgeGroup1Count * 100.0, genderAgeGroups.Where(x => x.AgeGroup == 1).SumOrDefault(x => (decimal)x.Count))));
            result.GroupedByAgePercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup2Title, dbResult.TotalCount == 0 ? 0 : safeDiv(dbResult.AgeGroup2Count * 100.0, genderAgeGroups.Where(x => x.AgeGroup == 2).SumOrDefault(x => (decimal)x.Count))));
            result.GroupedByAgePercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup3Title, dbResult.TotalCount == 0 ? 0 : safeDiv(dbResult.AgeGroup3Count * 100.0, genderAgeGroups.Where(x => x.AgeGroup == 3).SumOrDefault(x => (decimal)x.Count))));
            result.GroupedByAgePercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup4Title, dbResult.TotalCount == 0 ? 0 : safeDiv(dbResult.AgeGroup4Count * 100.0, genderAgeGroups.Where(x => x.AgeGroup == 4).SumOrDefault(x => (decimal)x.Count))));
            result.GroupedByAgePercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup5Title, dbResult.TotalCount == 0 ? 0 : safeDiv(dbResult.AgeGroup5Count * 100.0, genderAgeGroups.Where(x => x.AgeGroup == 5).SumOrDefault(x => (decimal)x.Count))));
            result.GroupedByAgePercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup6Title, dbResult.TotalCount == 0 ? 0 : safeDiv(dbResult.AgeGroup6Count * 100.0, genderAgeGroups.Where(x => x.AgeGroup == 6).SumOrDefault(x => (decimal)x.Count))));
            result.GroupedByAgePercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup7Title, dbResult.TotalCount == 0 ? 0 : safeDiv(dbResult.AgeGroup7Count * 100.0, genderAgeGroups.Where(x => x.AgeGroup == 7).SumOrDefault(x => (decimal)x.Count))));
            result.GroupedByAgePercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup8Title, dbResult.TotalCount == 0 ? 0 : safeDiv(dbResult.AgeGroup8Count * 100.0, genderAgeGroups.Where(x => x.AgeGroup == 8).SumOrDefault(x => (decimal)x.Count))));
            result.GroupedByAgePercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup9Title, dbResult.TotalCount == 0 ? 0 : safeDiv(dbResult.AgeGroup9Count * 100.0, genderAgeGroups.Where(x => x.AgeGroup == 9).SumOrDefault(x => (decimal)x.Count))));

            result.MaleAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup1Title, dbResult.TotalCount == 0 ? 0 : safeDiv(dbResult.MaleAgeGroup1Count * 100.0, genderAgeGroups.Where(x => x.AgeGroup == 1 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.Count))));
            result.MaleAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup2Title, dbResult.TotalCount == 0 ? 0 : safeDiv(dbResult.MaleAgeGroup2Count * 100.0, genderAgeGroups.Where(x => x.AgeGroup == 2 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.Count))));
            result.MaleAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup3Title, dbResult.TotalCount == 0 ? 0 : safeDiv(dbResult.MaleAgeGroup3Count * 100.0, genderAgeGroups.Where(x => x.AgeGroup == 3 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.Count))));
            result.MaleAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup4Title, dbResult.TotalCount == 0 ? 0 : safeDiv(dbResult.MaleAgeGroup4Count * 100.0, genderAgeGroups.Where(x => x.AgeGroup == 4 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.Count))));
            result.MaleAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup5Title, dbResult.TotalCount == 0 ? 0 : safeDiv(dbResult.MaleAgeGroup5Count * 100.0, genderAgeGroups.Where(x => x.AgeGroup == 5 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.Count))));
            result.MaleAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup6Title, dbResult.TotalCount == 0 ? 0 : safeDiv(dbResult.MaleAgeGroup6Count * 100.0, genderAgeGroups.Where(x => x.AgeGroup == 6 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.Count))));
            result.MaleAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup7Title, dbResult.TotalCount == 0 ? 0 : safeDiv(dbResult.MaleAgeGroup7Count * 100.0, genderAgeGroups.Where(x => x.AgeGroup == 7 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.Count))));
            result.MaleAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup8Title, dbResult.TotalCount == 0 ? 0 : safeDiv(dbResult.MaleAgeGroup8Count * 100.0, genderAgeGroups.Where(x => x.AgeGroup == 8 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.Count))));
            result.MaleAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup9Title, dbResult.TotalCount == 0 ? 0 : safeDiv(dbResult.MaleAgeGroup9Count * 100.0, genderAgeGroups.Where(x => x.AgeGroup == 9 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.Count))));

            result.FemaleAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup1Title, dbResult.TotalCount == 0 ? 0 : safeDiv(dbResult.FemaleAgeGroup1Count * 100.0, genderAgeGroups.Where(x => x.AgeGroup == 1 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.Count))));
            result.FemaleAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup2Title, dbResult.TotalCount == 0 ? 0 : safeDiv(dbResult.FemaleAgeGroup2Count * 100.0, genderAgeGroups.Where(x => x.AgeGroup == 2 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.Count))));
            result.FemaleAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup3Title, dbResult.TotalCount == 0 ? 0 : safeDiv(dbResult.FemaleAgeGroup3Count * 100.0, genderAgeGroups.Where(x => x.AgeGroup == 3 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.Count))));
            result.FemaleAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup4Title, dbResult.TotalCount == 0 ? 0 : safeDiv(dbResult.FemaleAgeGroup4Count * 100.0, genderAgeGroups.Where(x => x.AgeGroup == 4 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.Count))));
            result.FemaleAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup5Title, dbResult.TotalCount == 0 ? 0 : safeDiv(dbResult.FemaleAgeGroup5Count * 100.0, genderAgeGroups.Where(x => x.AgeGroup == 5 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.Count))));
            result.FemaleAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup6Title, dbResult.TotalCount == 0 ? 0 : safeDiv(dbResult.FemaleAgeGroup6Count * 100.0, genderAgeGroups.Where(x => x.AgeGroup == 6 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.Count))));
            result.FemaleAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup7Title, dbResult.TotalCount == 0 ? 0 : safeDiv(dbResult.FemaleAgeGroup7Count * 100.0, genderAgeGroups.Where(x => x.AgeGroup == 7 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.Count))));
            result.FemaleAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup8Title, dbResult.TotalCount == 0 ? 0 : safeDiv(dbResult.FemaleAgeGroup8Count * 100.0, genderAgeGroups.Where(x => x.AgeGroup == 8 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.Count))));
            result.FemaleAgeGroupsPercent.Add(new KeyValuePair<string, double>(dbResult.AgeGroup9Title, dbResult.TotalCount == 0 ? 0 : safeDiv(dbResult.FemaleAgeGroup9Count * 100.0, genderAgeGroups.Where(x => x.AgeGroup == 9 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.Count))));

            #endregion

            #region درصد و تعداد موارد مثبت به تفکیک نوع بیماری

            XmlDocument xDiseaseDoc = new XmlDocument();
            xDiseaseDoc.LoadXml(dbResult.DiseaseGroups);
            int total = 0;
            foreach (XmlNode item in xDiseaseDoc.DocumentElement.ChildNodes)
            {
                int groupCount = int.Parse(item.SelectSingleNode("c").InnerText);
                total += groupCount;
            }
            foreach (XmlNode item in xDiseaseDoc.DocumentElement.ChildNodes)
            {
                string groupTitle = fnDiseaseTitle(item.SelectSingleNode("n"));
                int groupCount = int.Parse(item.SelectSingleNode("c").InnerText);

                result.GroupedByDisease.Add(new KeyValuePair<string, int>(groupTitle, groupCount));
                result.GroupedByDiseasePercent.Add(new KeyValuePair<string, double>(groupTitle, groupCount * 100.0 / dbResult.PositiveCount));
            }

            #endregion

            #region بیماری به تفکیک سن

            // xDoc = new XmlDocument();
            // if (!string.IsNullOrEmpty(dbResult.DiseaseAgeGroups))
            // {
            //     xDoc.LoadXml(dbResult.DiseaseAgeGroups);
            //     foreach (XmlNode item in xDoc.DocumentElement.ChildNodes)
            //     {
            //         string ageGroupTitle = item.SelectSingleNode("a").InnerText;
            //         if (string.IsNullOrEmpty(ageGroupTitle))
            //             continue;
            //         int ageGroup = int.Parse(ageGroupTitle);
            //         int count = int.Parse(item.SelectSingleNode("c").InnerText);
            //         string title = fnDiseaseTitle(item.SelectSingleNode("n"));
            // 
            //         var pItem = result.DiseaseAgeGroup.FirstOrDefault(x => x.Title == title);
            //         var pItemPercent = result.DiseaseAgeGroupPercent.FirstOrDefault(x => x.Title == title);
            //         var pItemPercentInTheSameAge = result.DiseaseAgeGroupPercentInTheSameAge.FirstOrDefault(x => x.Title == title); // به تفکیک سن در همان گروه سنی
            //         if (pItem == null)
            //         {
            //             pItem = new BusinessModel.Statistics.AgeGroup()
            //             {
            //                 Title = title,
            //                 Values = new List<decimal>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            //             };
            //             result.DiseaseAgeGroup.Add(pItem);
            // 
            //             pItemPercent = new BusinessModel.Statistics.AgeGroup()
            //             {
            //                 Title = title,
            //                 Values = new List<decimal>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            //             };
            //             result.DiseaseAgeGroupPercent.Add(pItemPercent);
            // 
            //             // به تفکیک سن در همان گروه سنی
            //             pItemPercentInTheSameAge = new BusinessModel.Statistics.AgeGroup()
            //             {
            //                 Title = title,
            //                 Values = new List<decimal>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            //             };
            //             result.DiseaseAgeGroupPercentInTheSameAge.Add(pItemPercentInTheSameAge); // به تفکیک سن در همان گروه سنی
            //         }
            //         pItem.Values[ageGroup - 1] = count;
            //         pItemPercent.Values[ageGroup - 1] = dbResult.PositiveCount == 0 ? 0 : (decimal)safeDiv(count * 100, dbResult.PositiveCount);
            // 
            //         // به تفکیک سن در همان گروه سنی
            //         pItemPercentInTheSameAge.Values[ageGroup - 1] = dbResult.PositiveCount == 0 ? 0 : (decimal)safeDiv(count * 100, genderAgeGroups.Where(x => x.AgeGroup == ageGroup).SumOrDefault(x => (decimal)x.Count));
            //     }
            // }

            #endregion

            #region بیماری به تفکیک جنسیت

            // if (!string.IsNullOrEmpty(dbResult.DiseaseGenderGroups))
            // {
            //     xDoc = new XmlDocument();
            //     xDoc.LoadXml(dbResult.DiseaseGenderGroups);
            //     foreach (XmlNode item in xDoc.DocumentElement.ChildNodes)
            //     {
            //         var gender = (BusinessModel.Service.Gender)int.Parse(item.SelectSingleNode("g").InnerText);
            //         int count = int.Parse(item.SelectSingleNode("c").InnerText);
            //         string title = fnDiseaseTitle(item.SelectSingleNode("n"));
            // 
            //         var pItem = result.DiseaseGenderGroup.FirstOrDefault(x => x.Title == title);
            //         var pItemPercent = result.DiseaseGenderGroupPercent.FirstOrDefault(x => x.Title == title);
            //         var pItemPercentInTheSameAge = result.DiseaseGenderGroupPercentInTheSameGender.FirstOrDefault(x => x.Title == title);
            //         if (pItem == null)
            //         {
            //             pItem = new BusinessModel.Statistics.AgeGroup()
            //             {
            //                 Title = title,
            //                 Values = new List<decimal>() { 0, 0 }
            //             };
            //             result.DiseaseGenderGroup.Add(pItem);
            // 
            //             pItemPercent = new BusinessModel.Statistics.AgeGroup()
            //             {
            //                 Title = title,
            //                 Values = new List<decimal>() { 0, 0 }
            //             };
            //             result.DiseaseGenderGroupPercent.Add(pItemPercent);
            // 
            //             pItemPercentInTheSameAge = new BusinessModel.Statistics.AgeGroup()
            //             {
            //                 Title = title,
            //                 Values = new List<decimal>() { 0, 0 }
            //             };
            //             result.DiseaseGenderGroupPercentInTheSameGender.Add(pItemPercentInTheSameAge);
            //         }
            //         pItem.Values[gender == BusinessModel.Service.Gender.Male ? 0 : 1] = count;
            //         pItemPercent.Values[gender == BusinessModel.Service.Gender.Male ? 0 : 1] = (decimal)safeDiv(count * 100, dbResult.PositiveCount);
            //         pItemPercentInTheSameAge.Values[gender == BusinessModel.Service.Gender.Male ? 0 : 1] = (decimal)safeDiv(count * 100, genderAgeGroups.Where(x => x.Gender == gender).SumOrDefault(x => (decimal)x.Count));
            //     }
            // }

            #endregion

            #region بیماری به تفکیک جنسیت و سن

            List<EpidemicMaxHelperModel> diseaseAgeGenderGroupHelper = new List<EpidemicMaxHelperModel>();

            if (!string.IsNullOrEmpty(dbResult.DiseaseAgeGenderGroups))
            {
                xDoc = new XmlDocument();
                xDoc.LoadXml(dbResult.DiseaseAgeGenderGroups);
                foreach (XmlNode item in xDoc.DocumentElement.ChildNodes)
                {
                    string ageGroupTitle = item.SelectSingleNode("a").InnerText;
                    if (string.IsNullOrEmpty(ageGroupTitle))
                        continue;
                    int ageGroup = int.Parse(ageGroupTitle);

                    var gender = (BusinessModel.Service.Gender)int.Parse(item.SelectSingleNode("g").InnerText);
                    int count = int.Parse(item.SelectSingleNode("c").InnerText);
                    string title = fnDiseaseTitle(item.SelectSingleNode("n"));

                    diseaseAgeGenderGroupHelper.Add(new EpidemicMaxHelperModel()
                    {
                        AgeGroup = ageGroup,
                        Count = count,
                        DiseaseName = title,
                        Gender = gender
                    });

                }
            }
            var diseaseItems = diseaseAgeGenderGroupHelper.GroupBy(x => x.DiseaseName).ToList();
            foreach (var diseaseItem in diseaseItems)
            {
                var groupItems = diseaseItem.ToList();

                #region بیماری به تفکیک سن و جنسیت

                var pItem = new BusinessModel.Statistics.DiseaseGenderAgeGroup()
                {
                    DiseaseName = diseaseItem.Key
                };
                var pItemPercent = new BusinessModel.Statistics.DiseaseGenderAgeGroup()
                {
                    DiseaseName = diseaseItem.Key
                };
                var pItemPercentInTheSameGenderAgeGroup = new BusinessModel.Statistics.DiseaseGenderAgeGroup()
                {
                    DiseaseName = diseaseItem.Key
                };
                for (int i = 1; i <= 9; i++)
                {
                    var ageItem = new BusinessModel.Statistics.AgeGroup()
                    {
                        Title = i.ToString(),
                        Values = new List<decimal>() { 
                            groupItems.Where(x => x.AgeGroup == i && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.Count),
                            groupItems.Where(x => x.AgeGroup == i && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.Count)
                        }
                    };
                    pItem.Data.Add(ageItem);
                    pItemPercent.Data.Add(new BusinessModel.Statistics.AgeGroup()
                    {
                        Title = i.ToString(),
                        Values = new List<decimal>() {
                            (decimal)safeDiv((double)ageItem.Values[0] * 100.0, dbResult.PositiveCount),
                            (decimal)safeDiv((double)ageItem.Values[1] * 100.0, dbResult.PositiveCount)
                        }
                    });
                    pItemPercentInTheSameGenderAgeGroup.Data.Add(new BusinessModel.Statistics.AgeGroup()
                    {
                        Title = i.ToString(),
                        Values = new List<decimal>() {
                            (decimal)safeDiv((double)ageItem.Values[0] * 100.0, genderAgeGroups.Where(x => x.Gender == BusinessModel.Service.Gender.Male && x.AgeGroup == i).SumOrDefault(x => (decimal)x.Count)),
                            (decimal)safeDiv((double)ageItem.Values[1] * 100.0, genderAgeGroups.Where(x => x.Gender == BusinessModel.Service.Gender.Female && x.AgeGroup == i).SumOrDefault(x => (decimal)x.Count))
                        }
                    });
                }
                result.DiseaseGenderAgeGroup.Add(pItem);
                result.DiseaseGenderAgeGroupPercent.Add(pItemPercent);
                result.DiseaseGenderAgeGroupPercentInTheSameGenderAgeGroup.Add(pItemPercentInTheSameGenderAgeGroup);

                #endregion


                #region بیماری به تفکیک سن

                pItem = new BusinessModel.Statistics.DiseaseGenderAgeGroup()
                {
                    DiseaseName = diseaseItem.Key
                };
                pItemPercent = new BusinessModel.Statistics.DiseaseGenderAgeGroup()
                {
                    DiseaseName = diseaseItem.Key
                };
                pItemPercentInTheSameGenderAgeGroup = new BusinessModel.Statistics.DiseaseGenderAgeGroup()
                {
                    DiseaseName = diseaseItem.Key
                };
                for (int i = 1; i <= 9; i++)
                {
                    var ageItem = new BusinessModel.Statistics.AgeGroup()
                    {
                        Title = i.ToString(),
                        Value = groupItems.Where(x => x.AgeGroup == i).SumOrDefault(x => (decimal)x.Count)
                    };
                    pItem.Data.Add(ageItem);
                    pItemPercent.Data.Add(new BusinessModel.Statistics.AgeGroup()
                    {
                        Title = i.ToString(),
                        Value = (decimal)safeDiv((double)ageItem.Value * 100.0, dbResult.PositiveCount)
                    });
                    pItemPercentInTheSameGenderAgeGroup.Data.Add(new BusinessModel.Statistics.AgeGroup()
                    {
                        Title = i.ToString(),
                        Value = (decimal)safeDiv((double)ageItem.Value * 100.0, genderAgeGroups.Where(x => x.AgeGroup == i).SumOrDefault(x => (decimal)x.Count))
                    });
                }
                result.DiseaseAgeGroup.Add(pItem);
                result.DiseaseAgeGroupPercent.Add(pItemPercent);
                result.DiseaseAgeGroupPercentInTheSameAge.Add(pItemPercentInTheSameGenderAgeGroup);

                #endregion


                #region بیماری به تفکیک جنسیت

                pItem = new BusinessModel.Statistics.DiseaseGenderAgeGroup()
                {
                    DiseaseName = diseaseItem.Key
                };
                pItemPercent = new BusinessModel.Statistics.DiseaseGenderAgeGroup()
                {
                    DiseaseName = diseaseItem.Key
                };
                pItemPercentInTheSameGenderAgeGroup = new BusinessModel.Statistics.DiseaseGenderAgeGroup()
                {
                    DiseaseName = diseaseItem.Key
                };
                for (int i = 1; i <= 2; i++)
                {
                    var gender = (BusinessModel.Service.Gender)i;

                    var ageItem = new BusinessModel.Statistics.AgeGroup()
                    {
                        Title = i.ToString(),
                        Value = groupItems.Where(x => x.Gender == gender).SumOrDefault(x => (decimal)x.Count)
                    };
                    pItem.Data.Add(ageItem);
                    pItemPercent.Data.Add(new BusinessModel.Statistics.AgeGroup()
                    {
                        Title = i.ToString(),
                        Value = (decimal)safeDiv((double)ageItem.Value * 100.0, dbResult.PositiveCount)
                    });
                    pItemPercentInTheSameGenderAgeGroup.Data.Add(new BusinessModel.Statistics.AgeGroup()
                    {
                        Title = i.ToString(),
                        Value = (decimal)safeDiv((double)ageItem.Value * 100.0, genderAgeGroups.Where(x => x.Gender == gender).SumOrDefault(x => (decimal)x.Count))
                    });
                }
                result.DiseaseGenderGroup.Add(pItem);
                result.DiseaseGenderGroupPercent.Add(pItemPercent);
                result.DiseaseGenderGroupPercentInTheSameGender.Add(pItemPercentInTheSameGenderAgeGroup);

                #endregion

            }



            #endregion

            #region اعداد کمکی برای محاسبه فوت شده ها به تفکیک جنسیت، سن و بیماری

            var cfrData = new List<CFRHelperModel>();
            if (!string.IsNullOrEmpty(dbResult.DiedDiseaseAgeGenderGroups))
            {
                xDoc = new XmlDocument();
                xDoc.LoadXml(dbResult.DiedDiseaseAgeGenderGroups);
                foreach (XmlNode item in xDoc.DocumentElement.ChildNodes)
                {
                    string ageGroupTitle = item.SelectSingleNode("a").InnerText; // AgeGroup
                    if (string.IsNullOrEmpty(ageGroupTitle))
                        continue;
                    int ageGroup = int.Parse(ageGroupTitle);

                    var gender = (BusinessModel.Service.Gender)int.Parse(item.SelectSingleNode("g").InnerText); // GenderID
                    int diedCount = int.Parse(item.SelectSingleNode("d").InnerText); // DiedCount
                    int positiveCount = int.Parse(item.SelectSingleNode("c").InnerText); // PositiveCount
                    string title = fnDiseaseTitle(item.SelectSingleNode("n")); // DiseaseName

                    cfrData.Add(new CFRHelperModel()
                    {
                        AgeGroup = ageGroup,
                        DiseaseName = title,
                        Gender = gender,
                        DiedCount = diedCount,
                        PositiveCount = positiveCount
                    });
                }
            }


            #endregion

            #region کشندگی سندروم

            List<CFRHelperModel> syndromCfrData = new List<CFRHelperModel>();
            if (!string.IsNullOrEmpty(dbResult.SyndromCFR))
            {
                xDoc = new XmlDocument();
                xDoc.LoadXml(dbResult.SyndromCFR);
                foreach (XmlNode item in xDoc.DocumentElement.ChildNodes)
                {
                    string ageGroupTitle = item.SelectSingleNode("a").InnerText; // AgeGroup
                    if (string.IsNullOrEmpty(ageGroupTitle))
                        continue;
                    int ageGroup = int.Parse(ageGroupTitle);

                    var gender = (BusinessModel.Service.Gender)int.Parse(item.SelectSingleNode("g").InnerText); // GenderID
                    int diedCount = int.Parse(item.SelectSingleNode("d").InnerText); // DiedCount
                    int count = int.Parse(item.SelectSingleNode("c").InnerText); // PositiveCount

                    syndromCfrData.Add(new CFRHelperModel()
                    {
                        AgeGroup = ageGroup,
                        Gender = gender,
                        DiedCount = diedCount,
                        Count = count
                    });
                }
            }

            // میزان کشندگی سندروم
            result.SyndromCFR = new List<AgeGroup>() {
                new AgeGroup()
                {
                    Values = new List<decimal>(){
                        (decimal)safeDiv((double)syndromCfrData.Where(x => x.AgeGroup == 1 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.DiedCount) * 100, syndromCfrData.Where(x => x.AgeGroup == 1 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.Count)),
                        (decimal)safeDiv((double)syndromCfrData.Where(x => x.AgeGroup == 1 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.DiedCount) * 100, syndromCfrData.Where(x => x.AgeGroup == 1 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.Count)),
                    }
                },
                new AgeGroup()
                {
                    Values = new List<decimal>(){
                        (decimal)safeDiv((double)syndromCfrData.Where(x => x.AgeGroup == 2 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.DiedCount) * 100, syndromCfrData.Where(x => x.AgeGroup == 2 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.Count)),
                        (decimal)safeDiv((double)syndromCfrData.Where(x => x.AgeGroup == 2 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.DiedCount) * 100, syndromCfrData.Where(x => x.AgeGroup == 2 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.Count)),
                    }
                },
                new AgeGroup()
                {
                    Values = new List<decimal>(){
                        (decimal)safeDiv((double)syndromCfrData.Where(x => x.AgeGroup == 3 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.DiedCount) * 100, syndromCfrData.Where(x => x.AgeGroup == 3 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.Count)),
                        (decimal)safeDiv((double)syndromCfrData.Where(x => x.AgeGroup == 3 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.DiedCount) * 100, syndromCfrData.Where(x => x.AgeGroup == 3 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.Count)),
                    }
                },
                new AgeGroup()
                {
                    Values = new List<decimal>(){
                        (decimal)safeDiv((double)syndromCfrData.Where(x => x.AgeGroup == 4 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.DiedCount) * 100, syndromCfrData.Where(x => x.AgeGroup == 4 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.Count)),
                        (decimal)safeDiv((double)syndromCfrData.Where(x => x.AgeGroup == 4 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.DiedCount) * 100, syndromCfrData.Where(x => x.AgeGroup == 4 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.Count)),
                    }
                },
                new AgeGroup()
                {
                    Values = new List<decimal>(){
                        (decimal)safeDiv((double)syndromCfrData.Where(x => x.AgeGroup == 5 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.DiedCount) * 100, syndromCfrData.Where(x => x.AgeGroup == 5 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.Count)),
                        (decimal)safeDiv((double)syndromCfrData.Where(x => x.AgeGroup == 5 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.DiedCount) * 100, syndromCfrData.Where(x => x.AgeGroup == 5 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.Count)),
                    }
                },
                new AgeGroup()
                {
                    Values = new List<decimal>(){
                    (decimal)safeDiv((double)syndromCfrData.Where(x => x.AgeGroup == 6 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.DiedCount) * 100, syndromCfrData.Where(x => x.AgeGroup == 6 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.Count)),
                    (decimal)safeDiv((double)syndromCfrData.Where(x => x.AgeGroup == 6 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.DiedCount) * 100, syndromCfrData.Where(x => x.AgeGroup == 6 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.Count)),
                }
                },
                new AgeGroup()
                {
                    Values = new List<decimal>(){
                        (decimal)safeDiv((double)syndromCfrData.Where(x => x.AgeGroup == 7 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.DiedCount) * 100, syndromCfrData.Where(x => x.AgeGroup == 7 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.Count)),
                        (decimal)safeDiv((double)syndromCfrData.Where(x => x.AgeGroup == 7 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.DiedCount) * 100, syndromCfrData.Where(x => x.AgeGroup == 7 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.Count)),
                    }
                },
                new AgeGroup()
                {
                    Values = new List<decimal>(){
                        (decimal)safeDiv((double)syndromCfrData.Where(x => x.AgeGroup == 8 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.DiedCount) * 100, syndromCfrData.Where(x => x.AgeGroup == 8 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.Count)),
                        (decimal)safeDiv((double)syndromCfrData.Where(x => x.AgeGroup == 8 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.DiedCount) * 100, syndromCfrData.Where(x => x.AgeGroup == 8 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.Count)),
                    }
                },
                new AgeGroup()
                {
                    Values = new List<decimal>(){
                        (decimal)safeDiv((double)syndromCfrData.Where(x => x.AgeGroup == 9 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.DiedCount) * 100, syndromCfrData.Where(x => x.AgeGroup == 9 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.Count)),
                        (decimal)safeDiv((double)syndromCfrData.Where(x => x.AgeGroup == 9 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.DiedCount) * 100, syndromCfrData.Where(x => x.AgeGroup == 9 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.Count))                 
                    }
                }
            };

            #endregion

            #region کشندگی فوت شده ها به تفکیک جنسیت

            var disGroups = cfrData.GroupBy(x => x.DiseaseName).ToList();
            foreach (var disGroup in disGroups)
            {
                // به تفکیک جنسیت
                result.CFR_DiedDiseaseGender.Add(new DiseaseGenderAgeGroup()
                {
                    DiseaseName = disGroup.Key,
                    Data = new List<AgeGroup>()
                     {
                         new AgeGroup(){
                            Values = new List<decimal>(){
                                (decimal)safeDiv((double)disGroup.Where(x => x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.DiedCount) * 100, disGroup.Where(x => x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.PositiveCount)),
                                (decimal)safeDiv((double)disGroup.Where(x => x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.DiedCount) * 100, disGroup.Where(x => x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.PositiveCount)),
                            } 
                        }
                     }
                });
                // به تفکیک سن
                result.CFR_DiedDiseaseAgeGroup.Add(new DiseaseGenderAgeGroup()
                {
                    DiseaseName = disGroup.Key,
                    Data = new List<AgeGroup>()
                     {
                         new AgeGroup(){
                            Values = new List<decimal>(){
                                (decimal)safeDiv((double)disGroup.Where(x => x.AgeGroup == 1).SumOrDefault(x => (decimal)x.DiedCount) * 100, disGroup.Where(x => x.AgeGroup == 1).SumOrDefault(x => (decimal)x.PositiveCount)),
                                (decimal)safeDiv((double)disGroup.Where(x => x.AgeGroup == 2).SumOrDefault(x => (decimal)x.DiedCount) * 100, disGroup.Where(x => x.AgeGroup == 2).SumOrDefault(x => (decimal)x.PositiveCount)),
                                (decimal)safeDiv((double)disGroup.Where(x => x.AgeGroup == 3).SumOrDefault(x => (decimal)x.DiedCount) * 100, disGroup.Where(x => x.AgeGroup == 3).SumOrDefault(x => (decimal)x.PositiveCount)),
                                (decimal)safeDiv((double)disGroup.Where(x => x.AgeGroup == 4).SumOrDefault(x => (decimal)x.DiedCount) * 100, disGroup.Where(x => x.AgeGroup == 4).SumOrDefault(x => (decimal)x.PositiveCount)),
                                (decimal)safeDiv((double)disGroup.Where(x => x.AgeGroup == 5).SumOrDefault(x => (decimal)x.DiedCount) * 100, disGroup.Where(x => x.AgeGroup == 5).SumOrDefault(x => (decimal)x.PositiveCount)),
                                (decimal)safeDiv((double)disGroup.Where(x => x.AgeGroup == 6).SumOrDefault(x => (decimal)x.DiedCount) * 100, disGroup.Where(x => x.AgeGroup == 6).SumOrDefault(x => (decimal)x.PositiveCount)),
                                (decimal)safeDiv((double)disGroup.Where(x => x.AgeGroup == 7).SumOrDefault(x => (decimal)x.DiedCount) * 100, disGroup.Where(x => x.AgeGroup == 7).SumOrDefault(x => (decimal)x.PositiveCount)),
                                (decimal)safeDiv((double)disGroup.Where(x => x.AgeGroup == 8).SumOrDefault(x => (decimal)x.DiedCount) * 100, disGroup.Where(x => x.AgeGroup == 8).SumOrDefault(x => (decimal)x.PositiveCount)),
                                (decimal)safeDiv((double)disGroup.Where(x => x.AgeGroup == 9).SumOrDefault(x => (decimal)x.DiedCount) * 100, disGroup.Where(x => x.AgeGroup == 9).SumOrDefault(x => (decimal)x.PositiveCount))
                            } 
                        }
                     }
                });
                // به تفکیک سن و جسن
                result.CFR_DiedDiseaseGenderAgeGroup.Add(new DiseaseGenderAgeGroup()
                {
                    DiseaseName = disGroup.Key,
                    Data = new List<AgeGroup>()
                     {
                         new AgeGroup(){
                            Values = new List<decimal>(){
                                (decimal)safeDiv((double)disGroup.Where(x => x.AgeGroup == 1 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.DiedCount) * 100, disGroup.Where(x => x.AgeGroup == 1 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.PositiveCount)),
                                (decimal)safeDiv((double)disGroup.Where(x => x.AgeGroup == 1 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.DiedCount) * 100, disGroup.Where(x => x.AgeGroup == 1 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.PositiveCount)),
                            }
                         },
                         new AgeGroup(){
                            Values = new List<decimal>(){
                                (decimal)safeDiv((double)disGroup.Where(x => x.AgeGroup == 2 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.DiedCount) * 100, disGroup.Where(x => x.AgeGroup == 2 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.PositiveCount)),
                                (decimal)safeDiv((double)disGroup.Where(x => x.AgeGroup == 2 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.DiedCount) * 100, disGroup.Where(x => x.AgeGroup == 2 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.PositiveCount)),
                            }
                         },
                         new AgeGroup(){
                            Values = new List<decimal>(){
                                (decimal)safeDiv((double)disGroup.Where(x => x.AgeGroup == 3 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.DiedCount) * 100, disGroup.Where(x => x.AgeGroup == 3 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.PositiveCount)),
                                (decimal)safeDiv((double)disGroup.Where(x => x.AgeGroup == 3 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.DiedCount) * 100, disGroup.Where(x => x.AgeGroup == 3 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.PositiveCount)),
                            }
                         },
                         new AgeGroup(){
                            Values = new List<decimal>(){
                                (decimal)safeDiv((double)disGroup.Where(x => x.AgeGroup == 4 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.DiedCount) * 100, disGroup.Where(x => x.AgeGroup == 4 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.PositiveCount)),
                                (decimal)safeDiv((double)disGroup.Where(x => x.AgeGroup == 4 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.DiedCount) * 100, disGroup.Where(x => x.AgeGroup == 4 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.PositiveCount)),
                            }
                         },
                         new AgeGroup(){
                            Values = new List<decimal>(){
                                (decimal)safeDiv((double)disGroup.Where(x => x.AgeGroup == 5 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.DiedCount) * 100, disGroup.Where(x => x.AgeGroup == 5 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.PositiveCount)),
                                (decimal)safeDiv((double)disGroup.Where(x => x.AgeGroup == 5 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.DiedCount) * 100, disGroup.Where(x => x.AgeGroup == 5 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.PositiveCount)),
                            }
                         },
                         new AgeGroup(){
                            Values = new List<decimal>(){
                                (decimal)safeDiv((double)disGroup.Where(x => x.AgeGroup == 6 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.DiedCount) * 100, disGroup.Where(x => x.AgeGroup == 6 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.PositiveCount)),
                                (decimal)safeDiv((double)disGroup.Where(x => x.AgeGroup == 6 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.DiedCount) * 100, disGroup.Where(x => x.AgeGroup == 6 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.PositiveCount)),
                            }
                         },
                         new AgeGroup(){
                            Values = new List<decimal>(){
                                (decimal)safeDiv((double)disGroup.Where(x => x.AgeGroup == 7 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.DiedCount) * 100, disGroup.Where(x => x.AgeGroup == 7 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.PositiveCount)),
                                (decimal)safeDiv((double)disGroup.Where(x => x.AgeGroup == 7 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.DiedCount) * 100, disGroup.Where(x => x.AgeGroup == 7 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.PositiveCount)),
                            }
                         },
                         new AgeGroup(){
                            Values = new List<decimal>(){
                                (decimal)safeDiv((double)disGroup.Where(x => x.AgeGroup == 8 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.DiedCount) * 100, disGroup.Where(x => x.AgeGroup == 8 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.PositiveCount)),
                                (decimal)safeDiv((double)disGroup.Where(x => x.AgeGroup == 8 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.DiedCount) * 100, disGroup.Where(x => x.AgeGroup == 8 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.PositiveCount)),
                            }
                         },
                         new AgeGroup(){
                            Values = new List<decimal>(){
                                (decimal)safeDiv((double)disGroup.Where(x => x.AgeGroup == 9 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.DiedCount) * 100, disGroup.Where(x => x.AgeGroup == 9 && x.Gender == BusinessModel.Service.Gender.Male).SumOrDefault(x => (decimal)x.PositiveCount)),
                                (decimal)safeDiv((double)disGroup.Where(x => x.AgeGroup == 9 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.DiedCount) * 100, disGroup.Where(x => x.AgeGroup == 9 && x.Gender == BusinessModel.Service.Gender.Female).SumOrDefault(x => (decimal)x.PositiveCount))                 
                            }
                        }
                     }
                });
            }

            #endregion


            return result;
        }

        static double safeDiv(double a, double b)
        {
            if (b == 0)
                return 0;
            return a / b;
        }
        static double safeDiv(double a, decimal b)
        {
            if (b == 0)
                return 0;
            return a / (double)b;
        }
        static double safeDiv(double a, int b)
        {
            if (b == 0)
                return 0;
            return a / b;
        }
    }
}
