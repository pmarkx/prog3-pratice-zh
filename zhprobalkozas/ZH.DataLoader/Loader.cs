using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using zhprobalkozas.ZH.Entities;

namespace zhprobalkozas.ZH.DataLoader
{
    public class Loader
    {
        XDocument xDocument;
        public Loader(string file)
        {
            xDocument = XDocument.Load(file);
        }
        public IEnumerable<Plane> LoadPlanes()
        {
            List<Plane> planes = new List<Plane>();
            var help = xDocument.Descendants("aircraft");
            foreach (var item in help)
            {
                int id = (int)item.Element("id");
                string name = item.Element("name").Value;
                int mass = (int)item.Element("mass");
                int capacity = (int)item.Element("capacity");
                bool civil;
                if (item.Element("civil").Value=="False")
                {
                    civil = false;
                }
                else
                {
                    civil = true;
                }
                planes.Add(new Plane()
                {
                    Id = id,
                    Name=name,
                    Mass=mass,
                    Capacity=capacity,
                    Civil=civil
                });
            }
            return planes;
        }
        public IEnumerable<Order> LoadOrders()
        {
            List<Order> orders = new List<Order>();
            var help = xDocument.Descendants("order");
            foreach (var item in help)
            {
                int id = (int)item.Element("id");
                int planeid = (int)item.Element("plane_id");
                int ammount = (int)item.Element("ammount");
                orders.Add(new Order() {Id=id,PlaneId=planeid,Amount=ammount});
            }
            return orders;
        }
    }
}
