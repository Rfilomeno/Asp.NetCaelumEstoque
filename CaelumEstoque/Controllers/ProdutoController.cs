using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaelumEstoque;
using CaelumEstoque.DAO;
using CaelumEstoque.Models;
using CaelumEstoque.Controllers;

namespace CaelumEstoque.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        [Route("Produtos", Name ="ListaProdutos")]
        public ActionResult Index()
        {
            ProdutosDAO dao = new ProdutosDAO();
            IList<Produto> produtos = dao.Lista();
            return View(produtos);
        }

        public ActionResult Form()
        {
            ViewBag.Produto = new Produto();
            CategoriasDAO categoriasDAO = new CategoriasDAO();
            ViewBag.Categorias = categoriasDAO.Lista();
            return View();
        }
        [HttpPost]
        public ActionResult Adiciona(Produto produto)
        {
            int idproduto = 1;
            if(produto.CategoriaId.Equals(idproduto) && produto.Preco < 100.00)
            {
                ModelState.AddModelError("produto.Invalido", "Informatica com preco abaixo de 100 Reais");
            }
            if (ModelState.IsValid)
            {
                ProdutosDAO dao = new ProdutosDAO();
                dao.Adiciona(produto);
                return RedirectToAction("Index");
            }
            else
            {
                CategoriasDAO categoriasDAO = new CategoriasDAO();
                ViewBag.Categorias = categoriasDAO.Lista();
                ViewBag.Produto = produto;
                return View("form");
            }
        }
        [Route("produtos/{id}", Name ="VizualizaProduto")]
        public ActionResult Vizualiza(int id) 
        {
            ProdutosDAO dao = new ProdutosDAO();
            Produto produto = dao.BuscaPorId(id);
            ViewBag.Produto = produto;
            return View();
        }

        public ActionResult DecrementaQtd(int id)
        {
            ProdutosDAO dao = new ProdutosDAO();
            Produto produto = dao.BuscaPorId(id);
            produto.Quantidade--;
            dao.Atualiza(produto);

            return Json(produto);
        }

    }
}