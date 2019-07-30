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
    public partial class quizForm : Form
    {

        public string UserName { get; set; }
        public List<Results> multChoice { get; set; }
        public List<Results> trueFalseQ { get; set; }
        public int Score { get; set; }


        public quizForm()
        {
            InitializeComponent();
            loadQuestions();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            checkCorrectness();
            insertDbRecord();
            this.Hide();
            resultsForm rf = new resultsForm();
            rf.Score = this.Score;
            rf.Show();
        }

        public void insertDbRecord()
        {
            Database dbObj = new Database();
            string query = "INSERT INTO Quizzes (`Name`, `Score`) VALUES (@Name, @Score)";
            SQLiteCommand myCommand = new SQLiteCommand(query, dbObj.myConn);
            dbObj.OpenConnection();
            myCommand.Parameters.AddWithValue("@Name", this.UserName);
            myCommand.Parameters.AddWithValue("@Score", this.Score.ToString());
            myCommand.ExecuteNonQuery();
            dbObj.CloseConnection();
        }

        public void loadQuestions()
        {
            List<string> questions = new List<string>();
            List<string> answers = new List<string>();

            foreach (Results r in multChoice)
            {
                questions.Add(r.question);
                answers.Add(r.correct_answer);
                answers.AddRange(r.incorrect_answers);
            }

            foreach (Results r in trueFalseQ)
            {
                questions.Add(r.question);
                answers.Add(r.correct_answer);
                answers.AddRange(r.incorrect_answers);
            }

            labelq1.Text = questions[0];
            labelq2.Text = questions[1];
            labelq3.Text = questions[2];
            labelq4.Text = questions[3];
            labelq5.Text = questions[4];
            labelq6.Text = questions[5];
            labelq7.Text = questions[6];
            labelq8.Text = questions[7];
            labelq9.Text = questions[8];
            labelq10.Text = questions[9];

            BindingSource bs1 = new BindingSource();
            bs1.DataSource = answers.GetRange(0, 4).OrderBy(a => rng.Next());
            comboBoxQ1.DataSource = bs1;

            BindingSource bs2 = new BindingSource();
            bs2.DataSource = answers.GetRange(4, 4).OrderBy(a => rng.Next());
            comboBoxQ2.DataSource = bs2;

            BindingSource bs3 = new BindingSource();
            bs3.DataSource = answers.GetRange(8, 4).OrderBy(a => rng.Next());
            comboBoxQ3.DataSource = bs3;

            BindingSource bs4 = new BindingSource();
            bs4.DataSource = answers.GetRange(12, 4).OrderBy(a => rng.Next());
            comboBoxQ4.DataSource = bs4;

            BindingSource bs5 = new BindingSource();
            bs5.DataSource = answers.GetRange(16, 4).OrderBy(a => rng.Next());
            comboBoxQ5.DataSource = bs5;

            BindingSource bs6 = new BindingSource();
            bs6.DataSource = answers.GetRange(20, 2).OrderBy(a => rng.Next());
            comboBoxQ6.DataSource = bs6;

            BindingSource bs7 = new BindingSource();
            bs7.DataSource = answers.GetRange(22, 2).OrderBy(a => rng.Next());
            comboBoxQ7.DataSource = bs7;

            BindingSource bs8 = new BindingSource();
            bs8.DataSource = answers.GetRange(24, 2).OrderBy(a => rng.Next());
            comboBoxQ8.DataSource = bs8;

            BindingSource bs9 = new BindingSource();
            bs9.DataSource = answers.GetRange(26, 2).OrderBy(a => rng.Next());
            comboBoxQ9.DataSource = bs9;

            BindingSource bs10 = new BindingSource();
            bs10.DataSource = answers.GetRange(28, 2).OrderBy(a => rng.Next());
            comboBoxQ10.DataSource = bs10;

        }

        private static Random rng = new Random();

        public void checkCorrectness()
        {
            Score = 0;

            List<string> correctAnswers = new List<string>();
            foreach (Results r in multChoice)
            {
                correctAnswers.Add(r.correct_answer);
            }
            foreach (Results r in trueFalseQ)
            {
                correctAnswers.Add(r.correct_answer);
            }

            if (comboBoxQ1.Text == correctAnswers[0])
                Score++;
            if (comboBoxQ2.Text == correctAnswers[1])
                Score++;
            if (comboBoxQ3.Text == correctAnswers[2])
                Score++;
            if (comboBoxQ4.Text == correctAnswers[3])
                Score++;
            if (comboBoxQ5.Text == correctAnswers[4])
                Score++;
            if (comboBoxQ6.Text == correctAnswers[5])
                Score++;
            if (comboBoxQ7.Text == correctAnswers[6])
                Score++;
            if (comboBoxQ8.Text == correctAnswers[7])
                Score++;
            if (comboBoxQ9.Text == correctAnswers[8])
                Score++;
            if (comboBoxQ10.Text == correctAnswers[9])
                Score++;
        }

    }
}
