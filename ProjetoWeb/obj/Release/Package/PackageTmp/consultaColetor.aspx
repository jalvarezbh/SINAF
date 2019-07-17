<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="consultaColetor.aspx.cs" Inherits="ProjetoWeb.consultaColetor" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="ContentPopUp" ContentPlaceHolderID="PopUpContent" runat="server">    
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <table class="tablePrincipalConteudo">
        <tr class="trTituloPageCadastro">
            <td class="tdTituloPageCadastro" align="center">
                <asp:Label ID="lblTitulo" runat="server" Text="Consultar Coletor" CssClass="tdTituloPageCadastroLabel" />
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
                                <asp:Label ID="lblNumeroSerie" runat="server" Text="Número de Série: " />
                            </td>
                            <td class="pnltdConsulta">
                                <cabtec:CABTECTextBox ID="txtNumeroSerie" runat="server" Tipo="TEXTO" />
                            </td>
                            <td class="pnltdConsulta">
                                <asp:Label ID="lblIMEI" runat="server" Text="IMEI: " />
                            </td>
                            <td class="pnltdConsulta">
                                <cabtec:CABTECTextBox ID="txtIMEI" runat="server" Tipo="TEXTO" />
                            </td>
                            <td class="pnltdConsulta">
                                <asp:Label ID="lblAtivo" runat="server" Text="Ativo: " />
                            </td>
                            <td class="pnltdConsulta">
                                <asp:RadioButton ID="rdbAtivoSim" runat="server" Text="Sim" GroupName="Ativo" />
                                <asp:RadioButton ID="rdbAtivoNao" runat="server" Text="Não" GroupName="Ativo" />
                                <asp:RadioButton ID="rdbAtivoTodos" runat="server" Text="Todos" GroupName="Ativo"
                                    Checked="true" />
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <td class="pnltdConsulta">
                                <asp:Label ID="lblFabricante" runat="server" Text="Fabricante: " />
                            </td>
                            <td class="pnltdConsulta">
                                <cabtec:CABTECTextBox ID="txtFabricante" runat="server" Tipo="TEXTO" />
                            </td>
                            <td class="pnltdConsulta">
                                <asp:Label ID="lblModelo" runat="server" Text="Modelo: " />
                            </td>
                            <td class="pnltdConsulta">
                                <cabtec:CABTECTextBox ID="txtModelo" runat="server" Tipo="TEXTO" />
                            </td>
                            <td class="pnltdConsulta">
                                <asp:Label ID="lblUsoBackup" runat="server" Text="Backup: " />
                            </td>
                            <td class="pnltdConsulta">
                                <asp:RadioButton ID="rdbUsoBackupSim" runat="server" Text="Sim" GroupName="UsoBackup" />
                                <asp:RadioButton ID="rdbUsoBackupNao" runat="server" Text="Não" GroupName="UsoBackup" />
                                <asp:RadioButton ID="rdbUsoBackupTodos" runat="server" Text="Todos" GroupName="UsoBackup"
                                    Checked="true" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlGridConsulta" runat="server" GroupingText=" " CssClass="pnlGridConsulta"
                    ScrollBars="Auto">
                    <asp:GridView ID="gridConsulta" runat="server" CssClass="gridConsulta" AutoGenerateColumns="false"
                        AlternatingRowStyle-CssClass="gridConsultaRowAlternating" RowStyle-CssClass="gridConsultaRow"
                        DataKeyNames="IDColetor" HeaderStyle-CssClass="gridHeader" OnRowCommand="gridConsulta_RowCommand"
                        OnRowDeleting="gridConsulta_RowDeleting" AllowPaging="True" AllowSorting="True"
                        PageSize="8" OnPageIndexChanging="gridConsulta_PageIndexChanging" PagerSettings-LastPageText="Última"
                        PagerSettings-FirstPageText="Primeira" PagerStyle-HorizontalAlign="Center" PagerSettings-Mode="NumericFirstLast"
                        PagerSettings-PageButtonCount="4" PagerStyle-CssClass="gridFooter" PagerStyle-ForeColor="#223D76"
                        OnRowDataBound="gridConsulta_RowDataBound" >
                        <Columns>
                            <asp:CommandField ButtonType="Image" ShowSelectButton="true" SelectImageUrl="~/Images/note_editGrid.ico"
                                HeaderText="Editar" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="25px" />
                            <asp:CommandField ButtonType="Image" ShowDeleteButton="true" DeleteImageUrl="~/Images/note_removeGrid.ico"
                                HeaderText="Excluir" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="25px" />
                            <asp:BoundField DataField="NumeroSerie" HeaderText="Número de Série" ItemStyle-Width="60px" />
                            <asp:BoundField DataField="IMEI" HeaderText="IMEI" ItemStyle-Width="60px" />
                            <asp:BoundField DataField="Fabricante" HeaderText="Fabricante" ItemStyle-Width="70px" />
                            <asp:BoundField DataField="Modelo" HeaderText="Modelo" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="GridAtivo" HeaderText="Ativo" ItemStyle-Width="25px" />
                            <asp:BoundField DataField="GridUsoBackup" HeaderText="Backup" ItemStyle-Width="25px" />
                        </Columns>
                        <EmptyDataTemplate>Não existe registro para o filtro informado.</EmptyDataTemplate>
                    </asp:GridView>
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
                <cabtec:CABTECImageButton ID="btnNovo" runat="server" Tipo="ADICIONAR" OnClick="btnNovo_Click" />
            </td>
            <td class="tdButtons">
                <cabtec:CABTECImageButton ID="btnPesquisar" runat="server" Tipo="PESQUISAR" OnClick="btnPesquisar_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
