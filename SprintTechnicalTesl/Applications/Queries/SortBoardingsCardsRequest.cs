using MediatR;
using SprintTechnicalTesl.Applications.Factories;
using SprintTechnicalTesl.Domains.BoardingCards;
using System.Text;

namespace SprintTechnicalTesl.Applications.Queries
{
    public record SortBoardingsCardsRequest(IReadOnlyList<BoardingCardRequest> BoardingCardRequests) : IRequest<string>;

    public class SortBoardingsCardsRequestHandler : IRequestHandler<SortBoardingsCardsRequest, string>
    {
        public Task<string> Handle(SortBoardingsCardsRequest request, CancellationToken cancellationToken)
        {
            List<BoardingCard> boardingCards = request.BoardingCardRequests.Select(card => BoardingCardFactory.Create(card))
                                                                           .ToList();

            IReadOnlyList<BoardingCard> sortedBoardingCards = boardingCards.SortBoardingCards();

            StringBuilder stringBuilder = new();

            foreach (var card in sortedBoardingCards)
            {
                stringBuilder.AppendLine(card.Print());
            }

            stringBuilder.AppendLine("You have arrived at your final destination.");

            return Task.FromResult(stringBuilder.ToString());
        }
    }
}