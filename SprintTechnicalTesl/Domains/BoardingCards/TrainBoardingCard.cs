namespace SprintTechnicalTesl.Domains.BoardingCards
{
    public class TrainBoardingCard : BoardingCard
    {
        public override string Print()
        {
            return $"Take train {TransportNumber} from {Start} to {Finish}. Sit in seat {SeatNumber}.";
        }
    }
}
