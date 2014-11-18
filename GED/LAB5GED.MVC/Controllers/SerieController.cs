﻿using LAB5GED.DOMAIN.DAO.Business;
using LAB5GED.DOMAIN.Entidades;
using LAB5GED.MVC.Acessorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAB5GED.MVC.Controllers
{
    [PermissaoFiltro("Serie")]
    public class SerieController : Controller
    {
        //
        // GET: /Serie/

        private SerieBO _DAO = new SerieBO();

        public ActionResult Index()
        {
            MetodosUtilidadeGeral.LimparSessaoEdicao(Session); 
            return View(_DAO.GetAll().OrderBy(s=>s.Id_serie).ToList());
        }


        public ActionResult Cadastrar(Serie _serie)
        {

            return View(_serie);

        }

        public ActionResult Editar(int registro)
        {
            Session["id"] = registro;
            return View("Cadastrar", _DAO.GetByRegistro(registro));

        }

        public ActionResult CadastrarSerie(Serie _novaSerie)
        {
            if (!ModelState.IsValid)
                return View("Cadastrar", _novaSerie);
            {
                try
                {

                    if (Session["id"] != null) _novaSerie.Registro = int.Parse(Session["id"].ToString());
                    _DAO.SalvarSerie(_novaSerie);
                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {
                    MetodosUtilidadeGeral.MensagemDeErro(ex.Message, Response);
                    return View("Cadastrar", _novaSerie);
                }
            }

        }
    }
}
