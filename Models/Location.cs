using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Estore.Ce.Models;

namespace Estore.Ce.Models
{
    public class Location:BaseEntity
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
    }
}
