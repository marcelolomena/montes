function ValidaCampo(campo,txt) { 
//alert(campo);
//alert(txt);
var caracter 
var caracteres = " abcdefghijklmnopqrstuvwxyzÒABCDEFGHIJKLMNOPQRSTUVWXYZ—·ÈÌÛ˙¡…Õ”⁄1234567890*/+-()%$#!°ø?.:,;" + String.fromCharCode(13) + String.fromCharCode(10) //en esta variable se guardaran todos los caracteres que pueden ser aceptados, la funcion String.fromCharCode(13) nos devuelve el caracter que en codigo se representa por un 13 en este caso el 13 representa un enter.
var contador = 0
		for (var i=0; i < campo.length; i++) { //creamos un ciclo para recorrer caracter por caracter la palabra		contenida en la variable campo
		caracter = campo.substring(i, i + 1) //con la funcion substring obtenemos el caracter de la posicion i de la palabra a validar
			
			if (caracteres.indexOf(caracter) != -1) {//lo que hacemos aqui es buscar si el caracter contenido en la variable caracter se encuentra en la palabra caracteres ,esto a traves de la funcion indexOf la cual detecta si en una frase o cadena existe un valor o palabra identica. si es asi nos devuelve el indice que indica la pocicion donde lo encontro, si no lo encuentra nos manda un numero negativo.
				contador++
			} else {
				    alert("ERROR: Esta tratando de ingrasar valores no permitidos");
				//	alert("ERROR: Esta tratando de ingrasar valores no permitidos --------->" + caracter +"<--------");
					document.getElementById(txt).value="";
					document.getElementById(txt).focus();
					return false
			}

		}
		//alert("Datos correctos.")
		return true

}
