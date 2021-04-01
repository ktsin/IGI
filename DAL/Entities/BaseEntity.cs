using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
