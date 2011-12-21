<%@ Page Language="C#" AutoEventWireup="true" CodeFile="report.aspx.cs" Inherits="Report_report" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <p>
        Picker Date to show report.<br />
            <mark:datetimepicker ID="Picker1" runat="server" PickerCssClass="Picker" 
                FirstDayOfWeek="Sunday" Format="dd/MM/yyyy" ontextchanged="RenderReport" 
                ShowDatePicker="True" ShowTimePicker="False" />
            <asp:Button ID="Button1" runat="server" Text="Button" onclick="RenderReport" />
        </p>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
            GroupTreeImagesFolderUrl="" Height="50px" 
            ReportSourceID="CrystalReportSource1" ToolbarImagesFolderUrl="" 
            ToolPanelWidth="200px" Width="350px" />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="Report\CrystalReport.rpt">
            </Report>
        </CR:CrystalReportSource>
    
    </div>
    </form>
</body>
</html>
