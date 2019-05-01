using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PadraoRepositorio.WebMVC.Models
{
    public class DataTable
    {
        public int draw { get; set; }
        public int length { get; set; }
        public int start { get; set; }
        public search search { get; set; }
        public order[] order { get; set; }
        public columns[] columns { get; set; }

    }

    public class search
    {
        public string value { get; set; }
        public bool regex { get; set; }
    }

    public class order
    {
        public int column { get; set; }
        public string dir { get; set; }
    }

    public class columns
    {
        public string name { get; set; }
        public string data { get; set; }
        public string orderable { get; set; }
        public search[] search { get; set; }
    }
}