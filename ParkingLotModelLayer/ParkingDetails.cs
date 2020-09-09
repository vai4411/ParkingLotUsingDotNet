// <copyright file="ParkingDetails.cs" company="Bridgelabz">
// Copyright (c) Bridgelabz. All rights reserved.
// </copyright>

namespace ParkingLotModelLayer
{
    /// <summary>
    /// This class used for parking deails model.
    /// </summary>
    public class ParkingDetails
    {
        /// <summary>
        /// Gets or sets method for parking id.
        /// </summary>
        public int ParkingId { get; set; }

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
        /// Gets or sets method for entry time.
        /// </summary>
        public string EntryTime { get; set; }

        /// <summary>
        /// Gets or sets method for parking type.
        /// </summary>
        public int ParkingType { get; set; }

        /// <summary>
        /// Gets or sets method for driver type.
        /// </summary>
        public int DriverType { get; set; }

        /// <summary>
        /// Gets or sets method for exit time.
        /// </summary>
        public string ExitTime { get; set; }

        /// <summary>
        /// Gets or sets method for parking charge.
        /// </summary>
        public int ParkingCharge { get; set; }
    }
}
