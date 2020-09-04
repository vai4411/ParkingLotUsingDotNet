// <copyright file="IParkingRepository.cs" company="Bridgelabz">
// Copyright (c) Bridgelabz. All rights reserved.
// </copyright>

namespace ParkingLotRepositoryLayer
{
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
        bool ParkVehicle(Parking parking);
    }
}
