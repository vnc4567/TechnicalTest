using FluentValidation;
using SprintTechnicalTesl.Applications.Queries;

namespace SprintTechnicalTesl.Validators
{
    public class SortBoardingsCardsRequestValidator : AbstractValidator<SortBoardingsCardsRequest>
    {
        public SortBoardingsCardsRequestValidator()
        {
            RuleForEach(x => x.BoardingCardRequests).SetValidator(new BoardingCardRequestValidator());
        }
    }
}
