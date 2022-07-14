function openInNewWindow(frm)
{
	// open a blank window
	var aWindow = window.open("", "TableAddRowNewWindow",
	 'scrollbars=yes,menubar=yes,resizable=yes,toolbar=no,width=400,height=400');
	 
	// set the target to the blank window
	frm.target = "TableAddRowNewWindow";
	
	// submit
	frm.submit();
}

/*
Grilla editable
*/

function setAttribute(key, value) {
    var out = ' ' + key + '=\'' + value+ '\' ';

    return out;
}

// Crea un Input base
function createInput(name, type, readonly, disabled, extraKey, extraValue) {
    var input = "<input ";
    input += setAttribute("name", name);
    input += setAttribute("type", type);

    if (readonly) {
        input += ' readonly ';
    }
    if (disabled) {
        input += ' disabled ';
    }

    if (extraKey != null) {
        if ((extraKey.length > 0) && (extraValue.length == extraKey.length)) {
            for (var i=0; i<extraKey.length; i++) {
                input += setAttribute(extraKey[i], extraValue[i]);
            }
        }
    }

    return input;
}

// Crea un Input:text
function createText(name, size, value, maxLength, readonly, disabled, extraKey, extraValue) {
    var input = createInput(name, 'text', readonly, disabled, extraKey, extraValue);
    input += setAttribute('size', size);
    input += setAttribute('value', value);
    input += setAttribute('maxLength', maxLength);
    input += setAttribute('class', extraValue);

    input += ' />';

    return input;
}

// Crea un Input:password
function createPassword(name, size, value, maxLength, readonly, disabled, extraKey, extraValue) {
    var input = createInput(name, 'password', readonly, disabled, extraKey, extraValue);
    input += setAttribute('size', size);
    input += setAttribute('value', value);
    input += setAttribute('maxLength', maxLength);

    input += ' />';

    return input;
}


// Crea un Input:checkbox
function createCheckbox(name, value, checked, readonly, disabled, extraKey, extraValue) {
    var input = createInput(name, 'checkbox', readonly, disabled, extraKey, extraValue);
    input += setAttribute('value', value);
    if (checked) {
        input += setAttribute('checked', checked);
    }

    input += ' />';

    return input;
}


// Crea un Input:radio
function createRadio(name, value, checked, readonly, disabled, extraKey, extraValue) {
    var input = createInput(name, 'radio', readonly, disabled, extraKey, extraValue);
    input += setAttribute('value', value);
    if (checked) {
        input += setAttribute('checked', checked);
    }

    input += ' />';

    return input;
}

// Crea un Input:hidden
function createHidden(name, value, readonly, disabled, extraKey, extraValue) {
    var input = createInput(name, 'hidden', readonly, disabled, extraKey, extraValue);
    input += setAttribute('value', value);

    input += ' />';

    return input;
}

// Crea un Input:submit
function createSubmit(name, value, readonly, disabled, extraKey, extraValue) {
    var input = createInput(name, 'submit', readonly, disabled, extraKey, extraValue);
    input += setAttribute('value', value);

    input += ' />';

    return input;
}

// Crea un Input:button
function createButton(name, value, readonly, disabled, extraKey, extraValue) {
    var input = createInput(name, 'button', readonly, disabled, extraKey, extraValue);
    input += setAttribute('value', value);

    input += ' />';

    return input;
}


// Crea un Input:image
function createImage(name, value, src, readonly, disabled, extraKey, extraValue) {
    var input = createInput(name, 'image', readonly, disabled, extraKey, extraValue);
    input += setAttribute('value', value);
    input += setAttribute('src', src);

    input += ' />';

    return input;
}

// Crea un Select
function createSelect(name, arrOptions, readonly, disabled, extraKey, extraValue) {
    var select = '<select ';
    select += setAttribute("name", name);

    if (readonly) {
        select += setAttribute('readonly', 'readonly');
    }
    if (disabled) {
        select += setAttribute('disabled', 'disabled');
    }

    if (extraKey != null) {
        if ((extraKey.length > 0) && (extraValue.length == extraKey.length)) {
            for (var i=0; i<extraKey.length; i++) {
                select += setAttribute(extraKey[i], extraValue[i]);
            }
        }
    }

    select += ' >';


    for (var i=0; i<arrOptions.length; i++) {
        select += arrOptions[i];
    }

    select += '</select>';

    return select;
}


// Crea un Option
function createOption(value, text) {
    var option = '<option value=\'' + value + '\'>'+ text + '</option>';

    return option;
}

// Crea un label
function createLabel(text) {
    var textNode = text;

    return textNode;
}

// Crea un Link
function createLink(text, url, querystring, target, extraKey, extraValue) {
    var link = '<a ';
    var text = text;
    var lnk ;
    
    lnk = url ;
    if ( querystring != null && querystring != '' ) {
	    lnk = lnk + '?' + querystring ;
    }
    
    link += setAttribute('href', lnk ) ;
    link += setAttribute('target', target);

    if (extraKey != null) {
        if ((extraKey.length > 0) && (extraValue.length == extraKey.length)) {
            for (var i=0; i<extraKey.length; i++) {
                link += setAttribute(extraKey[i], extraValue[i]);
            }
        }
    }

    link += ' >';

    link += text;

    link += '</a>';

    return link;
}


// Crea una celda de una tabla con un control inicial
// @param control Control inicial contenido en la celda
// @param styleAlign Alineacion de la celda
// @param styleClass Clase CSS de la celda
function createTd(control, styleAlign, styleClass) {

    var arr = Array(3);
    arr[0] = control;
    arr[1] = styleAlign;
    arr[2] = styleClass;
    
    return arr;
}

// Agrega a una celda un control
// @param td Elemento tipo TD a la cual se le agregara el control
// @param control Control a agregar a la celda
function appendToTd(td, control) {

    td[0] = td[0] + control;

    return td;
}


// Retorna la fila de la tabla en la cual esta el elemento
// @param element Elemento de la fila
function getFila(element) {
    var td = element.parentNode; 
    while (td.tagName.toLowerCase() != "tr") {
        td = td.parentNode; 
    }
    return td.rowIndex; 
}


// Agrega un arreglo de celdas a una tabla
// @param idTabla Id de la tabla
// @param arrTd Arreglo con los TD de la tabla
// @param colSel Indica si se requiere columna de seleccion (true/false)
// @param removeRow Indica si se requiere boton borrar fila (true/false)
function addRowToTable(idTable, arrTd, colSel, removeRow, classColSel) {
    var tbl = document.getElementById(idTable);

    var lastRow = tbl.rows.length;
    // if there's no header row in the table, then iteration = lastRow + 1
    var iteration = lastRow;
    var row = tbl.insertRow(lastRow);

    // Definicion de un Checkbox de accion
    if (colSel) {
        var extraKey   = new Array(1);
        var extraValue = new Array(1);
        extraKey[0]   = 'id';
        extraValue[0] = idTable + '_checkboxsel';
        var checkboxSel = createCheckbox(idTable + '_checkboxSel', iteration, false, false, false, extraKey, extraValue);
        //if (classColSel == null) {classColSel='';}
        var arrTdSel = createTd(checkboxSel, 'center', classColSel);
        var tdSel = document.createElement("TD");
        tdSel.align = arrTdSel[1];
        tdSel.innerHTML = arrTdSel[0];
        if (arrTdSel[2] != null && arrTdSel[2] != '') {
        	tdSel.className = arrTdSel[2];
        }	
        row.appendChild(tdSel);
    }



    // Inserto las celdas
    for (var i=0; i<arrTd.length; i++) {
        var td = document.createElement("TD");
        var arr = arrTd[i];
        if (arr) {
            td.innerHTML = arr[0]; //El control
            if (arr != '') 
                td.align = arr[1];
            if (arr != '')
               td.className = arr[2];
            
        } else {
            td.innerHTML = '';
        }
        row.appendChild(td);
    }
    
    if (removeRow) {
        var extraKey = Array(1);
        var extraValue = Array(1);
        extraKey[0] = 'onclick';
        extraValue[0] = 'javascript:removeMe("' + idTable + '", eval("this.parentNode.parentNode.rowIndex"));';
        var bttnRemove = createButton('button', 'X', false, false, extraKey, extraValue);
        var arrTd = createTd(bttnRemove, 'center', '');
        var elTd = document.createElement("TD");
        elTd.align=arrTd[1];
        elTd.innerHTML = arrTd[0];
        row.appendChild(elTd);
    }
}


// Borra la ultima fila de la tabla
function removeLastRowFromTable(tbl)
{
var tbl = document.getElementById(tbl);
var lastRow = tbl.rows.length;
if (lastRow > 2) tbl.deleteRow(lastRow - 1);
}


// Borra una fila especifica
function removeMe(tbl, rowIndex) {
    document.getElementById(tbl).deleteRow(rowIndex)
}

// Borra filas seleccionadas en la columna 'idTable + _checkboxSel'
// No aplica si checkboxSel es false en addRowToTable.
function removeSel(form, idTable) {
    var tbl = document.getElementById(idTable);
    var rowDel = 0;

    var arrCombo = new Array();

    for(var i=0; i<form.length; i++) { 
        if ((form.elements[i].type == 'checkbox') && (form.elements[i].name == (idTable + '_checkboxSel'))) { 
            if (form.elements[i].checked == true) {
                arrCombo[rowDel] = form.elements[i].value;
                rowDel++;
            }
            else {
                if (rowDel > 0) {
                    form.elements[i].value = form.elements[i].value - rowDel;
                }
            }
        }
    }

    rowDel = 0;
    for (var i=0; i<arrCombo.length; i++) {
        tbl.deleteRow(arrCombo[i] - rowDel);
        rowDel++;
    }
  if (rowDel > 0) {
   return true;
  } else {
   return false;
  }
}


// Borra filas seleccionadas en la columna de name control
// y agrega un control de tipo hidden de nombre controlDel
// permitiendo obtener en un arreglo los controles eliminados
function removeRowSelFixed(form, idTable, controlChk, controlDel) {

  var rowDel = 0;
  var arrCombo = new Array();  
  var arrHid = new Array();
 
  for(var i=0; i<form.length; i++) { 
   if ((form.elements[i].type == 'checkbox') && (form.elements[i].name == controlChk)) { 
       if (form.elements[i].checked == true) {
           var rowIndex = getFila(form.elements[i]) ;        
           arrCombo[rowDel] = rowIndex;    
           var control = createHidden(controlDel, form.elements[i].value, false, false);
           arrHid[rowDel] = control;
           rowDel++;
       }
       else {
           if (rowDel > 0) {
               form.elements[i].value = form.elements[i].value - rowDel;
           }
       }
   }
  }

  for (var i=0; i<arrHid.length; i++) {
     form.innerHTML = form.innerHTML + arrHid[i];
  }

  rowDel = 0;
  for (var i=0; i<arrCombo.length; i++) {   
   removeMe(idTable, arrCombo[i]- rowDel);   
   rowDel++;
  }
 
  if (rowDel > 0) {
   return true;
  } else {
   return false;
  }
}

// Retorna un arreglo con los valores de un control contenido en una grilla
// @param idTable id de la tabla
// @param name nombre del control a obtener los valores
function getValueOf(idTable, name) {
    var tbl = document.getElementById(idTable);

    var nRow = tbl.rows.length;

    var arr = new Array();

    var nVal = 0;

    for (var i=0; i<nRow; i++) {
        var row = tbl.rows[i];
        var nCell = row.cells.length;
        for (var j=0; j<nCell; j++) {
            var nChild = row.cells[j].childNodes.length;
            for (var k=0; k<nChild; k++) {
                if (row.cells[j].childNodes[k].name == name) {
                   arr[nVal] = row.cells[j].childNodes[k].value;
                   nVal++;
                }
            }
        }
    }

    return arr;

}


// Asigna el value al control name de la fila nRow de la tabla idTable
// @param idTable id de la tabla
// @param nRow Nro de fila
// @param name Nombre del control
// @param value Valor del control
function setValue(idTable, nRow, name, value) {
    var tbl = document.getElementById(idTable);

    var maxRow = tbl.rows.length;

    var row = tbl.rows[nRow];
    
    var control = null;

    var nCell = row.cells.length;
    for (var j=0; j<nCell; j++) {
        var nChild = row.cells[j].childNodes.length;
        for (var k=0; k<nChild; k++) {
            if (row.cells[j].childNodes[k].name == name) {
                row.cells[j].childNodes[k].value = value;
                control = row.cells[j].childNodes[k];
            }
        }
    }

    return control;
}


// Retorna el value del control name de la fila nRow de la tabla idTable
// @param idTable id de la tabla
// @param nRow Nro de fila
// @param name Nombre del control
function getValue(idTable, nRow, name) {
    var tbl = document.getElementById(idTable);

    var maxRow = tbl.rows.length;

    var row = tbl.rows[nRow];
    
    var value = null;

    var nCell = row.cells.length;
    for (var j=0; j<nCell; j++) {
        var nChild = row.cells[j].childNodes.length;
        for (var k=0; k<nChild; k++) {
            if (row.cells[j].childNodes[k].name == name) {
                value = row.cells[j].childNodes[k].value;
            }
        }
    }

    return value;
}

// Reemplaza un control name por un nuevo control
// @param idTable id de la tabla
// @param nRow Nro de fila
// @param name Nombre del control
// @param control Nuevo Control
function replaceControl(idTable, nRow, name, control) {
    var tbl = document.getElementById(idTable);

    var maxRow = tbl.rows.length;

    var row = tbl.rows[nRow];
    
    var value = null;

    var nCell = row.cells.length;
    
    var cellN = null;
    var nNode = null;
    
    for (var j=0; j<nCell; j++) {
        var nChild = row.cells[j].childNodes.length;
        for (var k=0; k<nChild; k++) {
            if (row.cells[j].childNodes[k].name == name) {
                cellN = j;
                nNode = k;
            }
        }
    }

    if (nNode != null) {
        row.cells[cellN].removeChild(row.cells[cellN].childNodes[nNode]);
        row.cells[cellN].innerHTML = row.cells[cellN].innerHTML + control;
    }

    return value;
}


// Para eliminar la paginacion de una celda
// Puede eliminar el contenido de cualquier celda.
// @param idTable id de la tabla que contiene la paginacion.
// @param idTd id de la celda que contiene la paginacion.
// @param inHtml texto que reemplazara la paginacion, si es null reemplaza un &nbsp;
function removePagination(idTable, idTd, inHtml) {
    var tbl = document.getElementById(idTable);

    var maxRow = tbl.rows.length;

    
    var cellN = null;
    var rowN = null;    

    if (inHtml == null) {
        inHtml = "&nbsp;";
    }

    for (var i=0; i<maxRow; i++) {
        var row = tbl.rows[i];
        var nCell = row.cells.length;
        for (var j=0; j<nCell; j++) {
            var nChild = row.cells[j].childNodes.length;
            if (row.cells[j].id == idTd) {
                cellN = j;
                rowN = i;
            }
        }
    }

    if (cellN != null && rowN != null) {
        tbl.rows[rowN].cells[cellN].innerHTML = inHtml
    }

}

// Crea un Option con selected
function createOptionS(value, text) {
    var option = '<option value=\'' + value + '\' selected>'+ text + '</option>';
 
    return option;
}

