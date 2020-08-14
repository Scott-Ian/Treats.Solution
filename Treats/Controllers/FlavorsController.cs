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
  public class FlavorsController : Controller
  {
    private readonly TreatsContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public FlavorsController(UserManager<Applicationuser> userManager, TreatsContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public ActionResult Index(string sortOrder, string searchString)
    {
      ViewBag.NameSortParam = string.IsNullOrEmpty(sortOrder) ?"last_desc" : "";
      ViewBag.IdSortParam = sortOrder == "Id" ? "id_desc" : "Id";
      ViewBag.DescriptionSortParam = sortOrder == "Descr" ? "descr_desc" : "Descr";

      IQueryable<Flavor> flavors = _db.Flavors
        .Include(flavor => flavor.Treats)
        .ThenInclude(join => join.Treat);

      if (!string.IsNullOrEmpty(searchString))
      {
        flavors = flavors.Where(flavor => flavor.Name.Contains(searchString));
      }

      switch (sortOrder)
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
      return View(flavors.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Flavor flavor)
    {
      _db.Flavors.Add(flavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisFlavor = _db.Flavors
        .Include(flavor => flavor.Treats)
        .ThenInclude(join => join.Treat)
        .FirstOrDefault(flavor => flavor.FlavorId == id);
      return ViewModels(thisFlavor);
    }

    public ActionResult Edit (int id)
    {
      var thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      return View(thisFlavor);
    }

    [HttpPost]
    public ActionResult Edit(Flavor flavor)
    {
      _db.Entry(flavor).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddTreat(int id)
    {
      var thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "Name");
      return ViewModels(thisFlavor);
    }

    [HttpPost]
    public ActionResult AddTreat(Flavor flavor, int TreatId)
    {
      if (TreatId != 0)
      {
        _db.FlavorTreat.Add(new FlavorTreat() { FlavorId = flavor.FlavorId, TreatId = TreatId } );
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      return View(thisFlavor);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed (int id)
    {
      var thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      _db.Flavors.Remove(thisFlavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }


  }
}