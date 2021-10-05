// //
// <copyright file="CoffeeController.cs" company="The AA(Ireland) Limited">
//     // Copyright (c) The AA(Ireland) Limited. All rights reserved. //
// </copyright>

using MicroServices.Model;
using System.Threading.Tasks;

namespace MicroServices.Coffee.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;

    /// <summary>
    /// Coffee controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CoffeeController : ControllerBase
    {
        /// <summary>
        /// List of available coffees
        /// </summary>
        private static readonly string[] Coffees = {
            "Flat White", "Long Black", "Latte", "Americano", "Cappuccino"
        };

        /// <summary>
        /// Get available coffee
        /// </summary>
        /// <returns> Available coffee </returns>
        [HttpGet]
        public ActionResult Get()
        {
            var rng = new Random();

            var beverage = new Beverage {
                Name = Coffees[rng.Next(Coffees.Length)]
            };

            return Ok(beverage);
        }
    }
}