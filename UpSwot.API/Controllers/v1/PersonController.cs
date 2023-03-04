using Microsoft.AspNetCore.Mvc;
using UpSwot.Business.Models.Requests;
using UpSwot.Business.Services.Interfaces;
using UpSwot.Data.Exceptions;

namespace UpSwot.API.Controllers.v1
{
    [Route("api/v1")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IRickAndMortyService _rickAndMortyCacheService;

        public PersonController
        (
            IRickAndMortyCacheService rickAndMortyCacheService)
        {
            _rickAndMortyCacheService = rickAndMortyCacheService;
        }

        /// <summary>
        /// Method checks if a character with the given name was in the
        /// episode with the given name and return true if the character
        /// was in the episode or false if the character was not in the
        /// episode. If character or episode with given names not found
        /// then 404 not found is returned.
        /// </summary>
        /// <param name="data">Character and episode names</param>
        /// <returns>true, false or 404 not found, according to the request result.</returns>
        [HttpGet("/api/v1/check-person")]
        public ActionResult IsPersonPresentedInEpisode(CheckCharacterInEpisode data)
        {
            try
            {
                return Ok(_rickAndMortyCacheService.IsCharacterPresentedInEpisode(data.EpisodeName, data.PersonName));
            }
            catch (EpisodeNotFoundException)
            {
                return NotFound("404 not found");
            }
            catch (CharacterNotFoundException)
            {
                return NotFound("404 not found");
            }
            catch (Exception ex)
            {
                // In case some other exception is thrown.
                return StatusCode(500, ex);
            }
        }

        /// <summary>
        /// Method searches and returns infoi about character with
        /// the given name. If the character exists - method returns
        /// info about it, else it returns 404 error.
        /// </summary>
        /// <param name="name">Character name</param>
        /// <returns>Character info or 404 not found, accroding to the request result.</returns>
        [HttpGet("/api/v1/person")]
        public ActionResult GetCharacterInfoByName([FromQuery(Name = "name")] string name)
        {
            try
            {
                return Ok(_rickAndMortyCacheService.GetCharacterInfoByName(name));
            }
            catch(CharacterNotFoundException)
            {
                return NotFound("404");
            }
            catch(LocationNotFoundException)
            {
                return NotFound("404");
            }
            catch (Exception ex)
            {
                // In case some other exception is thrown.
                return StatusCode(500, ex);
            }
        }
    }
}
