﻿using LAB5GED.DOMAIN.Acessorio;
using LAB5GED.DOMAIN.DAO.Interfaces;
using LAB5GED.DOMAIN.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace LAB5GED.DOMAIN.DAO.Business
{
    public class SubserieIndiceBO
    {
        private class SubserieIndiceDAO : AbstracCrudDAO<SubserieIndice>, ISubserieIndiceDAO
        {
            public SubserieIndiceDAO()
            {

            }
        }

        private SubserieIndiceDAO _DAO = new SubserieIndiceDAO();

        #region Métodos


        public SubserieIndice GetByRegistro(int _registro)
        {
            return _DAO.Find(c => c.Registro == _registro).First();
        }

        public List<SubserieIndice> GetAll()
        {
            return _DAO.GetAll();
        }

        public void Excluir(SubserieIndice _subserieIndice)
        {
            if (PodeExcluir(_subserieIndice.Registro))
            {
                _DAO.Delete(_subserieIndice);
            }
            else
                throw new Erros.ErroGeral("Indexador em uso. Exclusão não permitida.");

        }

        public bool PodeExcluir(int _registroSubserieIndice)
        {
         return  
             new SubserieIndiceValorBO().GetIndexadoresDoIndex(_registroSubserieIndice).Count == 0;
        }
        public void SalvarSubserieIndice(SubserieIndice _subserieIndice)
        {
            try
            {

                if (_subserieIndice.Registro == 0)
                {

                    _DAO.Add(_subserieIndice);
                    _DAO.SaveChanges();
                }
                else
                {
                    _DAO.Atualizar(_subserieIndice, _subserieIndice.Registro);

                }

            }
            catch (DbEntityValidationException dbex)
            {
                throw new Erros.ErroDeValidacao(dbex);
            }
            catch (DbUpdateException dbuex)
            {
                throw new Erros.ErroGeral("Não foi possível concluir a operação. Verifique se o item não foi cadastrado previamente.");
            }
            catch (Exception ex)
            {
                throw new Erros.ErroGeral("Erro inesperado. " + ex.Message);
            }

        }

        public List<SubserieIndice> GetIndexadoresDeUmaSubserie(int _registroSubserie)
        {
            return _DAO.Find(i => i.Subserie == _registroSubserie).ToList<SubserieIndice>();
        }

        public bool IndexadorIndexado(int _registroIndexador, int _registroDocumento)
        {
            return new SubserieIndiceValorBO().GetValorDeUmIndexador(_registroIndexador, _registroDocumento) != null;
        }



        #endregion
    }

}
