using System;
using System.ComponentModel;
using CallAdmin.Constructor;

namespace CallAdmin.Configs
{
    // Token: 0x0200000B RID: 11
    public sealed class Config
    {
        // Token: 0x17000016 RID: 22
        // (get) Token: 0x0600003F RID: 63 RVA: 0x0000295C File Offset: 0x00000B5C
        // (set) Token: 0x06000040 RID: 64 RVA: 0x00002964 File Offset: 0x00000B64
        [Description("Command names")]
        public string[] CommandAliases { get; set; } = new string[] { "admin", "админ", "help_pls" };

        // Token: 0x17000017 RID: 23
        // (get) Token: 0x06000041 RID: 65 RVA: 0x0000296D File Offset: 0x00000B6D
        // (set) Token: 0x06000042 RID: 66 RVA: 0x00002975 File Offset: 0x00000B75
        [Description("Allow calling the administrator if the reason is empty")]
        public bool AllowEmpty { get; set; }

        // Token: 0x17000018 RID: 24
        // (get) Token: 0x06000043 RID: 67 RVA: 0x0000297E File Offset: 0x00000B7E
        // (set) Token: 0x06000044 RID: 68 RVA: 0x00002986 File Offset: 0x00000B86
        [Description("Call reason max lenght")]
        public ushort MaxLenght { get; set; } = 50;

        // Token: 0x17000019 RID: 25
        // (get) Token: 0x06000045 RID: 69 RVA: 0x0000298F File Offset: 0x00000B8F
        // (set) Token: 0x06000046 RID: 70 RVA: 0x00002997 File Offset: 0x00000B97
        [Description("Cooldown (In seconds)")]
        public ushort Cooldown { get; set; } = 60;

        // Token: 0x1700001A RID: 26
        // (get) Token: 0x06000047 RID: 71 RVA: 0x000029A0 File Offset: 0x00000BA0
        // (set) Token: 0x06000048 RID: 72 RVA: 0x000029A8 File Offset: 0x00000BA8
        [Description("Broadcast that will appear to administrators if they are on the server")]
        public CallBroadcast Broadcast { get; set; } = new CallBroadcast("%player% %id% %userid% called the administrator for a reason %reason%", 10);

        // Token: 0x1700001B RID: 27
        // (get) Token: 0x06000049 RID: 73 RVA: 0x000029B1 File Offset: 0x00000BB1
        // (set) Token: 0x0600004A RID: 74 RVA: 0x000029B9 File Offset: 0x00000BB9
        [Description("Webhook that will be sent if there are admins on the server")]
        public CallWebhook OnlineWebhook { get; set; } = new CallWebhook(string.Empty, "%player% %id% %userid% called the administrator\nAdmins who are on the server: %admin%", "Reason", "%reason%", "%nick% (%userid%) [%group%] %nextline%");

        // Token: 0x1700001C RID: 28
        // (get) Token: 0x0600004B RID: 75 RVA: 0x000029C2 File Offset: 0x00000BC2
        // (set) Token: 0x0600004C RID: 76 RVA: 0x000029CA File Offset: 0x00000BCA
        [Description("Webhook that will be sent if there are no administrators on the server")]
        public CallWebhook OfflineWebhook { get; set; } = new CallWebhook(string.Empty, "%player% %id% %userid% called the administrator", "Reason", "%reason%", string.Empty);

        // Token: 0x1700001D RID: 29
        // (get) Token: 0x0600004D RID: 77 RVA: 0x000029D3 File Offset: 0x00000BD3
        // (set) Token: 0x0600004E RID: 78 RVA: 0x000029DB File Offset: 0x00000BDB
        [Description("Broadcast that will appear to administrators if player reported")]
        public ReportBroadcast LocalReport { get; set; } = new ReportBroadcast("Local report: %playernick% (%playerid%) Reported %targetnick% (%targetid%) for %reason%", 10);

        // Token: 0x1700001E RID: 30
        // (get) Token: 0x0600004F RID: 79 RVA: 0x000029E4 File Offset: 0x00000BE4
        // (set) Token: 0x06000050 RID: 80 RVA: 0x000029EC File Offset: 0x00000BEC
        [Description("Broadcast that will appear to administrators if player cheater reported")]
        public ReportBroadcast CheaterReport { get; set; } = new ReportBroadcast("Cheater report: %playernick% (%playerid%) Reported %targetnick% (%targetid%) for %reason%", 10);

        // Token: 0x1700001F RID: 31
        // (get) Token: 0x06000051 RID: 81 RVA: 0x000029F5 File Offset: 0x00000BF5
        // (set) Token: 0x06000052 RID: 82 RVA: 0x000029FD File Offset: 0x00000BFD
        [Description("Translations")]
        public string CommandDescription { get; set; } = "Call administrator";

        // Token: 0x17000020 RID: 32
        // (get) Token: 0x06000053 RID: 83 RVA: 0x00002A06 File Offset: 0x00000C06
        // (set) Token: 0x06000054 RID: 84 RVA: 0x00002A0E File Offset: 0x00000C0E
        public string CooldownMessage { get; set; } = "You have already called the administrator. You can call admin after %cool_down% seconds";

        // Token: 0x17000021 RID: 33
        // (get) Token: 0x06000055 RID: 85 RVA: 0x00002A17 File Offset: 0x00000C17
        // (set) Token: 0x06000056 RID: 86 RVA: 0x00002A1F File Offset: 0x00000C1F
        public string EmptyReasonMessage { get; set; } = "Please indicate the reason";

        // Token: 0x17000022 RID: 34
        // (get) Token: 0x06000057 RID: 87 RVA: 0x00002A28 File Offset: 0x00000C28
        // (set) Token: 0x06000058 RID: 88 RVA: 0x00002A30 File Offset: 0x00000C30
        public string MaxLenghtMessage { get; set; } = "The maximum text length must be at least %maxlenght% characters.";

        // Token: 0x17000023 RID: 35
        // (get) Token: 0x06000059 RID: 89 RVA: 0x00002A39 File Offset: 0x00000C39
        // (set) Token: 0x0600005A RID: 90 RVA: 0x00002A41 File Offset: 0x00000C41
        public string SuccessfullMessage { get; set; } = "You have successfully called the administrator!";
    }
}
