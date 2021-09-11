﻿using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services
{
    public class PessoaService : IPessoaService
    {
        private IRepositoryBase<Pessoa> _repository { get; set; }
        public PessoaService(IRepositoryBase<Pessoa> repository)
        {
            _repository = repository;
        }
        public Pessoa BuscaPorId(Guid id)
        {
            var obj = _repository.Query(x => x.Id == id).FirstOrDefault();


            return obj;
        }

        public List<Pessoa> listaPessoas()
        {
            // return _repository.Query(x => 1 == 1).ToList();
            return _repository.Query(x => 1 == 1)
                .Select(p => new Pessoa
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Peso = p.Peso,
                    Cidade = new Cidade
                    {
                        Nome = p.Cidade.Nome
                    }
                }).ToList();
        }

        public void Salvar(Pessoa obj)
        {
            if (string.IsNullOrEmpty(obj.Nome))
            {
                throw new Exception("informe o nome");
            }
            _repository.Save(obj);
            _repository.SaveChanges();
        }
        public void Remover(Guid id)
        {
            _repository.Delete(id);
            _repository.SaveChanges();
        }
    }
}
