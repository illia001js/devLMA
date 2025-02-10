using Logomate_Quiz_App.Models;

namespace Logomate_Quiz_App.Services
{
    public static class SeedData
    {
        public static async Task Initialize(DatabaseService database)
        {
            // Clearing the database before adding new questions (tests only)
            await database.ClearQuestionsAsync();

            var questions = await database.GetShuffledQuestionsAsync();
            if (questions.Count == 0)
            {
                await database.AddQuestionAsync(new Question
                {
                    Text = "Was passiert, wenn die Option „Heute bestellen“ ausgewählt wurde?",
                    Answer1 = "Bestellungen werden auf den heutigen Tag vorgezogen",
                    Answer2 = "Bestellmengen werden, wenn möglich, reduziert abhängig vom Bedarf",
                    Answer3 = "Es werden zusätzliche Bestellvorschläge für heute generiert",
                    CorrectAnswers = "Bestellungen werden auf den heutigen Tag vorgezogen| Bestellmengen werden, wenn möglich, reduziert abhängig vom Bedarf"
                });

                await database.AddQuestionAsync(new Question
                {
                    Text = "Welche Funktion hat der Planungshorizont?",
                    Answer1 = "Er zeigt den letzten Bestellvorschlag an",
                    Answer2 = "Er zeigt den Zeitraum an in dem Bestellvorschläge generiert werden können",
                    Answer3 = "Er zeigt den Zeitraum an in die Planwerte eingestellt wurden",
                    CorrectAnswers = "Er zeigt den Zeitraum an in dem Bestellvorschläge generiert werden können"
                });

                // After adding, updated questions are loadedы
                questions = await database.GetShuffledQuestionsAsync();
            }

        }
    }
}
