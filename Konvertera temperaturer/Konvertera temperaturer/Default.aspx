<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Konvertera_temperaturer.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Konvertera temperaturer</title>
    <link href="Content/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" defaultfocus="StartTextBox" defaultbutton="ConvertButton">
    <div>
        <div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" HeaderText="Fel inträffade. Åtgärda felen och försök igen." />
        </div>
        <div>
            <%-- Konverteringstabellen --%>
            <asp:Label ID="ConversionLabel" runat="server" Text="Label" Visible="false">
                <div id="conversion">
                    <asp:Table ID="ConversionTable" runat="server" CssClass="temperature">
                        <asp:TableHeaderRow>
                            <asp:TableHeaderCell ID="First">&degC</asp:TableHeaderCell>
                            <asp:TableHeaderCell ID="Second">&degF</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
                </div>
            </asp:Label>
            <%-- Starttemperatur --%>
            <div>
                <asp:Literal ID="StartLiteral" runat="server" Text="Starttemperatur"></asp:Literal>
            </div>
            <asp:TextBox ID="StartTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ErrorMessage="Startfältet får inte vara tomt!"
                ControlToValidate="StartTextBox"
                Display="None"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="StartCompareValidator" runat="server"
                ErrorMessage="Fyll i ett heltal."
                ControlToValidate="StartTextBox" Type="Integer" Operator="DataTypeCheck" Display="None"></asp:CompareValidator>
        </div>
        <div>
            <%-- Sluttemperatur --%>
            <div>
                <asp:Literal ID="EndLiteral" runat="server" Text="Sluttemperatur"></asp:Literal>
            </div>
            <asp:TextBox ID="EndTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                ErrorMessage="Slutfältet får inte vara tomt!"
                ControlToValidate="EndTextBox"
                Display="None"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="EndCompareValidator" runat="server"
                ErrorMessage="Fyll i ett heltal högre än starttemperaturen."
                ControlToValidate="EndTextBox" Operator="GreaterThan" Type="Integer" ControlToCompare="StartTextBox" Display="None"></asp:CompareValidator>
        </div>
        <div>
            <%-- Temperatursteg --%>
            <div>
                <asp:Literal ID="ScaleLiteral" runat="server" Text="Temperatursteg"></asp:Literal>
            </div>
            <asp:TextBox ID="ScaleTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                ErrorMessage="Stegfältet får inte vara tomt!"
                ControlToValidate="ScaleTextBox"
                Display="None"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="ScaleRangeValidator" runat="server"
                ErrorMessage="Fyll i ett heltal mellan 1-100."
                ControlToValidate="ScaleTextBox" MaximumValue="100" MinimumValue="1" Type="Integer" Display="None"></asp:RangeValidator>
        </div>
        <div>
            <%-- Radioknappar --%>
            <asp:Literal ID="RadioLiteral" runat="server" Text="Typ av konvertering"></asp:Literal>
        </div>
        <div>
            <asp:RadioButton ID="CelToFahRadioButton" runat="server" Text="Celsius till Fahrenheit" GroupName="RadioButtons" Checked="True" />
        </div>
        <div>
            <asp:RadioButton ID="FahToCelRadioButton" runat="server" Text="Fahrenheit till Celsius" GroupName="RadioButtons" />
        </div>
        <div>
            <asp:Button ID="ConvertButton" runat="server" Text="Konvertera" OnClick="ConvertButton_Click" />
        </div>
    </div>
    </form>
</body>
</html>