/**
 * Author : Aron Sajan Philip
 * Class designed for Database related activities
 * */

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataOperations.DBEngine
{
    
    public class DBManager
    {
        Database Db;
        public DBManager()
        {
            if(Db==null)
            {

                Db = DatabaseFactory.CreateDatabase();
               
            }
        }

        public DataSet ExecuteReadSP(string SPName,Parameters SPParameters)
        {
            DataSet ResultSet = new DataSet();
            DbCommand Command = Db.GetStoredProcCommand(SPName);
           
            foreach(Parameter Param in SPParameters)
            {
                Db.AddInParameter(Command, Param.ParameterName, Param.ParameterType, Param.ParameterValue);
            }
           
            ResultSet = Db.ExecuteDataSet(Command);
            return ResultSet;
        }

        public DataSet ExecuteReadSP(string SPName)
        {
            DataSet ResultSet = new DataSet();
            DbCommand Command = Db.GetStoredProcCommand(SPName);
            ResultSet = Db.ExecuteDataSet(Command);
            return ResultSet;
        }

        public void ExecuteWriteSP(string SPName,Parameters SPParameters)
        {
            DbCommand Command = Db.GetStoredProcCommand(SPName);

            foreach (Parameter Param in SPParameters)
            {
                Db.AddInParameter(Command, Param.ParameterName, Param.ParameterType, Param.ParameterValue);
            }

            Db.ExecuteDataSet(Command);
        }

        public void ExecuteWriteSP(string SPName)
        {
            DbCommand Command = Db.GetStoredProcCommand(SPName);
            Db.ExecuteDataSet(Command);
        }

    }
}
