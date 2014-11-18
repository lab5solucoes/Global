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
     [PermissaoFiltro("Indexadores")]
    public class SubserieIndiceController : Controller
    {
        //
        // GET: /SubserieIndice/
        private SubserieIndiceBO _DAO = new SubserieIndiceBO();


        public ActionResult Index()
        {
            MetodosUtilidadeGeral.LimparSessaoEdicao(Session);
            return View(_DAO.GetAll());
        }

        public ActionResult Cadastrar(SubserieIndice _novoSubserieIndice, int _subserie)
        {
            if (_subserie == 0)
                return View(new SubserieIndice());
            else
            {
                SubserieIndice _indice = new SubserieIndice();
                _indice.Subserie = _subserie;
                return View(_indice);
            }
        }

        public ActionResult Excluir(int _registroSubserieIndice)
        {
            try
            {
                _DAO.Excluir(_DAO.GetByRegistro(_registroSubserieIndice));
            }
            catch (Exception ex)
            {
                MetodosUtilidadeGeral.MensagemDeErro(ex.Message, Response);
                
                
            }
            return RedirectToAction("Index");
        }

     

        public ActionResult CadastrarSubserieIndice(SubserieIndice _novoSubserieIndice)
        {
            if (!ModelState.IsValid)
                return View("Cadastrar", _novoSubserieIndice);
            {
                try
                {
                    if (Session["id"] != null) _novoSubserieIndice.Registro = int.Parse(Session["id"].ToString());
                    _DAO.SalvarSubserieIndice(_novoSubserieIndice);
                    return RedirectToAction("Index");


                }


                catch (Exception ex)
                {
                    MetodosUtilidadeGeral.MensagemDeErro(ex.Message, Response);
                    return View("Cadastrar");
                }
            }

        }


        
    }
}
