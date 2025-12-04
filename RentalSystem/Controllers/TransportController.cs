using Microsoft.AspNetCore.Mvc;
using RentalSystem.Models;

namespace RentalSystem.Controllers;

public class TransportController : Controller
{
    private IRentalRepository _repository;

    public TransportController(IRentalRepository repo)
    {
        _repository = repo;
    }

    // Список авто (для адміна)
    public IActionResult Index() => View(_repository.Transports);

    // Створення (показати форму)
    public IActionResult Create() => View("Edit", new Transport());

    // Створення (зберегти)
    [HttpPost]
    public IActionResult Create(Transport transport)
    {
        if (ModelState.IsValid)
        {
            _repository.CreateTransport(transport);
            return RedirectToAction("Index");
        }
        return View("Edit", transport);
    }

    // Редагування (показати форму)
    public IActionResult Edit(long id)
    {
        var transport = _repository.Transports.FirstOrDefault(t => t.TransportID == id);
        return View(transport);
    }

    // Редагування (зберегти)
    [HttpPost]
    public IActionResult Edit(Transport transport)
    {
        if (ModelState.IsValid)
        {
            _repository.SaveTransport(transport);
            return RedirectToAction("Index");
        }
        return View(transport);
    }

    // Видалення
    [HttpPost]
    public IActionResult Delete(long id)
    {
        var transport = _repository.Transports.FirstOrDefault(t => t.TransportID == id);
        if (transport != null) _repository.DeleteTransport(transport);
        return RedirectToAction("Index");
    }

    // Деталі
    public IActionResult Details(long id)
    {
        var transport = _repository.Transports.FirstOrDefault(t => t.TransportID == id);
        return View(transport);
    }
}