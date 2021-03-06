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
    using Newtonsoft.Json;
    using System;

    public partial class Planejamento
    {
        public Guid IdPlanejamento { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdCategoria { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataAtualizacao { get; set; }

        [JsonIgnore]
        public virtual Categoria Categoria { get; set; }
        [JsonIgnore]
        public virtual Usuario Usuario { get; set; }
    }
}
