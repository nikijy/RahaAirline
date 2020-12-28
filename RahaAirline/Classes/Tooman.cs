using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RahaAirline
{
    public static class Tooman
    {
        public static string ToTooman(this int value)
        {
            return value.ToString("#,0 تومان");
        }

    }
}