using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class BaseUser : BaseEntity
    {
        public override int Id { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }

        public override void Deserialize(object[] values)
        {
            throw new NotImplementedException();
        }

        public override object[] Serialize()
        {
            throw new NotImplementedException();
        }
    }
}
