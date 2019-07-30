using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftEng
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();

        }

        private async void submitButton_Click(object sender, EventArgs e)
        {

            int categ = categoryFinder();
            var multiple = await ApiProcessor.LoadQuiz(categ, difficultyComboBox.Text, "multiple");
            var tf = await ApiProcessor.LoadQuiz(categ, difficultyComboBox.Text, "boolean");

            this.Hide();
            quizForm qf = new quizForm();
            qf.UserName = nameTextBox.Text;
            qf.multChoice = multiple;
            qf.trueFalseQ = tf;
            qf.Show();

        }

        public int categoryFinder()
        {
            int category = 0;

            switch (categoryComboBox.Text)
            {
                case "General Knowledge":
                    category = 9;
                    break;
                case "Entertainment: Books":
                    category = 10;
                    break;
                case "Entertainment: Film":
                    category = 11;
                    break;
                case "Entertainment: Music":
                    category = 12;
                    break;
                case "Entertainment: Musicals & Theatres":
                    category = 13;
                    break;
                case "Entertainment: Television":
                    category = 14;
                    break;
                case "Entertainment: Video Games":
                    category = 15;
                    break;
                case "Entertainment: Board Games":
                    category = 16;
                    break;
                case "Science & Nature":
                    category = 17;
                    break;
                case "Science: Computers":
                    category = 18;
                    break;
                case "Science: Mathematics":
                    category = 19;
                    break;
                case "Mythology":
                    category = 20;
                    break;
                case "Sports":
                    category = 21;
                    break;
                case "Geography":
                    category = 22;
                    break;
                case "History":
                    category = 23;
                    break;
                case "Politics":
                    category = 24;
                    break;
                case "Art":
                    category = 25;
                    break;
                case "Celebrities":
                    category = 26;
                    break;
                case "Animals":
                    category = 27;
                    break;
                case "Vehicles":
                    category = 28;
                    break;
                case "Entertainment: Comics":
                    category = 29;
                    break;
                case "Science: Gadgets":
                    category = 30;
                    break;
                case "Entertainment: Japanese Anime & Manga":
                    category = 31;
                    break;
                case "Entertainment: Cartoon & Animations":
                    category = 32;
                    break;
            }

            return category;
        }
    }
}
