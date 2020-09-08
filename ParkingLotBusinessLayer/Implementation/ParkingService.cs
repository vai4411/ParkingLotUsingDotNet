// <copyright file="ParkingService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotBusinessLayer
{
    using System.Collections.Generic;
    using ParkingLotModelLayer;
    using ParkingLotRepositoryLayer;

    /// <summary>
    ///  This class used for parking service.
    /// </summary>
    public class ParkingService : IParkingService
    {
        private readonly IParkingRepository parkingRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParkingService"/> class.
        /// </summary>
        /// <param name="parkingRepository">Parking repository.</param>
        public ParkingService(IParkingRepository parkingRepository)
        {
            this.parkingRepository = parkingRepository;
        }

        /// <summary>
        /// This method used for for parking new vehicle in parking lot.
        /// </summary>
        /// <param name="parking">Parking data.</param>
        /// <returns>Boolean result.</returns>
        public Parking ParkVehicle(Parking parking)
        {
            return this.parkingRepository.ParkVehicle(parking);
        }

        /// <summary>
        /// This method used for for unpark in parking lot.
        /// </summary>
        /// <param name="slotNumber">Slot Number.</param>
        /// <returns>Boolean result.</returns>
        public ParkingDetails UnParkVehicle(int slotNumber)
        {
            return this.parkingRepository.UnParkVehicle(slotNumber);
        }

        /// <summary>
        /// This method used for retrive data from slot number.
        /// </summary>
        /// <param name="slotNumber">Slot number.</param>
        /// <returns>Parking details.</returns>
        public ParkingDetails GetDetailsBySlotNumber(int slotNumber)
        {
            return this.parkingRepository.GetDetailsBySlotNumber(slotNumber);
        }

        /// <summary>
        /// This method used for retrive data from vehicle number.
        /// </summary>
        /// <param name="vehicleNumber">Vehicle number.</param>
        /// <returns>Parking details.</returns>
        public ParkingDetails GetDetailsByVehicleNumber(string vehicleNumber)
        {
            return this.parkingRepository.GetDetailsByVehicleNumber(vehicleNumber);
        }

        /// <summary>
        /// This method used for get empty slots.
        /// </summary>
        /// <returns>Get all empty slots.</returns>
        public List<int> GetAllEmptySlot()
        {
            return this.parkingRepository.GetAllEmptySlot();
        }

        /// <summary>
        /// This method used for get parking vehicles data.
        /// </summary>
        /// <returns>All parking vehicles data.</returns>
        public List<ParkingDetails> GetAllParkingVehiclesData()
        {
            return this.parkingRepository.GetAllParkingVehiclesData();
        }

        /// <summary>
        /// This method used for get parking vehicles data by vehicle color.
        /// </summary>
        /// /// <param name="vehicleColor">Vehicle color.</param>
        /// <returns>Parking vehicles data.</returns>
        public List<ParkingDetails> GetDetailsByVehicleColor(string vehicleColor)
        {
            return this.parkingRepository.GetDetailsByVehicleColor(vehicleColor);
        }

        /// <summary>
        /// This method used for get details by vehicle type.
        /// </summary>
        /// <param name="vehicleType">Vehicle type.</param>
        /// <returns>Parking details.</returns>
        public List<ParkingDetails> GetDetailsByVehicleType(int vehicleType)
        {
            return this.parkingRepository.GetDetailsByVehicleType(vehicleType);
        }

        /// <summary>
        /// This method used for delete data from slot number.
        /// </summary>
        /// <param name="slotNumber">Slot number.</param>
        /// <returns>Parking details.</returns>
        public ParkingDetails DeleteDetailsBySlotNumber(int slotNumber)
        {
            return this.parkingRepository.DeleteDetailsBySlotNumber(slotNumber);
        }
    }
}
