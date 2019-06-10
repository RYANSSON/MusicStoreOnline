<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form1.aspx.cs" Inherits="MusicStoreWebsite.Form1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="Style.css" type="text/css" media="screen" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <img id="Spotify" src="spotifylogo.png" alt="image error"/>
    <div id="Name">
        <asp:Label ID="lblName" runat="server" Text="Name: "></asp:Label>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    </div>
    <div id="Phone">
        <asp:Label ID="lblPhone" runat="server" Text="Phone #: "></asp:Label>
        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
    </div>
    <div id="CreditCard">

        <asp:Label ID="lblCC" runat="server" Text="Credit Card #: "></asp:Label>
        <asp:TextBox ID="txtCreditCard" runat="server"></asp:TextBox>
        <asp:Label ID="lblExp" runat="server" Text="Expiration Date: "></asp:Label>
        <asp:TextBox ID="txtCCExpMonth" runat="server" Width="24px"></asp:TextBox>
        <asp:Label ID="lblfslash" runat="server" Text="/"></asp:Label>
        <asp:TextBox ID="txtCCExpYear" runat="server" Width="24px"></asp:TextBox>
    </div>
    <div id="subs">
        <asp:Label ID="lblSub" runat="server" Text="Subscription Type: "></asp:Label>
        <asp:DropDownList ID="Subscription" runat="server">
            <asp:ListItem Value="20">Auto Pay</asp:ListItem>
            <asp:ListItem Value="200">Annual</asp:ListItem>
            <asp:ListItem Value="1">One-Time Charge</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div id="info">
        <br />
        <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
    </div>
    <div id="Grids">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSongs" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="SongID" HeaderText="ID"/>
            <asp:BoundField DataField="SongTitle" HeaderText="Song Title" />
            <asp:BoundField DataField="MusicArtist" HeaderText="Artist" />
                <asp:TemplateField HeaderText ="Format">
                    <ItemTemplate>
                        <asp:DropDownList ID="FormatList" runat="server">
                        <asp:ListItem Value="Vinyl">Vinyl Record</asp:ListItem>
                        <asp:ListItem Value="Download">Download Only</asp:ListItem>
                        <asp:ListItem Value="Stream">Stream Only</asp:ListItem>
                        </asp:DropDownList>
                         
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Price" HeaderText="Price"/>
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
        
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" ShowFooter="True" OnRowDataBound="GridView2_RowDataBound" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
            <Columns>
                <asp:BoundField DataField="SongTitle" HeaderText ="Title"/>
                <asp:BoundField DataField="Format" HeaderText ="Format"/>
                <asp:BoundField DataField="Quantity" HeaderText ="Quantity"/>
                <asp:BoundField DataField="price" HeaderText ="Price"/>
                <asp:BoundField DataField="totalCost" HeaderText ="Total Cost"/>

            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
        <asp:GridView ID="gvStats" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" >
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
            

            <asp:GridView ID="gvSubscriptions" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
    </div>
    <div id="buttons">
        <asp:Button ID="btnPurchase" runat="server" OnClick="btnPurchase_Click" Text="Purchase"/>
            <asp:Button ID="Songs" runat="server" Text="Songs" OnClick="Songs_Click" />
            
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"/>
            <asp:DropDownList ID="searchFunctionList" runat="server">
                <asp:ListItem Value="Song">By Song</asp:ListItem>
                <asp:ListItem Value="Genre">By Genre</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="btnViewSubscriptionInfo" runat="server" OnClick="viewSubscriptionInfo_Click" Text="View Subscription Info" Height="24px" Width="148px" />
            <asp:DropDownList ID="SubscriptionSearchFunctionList" runat="server">
                <asp:ListItem Value="Month">By Month</asp:ListItem>
                <asp:ListItem Value="One-Time">One-Time Purchase</asp:ListItem>
                <asp:ListItem Value="Annual">By Annual Total</asp:ListItem>
                <asp:ListItem Value="All">All Fields</asp:ListItem>
            </asp:DropDownList>
    </div>    
    <div id="Error"><asp:Label ID="lblError" runat="server" Text="" ForeColor ="Red"></asp:Label></div>   
    </form>
</body>
</html>
