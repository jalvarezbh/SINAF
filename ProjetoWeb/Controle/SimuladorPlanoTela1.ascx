<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SimuladorPlanoTela1.ascx.cs" Inherits="ProjetoWeb.Controle.SimuladorPlanoTela1" %>
<link href="../Styles/Principal.css" rel="stylesheet" type="text/css" />

<asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="panelModal"
    BackgroundCssClass="modalBackground" TargetControlID="buttonModal">
</asp:ModalPopupExtender>
<cabtec:CABTECButton ID="buttonModal" Text="button" runat="server" Style="visibility: hidden" />

<asp:Panel ID="panelModal" runat="server"  CssClass="panelSimulador"  ScrollBars="Auto">
      <div>
        <table style="width: 100%;">
            <tr style="height: 40px">
                <td class="tdTituloModal">
                    <asp:Label ID="lblTitulo" runat="server" Text="Simulador de Plano"></asp:Label>
                </td>
            </tr>
            <tr id="trPlanoProduto" runat="server">
                <td>
                    <asp:Panel ID="pnlProduto" runat="server" GroupingText="Produtos" CssClass="pnlSimuladorRenda">
                        <table>
                            <tr style="height: 25px;">
                                <td class="tdLabelModal" style="width: 150px;"></td>
                                <td></td>
                                <td></td>
                                <td style="text-align: right;">
                                    <asp:ImageButton ID="btnProdutoAltera" runat="server" ImageUrl="~/Images/accept20.ico" OnClick="btnProdutoAltera_Click" />
                                </td>
                            </tr>
                            <tr style="height: 20px;">
                                <td class="tdLabelModal" style="width: 150px;">
                                    <asp:Label ID="lblProdutoDefinido" runat="server" Text="Produto: "></asp:Label>
                                </td>
                                <td class="tdTextModal" style="width: 150px;">
                                    <asp:Label ID="txtProdutoDefinido" runat="server" Width="200px"></asp:Label>
                                </td>
                                <td class="tdLabelModal" style="width: 150px;">
                                    <asp:Label ID="lblProdutoAlterar" runat="server" Text="Alterar Produto: "></asp:Label>
                                </td>
                                <td class="tdTextModal" style="width: 150px;">
                                    <asp:DropDownList ID="ddlProdutoAlterar" runat="server" Width="200px"></asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr style="height: 10px;">
                <td></td>
            </tr>
            <tr id="trPlanoProtecaoRenda" runat="server" visible="false">
                <td>
                    <asp:Panel ID="pnlRenda" runat="server" GroupingText="Renda Mensal Titular" CssClass="pnlSimuladorRenda">
                        <table>
                            <tr style="height: 25px;">
                                <td class="tdLabelModal" style="width: 150px;"></td>
                                <td></td>
                                <td></td>
                                <td style="text-align: right;">
                                    <asp:ImageButton ID="btnPlanoProtecaoRendaNovo" runat="server" ImageUrl="~/Images/add20.ico" OnClick="btnRendaNovo_Click" />
                                </td>
                            </tr>
                            <tr style="height: 20px;">
                                <td class="tdLabelModal" style="width: 150px;">
                                    <asp:Label ID="lblPlanoProtecaoRendaValor" runat="server" Text="Valor da Renda: "></asp:Label></td>
                                <td class="tdTextModal" style="width: 150px;">
                                    <asp:Label ID="txtPlanoProtecaoRendaValor" runat="server"></asp:Label></td>
                                <td class="tdLabelModal" style="width: 150px;">
                                    <asp:Label ID="lblPlanoProtecaoRendaPeriodo" runat="server" Text="Período: "></asp:Label></td>
                                <td class="tdTextModal" style="width: 150px;">
                                    <asp:Label ID="txtPlanoProtecaoRendaPeriodo" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr style="height: 20px;">
                                <td class="tdLabelModal" style="width: 150px;">
                                    <asp:Label ID="lblPlanoProtecaoRendaCapital" runat="server" Text="Capital: "></asp:Label></td>
                                <td class="tdTextModal" style="width: 150px;">
                                    <asp:Label ID="txtPlanoProtecaoRendaCapital" runat="server"></asp:Label></td>
                                <td colspan="2"></td>
                            </tr>
                            <tr style="height: 20px;">
                                <td colspan="4" align="center">
                                    <asp:Label ID="lblPlanoProtecaoRendaPremio" runat="server" Text="Prêmio: " CssClass="tdLabelCenterModal"></asp:Label>
                                    <asp:Label ID="txtPlanoProtecaoRendaPremio" runat="server" CssClass="tdTextCenterModal"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table id="tblPlanoProtecaoRendaNovo" runat="server" visible="false" style="width: 100%;">
                            <tr>
                                <td align="center">
                                    <asp:Panel ID="pnlPlanoProtecaoRendaNovo" runat="server" GroupingText="Renda Mensal Titular" CssClass="pnlSimuladorSub">
                                        <table style="width: 100%;">
                                            <tr class="trSummaryPageCadastro">
                                                <td class="tdSummaryPageCadastro" colspan="4">
                                                    <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowSummary="true"
                                                        ValidationGroup="PlanoProtecaoRendaNovo" />
                                                </td>
                                            </tr>
                                            <tr style="height: 30px;">
                                                <td class="tdLabelModal" style="width: 150px;">
                                                    <asp:Label ID="lblPlanoProtecaoRendaValorNovo" runat="server" Text="Valor da Renda: "></asp:Label></td>
                                                <td class="tdTextModal" style="width: 100px;">
                                                    <asp:DropDownList ID="ddlPlanoProtecaoRendaValorNovo" runat="server" Width="100px" Enabled="false"></asp:DropDownList>
                                                </td>
                                                <td class="tdLabelModal" style="width: 100px;">
                                                    <asp:Label ID="lblPlanoProtecaoRendaPeriodoNovo" runat="server" Text="Período: "></asp:Label></td>
                                                <td class="tdTextModal" style="width: 150px;">
                                                    <asp:DropDownList ID="ddlPlanoProtecaoRendaPeriodoNovo" runat="server" Width="150px" AutoPostBack="true" OnSelectedIndexChanged="ddlPlanoProtecaoRendaPeriodoNovo_SelectedIndexChanged"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr style="height: 30px;">
                                                <td class="tdLabelModal" style="width: 150px;">
                                                    <asp:Label ID="lblPlanoProtecaoRendaCapitalNovo" runat="server" Text="Capital: "></asp:Label></td>
                                                <td class="tdTextModal" style="width: 100px;">
                                                    <asp:TextBox ID="txtPlanoProtecaoRendaCapitalNovo" runat="server" Width="100px" Enabled="false" />
                                                </td>
                                                <td colspan="2"></td>
                                            </tr>
                                            <tr style="height: 20px;">
                                                <td colspan="4" align="center">
                                                    <asp:Label ID="lblPlanoProtecaoRendaPremioNovo" runat="server" Text="Prêmio: " CssClass="tdLabelCenterModal"></asp:Label>
                                                    <asp:Label ID="txtPlanoProtecaoRendaPremioNovo" runat="server" Text="00,00" CssClass="tdTextCenterModal"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr style="height: 10px;">
                                                <td colspan="4"></td>
                                            </tr>
                                            <tr style="height: 30px;">
                                                <td colspan="4">
                                                    <table class="tableButtons">
                                                        <tr>
                                                            <td class="tdSubButtons">
                                                                <asp:ImageButton ID="btnPlanoProtecaoRendaVoltarNovo" runat="server" ImageUrl="~/Images/back28.ico" OnClick="btnPlanoProtecaoRendaVoltarNovo_Click" />
                                                            </td>
                                                            <td class="tdSubButtons">
                                                                <asp:ImageButton ID="btnPlanoProtecaoRendaSalvarNovo" runat="server" ImageUrl="~/Images/accept28.ico" OnClick="btnPlanoProtecaoRendaSalvarNovo_Click" />
                                                            </td>
                                                            <td class="tdSubButtons">
                                                                <asp:ImageButton ID="btnPlanoProtecaoRendaAtualizarNovo" runat="server" ImageUrl="~/Images/down28.ico" OnClick="btnPlanoProtecaoRendaAtualizarNovo_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr id="trPlanoProtecaoRendaEspaco" runat="server" visible="false" style="height: 10px;">
                <td></td>
            </tr>
            <tr id="trPlanoAgregados" runat="server" visible="false">
                <td>
                    <asp:Panel ID="pnlAgregados" runat="server" GroupingText="Agregados" CssClass="pnlSimuladorRenda">
                        <table>
                            <tr style="height: 25px;">
                                <td class="tdLabelModal" style="width: 150px;"></td>
                                <td></td>
                                <td></td>
                                <td style="text-align: right;">
                                    <asp:ImageButton ID="btnAgregadoNovo" runat="server" ImageUrl="~/Images/add20.ico" OnClick="btnAgregadoNovo_Click" />
                                </td>
                            </tr>
                            <tr style="height: 20px;">
                                <td class="tdLabelModal" style="width: 150px;">
                                    <asp:Label ID="lblAgregadoQuantidade" runat="server" Text="Quantidade: "></asp:Label></td>
                                <td class="tdTextModal" style="width: 150px;">
                                    <asp:Label ID="txtAgregadoQuantidade" runat="server" Text="2"></asp:Label></td>
                                <td class="tdLabelModal" style="width: 150px;"></td>
                                <td class="tdTextModal" style="width: 150px;"></td>
                            </tr>
                            <tr style="height: 20px;">
                                <td colspan="4" align="center">
                                    <asp:Label ID="lblAgregadoPremio" runat="server" Text="Prêmio: " CssClass="tdLabelCenterModal"></asp:Label>
                                    <asp:Label ID="txtAgregadoPremio" runat="server" Text="15,00" CssClass="tdTextCenterModal"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table id="tblPlanoProtecaoAgregadosNovo" runat="server" visible="false" style="width: 100%;">
                            <tr>
                                <td align="center">
                                    <asp:Panel ID="pnlPlanoProtecaoAgregadosNovo" runat="server" GroupingText="Agregados" CssClass="pnlSimuladorSub">
                                        <table style="width: 100%;">
                                            <tr class="trSummaryPageCadastro">
                                                <td class="tdSummaryPageCadastro" colspan="5">
                                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowSummary="true"
                                                        ValidationGroup="PlanoProtecaoAgregadosNovo" />
                                                </td>
                                            </tr>
                                            <tr style="height: 30px;">
                                                <td class="tdLabelModal" style="width: 130px;">
                                                    <asp:Label ID="lblPlanoProtecaoAgregadosGrauNovo" runat="server" Text="Grau de Parentesco: "></asp:Label></td>
                                                <td class="tdTextModal" style="width: 140px;">
                                                    <asp:DropDownList ID="ddlPlanoProtecaoAgregadosGrauNovo" runat="server" Width="140px"></asp:DropDownList>
                                                </td>
                                                <td class="tdLabelModal" style="width: 130px;">
                                                    <asp:Label ID="lblPlanoProtecaoAgregadosIdadeNovo" runat="server" Text="Idade: "></asp:Label></td>
                                                <td class="tdTextModal" style="width: 60px;">
                                                    <cabtec:CABTECTextBox ID="txtPlanoProtecaoAgregadosIdadeNovo" runat="server" Tipo="NUMERO" MaxLength="3" Width="60px" />
                                                </td>
                                                <td style="width: 40px;">
                                                    <asp:ImageButton ID="imgPlanoProtecaoAgregadosNovo" runat="server" ImageUrl="~/Images/add20.ico" OnClick="imgPlanoProtecaoAgregadosNovo_Click" />
                                                </td>
                                            </tr>
                                            <tr style="height: 30px;">
                                                <td colspan="5">
                                                    <asp:GridView ID="grdPlanoProtecaoAgregadosNovo" runat="server" CssClass="gridConsulta" AutoGenerateColumns="false"
                                                        AlternatingRowStyle-CssClass="gridConsultaRowAlternating" RowStyle-CssClass="gridConsultaRow"
                                                        DataKeyNames="Identificador" HeaderStyle-CssClass="gridHeader"
                                                        OnRowDeleting="grdPlanoProtecaoAgregadosNovo_RowDeleting" AllowPaging="True" AllowSorting="True"
                                                        PageSize="4" OnPageIndexChanging="grdPlanoProtecaoAgregadosNovo_PageIndexChanging" PagerSettings-LastPageText="Última"
                                                        PagerSettings-FirstPageText="Primeira" PagerStyle-HorizontalAlign="Center" PagerSettings-Mode="NumericFirstLast"
                                                        PagerSettings-PageButtonCount="4" PagerStyle-CssClass="gridFooter" PagerStyle-ForeColor="#223D76"
                                                        OnRowDataBound="grdPlanoProtecaoAgregadosNovo_RowDataBound">
                                                        <Columns>
                                                            <asp:CommandField ButtonType="Image" ShowDeleteButton="true" DeleteImageUrl="~/Images/note_removeGrid.ico"
                                                                HeaderText="Excluir" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="25px" />
                                                            <asp:BoundField DataField="GrauParentesco" HeaderText="Grau de Parentesco" ItemStyle-Width="80px" />
                                                            <asp:BoundField DataField="Idade" HeaderText="Idade" ItemStyle-Width="30px" />
                                                            <asp:BoundField DataField="Premio" HeaderText="Premio" ItemStyle-Width="40px" />
                                                        </Columns>
                                                        <EmptyDataTemplate>Não existe agregado informado.</EmptyDataTemplate>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr style="height: 20px;">
                                                <td colspan="5" align="center">
                                                    <asp:Label ID="lblPlanoProtecaoAgregadosPremioNovo" runat="server" Text="Prêmio: " CssClass="tdLabelCenterModal"></asp:Label>
                                                    <asp:Label ID="txtPlanoProtecaoAgregadosPremioNovo" runat="server" Text="00,00" CssClass="tdTextCenterModal"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr style="height: 10px;">
                                                <td colspan="5"></td>
                                            </tr>
                                            <tr style="height: 30px;">
                                                <td colspan="5">
                                                    <table class="tableButtons">
                                                        <tr>
                                                            <td class="tdSubButtons">
                                                                <asp:ImageButton ID="btnPlanoProtecaoAgregadosVoltarNovo" runat="server" ImageUrl="~/Images/back28.ico" OnClick="btnPlanoProtecaoAgregadosVoltarNovo_Click" />
                                                            </td>
                                                            <td class="tdSubButtons">
                                                                <asp:ImageButton ID="btnPlanoProtecaoAgregadosSalvarNovo" runat="server" ImageUrl="~/Images/accept28.ico" OnClick="btnPlanoProtecaoAgregadosSalvarNovo_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr style="height: 10px;">
                <td></td>
            </tr>
            <tr id="trPlanoProtecaoFuneral" runat="server" visible="false">
                <td>
                    <asp:Panel ID="pnlPlanoProtecaoFuneral" runat="server" GroupingText="AP + Funeral Familiar" CssClass="pnlSimuladorRenda">
                        <table>
                            <tr style="height: 25px;">
                                <td class="tdLabelModal" style="width: 150px;">
                                <td></td>
                                <td></td>
                                <td style="text-align: right;">
                                    <asp:ImageButton ID="btnPlanoProtecaoFuneralNovo" runat="server" ImageUrl="~/Images/add20.ico" OnClick="btnFuneralNovo_Click" />
                                </td>
                            </tr>
                            <tr style="height: 20px;">
                                <td class="tdLabelModal" style="width: 150px;">
                                    <asp:Label ID="lblPlanoProtecaoFuneralMorte" runat="server" Text="Morte Acidental: "></asp:Label></td>
                                <td class="tdTextModal" style="width: 150px;">
                                    <asp:Label ID="txtPlanoProtecaoFuneralMorte" runat="server" Text=""></asp:Label></td>
                                <td class="tdLabelModal" style="width: 150px;">
                                    <asp:Label ID="lblPlanoProtecaoFuneralIPA" runat="server" Text="Invalidez por Acidente: "></asp:Label></td>
                                <td class="tdTextModal" style="width: 150px;">
                                    <asp:Label ID="txtPlanoProtecaoFuneralIPA" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr style="height: 20px;">
                                <td class="tdLabelModal" style="width: 150px;">
                                    <asp:Label ID="lblPlanoProtecaoFuneralAssistencia" runat="server" Text="Assistência Emergencial: "></asp:Label></td>
                                <td class="tdTextModal" style="width: 150px;">
                                    <asp:Label ID="txtPlanoProtecaoFuneralAssistencia" runat="server" Text=""></asp:Label></td>
                                <td class="tdLabelModal" style="width: 150px;">
                                    <asp:Label ID="lblPlanoProtecaoFuneralDescricao" runat="server" Text="Funeral: "></asp:Label></td>
                                <td class="tdTextModal" style="width: 150px;">
                                    <asp:Label ID="txtPlanoProtecaoFuneralDescricao" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr style="height: 20px;">
                                <td colspan="4" align="center">
                                    <asp:Label ID="lblPlanoProtecaoFuneralPremio" runat="server" Text="Prêmio: " CssClass="tdLabelCenterModal"></asp:Label>
                                    <asp:Label ID="txtPlanoProtecaoFuneralPremio" runat="server" Text="" CssClass="tdTextCenterModal"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table id="tblPlanoProtecaoFuneralNovo" runat="server" visible="false" style="width: 100%;">
                            <tr>
                                <td align="center">
                                    <asp:Panel ID="pnlPlanoProtecaoFuneralNovo" runat="server" GroupingText="AP + Funeral Familiar - Alteração" CssClass="pnlSimuladorSub">
                                        <table style="width: 100%;">
                                            <tr class="trSummaryPageCadastro">
                                                <td class="tdSummaryPageCadastro" colspan="4">
                                                    <asp:ValidationSummary ID="ValidationSummaryPlanoProtecaoFuneralNovo" runat="server" ShowSummary="true"
                                                        ValidationGroup="PlanoProtecaoFuneralNovo" />
                                                </td>
                                            </tr>
                                            <tr style="height: 30px;">
                                                <td class="tdLabelModal" style="width: 150px;">
                                                    <asp:Label ID="lblPlanoProtecaoFuneralMorteNovo" runat="server" Text="Morte Acidental: "></asp:Label></td>
                                                <td class="tdTextModal" style="width: 100px;">
                                                    <asp:DropDownList ID="ddlPlanoProtecaoFuneralMorteNovo" runat="server" Width="100px" AutoPostBack="True" OnSelectedIndexChanged="ddlPlanoProtecaoFuneralMorteNovo_SelectedIndexChanged"></asp:DropDownList>
                                                </td>
                                                <td class="tdLabelModal" style="width: 150px;">
                                                    <asp:Label ID="lblPlanoProtecaoFuneralIPANovo" runat="server" Text="Invalidez por Acidente: "></asp:Label></td>
                                                <td class="tdTextModal" style="width: 100px;">
                                                    <asp:DropDownList ID="ddlPlanoProtecaoFuneralIPANovo" runat="server" Width="100px" AutoPostBack="True" OnSelectedIndexChanged="ddlPlanoProtecaoFuneralIPANovo_SelectedIndexChanged"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr style="height: 30px;">
                                                <td class="tdLabelModal" style="width: 150px;">
                                                    <asp:Label ID="lblPlanoProtecaoFuneralAssistenciaNovo" runat="server" Text="Assistência Emergencial: "></asp:Label></td>
                                                <td class="tdTextModal" style="width: 100px;">
                                                    <asp:DropDownList ID="ddlPlanoProtecaoFuneralAssistenciaNovo" runat="server" Width="100px"></asp:DropDownList>
                                                </td>

                                                <td class="tdLabelModal" style="width: 150px;">
                                                    <asp:Label ID="lblPlanoProtecaoFuneralCategoriaNovo" runat="server" Text="Funeral: "></asp:Label></td>
                                                <td class="tdTextModal" style="width: 100px;">
                                                    <asp:DropDownList ID="ddlPlanoProtecaoFuneralCategoriaNovo" runat="server" Width="100px"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr style="height: 20px;">
                                                <td colspan="4" align="center">
                                                    <asp:Label ID="lblPlanoProtecaoFuneralPremioNovo" runat="server" Text="Prêmio: " CssClass="tdLabelCenterModal"></asp:Label>
                                                    <asp:Label ID="txtPlanoProtecaoFuneralPremioNovo" runat="server" Text="00,00" CssClass="tdTextCenterModal"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr style="height: 10px;">
                                                <td colspan="4"></td>
                                            </tr>
                                            <tr style="height: 30px;">
                                                <td colspan="4">
                                                    <table class="tableButtons">
                                                        <tr>
                                                            <td class="tdSubButtons">
                                                                <asp:ImageButton ID="btnPlanoProtecaoFuneralVoltarNovo" runat="server" ImageUrl="~/Images/back28.ico" OnClick="btnPlanoProtecaoFuneralVoltarNovo_Click" />
                                                            </td>
                                                            <td class="tdSubButtons">
                                                                <asp:ImageButton ID="btnPlanoProtecaoFuneralSalvarNovo" runat="server" ImageUrl="~/Images/accept28.ico" OnClick="btnPlanoProtecaoFuneralSalvarNovo_Click" />
                                                            </td>
                                                            <td class="tdSubButtons">
                                                                <asp:ImageButton ID="btnPlanoProtecaoFuneralAtualizarNovo" runat="server" ImageUrl="~/Images/down28.ico" OnClick="btnPlanoProtecaoFuneralAtualizarNovo_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr id="trPlanoCasalFuneral" runat="server" visible="false">
                <td>
                    <asp:Panel ID="pnlPlanoCasalFuneral" runat="server" GroupingText="Sênior Casal" CssClass="pnlSimuladorRenda">
                        <table>
                            <tr style="height: 25px;">
                                <td class="tdLabelModal" style="width: 150px;">
                                <td></td>
                                <td></td>
                                <td style="text-align: right;">
                                    <asp:ImageButton ID="btnPlanoCasalFuneralNovo" runat="server" ImageUrl="~/Images/add20.ico" OnClick="btnPlanoCasalFuneralNovo_Click" />
                                </td>
                            </tr>
                            <tr style="height: 20px;">
                                <td class="tdLabelModal" style="width: 150px;">
                                    <asp:Label ID="lblPlanoCasalFuneralPrincipal" runat="server" Text="Morte Principal: "></asp:Label></td>
                                <td class="tdTextModal" style="width: 150px;">
                                    <asp:Label ID="txtPlanoCasalFuneralPrincipal" runat="server" Text=""></asp:Label></td>
                                <td class="tdLabelModal" style="width: 150px;">
                                    <asp:Label ID="lblPlanoCasalFuneralConjuge" runat="server" Text="Morte Cônjuge: "></asp:Label></td>
                                <td class="tdTextModal" style="width: 150px;">
                                    <asp:Label ID="txtPlanoCasalFuneralConjuge" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr style="height: 20px;">
                                <td class="tdLabelModal" style="width: 150px;">
                                    <asp:Label ID="lblPlanoCasalFuneralCategoria" runat="server" Text="Funeral: "></asp:Label></td>
                                <td class="tdTextModal" style="width: 150px;">
                                    <asp:Label ID="txtPlanoCasalFuneralCategoria" runat="server" Text=""></asp:Label></td>
                                <td class="tdLabelModal" style="width: 150px;"></td>
                                <td class="tdTextModal" style="width: 150px;"></td>
                            </tr>
                            <tr style="height: 20px;">
                                <td colspan="4" align="center">
                                    <asp:Label ID="lblPlanoCasalFuneralPremio" runat="server" Text="Prêmio: " CssClass="tdLabelCenterModal"></asp:Label>
                                    <asp:Label ID="txtPlanoCasalFuneralPremio" runat="server" Text="" CssClass="tdTextCenterModal"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table id="tblPlanoCasalFuneralNovo" runat="server" visible="false" style="width: 100%;">
                            <tr>
                                <td align="center">
                                    <asp:Panel ID="pnlPlanoCasalFuneralNovo" runat="server" GroupingText="Sênior Casal - Alteração" CssClass="pnlSimuladorSub">
                                        <table style="width: 100%;">
                                            <tr class="trSummaryPageCadastro">
                                                <td class="tdSummaryPageCadastro" colspan="4">
                                                    <asp:ValidationSummary ID="ValidationSummaryPlanoCasalFuneralNovo" runat="server" ShowSummary="true"
                                                        ValidationGroup="PlanoCasalFuneralNovo" />
                                                </td>
                                            </tr>
                                            <tr style="height: 30px;">
                                                <td class="tdLabelModal" style="width: 150px;">
                                                    <asp:Label ID="lblPlanoCasalFuneralPrincipalNovo" runat="server" Text="Morte Principal: "></asp:Label></td>
                                                <td class="tdTextModal" style="width: 100px;">
                                                    <asp:DropDownList ID="ddlPlanoCasalFuneralPrincipalNovo" runat="server" Width="100px" AutoPostBack="True" OnSelectedIndexChanged="ddlPlanoCasalFuneralPrincipalNovo_SelectedIndexChanged"></asp:DropDownList>
                                                </td>
                                                <td class="tdLabelModal" style="width: 150px;">
                                                    <asp:Label ID="lblPlanoCasalFuneralConjugeNovo" runat="server" Text="Morte Cônjuge: "></asp:Label></td>
                                                <td class="tdTextModal" style="width: 100px;">
                                                    <asp:DropDownList ID="ddlPlanoCasalFuneralConjugeNovo" runat="server" Width="100px" AutoPostBack="True" OnSelectedIndexChanged="ddlPlanoCasalFuneralConjugeNovo_SelectedIndexChanged"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr style="height: 30px;">
                                                <td class="tdLabelModal" style="width: 150px;">
                                                    <asp:Label ID="lblPlanoCasalFuneralCategoriaNovo" runat="server" Text="Funeral: "></asp:Label></td>
                                                <td class="tdTextModal" style="width: 100px;">
                                                    <asp:DropDownList ID="ddlPlanoCasalFuneralCategoriaNovo" runat="server" Width="100px"></asp:DropDownList>
                                                </td>

                                                <td class="tdLabelModal" style="width: 150px;"></td>
                                                <td class="tdTextModal" style="width: 100px;"></td>
                                            </tr>
                                            <tr style="height: 20px;">
                                                <td colspan="4" align="center">
                                                    <asp:Label ID="lblPlanoCasalFuneralPremioNovo" runat="server" Text="Prêmio: " CssClass="tdLabelCenterModal"></asp:Label>
                                                    <asp:Label ID="txtPlanoCasalFuneralPremioNovo" runat="server" Text="00,00" CssClass="tdTextCenterModal"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr style="height: 10px;">
                                                <td colspan="4"></td>
                                            </tr>
                                            <tr style="height: 30px;">
                                                <td colspan="4">
                                                    <table class="tableButtons">
                                                        <tr>
                                                            <td class="tdSubButtons">
                                                                <asp:ImageButton ID="btnPlanoCasalFuneralVoltarNovo" runat="server" ImageUrl="~/Images/back28.ico" OnClick="btnPlanoCasalFuneralVoltarNovo_Click" />
                                                            </td>
                                                            <td class="tdSubButtons">
                                                                <asp:ImageButton ID="btnPlanoCasalFuneralSalvarNovo" runat="server" ImageUrl="~/Images/accept28.ico" OnClick="btnPlanoCasalFuneralSalvarNovo_Click" />
                                                            </td>
                                                            <td class="tdSubButtons">
                                                                <asp:ImageButton ID="btnPlanoCasalFuneralAtualizarNovo" runat="server" ImageUrl="~/Images/down28.ico" OnClick="btnPlanoCasalFuneralAtualizarNovo_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr id="trPlanoSeniorFuneral" runat="server" visible="false">
                <td>
                    <asp:Panel ID="pnlPlanoSeniorFuneral" runat="server" GroupingText="Sênior" CssClass="pnlSimuladorRenda">
                        <table>
                            <tr style="height: 25px;">
                                <td class="tdLabelModal" style="width: 150px;">
                                <td></td>
                                <td></td>
                                <td style="text-align: right;">
                                    <asp:ImageButton ID="btnPlanoSeniorFuneralNovo" runat="server" ImageUrl="~/Images/add20.ico" OnClick="btnPlanoSeniorFuneralNovo_Click" />
                                </td>
                            </tr>
                            <tr style="height: 20px;">
                                <td class="tdLabelModal" style="width: 150px;">
                                    <asp:Label ID="lblPlanoSeniorFuneralPrincipal" runat="server" Text="Morte : "></asp:Label></td>
                                <td class="tdTextModal" style="width: 150px;">
                                    <asp:Label ID="txtPlanoSeniorFuneralPrincipal" runat="server" Text=""></asp:Label></td>
                                <td class="tdLabelModal" style="width: 150px;">
                                    <asp:Label ID="lblPlanoSeniorFuneralCategoria" runat="server" Text="Funeral: "></asp:Label></td>
                                <td class="tdTextModal" style="width: 150px;">
                                    <asp:Label ID="txtPlanoSeniorFuneralCategoria" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr style="height: 20px;">
                                <td colspan="4" align="center">
                                    <asp:Label ID="lblPlanoSeniorFuneralPremio" runat="server" Text="Prêmio: " CssClass="tdLabelCenterModal"></asp:Label>
                                    <asp:Label ID="txtPlanoSeniorFuneralPremio" runat="server" Text="" CssClass="tdTextCenterModal"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table id="tblPlanoSeniorFuneralNovo" runat="server" visible="false" style="width: 100%;">
                            <tr>
                                <td align="center">
                                    <asp:Panel ID="pnlPlanoSeniorFuneralNovo" runat="server" GroupingText="Sênior - Alteração" CssClass="pnlSimuladorSub">
                                        <table style="width: 100%;">
                                            <tr class="trSummaryPageCadastro">
                                                <td class="tdSummaryPageCadastro" colspan="4">
                                                    <asp:ValidationSummary ID="ValidationSummaryPlanoSeniorFuneralNovo" runat="server" ShowSummary="true"
                                                        ValidationGroup="PlanoSeniorFuneralNovo" />
                                                </td>
                                            </tr>
                                            <tr style="height: 30px;">
                                                <td class="tdLabelModal" style="width: 150px;">
                                                    <asp:Label ID="lblPlanoSeniorFuneralPrincipalNovo" runat="server" Text="Morte : "></asp:Label></td>
                                                <td class="tdTextModal" style="width: 100px;">
                                                    <asp:DropDownList ID="ddlPlanoSeniorFuneralPrincipalNovo" runat="server" Width="100px"></asp:DropDownList>
                                                </td>
                                                <td class="tdLabelModal" style="width: 150px;">
                                                    <asp:Label ID="lblPlanoSeniorFuneralCategoriaNovo" runat="server" Text="Funeral: "></asp:Label></td>
                                                <td class="tdTextModal" style="width: 100px;">
                                                    <asp:DropDownList ID="ddlPlanoSeniorFuneralCategoriaNovo" runat="server" Width="100px"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr style="height: 20px;">
                                                <td colspan="4" align="center">
                                                    <asp:Label ID="lblPlanoSeniorFuneralPremioNovo" runat="server" Text="Prêmio: " CssClass="tdLabelCenterModal"></asp:Label>
                                                    <asp:Label ID="txtPlanoSeniorFuneralPremioNovo" runat="server" Text="00,00" CssClass="tdTextCenterModal"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr style="height: 10px;">
                                                <td colspan="4"></td>
                                            </tr>
                                            <tr style="height: 30px;">
                                                <td colspan="4">
                                                    <table class="tableButtons">
                                                        <tr>
                                                            <td class="tdSubButtons">
                                                                <asp:ImageButton ID="btnPlanoSeniorFuneralVoltarNovo" runat="server" ImageUrl="~/Images/back28.ico" OnClick="btnPlanoSeniorFuneralVoltarNovo_Click" />
                                                            </td>
                                                            <td class="tdSubButtons">
                                                                <asp:ImageButton ID="btnPlanoSeniorFuneralSalvarNovo" runat="server" ImageUrl="~/Images/accept28.ico" OnClick="btnPlanoSeniorFuneralSalvarNovo_Click" />
                                                            </td>
                                                            <td class="tdSubButtons">
                                                                <asp:ImageButton ID="btnPlanoSeniorFuneralAtualizarNovo" runat="server" ImageUrl="~/Images/down28.ico" OnClick="btnPlanoSeniorFuneralAtualizarNovo_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr style="height: 10px;">
                <td></td>
            </tr>
            <tr id="trPlanoValorTotal" runat="server">
                <td>
                    <asp:Panel ID="pnlValorTotal" runat="server" GroupingText="Prêmio" CssClass="pnlSimuladorRenda">
                        <table>
                            <tr style="height: 20px;">
                                <td class="tdLabelModal" style="width: 150px;">
                                    <asp:Label ID="lblValorTotalPremio" runat="server" Text="Valor do Prêmio Total: "></asp:Label>
                                </td>
                                <td class="tdTextModal" style="width: 150px;">
                                    <asp:Label ID="txtValorTotalPremio" runat="server"></asp:Label>
                                </td>
                                <td class="tdLabelModal" style="width: 150px;"></td>
                                <td class="tdTextModal" style="width: 150px;"></td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr style="height: 10px;">
                <td></td>
            </tr>
            <tr style="height: 40px;">
                <td class="tdModalButtons">
                    <table class="tableButtons">
                        <tr>
                            <td class="tdButtons">
                                <cabtec:CABTECImageButton ID="btnVoltar" runat="server" Tipo="VOLTAR" OnClick="btnVoltar_Click" />
                            </td>
                            <td class="tdButtons">
                                <%--  <cabtec:CABTECImageButton ID="btnSalvar" runat="server" Tipo="SALVAR" OnClick="btnSalvar_Click" />--%>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Panel>





