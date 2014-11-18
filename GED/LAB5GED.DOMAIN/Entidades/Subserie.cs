﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LAB5GED.DOMAIN.Entidades
{
    [Table("tb_subserie")]
    public class Subserie
    {
        [Column("registro")]
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Registro { get; set; }

        [Column("id_subserie")]
        [Display(Name="ID da Subserie")]
        [Required(ErrorMessage="campo obrigatório")]
        public string Id_subserie { get; set; }

        [Column("rotulo_subserie")]
        [Display(Name = "Rótulo")]
        [Required(ErrorMessage = "campo obrigatório")]
        public string Rotulo_subserie { get; set; }

        [Column("subserie_pai")]
        [Display(Name = "Subserie Pai")]
        public int? Subserie_pai { get; set; }

        [Column("SERIE")]
        [Display(Name = "Série")]
        [Required(ErrorMessage = "campo obrigatório")]
        public int Serie { get; set; }

        [Column("ativo")]
        [Required(ErrorMessage = "campo obrigatório")]
        public bool Ativo { get; set; }
        //REMOVIDO APÓS VERIFICAÇÃO COM CLIENTE
        //[Column("TIPO_DESTINACAO_SUBSERIE")]
        //[Display(Name = "Tipo de Destinação")]
        //[Required(ErrorMessage="campo obrigatório")]
        //public int Tipo_destinacao_subserie { get; set; }

        //[Column("PRAZO_GUARDA")]
        //[Display(Name = "Prazo de Guarda")]
        //[Required(ErrorMessage = "campo obrigatório")]
        //public int Prazo_guarda { get; set; }

        #region ForeignKey

        [ForeignKey("Subserie_pai")]
        public virtual Subserie FK_Subserie_pai { get; set; }

        [ForeignKey("Serie")]
        public virtual Serie FK_Serie { get; set; }
        
        //REMOVIDO APÓS VERIFICAÇÃO COM CLIENTE
        //[ForeignKey("Tipo_destinacao_subserie")]
        //public virtual TipoDestinacaoSubserie FK_Tipo_destinacao_subserie{ get; set; }

        //[ForeignKey("Prazo_guarda")]
        //public virtual PrazoGuarda FK_Prazo_gurada { get; set; }

        #endregion

        public Subserie()
        {

        }

        public Subserie(string _rotulo)
        {
            this.Rotulo_subserie = _rotulo;
            

        }
    }
}
