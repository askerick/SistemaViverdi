using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ClsLoginNamespace
{
    public class clsLogin
    {
        public clsLogin() { }

        Boolean mAutenticado;
        Int64 mIdUsuario;
        string mUsuario;
        string mNombreUsuario;
        //Int64 mIdPerfil;
        string mPerfil;
        Int64 mIdSucursal;
        //Int64 mIdVendedor;
        //Int32 mEsLocal;
        Int64 mIdCorporativo;

        #region " PROPIEDADES "
        public Boolean Autenticado
        {
            get
            {
                return mAutenticado;
            }
            set
            {
                mAutenticado = value;
            }
        }

        public Int64 IdUsuario
        {
            get
            {
                return mIdUsuario;
            }
            set
            {
                mIdUsuario = value;
            }
        }

        public string Usuario
        {
            get
            {
                return mUsuario;
            }
            set
            {
                mUsuario = value;
            }
        }

        public string NombreUsuario
        {
            get
            {
                return mNombreUsuario;
            }
            set
            {
                mNombreUsuario = value;
            }
        }

        public string Perfil
        {
            get
            {
                return mPerfil;
            }
            set
            {
                mPerfil = value;
            }
        }

        //public Int64 IdPerfil
        //{
        //    get
        //    {
        //        return mIdPerfil;
        //    }   
        //    set
        //    {
        //        mIdPerfil = value;
        //    }
        //}        

        public Int64 IdSucursal
        {
            get
            {
                return mIdSucursal;
            }
            set
            {
                mIdSucursal = value;
            }
        }

        public Int64 IdCorporativo
        {
            get
            {
                return 1;   // mIdCorporativo;
            }
            set
            {
                mIdCorporativo = value;
            }
        }
        #endregion

        public void Autenticar(string Usuario, string Password)
        {
            dbo.BaseDatos db;
            DataTable dt = null;
            SqlParameter prmUser, prmPwd;

            try
            {
                db = new dbo.BaseDatos(ConfigurationManager.ConnectionStrings["cnn"].ToString());
                dt = new DataTable();

                prmUser = new SqlParameter("@Usuario", SqlDbType.VarChar, 15);
                prmUser.Value = Usuario;
                prmPwd = new SqlParameter("@Pwd", SqlDbType.VarChar, 15);
                prmPwd.Value = Password;

                dt = db.ObtenerDatosComoDataTable("spq_Login", prmUser, prmPwd);

                if (dt.Rows.Count > 0)

                    CargarInformacion(dt);
                else
                    LimpiarInformacion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dt.Dispose();
            }
        }

        private void CargarInformacion(DataTable dtInformacion)
        {
            mAutenticado = true;
            //mIdUsuario = ((Int32)dtInformacion.Rows[0]["IdUsuario"]);
            //mUsuario = ((string)dtInformacion.Rows[0]["Usuario"]);
            //mNombreUsuario = ((string)dtInformacion.Rows[0]["Nombre"]);
            //mPerfil = ((string)dtInformacion.Rows[0]["Perfil"]);
            //mIdCorporativo = ((Int32)dtInformacion.Rows[0]["IdCorporativo"]);
            //mIdPerfil = ((Int64)dtInformacion.Rows[0]["IdPerfil"]);
            //mIdVendedor = ((Int64)dtInformacion.Rows[0]["IdVendedor"]);
            //mEsLocal = ((Int32)dtInformacion.Rows[0]["EsLocal"]);  
        }

        private void LimpiarInformacion()
        {
            mAutenticado = false;
            mIdUsuario = -1;
            mUsuario = "";
            mNombreUsuario = "";
            //mIdPerfil = -1;
            mPerfil = "";
            mIdSucursal = -1;
            mIdCorporativo = -1;
            //mIdVendedor = -1;
            //mEsLocal = 0;
        }

    }

}