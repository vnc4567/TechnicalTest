namespace SprintTechnicalTesl.Domains.BoardingCards
{
    public abstract class BoardingCard
    {
        public string Start { get; init; }
        public string Finish { get; init; }
        public string TransportNumber { get; init; }
        public string SeatNumber { get; init; }

        public abstract string Print();
    }
}
