using Logomate_Quiz_App.Models;

namespace Logomate_Quiz_App.Views
{
    public partial class ResultsPage : ContentPage
    {
        public ResultsPage(List<List<string>> userAnswers, List<Question> questions)
        {
            InitializeComponent();
            ShowResults(userAnswers, questions);
        }

        private void ShowResults(List<List<string>> userAnswers, List<Question> questions)
        {
            ResultsLayout.Children.Clear();
            int correctCount = 0; // Counting correct answers

            for (int i = 0; i < questions.Count; i++)
            {
                var question = questions[i];
                var correctAnswers = question.CorrectAnswers.Split("| ").ToList();
                var userSelected = userAnswers[i];

                bool isCorrect = correctAnswers.All(userSelected.Contains) && correctAnswers.Count == userSelected.Count;
                if (isCorrect) correctCount++; // Increase the counter of correct answers

                var resultText = new Label
                {
                    Text = isCorrect ? "✅ True" : "❌ False",
                    TextColor = isCorrect ? Colors.Green : Colors.Red,
                    FontSize = 18
                };

                var questionText = new Label
                {
                    Text = $"Question {i + 1}: {question.Text}",
                    FontAttributes = FontAttributes.Bold
                };

                var userAnswerText = new Label
                {
                    Text = $"Your answer: {string.Join(", ", userSelected)}",
                    TextColor = Colors.Blue
                };

                var correctAnswerText = new Label
                {
                    Text = $"Right answer: {string.Join(", ", correctAnswers)}",
                    TextColor = Colors.Green
                };

                ResultsLayout.Children.Add(questionText);
                ResultsLayout.Children.Add(userAnswerText);
                ResultsLayout.Children.Add(correctAnswerText);
                ResultsLayout.Children.Add(resultText);
            }

            // Displaying the number of correct answers
            ScoreLabel.Text = $"Correct answers: {correctCount} / {questions.Count}";
        }

        private async void OnBackToStartClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync(); // Returns the user to the main page (MainPage)
        }
    }
}
