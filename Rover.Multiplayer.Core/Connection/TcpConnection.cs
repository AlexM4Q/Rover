﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using Rover.Multiplayer.Core.Models.Messages;

namespace Rover.Multiplayer.Core.Connection {

    /// <summary>
    /// TCP соединения
    /// </summary>
    public class TcpConnection : RemoteConnection {

        /// <summary>
        /// Очередь сообщений
        /// </summary>
        protected readonly IList<MessageBase> MessagesQueue;

        /// <summary>
        /// TCP клиент
        /// </summary>
        internal readonly TcpClient TcpClient;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="client">TCP клиент</param>
        public TcpConnection(TcpClient client) {
            MessagesQueue = new List<MessageBase>();

            TcpClient = client;
            TcpClient.ReceiveBufferSize = 60 * 1024;
            TcpClient.SendBufferSize = 60 * 1024;
        }

        /// <summary>
        /// Отключение
        /// </summary>
        public override void Dispose() => TcpClient?.Dispose();

        /// <summary>
        /// Добавление сообщения в очередь на отправку
        /// </summary>
        /// <param name="message">Сообщения</param>
        public void Send(MessageBase message) => MessagesQueue.Add(message);

        /// <summary>
        /// Процесс получения сообщений
        /// </summary>
        protected override void Receiving() {
            while (Connected) {
                if (TcpClient.Available > 0) {
                    try {
                        OnMessage(new BinaryFormatter().Deserialize(TcpClient.GetStream()) as MessageBase);
                    } catch (Exception e) {
                        Debug.WriteLine(e);
                    }
                }

                Thread.Sleep(ReceivingDelay);
            }
        }

        /// <summary>
        /// Процесс отправки сообщений
        /// </summary>
        protected override void Sending() {
            while (Connected) {
                if (MessagesQueue.Count > 0) {
                    var message = MessagesQueue[0];

                    try {
                        new BinaryFormatter().Serialize(TcpClient.GetStream(), message);
                    } catch (Exception e) {
                        Debug.WriteLine(e);
                    } finally {
                        MessagesQueue.Remove(message);
                    }
                }

                Thread.Sleep(SendingDelay);
            }
        }

    }

}