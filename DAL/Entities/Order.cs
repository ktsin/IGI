using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Order : BaseEntity
    {
        public override int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
