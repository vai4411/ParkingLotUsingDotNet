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

        /// <summary>
        /// This method used for unpark vehicle.
        /// </summary>
        /// <param name="slotNumber">Slot number.</param>
        /// <returns>Boolean result.</returns>
        public bool UnParkVehicle(int slotNumber)
        {
            try
            {
                using (this.conn)
                {
                    SqlCommand cmd = new SqlCommand("spUnPark", this.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Slot_Number", slotNumber);
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

        /// <summary>
        /// This method used for retrive data from slot number.
        /// </summary>
        /// <param name="slotNumber">Slot number.</param>
        /// <returns>Parking details.</returns>
        public Parking GetDetailsBySlotNumber(int slotNumber)
        {
            try
            {
                using (this.conn)
                {
                    Parking parkingLot = new Parking();
                    SqlCommand cmd = new SqlCommand("spGetVehicleBySlotNumber", this.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SlotNumber", slotNumber);
                    this.conn.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            parkingLot.SlotNumber = Convert.ToInt32(sqlDataReader["SLOT_NUMBER"]);
                            parkingLot.VehicleNumber = sqlDataReader["VEHICLE_NUMBER"].ToString();
                            parkingLot.ParkingType = Convert.ToInt32(sqlDataReader["PARKING_TYPE"]);
                            parkingLot.VehicleType = Convert.ToInt32(sqlDataReader["VEHICLE_TYPE"]);
                            parkingLot.DriverType = Convert.ToInt32(sqlDataReader["DRIVER_TYPE"]);
                        }

                        this.conn.Close();
                        return parkingLot;
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
        public Parking GetDetailsByVehicleNumber(string vehicleNumber)
        {
            try
            {
                using (this.conn)
                {
                    Parking parkingLot = new Parking();
                    SqlCommand cmd = new SqlCommand("spGetVehicleByVehicleNumber", this.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@VehicleNumber", vehicleNumber);
                    this.conn.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            parkingLot.SlotNumber = Convert.ToInt32(sqlDataReader["SLOT_NUMBER"]);
                            parkingLot.VehicleNumber = sqlDataReader["VEHICLE_NUMBER"].ToString();
                            parkingLot.ParkingType = Convert.ToInt32(sqlDataReader["PARKING_TYPE"]);
                            parkingLot.VehicleType = Convert.ToInt32(sqlDataReader["VEHICLE_TYPE"]);
                            parkingLot.DriverType = Convert.ToInt32(sqlDataReader["DRIVER_TYPE"]);
                        }

                        this.conn.Close();
                        return parkingLot;
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
                            Parking parkingLot = new Parking();
                            parkingLot.SlotNumber = Convert.ToInt32(sqlDataReader["SLOT_NUMBER"]);
                            emptySlots.Add(parkingLot.SlotNumber);
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
        public List<Parking> GetAllParkingVehiclesData()
        {
            try
            {
                using (this.conn)
                {
                    List<Parking> parkingData = new List<Parking>();
                    SqlCommand cmd = new SqlCommand("spGetParkingVehiclesData", this.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    this.conn.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Parking parkingLot = new Parking();
                            parkingLot.SlotNumber = Convert.ToInt32(sqlDataReader["SLOT_NUMBER"]);
                            parkingLot.VehicleNumber = sqlDataReader["VEHICLE_NUMBER"].ToString();
                            parkingLot.ParkingType = Convert.ToInt32(sqlDataReader["PARKING_TYPE"]);
                            parkingLot.VehicleType = Convert.ToInt32(sqlDataReader["VEHICLE_TYPE"]);
                            parkingLot.DriverType = Convert.ToInt32(sqlDataReader["DRIVER_TYPE"]);
                            parkingData.Add(parkingLot);
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
    }
}
