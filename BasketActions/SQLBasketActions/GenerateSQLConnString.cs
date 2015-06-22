using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BenchMark.BasketActions
{
    class GenerateConString
    {
        internal static string GenerateConnectionString(Dictionary<string, string> conParameters)
        {
            StringBuilder conString = new StringBuilder();

            foreach (KeyValuePair<string, string> conP in conParameters)
            {
                conString = conString.Append(conP.Key.ToString() + " = ");
                conString = conString.Append(conP.Value.ToString() + ";");
            }

            return conString.ToString();
        }


    }
}
