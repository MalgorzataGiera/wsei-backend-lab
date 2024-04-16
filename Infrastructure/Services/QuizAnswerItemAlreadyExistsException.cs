using System.Runtime.Serialization;

namespace Infrastructure.Services
{
    [Serializable]
    internal class QuizAnswerItemAlreadyExistsException : Exception
    {
        private int quizId;
        private int quizItemId;
        private int userId;

        public QuizAnswerItemAlreadyExistsException()
        {
        }

        public QuizAnswerItemAlreadyExistsException(string? message) : base(message)
        {
        }

        public QuizAnswerItemAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public QuizAnswerItemAlreadyExistsException(int quizId, int quizItemId, int userId) : base($"Answer for quiz item {quizItemId} in quiz {quizId} by user {userId} already exists!")        
        {
            this.quizId = quizId;
            this.quizItemId = quizItemId;
            this.userId = userId;
        }

        protected QuizAnswerItemAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}