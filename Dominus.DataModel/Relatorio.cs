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

    public partial class Relatorio
    {
        public Guid IdRelatorio { get; set; }
        public Guid IdTipoRelatorio { get; set; }
        public Guid IdUsuario { get; set; }
        public string Nome { get; set; }
        public string InfoLinha { get; set; }
        public string InfoColuna { get; set; }

        [JsonIgnore]
        public virtual TipoRelatorio TipoRelatorio { get; set; }
        [JsonIgnore]
        public virtual Usuario Usuario { get; set; }
    }
}
