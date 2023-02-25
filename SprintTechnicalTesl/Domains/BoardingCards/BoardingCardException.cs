namespace SprintTechnicalTesl.Domains.BoardingCards
{
    [Serializable]
    public class BoardingCardException : Exception
    {
        public BoardingCardException() : base()
        {
        }

        public BoardingCardException(string? message) : base(message)
        {
        }

        public BoardingCardException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
