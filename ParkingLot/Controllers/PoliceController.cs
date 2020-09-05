﻿// <copyright file="PoliceController.cs" company="Bridgelabz">
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
    /// This class used for parking lot police controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PoliceController : ControllerBase
    {
        private readonly IParkingService parkingService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PoliceController"/> class.
        /// </summary>
        /// <param name="parkingService">Parking service.</param>
        public PoliceController(IParkingService parkingService)
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

        /// <summary>
        /// This method used for unpark vehicle using post mapping.
        /// </summary>
        /// <param name="slotNumber">Slot number.</param>
        /// <returns>Action result.</returns>
        [Route("Unpark")]
        [HttpPut]
        public ActionResult UnParkVehicle(int slotNumber)
        {
            try
            {
                ParkingDetails result = this.parkingService.UnParkVehicle(slotNumber);
                if (result == null)
                {
                    return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "Please check details again", result));
                }

                return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle unParked successfully", result));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message));
            }
        }

        /// <summary>
        /// This method used for get vehicle by vehicle number using get mapping.
        /// </summary>
        /// <param name="vehicleNumber">Vehicle number.</param>
        /// <returns>Parking details.</returns>
        [Route("SearchVehicleByVehicleNumber")]
        [HttpGet]
        public ActionResult GetVehicleByVehicleNumber(string vehicleNumber)
        {
            try
            {
                ParkingDetails parking = this.parkingService.GetDetailsByVehicleNumber(vehicleNumber);
                if (parking == null)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle details found", parking));
                }

                return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "Plaese check slot number again", parking));
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message });
            }
        }

        /// <summary>
        /// This method used for get vehicle by vehicle color using get mapping.
        /// </summary>
        /// <param name="vehicleColor">Vehicle color.</param>
        /// <returns>Parking details.</returns>
        [Route("SearchVehicleByVehicleColor")]
        [HttpGet]
        public ActionResult GetVehicleByVehicleColor(string vehicleColor)
        {
            try
            {
                List<ParkingDetails> parking = this.parkingService.GetDetailsByVehicleColor(vehicleColor);
                if (parking == null)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle details found", parking));
                }

                return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "Plaese check vehicle color again", parking));
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message });
            }
        }
    }
}
