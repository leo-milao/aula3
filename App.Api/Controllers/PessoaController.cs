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
    public class PessoaController : Controller
    {
        private IPessoaService _service;

        public PessoaController(IPessoaService service)
        {
            _service = service;
        }

        [HttpGet("ListaPessoas")]
        public JsonResult ListaPessoa(string nome, int pesoMaiorQue, int pesoMenorQue)
        {
            try
            {
                var obj = _service.listaPessoas(nome, pesoMaiorQue, pesoMenorQue);
                return Json(RetornoApi.Sucesso(obj));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }

        [HttpGet("BuscaPorId")]
        public JsonResult BuscaPorId(Guid id)
        {
            return Json(_service.BuscaPorId(id));
        }

        [HttpPost("Salvar")]
        public JsonResult Salvar(string nome, int peso, DateTime dataNascimento, bool ativo, Guid idCidade)

        {
            var obj = new Pessoa()
            {
                Nome = nome,
                DataNascimento = dataNascimento,
                Peso = peso,
                Ativo = ativo,
                CidadeId = idCidade
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
