using BOI.BOIApplications.Application.Contracts.Persistence.GeoInformation;
using BOI.BOIApplications.Application.Features.API.GeoInformation.City.Queries.GetAllCities;
using BOI.BOIApplications.Application.Features.API.GeoInformation.City.Queries.GetCitiesByLGA;
using BOI.BOIApplications.Application.Features.API.GeoInformation.Countries.Queries.GetAllCountries;
using BOI.BOIApplications.Application.Features.API.GeoInformation.LGAs.Queries.GetAllLGAs;
using BOI.BOIApplications.Application.Features.API.GeoInformation.LGAs.Queries.GetAllLGAsByState;
using BOI.BOIApplications.Application.Features.API.GeoInformation.States.Queries.GetAllStates;
using BOI.BOIApplications.Application.Features.API.GeoInformation.States.Queries.GetStatesByCountry;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BOI.BOIApplications.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class GeoInformationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IStateRepository _stateRepository;
        private readonly ICityRepository _cityRepository;

        public GeoInformationController(IMediator mediator, IStateRepository stateRepository, ICityRepository cityRepository)
        {
            _mediator = mediator;
            _stateRepository = stateRepository;
            _cityRepository = cityRepository;

        }

        /// <summary>
        /// An endpoint to get All countries of the world
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/Countries", Name = "GetAllCountries")]
        public async Task<ActionResult<GetAllCountriesQueryResponse>> GetAllCountries()
        {
            var getAllCountriesQuery = new GetAllCountriesQuery() {BypassCache = false };
            var response = await _mediator.Send(getAllCountriesQuery);
            return Ok(response);
        }

        ///// <summary>
        ///// An endpoint to get All states of the world
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet("/api/States2", Name = "GetAllStates2")]
        //public async Task<ActionResult<GetAllStatesQueryResponse>> GetAllStates2()
        //{
        //    var getAllStatesQuery = new GetAllStatesQuery() { BypassCache = false };
        //    var response = await _mediator.Send(getAllStatesQuery);
        //    return Ok(response);
        //}

        /// <summary>
        /// An endpoint to get All states of the world
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/States", Name = "GetAllStates")]
        public async Task<IActionResult> GetAllStates()
        {
            var response = await _stateRepository.GetAllStates();
            if(response != null) return Ok(response);
            return StatusCode(StatusCodes.Status417ExpectationFailed, response);
        }

        /// <summary>
        /// An endpoint to get All states by CountryID
        /// </summary>
        /// <param name="countryID"></param>
        /// <returns></returns>
        [HttpGet("/api/States/{countryID}", Name = "GetStatesByCountry")]
        public async Task<ActionResult<GetStatesByCountryQueryResponse>> GetStatesByCountry(int countryID)
        {
            var getStatesByCountryQuery = new GetStatesByCountryQuery() { CountryId = countryID, BypassCache = false };
            var response = await _mediator.Send(getStatesByCountryQuery);
            return Ok(response);
        }

        /// <summary>
        /// An endpoint to get All LGAs of the world
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/LGAs", Name = "GetAllLGAs")]
        public async Task<ActionResult<GetAllStatesQueryResponse>> GetAllLGAs()
        {
            var getAllLGAsQuery = new GetAllLGAsQuery() { BypassCache = false };
            var response = await _mediator.Send(getAllLGAsQuery);
            return Ok(response);
        }

        ///// <summary>
        ///// An endpoint to get All LGAs by stateID
        ///// </summary>
        ///// <param name="stateID"></param>
        ///// <returns></returns>
        //[HttpGet("/api/LGAs2/{stateID}", Name = "GetAllLGAsByState2")]
        //public async Task<ActionResult<GetStatesByCountryQueryResponse>> GetAllLGAsByState2(int stateID)
        //{
        //    var getAllLGAsByStateQuery = new GetAllLGAsByStateQuery() { StateId = stateID, BypassCache = false };
        //    var response = await _mediator.Send(getAllLGAsByStateQuery);
        //    return Ok(response);
        //}

        /// <summary>
        /// An endpoint to get All LGAs by stateID
        /// </summary>
        /// <param name="stateID"></param>
        /// <returns></returns>
        [HttpGet("/api/LGAs/{stateID}", Name = "GetAllLGAsByState")]
        public async Task<IActionResult> GetAllLGAsByState(int stateID)
        {
            var response = await _stateRepository.GetStatesWithLGAs(stateID);
            if (response != null) return Ok(response);
            return StatusCode(StatusCodes.Status417ExpectationFailed, response);
        }

        /// <summary>
        /// An endpoint to get All Cities in Nigeria
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/Cities", Name = "GetAllCities")]
        public async Task<ActionResult<GetAllCitiesQueryResponse>> GetAllCities()
        {
            var getAllCitiesQuery = new GetAllCitiesQuery() { BypassCache = false };
            var response = await _mediator.Send(getAllCitiesQuery);
            return Ok(response);
        }

      

        ///// <summary>
        ///// An endpoint to get All Cities by LGA
        ///// </summary>
        ///// <param name="lgaId"></param>
        ///// <returns></returns>
        //[HttpGet("/api/Cities2/{lgaId}", Name = "GetCitiesByLGA2")]
        //public async Task<ActionResult<GetCitiesByLGAQueryResponse>> GetCitiesByLGA2(int lgaId)
        //{
        //    var getCitiesByLGAQuery = new GetCitiesByLGAQuery() { LGAId = lgaId, BypassCache = false };
        //    var response = await _mediator.Send(getCitiesByLGAQuery);
        //    return Ok(response);
        //}


        /// <summary>
        /// An endpoint to get All Cities by LGA
        /// </summary>
        /// <param name="lgaId"></param>
        /// <returns></returns>
        [HttpGet("/api/Cities/{lgaId}", Name = "GetCitiesByLGA")]
        public async Task<IActionResult> GetCitiesByLGA(int lgaId)
        {
            var response = await _cityRepository.GetCitiesByLGAId(lgaId);
            if (response != null) return Ok(response);
            return StatusCode(StatusCodes.Status417ExpectationFailed, response);
        }
    }
}
