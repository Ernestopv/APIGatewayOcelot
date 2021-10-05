// // <copyright file="TeaController.cs" company="The AA(Ireland) Limited">
// // Copyright (c) The AA(Ireland) Limited. All rights reserved.
// // </copyright>

using MicroServices.Model;

namespace MicroServices.Tea.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Tea controller 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class TeaController : ControllerBase
    {
        /// <summary>
        /// Get teas 
        /// </summary>
        private static readonly string[] Teas = new[]
        {
            "Green", "Peppermint", "Earl Grey", "English Breakfast", "Camomile"
        };

        /// <summary>
        /// Get Available Tea
        /// </summary>
        /// <returns>Available tea</returns>
        [HttpGet]
        public ActionResult Get()
        {
            var rng = new Random();

            var beverage = new Beverage {
                Name = Teas[rng.Next(Teas.Length)]
            };

            return Ok(beverage);
        }
    }
}
