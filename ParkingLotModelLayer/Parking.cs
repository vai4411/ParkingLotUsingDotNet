// <copyright file="Parking.cs" company="Bridgelabz">
// Copyright (c) Bridgelabz. All rights reserved.
// </copyright>
namespace ParkingLotModelLayer
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// This class used for parking model.
    /// </summary>
    public class Parking
    {
        /// <summary>
        /// Gets or sets method for slot number.
        /// </summary>
        [Required(ErrorMessage ="Slot number is required")]
        [RegularExpression(@"[0-9]{1,}", ErrorMessage ="Please enter slot number")]
        public int SlotNumber { get; set; }

        /// <summary>
        /// Gets or sets method for vehicle number.
        /// </summary>
        [Required(ErrorMessage = "Vehicle number is required")]
        [RegularExpression(@"[A-z]{2}[ ]?[0-9]{2}[ ]?[0-9]{2,}", ErrorMessage = "Please enter valid vehicle number")]
        public string VehicleNumber { get; set; }

        /// <summary>
        /// Gets or sets method for vehicle type.
        /// </summary>
        [Required(ErrorMessage = "Vehicle type is required")]
        [RegularExpression(@"[0-9]{1,}", ErrorMessage = "Please enter vehicle type id")]
        public int VehicleType { get; set; }

        /// <summary>
        /// Gets or sets method for parking type.
        /// </summary>
        [Required(ErrorMessage = "Parking type is required")]
        [RegularExpression(@"[0-9]{1,}", ErrorMessage = "Please enter parking type id")]
        public int ParkingType { get; set; }

        /// <summary>
        /// Gets or sets method for diver type.
        /// </summary>
        [Required(ErrorMessage = "Driver type is required")]
        [RegularExpression(@"[0-9]{1,}", ErrorMessage = "Please enter driver type id")]
        public int DriverType { get; set; }
    }
}
