using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Estore.Ce.Models;
using Estore.Ce.Infrastructure.Repositories;

namespace Estore.Ce.Contracts
{
    public interface ILocationRepository : IBaseRepository<Location>
    {
        Location GetByLocationType(LocationType locationType);        
    }
}
