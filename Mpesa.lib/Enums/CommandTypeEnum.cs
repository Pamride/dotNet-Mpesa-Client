using System.ComponentModel;

namespace Mpesa.lib.Enums;

public enum CommandType {
   [Description("Reversal for an erroneous C2B transaction")]
   TransactionReversal,
   [Description("Used to send money from an employer to employees.")]
   SalaryPayment,
   [Description("Used to send money from business to customer")]
   BusinessPayment,
   [Description("Used to send money when promtions takes place")]
   PromotionPayment,
   [Description("Used to check the balance in a paybill/buy goods accounts")]
   AccountBalance,
   [Description("Used to simulate a transaction taking place in the case of C2B Simulate Transaction or to initiate a transaction on behalf of the customer (STK Push)")]
   CustomerPayBillOnline,
   [Description("Used to query the details of a trasaction")]
   TransactionStatusQuery,
   [Description("Similar to STK Push, uses M-Pesa Pin as a service")]
   CheckIdentity,

   [Description("Sending funds from one Paybill to another paybill")]
   BusinessPayBill,
   [Description("Sending funds from buy goods to another buy goods")]
   BusinessBuyGoods,
   [Description("Transfer of funds from utility to MMF account.")]
   DisburseFundsToBusiness,
   [Description("Trasferring funds from one paybills MMF to another paybill MMF account")]
   BusinessToBusinessTransfer,
   [Description("Transfering funds from paybills MMF to another paybills utility account.")]
   BusinessTransferFromMMFTOUtility
}

