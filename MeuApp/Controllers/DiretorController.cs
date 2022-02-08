using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class DiretorController : ControllerBase
{
    private readonly IDiretorService _DiretorService;

    public DiretorController(IDiretorService DiretorService)
    {
        _DiretorService = DiretorService;
    }

    // GET api/diretores
    [HttpGet]
    public async Task<ActionResult<DiretorListOutputGetAllDTO>> Get(CancellationToken cancellationToken, int limit = 5, int page = 1)
    {
        return await _DiretorService.GetByPageAsync(limit, page, cancellationToken);

    }

    // GET api/diretores/1
    [HttpGet("{id}")]
    public async Task<ActionResult<DiretorOutputGetIdDTO>> Get(long id)
    {
        var diretor = await _DiretorService.GetById(id);

        if (diretor == null)
        {
            return NotFound("Diretor não encontrado!");
        }

        var outputDto = new DiretorOutputGetIdDTO(diretor.Id, diretor.Nome);
        return Ok(outputDto);
    }

    /// <summary>
    /// Cria um diretor
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /diretor
    ///     {
    ///        "nome": "Martin Scorsese",
    ///     }
    ///
    /// </remarks>
    /// <param name="diretorInputDto">Nome do diretor</param>
    /// <returns>O diretor criado</returns>
    /// <response code="200">Diretor foi criado com sucesso</response>
    /// <response code="400">Bad Request</response>
    /// <response code="404">Not Found</response>
    /// <response code="500">Erro interno inesperado</response>
    /// 
    [HttpPost]
    public async Task<ActionResult<DiretorOutputPostDTO>> Post([FromBody] DiretorInputPostDTO diretorInputDto)
    {
        var diretor = new Diretor(diretorInputDto.Nome);
        await _DiretorService.Add(diretor);

        var diretorOutputDto = new DiretorOutputPostDTO(diretor);
        return Ok(diretorOutputDto);
    }
    [HttpPost("/filmes")]
    public async Task<ActionResult<DiretorOutputPostDTO>> PostFilmes([FromBody] DiretorFilmesInputPostDTO input)
    {

        var diretor = await _DiretorService.AddF(input);

        var diretorOutputDto = new DiretorOutputPostDTO(diretor);
        return Ok(diretorOutputDto);
    }


    // PUT api/diretores/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult<DiretorOutputPutDTO>> Put(long id, [FromBody] DiretorInputPutDTO diretorInputDto)
    {
        var diretor = new Diretor(diretorInputDto.Nome);
        diretor.Id = id;
        await _DiretorService.Update(diretor);

        var diretorOutputDto = new DiretorOutputPutDTO(diretor.Id, diretor.Nome);
        return Ok(diretorOutputDto);
    }

    // DELETE api/diretores/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(long id)
    {
        await _DiretorService.Delete(id);
        return Ok();
    }

}