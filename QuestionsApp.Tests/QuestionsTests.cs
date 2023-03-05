using FluentAssertions;
using QuestionsApp.Web.Api.Commands;
using QuestionsApp.Web.Api.Queries;

namespace QuestionsApp.Tests
{
    public class QuestionsTests
    {
        private GetQuestionsQuery GetQuestionsQueryHandler => new();
        private AskQuestionCommand AskQuestionCommandHandler => new();
        private VoteForQuestionCommand VoteForQuestionCommandHandler => new();


        [Fact]
        public async void Empty()
        {
            var response = await GetQuestionsQueryHandler.Handle(new GetQuestionsRequest(), default);
            response.Should().BeEmpty();
        }

        [Fact]
        public async void OneQuestion()
        {
            var askResponse = await AskQuestionCommandHandler.Handle(new AskQuestionRequest { Content = "Dummy Question" }, default);
            askResponse.Should().NotBeNull();

            var response = await GetQuestionsQueryHandler.Handle(new GetQuestionsRequest(), default);
            response.Should().HaveCount(1);
        }

        [Fact]
        public async void OneQuestionAndVote()
        {
            var askResponse = await AskQuestionCommandHandler.Handle(new AskQuestionRequest { Content = "Dummy Question" }, default);
            askResponse.Should().NotBeNull();

            var response = await GetQuestionsQueryHandler.Handle(new GetQuestionsRequest(), default);
            response.Should().HaveCount(1);
            response[0].Votes.Should().Be(0);

            var voteResponse = await VoteForQuestionCommandHandler.Handle(new VoteForQuestionRequest { QuestionID = response[0].ID }, default);
            voteResponse.Should().NotBeNull();

            response = await GetQuestionsQueryHandler.Handle(new GetQuestionsRequest(), default);
            response.Should().HaveCount(1);
            response[0].Votes.Should().Be(1);
        }
    }
}