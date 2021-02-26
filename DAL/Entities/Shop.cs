using System;
using System.Collections;
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
            if (values.Length != 4)
                throw new Exception($"Got {values.Length}, expected {4} values");
            unchecked
            {
                Id = (int)((Int64)values[0]);
                Name = (string)values[1];
                OwnerId = (int)((Int64)values[2]);
                Raiting = (float)((Double)values[3]);
            }
        }

        public override object[] Serialize()
        {
            ArrayList list = new ArrayList()
            {
                $"'{Id}'",
                $"'{Name}'",
                $"'{OwnerId}'",
                $"'{Raiting}'"
            };
            return list.ToArray();
        }
    }
}
