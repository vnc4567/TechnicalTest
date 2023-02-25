using FluentAssertions;
using SprintTechnicalTesl.Domains.BoardingCards;
using Xunit;

namespace Test.Domains
{
    public class BoardingCard_Tests
    {
        [Fact]
        [Trait("Category", "Unit")]
        public void Should_PrintTrainBoardingCard()
        {
            BoardingCard sut = new TrainBoardingCard()
            {
                Finish = "Barcelona",
                Start = "Madrid",
                SeatNumber = "45B",
                TransportNumber = "78A"
            };

            string result = sut.Print();

            result.Should().Be("Take train 78A from Madrid to Barcelona. Sit in seat 45B.");
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Should_PrintBusBoardingCard()
        {
            BoardingCard sut = new AeroportBusBoardingCard(start: "Barcelona", finish: "Gerona Airport");

            string result = sut.Print();

            result.Should().Be("Take the airport bus from Barcelona to Gerona Airport. No seat assignment.");
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Should_PrintFlightBoardingCard()
        {
            BoardingCard sut = new FlightBoardingCard
            {
                Finish = "Stockholm",
                Start = "Gerona Airport",
                SeatNumber = "3A",
                TransportNumber = "SK455",
                Comment = "Baggage drop at ticket counter 344",
                GateNumber = "45B"
            };

            string result = sut.Print();

            result.Should().Be("From Gerona Airport, take flight SK455 to Stockholm. GateNumber 45B, seat 3A. Baggage drop at ticket counter 344.");
        }


        [Fact]
        [Trait("Category", "Unit")]
        public void Should_SortBoardingCards_WhithEmptyBoardingCard()
        {
            List<BoardingCard> boardingCards = new();

            IReadOnlyList<BoardingCard> result = boardingCards.SortBoardingCards();

            result.Should().BeEmpty();
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Should_SortBoardingCards()
        {
            BoardingCard stockholmAirportBoardingCard = new FlightBoardingCard
            {
                Finish = "New York JFK",
                Start = "Stockholm",
                SeatNumber = "7B",
                TransportNumber = "SK22",
                Comment = "Baggage will be automatically transferred from your last leg",
                GateNumber = "22"
            };

            BoardingCard geronaAirportBoardingCard = new FlightBoardingCard
            {
                Finish = "Stockholm",
                Start = "Gerona Airport",
                SeatNumber = "3A",
                TransportNumber = "SK455",
                Comment = "Baggage drop at ticket counter 344",
                GateNumber = "45B"
            };

            BoardingCard aeroportBusBoardingCard = new AeroportBusBoardingCard(start: "Barcelona", finish: "Gerona Airport");

            BoardingCard madridTrainBoardingCard = new TrainBoardingCard()
            {
                Finish = "Barcelona",
                Start = "Madrid",
                SeatNumber = "45B",
                TransportNumber = "78A"
            };

            List<BoardingCard> boardingCards = new()
            {
                stockholmAirportBoardingCard,
                aeroportBusBoardingCard,
                madridTrainBoardingCard,
                geronaAirportBoardingCard
            };

            IReadOnlyList<BoardingCard> result = boardingCards.SortBoardingCards();

            result.Should().HaveCount(4);

            result[0].Start.Should().Be("Madrid");
            result[1].Start.Should().Be("Barcelona");
            result[2].Start.Should().Be("Gerona Airport");
            result[3].Start.Should().Be("Stockholm");
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Should_ThrowBoardingException_WhenSortBoardingCards_WithNoFirstStep()
        {
            BoardingCard stockholmAirportBoardingCard = new FlightBoardingCard
            {
                Finish = "New York JFK",
                Start = "Stockholm",
                SeatNumber = "7B",
                TransportNumber = "SK22",
                Comment = "Baggage will be automatically transferred from your last leg",
                GateNumber = "22"
            };

            BoardingCard stockholmAirportBoardingCard2 = new FlightBoardingCard
            {
                Finish = "New York JFK",
                Start = "Stockholm",
                SeatNumber = "7B",
                TransportNumber = "SK22",
                Comment = "Baggage will be automatically transferred from your last leg",
                GateNumber = "22"
            };

            List<BoardingCard> boardingCards = new()
            {
                stockholmAirportBoardingCard,
                stockholmAirportBoardingCard2
            };

            Action act = () => boardingCards.SortBoardingCards();

            act.Should().Throw<BoardingCardException>();

        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Should_ThrowBoardingException_WhenSortBoardingCards_WithUnchainedBoardingCard()
        {
            BoardingCard geronaAirportBoardingCard = new FlightBoardingCard
            {
                Finish = "StockHolm",
                Start = "Gerona Airport",
                SeatNumber = "3A",
                TransportNumber = "SK455",
                Comment = "Baggage drop at ticket counter 344",
                GateNumber = "45B"
            };

            BoardingCard geronaAirportBoardingCard2 = new FlightBoardingCard
            {
                Finish = "StockHolm",
                Start = "Gerona Airport",
                SeatNumber = "3A",
                TransportNumber = "SK455",
                Comment = "Baggage drop at ticket counter 344",
                GateNumber = "45B"
            };

            BoardingCard aeroportBusBoardingCard = new AeroportBusBoardingCard(start: "Barcelona", finish: "Gerona Airport");

            BoardingCard madridTrainBoardingCard = new TrainBoardingCard()
            {
                Finish = "Barcelona",
                Start = "Madrid",
                SeatNumber = "45B",
                TransportNumber = "78A"
            };

            List<BoardingCard> boardingCards = new()
            {
                aeroportBusBoardingCard,
                madridTrainBoardingCard,
                geronaAirportBoardingCard,
                geronaAirportBoardingCard2
            };

            Action act = () => boardingCards.SortBoardingCards();

            act.Should().Throw<BoardingCardException>();
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Should_ThrowBoardingException_WhenSortBoardingCards_WithCycleBoardingCard()
        {
            BoardingCard stockholmAirportBoardingCard = new FlightBoardingCard
            {
                Finish = "StockHolm",
                Start = "Gerona Airport",
                SeatNumber = "3A",
                TransportNumber = "SK455",
                Comment = "Baggage drop at ticket counter 344",
                GateNumber = "45B"
            };

            BoardingCard parisBoardingCard = new FlightBoardingCard
            {
                Finish = "Paris",
                Start = "StockHolm",
                SeatNumber = "3A",
                TransportNumber = "SK455",
                Comment = "Baggage drop at ticket counter 344",
                GateNumber = "45B"
            };

            BoardingCard geronaAirportBoardingCard3 = new FlightBoardingCard
            {
                Finish = "Gerona Airport",
                Start = "Paris",
                SeatNumber = "3A",
                TransportNumber = "SK455",
                Comment = "Baggage drop at ticket counter 344",
                GateNumber = "45B"
            };

            BoardingCard firstStep = new FlightBoardingCard
            {
                Finish = "Gerona Airport",
                Start = "Madrid",
                SeatNumber = "3A",
                TransportNumber = "SK455",
                Comment = "Baggage drop at ticket counter 344",
                GateNumber = "45B"
            };

            List<BoardingCard> boardingCards = new()
            {
                firstStep,
                stockholmAirportBoardingCard,
                geronaAirportBoardingCard3,
                parisBoardingCard
            };

            Action act = () => boardingCards.SortBoardingCards();

            act.Should().Throw<BoardingCardException>();
        }
    }
}
