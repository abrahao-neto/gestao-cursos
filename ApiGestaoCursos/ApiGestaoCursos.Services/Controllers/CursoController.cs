using ApiGestaoCursos.Application.interfaces.Services;
using ApiGestaoCursos.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestaoCursos.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly ICursoAppService? _appService;

        public CursoController(ICursoAppService? appService)
        {
            _appService = appService;
        }

        [HttpPost]
        public IActionResult Cadastrar(CursoPostModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var curso = _appService.Cadastrar(model);

                    return StatusCode(201, new { mensagem = $"{curso.Nome} Cadastrado com sucesso", curso });
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
        public IActionResult Update(CursoPutModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var curso = _appService.Atualizar(model);

                    return StatusCode(200, new { mensagem = $"{curso.Nome} Atualizado com sucesso", curso });
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
        public IActionResult GetById(Guid? id)
        {
            try
            {
                var curso = _appService.GetById(id);

                if (curso == null)
                    throw new ArgumentException("Curso não encontrado.");

                return StatusCode(200, curso);
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
                var cursos = _appService.GetAll();

                if (cursos == null)
                    throw new ArgumentException("Cursos não encontrado.");

                return StatusCode(200, cursos);
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
