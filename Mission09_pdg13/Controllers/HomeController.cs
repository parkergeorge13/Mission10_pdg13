using Microsoft.AspNetCore.Mvc;
using Mission09_pdg13.Models;
using Mission09_pdg13.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_pdg13.Controllers
{
    public class HomeController : Controller
    {
        private IBookStoreRepository repo;

        public HomeController(IBookStoreRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(string category, int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(b => b.Category == category || category == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumProjects = 
                        (category == null 
                        ? repo.Books.Count()
                        : repo.Books.Where(x => x.Category == category).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }
    }
}
