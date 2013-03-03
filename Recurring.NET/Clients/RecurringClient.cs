using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Adyen.RecurringSample.Adyen;
using Adyen.RecurringSample.Adyen.Recurring;
using System.ServiceModel;

namespace Adyen.RecurringSample.Clients
{
    public sealed class RecurringClient : ClientBase<RecurringPortType>, IDisposable
    {

        private string _MerchantAccount;
        public RecurringClient() : this(ConfigurationManager.AppSettings["Adyen.MerchantAccount"])
        {
        }
        public RecurringClient(string MerchantAccount)
        {
            _MerchantAccount = MerchantAccount;
            this.ClientCredentials.UserName.UserName = ConfigurationManager.AppSettings["Adyen.username"];
            this.ClientCredentials.UserName.Password = ConfigurationManager.AppSettings["Adyen.password"];
        }

        public RecurringResult DeactivateRecurring(RecurringRequest recurringRequest)
        {
            recurringRequest.merchantAccount = _MerchantAccount;
            return base.Channel.deactivateRecurring(recurringRequest);
        }

        public DisableResult Disable(DisableRequest request)
        {
            request.merchantAccount = _MerchantAccount;
            return base.Channel.disable(request);
        }

        public RecurringResult InitialiseRecurring(RecurringRequest recurringRequest)
        {
            recurringRequest.merchantAccount = _MerchantAccount;
            return base.Channel.initialiseRecurring(recurringRequest);
        }

        public RecurringDetailsResult ListRecurringDetails(RecurringDetailsRequest request)
        {
            request.merchantAccount = _MerchantAccount;
          
            return base.Channel.listRecurringDetails(request);
        }

        public StoreTokenResult StoreToken(StoreTokenRequest request)
        {
            request.merchantAccount = _MerchantAccount;
            return base.Channel.storeToken(request);
        }

        public RecurringResult SubmitRecurring(RecurringRequest recurringRequest)
        {
            recurringRequest.merchantAccount = _MerchantAccount;
            return base.Channel.submitRecurring(recurringRequest);
        }
        /// <summary>
        /// base class also disposes but does not test for CommunicationState.Opened 
        /// </summary>
        public void Dispose()
        {
            if (this.State == System.ServiceModel.CommunicationState.Opened)
            {
                this.Close();
            }
        }
    }
}
