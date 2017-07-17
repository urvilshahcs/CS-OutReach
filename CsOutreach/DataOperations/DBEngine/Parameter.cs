
/*
 * Author : Aron Sajan Philip
 * Class defines Parameter elements
 * */
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataOperations.DBEngine
{
   public class Parameter
    {
        public string ParameterName
        {
            get;
            set;
        }

        public DbType ParameterType
        {
            get;
            set;
        }

        public object ParameterValue
        {
            get;
            set;
        }
    }
}
