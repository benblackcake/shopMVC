using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MvcLineBot2
{
    public partial class Form1 : Form
    {
        const string ChannelAccessToken = "SUMMGaGGy/7H4yewgnOHGpaKZ3BY4BZhtLZIlguM4PM0o0ROfa0WaNETzkzsH+dMAJuQgecMME7MVM7ZtbSDFcw3AbUQnYMQXCPKGWeZgECCqURpxYS7gaRhUswco7NzmiUoevfmnmUQ9ucM8xJKAwdB04t89/1O/w1cDnyilFU=";
        const string AdminUserId = "U4c90f41a5c97ddab5931ef31c5003dc8";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var LiffURL = "https://shopmvc.azurewebsites.net/shopIndex/Index2"; //測試用位置

            //建立LiffApp
            var Liff = isRock.LIFF.Utility.AddLiffApp(
                ChannelAccessToken, new Uri(LiffURL), isRock.LIFF.ViewType.tall);
            //顯示建立好的 Liff App
            isRock.LineBot.Utility.PushMessage(
                AdminUserId, "Liff App 已新增 " + Liff, ChannelAccessToken);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
