//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dominus.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Planejamento
    {
        public int IdPlanejamento { get; set; }
        public int IdUsuario { get; set; }
        public int IdCategoria { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public decimal Valor { get; set; }
        public int RepetirMes { get; set; }
    
        public virtual Categoria Categoria { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
