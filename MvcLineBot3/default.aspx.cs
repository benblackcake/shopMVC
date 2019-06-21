using isRock.LineBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MvcLineBot3
{
    public partial class _default : System.Web.UI.Page
    {
        const string ChannelAccessToken = "SUMMGaGGy/7H4yewgnOHGpaKZ3BY4BZhtLZIlguM4PM0o0ROfa0WaNETzkzsH+dMAJuQgecMME7MVM7ZtbSDFcw3AbUQnYMQXCPKGWeZgECCqURpxYS7gaRhUswco7NzmiUoevfmnmUQ9ucM8xJKAwdB04t89/1O/w1cDnyilFU=";
        const string AdminUserId = "U4c90f41a5c97ddab5931ef31c5003dc8";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var LiffURL = "https://shopmvc.azurewebsites.net/shopIndex/Index2"; //測試用位置

            //建立LiffApp
            var Liff = isRock.LIFF.Utility.AddLiffApp(
                ChannelAccessToken, new Uri(LiffURL), isRock.LIFF.ViewType.tall);
            //顯示建立好的 Liff App
            isRock.LineBot.Utility.PushMessage(
                AdminUserId, "Liff App 已新增 " + Liff, ChannelAccessToken);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var bot = new Bot(ChannelAccessToken);
            bot.PushMessage(AdminUserId, 1,2);
        }
    }
}