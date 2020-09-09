// <copyright file="MSMQService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotBusinessLayer.Implementation
{
    using System;
    using System.IO;
    using Experimental.System.Messaging;

    /// <summary>
    /// This class used for providing microsoft messaging queue service.
    /// </summary>
    public class MSMQService
    {
        private readonly MessageQueue messageQueue;

        /// <summary>
        /// Initializes a new instance of the <see cref="MSMQService"/> class.
        /// </summary>
        public MSMQService()
        {
            this.messageQueue = new MessageQueue();
            this.messageQueue.Path = @".\private$\Bills";
            if (MessageQueue.Exists(this.messageQueue.Path))
            {
                this.messageQueue = new MessageQueue(this.messageQueue.Path);
            }
            else
            {
                this.messageQueue = MessageQueue.Create(this.messageQueue.Path);
            }
        }

        /// <summary>
        /// This method used for send data to queue.
        /// </summary>
        /// <param name="message">String Message.</param>
        public void SendDataToQueue(string message)
        {
            this.messageQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
            this.messageQueue.ReceiveCompleted += this.MessageQueue_ReceivedCompleted;
            this.messageQueue.Send(message);
            this.messageQueue.BeginReceive();
            this.messageQueue.Close();
        }

        /// <summary>
        /// This method used for receive message.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Receive completed event.</param>
        public void MessageQueue_ReceivedCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            try
            {
                var message = this.messageQueue.EndReceive(e.AsyncResult);
                string data = message.Body.ToString();
                using (StreamWriter file = new StreamWriter(Directory.GetCurrentDirectory() + @"\ParkingRecords.txt"))
                {
                    file.WriteLine(data);
                }

                this.messageQueue.BeginReceive();
            }
            catch (MessageQueueException)
            {
            }
        }
    }
}
