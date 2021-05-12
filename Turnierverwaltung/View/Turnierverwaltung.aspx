<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Turnierverwaltung.aspx.cs" Inherits="Turnierverwaltung.View.Turnierverwaltung" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <center><h1>Willkommen zur Turnierverwaltung</h1></center>
            <br />
            <asp:Button ID="Hinzufeugen" runat="server" Text="Hinzufügen" OnClick="Hinzufeugen_Click1" />
            <asp:Button ID="Bearbeiten" runat="server" Text="Bearbeiten" OnClick="Bearbeiten_Click" />
            <asp:Button ID="Loeschen" runat="server" Text="Löschen" OnClick="Loeschen_Click" />

            <asp:Button ID="Alle_Anzeigen" runat="server" Text="Zeige alle Teilnehmer " OnClick="Alle_Anzeigen_Click" Width="255px" />
        </div>

        <div>
            <asp:Label ID="idLabel" runat="server" Text="Name" Visible="false"></asp:Label>
            <br />
            <asp:TextBox ID="Name" runat="server" Visible="false"></asp:TextBox>
            <br />
            <asp:Button ID="Personhinzufeugen" runat="server" Text="Submit" Visible="false" OnClick="Personhinzufeugen_Click" />
            <asp:Button ID="Bearbeitungsbutten" runat="server" Text="Bearbeiten" Visible="false" OnClick="Personbearbeiten_Click" />
        </div>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CellPadding="4">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="check_box" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="teilnehmer_id" HeaderText="ID" />
                <asp:BoundField DataField="name" HeaderText="Name" />
            </Columns>
        </asp:GridView>

    </form>
</body>
</html>
