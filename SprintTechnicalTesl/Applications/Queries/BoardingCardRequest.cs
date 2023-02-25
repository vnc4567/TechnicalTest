namespace SprintTechnicalTesl.Applications.Queries
{
    public class BoardingCardRequest
    {
        public string Start { get; init; }
        public string Finish { get; init; }
        public string TransportNumber { get; init; }
        public string SeatNumber { get; init; }
        public string Comment { get; init; }
        public string GateNumber { get; init; }
        public TransportMeans TransportMeans { get; init; }
    }
}