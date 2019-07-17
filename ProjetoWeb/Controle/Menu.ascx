<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="ProjetoWeb.Controle.Menu" %>
<asp:XmlDataSource ID="xmlDataSource" TransformFile="MenuTreeView.xslt" XPath="MenuItems/MenuItem"
    runat="server" EnableCaching="false" />
<div class="divMenuEsquerda">
<asp:Image runat="server" ID="ImageEsquerda" CssClass="imgMenuEsquerda"  ImageUrl="~/Images/MenuEsquerda.png" />
</div>
<div class="divMenuDireita">
<asp:Image runat="server" ID="ImageDireita" CssClass="imgMenuDireita"  ImageUrl="~/Images/MenuDireita.png" />
</div>
<div id="MenuPrincipal" runat="server" class="divMenu">
    <asp:Menu ID="MenuSistema" DataSourceID="xmlDataSource" runat="server" Orientation="Horizontal"
        MaximumDynamicDisplayLevels="5" StaticEnableDefaultPopOutImage="false" RenderingMode="List"
        SkipLinkText="">
        <DataBindings>
            <asp:MenuItemBinding DataMember="MenuItem" NavigateUrlField="NavigateUrl" TextField="Text"
                ToolTipField="ToolTip" />
        </DataBindings>
        <StaticMenuStyle CssClass="MenuPrincipal" />
        <StaticMenuItemStyle CssClass="MenuPrincipal" />
        <StaticSelectedStyle CssClass="MenuPrincipal" />
        <StaticHoverStyle CssClass="MenuPrincipal" />
        <DynamicMenuStyle />
        <DynamicMenuItemStyle />
        <DynamicHoverStyle />              
    </asp:Menu>
   
</div>
