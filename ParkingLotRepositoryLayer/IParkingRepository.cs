// <copyright file="IParkingRepository.cs" company="Bridgelabz">
// Copyright (c) Bridgelabz. All rights reserved.
// </copyright>

namespace ParkingLotRepositoryLayer
{
    using System.Collections.Generic;
    using ParkingLotModelLayer;

    /// <summary>
    /// This interface used to encapsulate repository class.
    /// </summary>
    public interface IParkingRepository
    {
        /// <summary>
        /// This method used for parking new vehicle in parking lot.
        /// </summary>
        /// <param name="parking">Parking data.</param>
        /// <returns>Boolean result.</returns>
        Parking ParkVehicle(Parking parking);

        /// <summary>
        /// This method used for unpark vehicle in parking lot.
        /// </summary>
        /// <param name="slotNumber">Slot number.</param>
        /// <returns>Boolean result.</returns>
        ParkingDetails UnParkVehicle(int slotNumber);

        /// <summary>
        /// This method used for get details by vehicle number.
        /// </summary>
        /// <param name="slotNumber">Slot number.</param>
        /// <returns>Parking details.</returns>
        ParkingDetails GetDetailsBySlotNumber(int slotNumber);

        /// <summary>
        /// This method used for get details by vehicle number.
        /// </summary>
        /// <param name="vehicleNumber">Vehicle number.</param>
        /// <returns>Parking details.</returns>
        ParkingDetails GetDetailsByVehicleNumber(string vehicleNumber);

        /// <summary>
        /// This method used for get empty slots.
        /// </summary>
        /// <returns>Get all empty slots.</returns>
        List<int> GetAllEmptySlot();

        /// <summary>
        /// This method used for get parking vehicles data.
        /// </summary>
        /// <returns>All parking vehicles data.</returns>
        List<ParkingDetails> GetAllParkingVehiclesData();
    }
}
