using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaSaleOrd
    {
        public static string GetCompareString(MaSaleOrd pObj, MaSalesOrdParameters salesOrderParams)
        {
            //string sDelivered = pObj.Delivered.Equals("1") ? "True" : "False";
            string sIsCancelled = pObj.Cancelled.Equals("1") ? "True" : "False";
            string sBlocked = pObj.IsBlocked.Equals("1") ? "True" : "False";

            //string aString = sDelivered + sIsCancelled + sBlocked;
            string aString = sIsCancelled + sBlocked;

            // Standard break criteria
            aString += pObj.Customer.ToString();
            aString += pObj.Payment.ToString();
            aString += pObj.TaxJournal.ToString();
            aString += pObj.StubBook.ToString();
            aString += pObj.Currency.ToString();
            aString += pObj.Salesperson.ToString();
            aString += pObj.AreaManager.ToString();
            aString += pObj.SalespersonPolicy.ToString();
            aString += pObj.AreaManagerPolicy.ToString();

            string sSalespersonCommIsAuto = pObj.SalespersonCommAuto.Equals("1") ? "True" : "False";
            string sAreaManagerCommIsAuto = pObj.AreaManagerCommAuto.Equals("1") ? "True" : "False";
            string sSalespersonCommPercAuto = pObj.SalespersonCommPercAuto.Equals("1") ? "True" : "False";
            string sAreaMngCommPercAuto = pObj.AreaManagerCommPercAuto.Equals("1") ? "True" : "False";

            aString += sSalespersonCommIsAuto + sAreaManagerCommIsAuto + sSalespersonCommPercAuto + sAreaMngCommPercAuto;

            // User-defined break criteria
            if (salesOrderParams.FulfillmentBreakByArea.Equals("1"))
            {
                aString += pObj.Area.ToString();
            }

            if (salesOrderParams.FulfillmentBreakByInvRsn.Equals("1"))
            {
                aString += pObj.InvRsn.ToString();
            }

            if (salesOrderParams.FulfillmentBreakByJob.Equals("1"))
            {
                aString += pObj.Job.ToString();
            }

            if (salesOrderParams.FulfillmentBreakByDocBranch.Equals("1"))
            {
                aString += pObj.SendDocumentsTo.ToString();
            }

            if (salesOrderParams.FulfillmentBreakByGoodBranch.Equals("1"))
            {
                aString += pObj.ShipToAddress.ToString();
            }

            if (salesOrderParams.FulfillmentBreakByShippRsn.Equals("1"))
            {
                aString += pObj.ShippingReason.ToString();
            }

            if (salesOrderParams.FulfillmentBreakByCarrier.Equals("1"))
            {
                aString += pObj.Carrier1.ToString();
            }

            if (salesOrderParams.FulfillmentBreakByPort.Equals("1"))
            {
                aString += pObj.Port.ToString();
            }

            if (salesOrderParams.FulfillmentBreakByPackage.Equals("1"))
            {
                aString += pObj.Package.ToString();
            }

            if (salesOrderParams.FulfillmentBreakByTransport.Equals("1"))
            {
                aString += pObj.Transport.ToString();
            }

            if (salesOrderParams.FulfillmentBreakByCig.Equals("1"))
            {
                aString += pObj.ContractCode.ToString();
                aString += pObj.ProjectCode.ToString();
            }

            if (salesOrderParams.FulfillmentBreakByTcg.Equals("1"))
            {
                aString += pObj.TaxCommunicationGroup.ToString();
            }

            // Order by date and number of bubbles
            string sExpectedDeliveryDate = pObj.ExpectedDeliveryDate.GetValueOrDefault().ToString("yyyyMMdd");
            aString += sExpectedDeliveryDate;

            // If AfxIsActivated(MAGONET_APP, _NS_ACT("MasterData_BR")) Then
            // aString += pObj.NotaFiscalCode.ToString();
            // aString += pObj.SaleOrdInternalNo.ToString();
            // string sSaleOrderDate = pObj.SaleOrderDate.ToString("yyyyMMdd");
            // aString += sSaleOrderDate;
            // Else
            aString += pObj.InternalOrdNo.ToString();
            // End If

            return aString;
        }
        public static void SortSaleOrd(List<MaSaleOrd> pArray, MaSalesOrdParameters salesOrdParameters)
        {
            //Console.WriteLine("Prima");
            //foreach( MaSaleOrd ox in pArray)
            // {
            //     Console.WriteLine(ox.Customer + " - " + ox.InternalOrdNo);
            // }            

            pArray.Sort((a, b) => string.Compare(GetCompareString(a, salesOrdParameters), GetCompareString(b, salesOrdParameters), StringComparison.Ordinal));

            // Console.WriteLine("Dopo");
            // foreach (MaSaleOrd ox in pArray)
            // {
            //     Console.WriteLine(ox.Customer + " - " + ox.InternalOrdNo);
            // }
        }

    }
}
