﻿<%@ Control Language="VB" AutoEventWireup="false" CodeFile="FichaTareasHipotecas.ascx.vb" Inherits="FichaTareasHipotecas" %>
<script type="text/javascript">
    function PanelClick(sender, e) {
    }
    function ActiveTabChanged(sender, e) {
    }
</script>
<script language="JavaScript" type="text/JavaScript">
<!--
    function RelationTableUpdate(RelationTable, PivotTable, ChildTable, PivotId, ChildId, UserId) {
        ret = SimpleService.RelationTableUpdate(RelationTable, PivotTable, ChildTable, PivotId, ChildId, UserId);
    }

// -->
</script>
<asp:PlaceHolder ID="MyView" runat="server"></asp:PlaceHolder>
<asp:Label ID="MyMessage1" runat="server" CssClass="subtit"></asp:Label>
<asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>