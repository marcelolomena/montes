<%@ Control Language="VB" AutoEventWireup="false" CodeFile="FichaDocumentosSGI.ascx.vb" Inherits="FichaDocumentosSGI" %>
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
<script language="JavaScript" type="text/JavaScript">
<!--
    function RelationTableUpdate(RelationTable, PivotTable, ChildTable, PivotId, ChildId, UserId) {
        ret = SimpleService.RelationTableUpdate(RelationTable, PivotTable, ChildTable, PivotId, ChildId, UserId);
    }

// -->
</script>
<asp:PlaceHolder ID="MyView" runat="server"></asp:PlaceHolder>
<asp:table id="MyTabs" runat="server" width="100%" cellspacing="2" cellpadding="2" />
<asp:PlaceHolder ID="MyFormulario" runat="server"></asp:PlaceHolder>
<asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>