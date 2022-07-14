// Archivo JScript

function handleUpdateFuncion(id) {

    // set values ...
    
    // call webservice (getone)

    ZRISMART.NET.CintacDataBroker.set_defaultSucceededCallback(handleCallbackFuncionSave);
    ZRISMART.NET.CintacDataBroker.DependenciaCargoUpdate(id,$get("txtNuevoCargoSuperiorId").value);
    
    }

function handleGetFuncion(value,id) {
    
    // call webservice (getone)
    $get("txtDependenciaActual").value = value;    
    // $get("txtNuevoCargoSuperiorId").value = id;
    
    }

    function handleGetHoja(value, id) {

        // call webservice (getone)
        $get("txtDependenciaActual").value = value;
        $get("txtMenuOptionsId").value = id;

    }

    function handleGetAmbito(value, id) {

        // call webservice (getone)
        $get("txtAmbito").value = value;
        // $get("txtNuevoCargoSuperiorId").value = id;

    }

    function handleGetGrupos(value, id) {

        // call webservice (getone)
        $get("txtGrupo").value = value;
        // $get("txtNuevoCargoSuperiorId").value = id;

    }

function handleGetDocumento(value, id) {

        // call webservice (getone)
        $get("txtDependenciaPropuesta").value = value;
        $get("txtNuevoCargoSuperiorId").value = id;

    }

function handleCallbackFuncionSave() {

    window.returnValue = $get("txtDependenciaPropuesta").value;
    event.returnValue = true;
    window.close();

}


function handleGetDocumentoFromModalList(value, id) {

    // call webservice (getone)
    var j = new Array(1);
    j[0] = value;
    j[1] = id;
    window.returnValue = j;
    //alert(j[0] + " " + j[1]);
    //var respuesta = JSON.stringify(j);
    // alert(respuesta);
    //window.opener.postMessage(j, "*");
    window.close();


}

function handleUpdateTareas(value) {

    window.returnValue = value;
    event.returnValue = true;
    window.close();

}