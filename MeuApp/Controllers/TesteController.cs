using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;


namespace Projeto_C_.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TesteController : ControllerBase
    {
        public static IWebHostEnvironment _environment;
        private readonly ApplicationDbContext _context;

        public TesteController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        [HttpGet("Arquivos/All")]
        public String[] GetAllFiles()
        {
            string dir = _environment.ContentRootPath + "\\Arquivos\\";
            return Directory.GetFiles(dir);

        }
        [HttpGet("Download{file}")]
        [ProducesResponseType(typeof(byte[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        public async Task<IActionResult> GetFileDownload(string file)
        {
            string dir = _environment.ContentRootPath + "\\Arquivos\\";
            if (!System.IO.File.Exists(dir + file))
            {
                return BadRequest();
            }
            return File(await System.IO.File.ReadAllBytesAsync(dir + file), "application/octet-stream", file);

        }


        [HttpPost("Upload")]
        public async Task<string> EnviaArquivo(IFormFile arquivo)
        {
            if (arquivo.Length > 0)
            {
                try
                {
                    string dir = _environment.ContentRootPath;
                    if (!Directory.Exists(dir + "\\Arquivos\\"))
                    {
                        Directory.CreateDirectory(dir + "\\Arquivos\\");
                    }
                    using (FileStream filestream = System.IO.File.Create(dir + "\\Arquivos\\" + arquivo.FileName))
                    {
                        await arquivo.CopyToAsync(filestream);
                        filestream.Flush();

                        return filestream.Name;
                    }
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            else
            {
                return "Ocorreu uma falha no envio do arquivo...";
            }
        }



    }
}