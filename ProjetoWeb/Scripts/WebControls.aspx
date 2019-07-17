<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebControls.aspx.cs" Inherits="ProjetoWeb.Scripts.WebControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CABTEC - Script(js) Control</title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr style="height: 80px; vertical-align: top;">
                <td style="width: 200px; text-align: right;">
                    <asp:Label ID="lblPassCode" runat="server" Text="Code:" />
                </td>
                <td style="width: 400px;">
                    <asp:TextBox ID="txtPassCode" runat="server" TextMode="Password" Width="380px" />
                </td>
                <td style="width: 220px; text-align: right;vertical-align:central;padding-left:20px;" rowspan="4">
                    <table>
                        <tr style="height: 35px; vertical-align: top;">
                            <td colspan="2">
                                <asp:Button ID="btnImportCompleto" runat="server" Text="Importar Completo" Width="200px" OnClick="btnImportCompleto_Click" />
                            </td>
                        </tr>
                        <tr style="height: 35px; vertical-align: top;">
                            <td colspan="2">
                                <asp:Button ID="btnImportUsuario" runat="server" Text="Importar Usuário" Width="200px" OnClick="btnImportUsuario_Click" />
                            </td>
                        </tr>
                        <tr style="height: 35px; vertical-align: top;">
                            <td colspan="2">
                                <asp:Button ID="btnImportProfissao" runat="server" Text="Importar Profissão" Width="200px" OnClick="btnImportProfissao_Click" />
                            </td>
                        </tr>
                        <tr style="height: 35px; vertical-align: top;">
                            <td colspan="2">
                                <asp:Button ID="btnImportOrigem" runat="server" Text="Importar Origem" Width="200px" OnClick="btnImportOrigem_Click" />
                            </td>
                        </tr>
                        <tr style="height: 35px; vertical-align: top;">
                            <td colspan="2">
                                <asp:Button ID="btnImportFaixa" runat="server" Text="Importar Faixa" Width="200px" OnClick="btnImportFaixa_Click" />
                            </td>
                        </tr>
                        <tr style="height: 35px; vertical-align: top;">
                            <td colspan="2">
                                <asp:Button ID="btnExcluirEntrevista" runat="server" Text="Excluir Entrevistas" Width="200px" OnClick="btnExcluirEntrevista_Click" />
                            </td>
                        </tr>
                        <tr style="height: 35px; vertical-align: top;">
                            <td colspan="2">
                                <asp:Button ID="btnImportCorreio" runat="server" Text="Importar Correio" Width="200px" OnClick="btnImportCorreio_Click" />
                            </td>
                        </tr>
                        <tr style="height: 35px; vertical-align: top;">
                            <td colspan="2">
                                <asp:Button ID="btnExport" runat="server" Text="Exportar Completo" Width="200px" OnClick="btnExport_Click" />
                            </td>
                        </tr>                        
                         <tr style="height: 35px; vertical-align: top;">
                            <td colspan="2">
                                <asp:Button ID="btnExcluirBackups" runat="server" Text="Excluir Backup Coletor" Width="200px" OnClick="btnExcluirBackups_Click"   />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
             <tr style="height: 100px; vertical-align: top;">
                <td style="width: 600px;" colspan="2">
                    <asp:Label ID="lblMensagem" runat="server" Text="Mensagem :" />
                </td>               
            </tr>
            <tr style="height: 300px; vertical-align: top;">
                <td style="width: 200px; text-align: right;">
                    <asp:Label ID="lblScript" runat="server" Text="New Script(js) Method:" />
                </td>
                <td style="width: 400px;">
                    <asp:TextBox ID="txtScript" runat="server" TextMode="MultiLine" Height="280px" Width="380px" />
                </td>
            </tr>
            <tr style="height: 80px; vertical-align: top;">
                <td style="width: 200px; text-align: right;">
                    <asp:Button ID="btnConnect" runat="server" Text="Connect" Width="100px" OnClick="btnConnect_Click" />
                </td>
                <td style="width: 400px; text-align: right;">
                    <asp:Button ID="btnConfirmar" runat="server" Text="Executar" Width="100px" OnClick="btnConfirmar_Click" />
                </td>
            </tr>

        </table>
    </form>
</body>
</html>
