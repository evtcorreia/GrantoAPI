using AutoMapper;
using Granto.Data;
using Granto.Data.Dtos.Oportunidades;
using Granto.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net.Http.Json;

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
            //Oportunidade oportunidade = _context.Oportunidades.FirstOrDefault(oportunidade => oportunidade.Id == id);
            //if(oportunidade != null)
            //{
                //return Ok(oportunidade);
            //}

            return NotFound();
        }
       




        [HttpGet]
        [Route("/v1/oportunidade/vendedor/{id:int}")]
        public  async Task<object> GetCNPJ(int id)
        {
            Oportunidade oportunidade = _context.Oportunidades.FirstOrDefault(oportunidade => oportunidade.Id == id);

            var httpClient = new HttpClient();
            var request = new HttpRequestMessage();
           

            
           

            var ret = await httpClient.GetAsync("https://publica.cnpj.ws/cnpj/20188753000180");
           
            var res = await ret.Content.ReadAsStreamAsync();
            using var stremReader = new StreamReader(res);
            using var jsonReader = new JsonTextReader(stremReader);

            JsonSerializer serializer = new JsonSerializer();


            var serializado = serializer.Deserialize<Root>(jsonReader);

            Console.WriteLine(serializado);
         
            return serializado.estabelecimento.estado.ibge_id;



        }

       
       


    }
}
