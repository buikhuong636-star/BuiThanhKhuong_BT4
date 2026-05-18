using Microsoft.AspNetCore.Mvc;
using RegistrationApp.Models;

namespace RegistrationApp.Controllers;

public class RegisterController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View(new User());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Index(User user)
    {
        if (!ModelState.IsValid)
        {
            return View(user);
        }

        return View("Success", user);
    }
}
