namespace SprintTechnicalTesl.Domains.BoardingCards
{
    public class AeroportBusBoardingCard : BoardingCard
    {
        public AeroportBusBoardingCard(string start, string finish)
        {
            Start = start;
            Finish = finish;
        }

        public override string Print()
        {
            return $"Take the airport bus from {Start} to {Finish}. No seat assignment.";
        }
    }
}
