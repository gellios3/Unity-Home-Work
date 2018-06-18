﻿using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

namespace Server.Handlers
{
    public class ChatMessageHandler : IServerHandler
    {
        public short MessageType => MsgId.echoMsgId;

        private readonly NetworkingGameServer _gameServerConnector;

        public ChatMessageHandler(NetworkingGameServer gameServerConnector)
        {
            _gameServerConnector = gameServerConnector;
        }

        public void Handle(NetworkMessage message)
        {
            var echoMsg = message.ReadMessage<StringMessage>().value;
            echoMsg += " from server";

            var responseMsg = new StringMessage(echoMsg);
            _gameServerConnector.Send(_gameServerConnector.ActiveConnections, MsgId.echoServerResponse, responseMsg);
        }
    }
}