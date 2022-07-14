<%@ Control Language="VB" AutoEventWireup="false" CodeFile="FichaCargos.ascx.vb" Inherits="FichaCargos" %>
<! -- Código generado por ZRISMART SF el 18-04-2011 18:54:17 -->
<script type="text/javascript">
function PanelClick(sender, e) {
}
function ActiveTabChanged(sender, e) {
}
</script>
<script type="text/vbscript" language="vbscript">
Sub RutValidator_ClientValidate(s, e)
e.IsValid = True
End Sub
</script>
<asp:PlaceHolder ID="MyView" runat="server"></asp:PlaceHolder>
<br />
<asp:Label ID="MyMessage1" runat="server" CssClass="subtit"></asp:Label>
<br />
<asp:table id="MyTabs" runat="server" width="100%" cellspacing="2" cellpadding="2" />
<asp:PlaceHolder ID="MyFormulario" runat="server"></asp:PlaceHolder>
<script language="JavaScript" type="text/JavaScript">
<!--
    function RelationTableUpdate(RelationTable, PivotTable, ChildTable, PivotId, ChildId, UserId) {
        ret = SimpleService.RelationTableUpdate(RelationTable, PivotTable, ChildTable, PivotId, ChildId, UserId);
    }

// -->
</script>