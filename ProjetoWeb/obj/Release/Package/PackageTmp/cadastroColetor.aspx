<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="cadastroColetor.aspx.cs" Inherits="ProjetoWeb.cadastroColetor" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="ContentPopUp" ContentPlaceHolderID="PopUpContent" runat="server">    
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <table class="tablePrincipalConteudo">
        <tr class="trTituloPageCadastro">
            <td class="tdTituloPageCadastro" align="center">
                <asp:Label ID="lblTitulo" runat="server" Text="Cadastrar Coletor" CssClass="tdTituloPageCadastroLabel" />
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
                <asp:HiddenField ID="hiddenIDColetor" runat="server" Visible="false" />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="true"
                    ValidationGroup="Valida" />
            </td>
        </tr>
        <tr class="trConteudoPageCadastro">
            <td>
                <asp:Panel ID="pnlCampoCadastro" runat="server" GroupingText="Dados de Cadastro"
                    CssClass="pnlCadastroEditavel">
                    <table>
                        <tr style="height: 30px">
                            <td class="pnltdConsulta">
                                <asp:Label ID="lblNumeroSerie" runat="server" Text="Número de Série: " />
                            </td>
                            <td class="pnltdConsulta">
                                <cabtec:CABTECTextBox ID="txtNumeroSerie" runat="server" Tipo="TEXTO" />
                                <asp:RequiredFieldValidator ID="requiredNumeroSerie" runat="server" ValidationGroup="Valida"
                                    SetFocusOnError="true" ControlToValidate="txtNumeroSerie" ErrorMessage="Número de Série é obrigatório.">*</asp:RequiredFieldValidator>
                            </td>
                            <td class="pnltdConsulta">
                                <asp:Label ID="lblIMEI" runat="server" Text="IMEI: " />
                            </td>
                            <td class="pnltdConsulta">
                                <cabtec:CABTECTextBox ID="txtIMEI" runat="server" Tipo="TEXTO" />
                                <asp:RequiredFieldValidator ID="requiredIMEI" runat="server" ValidationGroup="Valida"
                                    SetFocusOnError="true" ControlToValidate="txtIMEI" ErrorMessage="IMEI é obrigatório.">*</asp:RequiredFieldValidator>
                            </td>
                            <td class="pnltdConsulta">
                            </td>
                            <td class="pnltdCheck">
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <td class="pnltdConsulta">
                                <asp:Label ID="lblFabricante" runat="server" Text="Fabricante: " />
                            </td>
                            <td class="pnltdConsulta">
                                <cabtec:CABTECTextBox ID="txtFabricante" runat="server" Tipo="TEXTO" />
                                <asp:RequiredFieldValidator ID="requiredFabricante" runat="server" ValidationGroup="Valida"
                                    SetFocusOnError="true" ControlToValidate="txtFabricante" ErrorMessage="Fabricante é obrigatório.">*</asp:RequiredFieldValidator>
                            </td>
                            <td class="pnltdConsulta">
                                <asp:Label ID="lblModelo" runat="server" Text="Modelo: " />
                            </td>
                            <td class="pnltdConsulta">
                                <cabtec:CABTECTextBox ID="txtModelo" runat="server" Tipo="TEXTO" />
                                <asp:RequiredFieldValidator ID="requiredModelo" runat="server" ValidationGroup="Valida"
                                    SetFocusOnError="true" ControlToValidate="txtModelo" ErrorMessage="Modelo é obrigatório.">*</asp:RequiredFieldValidator>
                            </td>
                            <td class="pnltdConsulta">
                                <asp:Label ID="lblUsoBackup" runat="server" Text="Backup: " />
                            </td>
                            <td class="pnltdCheck" align="left">
                                <asp:CheckBox ID="chkUsoBackup" runat="server" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlCampoLeitura" runat="server" GroupingText="Dados de Controle" CssClass="pnlCadastroLeitura">
                    <table>
                        <tr style="height: 30px">
                            <td class="pnltdConsulta">
                                <asp:Label ID="lblUsuarioCadastro" runat="server" Text="Usuário Cadastro: " />
                            </td>
                            <td class="pnltdConsulta">
                                <cabtec:CABTECTextBox ID="txtUsuarioCadastro" runat="server" Tipo="TEXTO" ReadOnly="true"
                                    Enabled="false" />
                            </td>
                            <td class="pnltdLabelDataControle">
                                <asp:Label ID="lblDataCadastro" runat="server" Text="Data de Cadastro: " />
                            </td>
                            <td class="pnltdDataControle">
                                <cabtec:CABTECTextBox ID="txtDataCadastro" runat="server" Tipo="DATA" ReadOnly="true"
                                    Enabled="false" />
                            </td>
                            <td class="pnltdConsulta">
                            </td>
                            <td class="pnltdCheck">
                        </tr>
                        <tr style="height: 30px">
                            <td class="pnltdConsulta">
                                <asp:Label ID="lblUsuarioResponsavel" runat="server" Text="Vendedor: " />
                            </td>
                            <td class="pnltdConsulta">
                                <cabtec:CABTECTextBox ID="txtUsuarioResponsavel" runat="server" Tipo="TEXTO" ReadOnly="true"
                                    Enabled="false" />
                            </td>
                            <td class="pnltdLabelDataControle">
                                <asp:Label ID="lblDataInativacao" runat="server" Text="Data de Inativação: " />
                            </td>
                            <td class="pnltdDataControle">
                                <cabtec:CABTECTextBox ID="txtDataInativacao" runat="server" Tipo="DATA" ReadOnly="true"
                                    Enabled="false" />
                            </td>
                             <td class="pnltdConsulta">
                                <asp:Label ID="lblAtivo" runat="server" Text="Ativo: " />
                            </td>
                            <td class="pnltdCheck">
                                <asp:CheckBox ID="chkAtivo" runat="server" ReadOnly="true" Enabled="false" />
                            </td>
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
                <cabtec:CABTECImageButton ID="btnVoltar" runat="server" Tipo="VOLTAR" OnClick="btnVoltar_Click" />
            </td>
            <td class="tdButtons">
                <cabtec:CABTECImageButton ID="btnSalvar" runat="server" Tipo="SALVAR" ValidationGroup="Valida"
                    OnClick="btnSalvar_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
