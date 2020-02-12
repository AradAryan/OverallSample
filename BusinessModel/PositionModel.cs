using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel
{
    public class PositionModel
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }

        public List<PermissionModel> Permissions { get; set; }

        public PositionModel()
        {
            Permissions = new List<PermissionModel>();
        }
    }
}
