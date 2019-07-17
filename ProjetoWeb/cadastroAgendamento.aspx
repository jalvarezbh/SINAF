<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="cadastroAgendamento.aspx.cs" Inherits="ProjetoWeb.cadastroAgendamento" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="ContentPopUp" ContentPlaceHolderID="PopUpContent" runat="server">    
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <table class="tablePrincipalConteudo">
        <tr class="trTituloPageCadastro">
            <td class="tdTituloPageCadastro" align="center">
                <asp:Label ID="lblTitulo" runat="server" Text="Cadastrar Agendamento" CssClass="tdTituloPageCadastroLabel" />
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
                <asp:HiddenField ID="hiddenIDAgendamento" runat="server" Visible="false" />
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
                            <td class="pnltd3ColunaLeftLabel">
                                <asp:Label ID="lblNome" runat="server" Text="Nome: " />
                            </td>
                            <td style="width: 300px;" align="left">
                                <cabtec:CABTECTextBox ID="txtNome" runat="server" Tipo="TEXTO" Width="250px" />
                                <asp:RequiredFieldValidator ID="requiredNome" runat="server" ValidationGroup="Valida"
                                    SetFocusOnError="true" ControlToValidate="txtNome" ErrorMessage="Nome é obrigatório.">*</asp:RequiredFieldValidator>
                            </td>
                            <td class="pnltd3ColunaCenterLabel">
                                <asp:Label ID="lblDataNascimento" runat="server" Text="Data de Nascimento: " />
                            </td>
                            <td class="pnltd3ColunaCenterText">
                                <cabtec:CABTECTextBox ID="txtDataNascimento" runat="server" Tipo="DATA" Width="120px"
                                    Estilo="false" BorderColor="Black" BorderWidth="1" />
                                <asp:RequiredFieldValidator ID="requiredDataNascimento" runat="server" ValidationGroup="Valida"
                                    SetFocusOnError="true" ControlToValidate="txtDataNascimento" ErrorMessage="Data de Nascimento é obrigatório.">*</asp:RequiredFieldValidator>
                            </td>
                            <td class="pnltd3ColunaRightLabel">
                            </td>
                            <td class="pnltd3ColunaRightText" align="left">
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <td class="pnltd3ColunaLeftLabel">
                                <asp:Label ID="lblEmail" runat="server" Text="Email: " />
                            </td>
                            <td style="width: 300px;" align="left">
                                <cabtec:CABTECTextBox ID="txtEmail" runat="server" Tipo="TEXTO" Width="250px" />
                            </td>
                            <td class="pnltd3ColunaCenterLabel">
                                <asp:Label ID="lblTelefone" runat="server" Text="Telefone: " />
                            </td>
                            <td class="pnltd3ColunaCenterText">
                                <cabtec:CABTECTextBox ID="txtTelefone" runat="server" Tipo="TELEFONE" />
                                <asp:RequiredFieldValidator ID="requiredTelefone" runat="server" ValidationGroup="Valida"
                                    SetFocusOnError="true" ControlToValidate="txtTelefone" ErrorMessage="Telefone é obrigatório.">*</asp:RequiredFieldValidator>
                            </td>
                            <td class="pnltd3ColunaRightLabel">
                                <asp:Label ID="lblCelular" runat="server" Text="Celular: " />
                            </td>
                            <td class="pnltd3ColunaRightText">
                                <cabtec:CABTECTextBox ID="txtCelular" runat="server" Tipo="TELEFONE" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlCampoLeitura" runat="server" GroupingText="Dados de Endereço" CssClass="pnlCadastroLeitura">
                    <table>
                        <tr style="height: 30px">
                            <td class="pnltd3ColunaLeftLabel">
                                <asp:Label ID="lblCEP" runat="server" Text="CEP: " />
                            </td>
                            <td colspan="5" align="left">
                                <cabtec:CABTECTextBox ID="txtCEP" runat="server" Tipo="CEP" 
                                    ontextchanged="txtCEP_TextChanged" AutoPostBack="true"  />
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <td class="pnltd3ColunaLeftLabel">
                                <asp:Label ID="lblEndereco" runat="server" Text="Endereço: " />
                            </td>
                            <td style="width: 300px;" align="left">
                                <cabtec:CABTECTextBox ID="txtEndereco" runat="server" Tipo="TEXTO" Width="250px" />
                            </td>
                            <td class="pnltd3ColunaCenterLabel">
                                <asp:Label ID="lblNumero" runat="server" Text="Número: " />
                            </td>
                            <td class="pnltd3ColunaCenterText" align="left">
                                <cabtec:CABTECTextBox ID="txtNumero" runat="server" Tipo="TEXTO" />
                            </td>
                            <td class="pnltd3ColunaRightLabel">
                                <asp:Label ID="lblComplemento" runat="server" Text="Complemento: " />
                            </td>
                            <td class="pnltd3ColunaRightText" align="left">
                                <cabtec:CABTECTextBox ID="txtComplemento" runat="server" Tipo="TEXTO" Width="120px" />
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <td class="pnltd3ColunaLeftLabel">
                                <asp:Label ID="lblBairro" runat="server" Text="Bairro: " />
                            </td>
                            <td class="pnltd3ColunaLeftText" align="left">
                                <cabtec:CABTECTextBox ID="txtBairro" runat="server" Tipo="TEXTO" />
                            </td>
                            <td class="pnltd3ColunaCenterLabel">
                                <asp:Label ID="lblCidade" runat="server" Text="Cidade: " />
                            </td>
                            <td class="pnltd3ColunaCenterText" align="left">
                                <cabtec:CABTECTextBox ID="txtCidade" runat="server" Tipo="TEXTO" />
                            </td>
                            <td class="pnltd3ColunaRightLabel">
                                <asp:Label ID="lblEstado" runat="server" Text="Estado: " />
                            </td>
                            <td class="pnltd3ColunaRightText" align="left">
                                <asp:DropDownList ID="ddlEstado" runat="server" Width="125px" CssClass="controleDDL" >
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <td class="pnltd3ColunaLeftLabel">
                                <asp:Label ID="lblPontoReferencia" runat="server" Text="Ponto de Referência: " />
                            </td>
                            <td colspan="5" align="left">
                                <cabtec:CABTECTextBox ID="txtPontoReferencia" runat="server" Tipo="TEXTO" Width="250px"/>
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
