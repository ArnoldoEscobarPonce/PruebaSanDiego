<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="frmIngresoLecturas.aspx.cs" Inherits="Prueba_San_Diego.frmIngresoLecturas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <label>Numero de Contador</label>
                            <asp:TextBox ID="txtNumContador" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>Fecha Lectura</label>
                            <asp:TextBox ID="txtFechaLectura" TextMode="Date" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>Valor</label>
                            <asp:TextBox ID="txtValor" TextMode="Number" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>Observaciones</label>
                            <asp:TextBox ID="txtObservaciones" Width="350px"  runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="Grabar" runat="server" Text="Guardar" OnClick="Grabar_Click" />
                <hr />
                <asp:GridView ID="GridDatos" runat="server">
                    <Columns>
                        <asp:BoundField  DataField="IdLectura" HeaderText="#Lectura"/>
                        <asp:BoundField  DataField="NumContador" HeaderText="Num Contador"/>
                        <asp:BoundField  DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}"/>
                        <asp:BoundField  DataField="Valor" HeaderText="Valor" DataFormatString="{0:N}"/>
                        <asp:BoundField  DataField="Observaciones" HeaderText="Observaciones" />
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
    </form>
</body>
</html>
