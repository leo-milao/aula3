using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CidadeController : Controller
    {
        private ICidadeService _service;

        public CidadeController(ICidadeService service)
        {
            _service = service;
        }

        [HttpGet("ListaCidades")]
        public JsonResult ListaCidade()
        {
            return Json(_service.listaCidades());
        }
        [HttpPost("Salvar")]
        public JsonResult Salvar(string nome, int cep, string uf, bool ativo)
        {
            var obj = new Cidade()
            {
                Nome = nome,
                Cep = cep,
                Uf = uf
            };
            _service.Salvar(obj);
            return Json(true);
        }
        [HttpDelete("Deletar")]
        public JsonResult Deletar(Guid id)
        {
            _service.Remover(id);
            return Json(true);
        }
    }
}