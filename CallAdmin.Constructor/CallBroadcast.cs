using System;
using System.Collections.Generic;
using LabApi.Features.Wrappers;

namespace CallAdmin.Constructor
{
    // Token: 0x02000008 RID: 8
    public sealed class CallBroadcast
    {
        // Token: 0x1700000D RID: 13
        // (get) Token: 0x06000023 RID: 35 RVA: 0x00002562 File Offset: 0x00000762
        // (set) Token: 0x06000024 RID: 36 RVA: 0x0000256A File Offset: 0x0000076A
        public string Message { get; set; }

        // Token: 0x1700000E RID: 14
        // (get) Token: 0x06000025 RID: 37 RVA: 0x00002573 File Offset: 0x00000773
        // (set) Token: 0x06000026 RID: 38 RVA: 0x0000257B File Offset: 0x0000077B
        public ushort Duration { get; set; }

        // Token: 0x06000027 RID: 39 RVA: 0x00002584 File Offset: 0x00000784
        public CallBroadcast()
        {
        }

        // Token: 0x06000028 RID: 40 RVA: 0x0000258C File Offset: 0x0000078C
        public CallBroadcast(string message, ushort duration)
        {
            this.Duration = this.Duration;
            this.Message = this.Message;
        }

        // Token: 0x06000029 RID: 41 RVA: 0x000025AC File Offset: 0x000007AC
        public void Send(Player player, string reason, IEnumerable<Player> admins)
        {
            string text = this.Message.Replace("%player%", player.Nickname).Replace("%id%", player.PlayerId.ToString()).Replace("%userid%", player.UserId)
                .Replace("%reason%", reason);
            foreach (Player player2 in admins)
            {
                player2.ClearBroadcasts();
                player2.SendBroadcast(text, this.Duration, Broadcast.BroadcastFlags.Normal, false);
            }
        }
    }
}
