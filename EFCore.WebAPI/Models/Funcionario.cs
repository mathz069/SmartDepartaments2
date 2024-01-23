using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using Microsoft.AspNetCore.Mvc;
namespace EFCore.WebAPI.Models
{
    public class Funcionario
        {
        public Funcionario() {}

        public Funcionario(int Id, string Nome, string RG, string Foto, int DepartamentoId) 
        {
            this.Id = Id;
            this.Nome = Nome;
            this.RG = RG;
            this.Foto = Foto;
            this.DepartamentoId = DepartamentoId;   
        }

        public int Id { get; set; }
            
            public string Nome { get; set; }
            
            public string RG { get; set; }

            public string Foto { get; set; }
      
            public int DepartamentoId { get; set; }

            public Departamento Departamento { get; set; }
        }
    }
