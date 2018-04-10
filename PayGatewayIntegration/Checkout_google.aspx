<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout_google.aspx.cs" Inherits="PayGatewayIntegration.Checkout_google" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form method="POST" action="https://checkout.google.com/api/checkout/v2/checkoutForm/Merchant/1234567890"
 accept-charset="utf-8">
 <input type="hidden" name="item_name_1" value="Peanut Butter"/>
 <input type="hidden" name="item_description_1" value="Chunky peanut butter."/>
 <input type="hidden" name="item_quantity_1" value="1"/>
 <input type="hidden" name="item_price_1" value="3.99"/>
 <input type="hidden" name="item_currency_1" value="USD"/>
 <input type="hidden" name="ship_method_name_1" value="UPS Ground"/>
 <input type="hidden" name="ship_method_price_1" value="10.99"/>
 <input type="hidden" name="ship_method_currency_1" value="USD"/>
 <input type="hidden" name="tax_rate" value="0.0875"/>
 <input type="hidden" name="tax_us_state" value="NY"/>
 <input type="hidden" name="_charset_"/>
 <input type="image" name="Google Checkout" alt="Fast checkout through Google"

src="http://checkout.google.com/buttons/checkout.gif?merchant_id=1234567890&w=180&h=
46&style=white&variant=text&loc=en_US"
 height="46" width="180"/>
</form>
</body>
</html>
