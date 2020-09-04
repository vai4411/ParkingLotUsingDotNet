// <copyright file="ParkingLotController.cs" company="Bridgelabz">
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
        [Route("ParkVehicle")]
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

        /// <summary>
        /// This method used for unpark vehicle using post mapping.
        /// </summary>
        /// <param name="slotNumber">Slot number.</param>
        /// <returns>Action result.</returns>
        [Route("Unpark/{id}")]
        [HttpPut]
        public ActionResult UnParkVehicle(int slotNumber)
        {
            try
            {
                bool result = this.parkingService.UnParkVehicle(slotNumber);
                if (result == true)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle unParked successfully", result));
                }

                return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "Please check details again", result));
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message });
            }
        }

        /// <summary>
        /// This method used for get vehicle by slot number using get mapping.
        /// </summary>
        /// <param name="slotNumber">Slot number.</param>
        /// <returns>Parking details.</returns>
        [Route("SearchVehicle/{slotNumber}")]
        [HttpGet]
        public ActionResult GetVehicleBySlotNumber(int slotNumber)
        {
            try
            {
                Parking parking = this.parkingService.GetDetailsBySlotNumber(slotNumber);
                if (!parking.ParkingType.Equals(null))
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
        /// This method used for get vehicle by vehicle number using get mapping.
        /// </summary>
        /// <param name="vehicleNumber">Vehicle number.</param>
        /// <returns>Parking details.</returns>
        [Route("SearchVehicle/{vehicleNumber}")]
        [HttpGet]
        public ActionResult GetVehicleByVehicleNumber(string vehicleNumber)
        {
            try
            {
                Parking parking = this.parkingService.GetDetailsByVehicleNumber(vehicleNumber);
                if (!parking.ParkingType.Equals(null))
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
        /// This method used for get empty slots using get mapping.
        /// </summary>
        /// <returns>List of empty slots.</returns>
        [Route("EmptySlots")]
        [HttpGet]
        public ActionResult GetEmptySlots()
        {
            try
            {
                List<int> emptySlots = this.parkingService.GetAllEmptySlot();
                if (emptySlots.Count > 0)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Empty slots found", emptySlots));
                }

                return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "Empty slots not found", emptySlots));
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message });
            }
        }

        /// <summary>
        /// This method used for get all parking vehicles data using get mapping.
        /// </summary>
        /// <returns>All parking vehicles data.</returns>
        [Route("GetAllVehicleDetails")]
        [HttpGet]
        public ActionResult GetAllParkingVehiclesData()
        {
            try
            {
                List<Parking> vehiclesdata = this.parkingService.GetAllParkingVehiclesData();
                if (vehiclesdata.Count > 0)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.OK, "All parking vehicles record found", vehiclesdata));
                }

                return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "No record found", vehiclesdata));
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message });
            }
        }
    }
}
