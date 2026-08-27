using System;
using System.Collections.Generic;
using System.Linq;
using LabApi.Features.Wrappers;

namespace CallAdmin.Constructor
{
    // Token: 0x02000009 RID: 9
    public sealed class CallWebhook
    {
        // Token: 0x1700000F RID: 15
        // (get) Token: 0x0600002A RID: 42 RVA: 0x0000264C File Offset: 0x0000084C
        // (set) Token: 0x0600002B RID: 43 RVA: 0x00002654 File Offset: 0x00000854
        public string URL { get; set; }

        // Token: 0x17000010 RID: 16
        // (get) Token: 0x0600002C RID: 44 RVA: 0x0000265D File Offset: 0x0000085D
        // (set) Token: 0x0600002D RID: 45 RVA: 0x00002665 File Offset: 0x00000865
        public string Text { get; set; }

        // Token: 0x17000011 RID: 17
        // (get) Token: 0x0600002E RID: 46 RVA: 0x0000266E File Offset: 0x0000086E
        // (set) Token: 0x0600002F RID: 47 RVA: 0x00002676 File Offset: 0x00000876
        public string Title { get; set; }

        // Token: 0x17000012 RID: 18
        // (get) Token: 0x06000030 RID: 48 RVA: 0x0000267F File Offset: 0x0000087F
        // (set) Token: 0x06000031 RID: 49 RVA: 0x00002687 File Offset: 0x00000887
        public string Description { get; set; }

        // Token: 0x17000013 RID: 19
        // (get) Token: 0x06000032 RID: 50 RVA: 0x00002690 File Offset: 0x00000890
        // (set) Token: 0x06000033 RID: 51 RVA: 0x00002698 File Offset: 0x00000898
        public string Admins { get; set; }

        // Token: 0x06000034 RID: 52 RVA: 0x000026A1 File Offset: 0x000008A1
        public CallWebhook()
        {
        }

        // Token: 0x06000035 RID: 53 RVA: 0x000026A9 File Offset: 0x000008A9
        public CallWebhook(string url, string text, string title, string description, string admin)
        {
            this.URL = url;
            this.Text = text;
            this.Title = title;
            this.Description = description;
            this.Admins = admin;
        }

        // Token: 0x06000036 RID: 54 RVA: 0x000026D8 File Offset: 0x000008D8
        public void Send(Player player, string reason, IEnumerable<Player> admins = null)
        {
            string text = string.Empty;
            if (admins != null && Enumerable.Any<Player>(admins) && this.Admins != null)
            {
                foreach (Player player2 in admins)
                {
                    string text2 = text;
                    string text3 = this.Admins.Replace("%nick%", player2.Nickname).Replace("%userid%", player2.UserId);
                    string text4 = "%group%";
                    UserGroup userGroup = player2.UserGroup;
                    text = text2 + text3.Replace(text4, ((userGroup != null) ? userGroup.Name : null) ?? "NULL").Replace("%nextline%", "\n");
                }
            }
            string text5 = this.Validate(this.Text, player, reason, text);
            string text6 = this.Validate(this.Title, player, reason, text);
            string text7 = this.Validate(this.Description, player, reason, text);
            WebHook.Send(this.URL, text5, text6, text7);
        }

        // Token: 0x06000037 RID: 55 RVA: 0x000027E4 File Offset: 0x000009E4
        private string Validate(string text, Player player, string reason, string admins)
        {
            return text.Replace("%player%", player.Nickname).Replace("%id%", player.PlayerId.ToString()).Replace("%userid%", player.UserId)
                .Replace("%reason%", reason)
                .Replace("%admin%", admins)
                .Replace("\n", "\n");
        }
    }
}
