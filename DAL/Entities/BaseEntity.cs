using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public abstract class BaseEntity
    {
        public abstract int Id { get; set; }

        public abstract void Deserialize(object[] values);

        public abstract object[] Serialize();
    }
}
