<%@ Control Language="VB" AutoEventWireup="false" CodeFile="FichaCarpetaJudicial.ascx.vb" Inherits="FichaCarpetaJudicial" %>
<! -- Código generado por ZRISMART SF el 24-02-2012 11:00:32 -->

<script type="text/vbscript" language="vbscript">
Sub RutValidator_ClientValidate(s, e)
e.IsValid = True
End Sub
</script>
<script type="text/javascript" language="javascript">

    function verModalTarea(urlName,UserId,arrControl,arrLabel,k,IsNotEnabledField,Pagina,NombrePagina,MenuOptionsId,MasterName,MasterId,DomainField,FormularioWebPId,FilterField,sSQLWhere,sSQLOrder,PaginaWebName) {
        var vals;
        // vals = window.showModalDialog(urlName);
        vals = window.showModalDialog(urlName);        
        refrescarnotas(vals);
        LoadTabla(arrControl, arrLabel, k, IsNotEnabledField, Pagina, NombrePagina, MenuOptionsId, MasterName, MasterId, DomainField, FormularioWebPId, FilterField, sSQLWhere, sSQLOrder, PaginaWebName, UserId);
    }
    function OnCompleteRefrescarnotas(arg) {
        // var cajadiv = "div#ListaNotas";
        document.getElementById("ListaNotas").innerHTML = arg;
    }
    function OnTimeOutRefrescarnotas(arg) {
        alert("TimeOut al invocar el servicio de refrescar notas");
    }
    function OnErrorRefrescarnotas(arg) {
        alert("Error encontrado al invocar el servicio de refrescar notas");
    }
    function refrescarnotas(UsuariosCodigo) {
        ret = SimpleService.MostrarNotasTransversales(UsuariosCodigo, OnCompleteRefrescarnotas, OnTimeOutRefrescarnotas, OnErrorRefrescarnotas);
        return (true);
    }

    function OnCompletecerrarTarea(arg) {
        // var cajadiv = "div#Acciones";
        document.getElementById("Acciones").innerHTML = arg;
    }
    function OnTimeOutcerrarTarea(arg) {
        alert("TimeOut al invocar el servicio");
    }
    function OnErrorcerrarTarea(arg) {
        alert("Error encontrado al invocar el servicio");
    }
    function cerrarTarea(TareasId,UserId,arrControl,arrLabel,k,IsNotEnabledField,Pagina,NombrePagina,MenuOptionsId,MasterName,MasterId,DomainField,FormularioWebPId,FilterField,sSQLWhere,sSQLOrder,PaginaWebName) {
        ret = SimpleService.CerrarTarea(TareasId, UserId,arrControl,arrLabel,k,IsNotEnabledField,Pagina,NombrePagina,MenuOptionsId,MasterName,MasterId,DomainField,FormularioWebPId,FilterField,sSQLWhere,sSQLOrder,PaginaWebName, OnCompletecerrarTarea, OnTimeOutcerrarTarea, OnErrorcerrarTarea);
        return (true);
    }

    function OnCompleteLoadTabla(arg) {
        //var cajadiv = "div#Acciones";
        document.getElementById("Acciones").innerHTML = arg;
    }
    function OnTimeOutLoadTabla(arg) {
        alert("TimeOut al invocar el servicio");
    }
    function OnErrorLoadTabla(arg) {
        alert("Error encontrado al invocar el servicio");
    }
    function LoadTabla(arrControl, arrLabel, k, IsNotEnabledField, Pagina, NombrePagina, MenuOptionsId, MasterName, MasterId, DomainField, FormularioWebPId, FilterField, sSQLWhere, sSQLOrder, PaginaWebName, UserId) {
        ret = SimpleService.LoadTabla(arrControl, arrLabel, k, IsNotEnabledField, Pagina, NombrePagina, MenuOptionsId, MasterName, MasterId, DomainField, FormularioWebPId, FilterField, sSQLWhere, sSQLOrder, PaginaWebName, UserId, OnCompleteLoadTabla, OnTimeOutLoadTabla, OnErrorLoadTabla);
        return (true);
    }

</script>

<asp:PlaceHolder ID="MyView" runat="server"></asp:PlaceHolder>
<asp:PlaceHolder ID="MyJavaScript" runat="server"></asp:PlaceHolder>
<asp:Label ID="MyMessage1" runat="server" CssClass="contenidos"></asp:Label>
<!-- <asp:LinkButton ID="lblLinkGantt" runat="server">Carta Gantt</asp:LinkButton> -->
<asp:table id="MyTabs" runat="server" width="600" cellspacing="2" cellpadding="2" />
<asp:PlaceHolder ID="MyFormulario" runat="server"></asp:PlaceHolder>


<script language="JavaScript" type="text/JavaScript">
<!--
    function RelationTableUpdate(RelationTable, PivotTable, ChildTable, PivotId, ChildId, UserId) {
        ret = SimpleService.RelationTableUpdate(RelationTable, PivotTable, ChildTable, PivotId, ChildId, UserId);
    }

// -->
</script>
