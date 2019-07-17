<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="cadastroSenha.aspx.cs" Inherits="ProjetoWeb.cadastroSenha" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="ContentPopUp" ContentPlaceHolderID="PopUpContent" runat="server">    
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <table class="tablePrincipalConteudo">
        <tr class="trTituloPageCadastro">
            <td class="tdTituloPageCadastro" align="center">
                <asp:Label ID="lblTitulo" runat="server" Text="Cadastrar Senha" CssClass="tdTituloPageCadastroLabel" />
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
                <asp:HiddenField ID="hiddenIDParametro" runat="server" Visible="false" />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="true"
                    ValidationGroup="Valida" />
            </td>
        </tr>
        <tr class="trConteudoPageCadastro">
            <td>
                <asp:Panel ID="pnlMudarSenha" runat="server" GroupingText="Modificar Senha" CssClass="pnlCadastroEditavel">
                    <table>
                        <tr style="height: 30px">
                            <td class="pnltdConsulta">
                                <asp:Label ID="lblSenhaAtual" runat="server" Text="Senha Atual: " />
                            </td>
                            <td class="pnltdConsulta">
                                <cabtec:CABTECTextBox ID="txtSenhaAtual" runat="server" Tipo="TEXTO" TextMode="Password"  MaxLength="10" />
                                <asp:RequiredFieldValidator ID="requiredSenhaAtual" runat="server" ValidationGroup="Valida"
                                    SetFocusOnError="true" ControlToValidate="txtSenhaAtual" ErrorMessage="Senha Atual é obrigatória.">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <td class="pnltdConsulta">
                                <asp:Label ID="lblSenhaNova" runat="server" Text="Nova Senha: " />
                            </td>
                            <td class="pnltdConsulta"> 
                                <cabtec:CABTECTextBox ID="txtSenhaNova" runat="server" Tipo="TEXTO" TextMode="Password" MaxLength="10" />
                                <asp:RequiredFieldValidator ID="requiredSenhaNova" runat="server" ValidationGroup="Valida"
                                    SetFocusOnError="true" ControlToValidate="txtSenhaNova" ErrorMessage="Nova Senha é obrigatória.">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <td class="pnltdConsulta">
                                <asp:Label ID="lblCofirmarSenha" runat="server" Text="Confirmar Senha: " />
                            </td>
                            <td class="pnltdConsulta">
                                <cabtec:CABTECTextBox ID="txtCofirmarSenha" runat="server" Tipo="TEXTO" TextMode="Password"  MaxLength="10" />
                               <asp:CompareValidator ID="compareCofirmarSenha" runat="server" ValidationGroup="Valida"
                                    SetFocusOnError="true" ControlToValidate="txtCofirmarSenha" ControlToCompare="txtSenhaNova"
                                    Operator="Equal" Type="String" ErrorMessage="Os campos Nova Senha e Confirmar Senha não possuem o mesmo valor.">*</asp:CompareValidator>
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
