using App.Domain.DTO;
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
            try
            {
                var obj = _service.listaCidades();
                return Json(RetornoApi.Sucesso(obj));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }

        [HttpPost("Salvar")]
        public JsonResult Salvar([FromBody] Cidade obj)
        {
            try
            {
                _service.Salvar(obj);
                return Json(RetornoApi.Sucesso(true));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }

        [HttpDelete("Deletar")]
        public JsonResult Deletar(Guid id)
        {
            _service.Remover(id);
            return Json(true);
        }
    }
}