using isRock.LineBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MvcLineBot
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
                ChannelAccessToken, new Uri(LiffURL), isRock.LIFF.ViewType.full);
            //顯示建立好的 Liff App
            isRock.LineBot.Utility.PushMessage(
                AdminUserId, "Liff App 已新增 " + Liff, ChannelAccessToken);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var bot = new Bot(ChannelAccessToken);
            bot.PushMessage(AdminUserId, 1,2);
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            var LiffURL = "https://shopmvc.azurewebsites.net/shopProduct/Index/?category=124"; //測試用位置

            //建立LiffApp
            var Liff = isRock.LIFF.Utility.AddLiffApp(
                ChannelAccessToken, new Uri(LiffURL), isRock.LIFF.ViewType.tall);
            //顯示建立好的 Liff App
            isRock.LineBot.Utility.PushMessage(
                AdminUserId, "Liff App 已新增 " + Liff, ChannelAccessToken);
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            var LiffURL = "https://shopmvc.azurewebsites.net/shopProduct/Index/?subcategory=12101"; //測試用位置

            //建立LiffApp
            var Liff = isRock.LIFF.Utility.AddLiffApp(
                ChannelAccessToken, new Uri(LiffURL), isRock.LIFF.ViewType.tall);
            //顯示建立好的 Liff App
            isRock.LineBot.Utility.PushMessage(
                AdminUserId, "Liff App 已新增 " + Liff, ChannelAccessToken);
        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            var LiffURL = "https://shopmvc.azurewebsites.net/shopProduct/Index/?subcategory=12102"; //測試用位置

            //建立LiffApp
            var Liff = isRock.LIFF.Utility.AddLiffApp(
                ChannelAccessToken, new Uri(LiffURL), isRock.LIFF.ViewType.tall);
            //顯示建立好的 Liff App
            isRock.LineBot.Utility.PushMessage(
                AdminUserId, "Liff App 已新增 " + Liff, ChannelAccessToken);
        }
        protected void Button6_Click(object sender, EventArgs e)
        {
            var LiffURL = "https://shopmvc.azurewebsites.net/shopProduct/Index/?subcategory=12103"; //測試用位置

            //建立LiffApp
            var Liff = isRock.LIFF.Utility.AddLiffApp(
                ChannelAccessToken, new Uri(LiffURL), isRock.LIFF.ViewType.tall);
            //顯示建立好的 Liff App
            isRock.LineBot.Utility.PushMessage(
                AdminUserId, "Liff App 已新增 " + Liff, ChannelAccessToken);
        }
        protected void Button7_Click(object sender, EventArgs e)
        {
            var LiffURL = "https://shopmvc.azurewebsites.net/shopProduct/Index/?subcategory=12104"; //測試用位置

            //建立LiffApp
            var Liff = isRock.LIFF.Utility.AddLiffApp(
                ChannelAccessToken, new Uri(LiffURL), isRock.LIFF.ViewType.tall);
            //顯示建立好的 Liff App
            isRock.LineBot.Utility.PushMessage(
                AdminUserId, "Liff App 已新增 " + Liff, ChannelAccessToken);
        }
        protected void Button8_Click(object sender, EventArgs e)
        {
            var LiffURL = "https://shopmvc.azurewebsites.net/shopProduct/Index/?subcategory=12105"; //測試用位置

            //建立LiffApp
            var Liff = isRock.LIFF.Utility.AddLiffApp(
                ChannelAccessToken, new Uri(LiffURL), isRock.LIFF.ViewType.tall);
            //顯示建立好的 Liff App
            isRock.LineBot.Utility.PushMessage(
                AdminUserId, "Liff App 已新增 " + Liff, ChannelAccessToken);
        }
        protected void Button9_Click(object sender, EventArgs e)
        {
            var LiffURL = "https://shopmvc.azurewebsites.net/shopProduct/Index/?subcategory=12106"; //測試用位置

            //建立LiffApp
            var Liff = isRock.LIFF.Utility.AddLiffApp(
                ChannelAccessToken, new Uri(LiffURL), isRock.LIFF.ViewType.tall);
            //顯示建立好的 Liff App
            isRock.LineBot.Utility.PushMessage(
                AdminUserId, "Liff App 已新增 " + Liff, ChannelAccessToken);
        }
        protected void Button10_Click(object sender, EventArgs e)
        {
            var LiffURL = "https://shopmvc.azurewebsites.net/shopProduct/Index/?subcategory=12107"; //測試用位置

            //建立LiffApp
            var Liff = isRock.LIFF.Utility.AddLiffApp(
                ChannelAccessToken, new Uri(LiffURL), isRock.LIFF.ViewType.tall);
            //顯示建立好的 Liff App
            isRock.LineBot.Utility.PushMessage(
                AdminUserId, "Liff App 已新增 " + Liff, ChannelAccessToken);
        }

    }
}