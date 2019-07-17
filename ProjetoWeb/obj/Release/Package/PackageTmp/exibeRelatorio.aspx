<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="exibeRelatorio.aspx.cs" Inherits="ProjetoWeb.exibeRelatorio" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="ContentPopUp" ContentPlaceHolderID="PopUpContent" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <div class="divConteudoReport">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server"   OnLoad="ReportViewer1_Load"></rsweb:ReportViewer>
    </div>
</asp:Content>
<asp:Content ID="ContentButton" ContentPlaceHolderID="ButtonContent" runat="server">
     <table class="tableButtons">
        <tr>
            <td class="tdButtons">
               <%-- <cabtec:CABTECImageButton ID="btnVoltar" runat="server" Tipo="VOLTAR" OnClick="btnVoltar_Click" />--%>
            </td>
        </tr>
    </table>
</asp:Content>
