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
                TransportMeans.Train => new TrainBoardingCard()
                {
                    Start = boardingCardRequest.Start,
                    Finish = boardingCardRequest.Finish,
                    SeatNumber = boardingCardRequest.SeatNumber,
                    TransportNumber = boardingCardRequest.TransportNumber
                },
                TransportMeans.AeroportBus => new AeroportBusBoardingCard(boardingCardRequest.Start, boardingCardRequest.Finish),
                TransportMeans.Flight => new FlightBoardingCard()
                {
                    Start = boardingCardRequest.Start,
                    Finish = boardingCardRequest.Finish,
                    SeatNumber = boardingCardRequest.SeatNumber,
                    TransportNumber = boardingCardRequest.TransportNumber,
                    GateNumber = boardingCardRequest.GateNumber,
                    Comment = boardingCardRequest.Comment
                },
                _ => throw new NotSupportedException("Means of transport not supported")
            };
        }
    }
}
