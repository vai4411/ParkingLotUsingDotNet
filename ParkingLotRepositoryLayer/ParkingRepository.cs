// <copyright file="ParkingRepository.cs" company="Bridgelabz">
// Copyright (c) Bridgelabz. All rights reserved.
// </copyright>

namespace ParkingLotRepositoryLayer
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using Microsoft.Extensions.Configuration;
    using ParkingLotModelLayer;

    /// <summary>
    /// This class used for parking repository.
    /// </summary>
    public class ParkingRepository : IParkingRepository
    {
        private readonly string connectionString;
        private readonly SqlConnection conn;
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParkingRepository"/> class.
        /// </summary>
        /// <param name="configuration">Configuration.</param>
        public ParkingRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = this.configuration.GetSection("ConnectionStrings").GetSection("ParkingLotDBConnection").Value;
            this.conn = new SqlConnection(this.connectionString);
        }

        /// <summary>
        /// This method used for park vehicle.
        /// </summary>
        /// <param name="parking">Parking object.</param>
        /// <returns>Boolean result.</returns>
        public bool ParkVehicle(Parking parking)
        {
            try
            {
                using (this.conn)
                {
                    SqlCommand cmd = new SqlCommand("spPark", this.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Slot_Number", parking.SlotNumber);
                    cmd.Parameters.AddWithValue("@Vehicle_Number", parking.VehicleNumber);
                    cmd.Parameters.AddWithValue("@Vehicle_Type", parking.VehicleType);
                    cmd.Parameters.AddWithValue("@Parking_Type", parking.ParkingType);
                    cmd.Parameters.AddWithValue("@Driver_Type", parking.DriverType);
                    this.conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    this.conn.Close();
                    if (result != 0)
                    {
                        return true;
                    }

                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
