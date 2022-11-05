using CinemaService.Models;
using CinemaService.Service;
using Microsoft.AspNetCore.Mvc;

namespace CinemaService.Controller
{
    [Route("api/v1/cinema")]
    [ApiController]
    
    public class CinemaController : ControllerBase
    {
        private readonly ICinemaService _cinemaService;
        
        public CinemaController(ICinemaService cienmaSerivce)
        {
            _cinemaService = cienmaSerivce;
        }

        [HttpPost]
        public ActionResult Create([FromBody]CreateCinemaDto dto)
        {
            var id = _cinemaService.Create(dto);
            return Created($"api/v1/cinema/{id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _cinemaService.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromRoute]int id, [FromBody] UpdateCinemaDto dto)
        {
            _cinemaService.Update(id, dto);
            return Ok();
        }
    }

    
}
