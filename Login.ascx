<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Login.ascx.vb" Inherits="Login" %>
    <asp:table id="MyTable" runat="server" width="100%" cellspacing="2" cellpadding="2" />     
    <script type="text/vbscript" language="vbscript">
        Sub RutValidator_ClientValidate(s, e)
            'Dim RD
            'Dim LenRut
            'Dim RutSinDigito
            'Dim Digito
            'Dim Contador
            'Dim Multiplo
            'Dim Acumulador
            'Dim RutDigito
            'Dim Rut
            
            'Rut = e.Value
            'LenRut = Len(Rut)

            'If LenRut > 2 Then
            '    RD = Mid(Rut, LenRut)
            '    RutSinDigito = Val(Mid(Rut, 1, LenRut - 2))
            'End If

            'Contador = 2
            'Acumulador = 0
            'While Rut <> 0
            '    Multiplo = (Rut Mod 10) * Contador
            '    Acumulador = Acumulador + Multiplo
            '    Rut = Rut \ 10
            '    Contador = Contador + 1
            '    If Contador = 8 Then
            '        Contador = 2
            '    End If
            'End While
            'Digito = 11 - (Acumulador Mod 11)
            'RutDigito = CStr(Digito)
            'If Digito = 10 Then RutDigito = "K"
            'If Digito = 11 Then RutDigito = "0"

            'If RD = RutDigito And LenRut > 2 Then
            '    e.IsValid = True
            'Else
            '    e.isValid = False
            'End If        
        
            'Dim strValue

            'strValue = e.Value
            'If strValue <> "7627170-4" Then
            '    e.IsValid = False
            'Else
                e.IsValid = True
            'End If        
        
        
        End Sub

    </script>
<br />
<asp:Label ID="MyMessage1" runat="server" CssClass="subtit"></asp:Label>
  
    