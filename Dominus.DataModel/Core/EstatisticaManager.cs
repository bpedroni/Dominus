using System;
using System.Collections.Generic;
using System.Linq;

namespace Dominus.DataModel.Core
{
    public class EstatisticaManager
    {
        public static List<Item> GetAnaliseUsuarios(DateTime dataInicial, DateTime dataFinal, Periodo periodo = Periodo.Mes)
        {
            try
            {
                List<Item> items = new List<Item>();

                DateTime inicio = new DateTime(dataInicial.Year, dataInicial.Month, dataInicial.Day, 0, 0, 0);
                DateTime fim = new DateTime(dataFinal.Year, dataFinal.Month, dataFinal.Day, 23, 59, 59);

                List<Usuario> usuarios = ConnectionManager.context.Usuarios.Where(x => x.DataCriacao >= inicio && x.DataCriacao <= fim).ToList();

                switch (periodo)
                {
                    case Periodo.Dia:
                        foreach (var item in usuarios.GroupBy(x => x.DataCriacao.Day).OrderBy(x => x.Key))
                        {
                            items.Add(new Item { Categoria = item.Key.ToString(), Valor = usuarios.Count(x => x.DataCriacao.Day == item.Key) });
                        }
                        break;
                    case Periodo.Mes:
                        foreach (var item in usuarios.GroupBy(x => x.DataCriacao.Month).OrderBy(x => x.Key))
                        {
                            String mes = new DateTime(2000, item.Key, 1).ToString(@"MMMM", new System.Globalization.CultureInfo("PT-br"));
                            items.Add(new Item { Categoria = mes, Valor = usuarios.Count(x => x.DataCriacao.Month == item.Key) });
                        }
                        break;
                    case Periodo.Ano:
                        foreach (var item in usuarios.GroupBy(x => x.DataCriacao.Year).OrderBy(x => x.Key))
                        {
                            items.Add(new Item { Categoria = item.Key.ToString(), Valor = usuarios.Count(x => x.DataCriacao.Year == item.Key) });
                        }
                        break;
                    default:
                        break;
                }
                return items;
            }
            catch (Exception)
            {
                return new List<Item>();
            }
        }

        public static List<Item> GetAnaliseCategorias(DateTime dataInicial, DateTime dataFinal, GrupoTransacoes grupoTransacoes = GrupoTransacoes.Categoria)
        {
            try
            {
                List<Item> items = new List<Item>();

                DateTime inicio = new DateTime(dataInicial.Year, dataInicial.Month, dataInicial.Day, 0, 0, 0);
                DateTime fim = new DateTime(dataFinal.Year, dataFinal.Month, dataFinal.Day, 23, 59, 59);

                List<Transacao> transacoes = ConnectionManager.context.Transacoes.Where(x => x.Data >= inicio && x.Data <= fim).ToList();

                switch (grupoTransacoes)
                {
                    case GrupoTransacoes.Categoria:
                        foreach (var item in transacoes.GroupBy(x => x.Categoria.Nome).OrderBy(x => x.Key))
                        {
                            items.Add(new Item { Categoria = item.Key.ToString(), Valor = transacoes.Count(x => x.Categoria.Nome == item.Key) });
                        }
                        break;
                    case GrupoTransacoes.TipoFluxo:
                        foreach (var item in transacoes.GroupBy(x => x.Categoria.TipoFluxo).OrderBy(x => x.Key))
                        {
                            items.Add(new Item { Categoria = item.Key.ToString(), Valor = transacoes.Count(x => x.Categoria.TipoFluxo == item.Key) });
                        }
                        break;
                    default:
                        break;
                }
                return items;
            }
            catch (Exception)
            {
                return new List<Item>();
            }
        }
    }

    public class Item
    {
        public String Categoria { get; set; }
        public int Valor { get; set; }
    }

    public enum Periodo
    {
        Dia,
        Mes,
        Ano
    }

    public enum GrupoTransacoes
    {
        Categoria,
        TipoFluxo
    }
}
