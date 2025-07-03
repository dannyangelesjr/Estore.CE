using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Estore.Ce.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
