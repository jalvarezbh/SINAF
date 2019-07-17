<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cadastroPlano.aspx.cs" Inherits="ProjetoWeb.cadastroPlano" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="ContentPopUp" ContentPlaceHolderID="PopUpContent" runat="server">    
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <table class="tablePrincipalConteudo">
        <tr class="trTituloPageCadastro">
            <td class="tdTituloPageCadastro" align="center">
                <asp:Label ID="lblTitulo" runat="server" Text="Cadastro de Planos" CssClass="tdTituloPageCadastroLabel" />
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
                <asp:Panel ID="pnlCampoCadastro" runat="server" GroupingText="Download Arquivo" CssClass="pnlCadastroEditavelDonwload">
                    <table>
                        <tr style="height: 30px">
                            <td style="width: 150px;" align="right">
                                <asp:Label ID="lblDownloadPF" runat="server" Text="Proteção Familia: " />
                            </td>
                            <td style="width: 100px; padding-left: 20px;" align="left">
                                <asp:ImageButton ID="imgDownloadPF" runat="server" ImageUrl="~/Images/download32.ico" OnClick="imgDownloadPF_Click" />
                            </td>
                            <td style="width: 150px;" align="right">
                                <asp:Label ID="lblDownloadAS" runat="server" Text="Assistência Senior: " />
                            </td>
                            <td style="width: 100px; padding-left: 20px;" align="left">
                                <asp:ImageButton ID="imgDownloadAS" runat="server" ImageUrl="~/Images/download32.ico" OnClick="imgDownloadAS_Click" />
                            </td>
                            <td style="width: 150px;" align="right">
                                <asp:Label ID="lblDownloadASC" runat="server" Text="Assistência Senior Casal: " />
                            </td>
                            <td style="width: 100px; padding-left: 20px;" align="left">
                                <asp:ImageButton ID="imgDownloadASC" runat="server" ImageUrl="~/Images/download32.ico" OnClick="imgDownloadASC_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlCampoExemplo" runat="server" GroupingText="Download Arquivo Exemplo" CssClass="pnlCadastroEditavelDonwload">
                    <table>
                        <tr style="height: 30px">
                            <td style="width: 150px;" align="right">
                                <asp:Label ID="lblExemploProtecao" runat="server" Text="Proteção Familia: " />
                            </td>
                            <td style="width: 100px; padding-left: 20px;" align="left">
                                <asp:ImageButton ID="imgExemploProtecao" runat="server" ImageUrl="~/Images/download32.ico" OnClick="imgExemploProtecao_Click" />
                            </td>
                            <td style="width: 150px;" align="right">
                                <asp:Label ID="lblExemploSenior" runat="server" Text="Assistência Senior: " />
                            </td>
                            <td style="width: 100px; padding-left: 20px;" align="left">
                                <asp:ImageButton ID="imgExemploSenior" runat="server" ImageUrl="~/Images/download32.ico" OnClick="imgExemploSenior_Click" />
                            </td>
                            <td style="width: 150px;" align="right">
                                <asp:Label ID="lblExemploCasal" runat="server" Text="Assistência Senior Casal: " />
                            </td>
                            <td style="width: 100px; padding-left: 20px;" align="left">
                                <asp:ImageButton ID="imgExemploCasal" runat="server" ImageUrl="~/Images/download32.ico" OnClick="imgExemploCasal_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlCampoLeitura" runat="server" GroupingText="Upload Arquivo" CssClass="pnlCadastroLeitura">
                    <table>
                        <tr style="height: 30px">
                            <td style="width: 150px;" align="right">
                                <asp:Label ID="lblUploadPF" runat="server" Text="Proteção Familia: " />
                            </td>
                            <td style="width: 400px; padding-left: 20px;" align="left">
                                <asp:FileUpload ID="fupUploadPF" runat="server" BorderColor="Black" BorderWidth="1" Width="380px" />
                            </td>
                            <td>
                                <asp:ImageButton ID="imgUploadPF" runat="server" ImageUrl="~/Images/upload32.ico" OnClick="imgUploadPF_Click" />
                            </td>
                            <td>
                                <asp:Label ID="lblMSGUploadPF" runat="server" Text="" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 150px;" align="right">
                                <asp:Label ID="lblUploadAS" runat="server" Text="Assistência Senior: " />
                            </td>
                            <td style="width: 400px; padding-left: 20px;" align="left">
                                <asp:FileUpload ID="fupUploadAS" runat="server" BorderColor="Black" BorderWidth="1" Width="380px" />
                            </td>
                            <td>
                                <asp:ImageButton ID="imgUploadAS" runat="server" ImageUrl="~/Images/upload32.ico" OnClick="imgUploadAS_Click" />
                            </td>
                            <td>
                                <asp:Label ID="lblMSGUploadAS" runat="server" Text="" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 150px;" align="right">
                                <asp:Label ID="lblUploadASC" runat="server" Text="Assistência Senior Casal: " />
                            </td>
                            <td style="width: 400px; padding-left: 20px;" align="left">
                                <asp:FileUpload ID="fupUploadASC" runat="server" BorderColor="Black" BorderWidth="1" Width="380px" />
                            </td>
                            <td>
                                <asp:ImageButton ID="imgUploadASC" runat="server" ImageUrl="~/Images/upload32.ico" OnClick="imgUploadASC_Click" />
                            </td>
                            <td>
                                <asp:Label ID="lblMSGUploadASC" runat="server" Text="" />
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
        </tr>
    </table>
</asp:Content>
