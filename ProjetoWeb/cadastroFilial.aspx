<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="cadastroFilial.aspx.cs" Inherits="ProjetoWeb.cadastroFilial" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="ContentPopUp" ContentPlaceHolderID="PopUpContent" runat="server">    
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <table class="tablePrincipalConteudo">
        <tr class="trTituloPageCadastro">
            <td class="tdTituloPageCadastro" align="center">
                <asp:Label ID="lblTitulo" runat="server" Text="Relação de Áreas de Atividades" CssClass="tdTituloPageCadastroLabel" />
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
                <asp:Panel ID="pnlCampoCadastro" runat="server" GroupingText="Download Arquivo" CssClass="pnlCadastroEditavel">
                    <table>
                        <tr style="height: 30px">
                            <td style="width: 200px;" align="right">
                                <asp:Label ID="lblDownload" runat="server" Text="Download Aquivo de Base: " />
                            </td>
                            <td style="width: 300px; padding-left: 20px;" align="left">
                                <asp:ImageButton ID="imgDownload" runat="server" ImageUrl="~/Images/download32.ico"
                                    OnClick="imgDownload_Click"   />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlCampoLeitura" runat="server" GroupingText="Upload Arquivo" CssClass="pnlCadastroLeitura">
                    <table>
                        <tr style="height: 30px">
                            <td style="width: 200px;" align="right">
                                <asp:Label ID="lblUpload" runat="server" Text="Upload Arquivo de Dados: " />
                            </td>
                            <td style="width: 400px; padding-left: 20px;" align="left">
                                <asp:FileUpload ID="fupUpload" runat="server" BorderColor="Black" BorderWidth="1"
                                    Width="380px" />
                            </td>
                            <td>
                                <asp:ImageButton ID="imgUpload" runat="server" ImageUrl="~/Images/upload32.ico" OnClick="imgUpload_Click" />
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <td style="width: 200px;" align="right">
                                <asp:Label ID="lblProcesso" runat="server" Text="Processo: " />
                            </td>
                            <td rowspan="2" colspan="2" style="padding-left: 20px;" align="left">
                                <asp:TextBox ID="txtUploadProgress" runat="server" TextMode="MultiLine" Height="50px" Width="380px" BorderColor="Black" BorderWidth="1"></asp:TextBox>
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
                <cabtec:CABTECImageButton ID="btnVoltar" runat="server" Tipo="VOLTAR" OnClick="btnVoltar_Click"/>
            </td>
        </tr>
    </table>
</asp:Content>
