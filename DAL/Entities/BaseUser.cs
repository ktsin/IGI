using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class BaseUser : BaseEntity
    {
        public override int Id { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public DateTime Born { get; set; }

        public override void Deserialize(object[] values)
        {
            if (values.Length != 5)
                throw new Exception($"Got {values.Length}, expected {5} values");
            Id = (int)values[0];
            Name = (string)values[1];
            UserName = (string)values[2];
            PasswordHash = (string)values[3];
            Born = DateTime.Parse((string)values[4]);
        }

        public override object[] Serialize()
        {
            ArrayList list = new ArrayList(5)
            {
                [0] = $"'{Id}'",
                [1] = $"'{Name}'",
                [2] = $"'{UserName}'",
                [3] = $"'{PasswordHash}'",
                [4] = $"'{Born.ToShortDateString()}'"
            };
            return list.ToArray();
        }
    }
}
