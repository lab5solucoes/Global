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
    [PermissaoFiltro("Grupo")]
    public class GrupoController : Controller
    {
        //
        // GET: /Grupo/
        private GrupoBO _DAO = new GrupoBO();
        public ActionResult Index()
        {
            return View(_DAO.GetAll());
        }

        public ActionResult Editar(int registro)
        {
            Session["id"] = registro;
            return View("Cadastrar", _DAO.GetByRegistro(registro));

        }

        public ActionResult Cadastrar(Grupo _grupo)
        {
            return View(_grupo);
        }

        public ActionResult CadastrarGrupo(Grupo _novaGrupo)
        {
            if (!ModelState.IsValid)
                return View("Cadastrar", _novaGrupo);
            {
                try
                {

                    if (Session["id"] != null) _novaGrupo.Registro = int.Parse(Session["id"].ToString());
                    _DAO.SalvarGrupo(_novaGrupo);
                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {
                    MetodosUtilidadeGeral.MensagemDeErro(ex.Message, Response);
                    return View("Cadastrar", _novaGrupo);

                }
            }

        }

    }
}
