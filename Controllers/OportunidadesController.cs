using AutoMapper;
using Granto.Data;
using Granto.Data.Dtos.Oportunidades;
using Granto.Data.Dtos.User;
using Granto.Models;
using Granto.Models.Enums;
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
        public async Task<object> Adiciona([FromBody] CreateOportunidadeDto oportunidadeDto)
        {

            Oportunidade oportunidade = _mapper.Map<Oportunidade>(oportunidadeDto);

            _context.Oportunidades.Add(oportunidade);
            _context.SaveChanges();

            var ret = CreatedAtAction(nameof(getOportunidade), new { id = oportunidade.Id }, oportunidade);
            string cnpj = oportunidade.cnpj.ToString();
            var idUser = await GetCNPJ(cnpj);

            int valor = (int)idUser;

            AtualizaUser(valor);      



            return Ok(idUser);

        }

        [HttpPut]
        private IActionResult AtualizaUser(int id)
        {

            UpdateUserDto userDto = new UpdateUserDto();
            User user = _context.Users.FirstOrDefault(user => user.Id == id);

            userDto.email = user.email;
            userDto.nome = user.nome;
            userDto.regiao = user.regiao;
            userDto.dataUltimaOprtunidade = DateTime.Now;

            

            if (user == null)
            {
                return NotFound();
            }

            _mapper.Map(userDto, user);

            _context.SaveChanges();

            return NoContent();

            

            return NoContent();
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
        public  async Task<object> GetCNPJ(string cnpj)
        {            
           
            var httpClient = new HttpClient();
            var request = new HttpRequestMessage();


            var ret = await httpClient.GetAsync("https://publica.cnpj.ws/cnpj/" + cnpj);
           
            var res = await ret.Content.ReadAsStreamAsync();
            using var stremReader = new StreamReader(res);
            using var jsonReader = new JsonTextReader(stremReader);

            JsonSerializer serializer = new JsonSerializer();


            var serializado = serializer.Deserialize<Root>(jsonReader);

            Console.WriteLine(serializado);

            int numeroRegiao = serializado.estabelecimento.estado.ibge_id / 10;
            Regioes regiao = (Regioes)2;
            regiao.GetType().GetEnumName(regiao);            

            var user = _context.Users
                .Where(user => user.regiao == (Regioes)numeroRegiao)
                .ToList();

            int idUser = -1;
            DateTime ultimaData = DateTime.Now;
            foreach (var us in user){

                

                if(us.dataUltimaOprtunidade < ultimaData)
                {
                    idUser = us.Id;
                    ultimaData = us.dataUltimaOprtunidade;

                }

            }            

            return idUser;





        }

       

       
       


    }
}
