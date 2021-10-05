// //
// <copyright file="CustomResponse.cs" company="The AA(Ireland) Limited">
//     // Copyright (c) The AA(Ireland) Limited. All rights reserved. //
// </copyright>

using MicroServices.Model;
using Newtonsoft.Json;
using Ocelot.Middleware;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace APIgateway.Ocelot.Aggregators
{
    /// <summary>
    /// Custom Order response
    /// </summary>
    abstract public class CustomOrderResponse
    {
        public DownstreamResponse GetCustomerOrderResponse(Customer customer, Beverage product)
        {
            // create custom response object
            var order = new Order() { OrderNO = DateTime.UtcNow + "XXX", CustomerName = customer.Name, Drink = product.Name };
            var getOrder = JsonConvert.SerializeObject(order);

            // set string body content and header
            var stringContent = new StringContent(getOrder) {
                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
            };

            return new DownstreamResponse(stringContent, HttpStatusCode.OK, new List<KeyValuePair<string, IEnumerable<string>>>(), "OK");
        }
    }
}