using Microsoft.AspNetCore.Mvc;
using RentalSystem.Models;
using RentalSystem.Models.ViewModels;

namespace RentalSystem.Controllers;

public class HomeController : Controller
{
    private IRentalRepository _repository;
    public int PageSize = 2;

    public HomeController(IRentalRepository repo)
    {
        _repository = repo;
    }


    public IActionResult Index(string? category, int page = 1)
    {
      
        var filteredTransports = _repository.Transports
            .Where(p => category == null || p.Category == category);

       
        var count = filteredTransports.Count();

       
        var transports = filteredTransports
            .OrderBy(p => p.TransportID)
            .Skip((page - 1) * PageSize)
            .Take(PageSize);

        var viewModel = new TransportsListViewModel
        {
            Transports = transports,
            CurrentCategory = category, 
            PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = count
            }
        };

        return View(viewModel);
    }
}