// <copyright file="ValuesController.cs" company="Bridgelabz">
// Copyright (c) Bridgelabz. All rights reserved.
// </copyright>

namespace ParkingLot.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// This class used for controller mapping.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// GET api/values.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// GET api/values/5.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>ActionResult.</returns>
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// POST api/values.
        /// </summary>
        /// <param name="value">String value.</param>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        /// <summary>
        /// PUT api/values/5.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="value">String value.</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        /// <summary>
        /// DELETE api/values/5.
        /// </summary>
        /// <param name="id">Id.</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
