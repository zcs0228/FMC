using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FMC.EFDbModels
{
    public class BaseEntity : IEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}