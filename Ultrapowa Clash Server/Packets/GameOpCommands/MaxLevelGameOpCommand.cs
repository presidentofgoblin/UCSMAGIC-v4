﻿using UCS.Core.Network;
using UCS.Files.Logic;
using UCS.Logic;
using UCS.PacketProcessing;
using UCS.PacketProcessing.Messages.Server;

namespace UCS.Packets.GameOpCommands
{
    internal class MaxLevelGameOpCommand : GameOpCommand
    {
        public MaxLevelGameOpCommand(string[] args)
        {
            SetRequiredAccountPrivileges(0);
        }

        public override void Execute(Level level)
        {
            var buildings = level.GameObjectManager.GetGameObjects(0);
            for (int i = 0; i < buildings.Count; i++)
            {
                var building = (Building)buildings[i];
                var data = (ConstructionItemData)building.GetData();

                building.SetUpgradeLevel(data.GetUpgradeLevelCount() - 1);
            }

            var traps = level.GameObjectManager.GetGameObjects(4);
            for (int i = 0; i < traps.Count; i++)
            {
                var trap = (Trap)traps[i];
                var data = (ConstructionItemData)trap.GetData();

                trap.SetUpgradeLevel(data.GetUpgradeLevelCount() - 1);
            }

            new OwnHomeDataMessage(level.GetClient(), level).Send();
        }
    }
}
