using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Estore.Ce.Models;
using Estore.Ce.LocationService;
using System.Data.SqlServerCe;

namespace Estore.Ce.Profiles
{
    public class LocationProfile
    {
        //No AutoMapper so manual mapping for now
        public Location Map(SqlCeDataReader reader)
        {
            try
            {
                Location location = new Location();
                location.LocationId = (int)reader["LocationId"];
                location.LocationName = reader["LocationName"].ToString();

                return location;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Location Map(LocationGetAllDto locationDto)
        {
            Location location = new Location()
            {
                LocationId = locationDto.LocationId,
                LocationName = locationDto.LocationName
            };

            return location;
        }
    }
}
