// <copyright file="ParkingRepository.cs" company="Bridgelabz">
// Copyright (c) Bridgelabz. All rights reserved.
// </copyright>

namespace ParkingLotRepositoryLayer
{
    using System;
    using System.Collections.Generic;
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
        /// This method used for storing data in parking detail object.
        /// </summary>
        /// <param name="sqlDataReader">Sql reader.</param>
        /// <returns>Parking details.</returns>
        public ParkingDetails VehicleDetails(SqlDataReader sqlDataReader)
        {
            ParkingDetails parkingDetails = new ParkingDetails();
            parkingDetails.ParkingId = Convert.ToInt32(sqlDataReader["PARKING_ID"]);
            parkingDetails.SlotNumber = Convert.ToInt32(sqlDataReader["SLOT_NUMBER"]);
            parkingDetails.VehicleNumber = sqlDataReader["VEHICLE_NUMBER"].ToString();
            parkingDetails.ParkingType = Convert.ToInt32(sqlDataReader["PARKING_TYPE"]);
            parkingDetails.VehicleType = Convert.ToInt32(sqlDataReader["VEHICLE_TYPE"]);
            parkingDetails.DriverType = Convert.ToInt32(sqlDataReader["DRIVER_TYPE"]);
            parkingDetails.EntryTime = sqlDataReader["Entry_Time"].ToString();
            parkingDetails.ExitTime = sqlDataReader["Exit_Time"].ToString();
            parkingDetails.ParkingCharge = Convert.ToInt32(sqlDataReader["PARKING_CHARGE"]);
            parkingDetails.VehicleColor = sqlDataReader["Vehicle_Color"].ToString();
            return parkingDetails;
        }

        /// <summary>
        /// This method used for park vehicle.
        /// </summary>
        /// <param name="parking">Parking object.</param>
        /// <returns>Parking <see cref="object"/>.</returns>
        public Parking ParkVehicle(Parking parking)
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
                    if (result != 0)
                    {
                        return parking;
                    }

                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// This method used for unpark vehicle.
        /// </summary>
        /// <param name="slotNumber">Slot number.</param>
        /// <returns>Boolean result.</returns>
        public ParkingDetails UnParkVehicle(int slotNumber)
        {
            try
            {
                using (this.conn)
                {
                    ParkingDetails parkingDetails = new ParkingDetails();
                    SqlCommand cmd = new SqlCommand("spUnPark", this.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Slot_Number", slotNumber);
                    this.conn.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            parkingDetails = this.VehicleDetails(sqlDataReader);
                        }

                        this.conn.Close();
                        return parkingDetails;
                    }

                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// This method used for retrive data from slot number.
        /// </summary>
        /// <param name="slotNumber">Slot number.</param>
        /// <returns>Parking details.</returns>
        public ParkingDetails GetDetailsBySlotNumber(int slotNumber)
        {
            try
            {
                using (this.conn)
                {
                    ParkingDetails parkingDetails = new ParkingDetails();
                    SqlCommand cmd = new SqlCommand("spGetVehicleBySlotNumber", this.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SlotNumber", slotNumber);
                    this.conn.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            parkingDetails = this.VehicleDetails(sqlDataReader);
                        }

                        this.conn.Close();
                        return parkingDetails;
                    }

                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// This method used for retrive data from vehicle number.
        /// </summary>
        /// <param name="vehicleNumber">Vehicle number.</param>
        /// <returns>Parking details.</returns>
        public ParkingDetails GetDetailsByVehicleNumber(string vehicleNumber)
        {
            try
            {
                using (this.conn)
                {
                    ParkingDetails parkingDetails = new ParkingDetails();
                    SqlCommand cmd = new SqlCommand("spGetVehicleByVehicleNumber", this.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@VehicleNumber", vehicleNumber);
                    this.conn.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            parkingDetails = this.VehicleDetails(sqlDataReader);
                        }

                        this.conn.Close();
                        return parkingDetails;
                    }

                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// This method used for get empty slots.
        /// </summary>
        /// <returns>Get all empty slots.</returns>
        public List<int> GetAllEmptySlot()
        {
            try
            {
                using (this.conn)
                {
                    List<int> emptySlots = new List<int>();
                    SqlCommand cmd = new SqlCommand("spGetEmptySlots", this.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    this.conn.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            emptySlots.Add(Convert.ToInt32(sqlDataReader["SLOT_NUMBER"]));
                        }

                        this.conn.Close();
                        return emptySlots;
                    }

                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// This method used for get all parking vehicles data.
        /// </summary>
        /// <returns>All parking vehicles data.</returns>
        public List<ParkingDetails> GetAllParkingVehiclesData()
        {
            try
            {
                using (this.conn)
                {
                    List<ParkingDetails> parkingData = new List<ParkingDetails>();
                    SqlCommand cmd = new SqlCommand("spGetParkingVehiclesData", this.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    this.conn.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            ParkingDetails parkingDetails = new ParkingDetails();
                            parkingDetails = this.VehicleDetails(sqlDataReader);
                            parkingData.Add(parkingDetails);
                        }

                        this.conn.Close();
                        return parkingData;
                    }

                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// This method used for get details by vehicle number.
        /// </summary>
        /// <param name="vehicleColor">Vehicle color.</param>
        /// <returns>Parking details.</returns>
        public ParkingDetails GetDetailsByVehicleColor(string vehicleColor)
        {
            try
            {
                using (this.conn)
                {
                    ParkingDetails parkingDetails = new ParkingDetails();
                    SqlCommand cmd = new SqlCommand("spGetVehicleByVehicleColor", this.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Vehicle_Color", vehicleColor);
                    this.conn.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            parkingDetails = this.VehicleDetails(sqlDataReader);
                        }

                        this.conn.Close();
                        return parkingDetails;
                    }

                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
