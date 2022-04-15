using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SERVICE_BG.Data;
using SERVICE_BG.Entities;
using SERVICE_BG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SERVICE_BG.Controllers
{

    [Authorize]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext context;

        public OrderController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpPost]

        public IActionResult Create(OrderCreateBindingModel bindingModel)
        {
            if (this.ModelState.IsValid)
            {
                string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = this.context.Users.SingleOrDefault(u => u.Id == userId);
                var ev = this.context.Services.SingleOrDefault(e => e.Id == bindingModel.ServiceId);

                if (user == null || ev == null )
                {

                    return this.RedirectToAction("Index", "Services");
                }
                Order orderForDb = new Order
                {
                    OrderDate = DateTime.UtcNow,
                    ServiceId = bindingModel.ServiceId,
                    Quantity = bindingModel.Quantity,
                    UserId = userId,
                    CarModel = bindingModel.CarModel,
                                       
                    Price = ev.Price,
                //    TotalPrice = ev.TotalPrice,


                };

               
              this.context.Services.Update(ev);
                this.context.Orders.Add(orderForDb);
                this.context.SaveChanges();
            }
            return this.RedirectToAction("Index", "Services");
        }
        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = context.Users.SingleOrDefault(u => u.Id == userId);

            List<OrderListVM> orders = context
                 .Orders
                 .Select(x => new OrderListVM
                 {
                     Id = x.Id,
                     OrderDate = DateTime.UtcNow,
                     ServiceId = x.ServiceId,
                   Service=x.Service.Name,
                     Quantity = x.Quantity,
                     UserId=x.UserId,
                     User =user.UserName,
                     CarModel = x.CarModel,


                     Price = x.Price,
                     
                     
                     TotalPrice = x.TotalPrice,

                     // TotalPrice = (x.Count * x.MaxPrice).ToString()
                 }).ToList();

            return View(orders);
        }
        [Authorize]
        public IActionResult My(string searchString)
        {
            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = this.context.Users.SingleOrDefault(u => u.Id == currentUserId);
            if (user == null)
            {
                return null;
            }

            List<OrderListVM> orders = this.context.Orders
                .Where(x => x.UserId == user.Id)
            .Select(x => new OrderListVM
            {
                Id = x.Id,
                OrderDate = DateTime.UtcNow,
                ServiceId = x.ServiceId,
                Quantity = x.Quantity,
                User = x.User.FirstName,
                CarModel = x.CarModel,


                Price = x.Price,


                TotalPrice = x.TotalPrice,
                // TotalPrice = (x.Count * x.MaxPrice).ToString()
            })
            .ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(o => o.CarModel.Contains(searchString)).ToList();
            }
            return this.View(orders);
        }

    }
}
