using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Treats.Models;

namespace Treats.Controllers
{
  [Authorize]
  public class TreatsController : Controller
  {
    private readonly TreatsContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public TreatsController(UserManager<Applicationuser> userManager, TreatsContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public ActionResult Index(string sortOrder, string searchString)
    {
      ViewBag.NameSortParam = string.IsNullOrEmpty(sortOrder) ?"last_desc" : "";
      ViewBag.IdSortParam = sortOrder == "Id" ? "id_desc" : "Id";
      ViewBag.DescriptionSortParam = sortOrder == "Descr" ? "descr_desc" : "Descr";
      ViewBag.PriceSortParam = sortOrder == "Price" ? "price_desc" : "Price";

      IQueryable<Treat> treats = _db.Treats
        .Include(treat => treat.Flavors)
        .ThenInclude(join => join.Flavor);

      if (!string.IsNullOrEmpty(searchString))
      {
        treats = treats.Where(treat => treat.Name.Contains(searchString));
      }

      switch (sortOrder)
      {
        case "last_desc":
          treats = treats.OrderByDescending(treat => treat.Name);
          break;
        case "Id":
          treats = treats.OrderBy(treat => treat.TreatId);
          break;
        case "id_desc":
          treats = treats.OrderByDescending(treat => treat.TreatId);
          break;
        case "Descr":
          treats = treats.OrderBy(treat => treat.Description);
          break;
        case "descr_desc":
          treats = treats.OrderByDescending(treat => treat.Description);
          break;
        case "Price":
          treats = treats.OrderBy(treat => treat.Price);
          break;
        case "price_desc":
          treats = treats.OrderByDescending(treat => treat.Price);
          break;
        default:
          treats = treats.OrderBy(treat => treat.Name);
          break;
      }
      return View(treats.ToList());
    }
  }
}