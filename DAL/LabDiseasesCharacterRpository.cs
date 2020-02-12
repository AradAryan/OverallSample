using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class LabDiseasesCharacterRpository : RepositoryBase<LabDiseasesCharacter>
    {
        public LabDiseasesCharacterRpository(SyndromeDBEntities Context)
        : base(Context)
       {

       }
    }
}
