/* Author: Aron Sajan Philip
 * Class serves as the "Helper Class" for the Student Module
 * */

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEntity.Utilities
{
    class Helper
    {
        public static string GetConfigValue(string Key)
        {
           return ConfigurationSettings.AppSettings[Key];
        }
    }
}
