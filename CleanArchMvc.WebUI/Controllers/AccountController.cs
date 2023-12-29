using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Account;
using CleanArchMvc.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchMvc.WebUI.Controllers;

public class AccountController : Controller
{
    private readonly IAuthenticate _authentication;

    //public AccountController(IAuthenticate authentication)
    //{
    //    _authentication = authentication;
    //}

    public AccountController(IAuthenticate authentication)
    {
        _authentication = authentication;
    }

    [HttpGet, ActionName("Login")]
    public IActionResult Login(string returnUrl)
    {
        return View(new LoginViewModel()
        {
            ReturnUrl = returnUrl,
        });
    }

    [HttpPost, ActionName("Login")]
    public async Task<IActionResult> LoginUsuario(LoginViewModel model)
    {
        var result = await _authentication.Authenticate(model.Email, model.Password);

        if (result)
        {
            if (string.IsNullOrEmpty(model.ReturnUrl))
                return RedirectToAction("Index", "Home");

            return Redirect(model.ReturnUrl);
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Invalid login attempt.(password must be strong).");
            return View(model);
        }
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }



    [HttpPost, ActionName("Register")]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        var result = await _authentication.RegisterUser(model.Email, model.Password);


        if (result)
        {
            return Redirect("/");
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Invalid register attempt.(password must be strong).");
            return View(model);
        }

    }

    public async Task<IActionResult> Logout()
    {
        await _authentication.Logout();
        return Redirect("/Account/Login");
    }



}
