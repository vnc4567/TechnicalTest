using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SprintTechnicalTesl.Applications.Queries;
using SprintTechnicalTesl.Domains.BoardingCards;

namespace SprintTechnicalTesl.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoardingsCardsController : ControllerBase
    {
        private readonly ILogger<BoardingsCardsController> _logger;
        private readonly Mediator _mediator;
        private readonly IValidator<SortBoardingsCardsRequest> _sortBoardingsCardsRequestValidator;

        public BoardingsCardsController(ILogger<BoardingsCardsController> logger,
                                        Mediator mediator,
                                        IValidator<SortBoardingsCardsRequest> sortBoardingsCardsRequestValidator)
        {
            _logger = logger;
            _mediator = mediator;
            _sortBoardingsCardsRequestValidator = sortBoardingsCardsRequestValidator;
        }

        [HttpGet(Name = nameof(SortBoardingsCards))]
        public async Task<ActionResult<List<string>>> SortBoardingsCards([FromBody] List<BoardingCardRequest> boardingCardRequests)
        {
            try
            {
                SortBoardingsCardsRequest request = new(boardingCardRequests);

                ValidationResult validationResult = _sortBoardingsCardsRequestValidator.Validate(request);

                if (!validationResult.IsValid)
                {
                    return BadRequest(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
                }

                string result = await _mediator.Send(request);

                return Ok(result);
            }
            catch (BoardingCardException ex)
            {
                _logger.LogError(ex, ex.Message);

                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured");

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}