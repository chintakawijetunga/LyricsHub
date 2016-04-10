using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LyricsHub
{
    class XMLHandling
    {
        public void WriteXML()
        {
            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("People2.xml", FileMode.Create, myIsolatedStorage))
                {
                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;
                    using (XmlWriter writer = XmlWriter.Create(isoStream, settings))
                    {
                        writer.WriteStartElement("p", "person", "urn:person");
                        writer.WriteStartElement("FirstName", "");
                        writer.WriteString("Kate");
                        writer.WriteEndElement();
                        writer.WriteStartElement("LastName", "");
                        writer.WriteString("Brown");
                        writer.WriteEndElement();
                        writer.WriteStartElement("Age", "");
                        writer.WriteString("25");
                        writer.WriteEndElement();
                        // Ends the document
                        writer.WriteEndDocument();
                        // Write the XML to the file.
                        writer.Flush();
                    }
                }
            }
        }

        public String ReadXML()
        {
            StringBuilder output = new StringBuilder();
            try
            {
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    IsolatedStorageFileStream isoFileStream = myIsolatedStorage.OpenFile("People2.xml", FileMode.Open);
                    using (StreamReader reader = new StreamReader(isoFileStream))
                    {
                        String tt = "";
                        
                    }
                }
                return "";
            }
            catch(Exception e)
            {
                String x = e.ToString();
                return "Error Occured";
            }
        }
    }
}
