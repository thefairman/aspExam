using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class PaginationAnswerModel<T>
    {
        public int Total { get; set; }
        public IEnumerable<T> Rows { get; set; }
    }
}
