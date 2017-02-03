using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaelumEstoque.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Favor inserir um nome."), StringLength(20, ErrorMessage ="Nome deve ter no máximo 20 caracteres")]
        public String Nome { get; set; }

        [Range(0.0, 10000.0, ErrorMessage ="O valor deve ser entre 0,0 e 10.000,00")]
        public float Preco { get; set; }

        public CategoriaDoProduto Categoria { get; set; }

        public int? CategoriaId { get; set; }

        public String Descricao { get; set; }

        public int Quantidade { get; set; }
    }
}