// <copyright file="DriverController.cs" company="Bridgelabz">
// Copyright (c) Bridgelabz. All rights reserved.
// </copyright>

namespace ParkingLot.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using Microsoft.AspNetCore.Mvc;
    using ParkingLotBusinessLayer;
    using ParkingLotModelLayer;

    /// <summary>
    /// This class used for parking lot driver controller.
    /// </summary>
    /// [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IParkingService parkingService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DriverController"/> class.
        /// </summary>
        /// <param name="parkingService">Parking service.</param>
        public DriverController(IParkingService parkingService)
        {
            this.parkingService = parkingService;
        }

        /// <summary>
        /// This method used for park vehicle using post mapping.
        /// </summary>
        /// <param name="parking">Parking object.</param>
        /// <returns>Action result.</returns>
        [Route("ParkVehicle")]
        [HttpPost]
        public ActionResult ParkVehicle([FromBody] Parking parking)
        {
            try
            {
                Parking result = this.parkingService.ParkVehicle(parking);
                if (result.Equals(null))
                {
                    return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "Please check details again", result));
                }

                return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle parked successfully", result));
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message });
            }
        }
    }
}
