using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PadraoRepositorio.WebMVC.Models
{
    public class DataTableResult
    {
        public int draw { get; set; }
        public int recordsFiltered { get; set; }
        public Array data { get; set; }
        public string error { get; set; }
    }
}