<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ReportesPGG.aspx.vb" Inherits="ReportesPGG" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Sistema de Cobranza Judicial</title>
    <meta content="text/html; charset=iso-8859-1" http-equiv="Content-Type" />
    <link rel="stylesheet" type="text/css" href="Styles/stylesheet.css" />
    <link href="SpryAssets/SpryAccordion.css" rel="stylesheet" type="text/css" />
    <script src="SpryAssets/SpryAccordion.js" type="text/javascript"></script>

    <script src="http://ajax.microsoft.com/ajax/jquery/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="Scripts/AC_RunActiveContent.js"></script>
    <script type="text/javascript" language="javascript">

        function aparecer(submenus) {

            if (document.getElementById(submenus).className == "visible") {
                document.getElementById(submenus).className = "invisible";
            } else {
                document.getElementById(submenus).className = "visible";
            }
        }

        function desaparecer(submenus) {

            if (document.getElementById(submenus).className == "visible") {
                document.getElementById(submenus).className = "invisible";
            } else {
                document.getElementById(submenus).className = "invisible";
            }
        }

        function todosvisibles(submenus) {

            if (document.getElementById(submenus).className == "visible") {
                document.getElementById(submenus).className = "visible";
            } else {
                document.getElementById(submenus).className = "visible";
            }
        }
        function MM_preloadImages() { //v3.0
            var d = document; if (d.images) {
                if (!d.MM_p) d.MM_p = new Array();
                var i, j = d.MM_p.length, a = MM_preloadImages.arguments; for (i = 0; i < a.length; i++)
                    if (a[i].indexOf("#") != 0) { d.MM_p[j] = new Image; d.MM_p[j++].src = a[i]; }
            }
        }
 

        function verModalCarpetaJudicial(urlName) { 
            var vals;
            vals = window.showModalDialog(urlName);
        }



    </script>
    <link rel="stylesheet" type="text/css" href="jsgantt.css"/>
    <script type="text/javascript" language="javascript" src="jsgantt.js"></script>
    <meta name="GENERATOR" content="MSHTML 8.00.7600.16535" />
    <style type="text/css">

        .style1 {color: #0000FF}

        .roundedCorner{display:block}
        .roundedCorner *{
          display:block;
          height:1px;
          overflow:hidden;
          font-size:.01em;
          background:#0061ce}
        .roundedCorner1{
          margin-left:3px;
          margin-right:3px;
          padding-left:1px;
          padding-right:1px;
          border-left:1px solid #91bbe9;
          border-right:1px solid #91bbe9;
          background:#3f88da}
        .roundedCorner2{
          margin-left:1px;
          margin-right:1px;
          padding-right:1px;
          padding-left:1px;
          border-left:1px solid #e5effa;
          border-right:1px solid #e5effa;
          background:#307fd7}
        .roundedCorner3{
          margin-left:1px;
          margin-right:1px;
          border-left:1px solid #307fd7;
          border-right:1px solid #307fd7;}
        .roundedCorner4{
          border-left:1px solid #91bbe9;
          border-right:1px solid #91bbe9}
        .roundedCorner5{
          border-left:1px solid #3f88da;
          border-right:1px solid #3f88da}
        .roundedCornerfg{
          background:#0061ce;}



    </style>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Services >
                <asp:ServiceReference Path="AutoCompleteTitulo.asmx" /> 
                <asp:ServiceReference Path="SimpleService.asmx" />
            </Services>
        </asp:ScriptManager>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
 
    </form>
</body>
</html>
