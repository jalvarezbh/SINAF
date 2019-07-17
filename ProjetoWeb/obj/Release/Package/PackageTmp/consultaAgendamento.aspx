<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="consultaAgendamento.aspx.cs" Inherits="ProjetoWeb.consultaAgendamento" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="ContentPopUp" ContentPlaceHolderID="PopUpContent" runat="server">    
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <table class="tablePrincipalConteudo">
        <tr class="trTituloPageCadastro">
            <td class="tdTituloPageCadastro" align="center">
                <asp:Label ID="lblTitulo" runat="server" Text="Consultar Agendamento" CssClass="tdTituloPageCadastroLabel" />
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
                <asp:Panel ID="pnlCampoConsulta" runat="server" GroupingText=" " CssClass="pnlConsulta">
                    <table>
                        <tr style="height: 30px">
                            <td class="pnltdConsulta">
                                <asp:Label ID="lblAtendente" runat="server" Text="Cadastrado por: " />
                            </td>
                            <td class="pnltdConsulta">
                                <cabtec:CABTECTextBox ID="txtAtendente" runat="server" Tipo="TEXTO" />
                            </td>
                             <td class="pnltdConsulta">
                                 </td>
                            <td class="pnltdConsulta">
                                <asp:Label ID="lblVendedor" runat="server" Text="Vendedor Responsável: " />
                            </td>
                            <td class="pnltdConsulta">
                                <cabtec:CABTECTextBox ID="txtVendedor" runat="server" Tipo="TEXTO" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlGridConsulta" runat="server" GroupingText=" " CssClass="pnlGridConsulta"
                    ScrollBars="Auto">
                    <asp:GridView ID="gridConsulta" runat="server" CssClass="gridConsulta" AutoGenerateColumns="false"
                        AlternatingRowStyle-CssClass="gridConsultaRowAlternating" RowStyle-CssClass="gridConsultaRow"
                        DataKeyNames="IDAgendamento" HeaderStyle-CssClass="gridHeader" OnRowCommand="gridConsulta_RowCommand"
                        OnRowDeleting="gridConsulta_RowDeleting" AllowPaging="True" AllowSorting="True"
                        PageSize="8" OnPageIndexChanging="gridConsulta_PageIndexChanging" PagerSettings-LastPageText="Última"
                        PagerSettings-FirstPageText="Primeira" PagerStyle-HorizontalAlign="Center" PagerSettings-Mode="NumericFirstLast"
                        PagerSettings-PageButtonCount="4" PagerStyle-CssClass="gridFooter" PagerStyle-ForeColor="#223D76"
                        OnRowDataBound="gridConsulta_RowDataBound">
                        <Columns>
                            <asp:CommandField ButtonType="Image" ShowSelectButton="true" SelectImageUrl="~/Images/note_editGrid.ico"
                                HeaderText="Editar" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="25px" />
                            <asp:CommandField ButtonType="Image" ShowDeleteButton="true" DeleteImageUrl="~/Images/note_removeGrid.ico"
                                HeaderText="Excluir" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="25px" />
                            <asp:BoundField DataField="IDAgendamento" HeaderText="IDAgendamento"  Visible="false" />
                            <asp:BoundField DataField="Nome" HeaderText="Cliente" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="Telefone" HeaderText="Telefone" ItemStyle-Width="40px" />
                            <asp:BoundField DataField="NomeUsuarioAgendamento" HeaderText="Cadastrado por" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Left"/>
                            <asp:TemplateField HeaderText="Vendedor Responsável" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlVendedor" runat="server" ></asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
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
                <cabtec:CABTECImageButton ID="btnSalvar" runat="server" Tipo="SALVAR" OnClick="btnSalvar_Click" />
            </td>
            <td class="tdButtons">
                <cabtec:CABTECImageButton ID="btnPesquisar" runat="server" Tipo="PESQUISAR" OnClick="btnPesquisar_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
