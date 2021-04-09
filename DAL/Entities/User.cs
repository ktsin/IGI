using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class User : BaseEntity
    {
        public User() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        [StringLength(32)]
        public string PasswordHash { get; set; }

        [CsvHelper.Configuration.Attributes.Format("dd.mm.yyyy")]
        public DateTime Born { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        public string PhotoPath { get; set; }

        public string Deliverydate { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string MobileNumber { get; set; }

        [Obsolete("Использование только для CSV")]
        public override void Deserialize(object[] values)
        {
            if (values.Length != 5)
            {
                throw new Exception($"Got {values.Length}, expected {5} values");
            }

            Id = (Int32)(Int64)values[0];
            FullName = (string)values[1];
            Login = (string)values[2];
            PasswordHash = (string)values[3];
            Born = DateTime.Parse((string)values[4]);
        }

        [Obsolete("Использование только для CSV")]
        public override object[] Serialize()
        {
            ArrayList list = new ArrayList(5)
            {
                $"'{Id}'",
                $"'{FullName}'",
                $"'{Login}'",
                $"'{PasswordHash}'",
                $"'{Born.ToShortDateString()}'"
            };
            return list.ToArray();
        }
    }
}
