using Microsoft.AspNetCore.Mvc;
using RentalSystem.Models;
using System.Text.Json; 

namespace RentalSystem.Controllers;

public class RentController : Controller
{
    private IRentalRepository _repository;

    public RentController(IRentalRepository repo)
    {
        _repository = repo;
    }

    public IActionResult Index(int transportId)
    {
        RentRequest model;

     
        var sessionData = HttpContext.Session.GetString("RentDraft");

        if (!string.IsNullOrEmpty(sessionData))
        {
       
            model = JsonSerializer.Deserialize<RentRequest>(sessionData);

            if (transportId != 0 && transportId != model.TransportID)
            {
                model.TransportID = transportId;
            }
        }
        else
        {
            model = new RentRequest { TransportID = transportId };
        }

        
        var transport = _repository.Transports.FirstOrDefault(t => t.TransportID == model.TransportID);
        ViewBag.Transport = transport;

        return View(model);
    }

    [HttpPost]
    public IActionResult SaveDraft(RentRequest request)
    {
       
        var json = JsonSerializer.Serialize(request);
        HttpContext.Session.SetString("RentDraft", json);

        TempData["Message"] = "Дані збережено в сесії! Можете продовжити пізніше.";

     
        return RedirectToAction("Index", new { transportId = request.TransportID });
    }


    [HttpPost]
    public IActionResult Complete(RentRequest request)
    {
       
        HttpContext.Session.Remove("RentDraft");

        TempData["Message"] = $"Дякуємо, {request.ClientName}! Бронювання успішне.";
        return RedirectToAction("Index", "Home");
    }
}