using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CommandSystem;
using LabApi.Features.Wrappers;
using UnityEngine;

namespace CallAdmin.Commands
{
    // Token: 0x0200000C RID: 12
    internal sealed class Call : ICommand
    {
        // Token: 0x17000024 RID: 36
        // (get) Token: 0x0600005C RID: 92 RVA: 0x00002B48 File Offset: 0x00000D48
        public string Command { get; } = "call";

        // Token: 0x17000025 RID: 37
        // (get) Token: 0x0600005D RID: 93 RVA: 0x00002B50 File Offset: 0x00000D50
        public string[] Aliases { get; } = Enumerable.ToArray<string>(Main.PluginConfig.CommandAliases);

        // Token: 0x17000026 RID: 38
        // (get) Token: 0x0600005E RID: 94 RVA: 0x00002B58 File Offset: 0x00000D58
        public string Description { get; } = Main.PluginConfig.CommandDescription;

        // Token: 0x0600005F RID: 95 RVA: 0x00002B60 File Offset: 0x00000D60
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);
            float num;
            if (this.CoolDown.TryGetValue(player.UserId, ref num) && num > Time.time)
            {
                response = Main.PluginConfig.CooldownMessage.Replace("%cool_down%", (num - Time.time).ToString());
                return false;
            }
            string text = string.Empty;
            if (!Enumerable.Any<string>(arguments))
            {
                if (!Main.PluginConfig.AllowEmpty)
                {
                    response = Main.PluginConfig.EmptyReasonMessage;
                    return false;
                }
                text = "None";
            }
            foreach (string text2 in arguments)
            {
                text = text + text2 + " ";
            }
            if (text.Length > (int)Main.PluginConfig.MaxLenght)
            {
                response = Main.PluginConfig.MaxLenghtMessage.Replace("%maxlenght%", Main.PluginConfig.MaxLenght.ToString());
                return false;
            }
            text = Regex.Replace(text, "<.*?>", string.Empty);
            Player[] array = Enumerable.ToArray<Player>(Enumerable.Where<Player>(Player.List, (Player p) => player != p && p.HasPermission(PlayerPermissions.KickingAndShortTermBanning)));
            if (Enumerable.Any<Player>(array))
            {
                Main.PluginConfig.Broadcast.Send(player, text, array);
                Main.PluginConfig.OnlineWebhook.Send(player, text, array);
            }
            else
            {
                Main.PluginConfig.OfflineWebhook.Send(player, text, null);
            }
            this.CoolDown[player.UserId] = Time.time + (float)Main.PluginConfig.Cooldown;
            response = Main.PluginConfig.SuccessfullMessage;
            return true;
        }

        // Token: 0x04000028 RID: 40
        private readonly Dictionary<string, float> CoolDown = new Dictionary<string, float>();
    }
}
