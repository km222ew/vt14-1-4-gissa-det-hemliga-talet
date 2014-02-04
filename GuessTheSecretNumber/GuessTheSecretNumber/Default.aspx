<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GuessTheSecretNumber.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gissa det hemliga talet</title>
    <link href="~/Content/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>

    <h1>Gissa det hemliga talet</h1>

    <div id="container">

        <form id="form" runat="server">
        <div>

            <div>
                <asp:ValidationSummary ID="ValidationSummary" runat="server" CssClass="error" HeaderText="Ett fel inträffade. Korrigera felet och gör ett nytt försök." />
            </div>

            <%-- Input --%>
            <asp:Label ID="GuessInputLabel" runat="server" Text="Ange ett tal mellan 1 och 100: " CssClass="info"></asp:Label>
            <asp:TextBox ID="GuessInput" runat="server" autofocus="autofocus" CssClass="input"></asp:TextBox>
            <asp:RequiredFieldValidator ID="GuessInputRequiredField" runat="server" ErrorMessage="Ett tal måste anges." ControlToValidate="GuessInput" Display="Dynamic" Text="*" CssClass="error"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="GuessInputRange" runat="server" ErrorMessage="Ange ett tal mellan 1 och 100." ControlToValidate="GuessInput" Display="Dynamic" MaximumValue="100" MinimumValue="1" Text="*" Type="Integer" CssClass="error"></asp:RangeValidator>

            <%-- Button --%>
            <asp:Button ID="SubmitGuess" runat="server" Text="Skicka gissning" CssClass="submit" />
    
            <%-- Gissningar --%>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server">

                <div>
                    <asp:Label ID="PrevGuesses" runat="server" Text="sdsd" CssClass="info"></asp:Label>
                </div>

            </asp:PlaceHolder>

            <%-- Resultat --%>
            <asp:PlaceHolder ID="PlaceHolder2" runat="server">

                <div>
                    <asp:Label ID="CurrentGuess" runat="server" Text="sdsd" CssClass="info"></asp:Label>
                </div>

            </asp:PlaceHolder>

            <%-- Nytt nummer-knapp --%>
            <asp:PlaceHolder ID="PlaceHolder3" runat="server">

                <asp:Button ID="SubmitNewNumber" runat="server" Text="Slumpa nytt hemligt tal" CssClass="submit" />

            </asp:PlaceHolder>

        </div>
        </form>
    </div>
</body>
</html>
