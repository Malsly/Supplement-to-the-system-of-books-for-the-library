using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Entities.Abs;

namespace Entities.Imp
{
    public class Accaunt: IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        [Required]
        public virtual Person Person { get; set; }
    }
}
