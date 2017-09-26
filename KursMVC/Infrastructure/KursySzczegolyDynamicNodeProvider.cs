using KursMVC.DAL;
using KursMVC.Models;
using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KursMVC.Infrastructure
{
    public class KursySzczegolyDynamicNodeProvider : DynamicNodeProviderBase
    {
        private KursyContext db = new KursyContext();

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode nodee)
        {
            var returnValue = new List<DynamicNode>();

            foreach ( Kurs kurs in db.Kursy)
            {
                DynamicNode node = new DynamicNode()
                {
                    Title = kurs.TytulKursu,
                    Key = "Kurs_" + kurs.KursID,
                    ParentKey = "Kategoria_" + kurs.KategoriaID
                };
                node.RouteValues.Add("id", kurs.KursID);
                returnValue.Add(node);
            }

            return returnValue;
        }
    }
}