using MediatR;
using QuestionsApp.Web.DB;

namespace QuestionsApp.Web.Api.Commands
{
    public class VoteForQuestionCommand : IRequestHandler<VoteForQuestionRequest, IResult>
    {
        private readonly QuestionsContext _context;
        public VoteForQuestionCommand(QuestionsContext context)
        {
            _context = context;
        }

        public Task<IResult> Handle(VoteForQuestionRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class VoteForQuestionRequest : IRequest<IResult>
    {
        public int QuestionID { get; set; }
    }
}
