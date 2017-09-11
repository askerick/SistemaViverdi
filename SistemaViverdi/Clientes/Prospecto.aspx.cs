using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;
using System.Web.Script.Services;
using Newtonsoft.Json;


namespace SistemaViverdi.Clientes
{
    public partial class Prospecto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }





        //*****************GUARDAR Y ACTUALIZAR***********************************+
        #region <<Guardar y Actualizar>>
        [WebMethod]
        //RECIBIMOS PARAMETROS PJDATA QUE VIENE EN FORMATO JSON CON TODAS LAS VARIABLES ***************
        public static string Guardar(Object pJData)
        {

            //**********************DECLARAMOS LAS VARIABLES QUE NECESITATREMOS************************+
            int IdCliente, IdVendedor, IdPublicidad, IdTipoPedido;
            string Nombre, Apellido, Correo, Celular, Empresa, Pais, Estado, Ciudad,
                Direccion, Comentarios, FormaPago;

          


            //************************DESERIABILIZAMOS PARA INVERTIR EL PJDATA DE JSON A ARRAY***************************+
            dynamic Data = JsonConvert.DeserializeObject(pJData.ToString());



            //************************ASIGNAMOS A CADA VARIABLE EL VALOR DEL ARRAY *****************************************
            IdCliente = Data[0]["IdCliente"];
            IdVendedor = Data[0]["IdVendedor"];
            IdPublicidad = Data[0]["IdPublicidad"];
            IdTipoPedido = Data[0]["IdTipoPedido"];
            Nombre = Data[0]["Nombre"];
            Apellido = Data[0]["Apellido"];
            Correo = Data[0]["Correo"];
            Celular = Data[0]["Celular"];
            Empresa = Data[0]["Empresa"];
            Pais = Data[0]["Pais"];

            Estado = Data[0]["Estado"];
            Ciudad = Data[0]["Ciudad"];
            Direccion = Data[0]["Direccion"];
            Comentarios = Data[0]["Comentarios"];
            FormaPago = Data[0]["FormaPago"];

            string mensaje = string.Empty;



            //*******************CREAMOS PARAMETROS QUE VAMOS AMANDAR A SQL, ASIGNAMOS SU VALOR Y TIPO DE DATO QUE ES ************************++
            dbo.BaseDatos db = null;
            SqlParameter prmIdCliente, prmIdVendedor, prmIdPublicidad, prmIdTipoPedido, prmNombre, prmApellido,
                prmCorreo,prmCelular,prmEmpresa,prmPais,prmEstado,prmCiudad,prmDireccion,prmComentarios,prmFormaPago;
            try
            {
                db = new dbo.BaseDatos(ConfigurationManager.ConnectionStrings["cnn"].ToString());
                prmIdCliente = new SqlParameter("@IdCliente", SqlDbType.BigInt);
                prmIdCliente.Value = IdCliente;
                prmIdVendedor = new SqlParameter("@IdVendedor", SqlDbType.BigInt);
                prmIdVendedor.Value = IdVendedor;
                prmIdPublicidad = new SqlParameter("@IdPublicidad", SqlDbType.BigInt);
                prmIdPublicidad.Value = IdPublicidad;
                prmIdTipoPedido = new SqlParameter("@IdTipoPedido", SqlDbType.BigInt);
                prmIdTipoPedido.Value = IdTipoPedido;
                prmNombre = new SqlParameter("@Nombre", SqlDbType.NVarChar, 50);
                prmNombre.Value = Nombre;
                prmApellido = new SqlParameter("@Apellido", SqlDbType.NVarChar, 50);
                prmApellido.Value = Apellido;

                prmCorreo = new SqlParameter("@Correo", SqlDbType.NVarChar, 50);
                prmCorreo.Value = Correo;
                prmCelular = new SqlParameter("@Celular", SqlDbType.NVarChar, 50);
                prmCelular.Value = Celular;
                prmEmpresa = new SqlParameter("@Empresa", SqlDbType.NVarChar, 50);
                prmEmpresa.Value = Empresa;
                prmPais = new SqlParameter("@Pais", SqlDbType.NVarChar, 50);
                prmPais.Value = prmPais;
                prmEstado = new SqlParameter("@Estado", SqlDbType.NVarChar, 50);
                prmEstado.Value = Estado;
                prmCiudad = new SqlParameter("@Ciudad", SqlDbType.NVarChar, 50);
                prmCiudad.Value = Ciudad;
                prmPais = new SqlParameter("@Pais", SqlDbType.NVarChar, 50);
                prmPais.Value = prmPais;
                prmDireccion = new SqlParameter("@Direccion", SqlDbType.NVarChar, 50);
                prmDireccion.Value = Direccion;
                prmComentarios = new SqlParameter("@Comentarios", SqlDbType.NVarChar, 50);
                prmComentarios.Value = Comentarios;
                prmFormaPago = new SqlParameter("@FormaPago", SqlDbType.NVarChar, 50);
                prmFormaPago.Value = FormaPago;

                //***************EJECUTAMOS INSTRUCION DE IR AL STORED PROCEDURE MANDANDO LOS PARAMETROS CORRESPONDIENTES**********************
                db.EjecutarInstruccion(dbo.BaseDatos.TipoEjecucion.NonQuery, "spac_Prospecto", prmIdCliente, prmIdVendedor, prmIdPublicidad, prmIdTipoPedido, prmNombre, prmApellido,
                prmCorreo, prmCelular, prmEmpresa, prmPais, prmEstado, prmCiudad, prmDireccion, prmComentarios, prmFormaPago);



                //
                db.FinalizarTransaccion();
                mensaje = "ok|";
            }
            catch (Exception ex)
            {
                mensaje = "error|" + ex.Message.ToString();
            }
            finally
            {

                // *******************RECIBIMOS VALORES QUE NOS REGRESA EL STORED PRODECURES Y SE REGRESA AL JAVA SCRIPT************+*******
                db.Finalizar();
            }
            return mensaje;
        }
        #endregion <<Guardar>>
    }
}