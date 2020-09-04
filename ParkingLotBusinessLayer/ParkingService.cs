﻿// <copyright file="ParkingService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotBusinessLayer
{
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
        public bool ParkVehicle(Parking parking)
        {
            return this.parkingRepository.ParkVehicle(parking);
        }
    }
}
