using Granto.Data;
using Granto.Models;
using Microsoft.AspNetCore.Mvc;

namespace Granto.Controllers
{

    [ApiController]
    [Route("[Controller]")]

    public class OportunidadesController : ControllerBase
    {

        private AppGrantoContext _context;

        public OportunidadesController(AppGrantoContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("/v1/oportunidade/insert")]
        public IActionResult Adiciona([FromBody] Oportunidade oportunidade)
        {

            _context.Oportunidades.Add(oportunidade);

            return CreatedAtAction(nameof(getOportunidade), new { id = oportunidade.Id }, oportunidade);

        }

        [HttpGet]
        [Route("/v1/oportunidade/all")]
        public IActionResult getOportunidades()
        {
            return Ok(_context.Oportunidades);
        }

        [HttpGet]
        [Route("/v1/oportunidade/{id:int}")]
        public IActionResult getOportunidade(int id)
        {
            Oportunidade oportunidade = _context.Oportunidades.FirstOrDefault(oportunidade => oportunidade.Id == id);
            if(oportunidade != null)
            {
                return Ok(oportunidade);
            }

            return NotFound();
        }


    }
}
