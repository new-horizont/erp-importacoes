using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primavera.Formularios.RH.Helpers
{
    public static class StringHelper
    {
        public static string StripAlpha(this string self)
        {
            return new string(self.Where(c => Char.IsLetter(c)).ToArray());
        }

        public static string StripNonNumeric(this string self)
        {
            string palavra = new string(self.Where(c => (Char.IsDigit(c) || c == '.' || c == ',')).ToArray()); return new string(self.Where(c => (Char.IsDigit(c) || c == '.' || c == ',')).ToArray());  // See Vlad's

        }

        public static string DaString(object s)
        {
            try
            {
                if (s is DBNull)
                {
                    return "";
                }
                else
                    return Convert.ToString(s);
            }
            catch
            {
                return "";
            }
            
        }

        public static Int32 DaInt32(object s)
        {
            try
            {
                if (s is DBNull)
                {
                    return 0;
                }
                else
                    return Convert.ToInt32(s);
            }
            catch
            {
                return -1;
            }
            
        }

        public static Double DaDouble(object s)
        {
            try
            {
                if (s is DBNull)
                {
                    return 0;
                }
                else
                    return Convert.ToDouble(s);
            }
            catch(Exception ex)
            {
                return -1;
            }
            
        }

        public static Decimal DaDecimal(object s)
        {
            if (s is DBNull)
            {
                return 0;
            }
            else
                return Convert.ToDecimal(s);
        }

        public static float DaFloat(object s)
        {
            if (s is DBNull)
            {
                return 0;
            }
            else
                return float.Parse(s.ToString());
        }
    }
}
