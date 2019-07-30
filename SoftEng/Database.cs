using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace SoftEng
{

    class Database
    {
        public SQLiteConnection myConn;

        public Database()
        {
            myConn = new SQLiteConnection("Data Source=database.sqlite3");

            if (!File.Exists("./database.sqlite3"))
            {
                SQLiteConnection.CreateFile("database.sqlite3");
            }
            
        }

        public void OpenConnection()
        {
            if (myConn.State != System.Data.ConnectionState.Open)
            {
                myConn.Open();
            }
        }

        public void CloseConnection()
        {
            if (myConn.State != System.Data.ConnectionState.Closed)
            {
                myConn.Close();
            }
        }
    }
}
