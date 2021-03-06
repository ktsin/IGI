﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

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
            Id = (Int32)(Int64)values[0];
            Buyer = (Int32)(Int64)values[1];
            ProductId = (Int32)(Int64)values[2];
            Count = (Int32)(Int64)values[3];
            Price = (float)(Double)values[4];
        }

        public override object[] Serialize()
        {
            ArrayList list = new ArrayList()
            {
                $"'{Id}'",
                $"'{Buyer}'",
                $"'{ProductId}'",
                $"'{Count}'",
                $"'{Price.ToString(CultureInfo.InvariantCulture)}'"
            };
            return list.ToArray();
        }
    }
}
