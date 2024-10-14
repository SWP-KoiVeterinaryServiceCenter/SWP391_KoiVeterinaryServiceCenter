using Application.Util.UitlModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Util
{
    public static  class CalculateDistance
    {
        public static double CalculateDistanceByLatAndLong(Location loc1, Location loc2)
        {
            const double R = 6371; // Radius of the Earth in kilometers
            double lat1 = Convert.ToDouble(loc1.Lat);
            double lon1 = Convert.ToDouble(loc1.Lon);
            double lat2 = Convert.ToDouble(loc2.Lat);
            double lon2 = Convert.ToDouble(loc2.Lon);

            double dLat = DegreesToRadians(lat2 - lat1);
            double dLon = DegreesToRadians(lon2 - lon1);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(DegreesToRadians(lat1)) * Math.Cos(DegreesToRadians(lat2)) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return R * c; // Distance in kilometers
        }
        private static double DegreesToRadians(double degrees)
        {
            return degrees * (Math.PI / 180);
        }
    }
    }

