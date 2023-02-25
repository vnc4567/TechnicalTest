using FluentValidation;
using SprintTechnicalTesl.Applications.Queries;

namespace SprintTechnicalTesl.Validators
{
    public class BoardingCardRequestValidator : AbstractValidator<BoardingCardRequest>
    {
        public BoardingCardRequestValidator()
        {
            RuleFor(x => x.Start).NotEmpty();
            RuleFor(x => x.Finish).NotEmpty();
            RuleFor(x => x.TransportNumber).NotEmpty().When(p => p.TransportMeans == TransportMeans.Train || p.TransportMeans == TransportMeans.Flight);
            RuleFor(x => x.SeatNumber).NotEmpty();
            RuleFor(x => x.TransportMeans).NotNull().IsInEnum();
        }
    }
}
