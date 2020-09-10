// <copyright file="PoliceController.cs" company="Bridgelabz">
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
        [Route("park")]
        [HttpPost]
        public ActionResult ParkVehicle([FromBody] Parking parking)
        {
            try
            {
                ParkingDetails result = this.parkingService.ParkVehicle(parking);
                if (result == null)
                {
                    return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "Please check details again"));
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
                    return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "Please check details again"));
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
        [Route("search/&vehicleNumber={vehicleNumber}")]
        [HttpGet]
        public ActionResult GetVehicleByVehicleNumber(string vehicleNumber)
        {
            try
            {
                ParkingDetails parking = this.parkingService.GetDetailsByVehicleNumber(vehicleNumber);
                if (parking == null)
                {
                    return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "Plaese check slot number again"));
                }

                return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle details found", parking));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message));
            }
        }

        /// <summary>
        /// This method used for get vehicle by vehicle type using get mapping.
        /// </summary>
        /// <param name="vehicleType">Vehicle type.</param>
        /// <returns>Parking details.</returns>
        [Route("search/&vehicleType={vehicleType}")]
        [HttpGet]
        public ActionResult GetVehicleByVehicleType(int vehicleType)
        {
            try
            {
                List<ParkingDetails> parking = this.parkingService.GetDetailsByVehicleType(vehicleType);
                if (parking.Count > 0)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle details found", parking));
                }

                return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "Plaese check vehicle type again"));
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
        [Route("search/&slotNumber={slotNumber}")]
        [HttpGet]
        public ActionResult GetVehicleBySlotNumber(int slotNumber)
        {
            try
            {
                ParkingDetails parking = this.parkingService.GetDetailsBySlotNumber(slotNumber);
                if (parking == null)
                {
                    return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "Plaese check slot number again"));
                }

                return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle details found", parking));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message));
            }
        }

        /// <summary>
        /// This method used for get vehicle count by vehicle type using get mapping.
        /// </summary>
        /// <param name="vehicleType">Vehicle type.</param>
        /// <returns>Parking details.</returns>
        [Route("count/{vehicleType}")]
        [HttpGet]
        public ActionResult GetTotalVehicleCountByVehicleType(int vehicleType)
        {
            try
            {
                List<ParkingDetails> parking = this.parkingService.GetDetailsByVehicleType(vehicleType);
                if (parking.Count > 0)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle details found", parking.Count));
                }

                return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "Plaese check vehicle type again"));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message));
            }
        }
    }
}
