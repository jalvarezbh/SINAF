<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cadastroPerfilCargo.aspx.cs" Inherits="ProjetoWeb.cadastroPerfilCargo" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="ContentPopUp" ContentPlaceHolderID="PopUpContent" runat="server">    
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <table class="tablePrincipalConteudo">
        <tr class="trTituloPageCadastro">
            <td class="tdTituloPageCadastro" align="center">
                <asp:Label ID="lblTitulo" runat="server" Text="Associar Perfil - Cargo" CssClass="tdTituloPageCadastroLabel" />
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
                                <asp:Label ID="lblPerfil" runat="server" Text="Perfil: " />
                            </td>
                            <td class="pnltdConsulta">
                                    <asp:DropDownList ID="ddlPerfil" runat="server" Width="200px" CssClass="controleDDL" >
                                </asp:DropDownList>
                            </td>
                             <td class="pnltdConsulta">
                                 </td>
                            <td class="pnltdConsulta">
                                <asp:Label ID="lblCargo" runat="server" Text="Cargo: " />
                            </td>
                            <td class="pnltdConsulta">
                                <cabtec:CABTECTextBox ID="txtCargo" runat="server" Tipo="TEXTO" Width="200px"/>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlGridConsulta" runat="server" GroupingText=" " CssClass="pnlGridConsulta"
                    ScrollBars="Auto">
                    <asp:GridView ID="gridConsulta" runat="server" CssClass="gridConsulta" AutoGenerateColumns="false"
                        AlternatingRowStyle-CssClass="gridConsultaRowAlternating" RowStyle-CssClass="gridConsultaRow"
                        DataKeyNames="IDPerfilCargo" HeaderStyle-CssClass="gridHeader" OnRowDeleting="gridConsulta_RowDeleting" 
                        AllowPaging="True" AllowSorting="True"
                        PageSize="8" OnPageIndexChanging="gridConsulta_PageIndexChanging" PagerSettings-LastPageText="Última"
                        PagerSettings-FirstPageText="Primeira" PagerStyle-HorizontalAlign="Center" PagerSettings-Mode="NumericFirstLast"
                        PagerSettings-PageButtonCount="4" PagerStyle-CssClass="gridFooter" PagerStyle-ForeColor="#223D76"
                        OnRowDataBound="gridConsulta_RowDataBound">
                        <Columns>
                            <asp:CommandField ButtonType="Image" ShowDeleteButton="true" DeleteImageUrl="~/Images/note_removeGrid.ico"
                                HeaderText="Excluir" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="IDPerfilCargo" HeaderText="IDPerfilCargo"  Visible="false" />
                            <asp:BoundField DataField="Descricao" HeaderText="Perfil" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="NomeCargo" HeaderText="Cargo" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Left"/>
                        </Columns>
                        <EmptyDataTemplate>Não existe registro.</EmptyDataTemplate>
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
                <cabtec:CABTECImageButton ID="btnSalvar" runat="server" Tipo="SALVAR" OnClick="btnSalvar_Click" />
            </td>
                <td class="tdButtons">
                <cabtec:CABTECImageButton ID="btnPesquisar" runat="server" Tipo="PESQUISAR" OnClick="btnPesquisar_Click" />
            </td>
     </tr>
    </table>
</asp:Content>

