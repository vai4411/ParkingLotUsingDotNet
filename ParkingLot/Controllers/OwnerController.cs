// <copyright file="OwnerController.cs" company="Bridgelabz">
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
    /// This class used for parking lot owner controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IParkingService parkingService;

        /// <summary>
        /// Initializes a new instance of the <see cref="OwnerController"/> class.
        /// </summary>
        /// <param name="parkingService">Parking service.</param>
        public OwnerController(IParkingService parkingService)
        {
            this.parkingService = parkingService;
        }

        /// <summary>
        /// This method used for park vehicle using post mapping.
        /// </summary>
        /// <param name="parking">Parking object.</param>
        /// <returns>Action result.</returns>
        [Route("park")]
        [HttpPost]
        public ActionResult ParkVehicle([FromBody] Parking parking)
        {
            try
            {
                Parking result = this.parkingService.ParkVehicle(parking);
                if (result == null)
                {
                    return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "Please check details again", result));
                }

                return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle parked successfully", result));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message));
            }
        }

        /// <summary>
        /// This method used for unpark vehicle using post mapping.
        /// </summary>
        /// <param name="slotNumber">Slot number.</param>
        /// <returns>Action result.</returns>
        [Route("unPark")]
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
        /// This method used for get vehicle by slot number using get mapping.
        /// </summary>
        /// <param name="slotNumber">Slot number.</param>
        /// <returns>Parking details.</returns>
        [Route("search/slotNumber")]
        [HttpGet]
        public ActionResult GetVehicleBySlotNumber(int slotNumber)
        {
            try
            {
                ParkingDetails parking = this.parkingService.GetDetailsBySlotNumber(slotNumber);
                if (parking == null)
                {
                    return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "Plaese check slot number again", parking));
                }

                return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle details found", parking));
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
        [Route("search/vehicleNumber")]
        [HttpGet]
        public ActionResult GetVehicleByVehicleNumber(string vehicleNumber)
        {
            try
            {
                ParkingDetails parking = this.parkingService.GetDetailsByVehicleNumber(vehicleNumber);
                if (parking == null)
                {
                    return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "Plaese check slot number again", parking));
                }

                return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle details found", parking));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message));
            }
        }

        /// <summary>
        /// This method used for get empty slots using get mapping.
        /// </summary>
        /// <returns>List of empty slots.</returns>
        [Route("emptySlots")]
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
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message));
            }
        }

        /// <summary>
        /// This method used for get all parking vehicles data using get mapping.
        /// </summary>
        /// <returns>All parking vehicles data.</returns>
        [Route("allVehicleDetails")]
        [HttpGet]
        public ActionResult GetAllParkingVehiclesData()
        {
            try
            {
                List<ParkingDetails> vehiclesdata = this.parkingService.GetAllParkingVehiclesData();
                if (vehiclesdata.Count > 0)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.OK, "All parking vehicles record found", vehiclesdata));
                }

                return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "No record found", vehiclesdata));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message));
            }
        }
    }
}
