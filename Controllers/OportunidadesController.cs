using AutoMapper;
using Granto.Data;
using Granto.Data.Dtos.Oportunidades;
using Granto.Models;
using Microsoft.AspNetCore.Mvc;

namespace Granto.Controllers
{

    [ApiController]
    [Route("[Controller]")]

    public class OportunidadesController : ControllerBase
    {

        private AppGrantoContext _context;
        private IMapper _mapper;

        public OportunidadesController(AppGrantoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/v1/oportunidade/insert")]
        public IActionResult Adiciona([FromBody] CreateOportunidadeDto oportunidadeDto)
        {

            Oportunidade oportunidade = _mapper.Map<Oportunidade>(oportunidadeDto);

            Console.WriteLine(oportunidade);

            _context.Oportunidades.Add(oportunidade);
            _context.SaveChanges();

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
        [HttpGet]
        [Route("/v1/oportunidade/vendedor/{id:int}")]
        public IActionResult SelecionaVendedor(int id)
        {
            Oportunidade oportunidade = _context.Oportunidades.FirstOrDefault(oportunidade => oportunidade.Id == id);

            var cnpj = oportunidade.User.Oportunidades;
            //string estado = oportunidade;

            return Ok(cnpj);
        }


    }
}
