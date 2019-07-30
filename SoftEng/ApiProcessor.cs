using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;


namespace SoftEng
{
    public class ApiProcessor
    {
        public static async Task<List<Results>> LoadQuiz(int category, string difficulty, string type)
        {
            string url = $"https://opentdb.com/api.php?amount=5&category={ category }&difficulty={ difficulty }&type={ type }".ToLower();

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    QuizModel quiz = await response.Content.ReadAsAsync<QuizModel>();

                    return quiz.results;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
