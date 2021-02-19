using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Order : BaseEntity
    {
        public override int Id { get; set; }

        public int Buyer { get; set; }

        public int ProductId { get; set; }

        public int Count { get; set; }

        public float Price { get; set; }

        public override void Deserialize(object[] values)
        {
            if (values.Length != 5)
                throw new Exception($"Got {values.Length}, expected {5} values");
            Id = (int)values[0];
            Buyer = (int)values[1];
            ProductId = (int)values[2];
            Count = (int)values[3];
            Price = (float)values[4];
        }

        public override object[] Serialize()
        {
            ArrayList list = new ArrayList(5)
            {
                [0] = $"'{Id}'",
                [1] = $"'{Buyer}'",
                [2] = $"'{ProductId}'",
                [3] = $"'{Count}'",
                [4] = $"'{Price}'"
            };
            return list.ToArray();
        }
    }
}
