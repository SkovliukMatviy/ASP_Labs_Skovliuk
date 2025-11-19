using Microsoft.AspNetCore.Mvc;
using RentalSystem.Models;

namespace RentalSystem.Components;

public class NavigationMenuViewComponent : ViewComponent
{
    private IRentalRepository _repository;

    public NavigationMenuViewComponent(IRentalRepository repo)
    {
        _repository = repo;
    }

    public IViewComponentResult Invoke()
    {
       
        ViewBag.SelectedCategory = RouteData?.Values["category"];

        var categories = _repository.Transports
            .Select(x => x.Category)
            .Distinct()
            .OrderBy(x => x);

        return View(categories);
    }
}