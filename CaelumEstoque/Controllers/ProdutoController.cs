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
        public ActionResult Index()
        {
            ProdutosDAO dao = new ProdutosDAO();
            IList<Produto> produtos = dao.Lista();
            ViewBag.Produtos = produtos;
            return View();
        }

        public ActionResult Form()
        {
            CategoriasDAO categoriasDAO = new CategoriasDAO();
            ViewBag.Categorias = categoriasDAO.Lista();
            return View();
        }
        [HttpPost]
        public ActionResult Adiciona(Produto produto)
        {
            ProdutosDAO dao = new ProdutosDAO();
            dao.Adiciona(produto);
            return RedirectToAction("Index");
        }


    }
}