using System;
using System.IO;
using System.Xml.Serialization;

namespace Wpf_ManageStudents
{
    internal class TestStorage
    {
        internal static void WriteXml<T>(T students, string fileName)
        {
            try
            {
                XmlSerializer serializer=new XmlSerializer(typeof(T));
                FileStream stream;
                stream = new FileStream(fileName, FileMode.Create);
                serializer.Serialize(stream, students);
                stream.Close();
            }
            catch (Exception x)
            {
                Console.WriteLine(x);
                throw;
            }
        }

        internal static T ReadXml<T>(string fileName)
        {
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    XmlSerializer xmlSer = new XmlSerializer(typeof(T));
                    return (T)xmlSer.Deserialize(sr);
                }
            }
            catch (Exception)
            {
                return default(T);
            }
            
        }
    }
}