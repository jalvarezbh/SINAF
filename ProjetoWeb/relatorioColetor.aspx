<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="relatorioColetor.aspx.cs" Inherits="ProjetoWeb.relatorioColetor" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="ContentPopUp" ContentPlaceHolderID="PopUpContent" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <table class="tablePrincipalConteudo">
        <tr class="trTituloPageCadastro">
            <td class="tdTituloPageCadastro" align="center">
                <asp:Label ID="lblTitulo" runat="server" Text="Relatório Coletor" CssClass="tdTituloPageCadastroLabel" />
            </td>
        </tr>
        <tr id="trMensagemPageCadastro" runat="server" visible="false">
            <td>
                <asp:Panel ID="pnlMensagem" runat="server" CssClass="pnlMensagem" GroupingText=" ">
                    <asp:Image ID="imgMensagem" runat="server" ImageAlign="Middle" />
                    <asp:Label ID="lblMensagem" runat="server" />
                </asp:Panel>
            </td>
        </tr>
        <tr class="trSummaryPageCadastro">
            <td class="tdSummaryPageCadastro">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="true"
                    ValidationGroup="Valida" />
            </td>
        </tr>
        <tr class="trConteudoPageCadastro">
            <td>
                <asp:Panel ID="pnlCampoConsulta" runat="server" GroupingText=" " CssClass="pnlConsulta">
                    <table>
                        <tr style="height: 30px">
                            <td class="pnltdConsulta">
                                <asp:Label ID="lblColetor" runat="server" Text="Número Coletor: " />
                            </td>
                            <td class="pnltdConsultaLeft">
                                <cabtec:CABTECTextBox ID="txtColetor" runat="server" Tipo="TEXTO" />
                            </td>
                            <td class="pnltdConsulta">
                                <asp:Label ID="lblVendedor" runat="server" Text="Vendedor: " />
                            </td>
                            <td class="pnltdConsultaLeft">
                                <cabtec:CABTECTextBox ID="txtVendedor" runat="server" Tipo="TEXTO" />
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <td class="pnltdConsulta">
                                <asp:Label ID="lblDataInicial" runat="server" Text="Período Sincronismo:" />
                            </td>
                            <td class="pnltdConsultaLeft">
                                <cabtec:CABTECTextBox ID="txtDataInicial" runat="server" Tipo="DATA" />
                            </td>
                            <td class="pnltdConsulta">
                                <asp:Label ID="lblDataFinal" runat="server" Text="Até: " />
                            </td>
                            <td class="pnltdConsultaLeft">
                                <cabtec:CABTECTextBox ID="txtDataFinal" runat="server" Tipo="DATA" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:UpdatePanel ID="uplGridConsulta" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pnlGridConsulta" runat="server" GroupingText=" " CssClass="pnlGridConsulta"
                            ScrollBars="Auto">
                            <asp:Repeater ID="rptColetor" runat="server" OnItemDataBound="rptColetor_ItemDataBound" >
                                <HeaderTemplate>
                                    <table class="repeaterHeaderPrincipal">
                                        <tr>
                                            <td style="width: 200px;">
                                                <asp:Label ID="headNumColetor" runat="server" Text="Número Coletor"></asp:Label>
                                            </td>
                                            <td style="width: 250px;">
                                                <asp:Label ID="headDataUltimo" runat="server" Text="Data Último Sincronismo"></asp:Label>
                                            </td>
                                            <td style="width: 250px;">
                                                <asp:Label ID="headTotalSincronismo" runat="server" Text="Total de Sincronismos"></asp:Label>
                                            </td>
                                            <td style="width: 250px;">
                                                <asp:Label ID="headTotalEntrevista" runat="server" Text="Total de Entrevistas"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table class="repeaterItemPrincipal">
                                        <tr>
                                            <td style="width: 200px;">
                                                <asp:LinkButton ID="itemNumColetor" runat="server" OnClick="lnkColetor_Click"></asp:LinkButton>
                                            </td>
                                            <td style="width: 250px;">
                                                <asp:Label ID="itemDataUltimo" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 250px;">
                                                <asp:Label ID="itemTotalSincronismo" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 250px;">
                                                <asp:Label ID="itemTotalEntrevista" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:Repeater ID="rptSincronismo" runat="server" OnItemDataBound="rptSincronismo_ItemDataBound">
                                                    <HeaderTemplate>
                                                        <table class="repeaterHeaderDetalhe">
                                                            <tr>
                                                                <td style="width: 200px;"></td>
                                                                <td style="width: 250px;">
                                                                    <asp:Label ID="headDataSincronismo" runat="server" Text="Data Sincronismo"></asp:Label>
                                                                </td>
                                                                <td style="width: 250px;">
                                                                    <asp:Label ID="headNumeroUpload" runat="server" Text="Upload"></asp:Label>
                                                                </td>
                                                                <td style="width: 250px;">
                                                                    <asp:Label ID="headNumeroDownload" runat="server" Text="Download"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <table class="repeaterItemPrincipal" >
                                                            <tr>
                                                                <td style="width: 200px;"></td>
                                                                <td style="width: 250px;">
                                                                    <asp:Label ID="itemDataSincronismo" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="width: 250px;">
                                                                    <asp:LinkButton ID="itemNumeroUpload" runat="server" OnClick="lnkUpload_Click"></asp:LinkButton>
                                                                </td>
                                                                <td style="width: 250px;">
                                                                    <asp:LinkButton ID="itemNumeroDownload" runat="server" OnClick="lnkDownload_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 200px;"></td>
                                                                <td style="width: 250px;"></td>
                                                                <td style="width: 250px;">
                                                                    <asp:Repeater ID="rptUpload" runat="server" OnItemDataBound="rptUpload_ItemDataBound">
                                                                        <HeaderTemplate>
                                                                            <table class="repeaterHeaderDetalhe">
                                                                                <tr>
                                                                                    <td style="width: 250px;">
                                                                                        <asp:Label ID="headEntrevistaUpload" runat="server" Text="Número Entrevista"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <table  class="repeaterItemPrincipal">
                                                                                <tr>
                                                                                    <td style="width: 250px;">
                                                                                        <asp:Label ID="itemEntrevistaUpload" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>
                                                                </td>
                                                                <td style="width: 250px;">
                                                                    <asp:Repeater ID="rptDownload" runat="server" OnItemDataBound="rptDownload_ItemDataBound">
                                                                        <HeaderTemplate>
                                                                            <table class="repeaterHeaderDetalhe">
                                                                                <tr>
                                                                                    <td style="width: 250px;">
                                                                                        <asp:Label ID="headEntrevistaDownload" runat="server" Text="Número Entrevista"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <table  class="repeaterItemPrincipal">
                                                                                <tr>
                                                                                    <td style="width: 250px;">
                                                                                        <asp:Label ID="itemEntrevistaDownload" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:Repeater>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="ContentButton" ContentPlaceHolderID="ButtonContent" runat="server">
    <table class="tableButtons">
        <tr>
            <td class="tdButtons">
                <cabtec:CABTECImageButton ID="btnVoltar" runat="server" Tipo="VOLTAR" OnClick="btnVoltar_Click" />
            </td>
            <td class="tdButtons">
                <cabtec:CABTECImageButton ID="btnNovo" runat="server" Tipo="ADICIONAR" OnClick="btnNovo_Click" />
            </td>
            <td class="tdButtons">
                <cabtec:CABTECImageButton ID="btnPesquisar" runat="server" Tipo="PESQUISAR" OnClick="btnPesquisar_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
