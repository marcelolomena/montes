<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PlantillaDemandaJuicioEjecutivo.ascx.vb" Inherits="PlantillaDemandaJuicioEjecutivo" %>
<asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/img/lupa20x20.png" 
            ToolTip="De un click de mouse para visualizar en Word 2010">HyperLink</asp:HyperLink>
<table width="650" border="0" cellpadding="0" cellspacing="0" class="caja_principal">
  <tr>
    <td>
    <table width="650" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td class="contenidos"><p>&nbsp;</p>
          <table border="0" cellpadding="0" cellspacing="0" class="priorizacion_tabla_encabezado">
            <tr>
              <td><h1>PROCEDIMIENTO:</h1></td>
              <td><h1><b>EJECUTIVO</b></h1></td>
              <td></td>
            </tr>            
            <tr>
              <td><h1>MATERIA:</h1></td>
              <td><h1><b>COBRO DE MUTUO</b></h1></td>
              <td></td>
            </tr>            
            <tr>
              <td><h1>DEMANDANTE:</h1></td>
              <td><h1><b>BANCO SCOTIABANK</b></h1></td>
              <td><h1><b>RUT 97.018.000-1</b></h1></td>
            </tr>
            <tr>
              <td><h1>PATROCINANTE:</h1></td>
              <td><h1><b>JORGE MONTES BEZANILLA</b></h1></td>
              <td><h1><b>RUT 5.892.163-7</b></h1></td>
            </tr>
            <tr>
              <td><h1>APODERADO:</h1></td>
              <td><h1><b>MARÍA PAZ MONTES BEZANILLA</b></h1></td>
              <td><h1><b>RUT 6.971.644-K</b></h1></td>
            </tr>                                    
            <tr>
              <td><h1>DEMANDADO:</h1></td>
              <td><h1><b><asp:Label ID="lblDeudor" runat="server" Text="Label"></asp:Label></b></h1></td>
              <td><h1><b>RUT <asp:Label ID="lblRutDeudor" runat="server" Text="Label"></asp:Label></b></h1></td>
            </tr>            
            <asp:PlaceHolder ID="MyAvales" runat="server"></asp:PlaceHolder>    
            </table>
            <hr />
            <p>En lo principal, demanda ejecutiva y mandamiento de ejecución y embargo; en el primer otrosí, señala bienes para la traba de embargo y depositario provisional; en el segundo, acompaña documentos, con citación; en el tercero, patrocinio y poder.</p>
            <center><h1><b>S.J.L</b></h1></center>
            <center><h1><b>.J.L</b></h1></center>
            <p><asp:Label ID="LblRepresentanteBanco" runat="server" Text="Label"></asp:Label> en representación según se acredita con el documento que archivado en la Secretaria del Tribunal,  del Banco Scotiabank, institución financiera, ambos domiciliados en calle Morandé Nº 226, Santiago, a V.S. respetuosamente digo:</p>
            <p>Consta de la escritura pública de fecha <asp:Label ID="lblFechaEscritura" runat="server" Text="Label"></asp:Label> otorgada en la Notaría de <asp:Label ID="lblCiudadEscritura" runat="server" Text="Label"></asp:Label> de don <asp:Label ID="lblNotarioEscritura" runat="server" Text="Label"></asp:Label>, que el Banco Scotiabank otorgó a 
<asp:Label ID="lblNombreDeudor" runat="server" Text="Label"></asp:Label> un mutuo por la cantidad equivalente de <asp:Label ID="lblMontoUF" runat="server" Text="Label"></asp:Label> Unidades de Fomento, en letras de crédito de su propia emisión, las que ganan los intereses y se amortizan en los plazos y condiciones establecidos en la citada escritura pública. La obligación genera un interés del <asp:Label ID="lblTasaInteresAnual" runat="server" Text="Label"></asp:Label> anual.
</p>
            <p>El deudor se obligó a pagar la cantidad recibida en mutuo en el plazo de <asp:Label ID="lblMesesPlazo" runat="server" Text="Label"></asp:Label>, por  medio de dividendos anticipados, mensuales y sucesivos, pactados en unidades de fomento, pagaderos en moneda nacional en el equivalente de la Unidad de Fomento del día del pago, dividendos que comprenden la amortización, los intereses  pactados y la comisión estipulada en el mutuo.</p>
            <p>Los dividendos deben pagarse dentro de los primeros diez días de cada mes, en efectivo, en el domicilio del acreedor. En el caso de no pago oportuno de cualquiera de los dividendos dentro del plazo establecido, se devengan intereses penales o moratorios equivalentes al máximo que la ley permite estipular para operaciones de crédito de dinero reajustables en moneda nacional que se aplican desde la fecha de la mora y hasta la de pago efectivo de toda la deuda.</p>
            <p>El dividendo que el deudor debió pagar el <asp:Label ID="lblMesInicio" runat="server" Text="Label"></asp:Label> y los sucesivos dividendos a contar de ese, se encuentran impagos hasta esta fecha. De acuerdo con la liquidación practicada por el Banco Soctiabank, la deuda es <asp:Label ID="lblDeudaCapitalUF" runat="server" Text="Label"></asp:Label> Unidades de Fomento equivalentes a $ <asp:Label ID="lblDeudaCapitalPesos" runat="server" Text="Label"></asp:Label> por concepto de capital y de <asp:Label ID="lblDeudaDividendosUF" runat="server" Text="Label"></asp:Label> Unidades de Fomento equivalentes a $ <asp:Label ID="lblDeudaDividendosPesos" runat="server" Text="Label"></asp:Label> por concepto de dividendos impagos, a lo que se deben sumar los intereses penales pactados</p>
            <p>En la escritura pública en que consta el referido mutuo se estipuló que el no pago oportuno de cualquier dividendo daría derecho al Banco para exigir el pago de toda la obligación, como si fuere de plazo vencido.</p>
            <p>En garantía de las obligaciones que <asp:Label ID="lblNombreDeudor1" runat="server" Text="Label"></asp:Label>  asumió en el contrato de mutuo antes referido, en el mismo instrumento constituyó hipoteca sobre el inmueble de su propiedad que se singulariza a continuación:</p>
            <asp:PlaceHolder ID="LasHipotecas" runat="server"></asp:PlaceHolder>
            <asp:PlaceHolder ID="LasGarantias" runat="server"></asp:PlaceHolder>
            <asp:PlaceHolder ID="LosOtrosBienes" runat="server"></asp:PlaceHolder>
            <asp:PlaceHolder ID="LosAvales" runat="server"></asp:PlaceHolder>
            <p>Conforme a lo anterior, vengo en demandar ejecutivamente a don(ña) <asp:Label ID="lblNombreDeudor2" runat="server" Text="Label"></asp:Label>, <asp:Label ID="lblProfesion" runat="server" Text="Label"></asp:Label>, domiciliado en <asp:Label ID="lblDomicilio" runat="server" Text="Label"></asp:Label>, <asp:Label ID="lblComuna" runat="server" Text="Label"></asp:Label>  por <asp:Label ID="lblDeudaCapitalUF1" runat="server" Text="Label"></asp:Label> Unidades de Fomento equivalentes a $ <asp:Label ID="lblDeudaCapitalPesos1" runat="server" Text="Label"></asp:Label> por concepto de capital y de <asp:Label ID="lblDeudaDividendosUF1" runat="server" Text="Label"></asp:Label> Unidades de Fomento equivalentes a $ <asp:Label ID="lblDeudaDividendosPesos1" runat="server" Text="Label"></asp:Label> por concepto de dividendos impagos, más los intereses pactados y los intereses penales o moratorios que se han indicado.</p>
            <p>El mutuo consta de una escritura pública por lo que tiene mérito ejecutivo en conformidad con la ley. La deuda es líquida, actualmente exigible y su acción no ha prescrito.</p>
            <asp:PlaceHolder ID="LosAvalesDemandados" runat="server"></asp:PlaceHolder>            
            <center><h1><b>POR TANTO,</b></h1></center>
            <p>En mérito de lo expuesto, de los documentos que se acompañan y conforme lo estableces los artículos 434 y siguientes del Código de Procedimiento Civil, a V.S. ruego se sirva tener por presentada demanda ejecutiva en contra de don(ña) <asp:Label ID="lblNombreDeudor3" runat="server" Text="Label"></asp:Label> <asp:PlaceHolder ID="LosDemandados" runat="server"></asp:PlaceHolder>  ordenar se despache en su contra mandamiento de ejecución y embargo por <asp:Label ID="lblDeudaCapitalUF2" runat="server" Text="Label"></asp:Label> Unidades de Fomento equivalentes a $ <asp:Label ID="lblDeudaCapitalPesos2" runat="server" Text="Label"></asp:Label> por concepto de capital y de <asp:Label ID="lblDeudaDividendosUF2" runat="server" Text="Label"></asp:Label> Unidades de Fomento equivalentes a $ <asp:Label ID="lblDeudaDividendosPesos2" runat="server" Text="Label"></asp:Label> por concepto de dividendos impagos, más los interses pactados y los intereses penales o moratorios, y disponer se siga adelante con la ejecución hasta hacerse íntegro pago de toda la deuda, con costas.</p>
            <p><b>PRIMER OTROSÍ:</b> ruego a V.S. tener presente que señalo para la traba de embargo todos los bienes que aparezcan a nombre o en posesión del demandado, en especial, los singularizados en lo principal, bienes que  quedarán en  poder del deudor, como depositario provisional bajo su responsabilidad legal, sin perjuicio de la designación de un depositario definitivo que solicitará esta parte.</p>
            <p><b>SEGUNDO OTROSÍ:</b> sírvase V.S. tener por acompañados los siguientes documentos con citación:</p><p>Copia autorizada de los siguientes documentos:</p>
            <p><asp:PlaceHolder ID="LosDocumentos" runat="server"></asp:PlaceHolder></p>            
            <p><b>TERCER OTROSÍ:</b> ruego a V.S. tener presente que designo abogado patrocinante y otorgo poder a don Jorge Montes Bezanilla, patente de la Municipalidad de Santiago Nº 410.610-5 y que confiero poder a doña María Paz Montes Bezanilla, abogado, patente al día Nº 420.642-8 de la citada Municipalidad, ambos domiciliados en calle San Pío X, Oficina 1304, Providencia, quienes podrán actuar en forma separada e indistinta.</p>
        </td></tr>
    </table></td>
  </tr>
</table>     