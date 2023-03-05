using MediatR;
using QuestionsApp.Web.DB;

namespace QuestionsApp.Web.Api.Commands
{
    public class AskQuestionCommand : IRequestHandler<AskQuestionRequest, IResult>
    {
        private readonly QuestionsContext _context;
        public AskQuestionCommand(QuestionsContext context)
        {
            _context = context;
        }

        public Task<IResult> Handle(AskQuestionRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class AskQuestionRequest :IRequest<IResult>
    {
        public string Content { get; set; } = "";
    }

}
