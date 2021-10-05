// //
// <copyright file="CustomerController.cs" company="The AA(Ireland) Limited">
//     // Copyright (c) The AA(Ireland) Limited. All rights reserved. //
// </copyright>

using SharedLibrary.Exceptions;
using System;
using System.Threading.Tasks;

namespace MicroServices.Customer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Customer controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        /// <summary>
        /// Available customers
        /// </summary>
        private static readonly List<Model.Customer> Customers = new() {
            new Model.Customer() { Id = 1, Name = "Ernesto Prado" },
            new Model.Customer() { Id = 2, Name = "Pablo Martinez" },
            new Model.Customer() { Id = 3, Name = "Raul Gonzalez" },
            new Model.Customer() { Id = 4, Name = "Sean Murphy" }
        };

        /// <summary>
        /// Get all Customers
        /// </summary>
        /// <returns> </returns>
        [HttpGet]
        public IActionResult GetAvailableCustomers()
        {
            return Ok(Customers);
        }

        /// <summary>
        /// Get Customer by Id
        /// </summary>
        /// <param name="id"> Customer Id </param>
        /// <returns> Customer available </returns>
        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var customer = Customers.FirstOrDefault(x => x.Id == id);
            if (customer == null)
            {
                throw new NotFoundException($"The customer ({id}) does not exist,");
            }

            return Ok(customer);
        }
    }
}