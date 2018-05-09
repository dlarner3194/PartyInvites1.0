using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
  public class HomeController : Controller
  {
    //data project endpoint
    protected static string _Url = "http://localhost:52209/";

    protected HttpClient httpClient = new HttpClient();

    public ViewResult Index()
    {
      int hour = DateTime.Now.Hour;
      ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";

      return View("MyView");
    }

    [HttpGet]
    public ViewResult RsvpForm()
    {
      return View();
    }

    [HttpPost]
    public ViewResult RsvpForm(GuestResponse guestResponse)
    {
      if (ModelState.IsValid)
      {
        Repository.AddResponse(guestResponse);
        return View("Thanks", guestResponse);
      }
      else
      {
        //validation error
        return View();
      }
    }

    [HttpGet]
    public async Task<ViewResult> ListResponses()
    {
      var res = await httpClient.GetAsync(_Url + "api/GuestResponse/GetAll");

      if (res.IsSuccessStatusCode)
      {
        var content = res.Content.ReadAsStringAsync().Result;
        return View(JsonConvert.DeserializeObject<List<GuestResponse>>(content));
      }

      return View(Repository.Responses.Where(r => r.WillAttend == true));
    }

      //public IActionResult About()
      //{
      //    ViewData["Message"] = "Your application description page.";

      //    return View();
      //}

      //public IActionResult Contact()
      //{
      //    ViewData["Message"] = "Your contact page.";

      //    return View();
      //}

      //public IActionResult Error()
      //{
      //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
      //}
  }
}
