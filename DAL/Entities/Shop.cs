using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{

    public class Shop : BaseEntity
    {
        public override int Id { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public float Raiting { get; set; }

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
