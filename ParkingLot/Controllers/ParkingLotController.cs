// <copyright file="ParkingLotController.cs" company="Bridgelabz">
// Copyright (c) Bridgelabz. All rights reserved.
// </copyright>

namespace ParkingLot.Controllers
{
    using System;
    using System.Net;
    using Microsoft.AspNetCore.Mvc;
    using ParkingLotBusinessLayer;
    using ParkingLotModelLayer;

    /// <summary>
    /// This class used for parking lot controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingLotController : ControllerBase
    {
        private readonly IParkingService parkingService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParkingLotController"/> class.
        /// </summary>
        /// <param name="parkingService">Parking service.</param>
        public ParkingLotController(IParkingService parkingService)
        {
            this.parkingService = parkingService;
        }

        /// <summary>
        /// This method used for park vehicle using post mapping.
        /// </summary>
        /// <param name="parking">Parking object.</param>
        /// <returns>Action result.</returns>
        [HttpPost]
        public ActionResult ParkVehicle([FromBody] Parking parking)
        {
            try
            {
                bool result = this.parkingService.ParkVehicle(parking);
                if (result == true)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle parked successfully", result));
                }

                return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "Please check details again", result));
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message });
            }
        }
    }
}
