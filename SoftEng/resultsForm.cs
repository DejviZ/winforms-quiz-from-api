using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace SoftEng
{
    public partial class resultsForm : Form
    {

        public int Score { get; set; }

        public resultsForm()
        {
            InitializeComponent();
            loadDataGridView();
            scoreLabel.Text = "The score is " + Score + "/10";
            danLabel.Text = "Dan rank: " + calcDan();

        }

        public void loadDataGridView()
        {
            DataSet DS = new DataSet();
            DataTable DT = new DataTable();
            Database dbObj = new Database();
            dbObj.OpenConnection();
            SQLiteCommand sql_cmd = dbObj.myConn.CreateCommand();
            string CommandText = "select * from Quizzes";
            SQLiteDataAdapter DB = new SQLiteDataAdapter(CommandText, dbObj.myConn);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            dataGridView1.DataSource = DT;
            dbObj.CloseConnection();
        }

        public string calcDan()
        {
            string dan = "";

            switch (Score)
            {
                case 1:
                    dan = "Shodan";
                    break;
                case 2:
                    dan = "Nidan";
                    break;
                case 3:
                    dan = "Sandan";
                    break;
                case 4:
                    dan = "Yondan";
                    break;
                case 5:
                    dan = "Godan";
                    break;
                case 6:
                    dan = "Rokudan";
                    break;
                case 7:
                    dan = "Shichidan";
                    break;
                case 8:
                    dan = "Hachidan";
                    break;
                case 9:
                    dan = "Kudan";
                    break;
                case 10:
                    dan = "Jūdan";
                    break;
            }

            return dan;
        }
    }
}
