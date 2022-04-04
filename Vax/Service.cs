using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vax
{
    public class Vax
    {
        public int K { get; set; }
    }
    public class Individual
    {
        public double lat { get; set; }
        public double lon { get; set; }
        public string name { get; set; }
        public Neighbor [] neighbor { get; set; }

    }
    public class Neighbor
    {
        public int id { get; set; }
        public double w { get; set; }
    }
    public class Company
    {
        public string companyName { get; set; }
        public string status { get; set; }
    }
    public class Response

    {
        public bool success { get; set; }
        public int index { get; set; }
        public string message { get; set; }
        public string companyId { get; set; }
        public string color { get; set; }

    }


}

