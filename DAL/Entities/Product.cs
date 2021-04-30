using System;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace DAL.Entities
{
    public class Product : BaseEntity
    {
        public Product() { }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        public float Price { get; set; }

        public int Discount { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public int ShopId { get; set; }

        public override void Deserialize(object[] values)
        {
            if (values.Length != 6)
            {
                throw new Exception($"Got {values.Length}, expected {5} values");
            }

            Id = (Int32)(Int64)values[0];
            Price = (float)(Double)values[1];
            Discount = (Int32)(Int64)values[2];
            Name = (string)values[3];
            ShortDescription = (string)values[4];
            ShopId = (Int32)(Int64)values[5];
        }

        public override object[] Serialize()
        {
            ArrayList list = new ArrayList()
            {
                $"'{Id}'",
                $"'{Price.ToString(CultureInfo.InvariantCulture)}'",
                $"'{Discount}'",
                $"'{Name}'",
                $"'{ShortDescription}'",
                $"'{ShopId}'"
            };
            return list.ToArray();
        }
    }
}
