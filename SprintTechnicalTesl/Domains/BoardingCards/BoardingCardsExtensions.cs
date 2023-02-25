namespace SprintTechnicalTesl.Domains.BoardingCards
{
    public static class BoardingCardsExtensions
    {
        public static IReadOnlyList<BoardingCard> SortBoardingCards(this List<BoardingCard> cards)
        {
            List<BoardingCard> result = new();

            if (cards == null || cards.Count == 0)
            {
                return result;
            }

            BoardingCard firstStepBoardingCard = IdentifyFirstStep(cards);

            result.Add(firstStepBoardingCard);

            result.AddRange(ComputeNextSteps(cards, firstStepBoardingCard));

            return result;
        }

        private static List<BoardingCard> ComputeNextSteps(List<BoardingCard> cards, BoardingCard firstStepBoardingCard)
        {
            List<BoardingCard> result = new();

            string nextStep = firstStepBoardingCard.Finish;

            while (cards.Any(card => nextStep.Equals(card.Start, StringComparison.InvariantCultureIgnoreCase)))
            {
                IEnumerable<BoardingCard> nextStepsBoardingCards = cards.Where(card => nextStep.Equals(card.Start, StringComparison.InvariantCultureIgnoreCase));

                if (nextStepsBoardingCards.Count() != 1)
                {
                    throw new BoardingCardException($"Can't sort BoardingCards : Can't determine the step after : {nextStep}");
                }

                BoardingCard nextStepBoardingCard = nextStepsBoardingCards.First();

                result.Add(nextStepBoardingCard);

                nextStep = nextStepBoardingCard.Finish;
            }

            return result;
        }

        private static BoardingCard IdentifyFirstStep(List<BoardingCard> cards)
        {
            IEnumerable<BoardingCard> firstSteps = cards.Where(p => !cards.Any(card => p.Start.Equals(card.Finish, StringComparison.InvariantCultureIgnoreCase)));

            if (firstSteps.Count() != 1)
            {
                throw new BoardingCardException("Can't sort BoardingCards : Can't identify the first step");
            }

            return firstSteps.First();
        }
    }
}
