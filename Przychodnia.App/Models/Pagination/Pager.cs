using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Przychodnia.App.Models.Pagination
{
    public class Pager
    {
        //Całkowita iliość rekordów
        public int TotalItems { get; set; }
        //Aktywna strona
        public int CurrentPage { get; set; }
        //Ilość rekordów wyswietlana na stronie
        public int PageSize { get; set; }
        //Całkowita ilość stron
        public int TotalPages { get; set; }

        public int StartPage { get; set; }
        public int EndPage { get; set; }

        public Pager()
        {
        }

        public Pager(int totalItems, int page, int pageSize = 10)
        {
            int totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            int currentPage = page;

            int startPage = currentPage - 5;
            int endPage = currentPage + 4;

            if(startPage <= 0)
            {
                endPage = endPage - (startPage - 1);
                startPage = 1;
            }

            if(endPage > totalPages)
            {
                endPage = totalPages;
                if(endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }

            this.TotalItems= totalItems;
            this.CurrentPage = currentPage;
            this.PageSize = pageSize;
            this.TotalPages = totalPages;
            this.StartPage = startPage;
            this.EndPage = endPage;
        }
    }
}
