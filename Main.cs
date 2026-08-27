using System;
using CallAdmin.Commands;
using CallAdmin.Configs;
using CallAdmin.EventHandlers;
using LabApi.Loader.Features.Plugins;
using RemoteAdmin;

namespace CallAdmin
{
    // Token: 0x02000006 RID: 6
    public sealed class Main : Plugin<Config>
    {
        // Token: 0x17000007 RID: 7
        // (get) Token: 0x06000014 RID: 20 RVA: 0x000023F7 File Offset: 0x000005F7
        public override string Name { get; } = "CallAdmin";

        // Token: 0x17000008 RID: 8
        // (get) Token: 0x06000015 RID: 21 RVA: 0x000023FF File Offset: 0x000005FF
        public override string Author { get; } = "PAPAROMA511";

        // Token: 0x17000009 RID: 9
        // (get) Token: 0x06000016 RID: 22 RVA: 0x00002407 File Offset: 0x00000607
        public override string Description { get; } = "CallAdmin";

        // Token: 0x1700000A RID: 10
        // (get) Token: 0x06000017 RID: 23 RVA: 0x0000240F File Offset: 0x0000060F
        public override Version Version { get; } = new Version(1, 0, 0);

        // Token: 0x1700000B RID: 11
        // (get) Token: 0x06000018 RID: 24 RVA: 0x00002417 File Offset: 0x00000617
        public override Version RequiredApiVersion { get; } = new Version(1, 1, 4);

        // Token: 0x1700000C RID: 12
        // (get) Token: 0x06000019 RID: 25 RVA: 0x0000241F File Offset: 0x0000061F
        // (set) Token: 0x0600001A RID: 26 RVA: 0x00002426 File Offset: 0x00000626
        internal static Config PluginConfig { get; private set; }

        // Token: 0x0600001B RID: 27 RVA: 0x0000242E File Offset: 0x0000062E
        public override void Enable()
        {
            Main.PluginConfig = base.Config;
            this._playerEvents = new PlayerEvents();
            this._playerEvents.RegisterEvents();
            QueryProcessor.DotCommandHandler.RegisterCommand(new Call());
        }

        // Token: 0x0600001C RID: 28 RVA: 0x00002460 File Offset: 0x00000660
        public override void Disable()
        {
            this._playerEvents.UnRegisterEvents();
            Main.PluginConfig = null;
            this._playerEvents = null;
        }

        // Token: 0x0400000D RID: 13
        private PlayerEvents _playerEvents;
    }
}