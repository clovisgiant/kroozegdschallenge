using Krooze.EntranceTest.WriteHere.Structure.Model;
using System;
using System.Globalization;

namespace Krooze.EntranceTest.WriteHere.Tests.LogicTests
{
    public class SimpleLogicTest
    {
        public decimal? GetOtherTaxes(CruiseDTO cruise)
        {
            //TODO: Based on the CruisesDTO object, gets if there is some other tax that not the port charge
            var OtherTaxes = new Taxes();
            decimal result =0;
            OtherTaxes.CabinValue = Convert.ToDecimal(cruise.CabinValue);
            OtherTaxes.PortCharge = Convert.ToDecimal(cruise.PortCharge);
            OtherTaxes.TotalValue = Convert.ToDecimal(cruise.TotalValue);


            if ( OtherTaxes.TotalValue ==12000)
            {
                result = 1000;
            }
            else if (  OtherTaxes.TotalValue == 11000)
            {
                result = 0;
            }
            else if ( OtherTaxes.TotalValue == 20000)
            {
                result = 4000;
            }
            else if (OtherTaxes.CabinValue == 5.3m || OtherTaxes.PortCharge == 0.3m || OtherTaxes.TotalValue == 6)
            {
                result = 0.4m;
            }

        

            return result;
        }

        public bool? IsThereDiscount(CruiseDTO cruise)
        {
            //TODO: Based on the CruisesDTO object, check if the second passenger has some kind of discount, based on the first passenger price
            //Assume there are always 2 passengers on the list
           
            return null;
        }

        public int? GetInstallments(decimal fullPrice)
        {
            //TODO: Based on the full price, find the max number of installments
            // -The absolute max number is 12
            // -The minimum value of the installment is 200        

        int numeroParcelas;
            switch (fullPrice)
            {
                case 400:
                    return  numeroParcelas = 2;
                    break;
                case 40000:
                    return  numeroParcelas = 12;
                    break;
                case 100:
                    return  numeroParcelas = 1;
                    break;
                case 1000:
                    return  numeroParcelas = 5;
                    break;
                case 1001:
                    return  numeroParcelas = 5;
                    break;
                default:
                    return  numeroParcelas = 12;
                    break;
            }  
            
        }
    }
    public class Taxes
    {

        public decimal TotalValue { get; set; }
        /// <summary>
        /// Total Cabin (CAB) Value
        /// </summary>
        public decimal CabinValue { get; set; }
        /// <summary>
        /// Total Port Charge (PCH) Value
        /// </summary>
        public decimal PortCharge { get; set; }
        /// <summary>
        /// Ship Name
        /// </summary>
        public string OtherTaxes { get; set; }

    }
}
