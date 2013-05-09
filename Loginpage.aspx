<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Loginpage.aspx.cs" Inherits="Loginpage" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   </head>




   <%--<form id="form1" runat="server">
   <boby><div>
   
   
   
       <br />
       <br />
       <asp:TextBox ID="TxtBox_name" runat="server"></asp:TextBox>
       <br />
       <br />
       <asp:TextBox ID="TxtBox_Pwd" runat="server"></asp:TextBox>
       <br />
       <br />
       <asp:Button ID="Login" runat="server" Text="Login" />
       <br />
       <br />
       <br />
       <br />
       <asp:DropDownList ID="ddl1" runat="server" AutoPostBack="True" 
           onselectedindexchanged="ddl1_SelectedIndexChanged">
       </asp:DropDownList>
       <br />
       <br />
       <asp:DropDownList ID="ddl2" runat="server">
       </asp:DropDownList>
       <br />
       <br />
       <br />
       <br />
   
   
   
   </div></boby>*/--%>

   <body>
    <form id="form2" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    
    </div>
        Country
        <asp:DropDownList ID="ddl_1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_1_SelectedIndexChanged" Width="171px">
        </asp:DropDownList><br />
        <br />
        City
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:DropDownList ID="ddl_2" runat="server" Width="167px">
                </asp:DropDownList>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddl_1" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
</body>
   <%--</form>--%>

   </html>