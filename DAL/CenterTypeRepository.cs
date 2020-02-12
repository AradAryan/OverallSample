using BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class CenterTypeRepository : RepositoryBase<CenterType>
    {
        public CenterTypeRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }

        public List<CenterType> getChildOfNode(int id)
        {
            return _dataContext.GetChildrenOfCenterType(id).Select(x => new CenterType() { Id = x.Id, Name = x.Name, ParentId = x.ParentId, Special = x.Special, Type = x.Type, StructureOrder = x.StructureOrder,
                FieldOfView = x.FieldOfView, CenterTypeUniqId = x.CenterTypeUniqId }).ToList();
            //  _dataContext.CenterTypes.Where(x => x.ParentId == id).ToList();
        }

        public List<CenterType> getChildOfNodeBaseOnCorporateId(int CorporateId)
        {
            return _dataContext.GetChildrenOfCenterTypeBaseOnCorporateId(CorporateId).Select(x => new CenterType()
            {
                Id = x.Id,
                Name = x.Name,
                ParentId = x.ParentId,
                Special = x.Special,
                Type = x.Type,
                StructureOrder = x.StructureOrder,
                FieldOfView = x.FieldOfView,
                CenterTypeUniqId = x.CenterTypeUniqId
            }).ToList();
            //  _dataContext.CenterTypes.Where(x => x.ParentId == id).ToList();
        }

        public List<GetCenerList> GetCenterListForRegisterUser(string text, int CorporateId, int take)
        {
            return _dataContext.GetCenterListForRegisterUser(text, CorporateId, take).ToList();
            //  _dataContext.CenterTypes.Where(x => x.ParentId == id).ToList();
        }

        public bool? GetCorparateCenterType(int CorporateId)
        {
            return _dataContext.Corporates
                .Where(x => x.Id == CorporateId)
                .Join(_dataContext.CenterTypes, x => x.Id, y => y.Id, (x, y) => new  { SpecialCenterType = y.SpecialCenterType }).FirstOrDefault().SpecialCenterType;
        }
    }
}
