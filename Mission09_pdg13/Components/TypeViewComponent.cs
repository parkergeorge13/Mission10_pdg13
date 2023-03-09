using Microsoft.AspNetCore.Mvc;
using Mission09_pdg13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_pdg13.Components
{
    public class TypesViewComponent : ViewComponent
    {
        private IBookStoreRepository repo { get; set; }

        public TypesViewComponent (IBookStoreRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["category"];

            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }
    }
}
