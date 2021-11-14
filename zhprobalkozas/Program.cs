using System;
using System.Linq;
using zhprobalkozas.ZH.Data;

namespace zhprobalkozas
{
    class Program
    {
        static void Main(string[] args)
        {
            AircraftContext aircraftContext = new AircraftContext();
            Console.WriteLine("A:");
            var a = from x in aircraftContext.Planes
                    select x.Name;
            Console.WriteLine(string.Join("\n", a));
            Console.WriteLine();
            Console.WriteLine("B:");
            double avrage = 0;
            foreach (var item in aircraftContext.Planes)
            {
                avrage += item.Mass;
            }
            Console.WriteLine("Repülők átlagos tömege :" + avrage/aircraftContext.Planes.Count());
            Console.WriteLine();
            Console.WriteLine("C:");
            var c = from y in aircraftContext.Orders
                    where y.Amount > 100 && y.Planes.Civil == false
                    orderby y.Planes.Capacity descending
                    select new { y.Planes.Id, y.Planes.Name,y.Planes.Capacity, y.Planes.Civil, y.Amount };
            Console.WriteLine(string.Join("\n",c));
            Console.WriteLine();
            Console.WriteLine("D:");
            var d = from q in aircraftContext.Orders
                    group q by new { q.Planes.Name} into qq
                    orderby qq.Key.Name ascending
                    select new
                    {
                        Plane_Name = qq.Key.Name,
                        avg=Math.Round(qq.Average(x=>x.Amount),2)
                    };
            Console.WriteLine(string.Join("\n",d));
            Console.WriteLine();
            Console.WriteLine("E:");
            Console.WriteLine("NINCS OLYAN H BOIEING DE HELYETTE ITT A RENDES:");
            var e = from w in aircraftContext.Planes
                    where w.Name.Contains("Boeing")
                    select w.Name;
            Console.WriteLine(string.Join("\n",e));
            Console.WriteLine();
            Console.WriteLine("F:");
            var f = from asd in aircraftContext.Orders
                    where asd.Amount > 100 && asd.Planes.Mass > 50000 && asd.Planes.Civil == true
                    select new { asd.Planes.Name, asd.Planes.Civil, asd.Planes.Mass, asd.Amount };
            Console.WriteLine(string.Join("\n",f));


        }
    }
}
