﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Product : BaseEntity
    {
        public override int Id { get; set; }

        public float Price { get; set; }

        public int Discount { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public int ShopId { get; set; }

        public override void Deserialize(object[] values)
        {
            if (values.Length != 6)
                throw new Exception($"Got {values.Length}, expected {5} values");
            Id = (int)values[0];
            Price = (float)values[1];
            Discount = (int)values[2];
            Name = (string)values[3];
            ShortDescription = (string)values[4];
            ShopId = (int)values[5];
        }

        public override object[] Serialize()
        {
            ArrayList list = new ArrayList(6)
            {
                [0] = $"'{Id}'",
                [1] = $"'{Price}'",
                [2] = $"'{Discount}'",
                [3] = $"'{Name}'",
                [4] = $"'{ShortDescription}'",
                [5] = $"'{ShopId}'"
            };
            return list.ToArray();
        }
    }
}
