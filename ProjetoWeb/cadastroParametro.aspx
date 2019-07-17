<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="cadastroParametro.aspx.cs" Inherits="ProjetoWeb.cadastroParametro" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="ContentPopUp" ContentPlaceHolderID="PopUpContent" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <table class="tablePrincipalConteudo">
        <tr class="trTituloPageCadastro">
            <td class="tdTituloPageCadastro" align="center">
                <asp:Label ID="lblTitulo" runat="server" Text="Parâmetrização do Sistema" CssClass="tdTituloPageCadastroLabel" />
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
                <asp:ValidationSummary runat="server" ShowSummary="true" ValidationGroup="Valida" />
            </td>
        </tr>
        <tr class="trConteudoPageCadastro">
            <td>
                <asp:Panel ID="pnlParametrosWEB" runat="server" GroupingText="Parâmetros Web" CssClass="pnlParametro">
                    <table>
                        <tr style="height: 30px">
                            <td>
                                <asp:Label ID="lblEstoqueWEB" runat="server" Text="Estoque de Faixas: " />
                            </td>
                            <td>
                                <asp:Label ID="lblEstoqueMinimoWEB" runat="server" Text="Mínimo: " />
                            </td>
                            <td>
                                <cabtec:CABTECTextBox ID="txtEstoqueMinimoWEB" runat="server" Tipo="NUMERO" MaxLength="9" />
                                <asp:RequiredFieldValidator ID="requiredEstoqueMinimoWEB" runat="server" ValidationGroup="Valida"
                                    SetFocusOnError="true" ControlToValidate="txtEstoqueMinimoWEB" ErrorMessage="WEB - Estoque de Faixas campo Mínimo é obrigatório.">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Label ID="lblEstoqueMaximoWEB" runat="server" Text="Máximo: " />
                            </td>
                            <td>
                                <cabtec:CABTECTextBox ID="txtEstoqueMaximoWEB" runat="server" Tipo="NUMERO" MaxLength="9" />
                                <asp:RequiredFieldValidator ID="requiredEstoqueMaximoWEB" runat="server" ValidationGroup="Valida"
                                    SetFocusOnError="true" ControlToValidate="txtEstoqueMaximoWEB" ErrorMessage="WEB - Estoque de Faixas campo Máximo é obrigatório.">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="compareEstoqueMaximoWEB" runat="server" ValidationGroup="Valida"
                                    SetFocusOnError="true" ControlToValidate="txtEstoqueMaximoWEB" ControlToCompare="txtEstoqueMinimoWEB"
                                    Operator="GreaterThanEqual" Type="Integer" ErrorMessage="WEB - Estoque de Faixas campo Máximo não pode ser menor que campo Mínimo.">*</asp:CompareValidator>
                            </td>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td colspan="4" class="pnltdParametro">
                                <asp:Label ID="lblTempoDadosServidorDias" runat="server" Text="Tempo máximo que os dados permanecerão na base do servidor, em dias: " />
                            </td>
                            <td>
                                <cabtec:CABTECTextBox ID="txtTempoDadosServidorDias" runat="server" Tipo="NUMERO"
                                    MaxLength="9" />
                                <asp:RequiredFieldValidator ID="requiredTempoDadosServidorDias" runat="server" ValidationGroup="Valida"
                                    SetFocusOnError="true" ControlToValidate="txtTempoDadosServidorDias" ErrorMessage="WEB - Tempo máximo que os dados permanecerão na base do servidor é obrigatório.">*</asp:RequiredFieldValidator>
                            </td>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td colspan="4" class="pnltdParametro">
                                <asp:Label ID="lblTempoVerificaERPDias" runat="server" Text="Tempo de verificação da base ERP SINAF, em dias: " />
                            </td>
                            <td>
                                <cabtec:CABTECTextBox ID="txtTempoVerificaERPDias" runat="server" Tipo="NUMERO" MaxLength="9" />
                                <asp:RequiredFieldValidator ID="requiredTempoVerificaERPDias" runat="server" ValidationGroup="Valida"
                                    SetFocusOnError="true" ControlToValidate="txtTempoVerificaERPDias" ErrorMessage="WEB - Tempo de verificação da base ERP SINAF é obrigatório.">*</asp:RequiredFieldValidator>
                            </td>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td colspan="4" class="pnltdParametro">
                                <asp:Label ID="lblServicoUsuario" runat="server" Text="Executar serviço de importação de usuário: " />
                            </td>
                            <td>
                                <asp:ImageButton ID="imgServicoUsuario" runat="server" ImageUrl="~/Images/upload32.ico" OnClick="imgServicoUsuario_Click"  />
                                   </td>
                            <td colspan="2"></td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlParametrosColetor" runat="server" GroupingText="Parâmetros Coletor"
                    CssClass="pnlParametro">
                    <table>
                        <tr style="height: 30px">
                            <td>
                                <asp:Label ID="lblEstoqueColetor" runat="server" Text="Estoque de Faixas: " />
                            </td>
                            <td>
                                <asp:Label ID="lblEstoqueMinimoColetor" runat="server" Text="Mínimo: " />
                            </td>
                            <td>
                                <cabtec:CABTECTextBox ID="txtEstoqueMinimoColetor" runat="server" Tipo="NUMERO" MaxLength="9" />
                                <asp:RequiredFieldValidator ID="requiredEstoqueMinimoColetor" runat="server" ValidationGroup="Valida"
                                    SetFocusOnError="true" ControlToValidate="txtEstoqueMinimoColetor" ErrorMessage="Coletor - Estoque de Faixas campo Mínimo é obrigatório.">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Label ID="lblEstoqueMaximoColetor" runat="server" Text="Máximo: " />
                            </td>
                            <td>
                                <cabtec:CABTECTextBox ID="txtEstoqueMaximoColetor" runat="server" Tipo="NUMERO" MaxLength="9" />
                                <asp:RequiredFieldValidator ID="requiredEstoqueMaximoColetor" runat="server" ValidationGroup="Valida"
                                    SetFocusOnError="true" ControlToValidate="txtEstoqueMaximoColetor" ErrorMessage="Coletor - Estoque de Faixas campo Máximo é obrigatório.">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="compareEstoqueMaximoColetor" runat="server" ValidationGroup="Valida"
                                    SetFocusOnError="true" ControlToValidate="txtEstoqueMaximoColetor" ControlToCompare="txtEstoqueMinimoColetor"
                                    Operator="GreaterThanEqual" Type="Integer" ErrorMessage="Coletor - Estoque de Faixas campo Máximo não pode ser menor que campo Mínimo.">*</asp:CompareValidator>
                            </td>
                            <td>
                                <asp:Label ID="lblVersaoCorreio" runat="server" Text="Versão Base Correio: " />
                            </td>
                            <td>
                                <cabtec:CABTECTextBox ID="txtVersaoCorreio" runat="server" Tipo="NUMERO" MaxLength="9" />
                                <asp:RequiredFieldValidator ID="requiredVersaoCorreio" runat="server" ValidationGroup="Valida"
                                    SetFocusOnError="true" ControlToValidate="txtVersaoCorreio" ErrorMessage="Coletor - Versão Base Correio é obrigatório.">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" class="pnltdParametro">
                                <asp:Label ID="lblTempoLogOff" runat="server" Text="Tempo de log-off automático dos coletores, em minutos: " />
                            </td>
                            <td>
                                <cabtec:CABTECTextBox ID="txtTempoLogOff" runat="server" Tipo="NUMERO" MaxLength="9" />
                                <asp:RequiredFieldValidator ID="requiredTempoLogOff" runat="server" ValidationGroup="Valida"
                                    SetFocusOnError="true" ControlToValidate="txtTempoLogOff" ErrorMessage="Coletor - Tempo de log-off automático dos coletores é obrigatório.">*</asp:RequiredFieldValidator>
                            </td>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td colspan="4" class="pnltdParametro">
                                <asp:Label ID="lblPrazoSincronismoDia" runat="server" Text="Prazo máximo permitido para ficar sem sincronismo, em dias: " />
                            </td>
                            <td>
                                <cabtec:CABTECTextBox ID="txtPrazoSincronismoDia" runat="server" Tipo="NUMERO" MaxLength="9" />
                                <asp:RequiredFieldValidator ID="requiredPrazoSincronismoDia" runat="server" ValidationGroup="Valida"
                                    SetFocusOnError="true" ControlToValidate="txtPrazoSincronismoDia" ErrorMessage="Coletor - Prazo máximo permitido para ficar sem sincronismo é obrigatório.">*</asp:RequiredFieldValidator>
                            </td>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td colspan="4" class="pnltdParametro">
                                <asp:Label ID="lblPrazoEntrevistaColetor" runat="server" Text="Prazo que a entrevista permanece no coletor após sincronismo, em dias: " />
                            </td>
                            <td>
                                <cabtec:CABTECTextBox ID="txtPrazoEntrevistaColetor" runat="server" Tipo="NUMERO" MaxLength="3" />
                                <asp:RequiredFieldValidator ID="requiredPrazoEntrevistaColetor" runat="server" ValidationGroup="Valida"
                                    SetFocusOnError="true" ControlToValidate="txtPrazoEntrevistaColetor" ErrorMessage="Coletor - Prazo que a entrevista permanece no coletor após sincronismo é obrigatório.">*</asp:RequiredFieldValidator>
                            </td>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td colspan="4" class="pnltdParametro">
                                <asp:Label ID="lblPrazoIncompletaColetor" runat="server" Text="Prazo que a entrevista incompleta permanece no coletor, em dias: " />
                            </td>
                            <td>
                                <cabtec:CABTECTextBox ID="txtPrazoIncompletaColetor" runat="server" Tipo="NUMERO" MaxLength="3" />
                                <asp:RequiredFieldValidator ID="requiredPrazoIncompletaColetor" runat="server" ValidationGroup="Valida"
                                    SetFocusOnError="true" ControlToValidate="txtPrazoIncompletaColetor" ErrorMessage="Coletor - Prazo que a entrevista incompleta permanece no coletor é obrigatório.">*</asp:RequiredFieldValidator>
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
                <cabtec:CABTECImageButton ID="btnVoltar" runat="server" Tipo="VOLTAR" OnClick="btnVoltar_Click" />
            </td>
            <td class="tdButtons">
                <cabtec:CABTECImageButton ID="btnSalvar" runat="server" Tipo="SALVAR" ValidationGroup="Valida"
                    OnClick="btnSalvar_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
