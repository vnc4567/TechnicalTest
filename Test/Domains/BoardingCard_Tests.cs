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
                TrainNumber = "78A"
            };

            string result = sut.Print();

            result.Should().Be("Take train 78A from Madrid to Barcelona. Sit in seat 45B");
        }
    }
}
