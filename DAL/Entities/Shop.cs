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
            Id = (int)values[0];
            Name = (string)values[1];
            OwnerId = (int)values[2];
            Raiting = (float)values[3];
        }

        public override object[] Serialize()
        {
            ArrayList list = new ArrayList(4)
            {
                [0] = $"'{Id}'",
                [1] = $"'{Name}'",
                [2] = $"'{OwnerId}'",
                [3] = $"'{Raiting}'"
            };
            return list.ToArray();
        }
    }
}
