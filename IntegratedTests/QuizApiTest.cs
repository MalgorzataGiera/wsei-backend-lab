using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using WebApi.DTO;


namespace IntegratedTests
{
    public class QuizApiTest
    {
        [Fact]
        public async void GetShoudReturnQuizDto()
        {
            await using var app = new WebApplicationFactory<Program>();
            using var client = app.CreateClient();

            // Act
            var result = client.GetFromJsonAsync<QuizDTO>("/api/v1/user/quizzes/1");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }
    }
}