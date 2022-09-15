using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneManager.Application.Phones.Commands.CreatePhone;
using PhoneManager.Application.Phones.Commands.DeletePhone;
using PhoneManager.Application.Phones.Commands.UpdatePhone;
using PhoneManager.Application.Phones.Queries.GetPhoneDetails;
using PhoneManager.Application.Phones.Queries.GetPhoneList;
using PhoneManager.WebApi.DataTransferObject.PhoneDto;
using System;
using System.Threading.Tasks;

namespace PhoneManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PhoneController : BaseController
    {
        private readonly IMapper _mapper;

        public PhoneController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<PhoneListVm>> GetAll()
        {
            var query = new GetPhoneListQuery{};
            var vm = await Mediator.Send(query);
            return Ok(vm.Phones);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<PhoneDetailsVm>> Get(Guid id)
        {
            var query = new GetPhoneDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Create([FromBody] CreatePhoneDto createPhoneDto)
        {
            var command = _mapper.Map<CreatePhoneCommand>(createPhoneDto);
            var PhoneId = await Mediator.Send(command);
            return Ok(PhoneId);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(409)]
        public async Task<ActionResult> Update([FromBody] UpdatePhoneDto updatePhoneDto)
        {
            var command = _mapper.Map<UpdatePhoneCommand>(updatePhoneDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Delete(Guid id)
        {
            var commnad = new DeletePhoneCommand
            {
                Id = id
            };
            await Mediator.Send(commnad);
            return NoContent();
        }
    }
}
