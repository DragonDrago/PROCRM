using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProCrm.Ldi.Api.Domain;
using ProCrm.Ldi.Api.Repositories;
using ProCrm.Ldi.Api.Requests;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProCrm.Ldi.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class LdiController : ControllerBase
    {
        private readonly ILdiRepository _ldiRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public LdiController(ILdiRepository ldiRepository, ILogger logger, IMapper mapper)
        {
            _ldiRepository = ldiRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("all")]
        [Authorize(Policy = "LDI_VIEW")]
        public async Task<IActionResult> All([FromQuery] LdiFilterRequest ldiFilterRequest)
        {
            LdiFilter ldiFilter = ldiFilterRequest!=null?
                _mapper.Map<LdiFilter>(ldiFilterRequest):null;
            return Ok(await _ldiRepository.All(ldiFilter));
        }

        [HttpGet("remove/{id}")]
        public async Task<IActionResult>Remove(int id)=>Ok(await _ldiRepository.Remove(id));

        [HttpPost("add")]
        [Authorize(Policy ="LDI_ADD")]
        public async Task<IActionResult> Add([FromBody] LdiRequest ldiRequest)
        {
            if (!ModelState.IsValid)
            {
                var errorMessage = ModelState.Values.SelectMany(s=>s.Errors.Select(e=>e.ErrorMessage));
                throw new Exception(string.Join(", ", errorMessage));
            }
            LdiDomain ldiDomain = _mapper.Map<LdiDomain>(ldiRequest);

            //if (!string.IsNullOrEmpty(ldiRequest.FullName) && !string.IsNullOrEmpty(ldiRequest.Phone) && !string.IsNullOrEmpty(ldiRequest.JobTitle)
            //   && !string.IsNullOrEmpty(ldiRequest.Source)&&!string.IsNullOrEmpty(ldiRequest.Status)&& !string.IsNullOrEmpty(ldiRequest.Company))
            //{
            //    try
            //    {
            //        string 
            //    }
            //}
            return Ok(await _ldiRepository.CreateOrUpdateAsync(ldiDomain));
        }

        [HttpPut("update/{id}")]
        [Authorize(Policy = "LDIS_EDIT")]
        public async Task<IActionResult> Update(int id, [FromBody] LdiRequest ldiRequest)
        {
            ldiRequest.Id = id;
            return await Add(ldiRequest);
        }
    }
}
