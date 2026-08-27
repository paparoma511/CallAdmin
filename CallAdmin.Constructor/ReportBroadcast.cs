using System;
using LabApi.Features.Wrappers;

namespace CallAdmin.Constructor
{
    // Token: 0x0200000A RID: 10
    public sealed class ReportBroadcast
    {
        // Token: 0x17000014 RID: 20
        // (get) Token: 0x06000038 RID: 56 RVA: 0x00002850 File Offset: 0x00000A50
        // (set) Token: 0x06000039 RID: 57 RVA: 0x00002858 File Offset: 0x00000A58
        public string Message { get; set; }

        // Token: 0x17000015 RID: 21
        // (get) Token: 0x0600003A RID: 58 RVA: 0x00002861 File Offset: 0x00000A61
        // (set) Token: 0x0600003B RID: 59 RVA: 0x00002869 File Offset: 0x00000A69
        public ushort Duration { get; set; }

        // Token: 0x0600003C RID: 60 RVA: 0x00002872 File Offset: 0x00000A72
        public ReportBroadcast()
        {
        }

        // Token: 0x0600003D RID: 61 RVA: 0x0000287A File Offset: 0x00000A7A
        public ReportBroadcast(string message, ushort duration)
        {
            this.Message = message;
            this.Duration = duration;
        }

        // Token: 0x0600003E RID: 62 RVA: 0x00002890 File Offset: 0x00000A90
        public void Send(Player player, Player target, string reason)
        {
            string text = this.Message.Replace("%playernick%", player.Nickname).Replace("%playerid%", player.UserId).Replace("%targetnick%", target.Nickname)
                .Replace("%targetid%", target.UserId)
                .Replace("%reason%", reason);
            foreach (Player player2 in Player.List)
            {
                if (!player2.IsDestroyed && !player2.IsHost && !player2.IsDummy && player2 != player && player2.HasPermission(PlayerPermissions.KickingAndShortTermBanning))
                {
                    player2.SendBroadcast(text, this.Duration, Broadcast.BroadcastFlags.Normal, false);
                }
            }
        }
    }
}
