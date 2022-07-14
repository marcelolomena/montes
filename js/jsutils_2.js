// ======================================================
// Libreria de Funciones utilitarias en JavaScript
// Version 2
// ======================================================

// Esteblece una fecha (popUp)
    function calendario(nom, control, form1)
    {
        addCalendar(nom, "Seleccione Fecha", control, form1);
        showCal(nom);
    }
////////////////////////////////////////////////////////////////////
// Establece la fecha minima a admitir
	function f_fechaBase()
    {
		return ("01/01/1900");
	}
////////////////////////////////////////////////////////////////////
// Retorna la fehca de hoy
	function f_fechaHoy()
    {
		var today = new Date();
		var dia = today.getDate();
		var mes = today.getMonth() + 1;
		var ano = today.getFullYear();
		if (dia < 10)
			dia = "0" + dia;
		if (mes < 10)
			mes = "0" + mes;

		return (dia + '/' + mes + '/' + ano);
	}
////////////////////////////////////////////////////////////////////
// Valida (fechaDesde < fechaHasta) y que ambas fechas sean validas
	function f_validarDesdeHasta(fechaDesde, fechaHasta, nomXSubmit)
    {
		// Se validan ambas fechas de forma separada
		if ((revisaFechaLim(fechaDesde.value, f_fechaBase(), fechaDesde.value)) && (revisaFechaLim(fechaHasta.value, f_fechaBase(), f_fechaHoy())))
		{
			// Se valida que fechaDesde no sea superior a fechaHasta
			if (revisaFechaLim(fechaDesde.value, f_fechaBase(), fechaHasta.value))
				return true;
			else
				alert("Fecha Desde no puede ser superior a Fecha Hasta");
		}
		else
			alert("Fechas err\u00F3neas.\nRecuerde que 'dd/mm/aaaa' no puede superar " +  f_fechaHoy());
    }
////////////////////////////////////////////////////////////////////
// Deshabilita elementos de una pagina html
function deshabElemento(nombre, deshabilitar)
{
	for (var i = 0; i < document.forms[0].elements.length; i++)
	{
		if (document.forms[0].elements[i].value == nombre)
			document.forms[0].elements[i].disabled = deshabilitar;
	}
}
