<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="simuladorPlano.aspx.cs" Inherits="ProjetoWeb.simuladorPlano" %>

<%@ Register Src="~/Controle/SimuladorPlanoTela1.ascx" TagName="SimuladorTela1" TagPrefix="cabtec" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="ContentPopUp" ContentPlaceHolderID="PopUpContent" runat="server">
       <cabtec:SimuladorTela1 ID="SimuladorTela1" runat="server" />
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <table class="tablePrincipalConteudo">
        <tr class="trTituloPageCadastro">
            <td class="tdTituloPageCadastro" align="center">
                <asp:Label ID="lblTitulo" runat="server" Text="Simulador de Plano" CssClass="tdTituloPageCadastroLabel" />
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
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="true" ValidationGroup="Valida" />
            </td>
        </tr>
        <tr class="trConteudoPageCadastro">
            <td>
                <asp:Panel ID="pnlPerguntas" runat="server" GroupingText="Pergunta" CssClass="pnlCadastroSimulador">
                    <table>
                        <tr style="height: 30px">
                            <td align="left" width="450px" style="padding-left: 20px">
                                <asp:Label ID="lblIdade" runat="server" Text="Faixa Etária Titular: " />
                            </td>
                            <td align="left" width="450px" style="padding-left: 20px">
                                <asp:Label ID="lblFaixaConjuge" runat="server" Text="Faixa Etária Cônjuge: " />
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <td align="left" width="450px">
                                <table>
                                    <tr>
                                        <td align="left" width="110px" style="padding-left: 20px">
                                            <asp:RadioButton ID="rdbTitular18" runat="server" Text="18 - 30" GroupName="EtariaPrincipal" />
                                        </td>
                                        <td align="left" width="110px" style="padding-left: 20px">
                                            <asp:RadioButton ID="rdbTitular46" runat="server" Text="46 - 50" GroupName="EtariaPrincipal" />
                                        </td>
                                        <td align="left" width="110px" style="padding-left: 20px">
                                            <asp:RadioButton ID="rdbTitular61" runat="server" Text="61 - 65" GroupName="EtariaPrincipal" />
                                        </td>
                                        <td align="left" width="110px" style="padding-left: 20px">
                                            <asp:RadioButton ID="rdbTitular76" runat="server" Text="76 - 80" GroupName="EtariaPrincipal" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" width="110px" style="padding-left: 20px">
                                            <asp:RadioButton ID="rdbTitular31" runat="server" Text="31 - 40" GroupName="EtariaPrincipal" />
                                        </td>
                                        <td align="left" width="110px" style="padding-left: 20px">
                                            <asp:RadioButton ID="rdbTitular51" runat="server" Text="51 - 55" GroupName="EtariaPrincipal" />
                                        </td>
                                        <td align="left" width="110px" style="padding-left: 20px">
                                            <asp:RadioButton ID="rdbTitular66" runat="server" Text="66 - 70" GroupName="EtariaPrincipal" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" width="110px" style="padding-left: 20px">
                                            <asp:RadioButton ID="rdbTitular41" runat="server" Text="41 - 45" GroupName="EtariaPrincipal" />
                                        </td>
                                        <td align="left" width="110px" style="padding-left: 20px">
                                            <asp:RadioButton ID="rdbTitular56" runat="server" Text="56 - 60" GroupName="EtariaPrincipal" />
                                        </td>
                                        <td align="left" width="110px" style="padding-left: 20px">
                                            <asp:RadioButton ID="rdbTitular71" runat="server" Text="71 - 75" GroupName="EtariaPrincipal" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td align="left" width="450px">
                                <table>
                                    <tr>
                                        <td align="left" width="110px" style="padding-left: 20px">
                                            <asp:RadioButton ID="rdbConjuge18" runat="server" Text="18 - 30" GroupName="EtariaConjuge" />
                                        </td>
                                        <td align="left" width="110px" style="padding-left: 20px">
                                            <asp:RadioButton ID="rdbConjuge46" runat="server" Text="46 - 50" GroupName="EtariaConjuge" />
                                        </td>
                                        <td align="left" width="110px" style="padding-left: 20px">
                                            <asp:RadioButton ID="rdbConjuge61" runat="server" Text="61 - 65" GroupName="EtariaConjuge" />
                                        </td>
                                        <td align="left" width="110px" style="padding-left: 20px">
                                            <asp:RadioButton ID="rdbConjuge76" runat="server" Text="76 - 80" GroupName="EtariaConjuge" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" width="110px" style="padding-left: 20px">
                                            <asp:RadioButton ID="rdbConjuge31" runat="server" Text="31 - 40" GroupName="EtariaConjuge" />
                                        </td>
                                        <td align="left" width="110px" style="padding-left: 20px">
                                            <asp:RadioButton ID="rdbConjuge51" runat="server" Text="51 - 55" GroupName="EtariaConjuge" />
                                        </td>
                                        <td align="left" width="110px" style="padding-left: 20px">
                                            <asp:RadioButton ID="rdbConjuge66" runat="server" Text="66 - 70" GroupName="EtariaConjuge" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" width="110px" style="padding-left: 20px">
                                            <asp:RadioButton ID="rdbConjuge41" runat="server" Text="41 - 45" GroupName="EtariaConjuge" />
                                        </td>
                                        <td align="left" width="110px" style="padding-left: 20px">
                                            <asp:RadioButton ID="rdbConjuge56" runat="server" Text="56 - 60" GroupName="EtariaConjuge" />
                                        </td>
                                        <td align="left" width="110px" style="padding-left: 20px">
                                            <asp:RadioButton ID="rdbConjuge71" runat="server" Text="71 - 75" GroupName="EtariaConjuge" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <td align="left" width="900px" colspan="2" style="padding-left: 20px">
                                <asp:Label ID="lblPergunta2" runat="server" Text="Somando os salários de todas as pessoas que ajudam na despesa da casa, qual é a faixa de renda da sua família? " />
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <td align="left" width="900px" colspan="2">
                                <table>
                                    <tr>
                                        <td align="left" width="300px" style="padding-left: 20px">
                                            <asp:RadioButton ID="rdbPergunta2_15" runat="server" Text="Até R$ 800 (R$15,00)" GroupName="Pergunta2" />
                                        </td>
                                        <td align="left" width="300px" style="padding-left: 20px">
                                            <asp:RadioButton ID="rdbPergunta2_30" runat="server" Text="R$ 1.201 até R$ 1.400 (R$ 30,00)" GroupName="Pergunta2" />
                                        </td>
                                        <td align="left" width="300px" style="padding-left: 20px">
                                            <asp:RadioButton ID="rdbPergunta2_50" runat="server" Text="R$ 2.001 até R$ 2.500 (R$ 50,00)" GroupName="Pergunta2" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" width="300px" style="padding-left: 20px">
                                            <asp:RadioButton ID="rdbPergunta2_20" runat="server" Text="R$ 801 até R$ 1.000 (R$ 20,00)" GroupName="Pergunta2" />
                                        </td>
                                        <td align="left" width="300px" style="padding-left: 20px">
                                            <asp:RadioButton ID="rdbPergunta2_35" runat="server" Text="R$ 1.401 até R$ 1.600 (R$ 35,00)" GroupName="Pergunta2" />
                                        </td>
                                        <td align="left" width="300px" style="padding-left: 20px">
                                            <asp:RadioButton ID="rdbPergunta2_60" runat="server" Text="Acima de R$ 2.501 (R$ 60,00)" GroupName="Pergunta2" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" width="300px" style="padding-left: 20px">
                                            <asp:RadioButton ID="rdbPergunta2_25" runat="server" Text="R$ 1.001 até R$ 1.200 (R$ 25,00)" GroupName="Pergunta2" />
                                        </td>
                                        <td align="left" width="300px" style="padding-left: 20px">
                                            <asp:RadioButton ID="rdbPergunta2_40" runat="server" Text="R$ 1.601 até R$ 2.000 (R$ 40,00)" GroupName="Pergunta2" />
                                        </td>
                                        <td align="left" width="300px" style="padding-left: 20px">
                                            <asp:RadioButton ID="rdbPergunta2_00" runat="server" Text="Não quis informar" GroupName="Pergunta2" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <td align="left" width="900px" colspan="2" style="padding-left: 20px">
                                <asp:Label ID="lblPergunta7" runat="server" Text="Até quanto você está disposto a pagar para isso? " />
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <td align="left" width="900px" colspan="2">
                                <table>
                                    <tr>
                                        <td align="left" width="200px" style="padding-left: 20px">
                                            <asp:RadioButton ID="rdbPergunta7_15" runat="server" Text="R$15,00" GroupName="Pergunta7" />
                                        </td>
                                        <td align="left" width="200px" style="padding-left: 20px">
                                            <asp:RadioButton ID="rdbPergunta7_25" runat="server" Text="R$ 25,00" GroupName="Pergunta7" />
                                        </td>
                                        <td align="left" width="200px" style="padding-left: 20px">
                                            <asp:RadioButton ID="rdbPergunta7_35" runat="server" Text="R$ 35,00" GroupName="Pergunta7" />
                                        </td>
                                        <td align="left" width="200px" style="padding-left: 20px">
                                            <asp:RadioButton ID="rdbPergunta7_50" runat="server" Text="R$ 50,00" GroupName="Pergunta7" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" width="200px" style="padding-left: 20px">
                                            <asp:RadioButton ID="rdbPergunta7_20" runat="server" Text="R$ 20,00" GroupName="Pergunta7" />
                                        </td>
                                        <td align="left" width="200px" style="padding-left: 20px">
                                            <asp:RadioButton ID="rdbPergunta7_30" runat="server" Text="R$ 30,00" GroupName="Pergunta7" />
                                        </td>
                                        <td align="left" width="200px" style="padding-left: 20px">
                                            <asp:RadioButton ID="rdbPergunta7_40" runat="server" Text="R$ 40,00" GroupName="Pergunta7" />
                                        </td>
                                        <td align="left" width="200px" style="padding-left: 20px">
                                            <asp:RadioButton ID="rdbPergunta7_60" runat="server" Text="R$ 60,00" GroupName="Pergunta7" />
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
