// <copyright file="IParkingService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotBusinessLayer
{
    using ParkingLotModelLayer;

    /// <summary>
    /// This interface used to encapsulate service class.
    /// </summary>
    public interface IParkingService
    {
        /// <summary>
        /// This method used for parking new vehicle in parking lot.
        /// </summary>
        /// <param name="parking">Parking data.</param>
        /// <returns>Boolean result.</returns>
        bool ParkVehicle(Parking parking);

        /// <summary>
        /// This method used for unpark vehicle in parking lot.
        /// </summary>
        /// <param name="slotNumber">Slot number.</param>
        /// <returns>Boolean result.</returns>
        bool UnParkVehicle(int slotNumber);
    }
}
