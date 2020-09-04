// <copyright file="Parking.cs" company="Bridgelabz">
// Copyright (c) Bridgelabz. All rights reserved.
// </copyright>
namespace ParkingLotModelLayer
{
    /// <summary>
    /// This class used for parking model.
    /// </summary>
    public class Parking
    {
        /// <summary>
        /// Gets or sets method for slot number.
        /// </summary>
        public int SlotNumber { get; set; }

        /// <summary>
        /// Gets or sets method for vehicle number.
        /// </summary>
        public string VehicleNumber { get; set; }

        /// <summary>
        /// Gets or sets method for vehicle type.
        /// </summary>
        public int VehicleType { get; set; }

        /// <summary>
        /// Gets or sets method for parking type.
        /// </summary>
        public int ParkingType { get; set; }

        /// <summary>
        /// Gets or sets method for diver type.
        /// </summary>
        public int DriverType { get; set; }
    }
}
