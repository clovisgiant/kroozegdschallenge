using Krooze.EntranceTest.WriteHere.Structure.Model;
using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;


namespace Krooze.EntranceTest.WriteHere.Tests.LogicTests
{
    public class XMLTest
    {
        public CruiseDTO TranslateXML()
        {
            //TODO: Take the Cruises.xml file, on the Resources folder, and translate it to the CruisesDTO object,
            //you can do it in any way, including intermediary objects            
            string path = string.Empty;   
            var retorno = new CruiseDTO();       
            var crusedto = new PassengerCruiseDTO();
           

            path = @"\Resources\Cruises.xml";           
            var doc = new XmlDocument();
            doc.Load(path);
            var Cruises = doc.SelectNodes(@"//Cruises");
            foreach (XmlNode item in Cruises)
            {

                

                retorno.CruiseCode = item.SelectSingleNode("./CruiseId").InnerText;
                retorno.TotalValue = Convert.ToDecimal(item.SelectSingleNode("./TotalCabinPrice").InnerText);
                retorno.CabinValue = Convert.ToDecimal(item.SelectSingleNode("./CabinPrice").InnerText);
                retorno.PortCharge = Convert.ToDecimal(item.SelectSingleNode("./PortChargesAmt").InnerText);
                retorno.ShipName = item.SelectSingleNode("./ShipName").InnerText;              
                crusedto.PassengerCode = item.SelectSingleNode("./CruiseId").InnerText;

                var passagem = new PassengerCruiseDTO()
                { PassengerCode = "1", Cruise = new CruiseDTO()
                {   CabinValue = Convert.ToDecimal(item.SelectSingleNode("./CabinPrice").InnerText),
                    TotalValue = Convert.ToDecimal(item.SelectSingleNode("./TotalCabinPrice").InnerText),
                    PortCharge = Convert.ToDecimal(item.SelectSingleNode("./PortChargesAmt").InnerText),
                    CruiseCode = item.SelectSingleNode("./CruiseId").InnerText, 
                    PassengerCruise = null,
                    ShipName = item.SelectSingleNode("./ShipName").InnerText

                }
                };


               

               
            }

            return retorno;
        }
    }     
}
