using System;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.Handlers;

namespace CallAdmin.EventHandlers
{
    // Token: 0x02000007 RID: 7
    internal sealed class PlayerEvents
    {
        // Token: 0x0600001E RID: 30 RVA: 0x000024CC File Offset: 0x000006CC
        internal void RegisterEvents()
        {
            PlayerEvents.ReportedPlayer += this.OnReportedPlayer;
            PlayerEvents.ReportedCheater += this.OnReportedCheater;
        }

        // Token: 0x0600001F RID: 31 RVA: 0x000024F0 File Offset: 0x000006F0
        internal void UnRegisterEvents()
        {
            PlayerEvents.ReportedPlayer -= this.OnReportedPlayer;
            PlayerEvents.ReportedCheater -= this.OnReportedCheater;
        }

        // Token: 0x06000020 RID: 32 RVA: 0x00002514 File Offset: 0x00000714
        private void OnReportedCheater(PlayerReportedCheaterEventArgs ev)
        {
            Main.PluginConfig.CheaterReport.Send(ev.Player, ev.Target, ev.Reason);
        }

        // Token: 0x06000021 RID: 33 RVA: 0x00002537 File Offset: 0x00000737
        private void OnReportedPlayer(PlayerReportedPlayerEventArgs ev)
        {
            Main.PluginConfig.LocalReport.Send(ev.Player, ev.Target, ev.Reason);
        }
    }
}
