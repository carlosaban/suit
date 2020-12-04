using SUIT.Security.BE;
using SUIT.Security.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SUIT;

namespace SUIT.Security.BL
{
    public class BL_Option
    {
        //
        public MySQLDatabase _database;
        public string connectionString;

        public List<BE_Option> GetOptionGeneral(BE_Option bE_Option)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Option(_database).GetOptionGeneral(bE_Option);
        }


        public BE_Option CreateOptionGeneral(BE_Option bE_Option)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Option(_database).CreateOptionGeneral(bE_Option);
        }

        public BE_Option UpdateOptionGeneral(BE_Option bE_Option)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Option(_database).UpdateOptionGeneral(bE_Option);
        }


        public int DeleteOptionGeneral(int optionId)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Option(_database).DeleteOptionGeneral(optionId);
        }


        public int ValidateOption(int optionId,string userName)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Option(_database).ValidateOption(optionId, userName);
        }

        public List<BE_Option> GetOptionMenuByUserName(string userName)
        {
            return GetOptionMenuByUserName(userName, true);
        }
        public List<BE_Option> GetOptionMenuByUserName(string userName, bool isMenu)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Option(_database).GetOptionMenuByUserName(userName , isMenu);
        }

        public BL_Option(string connectionString)
        {
            this.connectionString = connectionString;

        }
    }
}
