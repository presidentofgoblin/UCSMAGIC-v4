﻿using System.IO;
using UCS.Core.Network;
using UCS.Helpers;
using UCS.Logic;
using UCS.PacketProcessing.Messages.Server;

namespace UCS.PacketProcessing.Messages.Client
{
    internal class AskForFriendListMessage : Message
    {
        public AskForFriendListMessage(PacketProcessing.Client client, PacketReader br)
            : base(client, br)
        {
        }

        public override void Decode()
        {
        }

        public override void Process(Level level)
        {
            new FriendListMessage(Client).Send();
        }
    }
}