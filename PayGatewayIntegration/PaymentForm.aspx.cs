using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Transactions;
using System.Threading;


namespace PayGatewayIntegration
{
    public partial class PaymentForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String RequestID = PayflowUtility.RequestId;
            UserInfo User = new UserInfo("-", "-", "-", "-");
            PayflowConnectionData Connection = new PayflowConnectionData();
            Invoice Inv = new Invoice();

            String usCurrency = "USD";
            Currency Amt = new Currency(new decimal(19.99), usCurrency);
            Inv.Amt = Amt;
            // *** Set the Billing Address details. ***
            BillTo Bill = new BillTo();
            Bill.BillToFirstName = tbFirstName.Text;
            Bill.BillToLastName = tbLastName.Text;
            Bill.BillToStreet = tbStreetAddress.Text;
            Bill.BillToZip = tbPostCode.Text;

            // Set the BillTo object into invoice.
            Inv.BillTo = Bill;
            ShipTo Ship = new ShipTo();
            // If shipping address is different to billing address this can be set here

            // *** Create Customer Data ***

            CustomerInfo CustInfo = new CustomerInfo();

            UserItem nUser = new UserItem();
            nUser.UserItem1 = "TUSER1"; //e-commerce site user-name
            Inv.UserItem = nUser;
            // *** Create a new Payment Device - Credit Card data object. ***
            CreditCard CC = new CreditCard(tbCardNumber.Text, ddlExpiryMonth.SelectedValue + ddlExpiryYear.SelectedValue);
            CC.Cvv2 = tbCVV2.Text;
            CardTender Card = new CardTender(CC);
            SaleTransaction Trans = new SaleTransaction(User, Connection, Inv, Card, RequestID);
            ClientInfo cInfo = new ClientInfo();
            cInfo.IntegrationProduct = "Test";
            cInfo.IntegrationVersion = "1.0";
            Trans.ClientInfo = cInfo;
            Trans.Verbosity = "HIGH";
            // Try to submit the transaction up to 3 times with 5 second delay. This can be used
            // in case of network issues. The idea here is since you are posting via HTTPS behind the scenes there
            // could be general network issues, so try a few times before you tell customer there is an issue.
            int trxCount = 1;
            bool RespRecd = false;
            while (trxCount <= 3 && !RespRecd)
            {
                // Submit the Transaction
                Response Resp = Trans.SubmitTransaction();
                // Display the transaction response parameters.
                if (Resp != null)
                {
                    // Here would go response code handling. There is an extensive number of codes, all of which should
                    //Be handled effectively
                }
                else
                {
                    Thread.Sleep(5000); // let's wait 5 seconds to see if this is a temporary network issue.
                    trxCount++;
                }
            }
        }


        public void RedirectToSecurePage()
        {
            var httpsMode = string.Empty;
            var serverName = string.Empty;
            var url = string.Empty;

            for (var i = 0; i < Request.ServerVariables.Keys.Count; i++)
            {
                var key = Request.ServerVariables.Keys[i];
                if (key.Equals("HTTPS"))
                {
                    httpsMode = Request.ServerVariables[key];
                }
                else if (key.Equals("SERVER_NAME"))
                {
                    serverName = Request.ServerVariables[key];
                }
                else if (key.Equals("URL"))
                {
                    url = Request.ServerVariables[key];
                }
            }
            if (httpsMode.Equals("off"))
            {
                Response.Redirect(string.Concat("https://", serverName, url));
            }
        }

    }
}