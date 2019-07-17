<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ProjetoWeb.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="~/Controle/Menu.ascx" TagName="Menu" TagPrefix="cabtec" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="cabtec" Namespace="WebControls" Assembly="WebControls" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>CABTEC - Consulting</title>
    <link href="Styles/Principal.css" rel="stylesheet" type="text/css" />
    <link href="Scripts/css/jquery.ui.core.css" rel="stylesheet" type="text/css" />
    <link href="Scripts/css/jquery.ui.datepicker.css" rel="stylesheet" type="text/css" />
    <link href="Scripts/css/jquery.ui.theme.css" rel="stylesheet" type="text/css" />
    <link href="Scripts/css/jquery-ui.css" rel="stylesheet" type="text/css" />

    <script src="Scripts/jquery-1.6.4.js" type="text/javascript"></script>

    <script src="Scripts/jquery.ui/jquery.ui.datepicker.js" type="text/javascript"></script>

    <script src="Scripts/jquery.ui/jquery.ui.core.js" type="text/javascript"></script>

    <script src="Scripts/jquery-ui.min.js" type="text/javascript"></script>

    <script src="Scripts/jquery.jgrowl_minimized.js" type="text/javascript"></script>

    <script src="Scripts/jquery.blockUI.js" type="text/javascript"></script>

    <script src="Scripts/jquery.mask.js" type="text/javascript"></script>

    <script src="Scripts/autoCurrency.js" type="text/javascript"></script>

    <script src="Scripts/jquery-ui-timepicker-addon.js" type="text/javascript"></script>

    <script src="Scripts/jquery.cycle.lite.js" type="text/javascript"></script>

    <script src="Scripts/WebControls.js" type="text/javascript"></script>

</head>
<body class="bodyLogin">
    <form id="Form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePageMethods="true"
        EnableScriptGlobalization="true" EnableScriptLocalization="true" />
    <table class="tableLogin">
        <tr>
            <td class="tdLogoLogin">
                <asp:HyperLink ID="hyperlinkPrincipalLogo" runat="server" NavigateUrl="~/Default.aspx">
                    <asp:Image ID="imagePrincipalLogo" runat="server" CssClass="imageLogo" ImageUrl="~/Images/LogoCliente.png" />
                </asp:HyperLink>
            </td>
            <td class="tdTituloLogin">
                <asp:Label ID="labelPrincipalNome" runat="server" Text="SINAF - SEGUROS" CssClass="labelTitulo" />
            </td>
            <td class="tdVersaoLogin">
                <span class="spanVersao">V_0.0.2</span>
            </td>
        </tr>
        <tr style="height: 40px">
            <td colspan="4" class="tdTituloModal">
                <asp:Label ID="lblTitulo" runat="server" Text="Projeto Entrevista Premiada"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <div id="divConteudo" runat="server" class="divConteudoCentro">
                    <table id="tableConteudo" runat="server" >
                        <tr id="trConteudo" runat="server">
                            <td style="width: 95%; padding-top: 20px;" valign="top" align="center">
                                <asp:Panel ID="pnlLogin" runat="server" GroupingText=" " CssClass="panelLogin">
                                    <table class="tableLoginCampos">
                                        <tr class="trSummaryPageCadastro">
                                            <td class="tdSummaryLogin">
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="true"
                                                    ValidationGroup="Valida" />
                                            </td>
                                        </tr>
                                        <tr id="trMensagemPageCadastro" runat="server" visible="false" class="trtableLoginCampos">
                                            <td class="tdMensagemLogin">
                                                <asp:Image ID="imgMensagem" runat="server" ImageAlign="Middle" />
                                                <asp:Label ID="lblMensagem" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                    <table class="tableLoginCampos">
                                        <tr class="trtableLoginCampos">
                                            <td class="tdLabelModal">
                                                <asp:Label ID="lblLogin" runat="server" Text="Login: " />
                                            </td>
                                            <td>
                                                <cabtec:CABTECTextBox ID="txtLogin" runat="server" Tipo="TEXTO" Width="120px" />
                                                <asp:RequiredFieldValidator ID="requiredLogin" runat="server" ValidationGroup="Valida"
                                                    SetFocusOnError="true" ControlToValidate="txtLogin" ErrorMessage="Login é obrigatório.">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr class="trtableLoginCampos">
                                            <td class="tdLabelModal">
                                                <asp:Label ID="lblSenha" runat="server" Text="Senha: " />
                                            </td>
                                            <td>
                                                <cabtec:CABTECTextBox ID="txtSenha" runat="server" Tipo="TEXTO" TextMode="Password"
                                                    Width="120px" MaxLength="10" />
                                                <asp:RequiredFieldValidator ID="requiredSenha" runat="server" SetFocusOnError="true"
                                                    ValidationGroup="Nenhum" ControlToValidate="txtSenha" ErrorMessage="Senha é obrigatória.">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr class="trtableLoginCampos">
                                            <td colspan="2">
                                                <table width="100%">
                                                    <tr>
                                                        <td class="tdLabelModal" width="60%">
                                                            <cabtec:CABTECLinkButton ID="linkEsqueciSenha" runat="server" Text="Esqueci a senha."
                                                                CssClass="linkEsqueceu" OnClick="linkEsqueciSenha_Click" ValidationGroup="Valida" />
                                                        </td>
                                                        <td align="right" width="40%">
                                                            <cabtec:CABTECImageButton ID="btnSalvar" runat="server" Tipo="SALVAR" ToolTip="Logar"
                                                                OnClick="btnSalvar_Click" ValidationGroup="Valida" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlDefinirSenha" runat="server" GroupingText="Nova Senha" CssClass="pnlParametro"
                                    Visible="false">
                                    <table class="tableLoginCampos">
                                        <tr class="trSummaryPageCadastro">
                                            <td class="tdSummaryLogin">
                                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowSummary="true"
                                                    ValidationGroup="MudarSenha" />
                                            </td>
                                        </tr>
                                    </table>
                                    <table class="tableLoginCampos">
                                        <tr id="trMensagemNovaSenha" runat="server" visible="false" class="trtableLoginCampos">
                                            <td colspan="2" class="tdMensagemLogin">
                                                <asp:Image ID="imgMensagemNovaSenha" runat="server" ImageAlign="Middle" />
                                                <asp:Label ID="lblMensagemNovaSenha" runat="server" />
                                            </td>
                                        </tr>
                                        <tr class="trtableLoginCampos">
                                            <td class="tdLabelModal">
                                                <asp:Label ID="lblSenhaNova" runat="server" Text="Nova Senha: " />
                                            </td>
                                            <td>
                                                <cabtec:CABTECTextBox ID="txtSenhaNova" runat="server" Tipo="TEXTO" TextMode="Password"
                                                    MaxLength="10" />
                                                <asp:RequiredFieldValidator ID="requiredSenhaNova" runat="server" ValidationGroup="MudarSenha"
                                                    SetFocusOnError="true" ControlToValidate="txtSenhaNova" ErrorMessage="Nova Senha é obrigatória.">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr class="trtableLoginCampos">
                                            <td class="tdLabelModal">
                                                <asp:Label ID="lblSenhaConfirmar" runat="server" Text="Confirmar Senha: " />
                                            </td>
                                            <td>
                                                <cabtec:CABTECTextBox ID="txtSenhaConfirmar" runat="server" Tipo="TEXTO" TextMode="Password"
                                                    MaxLength="10" />
                                                <asp:CompareValidator ID="compareCofirmarSenha" runat="server" ValidationGroup="MudarSenha"
                                                    SetFocusOnError="true" ControlToValidate="txtSenhaConfirmar" ControlToCompare="txtSenhaNova"
                                                    Operator="Equal" Type="String" ErrorMessage="Os campos Nova Senha e Confirmar Senha não possuem o mesmo valor.">*</asp:CompareValidator>
                                            </td>
                                        </tr>
                                        <tr class="trtableLoginCampos">
                                            <td class="tdLabelModal">
                                            </td>
                                            <td align="right">
                                                <cabtec:CABTECImageButton ID="btnCancelar" runat="server" Tipo="VOLTAR" ToolTip="Cancelar"
                                                    OnClick="btnCancelar_Click" />
                                                <cabtec:CABTECImageButton ID="btnMudarSenha" runat="server" Tipo="SALVAR" ToolTip="Mudar Senha"
                                                    ValidationGroup="MudarSenha" OnClick="btnMudarSenha_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                            <td class="imgCABTEC">
                                <asp:Image ID="imgLogo" runat="server" ImageUrl="~/Images/logo90.png" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <div class="divMenuEsquerda">
                    <asp:Image runat="server" ID="ImageEsquerda" CssClass="imgMenuEsquerda" ImageUrl="~/Images/MenuEsquerda.png" />
                </div>
                <div class="divMenuDireita">
                    <asp:Image runat="server" ID="ImageDireita" CssClass="imgMenuDireita" ImageUrl="~/Images/MenuDireita.png" />
                </div>
                <div id="MenuPrincipal" runat="server" class="divMenu">
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
