namespace SprintTechnicalTesl.Domains.BoardingCards
{
    public abstract class BoardingCard
    {
        public string Start { get; init; }
        public string Finish { get; init; }
        public string TrainNumber { get; init; }
        public string SeatNumber { get; init; }

        public abstract string Print();
    }

    public class TrainBoardingCard : BoardingCard
    {
        public override string Print()
        {
            return $"Take train {TrainNumber} from {Start} to {Finish}. Sit in seat {SeatNumber}";
        }
    }
}
