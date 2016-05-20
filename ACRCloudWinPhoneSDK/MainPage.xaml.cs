/*
   @author qinxue.pan E-mail: xue@acrcloud.com
   @version 1.0.0
   @create 2016.05.20
 
Copyright 2016 ACRCloud SDK v1.0.0
  
*/


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using ACRCloud;

using Windows.UI.Core;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace ACRCloudWinPhoneSDK
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page, IACRCloudClientListener
    {
        ACRCloudClient client = null;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void stopbtn_Click(object sender, RoutedEventArgs e)
        {
            if (client != null)
            {
                client.Cancel();
            }
            resultTextBlock.Text = "stoped";
        }

        private void startbtn_Click(object sender, RoutedEventArgs e)
        {
            var config = new Dictionary<string, object>();

            // Replace "XXXXXXXX" below with your project's access_key and access_secret
            config.Add("host", "XXXXXXXX");            
            config.Add("access_key", "XXXXXXXX");
            config.Add("access_secret", "XXXXXXXX");

            client = new ACRCloudClient(this, config);
            client.Start();

            resultTextBlock.Text = "recording";
        }

        void IACRCloudClientListener.OnResult(string result)
        {
            resultTextBlock.Text = result;
        }
    }
}
