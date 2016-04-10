using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace LyricsHub
{
    public partial class PageLyrics : PhoneApplicationPage
    {

        FileHandling obj;
        String btnName;
        String SongName;
        String FileName;
        public PageLyrics()
        {
            InitializeComponent();
            obj = new FileHandling();
            obj.OpenFile();
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                while(true)
                {
                    btnName = null;
                    SongName = null;
                    FileName = null;
                    obj.GetData(ref btnName, ref SongName, ref FileName);
                    if (FileName == null)
                        break;
                    Button button1 = new Button();
                    button1.Height = 75;
                    button1.Content = SongName;
                    button1.Name = btnName;
                    button1.Click += (s, e) => {
                        Button button = (s as Button);
                        PageLyricsViewer.fileNameLoad = button.Content.ToString() + ".PNG";
                        NavigationService.Navigate(new Uri("/PageLyricsViewer.xaml", UriKind.Relative)); };
                    
                    stackPanel.Children.Add(button1);
                }
            });
        }

        private void btnButton_Click(object sender, RoutedEventArgs e)
        {
           NavigationService.Navigate(new Uri("/PageLyricsViewer.xaml", UriKind.Relative));
        }
    }
}