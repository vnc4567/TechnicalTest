namespace SprintTechnicalTesl.Domains.BoardingCards
{
    public class FlightBoardingCard : BoardingCard
    {
        public string Comment { get; set; }
        public string GateNumber { get; set; }

        public override string Print()
        {
            return $"From {Start}, take flight {TransportNumber} to {Finish}. GateNumber {GateNumber}, seat {SeatNumber}. {Comment}.";
        }
    }
}
