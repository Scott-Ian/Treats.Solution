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
  public class HomeController : Controller
  {
    private readonly TreatsContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public HomeController (UserManager<ApplicationUser> userManager, TreatsContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index (string flavorSortOrder, string flavorSearchString, string treatSortOrder, string treatSearchString)
    {
      ViewBag.FlavorNameSortParam = string.IsNullOrEmpty(flavorSortOrder) ?"last_desc" : "";
      ViewBag.FlavorIdSortParam = flavorSortOrder == "Id" ? "id_desc" : "Id";
      ViewBag.FlavorDescriptionSortParam = flavorSortOrder == "Descr" ? "descr_desc" : "Descr";

      IQueryable<Flavor> flavors = _db.Flavors
        .Include(flavor => flavor.Treats)
        .ThenInclude(join => join.Treat);

      if (!string.IsNullOrEmpty(flavorSearchString))
      {
        flavors = flavors.Where(flavor => flavor.Name.Contains(flavorSearchString));
      }

      switch (flavorSortOrder)
      {
        case "last_desc":
          flavors = flavors.OrderByDescending(flavor => flavor.Name);
          break;
        case "Id":
          flavors = flavors.OrderBy(flavor => flavor.FlavorId);
          break;
        case "id_desc":
          flavors = flavors.OrderByDescending(flavor => flavor.FlavorId);
          break;
        case "Descr":
          flavors = flavors.OrderBy(flavor => flavor.Description);
          break;
        case "descr_desc":
          flavors = flavors.OrderByDescending(flavor => flavor.Description);
          break;
        default:
          flavors = flavors.OrderBy(flavor => flavor.Name);
          break;
      }

      ViewBag.TreatNameSortParam = string.IsNullOrEmpty(treatSortOrder) ?"last_desc" : "";
      ViewBag.TreatIdSortParam = treatSortOrder == "Id" ? "id_desc" : "Id";
      ViewBag.TreatDescriptionSortParam = treatSortOrder == "Descr" ? "descr_desc" : "Descr";
      ViewBag.TreatPriceSortParam = treatSortOrder == "Price" ? "price_desc" : "Price";

      IQueryable<Treat> treats = _db.Treats
        .Include(treat => treat.Flavors)
        .ThenInclude(join => join.Flavor);

      if (!string.IsNullOrEmpty(treatSearchString))
      {
        treats = treats.Where(treat => treat.Name.Contains(treatSearchString));
      }

      switch (treatSortOrder)
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

      ViewBag.Treats = treats.ToList();
      return View(flavors.ToList());
    }
  }
}