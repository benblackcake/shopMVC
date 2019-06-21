using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcLineBot.Controllers
{
    public class LineBotWebHookController : isRock.LineBot.LineWebHookControllerBase
    {
        const string channelAccessToken = "SUMMGaGGy/7H4yewgnOHGpaKZ3BY4BZhtLZIlguM4PM0o0ROfa0WaNETzkzsH+dMAJuQgecMME7MVM7ZtbSDFcw3AbUQnYMQXCPKGWeZgECCqURpxYS7gaRhUswco7NzmiUoevfmnmUQ9ucM8xJKAwdB04t89/1O/w1cDnyilFU=";
        const string AdminUserId= "U4c90f41a5c97ddab5931ef31c5003dc8";
        string StartMsg = "感謝您加入Style'G，若不想接收提醒，可以點選本畫面上方的「V」圖示中的「關閉提醒」鍵喔，下方有選單可以讓你選擇您想要的功能，祝您使用愉快^0^";
        string helpMsg = "Hi，客服的聯絡電話為：02-4050-3525\n官方網站網址:https://shopmvc.azurewebsites.net/shopIndex/Index2 \n粉絲團網址：https://www.google.com/";

        [Route("api/LineWebHookSample")]
        [HttpPost]
        public IHttpActionResult POST()
        {
            try
            {
                
                //設定ChannelAccessToken(或抓取Web.Config)
                this.ChannelAccessToken = channelAccessToken;
                //取得Line Event(範例，只取第一個)
                var LineEvent = this.ReceivedMessage.events.FirstOrDefault();
                //配合Line verify 
                if (LineEvent.replyToken == "00000000000000000000000000000000") return Ok();
                //回覆訊息
                if (LineEvent.type == "message")
                {
                    if (LineEvent.message.type == "text")
                    {//收到文字
                        if (LineEvent.message.text.Trim() == "瀏覽商品")
                        {
                            isRock.LineBot.Bot bot =
                            new isRock.LineBot.Bot(channelAccessToken);  //傳入Channel access token

                            //建立actions，作為ButtonTemplate的用戶回覆行為
                            var actions = new List<isRock.LineBot.TemplateActionBase>();
                            actions.Add(new isRock.LineBot.MessageAction() { label = "Clothing", text = "Clothing" });
                            actions.Add(new isRock.LineBot.MessageAction() { label = "Pants & Leggings", text = "Pants & Leggings" });
                            actions.Add(new isRock.LineBot.MessageAction() { label = "Jumpsuits & Rompers", text = "Jumpsuits & Rompers" });

                            //單一Button Template Message
                            var ButtonTemplate = new isRock.LineBot.ButtonsTemplate()
                            {
                                text = "請選擇",
                                title = "商品種類",
                                //設定圖片
                                thumbnailImageUrl = new Uri("https://upload.cc/i1/2019/06/10/QFKEYI.png"),
                                actions = actions //設定回覆動作
                            };
                            //發送
                            bot.PushMessage(LineEvent.source.userId, ButtonTemplate);
                            return Ok();
                        }
                        if (LineEvent.message.text.Trim() == "聯絡資訊")
                        {
                            this.ReplyMessage(LineEvent.replyToken, helpMsg);
                            return Ok();
                        }
                        if (LineEvent.message.text.Trim() == "Clothing")
                        {
                            isRock.LineBot.Bot bot =
                            new isRock.LineBot.Bot(channelAccessToken);  //傳入Channel access token

                            //建立actions，作為ButtonTemplate的用戶回覆行為
                            var actions = new List<isRock.LineBot.TemplateActionBase>();
                            actions.Add(new isRock.LineBot.UriAction() { label = "TOP", uri = new Uri("line://app/1584515870-0rgamNBP") });
                            actions.Add(new isRock.LineBot.UriAction() { label = "Base Layer", uri = new Uri("line://app/1584515870-2aqBK8kA") });

                            //單一Button Template Message
                            var ButtonTemplate = new isRock.LineBot.ButtonsTemplate()
                            {
                                text = "請選擇",
                                title = "Clothing",
                                //設定圖片
                                thumbnailImageUrl = new Uri("https://upload.cc/i1/2019/06/10/QFKEYI.png"),
                                actions = actions //設定回覆動作
                            };
                            //發送
                            bot.PushMessage(LineEvent.source.userId, ButtonTemplate);
                            return Ok();
                        }
                        if (LineEvent.message.text.Trim() == "Pants & Leggings")
                        {
                            isRock.LineBot.Bot bot =
                            new isRock.LineBot.Bot(channelAccessToken);  //傳入Channel access token

                            //建立actions，作為ButtonTemplate的用戶回覆行為
                            var actions = new List<isRock.LineBot.TemplateActionBase>();
                            actions.Add(new isRock.LineBot.UriAction() { label = "Pants", uri = new Uri("line://app/1584515870-NjD7Xxbg") });
                            actions.Add(new isRock.LineBot.UriAction() { label = "Skirt", uri = new Uri("line://app/1584515870-GVYN4jqE") });

                            //單一Button Template Message
                            var ButtonTemplate = new isRock.LineBot.ButtonsTemplate()
                            {
                                text = "請選擇",
                                title = "Pants & Leggings",
                                //設定圖片
                                thumbnailImageUrl = new Uri("https://upload.cc/i1/2019/06/10/QFKEYI.png"),
                                actions = actions //設定回覆動作
                            };
                            //發送
                            bot.PushMessage(LineEvent.source.userId, ButtonTemplate);
                            return Ok();
                        }
                        if (LineEvent.message.text.Trim() == "Jumpsuits & Rompers")
                        {
                            isRock.LineBot.Bot bot =
                            new isRock.LineBot.Bot(channelAccessToken);  //傳入Channel access token

                            //建立actions，作為ButtonTemplate的用戶回覆行為
                            var actions = new List<isRock.LineBot.TemplateActionBase>();
                            actions.Add(new isRock.LineBot.UriAction() { label = "Dresses", uri = new Uri("line://app/1584515870-Br8zqK3D") });
                            actions.Add(new isRock.LineBot.UriAction() { label = "Suit", uri = new Uri("line://app/1584515870-5krwv2Lx") });
                            actions.Add(new isRock.LineBot.UriAction() { label = "Jeans", uri = new Uri("line://app/1584515870-WVpYoxrG") });
                            //單一Button Template Message
                            var ButtonTemplate = new isRock.LineBot.ButtonsTemplate()
                            {
                                text = "請選擇",
                                title = "Jumpsuits & Rompers",
                                //設定圖片
                                thumbnailImageUrl = new Uri("https://upload.cc/i1/2019/06/10/QFKEYI.png"),
                                actions = actions //設定回覆動作
                            };
                            //發送
                            bot.PushMessage(LineEvent.source.userId, ButtonTemplate);
                            return Ok();
                        }
                    }

                }
                else
                {
                    this.ReplyMessage(LineEvent.replyToken, StartMsg);
                }
                //response OK
                return Ok();
            }
            catch (Exception ex)
            {
                //如果發生錯誤，傳訊息給Admin
                this.PushMessage(AdminUserId, "發生錯誤:\n" + ex.Message);
                //response OK
                return Ok();
            }
        }
    }
}
