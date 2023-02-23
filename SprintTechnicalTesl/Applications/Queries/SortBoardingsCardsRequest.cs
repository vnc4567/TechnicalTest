using MediatR;

namespace SprintTechnicalTesl.Applications.Queries
{
    public class SortBoardingsCardsRequest : IRequest<IReadOnlyList<string>>
    {
    }

    public class SortBoardingsCardsRequestHandler : IRequestHandler<SortBoardingsCardsRequest, IReadOnlyList<string>>
    {
        public Task<IReadOnlyList<string>> Handle(SortBoardingsCardsRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}