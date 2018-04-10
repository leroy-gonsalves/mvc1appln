<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout_amazon.aspx.cs" Inherits="PayGatewayIntegration.Checkout_amazon" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form method ="POST" action
="https://authorize.payments.amazon.com/pba/paypipeline">
<!--REQUIRED FIELDS -->
 <input type ="hidden" name ="accessKey" value ="YourAccessKeyId">
 <input type ="hidden" name ="amount" value ="USD 10">
 <input type ="hidden" name ="signature" value
="K2ryWe7s/0AHI0/PbuAveuUPksTefhmNCzDTold2VYA=">
 <input type ="hidden" name ="description" value ="pay for dinner">
 <input type ="image" src
="https://authorize.payments.amazon.com/pba/images/SLPayNowWithLogo.png" border
="0">
 <input type ="hidden" name ="signatureVersion" value ="2">
 <input type ="hidden" name ="signatureMethod" value ="HmacSHA256">
<!--NON REQUIRED FIELDS -->
 <input type ="hidden" name ="ipnUrl" value
="http://yourwebsite.com/instantpaymentnotification">
 <input type ="hidden" name ="returnUrl" value ="http://yourwebsite.com/success">
 <input type ="hidden" name ="processImmediate" value ="1">
 <input type ="hidden" name ="cobrandingStyle" value ="logo">
 <input type ="hidden" name ="abandonUrl" value
="http://yourwebsite.com/abandon">
 <input type ="hidden" name ="referenceId" value ="MyTransaction-001">
 <input type ="hidden" name ="immediateReturn" value ="1">
 <input type ="hidden" name ="collectShippingAddress" value ="0">
</form>

</body>
</html>
