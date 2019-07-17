<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="filtroHistoricoSimulador.aspx.cs" Inherits="ProjetoWeb.filtroHistoricoSimulador" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="ContentPopUp" ContentPlaceHolderID="PopUpContent" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <table class="tablePrincipalConteudo">
        <tr class="trTituloPageCadastro">
            <td class="tdTituloPageCadastro" align="center">
                <asp:Label ID="lblTitulo" runat="server" Text="Histórico Simulador" CssClass="tdTituloPageCadastroLabel" />
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
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td class="pnltdConsulta">
                                <asp:Label ID="lblVendedor" runat="server" Text="Vendedor: " />
                            </td>
                            <td class="pnltdConsultaLeft">
                                <cabtec:CABTECTextBox ID="txtVendedor" runat="server" Tipo="TEXTO" />
                            </td>
                            <td colspan="2"></td>
                        </tr>    
                          <tr style="height: 30px">
                            <td class="pnltdConsulta">
                                <asp:Label ID="lblEntrevista" runat="server" Text="Número Entrevista: " />
                            </td>
                            <td class="pnltdConsultaLeft">
                                <cabtec:CABTECTextBox ID="txtEntrevista" runat="server" Tipo="TEXTO" />
                            </td>
                            <td colspan="2"></td>
                        </tr>                  
                        <tr style="height: 30px">
                            <td class="pnltdConsulta">
                                <asp:Label ID="lblDataInicial" runat="server" Text="Período Entrevista:" />
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
                          <tr>
                            <td class="pnltdConsulta">
                                <asp:Label ID="lblTipo" runat="server" Text="Exibir Completo: " />
                            </td>
                            <td class="pnltdConsultaLeft">
                                 <asp:RadioButton ID="rdbTipoSim" runat="server" Text="Sim" GroupName="Tipo" Checked="true"/>
                                <asp:RadioButton ID="rdbTipoNao" runat="server" Text="Não" GroupName="Tipo" />
                            </td>
                            <td colspan="2"></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="ContentButton" ContentPlaceHolderID="ButtonContent" runat="server">
     <table class="tableButtons">
        <tr>           
            <td class="tdButtons">
                <cabtec:CABTECImageButton ID="btnPesquisar" runat="server" Tipo="PESQUISAR" OnClick="btnPesquisar_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

