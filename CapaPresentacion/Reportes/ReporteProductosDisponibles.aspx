<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteProductosDisponibles.aspx.cs" Inherits="CapaPresentacion.Reportes.ReporteProductosDisponibles" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="50px" ReportSourceID="CrystalReportSourceProdDisponibles" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="350px" />
            <CR:CrystalReportSource ID="CrystalReportSourceProdDisponibles" runat="server">
                <Report FileName="ProductosDisponibles.rpt">
                </Report>
            </CR:CrystalReportSource>
            <CR:CrystalReportSource ID="CrystalReportSourceProductosDisponibles" runat="server">
                <Report FileName="CrystalReportProductosDisponibles.rpt">
                </Report>
            </CR:CrystalReportSource>
        </div>
    </form>
</body>
</html>
