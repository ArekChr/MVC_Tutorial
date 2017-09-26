using KursMVC.DAL;
using KursMVC.Models;
using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KursMVC.Infrastructure
{
    public class KategorieDynamicNodeProvider : DynamicNodeProviderBase
    {
        private KursyContext db = new KursyContext();

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode nodee)
        {
            var returnValue = new List<DynamicNode>();

            foreach (Kategoria kategoria in db.Kategorie)
            {
                DynamicNode node = new DynamicNode()
                {
                    Title = kategoria.NazwaKategori,
                    Key = "Kategoria_" + kategoria.KategoriaID,
                };
                node.RouteValues.Add("nazwaKategori", kategoria.NazwaKategori);
                returnValue.Add(node);
            }

            return returnValue;
        }
    }
}