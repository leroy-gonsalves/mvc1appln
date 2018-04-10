<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentForm.aspx.cs" Inherits="PayGatewayIntegration.PaymentForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="paymentForm" runat="server">
        <!--Card choices here are decided by your merchant account and what cards
your account can accept! -->
        <asp:DropDownList ID="ddlCardType" runat="server">
            <asp:ListItem>Visa</asp:ListItem>
            <asp:ListItem>Mastercard</asp:ListItem>
            <asp:ListItem>American Express</asp:ListItem>
        </asp:DropDownList>

        <asp:Label ID="lbCardNumber" runat="server" Text="card number:"></asp:Label>
        <asp:TextBox ID="tbCardNumber" runat="server" MaxLength="16"></asp:TextBox>
        <%--Visa ^4[0-9]{12}(?:[0-9]{3})?$
            Mastercard ^5[1-5][0-9]{14}$
            American Express ^3[47][0-9]{13}$
            Diners Club ^3(?:0[0-5]|[68][0-9])[0-9]{11}$
            Discover ^6(?:011|5[0-9]{2})[0-9]{12}$
            JCB ^(?:2131|1800|35\d{3})\d{11}$--%>
        <asp:RegularExpressionValidator
            ID="revCardNumber" runat="server" ErrorMessage="Please check your card number!"
            ValidationExpression="^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$"
            ControlToValidate="tbCardNumber"></asp:RegularExpressionValidator>
        <br />
        <asp:Label ID="lbExpires" runat="server" Text="expires :"></asp:Label>
        <!--Include obviously all months to '12'-->
        <asp:DropDownList ID="ddlExpiryMonth" runat="server">
            <asp:ListItem>01</asp:ListItem>
            <asp:ListItem>02</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="ddlExpiryYear" runat="server">
            <asp:ListItem>2012</asp:ListItem>
            <asp:ListItem>2013</asp:ListItem>
            <asp:ListItem>2014</asp:ListItem>
            <asp:ListItem>2015</asp:ListItem>
        </asp:DropDownList>

        <asp:Label ID="lbCVV2" runat="server" Text="CVV2 number"></asp:Label>
        <asp:TextBox ID="tbCVV2" runat="server" MaxLength="4"
            Width="44px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvCVV" runat="server" ErrorMessage="CVV number is required!" ControlToValidate="tbCvV2"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lbFirstName" runat="server" Text="first name: "></asp:Label>
        <asp:TextBox ID="tbFirstName" runat="server" MaxLength="30"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvFirstName" runat="server"
            ErrorMessage="First name is required!"
            ControlToValidate="tbfirstName"></asp:RequiredFieldValidator>
        <asp:Label ID="lbLastName" runat="server" Text="last name: "></asp:Label>
        <asp:TextBox ID="tbLastName" runat="server" MaxLength="30"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvLastName" runat="server"
            ErrorMessage="Last name is required!"
            ControlToValidate="tbLastName"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lbStreetAddress" runat="server" Text="street address:"></asp:Label>
        <asp:TextBox ID="tbStreetAddress" runat="server"
            MaxLength="30"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvStreetAddress" runat="server"
            ErrorMessage="Street address is required!"
            ControlToValidate="tbStreetAddress"></asp:RequiredFieldValidator>

        <asp:Label ID="lbPostCode" runat="server" Text="ZIP/postal code:"></asp:Label>
        <asp:TextBox ID="tbPostCode" runat="server" MaxLength="9"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvPostCode" runat="server" ErrorMessage="ZIP/Postal Code is required!"
            ControlToValidate="tbPostCode"></asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="btPay" runat="server" Text="Pay" CausesValidation="True" />
    </form>
</body>
</html>
