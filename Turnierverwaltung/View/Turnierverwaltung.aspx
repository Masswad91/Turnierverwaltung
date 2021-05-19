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
            <asp:Button ID="Arzt" runat="server" Text="Arzt" OnClick="Hinzufeugen_Arzt" Visible="false" />
            <asp:Button ID="Fussballspieler" runat="server" Text="Fussballspieler" OnClick="Hinzufeugen_Fussballspiele" Visible="false" />
            <asp:Button ID="Handballspieler" runat="server" Text="Handballspieler" OnClick="Hinzufeugen_Handballspieler" Visible="false" />
            <asp:Button ID="Organisator" runat="server" Text="Organisator" OnClick="Hinzufeugen_Organisator" Visible="false" Style="height: 29px" />
            <asp:Button ID="Tennisspieler" runat="server" Text="Tennisspieler" OnClick="Hinzufeugen_Tennisspieler" Visible="false" />
            <br />
            <br />
            <asp:Label ID="idLabel" runat="server" Text="Name" Visible="false"></asp:Label>
            <br />
            <asp:TextBox ID="Name" runat="server" Visible="false"></asp:TextBox>
            <br />
            <asp:Label ID="idLabe2" runat="server" Text="Fussstearke" Visible="false"></asp:Label>
            <br />
            <asp:TextBox ID="Fussstearke" runat="server" Visible="false"></asp:TextBox>
            <br />
            <asp:Label ID="idLabe3" runat="server" Text="Handstearke" Visible="false"></asp:Label>
            <br />
            <asp:TextBox ID="Handstearke" runat="server" Visible="false"></asp:TextBox>
            <br />
            <asp:Label ID="idLabe4" runat="server" Text="Rolle" Visible="false"></asp:Label>
            <br />
            <asp:TextBox ID="Rolle" runat="server" Visible="false"></asp:TextBox>
            <br />
            <asp:Label ID="idLabe5" runat="server" Text="Bezeichnung" Visible="false"></asp:Label>
            <br />
            <asp:TextBox ID="Bezeichnung" runat="server" Visible="false"></asp:TextBox>
            <br />
            <asp:Label ID="idLabe6" runat="server" Text="Mit_welcher_Hand" Visible="false"></asp:Label>
            <br />
            <asp:TextBox ID="Mit_welcher_Hand" runat="server" Visible="false"></asp:TextBox>
            <br />
            <asp:Button ID="Personhinzufeugen" runat="server" Text="Submit" Visible="false" OnClick="Personhinzufeugen_Click" />
            <asp:Button ID="Bearbeitungsbutten" runat="server" Text="Bearbeiten" Visible="false" OnClick="Personbearbeiten_Click" />
        </div>
        <asp:GridView ID="Teilnehmer_view" runat="server" AutoGenerateColumns="false" CellPadding="6">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="check_box" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="teilnehmer_id" HeaderText="Teilnehmer_ID" />
                <asp:BoundField DataField="name" HeaderText="Name" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
