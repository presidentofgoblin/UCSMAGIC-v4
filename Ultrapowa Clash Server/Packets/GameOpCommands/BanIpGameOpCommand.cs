using System;
using UCS.Core;
using UCS.Core.Network;
using UCS.Logic;
using UCS.PacketProcessing.Messages.Server;

namespace UCS.PacketProcessing.GameOpCommands
{
    internal class BanIpGameOpCommand : GameOpCommand
    {
        readonly string[] m_vArgs;

        public BanIpGameOpCommand(string[] args)
        {
            m_vArgs = args;
            SetRequiredAccountPrivileges(3);
        }

        public override void Execute(Level level)
        {
            if (level.GetAccountPrivileges() >= GetRequiredAccountPrivileges())
                if (m_vArgs.Length >= 1)
                    try
                    {
                        var id = Convert.ToInt64(m_vArgs[1]);
                        var l = ResourcesManager.GetPlayer(id);
                        if (l != null)
                            if (l.GetAccountPrivileges() < level.GetAccountPrivileges())
                            {
                                l.SetAccountStatus(99);
                                l.SetAccountPrivileges(0);
                                if (ResourcesManager.IsPlayerOnline(l))
                                {
                                    new OutOfSyncMessage(l.GetClient()).Send();
                                }
                            }
                            else
                            {
                            }
                        else
                        {
                        }
                    }
                    catch 
                    {
                    }
                else
                    SendCommandFailedMessage(level.GetClient());
        }
    }
}
