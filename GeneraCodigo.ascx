<%@ Control Language="VB" AutoEventWireup="false" CodeFile="GeneraCodigo.ascx.vb" Inherits="GeneraCodigo"  %>
    <h1>Aplicación para apoyar el desarrollo de páginas</h1>
    <table border="0" cellpadding="0" cellspacing="0" class="popups_titulo_con_enlaces">
        <tr>
            <td><h2>1.- Genera archivo con la definición de una tabla</h2></td>
            <td align="right"><img src="imgs/expandir.png" width="25" height="25" alt="Expandir" onclick="aparecer('subgrilla1')" /></td>
        </tr>
    </table>
    <div id="subgrilla1" class="visible">
    <p>Este primer paso genera una clase con los metodos basicos para el acceso a la tabla indicada por el usuario</p>
    <asp:BulletedList ID="BulletedList1" FirstBulletNumber="1" runat="server">
        <asp:ListItem>Digite el nombre de la tabla de la base de datos</asp:ListItem>
        <asp:ListItem>Indique si la tabla es del tipo "Maestra" o del tipo "Hija"</asp:ListItem>
        <asp:ListItem>Indique el nombre de la clase, mantenga el mismo nombre de la tabla</asp:ListItem>
        <asp:ListItem>Genere el código accionando el botón para generar el archivo de definición de una tabla</asp:ListItem>
        <asp:ListItem>EL sistema desplegará el nombre y ubicación del archivo generado y usted lo podrá visualizar si así lo desea hacer</asp:ListItem>
        <asp:ListItem>Finalmente debe hacer el upload del archivo generado y el sistema lo traspasa al directorio de la aplicación</asp:ListItem>
    </asp:BulletedList>
    <table cellspacing="2" cellpadding="2" border="0" style="background-color: WhiteSmoke;border-color:WhiteSmoke;border-width:1px;border-style:Solid;width:700px;">
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">Nombre de la tabla:</td>
            <td valign="middle" style="width:65%;"><asp:TextBox ID="txtNombreTabla" CssClass="textoboxgris" runat="server" ToolTip="Nombre de la Tabla" Height="20px" Width="450px"></asp:TextBox>
                </td>
	    </tr>
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">Tipo de Tabla (Maestra o Hija):</td>
            <td valign="middle" style="width:65%;"><asp:TextBox ID="txtTableType" CssClass="textoboxgris" runat="server" ToolTip="Tipo Tabla: Maestra, Hija" Height="20px" Width="450px"></asp:TextBox>
                </td>
	    </tr>       
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">Nombre de la Clase:</td>
            <td valign="middle" style="width:65%;"><asp:TextBox ID="txtClassName" CssClass="textoboxgris" runat="server" ToolTip="Nombre de la Clase" Height="20px" Width="450px"></asp:TextBox>
                </td>
	    </tr>        
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;"></td>
            <td valign="middle" style="width:65%;">
                <asp:Button ID="Button17" CssClass="boxceleste" runat="server"  Height="20px"
                    Text="Generar archivo de definición de una tabla" Width="450px" />
                </td>
	    </tr>        
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">Nombre del Archivo vb Generado:</td>
            <td valign="middle" style="width:65%;">
                <asp:Label ID="lblNombreArchivovbV2" runat="server"></asp:Label>&nbsp;&nbsp;
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="" 
                    Target="_blank">HyperLink</asp:HyperLink>
                </td>
	    </tr>
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">Nombre del Archivo de Clase:</td>
            <td valign="middle" style="width:65%;">                
                <asp:Label ID="lblNombreArchivovbDestinoV2" runat="server"></asp:Label>
                </td>
	    </tr>       
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">Adjuntar Archivo:</td>
            <td valign="middle" style="width:65%;"><asp:FileUpload ID="FileUpload8" runat="server"  Height="20px"  style="margin-top: 0px" />&nbsp;&nbsp;
                <asp:Button ID="Button18" CssClass="boxceleste" runat="server" Text="Save"  Height="20px" Width="80px" /></td>
	    </tr>        
    </table>
    </div>
    
    <table border="0" cellpadding="0" cellspacing="0" class="popups_titulo_con_enlaces">
        <tr>
            <td><h2>2.- Genera archivo master y detalle de una entidad de negocio</h2></td>
            <td align="right"><img src="imgs/expandir.png" width="25" height="25" alt="Expandir" onclick="aparecer('subgrilla2')" /></td>
        </tr>
    </table>
    <div id="subgrilla2" class="visible">
    <p>Este segundo paso permite generar un registro en la tabla "Entidad" y un registro en la tabla "AttrEntidad" por cada atributo de la tabla indicada por el usuario</p>
    <asp:BulletedList ID="BulletedList2" FirstBulletNumber="1" runat="server">
        <asp:ListItem>Digite el nombre de la tabla de la base de datos</asp:ListItem>
        <asp:ListItem>Digite el nombre de la Entidad</asp:ListItem>
        <asp:ListItem>Digite el nombre de la clase</asp:ListItem>
        <asp:ListItem>Indique el tipo de entidad: "Maestra" o "Hija"</asp:ListItem>
        <asp:ListItem>Si la tabla fue declarada como del tipo "Hija" debe indicar el nombre de la tabla padre, de lo contrario dejar en blanco</asp:ListItem>
        <asp:ListItem>Finalmente debe accionar el botón para generar el registro de cabecera de la tabla y cada uno de los registros que representan a los atributos de la tabla</asp:ListItem>
    </asp:BulletedList>
    <table cellspacing="2" cellpadding="2" border="0" style="background-color: WhiteSmoke;border-color:WhiteSmoke;border-width:1px;border-style:Solid;width:700px;">
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">Nombre de la tabla:</td>
            <td valign="middle" style="width:65%;">
                <asp:TextBox ID="txtTablaName" CssClass="textoboxgris" runat="server" Height="20px" Width="450px"></asp:TextBox>
                </td>
	    </tr>
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">Nombre de la 
                entidad:</td>
            <td valign="middle" style="width:65%;">
                <asp:TextBox ID="txtEntidadName" CssClass="textoboxgris" runat="server" Height="20px" Width="450px"></asp:TextBox>
                </td>
	    </tr>       
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">Nombre de la clase:</td>
            <td valign="middle" style="width:65%;">
                <asp:TextBox ID="txtClaseName" CssClass="textoboxgris" runat="server" Height="20px" Width="450px"></asp:TextBox>
                </td>
	    </tr>        
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">Tipo de Entidad:</td>
            <td valign="middle" style="width:65%;">
                
                <asp:TextBox ID="txtTipo" CssClass="textoboxgris" runat="server" Height="20px" Width="450px"></asp:TextBox>
                
                </td>
	    </tr>
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">Nombre tabla 
                padre:</td>
            <td valign="middle" style="width:65%;">
                <span> <asp:TextBox ID="txtParentTableName" CssClass="textoboxgris" runat="server" Height="20px" Width="450px"></asp:TextBox>
                </span>
                </td>
	    </tr>       
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">&nbsp;</td>
            <td valign="middle" style="width:65%;">
                <asp:Button ID="Button19" CssClass="boxceleste" runat="server" Text="Generar master y detalle de una entidad" Height="20px" Width="450px" />
                </td>
	    </tr>        
    </table>

    </div>

    <table border="0" cellpadding="0" cellspacing="0" class="popups_titulo_con_enlaces">
        <tr>
            <td><h2>3.- Modificar registros de la tabla "AttrEntidad"</h2></td>
            <td align="right"><img src="imgs/expandir.png" width="25" height="25" alt="Expandir" onclick="aparecer('subgrilla3')" /></td>
        </tr>
    </table>
    <div id="subgrilla3" class="invisible">
    <p>Este tercer paso es previo a la generación de uno o más registros en las tablas "PaginaWeb" y "FormularioWeb" y consiste en preparar los datos para el proceso de generación de los registros en las tablas mencionadas</p>
    <p>Este paso "por ahora" no tiene soporte mediante alguna aplicación de apoyo y debe realizarse directamente sobre la tabla "AttrEntidad" y en particular sobre aquellos registros que contienen la descripción de cada uno de los atributos de la tabla padre y de las tablas hijas, en caso de que existan y la aplicación a generar sea del tipo "Master-Detail"</p>
    <p>Acceder manualmente a la tabla "AttrEntidad" y ubicar los registros que correspondan a la entidad Master y a las entidades Hijas, estas últimas sólo si así corresponde</p>
    <p>El atributo EntidadNombreTabla contiene el nombre de las Tablas y el atributo AttrEntidadColumnName contiene el nombre de los atributos de cada tabla</p>
    <p>Para las siguientes columnas de la tabla AttrEntidad y operando sobre cada uno de los registros que correspondan a cada una de los campos o atributos de las tablas involucradas en el proceso de generación, se deben hacer las siguientes operaciones:</p>
    <table cellspacing="0" rules="all" border="1" id="tabla_de_datos" style="width:700px;border-collapse:collapse;">
	    <tr><th scope="col" style="width:20%;">Columna</th><th scope="col" style="width:80%;">Acción a realizar</th></tr>
        <tr><td align="left">AttrEntidadIsRequerido</td><td align="left">Se debe marcar en caso de que el campo sea obligatorio</td></tr>
        <tr  class="alt"><td align="left">AttrEntidadIsForeignKey</td><td align="left">Se debe marcar si el campo corresponde a una lista de selección de datos que se deben obtener desde otra tabla relacionada</td></tr>
        <tr><td align="left">AttrEntidadForeignTabla</td><td align="left">Nombre de la tabla Foranea, cuando corresponda</td></tr>
        <tr  class="alt"><td align="left">AttrEntidadForeignSQL</td><td align="left">Nombre de la tabla Foranea, cuando corresponda</td></tr>
        <tr><td align="left">AttrEntidadColumnLabel</td><td align="left">Etiqueta del campo en la página a generar</td></tr>
        <tr  class="alt"><td align="left">AttrEntidadColumnControlWidth</td><td align="left">Largo del control</td></tr>            
        <tr><td align="left">AttrEntidadColumnToolTip</td><td align="left">Tooltip del Control</td></tr>
        <tr  class="alt"><td align="left">AttrEntidadIsFilterField</td><td align="left">Se debe marcar si el campo debe ser considerar dentro del criterio de búsqueda de los registros de la tabla</td></tr>    
        <tr><td align="left">AttrEntidadIsColumnField</td><td align="left">Se debe marcar si el campo esta incluido entre las columnas que se deben mostrar en la lista de los registros encontrados aplicando el criterio de búsqueda y en la lista inicial que se presenta al usuario al acceder a la aplicación de mantención de la tabla</td></tr>
        <tr  class="alt"><td align="left">AttrEntidadColumnNumber</td><td align="left">Si el atributo "AttrEntidadIsColumnField" es verdadero, se debe indicar el número de la columna dentro de la lista</td></tr>        
        <tr><td align="left">AttrEntidadColumnHeader</td><td align="left">Si el atributo "AttrEntidadIsColumnField" es verdadero, se debe indicar el nombre de la columna dentro de la lista</td></tr>
        <tr  class="alt"><td align="left">AttrEntidadColumnGroupNumber</td><td align="left">Dentro de un formulario a generar se pueden definir uno o más grupos de datos, lo habitual es que todo los campos esten en un sólo grupo, pero de no ser asi se deben poner numeros a cada grupo comenzando del 1 en adelante</td></tr>            
        <tr><td align="left">AttrEntidadColumnGroupOrdinal</td><td align="left">Posición del campo dentro del resto de los campos que corresponden a un mismo grupo</td></tr>
        <tr  class="alt"><td align="left">AttrEntidadColumnGroupName</td><td align="left">Nombre del grupo de campos</td></tr>            
    </table>
    </div>
     <table border="0" cellpadding="0" cellspacing="0" class="popups_titulo_con_enlaces">
        <tr>
            <td><h2>4.- Genera Registros de especificación de Paginas y Formularios de la Entidad</h2></td>
            <td align="right"><img src="imgs/expandir.png" width="25" height="25" alt="Expandir" onclick="aparecer('subgrilla4')" /></td>
        </tr>
    </table>
    <div id="subgrilla4" class="invisible">
    <p>Este cuarto paso permite generar uno o más registros en la tabla "PaginaWeb" y un registro en la tabla "FormularioWeb" por cada control que debe ser usado en las páginas de la aplicación a generar, sea ésta del tipo Master o del tipo Master-Detail</p>
    <asp:BulletedList ID="BulletedList3" FirstBulletNumber="1" runat="server">
        <asp:ListItem>Digite el nombre de la Master Page, por ahora el nombre es fijo y corresponde a "MasterSGI.aspx"</asp:ListItem>
        <asp:ListItem>La aplicación debe poseer un punto de invocación dentro del menú del sistema.  El menú del sistema esta contenido en los registros de la tabla "MenuOptions". En este campo se debe indicar el valor del campo MenuOptionsId que corresponde al punto del menú desde el cuál la aplicación será invocada.</asp:ListItem>
        <asp:ListItem>Digite el nombre de la tabla</asp:ListItem>
        <asp:ListItem>De un click de mousse sobre cada uno de los botones para generar la especificación de las páginas a generar.  El sistema generará 4 registros en la tabla PaginaWeb y los registros que sean necesarios en la tabla FormularioWeb</asp:ListItem>
    </asp:BulletedList>       
    <table cellspacing="2" cellpadding="2" border="0" style="background-color: WhiteSmoke;border-color:WhiteSmoke;border-width:1px;border-style:Solid;width:700px;">
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">Nombre de la 
                Master Page:</td>
            <td valign="middle" style="width:65%;">
                
                <asp:TextBox ID="txtMasterPage" ToolTip="Nombre de la Master Page" 
                    runat="server" Height="20px" Width="450px" Text="MasterSGI.aspx"></asp:TextBox>
                
                </td>
	    </tr>
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">Número de la 
                opción de menú:</td>
            <td valign="middle" style="width:65%;">
                
                <asp:TextBox ID="txtMenuOptions" ToolTip="Número de la opción de menú" 
                    runat="server" Height="20px" Width="450px"></asp:TextBox>
                
                </td>
	    </tr>       
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">Nombre de la 
                Tabla:</td>
            <td valign="middle" style="width:65%;">
                
                <asp:TextBox ID="txtEntidadNameLista" ToolTip="Nombre de la Entidad" 
                    runat="server" Height="20px" Width="450px"></asp:TextBox>
                
                </td>
	    </tr>        
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">&nbsp;</td>
            <td valign="middle" style="width:65%;">
                
                
                
                <asp:Button ID="Button20" runat="server" 
                    Text="Generar Página Web y Formulario Web del tipo Lista" CssClass="boxceleste" Height="20px" Width="450px" />
                
                
                
                </td>
	    </tr>
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">&nbsp;</td>
            <td valign="middle" style="width:65%;">
                
                <asp:Button ID="Button21" runat="server" 
                    Text="Generar Página Web y Formulario Web del tipo Ficha de una Entidad" 
                    CssClass="boxceleste" Height="20px" Width="450px" />
                
                </td>
	    </tr>       
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">&nbsp;</td>
            <td valign="middle" style="width:65%;">
                
                <asp:Button ID="Button22" runat="server" 
                    Text="Generar Página Web y Formulario Web del tipo Valida una Entidad" 
                    CssClass="boxceleste" Height="20px" Width="450px" />
                
                </td>
	    </tr> 
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">&nbsp;</td>
            <td valign="middle" style="width:65%;">
                
                <asp:Button ID="Button23" runat="server" 
                    Text="Generar Página Web y Formulario Web del tipo Busca una Entidad" 
                    CssClass="boxceleste" Height="20px" Width="450px" />
                
                </td>
	    </tr>                
    </table>




    </div>
    
    <table border="0" cellpadding="0" cellspacing="0" class="popups_titulo_con_enlaces">
        <tr>
            <td><h2>5.- Modificar registros de la tabla "PaginaWeb" y "FormularioWeb"</h2></td>
            <td align="right"><img src="imgs/expandir.png" width="25" height="25" alt="Expandir" onclick="aparecer('subgrilla5')" /></td>
        </tr>
    </table>
    <div id="subgrilla5" class="invisible">
    <p>Este quinto paso es previo a la generación del código de las páginas de la aplicación y consiste en preparar los datos en los registros generados en el paso inmediatamente anterior</p>
    <p>Este paso "por ahora" no tiene soporte mediante alguna aplicación de apoyo y debe realizarse directamente sobre la tabla "PaginaWeb" y en particular sobre aquellos registros que contienen la descripción de cada una de las páginas para las cuales posteriormente se generará el código a partir de las especificaciones que se encuentran en los registros de las tablas "PaginaWeb" y "FormularioWeb"</p>
    <p>Debe tener presente que ambas tablas no solo se usan en el proceso de generación del código, sino que además son leidas durante la operación de la aplicación y son usuadas para la generación dinámica de las páginas, por ello algunos de sus atributos pueden ser modificados posteriormente produciendo cambios sin necesidad de regenerar el código</p>
    <p>Acceder manualmente a la tabla "PaginaWeb" y ubicar los registros que correspondan a la entidad Master y a las entidades Hijas, estas últimas sólo si así corresponde</p>
    <p>El atributo "PaginaWebName" contiene el nombre de cada una de las páginas</p>
    <p>Para las siguientes columnas de la tabla "PaginaWebName" y operando sobre cada uno de los registros que correspondan a cada una de las entidades o tablas involucradas de las cuales una es la tabla padre y las otras la tabla hija, se deben hacer las siguientes operaciones:</p>
    <table cellspacing="0" rules="all" border="1" id="Table1" style="width:700px;border-collapse:collapse;">
	    <tr><th scope="col" style="width:20%;">Columna</th><th scope="col" style="width:80%;">Acción a realizar</th></tr>
        <tr><td align="left">PaginaWebTitle</td><td align="left">Se debe registrar el nombre de la página.  Este nombre aparecerá como encabezado de la página</td></tr>
        <tr  class="alt"><td align="left">PaginaWebDescription</td><td align="left">Debe registrar una breve descripción del objetivo de la página</td></tr>
        <tr><td align="left">PaginawebDescription2</td><td align="left">Puede dejar el campo en blanco, es opcional</td></tr>
        <tr  class="alt"><td align="left">EntidadNombreTabla</td><td align="left">Debe digitar el nombre de la tabla</td></tr>
        <tr><td align="left">PaginaWebNovedades</td><td align="left">Indica si la página debe también mostrar la lista de novedades</td></tr>
    </table>
    <p>A continuación acceder manualmente a la tabla "FormularioWeb" y ubicar los registros que correspondan a la entidad Master y a las entidades Hijas, estas últimas sólo si así corresponde</p>
    <p>El atributo "FormularioWebNumber" indica el número con el cual se agruparon todos los controles que serán considerados en el proceso de generación del código de cada una de las páginas de la aplicación</p>

    <p>Para las siguientes columnas de la tabla "FormularioWebNumber" y operando sobre cada uno de los registros que correspondan a cada una de las páginas a generar, se deben hacer las siguientes operaciones:</p>
    <table cellspacing="0" rules="all" border="1" id="Table2" style="width:700px;border-collapse:collapse;">
	    <tr><th scope="col" style="width:20%;">Columna</th><th scope="col" style="width:80%;">Acción a realizar</th></tr>
        <tr><td align="left">FormularioWebTipoControl</td><td align="left">En algunos casos se debe cambiar el nombre del tipo de control a generar dependiendo del comportamiento deseado, ver en tabla de más abajo los tipos de control que existen y el comportamiento que ellos tienen al momento de que la página es operada por el usuario</td></tr>
        <tr  class="alt"><td align="left">FormularioWebLabelAlign</td><td align="left">Cuando el control corresponde a una columna de una lista, se debe indicar el alineamiento de la columna pero poniendo el primer caracter en mayuscula (Right, Left, etc)</td></tr>
        <tr><td align="left">FormularioWebControlWidth</td><td align="left">Corresponde al largo del control, que proviene de la especificación dada en la tabla AttrEntidad, sin embargo por una omisión en dicha tabla no se conoce el ancho de cada columna en caso de que el campo corresponda a una columna de una lista, por ello este campo debe ser modificado indicando el ancho de la columna pero solo expresandolo en un número, es decir, sin agregar "px"</td></tr>
        <tr  class="alt"><td align="left">FormularioWebToolTip</td><td align="left">Se debe asegurar que exista el tooltip para el campo</td></tr>
        <tr><td align="left">FormularioWebIsRequired</td><td align="left">Proviene de la tabla AttrEntidad, pero usted puede modificar este atributo si es que posteriormente el campo debe dejar de ser obligatorio</td></tr>
        <tr  class="alt"><td align="left">FormularioWebIsNotEnabled</td><td align="left">Se puede marcar como verdadero si se desea que el control en la página no este habilitado y se muestre como inhabilitado</td></tr>
        <tr><td align="left">FormularioWebDomainInField</td><td align="left">Debe indicar el dominio del campo con el fin de que se hagan validaciones sobre el y también se guie la manera de presentar el control. En tabla de más abajo se indican los dominios posible y el comportamiento del control frente a cada uno</td></tr>
        <tr  class="alt"><td align="left">FormularioWebDataTextField</td><td align="left">Corresponde al nombre del campo dentro de la tabla.  Se usa en caso de que el campo sea del tipo Foreing Key</td></tr>
        <tr><td align="left">FormularioWebTipoDatos</td><td align="left">Tipo de Datos del Campo</td></tr>
        <tr  class="alt"><td align="left">FormularioWebDataFile</td><td align="left">Es la ruta a la base de datos Access de la aplicación</td></tr>
        <tr><td align="left">FormularioWebSelectCommand</td><td align="left">Debe contener una instrucción SQL cuando el campo es una Foreign Key o bien cuando se trata de la instrucción SQL que guía una búsqueda para obtenr una lista de registros.</td></tr>
        <tr  class="alt"><td align="left">FormularioWebGroupValidation</td><td align="left">En caso de que el campo sea requerido en forma obligatoria, este campo debe contener la glosa "InputValidation"</td></tr>
        <tr><td align="left">FormularioWebIsVisibleToInit</td><td align="left">Si este campo se marca el control es visible, en caso contrario el control es no visible al usuario</td></tr>
    </table>
    </div>

     <table border="0" cellpadding="0" cellspacing="0" class="popups_titulo_con_enlaces">
        <tr>
            <td><h2>6.- Genera UserControl con la vista de atributos de la entidad Padre (Ficha 
                Entidad Padre)</h2></td>
            <td align="right"><img src="imgs/expandir.png" width="25" height="25" alt="Expandir" onclick="aparecer('subgrilla6')" /></td>
        </tr>
    </table>
    <div id="subgrilla6" class="invisible">
    <p>Este sexto paso permite generar los archivos ascx y ascx.vb asociadas a la mantención del los datos atomicos de una entidad del tipo Padre</p>
    <asp:BulletedList ID="BulletedList4" FirstBulletNumber="1" runat="server">
        <asp:ListItem>Genere el código fuente del archivo para la mantención de la tabla Maestra (*.ascx)</asp:ListItem>
        <asp:ListItem>Hacer el upload del archivo al directorio de la Aplicación</asp:ListItem>
        <asp:ListItem>Genere el código fuente del archivo para la mantención de la tabla Maestra (*.ascx.vb)</asp:ListItem>
        <asp:ListItem>Hacer el upload del archivo al directorio de la Aplicación</asp:ListItem>
    </asp:BulletedList>       
    <table cellspacing="2" cellpadding="2" border="0" style="background-color: WhiteSmoke;border-color:WhiteSmoke;border-width:1px;border-style:Solid;width:700px;">
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;"></td>
            <td valign="middle" style="width:65%;">
                <asp:Button ID="Button2" runat="server" Text="Generar Archivoascx" CssClass="boxceleste" Height="20px" Width="450px" />
                </td>
	    </tr>
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">
                <span>Nombre del Archivo Generado :</span></td>
            <td valign="middle" style="width:65%;"><asp:Label ID="lblNombreArchivoascx" runat="server"></asp:Label>
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="" 
                    Target="_blank">HyperLink</asp:HyperLink>
                </td>
	    </tr>
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">
                <span>Nombre del Archivo de Clase :</span></td>
            <td valign="middle" style="width:65%;"><asp:Label ID="lblNombreArchivoascxDestino" runat="server"></asp:Label>
                </td>
	    </tr>
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">
                <span>Adjuntar Archivo :</span></td>
            <td class="textocontgris10bold" style="text-align:left;width:65%;">
                <asp:FileUpload ID="FileUpload2" runat="server" />
                <asp:Button ID="Button11" runat="server" Text="Save" CssClass="boxceleste" Height="20px" Width="80px" /> 
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
	    </tr>
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;"></td>
            <td valign="middle" style="width:65%;">
                <asp:Button ID="Button3" runat="server" Text="Generar Archivoascxvb" CssClass="boxceleste" Height="20px" Width="450px" />
                </td>
	    </tr>
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">
                <span>Nombre del Archivo Generado :</span></td>
            <td valign="middle" style="width:65%;"><asp:Label ID="lblNombreArchivoascxvb" runat="server"></asp:Label>
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="" 
                    Target="_blank">HyperLink</asp:HyperLink>
                </td>
	    </tr>
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">
                <span>Nombre del Archivo de Clase :</span></td>
            <td valign="middle" style="width:65%;"><asp:Label ID="lblNombreArchivoascxvbDestino" runat="server"></asp:Label>
                </td>
	    </tr>
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">
                <span>Adjuntar Archivo :</span></td>
            <td class="textocontgris10bold" style="text-align:left;width:65%;">
                <asp:FileUpload ID="FileUpload3" runat="server" />
                <asp:Button ID="Button12" runat="server" Text="Save" CssClass="boxceleste" Height="20px" Width="80px" /> 
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            </td>
	    </tr>                        
 
    </table>
    </div>
 
    <table border="0" cellpadding="0" cellspacing="0" class="popups_titulo_con_enlaces">
        <tr>
            <td><h2>7.- Genera UserControl con la vista de atributos de la entidad Hija (Ficha 
                Entidad Hija)</h2></td>
            <td align="right"><img src="imgs/expandir.png" width="25" height="25" alt="Expandir" onclick="aparecer('subgrilla7')" /></td>
        </tr>
    </table>
    <div id="subgrilla7" class="invisible">
    <p>Este septimo paso permite generar los archivos ascx y ascx.vb asociadas a la mantención del los datos atomicos de una entidad del tipo Hija</p>
    <asp:BulletedList ID="BulletedList5" FirstBulletNumber="1" runat="server">
        <asp:ListItem>Genere el código fuente del archivo para la mantención de la tabla Hija (*.ascx)</asp:ListItem>
        <asp:ListItem>Hacer el upload del archivo al directorio de la Aplicación</asp:ListItem>
        <asp:ListItem>Genere el código fuente del archivo para la mantención de la tabla Hija (*.ascx.vb)</asp:ListItem>
        <asp:ListItem>Hacer el upload del archivo al directorio de la Aplicación</asp:ListItem>
    </asp:BulletedList>       
    <table cellspacing="2" cellpadding="2" border="0" style="background-color: WhiteSmoke;border-color:WhiteSmoke;border-width:1px;border-style:Solid;width:700px;">
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;"></td>
            <td valign="middle" style="width:65%;">

                <asp:Button ID="Button4" runat="server" Text="Grabar ArchivoNewDetailsascx" CssClass="boxceleste" Height="20px" Width="450px" />

                </td>
	    </tr>
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">
                <span>Nombre del Archivo Generado :</span></td>
            <td valign="middle" style="width:65%;">
                <asp:Label ID="LblNombreArchivoNewDetailsascx" runat="server"></asp:Label>
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="" 
                    Target="_blank">HyperLink</asp:HyperLink>
                </td>
	    </tr>
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">
                <span>Nombre del Archivo de Clase :</span></td>
            <td valign="middle" style="width:65%;">
                <asp:Label ID="LblNombreArchivoNewDetailsascxDestino" runat="server"></asp:Label>
                </td>
	    </tr>
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">
                <span>Adjuntar Archivo :</span></td>
            <td class="textocontgris10bold" style="text-align:left;width:65%;">

                <asp:FileUpload ID="FileUpload10" runat="server" />
                <asp:Button ID="Button24" runat="server" Text="Save" CssClass="boxceleste" Height="20px" Width="80px" />
                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>

            </td>
	    </tr>
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;"></td>
            <td valign="middle" style="width:65%;">

                <asp:Button ID="Button5" runat="server" Text="Grabar ArchivoNewDetailsascxvb" CssClass="boxceleste" Height="20px" Width="450px" />

                </td>
	    </tr>
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">
                <span>Nombre del Archivo Generado :</span></td>
            <td valign="middle" style="width:65%;">
                <asp:Label ID="lblNombreArchivoNewDetailsascxvb" runat="server"></asp:Label>
                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="" 
                    Target="_blank">HyperLink</asp:HyperLink>
                </td>
	    </tr>
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">
                <span>Nombre del Archivo de Clase :</span></td>
            <td valign="middle" style="width:65%;">
                <asp:Label ID="lblNombreArchivoNewDetailsascxvbDestino" runat="server"></asp:Label>
                </td>
	    </tr>
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">
                <span>Adjuntar Archivo :</span></td>
            <td class="textocontgris10bold" style="text-align:left;width:65%;">

                <asp:FileUpload ID="FileUpload11" runat="server" />
                <asp:Button ID="Button29" runat="server" Text="Save" CssClass="boxceleste" Height="20px" Width="80px"/>
                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>

            </td>
	    </tr>                        
 
    </table>
    </div>   
    
    <table border="0" cellpadding="0" cellspacing="0" class="popups_titulo_con_enlaces">
        <tr>
            <td><h2>8.- Genera UserControl con la vista de búsqueda de la entidad Padre (Busca)</h2></td>
            <td align="right"><img src="imgs/expandir.png" width="25" height="25" alt="Expandir" onclick="aparecer('subgrilla8')" /></td>
        </tr>
    </table>
    <div id="subgrilla8" class="invisible">
    <p>Este octavo paso permite generar los archivos ascx y ascx.vb asociadas a la definición del criterio de búsqueda de registros sobre la tabla Padre</p>
    <asp:BulletedList ID="BulletedList6" FirstBulletNumber="1" runat="server">
        <asp:ListItem>Genere el código fuente de la aplicación que solicita los campos que componen el criterio de búsqueda requerido por el usuario (*.ascx)</asp:ListItem>
        <asp:ListItem>Hacer el upload del archivo al directorio de la Aplicación</asp:ListItem>
        <asp:ListItem>Genere el código fuente de la aplicación que solicita los campos que componen el criterio de búsqueda requerido por el usuario (*.ascx.vb)</asp:ListItem>
        <asp:ListItem>Hacer el upload del archivo al directorio de la Aplicación</asp:ListItem>
    </asp:BulletedList>       
    <table cellspacing="2" cellpadding="2" border="0" style="background-color: WhiteSmoke;border-color:WhiteSmoke;border-width:1px;border-style:Solid;width:700px;">
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;"></td>
            <td valign="middle" style="width:65%;">
                <asp:Button ID="Button6" runat="server" Text="Generar ArchivoBuscaEntidadesascx"  CssClass="boxceleste" Height="20px" Width="450px" />
                </td>
	    </tr>
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">
                <span>Nombre del Archivo Generado :</span></td>
            <td valign="middle" style="width:65%;">
                <asp:Label ID="LblNombreArchivoBuscaEntidadesascx" runat="server"></asp:Label>
                <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="" 
                    Target="_blank">HyperLink</asp:HyperLink>
                </td>
	    </tr>
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">
                <span>Nombre del Archivo de Clase :</span></td>
            <td valign="middle" style="width:65%;">
                <asp:Label ID="LblNombreArchivoBuscaEntidadesascxDestino" runat="server"></asp:Label>
                </td>
	    </tr>
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">
                <span>Adjuntar Archivo :</span></td>
            <td class="textocontgris10bold" style="text-align:left;width:65%;">

                <asp:FileUpload ID="FileUpload4" runat="server" />
                <asp:Button ID="Button13" runat="server" Text="Save"  CssClass="boxceleste" Height="20px" Width="80px"/>             
                <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>

            </td>
	    </tr>
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;"></td>
            <td valign="middle" style="width:65%;">
                <asp:Button ID="Button7" runat="server" Text="Generar ArchivoBuscaEntidadesascxvb"  CssClass="boxceleste" Height="20px" Width="450px" />
                </td>
	    </tr>
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">
                <span>Nombre del Archivo Generado :</span></td>
            <td valign="middle" style="width:65%;">
                <asp:Label ID="lblNombreArchivoBuscaEntidadesascxvb" runat="server"></asp:Label>
                <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="" 
                    Target="_blank">HyperLink</asp:HyperLink>
                </td>
	    </tr>
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">
                <span>Nombre del Archivo de Clase :</span></td>
            <td valign="middle" style="width:65%;">
                <asp:Label ID="lblNombreArchivoBuscaEntidadesascxvbDestino" runat="server"></asp:Label>
                </td>
	    </tr>
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">
                <span>Adjuntar Archivo :</span></td>
            <td class="textocontgris10bold" style="text-align:left;width:65%;">

                <asp:FileUpload ID="FileUpload5" runat="server" />
                <asp:Button ID="Button14" runat="server" Text="Save"  CssClass="boxceleste" Height="20px" Width="80px"/>            
                <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>

            </td>
	    </tr>                        
 
    </table>
    </div>

    <table border="0" cellpadding="0" cellspacing="0" class="popups_titulo_con_enlaces">
        <tr>
            <td><h2>9.- Genera UserControl con la vista de validación de un nuevo código en la entidad Padre (Valida)</h2></td>
            <td align="right"><img src="imgs/expandir.png" width="25" height="25" alt="Expandir" onclick="aparecer('subgrilla9')" /></td>
        </tr>
    </table>
    <div id="subgrilla9" class="invisible">
    <p>Este noveno paso permite generar los archivos ascx y ascx.vb asociadas a la validación del código de un nuevo registro en la tabla Padre</p>
    <asp:BulletedList ID="BulletedList7" FirstBulletNumber="1" runat="server">
        <asp:ListItem>Genere el código fuente de la aplicación que solicita el código único del nuevo registro a crear en la tabla padre (*.ascx)</asp:ListItem>
        <asp:ListItem>Hacer el upload del archivo al directorio de la Aplicación</asp:ListItem>
        <asp:ListItem>Genere el código fuente de la aplicación que solicita el código único del nuevo registro a crear en la tabla padre (*.ascx.vb)</asp:ListItem>
        <asp:ListItem>Hacer el upload del archivo al directorio de la Aplicación</asp:ListItem>
    </asp:BulletedList>       
    <table cellspacing="2" cellpadding="2" border="0" style="background-color: WhiteSmoke;border-color:WhiteSmoke;border-width:1px;border-style:Solid;width:700px;">
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;"></td>
            <td valign="middle" style="width:65%;">

                <asp:Button ID="Button8" runat="server" Text="Generar ArchivoValidaEntidadesascx" CssClass="boxceleste" Height="20px" Width="450px"/>

                </td>
	    </tr>
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">
                <span>Nombre del Archivo Generado :</span></td>
            <td valign="middle" style="width:65%;">

                <asp:Label ID="LblNombreArchivoValidaEntidadesascx" runat="server"></asp:Label>
                <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="" 
                    Target="_blank">HyperLink</asp:HyperLink>

                </td>
	    </tr>
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">
                <span>Nombre del Archivo de Clase :</span></td>
            <td valign="middle" style="width:65%;">

                <asp:Label ID="LblNombreArchivoValidaEntidadesascxDestino" runat="server"></asp:Label>

                </td>
	    </tr>
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">
                <span>Adjuntar Archivo :</span></td>
            <td class="textocontgris10bold" style="text-align:left;width:65%;">


                <asp:FileUpload ID="FileUpload6" runat="server" />
                <asp:Button ID="Button15" runat="server" Text="Save" CssClass="boxceleste" Height="20px" Width="80px" />
                <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>


            </td>
	    </tr>
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;"></td>
            <td valign="middle" style="width:65%;">

                <asp:Button ID="Button9" runat="server" Text="Generar ArchivoBuscaEntidadesascxvb" CssClass="boxceleste" Height="20px" Width="450px"/>

                </td>
	    </tr>
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">
                <span>Nombre del Archivo Generado :</span></td>
            <td valign="middle" style="width:65%;">

                <asp:Label ID="lblNombreArchivoValidaEntidadesascxvb" runat="server"></asp:Label>
                <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="" 
                    Target="_blank">HyperLink</asp:HyperLink>

                </td>
	    </tr>
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">
                <span>Nombre del Archivo de Clase :</span></td>
            <td valign="middle" style="width:65%;">

                <asp:Label ID="lblNombreArchivoValidaEntidadesascxvbDestino" runat="server"></asp:Label>

                </td>
	    </tr>
        <tr valign="middle">
            <td class="textocontgris10bold" style="text-align:left;width:35%;">
                <span>Adjuntar Archivo :</span></td>
            <td class="textocontgris10bold" style="text-align:left;width:65%;">


                <asp:FileUpload ID="FileUpload7" runat="server" />
                <asp:Button ID="Button16" runat="server" Text="Save" CssClass="boxceleste" Height="20px" Width="80px"/>            
                <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>


            </td>
	    </tr>                        
 
    </table>
    </div>