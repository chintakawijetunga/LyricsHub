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
using System.Windows.Media;

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

        private void imgViewer_ManipulationDelta(object sender, System.Windows.Input.ManipulationDeltaEventArgs e)
        {
            if (e.PinchManipulation != null)
            {
                var transform = (CompositeTransform)imgViewer.RenderTransform;

                // Scale Manipulation
                transform.ScaleX = e.PinchManipulation.CumulativeScale;
                transform.ScaleY = e.PinchManipulation.CumulativeScale;

                // Translate manipulation
                var originalCenter = e.PinchManipulation.Original.Center;
                var newCenter = e.PinchManipulation.Current.Center;
                transform.TranslateX = newCenter.X - originalCenter.X;
                transform.TranslateY = newCenter.Y - originalCenter.Y;

                // Rotation manipulation
                //transform.Rotation = angleBetween2Lines(
                //    e.PinchManipulation.Current,
                //    e.PinchManipulation.Original);

                // end 
                e.Handled = true;
            }
        }

        private double angleBetween2Lines(System.Windows.Input.PinchContactPoints line1, System.Windows.Input.PinchContactPoints line2)
        {
            if (line1 != null && line2 != null)
            {
                double angle1 = Math.Atan2(line1.PrimaryContact.Y - line1.SecondaryContact.Y,
                                           line1.PrimaryContact.X - line1.SecondaryContact.X);
                double angle2 = Math.Atan2(line2.PrimaryContact.Y - line2.SecondaryContact.Y,
                                           line2.PrimaryContact.X - line2.SecondaryContact.X);
                return (angle1 - angle2) * 180 / Math.PI;
            }
            else { return 0.0; }
        }
    }
}