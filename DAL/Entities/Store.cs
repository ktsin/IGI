using System;
using System.Collections;
using System.Globalization;

namespace DAL.Entities
{

    public class Store : BaseEntity
    {
        public Store() { }
        public override int Id { get; set; }
        public string Name { get; set; }

        public int OwnerId { get; set; }

        public string LabelPhotoPath { get; set; }

        public string Location { get; set; }

        public float Raiting { get; set; }

        [Obsolete("Использование только для CSV")]
        public override void Deserialize(object[] values)
        {
            if (values.Length != 4)
            {
                throw new Exception($"Got {values.Length}, expected {4} values");
            }

            unchecked
            {
                Id = (int)((Int64)values[0]);
                Name = (string)values[1];
                OwnerId = (int)((Int64)values[2]);
                Raiting = (float)((Double)values[3]);
            }
        }

        [Obsolete("Использование только для CSV")]
        public override object[] Serialize()
        {
            ArrayList list = new ArrayList()
            {
                $"'{Id}'",
                $"'{Name}'",
                $"'{OwnerId}'",
                $"'{Raiting.ToString(CultureInfo.InvariantCulture)}'"
            };
            return list.ToArray();
        }
    }
}
