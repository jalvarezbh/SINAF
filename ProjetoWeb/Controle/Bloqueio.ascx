<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Bloqueio.ascx.cs" Inherits="ProjetoWeb.Controle.Bloqueio" %>
<link href="../Styles/Principal.css" rel="stylesheet" type="text/css" />
<asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="panelModal"
    BackgroundCssClass="modalBackground" TargetControlID="buttonModal">
</asp:ModalPopupExtender>
<asp:HiddenField ID="hiddenIDColetor" runat="server" />
<cabtec:CABTECButton ID="buttonModal" Text="button" runat="server" Style="visibility: hidden" />
<asp:Panel ID="panelModal" runat="server" CssClass="panelBloqueio">
    <div>
        <table>
            <tr style="height: 40px">
                <td colspan="2" class="tdTituloModal">
                    <asp:Label ID="lblTitulo" runat="server" Text="Bloqueio Coletor"></asp:Label>
                </td>
            </tr>
            <tr class="trSummaryPageCadastro">
                <td colspan="2" class="tdSummaryPageCadastro">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="true"
                        ValidationGroup="Bloqueio" />
                </td>
            </tr>
            <tr style="height: 30px">
                <td class="tdLabelModal">
                    <asp:Label ID="lblNumeroSerie" runat="server" Text="Número de Série: "></asp:Label>
                </td>
                <td class="tdTextModal">
                    <asp:Label ID="txtNumeroSerie" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="height: 30px">
                <td class="tdLabelModal">
                    <asp:Label ID="lblIMEI" runat="server" Text="IMEI: "></asp:Label>
                </td>
                <td class="tdTextModal">
                    <asp:Label ID="txtIMEI" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="height: 30px">
                <td class="tdLabelModal">
                    <asp:Label ID="lblDataUltimaAlteracao" runat="server" Text="Data Último Sincronismo: "></asp:Label>
                </td>
                <td class="tdTextModal">
                    <asp:Label ID="txtDataUltimaAlteracao" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="height: 30px">
                <td class="tdLabelModal">
                    <asp:Label ID="lblDiasSemSincronizar" runat="server" Text="Número de Dias Sem Sincronizar: "></asp:Label>
                </td>
                <td class="tdTextModal">
                    <asp:Label ID="txtDiasSemSincronizar" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="height: 30px">
                <td class="tdLabelModal">
                    <asp:Label ID="lblDataInativacao" runat="server" Text="Data de Bloqueio: "></asp:Label>
                </td>
                <td class="tdTextModal">
                    <asp:Label ID="txtDataInativacao" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="height: 30px">
                <td class="tdLabelModal">
                    <asp:Label ID="lblMotivoInativacao" runat="server" Text="Motivo do Bloqueio: "></asp:Label>
                </td>
                <td>
                    <cabtec:CABTECTextBox ID="txtMotivoInativacao" runat="server" Tipo="TEXTO" Estilo="false"
                        TextMode="MultiLine" Height="50px" />
                    <asp:RequiredFieldValidator ID="requiredMotivoInativacao" runat="server" ValidationGroup="Bloqueio"
                        SetFocusOnError="true" ControlToValidate="txtMotivoInativacao" ErrorMessage="Motivo do Bloqueio é obrigatório.">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr style="height: 20px;">
                <td colspan="2">
                </td>
            </tr>
            <tr style="height: 40px;">
                <td colspan="2" class="tdModalButtons">
                    <table class="tableButtons">
                        <tr>
                            <td class="tdButtons">
                                <cabtec:CABTECImageButton ID="btnVoltar" runat="server" Tipo="VOLTAR" OnClick="btnVoltar_Click" />
                            </td>
                            <td class="tdButtons">
                                <cabtec:CABTECImageButton ID="btnSalvar" runat="server" Tipo="SALVAR" ValidationGroup="Bloqueio"
                                    OnClick="btnSalvar_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Panel>
