// <copyright file="ResponseEntity.cs" company="Bridgelabz">
// Copyright (c) Bridgelabz. All rights reserved.
// </copyright>

namespace ParkingLotModelLayer
{
    using System.Net;

    /// <summary>
    /// This class used as reponse entity model.
    /// </summary>
    public class ResponseEntity
    {
        /// <summary>
        /// This variable used for storing status code.
        /// </summary>
        public HttpStatusCode HttpStatusCode;

        /// <summary>
        /// This variable used for storing message.
        /// </summary>
        public string Message;

        /// <summary>
        /// This variable used for storing actual data.
        /// </summary>
        public object Data;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseEntity"/> class.
        /// </summary>
        /// <param name="statusCode">Http status code.</param>
        /// <param name="message">String message.</param>
        /// <param name="data">Object data.</param>
        public ResponseEntity(HttpStatusCode statusCode, string message, object data)
        {
            this.HttpStatusCode = statusCode;
            this.Message = message;
            this.Data = data;
        }
    }
}
