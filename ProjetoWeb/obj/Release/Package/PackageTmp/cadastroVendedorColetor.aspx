<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="cadastroVendedorColetor.aspx.cs" Inherits="ProjetoWeb.cadastroVendedorColetor" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="ContentPopUp" ContentPlaceHolderID="PopUpContent" runat="server">    
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <table class="tablePrincipalConteudo">
        <tr class="trTituloPageCadastro">
            <td class="tdTituloPageCadastro" align="center" colspan="5">
                <asp:Label ID="lblTitulo" runat="server" Text="Associar Coletor - Vendedor" CssClass="tdTituloPageCadastroLabel" />
            </td>
        </tr>
        <tr id="trMensagemPageCadastro" runat="server" visible="false">
            <td colspan="5">
                <asp:Panel ID="pnlMensagem" runat="server" CssClass="pnlMensagem" GroupingText=" ">
                    <table>
                        <tr>
                            <td valign="middle" >
                                <asp:Image ID="imgMensagem" runat="server" ImageAlign="Middle" />
                            </td>
                            <td>
                                <asp:Label ID="lblMensagem" runat="server" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr class="trSummaryPageCadastro">
            <td class="tdSummaryPageCadastro" colspan="5">
                <asp:HiddenField ID="hiddenIDColetor" runat="server" Visible="false" />
                <asp:HiddenField ID="HiddenIDVendedor" runat="server" Visible="false" />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="true"
                    ValidationGroup="Coletor" />
                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowSummary="true"
                    ValidationGroup="Vendedor" />
                <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowSummary="true"
                    ValidationGroup="Valida" />
            </td>
        </tr>
        <tr class="trConteudoPageCadastro">
            <td>
                <asp:Panel ID="pnlColetor" runat="server" GroupingText="Coletores" CssClass="pnlAssociaColetor">
                    <table width="300px">
                        <tr style="height: 30px">
                            <td align="center" width="300px">
                                <asp:Label ID="lblColetorPesquisa" runat="server" Text="Número de Série: " />
                                <cabtec:CABTECTextBox ID="txtColetorPesquisa" runat="server" Tipo="TEXTO" Width="100px" />
                                <asp:ImageButton ID="btnColetorPesquisa" runat="server" ImageUrl="~/Images/search14.ico"
                                    OnClick="btnColetorPesquisa_Click" />
                            </td>
                        </tr>
                        <tr style="height: 270px">
                            <td align="center" width="200px">
                                <asp:ListBox ID="lstColetor" runat="server" Width="200px" Height="250px"></asp:ListBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td>
                <asp:Panel ID="Panel1" runat="server" CssClass="pnlAssociaButtonsColetor">
                    <asp:ImageButton ID="imgColetor" runat="server" ImageUrl="~/Images/coletor32.ico"
                        OnClick="imgColetor_Click" ToolTip="Selecionar Coletor" />
                </asp:Panel>
            </td>
            <td>
                <asp:Panel ID="pnlAssociacao" runat="server" GroupingText="Associação" CssClass="pnlAssociaColetorMiddle">
                    <table width="100%">
                        <tr style="height: 30px">
                            <td align="center" width="100%">
                                <asp:Label ID="lblAssociarPor" runat="server" Text="Associar Por: " />
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <td align="center">
                                <asp:RadioButton ID="rdbColetor" runat="server" Text="Coletor" GroupName="Associar"
                                    AutoPostBack="true" OnCheckedChanged="rdbColetor_CheckedChanged" />
                                <asp:RadioButton ID="rdbVendedor" runat="server" Text="Vendedor" GroupName="Associar"
                                    AutoPostBack="true" OnCheckedChanged="rdbVendedor_CheckedChanged" />
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <td>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <td align="center" width="100%">
                                <asp:Label ID="lblColetorSelecionado" runat="server" Text="Coletor: " />
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <td align="center">
                                <cabtec:CABTECTextBox ID="txtColetorSelecionado" runat="server" Tipo="TEXTO" Width="150px"
                                    ReadOnly="true" />
                                <asp:RequiredFieldValidator ID="requiredColetorSelecionado" runat="server" ValidationGroup="Coletor"
                                    ControlToValidate="txtColetorSelecionado" ErrorMessage="Primeiro selecione o Coletor.">*</asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="requiredColetor" runat="server" ValidationGroup="Valida"
                                    ControlToValidate="txtColetorSelecionado" ErrorMessage="Selecione o Coletor.">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <td>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <td align="center">
                                <asp:Label ID="lblVendedorSelecionado" runat="server" Text="Vendedor: " />
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <td align="center">
                                <cabtec:CABTECTextBox ID="txtVendedorSelecionado" runat="server" Tipo="TEXTO" Width="150px"
                                    ReadOnly="true" />
                                <asp:RequiredFieldValidator ID="requiredVendedorSelecionado" runat="server" ValidationGroup="Vendedor"
                                    ControlToValidate="txtVendedorSelecionado" ErrorMessage="Primeiro selecione o Vendedor.">*</asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="requiredVendedor" runat="server" ValidationGroup="Valida"
                                    ControlToValidate="txtVendedorSelecionado" ErrorMessage="Selecione o Vendedor.">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr style="height: 50px">
                            <td>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td>
                <asp:Panel ID="Panel2" runat="server" CssClass="pnlAssociaButtonsVendedor">
                    <asp:ImageButton ID="imgVendedor" runat="server" ImageUrl="~/Images/vendedor32.ico"
                        OnClick="imgVendedor_Click" ToolTip="Selecionar Vendedor" />
                </asp:Panel>
            </td>
            <td>
                <asp:Panel ID="pnlVendedor" runat="server" GroupingText="Vendedores" CssClass="pnlAssociaColetorLeft">
                    <table width="300px">
                        <tr style="height: 30px">
                            <td align="center" width="200px">
                                <asp:Label ID="lblVendedorPesquisa" runat="server" Text="Nome: " />
                                <cabtec:CABTECTextBox ID="txtVendedorPesquisa" runat="server" Tipo="TEXTO" Width="100px" />
                                <asp:ImageButton ID="btnVendedorPesquisa" runat="server" ImageUrl="~/Images/search14.ico"
                                    OnClick="btnVendedorPesquisa_Click" />
                            </td>
                        </tr>
                        <tr style="height: 270px">
                            <td align="center" width="200px">
                                <asp:ListBox ID="lstVendedor" runat="server" Width="200px" Height="250px"></asp:ListBox>
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
                    OnClick="btnSalvar_Click" ToolTip="Associar Coletor/Vendedor" />
            </td>
        </tr>
    </table>
</asp:Content>
