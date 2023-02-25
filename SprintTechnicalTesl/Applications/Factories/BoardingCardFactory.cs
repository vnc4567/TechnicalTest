using SprintTechnicalTesl.Applications.Queries;
using SprintTechnicalTesl.Domains.BoardingCards;

namespace SprintTechnicalTesl.Applications.Factories
{
    public static class BoardingCardFactory
    {
        public static BoardingCard Create(BoardingCardRequest boardingCardRequest)
        {
            return boardingCardRequest.TransportMeans switch
            {
                TransportMeans.Train => new TrainBoardingCard(),
                TransportMeans.AeroportBus => new TrainBoardingCard(),
                TransportMeans.Flight => new TrainBoardingCard(),
                _ => throw new NotSupportedException("Means of transport not supported")
            };
        }
    }
}
