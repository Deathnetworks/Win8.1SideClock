﻿using System;
using System.Collections.Generic;
using System.Globalization;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Clock
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static DispatcherTimer timer;

        private static bool blink = true;

        public MainPage()
        {
            this.InitializeComponent();

            ClockText.Text = DateTime.Now.ToString("hh:mm:ss ttt");
            DateText.Text = DateTime.Now.ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);

            timer = new DispatcherTimer();
            timer.Tick += DispatcherTimerEventHandler;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            timer.Start();
        }        

        private void DispatcherTimerEventHandler(object sender, object e)
        {
            blink = !blink;
            ClockText.Text = DateTime.Now.ToString(blink ? "hh:mm:ss ttt" : "hh mm ss ttt");
            DateText.Text = DateTime.Now.ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
        }
    }
}
