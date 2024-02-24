using ApiGestaoCursos.Application.interfaces.Services;
using ApiGestaoCursos.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestaoCursos.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoAppService? _appService;

        public AlunoController(IAlunoAppService? appService)
        {
            _appService = appService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] AlunoPostModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var aluno = _appService.Cadastrar(model);

                    return StatusCode(201, new { mensagem = $"O aluno {aluno.Nome} Cadastrado com sucesso", aluno });
                }
                else
                {
                    // Se houver erros de validação, retorne uma resposta de erro com os detalhes dos erros
                    var errors = ModelState.ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToList()
                    );

                    return BadRequest(new { Errors = errors });
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        
        [HttpPut]
        public IActionResult Put([FromBody] AlunoPutModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var aluno = _appService.Atualizar(model);

                    return StatusCode(200, new { mensagem = $"O aluno {aluno.Nome} Atualizado com sucesso", aluno });
                }
                else
                {
                    // Se houver erros de validação, retorne uma resposta de erro com os detalhes dos erros
                    var errors = ModelState.ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToList()
                    );

                    return BadRequest(new { Errors = errors });
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var alunos = _appService.GetById(id);

                if (alunos == null)
                    throw new ArgumentException("Aluno não encontrado.");

                return StatusCode(200, alunos);
            }
            catch (Exception e)
            {

                //HTTP 500 => INTERNAL SERVER ERROR
                return StatusCode(500, new
                {
                    error = e.Message
                });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            { 
                var alunos = _appService.GetAlunos();

                if (alunos == null)
                    throw new ArgumentException("Alunos não encontrado.");

                return StatusCode(200, alunos);
            }
            catch (Exception e)
            {

                //HTTP 500 => INTERNAL SERVER ERROR
                return StatusCode(500, new
                {
                    error = e.Message
                });
            }
        }

        [HttpPut("AtivarAluno/{id}")]
        public IActionResult AtivarAluno(Guid id)
        {
            try
            {
                var aluno = _appService.AtivarAluno(id);

                return StatusCode(200, aluno);
            }
            catch (Exception e)
            {

                //HTTP 500 => INTERNAL SERVER ERROR
                return StatusCode(500, new
                {
                    error = e.Message
                });
            }
        }
    }
}
