using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public abstract int Id { get; set; }

        [Obsolete("Использование только для CSV")]
        public abstract void Deserialize(object[] values);

        [Obsolete("Использование только для CSV")]
        public abstract object[] Serialize();
    }
}
