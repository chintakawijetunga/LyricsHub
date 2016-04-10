using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;

namespace LyricsHub
{
    public partial class PageLyricsViewer : PhoneApplicationPage
    {
        public static String fileNameLoad = null;
        public PageLyricsViewer()
        {
            InitializeComponent();
            txtBlock.Text = fileNameLoad;
            imgViewer.Source = new BitmapImage(new Uri(@"Assets/Lyrics/" + fileNameLoad, UriKind.Relative));
        }
    }
}