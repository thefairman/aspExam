using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models.Helpers
{
    public class PaginatorModel
    {
        private int page;
        private int rows;
        public int Rows { get => rows; set => rows = value > 0 ? value : 0; }
        public int Page { get => page; set => page = value > 0 ? value : 0; }
    }
}
