function guardarProspecto() {

    var IdCliente = -1;


   
    var Nombre = $('#txtNombre').val();
    var Apellido = $('#txtNombre').val();
    var Correo = $('#txtCorreo').val();
    var Celular = $('#txtCelular').val();
    var Empresa = $('#txtEmpresa').val();
    var Pais = $('#cboPais').val();
    var Estado = $('#cboEstado').val();
    var Ciudad = $('#txtCiudad').val();
    var Direccion = $('#txtCiudad').val();
    var Comentarios = $('#txtComentarios').val();

    var IdVendedor = $('#cboVendedor').val();
    var IdPublicidad = $('#cboPublicidad').val();
    var IdTipoPedido = $('#cboTipoPedido').val();
    var FormaPago = $('#txtFormaPago').val();

    var pJData = [];

    pJData.push({
        IdCliente: IdCliente,
        Nombre: Nombre,
        Apellido: Apellido,
        Correo: Correo,
        Celular: Celular,
        Empresa: Empresa,
        Pais: Pais,
        Estado: Estado,
        Ciudad: Ciudad,
        Direccion: Direccion,
        Comentarios: Comentarios,
        IdVendedor: IdVendedor,
        IdPublicidad: IdPublicidad,
        IdTipoPedido: IdTipoPedido,
        FormaPago: FormaPago

        
    })

    pJData = JSON.stringify(pJData);


    $.ajax({
        type: "POST",
        url: "Prospecto.aspx/Guardar",
        data: JSON.stringify({ pJData: pJData }),
        async: false,
        cache: false,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            var res = result.d.split("|");
            if (result.d) {
                if (res[0] == 'ok') {
                    //alert('ok')
                    window.location.assign("listadoProducto.aspx");
                } else {
                    alert(res[1]);
                }
            }
        },
        error: function (result) {
            alert("No pasaron");
            alert(postData);
        }
    });

}