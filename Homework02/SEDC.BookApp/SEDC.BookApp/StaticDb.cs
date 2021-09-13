using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEDC.BookApp.Models;

namespace SEDC.BookApp
{
    public static class StaticDb
    {
        public static List<Book> Books = new List<Book>()
        {
            new Book(){Author = "Angela M.", Tittle = "Stories and Story-telling"},
            new Book(){Author = "Somerville", Tittle = "Summer Flowers of the High Alps"},
            new Book(){Author = "Sydney C", Tittle = "An Uncrowned King"}
        };
    }
}
