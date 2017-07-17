
/*
 * Author : Aron Sajan Philip
 * Class takes up the parameters for executing a stored procedure
 * */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataOperations.DBEngine
{
    public class Parameters:CollectionBase
    {
        public Parameter this[int Index]
        {
            get
            {
                return (List[Index] as Parameter);
            }
        }

        public void AddParameter(string ParameterName,object ParameterValue=null, DbType ParameterType=DbType.Int32)
        {
            Parameter NewParam = new Parameter();
            NewParam.ParameterName = ParameterName;
            NewParam.ParameterType = ParameterType;
            NewParam.ParameterValue = ParameterValue;
            List.Add(NewParam);
        }
    }
}
