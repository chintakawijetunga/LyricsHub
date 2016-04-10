using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace LyricsHub
{
    class FileHandling
    {
        System.IO.StreamReader reader;
        int noOfSongs = 0;
        public void OpenFile()
        {
            String pathoffile = @"FileData.txt";
            reader = new System.IO.StreamReader(pathoffile);
        }
        public String readfromtextfile()
        {
            String Content = "";
            Content = reader.ReadLine();
            return Content;
        }

        public void GetData(ref String btnName, ref String SongName, ref String FilePath)
        {
            String dataLine = this.readfromtextfile();
            if (dataLine == null)
                return;
            var values = dataLine.Split(';');
            btnName = values[0];
            SongName = values[1];
            FilePath = values[2];

        }
        public void writetotextfile()
        {
            //Set the path of the file
            String pathoffile = "FileData.txt";

            //Content of file
            String Content = "Change the content to something else.";

            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(pathoffile))
            {
                writer.Write(Content);
            }
        }
    }
}
