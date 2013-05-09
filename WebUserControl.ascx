<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebUserControl.ascx.cs" Inherits="WebUserControl" %>


 <%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Bannerpage.aspx.cs" Inherits="Bannerpage" %>
--%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <asp:ScriptManager ID="ScriptManger1" runat="Server">
    </asp:ScriptManager>
    <div>
        <asp:Timer runat="server" Interval="1000" ID="SlideShowTimer" OnTick="SlideShowTimer_Tick" />
        <asp:UpdatePanel runat="server" ID="SlideShow" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Image runat="Server" ID="SlideShowImage1" ImageUrl="" Width="100%" Height="150px" />
                <asp:AdRotator ID="AdRotator1" runat="Server" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="SlideShowTimer" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>
        
    </div>
    
    </div>
    <asp:Button ID="PrevBtn" runat="server" Text="Button" />
    <asp:Button ID="NextBtn" runat="server" Text="Button" />
    </form>
</body>
</html>
