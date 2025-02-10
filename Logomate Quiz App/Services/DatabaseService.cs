using SQLite;
using Logomate_Quiz_App.Models;

namespace Logomate_Quiz_App.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService()
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "quiz.db");
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Question>().Wait();
        }

        // Method to clear the database (need to be called in SeedData)
        public async Task ClearQuestionsAsync()
        {
            await _database.DeleteAllAsync<Question>();
        }

        public async Task<List<Question>> GetShuffledQuestionsAsync()
        {
            var questions = await _database.Table<Question>().ToListAsync();
            return questions.OrderBy(q => Guid.NewGuid()).ToList(); //  Randomize the list of questions
        }

        public Task<int> AddQuestionAsync(Question question)
        {
            return _database.InsertAsync(question);
        }
    }
}
