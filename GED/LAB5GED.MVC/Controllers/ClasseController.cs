﻿using LAB5GED.DOMAIN.Acessorio;
using LAB5GED.DOMAIN.DAO.Business;
using LAB5GED.DOMAIN.Entidades;
using LAB5GED.MVC.Acessorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAB5GED.MVC.Controllers
{
    [PermissaoFiltro("Classe")]
    public class ClasseController : Controller
    {
        //
        // GET: /Classe/

        private  ClasseBO _DAO = new ClasseBO();
        
        public ActionResult Index()
        {
            MetodosUtilidadeGeral.LimparSessaoEdicao(Session); 
            return View(_DAO.GetAll().OrderBy(cl=>cl.Id_classe).ToList());
        }

     
        
        public ActionResult Cadastrar(Classe _classe)
        {

            return View(_classe);

        }

        public ActionResult Editar(int registro)
        {
            Session["id"] = registro;
            return View("Cadastrar",_DAO.GetByRegistro(registro) );

        }

        public ActionResult CadastrarClasse(Classe _novaClasse)
        {
            if (!ModelState.IsValid)
                return View("Cadastrar",_novaClasse);
            {
                try
                {

                    if (Session["id"] != null) _novaClasse.Registro = int.Parse(Session["id"].ToString());
                        _DAO.SalvarClasse(_novaClasse);
                        return RedirectToAction("Index");
                    
                }
                catch (Exception ex)
                {
                    MetodosUtilidadeGeral.MensagemDeErro(ex.Message,Response);
                    return View("Cadastrar", _novaClasse);
                 
                }
            }

        }


     
    }
}
