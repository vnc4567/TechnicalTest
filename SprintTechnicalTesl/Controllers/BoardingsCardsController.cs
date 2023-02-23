using MediatR;
using Microsoft.AspNetCore.Mvc;
using SprintTechnicalTesl.Applications.Queries;

namespace SprintTechnicalTesl.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoardingsCardsController : ControllerBase
    {
        private readonly ILogger<BoardingsCardsController> _logger;
        private readonly Mediator _mediator;

        public BoardingsCardsController(ILogger<BoardingsCardsController> logger, Mediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = nameof(SortBoardingsCards))]
        public async Task<ActionResult<List<string>>> SortBoardingsCards(SortBoardingsCardsRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }
    }
}