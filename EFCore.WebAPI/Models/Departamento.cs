using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Mvc;
namespace EFCore.WebAPI.Models
{
    public class Departamento
    {
        public Departamento() { }

        public Departamento(int Id, string Nome, string Sigla)
        {
            this.Id = Id;
            this.Nome = Nome; 
            this.Sigla = Sigla;
        }
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sigla { get; set; }

    }
}
