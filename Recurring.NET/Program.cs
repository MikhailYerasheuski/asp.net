using System;

using System.Configuration;
using Adyen.RecurringSample.Clients;
using System.Diagnostics;
using Adyen.RecurringSample.Adyen.Recurring;
using Adyen.RecurringSample.Adyen.Payment;

//Add the Recurring Service as a Service Reference (instead of as a Web Reference)
//Should you need any further assistance please contact the Adyen support department

namespace Adyen.RecurringSample
{
    class Program
    {
        static void Main()
        {
            using (var proxy = new RecurringClient())  // do not use RecurringPortTypeClient
            {
                try
                {
                    var thisUserDetail = new RecurringDetailsRequest();
                    thisUserDetail.shopperReference = "[Shopper Reference]";
                    thisUserDetail.recurring = new Adyen.RecurringSample.Adyen.Recurring.Recurring()
                    {
                        contract = "RECURRING"
                    };

                    var recContractDetails = proxy.ListRecurringDetails(thisUserDetail);
                    Trace.TraceInformation("Shoppermail {0}", recContractDetails.lastKnownShopperEmail);
                    Trace.TraceInformation("Creation date {0}", recContractDetails.creationDate.Value.ToShortDateString());
                    
                }
                catch (Exception ex)
                {
                    Trace.TraceError("error using RecurringClient.listRecurringDetails {0}", ex.Message);
                    
                    throw ex;
                }
            }
            ///etc...
            using (var proxy = new PaymentClient())
            {
                try
                {
                    var paymentRequest = new PaymentRequest();
                    
                    proxy.Authorise(paymentRequest);
                }
                catch (Exception ex)
                {
                }
            }

        }
    }
}
