using System.Collections.Generic;
using Krooze.EntranceTest.WriteHere.Structure.Model;
using System;

namespace Krooze.EntranceTest.WriteHere.Tests.InjectionTests
{
    public class InjectionTest
    {
        public List<CruiseDTO> GetCruises(CruiseRequestDTO request)
        {
            //TODO: This method receives a generic request, that has a cruise company code on it
            //There is an interface (IGetCruise) that is implemented by 3 classes (Company1, Company2 and Company3)
            //Make sure that the correct class is injected based on the CruiseCompanyCode on the request
            //without directly referencing the 3 classes and the method GetCruises of the chosen implementation is called
            DateTime now = DateTime.Now;
            var PassengerCruise = new List<CruiseRequestDTO>()
                {
                    new CruiseRequestDTO()
                        {DeparturePort = "1",DepartureDate = now, CruiseCompanyCode= 1},
                    new CruiseRequestDTO()
                        {DeparturePort = "2",DepartureDate = now, CruiseCompanyCode= 2},
                    new CruiseRequestDTO()
                        {DeparturePort = "3",DepartureDate = now, CruiseCompanyCode= 3},
                };


            return null;
        }
    }
}
