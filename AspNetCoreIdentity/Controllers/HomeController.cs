using AspNetCoreIdentity.Extensions;
using AspNetCoreIdentity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AspNetCoreIdentity.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            throw new Exception("erro");
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Secret()
        {
            return View();
        }

        [Authorize(Policy = "PodeExcluir")]
        public IActionResult SecretClain()
        {
            return View("Secret");
        }

        [Authorize(Policy = "PodeEscrever")]
        public IActionResult SecretClainGravar()
        {
            return View("Secret");
        }

        [ClaimsAuthorize("Produtos", "Ler")]
        public IActionResult ClaimsCustom()
        {
            return View("Secret");
        }

        [Route("erro/{codHttp:length(3,3)}")]
        public IActionResult Error(int codHttp)
        {
            var modelErro = new ErrorViewModel();

            if (codHttp == 500)
            {
                modelErro.Mensagem = "Ocorreu um erro no servidor";
                modelErro.Titulo = "Ocorreu um erro";
                modelErro.ErroCode = codHttp;
            }
            else if(codHttp == 404)
            {
                modelErro.Mensagem = "Está pagina não existe";
                modelErro.Titulo = "Pagina não encontrada";
                modelErro.ErroCode = codHttp;
            }
            else if(codHttp == 403)
            {
                modelErro.Mensagem = "Você não tem permissão para fazer isto";
                modelErro.Titulo = "Acesso negado";
                modelErro.ErroCode = codHttp;
            }
            else
            {
                return StatusCode(404);
            }

            return View("Error", modelErro);
        }
    }
}
