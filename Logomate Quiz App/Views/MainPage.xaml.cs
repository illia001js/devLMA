using Logomate_Quiz_App.Services;
using Logomate_Quiz_App.Models;

namespace Logomate_Quiz_App.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly DatabaseService _database;

        public MainPage()
        {
            InitializeComponent();
            _database = new DatabaseService();  // Initializing the database

            // Filling the database when the application starts
            Task.Run(async () => await SeedData.Initialize(_database)).Wait();
        }

        private async void OnStartQuizClicked(object sender, EventArgs e)
        {
            List<Question> questions = await _database.GetShuffledQuestionsAsync(); // Loading questions
            if (questions.Count == 0)
            {
                await DisplayAlert("Error", "No questions available!", "OK");
                return;
            }

            await Navigation.PushAsync(new QuizPage(questions)); // Submitting questions to QuizPage
        }
    }
}
