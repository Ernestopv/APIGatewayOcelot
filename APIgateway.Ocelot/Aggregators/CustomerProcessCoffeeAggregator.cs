// //
// <copyright file="CustomerProcessCoffeeAggregator.cs" company="The AA(Ireland) Limited">
//     // Copyright (c) The AA(Ireland) Limited. All rights reserved. //
// </copyright>

using MicroServices.Model;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Ocelot.Configuration;
using Ocelot.Middleware;
using Ocelot.Multiplexer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIgateway.Ocelot.Aggregators
{
    /// <summary>
    /// custom class For "/customer-process-Coffee/{id}" endpoint
    /// </summary>
    public class CustomerProcessCoffeeAggregator : CustomOrderResponse, IDefinedAggregator
    {
        /// <summary>
        /// Request aggregator
        /// </summary>
        /// <param name="responses"> multiple responses from microServices </param>
        /// <returns> </returns>
        public async Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        {
            var customer = new Customer();
            var product = new Beverage();

            // search by downStreamRouteKey to get customer and product objects
            foreach (var response in responses)
            {
                string downStreamRouteKey = ((DownstreamRoute)response.Items["DownstreamRoute"]).Key;
                DownstreamResponse downstreamResponse = (DownstreamResponse)response.Items["DownstreamResponse"];
                var downstreamResponseContent = await downstreamResponse.Content.ReadAsStringAsync();

                if (downStreamRouteKey == "customer_service_Key")
                {
                    customer = JsonConvert.DeserializeObject<Customer>(downstreamResponseContent);
                }

                if (downStreamRouteKey == "coffee_service_key")
                {
                    product = JsonConvert.DeserializeObject<Beverage>(downstreamResponseContent);
                }
            }

            return GetCustomerOrderResponse(customer, product);
        }
    }
}