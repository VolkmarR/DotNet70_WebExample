using MediatR;
using Microsoft.EntityFrameworkCore;
using QuestionsApp.Web.DB;

namespace QuestionsApp.Web.Api.Queries
{
    public class GetQuestionsQuery : IRequestHandler<GetQuestionsRequest, List<GetQuestionsResponse>>
    {
        private readonly QuestionsContext _context;
        public GetQuestionsQuery(QuestionsContext context)
        {
            _context = context;
        }

        public Task<List<GetQuestionsResponse>> Handle(GetQuestionsRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class GetQuestionsResponse
    {
        public int ID { get; set; }
        public string Content { get; set; } = "";
        public int Votes { get; set; }
    }

    public class GetQuestionsRequest : IRequest<List<GetQuestionsResponse>>
    { }
}
