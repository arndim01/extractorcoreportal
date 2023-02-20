using Newtonsoft.Json;
using ONEConverter.Builder;
using ONEConverter.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace ONEConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                var physicalPath = Path.Combine("C:/Users/nel/Documents/CReader/233E5B3D-25DC-42FE-9798-0F958414861D/myset.xml");
                doc.Load(@physicalPath);
                string XML_JSON = JsonConvert.SerializeXmlNode(doc);
                var groupArbs = new GroupArbsBuilder<List<dynamic>>();
                //groupArbs.CompileDataTableTest(XML_JSON, "CONTRACT_ID", "AMD_ID");
                //IOneBuild<List<dynamic>> groupratesnotes = new GroupRateBuilder<List<dynamic>>();
                //groupratesnotes.CompileDataTable(XML_JSON, "CONTRACT_ID", "AMD_ID");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }


            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }
    }
}
