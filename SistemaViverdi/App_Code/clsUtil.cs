using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.InteropServices;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Globalization;
using System.Security.Cryptography;

using System.Configuration;
using System.Data;


    public class clsUtil
    {
        public static string FormatoCadenaXML(string RutaXML)
        {
            string archivoXML = RutaXML;
            string cadena = "";
            try
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(archivoXML);
                cadena = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cadena;
        }
        public static string Hash(string ToHash)
        {
            // Use UTF8 encoder
            Encoder enc = System.Text.Encoding.UTF8.GetEncoder();

            // Create a buffer and convert
            byte[] data = new byte[ToHash.Length];
            enc.GetBytes(ToHash.ToCharArray(), 0, ToHash.Length, data, 0, true);

            // Implementation the SHA1 compute
            using (SHA1 sha1 = new SHA1CryptoServiceProvider())
            {
                byte[] result = sha1.ComputeHash(data);
                return BitConverter.ToString(result).Replace("-", "").ToLower();
            }
        }
    #region << Liberar recursos >>
    private Boolean disposed;
    public void Dispose()
    {
        this.Dispose(true);
        // GC.SupressFinalize quita de la cola de finalización al objeto.
        GC.SuppressFinalize(this);
    }




    protected virtual void Dispose(bool disposing)
    {
        // Preguntamos si Dispose ya fue llamado.
        if (!this.disposed)
        {
            if (disposing)
            {
                // Llamamos al Dispose de todos los RECURSOS MANEJADOS.
                //this.componentes.Dispose();
                //this.dataSetDisposable.Dispose();
            }
            // Acá finalizamos correctamente los RECURSOS NO MANEJADOS
            // ...

        }
        this.disposed = true;
    }
    ~clsUtil()
    {
        this.disposed = true;
    }
    #endregion





    public static string EnviarEmail(string FromEmail, string pPassword, string pTo, string pSubject, string pBody,
        string pAttachmentPath, string pCC, string pCCO, string strSMTP, int Port, Boolean EnableSsl)
    {
        string mensaje = string.Empty;
        try
        {
            MailMessage msg = new MailMessage();
            string[] sCorreos;
            sCorreos = pTo.Split((",").ToCharArray());
            if (sCorreos.Length == 0 && pTo != "")
            {
                msg.To.Add(new MailAddress(pTo));
            }
            else
            {
                char[] delimit = new char[] { ',' };
                foreach (string enviar_a in pTo.Split(delimit))
                {
                    if (enviar_a.Trim() != "")
                        msg.To.Add(new MailAddress(enviar_a));
                }
            }

            msg.From = new MailAddress(FromEmail);
            msg.Subject = pSubject;
            msg.Body = pBody.ToString();
            msg.IsBodyHtml = true;

            if (pCC.Trim() != "")
                msg.CC.Add(pCC);
            if (pCCO.Trim() != "")
                msg.Bcc.Add(pCCO);

            if (pAttachmentPath.Trim() != "")
            {
                //System.Net.Mail.Attachment MyAttachment = new Attachment(pAttachmentPath);                    
                char[] delimit = new char[] { ',' };
                foreach (string archivo_a in pAttachmentPath.Split(delimit))
                {
                    if (archivo_a.Trim() != "")
                    {
                        System.Net.Mail.Attachment MyAttachment = new Attachment(archivo_a);
                        msg.Attachments.Add(MyAttachment);
                        //msg.Attachments.Add(MyAttachment);
                        //msg.Priority = MailPriority.High;
                    }
                }
                msg.Priority = MailPriority.High;
            }

            SmtpClient clienteSmtp = new SmtpClient(strSMTP.Trim());
            clienteSmtp.Host = "mail.souvenir.com.mx";
            clienteSmtp.Port = 587;
            clienteSmtp.Credentials = new NetworkCredential(FromEmail, pPassword);
            clienteSmtp.EnableSsl = true;
            clienteSmtp.Send(msg);
            mensaje = "ok|";
           
        }
        catch (Exception ex)
        {
            mensaje = "error|" + ex.Message.ToString();
        }
        return mensaje;
    }





    public static string FormatoCaracter(string cadena)
        {
            /*cadena = cadena.Replace("Ã±", "ñ");
            cadena = cadena.Replace("Ã¡", "á");
            cadena = cadena.Replace("Ã©", "é");
            cadena = cadena.Replace("Ã*", "í");
            cadena = cadena.Replace("Ã³", "ó");
            cadena = cadena.Replace("Ãº", "ú");*/

            byte[] bytes = Encoding.GetEncoding(1252).GetBytes(cadena);
            string formato = Encoding.UTF8.GetString(bytes);
            return formato;
        }
        public static string FormatoComas(string sTotal)
        {
            decimal i;
            decimal moneda;
            string s = string.Empty;

            s = sTotal;
            bool num = decimal.TryParse(sTotal, out i);
            if (num)
            {
                CultureInfo Cult = new CultureInfo("es-MX");
                moneda = decimal.Parse(sTotal);
                s = moneda.ToString("c", Cult).ToString();
                //s = s.Replace(".00", "");
                s = s.Replace("$", "");
            }
            return s;
        }
        public static string ImporteConLetra(float Importe)
        {
            string Letra = string.Empty;
            //clsGeneral obj = null;
            //try
            //{
            //    obj = new clsGeneral();
            //    Letra = obj.ObtenerImporteConLetra(Importe);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //finally
            //{
            //    obj.Dispose();
            //}
            return Letra;
        }

        public static string IdiomaActual(string Idioma)
        {
            string culture = string.Empty;
            switch (Idioma)
            {
                case "en":
                    culture = "en-US";
                    break;
                case "es":
                    culture = "es-MX";
                    break;
                default:
                    culture = "en-US";
                    break;
            }

            return culture;
        }

        public static string FechaActualIdioma(string Idioma)
        {
            string dia = DateTime.Now.Day.ToString();
            string mes = DateTime.Now.Month.ToString();
            string anio = DateTime.Now.Year.ToString();
            string Fecha = "";

            if (dia.Length == 1)
                dia = "0" + dia;
            if (mes.Length == 1)
                mes = "0" + mes;
            Fecha = dia + "/" + mes + "/" + anio;


            return Fecha;
        }
        public static string FormatoFecha(string Fecha)
        {
            Fecha = Fecha.Substring(0, 10);
            Fecha = Fecha.Substring(6, 4) + Fecha.Substring(3, 2) + Fecha.Substring(0, 2);
            return Fecha;
        }
        public static string FormatoFechaHora(string Fecha, string Hora)
        {
            Fecha = Fecha.Substring(0, 10);
            Fecha = Fecha.Substring(6, 4) + "-" + Fecha.Substring(3, 2) + "-" + Fecha.Substring(0, 2) + "T" + Hora;
            return Fecha;
        }
        public static string FormatoFechaSinHora(string Fecha)
        {
            Fecha = Fecha.Substring(0, 10);
            Fecha = Fecha.Substring(6, 4) + "-" + Fecha.Substring(3, 2) + "-" + Fecha.Substring(0, 2);
            return Fecha;
        }
        //public static string GenerarPDF_EnDisco(string stored, string nomtb, string rpt, string stored2, string nomtb2)
        //{
        //    string Reporte;
        //    string FName = string.Empty;
        //    DataSet ds = new DataSet();
        //    DataTable DT = new DataTable();
        //    try
        //    {
        //        string PathEnviar = "C:\\WINDOWS\\Temp";
        //        int NumAleatorio;
        //        Random random = new Random();
        //        NumAleatorio = random.Next(1000000, 9999999);
        //        FName = PathEnviar + "\\Rep_" + NumAleatorio + ".pdf";

        //        DT = ObtenerTablaDeQuery(stored);
        //        DT.TableName = nomtb;
        //        Reporte = HttpContext.Current.Server.MapPath(rpt).Replace("\\", "\\\\");
        //        ds.Tables.Add(DT);

        //        if (stored2.ToString().Length > 0)
        //        {
        //            DT = new DataTable();
        //            DT = ObtenerTablaDeQuery(stored2);  //"exec spq_RecepcionOrdenCompraDetalleIndirecto 19"
        //            DT.TableName = nomtb2; //"tblRecepcionOrdenCompraDetalleIndirecto";
        //            ds.Tables.Add(DT);
        //        }

        //        ReportDocument cr = new ReportDocument();
        //        string ReportPath = Reporte;
        //        cr.Load(ReportPath);
        //        cr.SetDataSource(ds);
        //        cr.Refresh();
        //        cr.ExportToDisk(ExportFormatType.PortableDocFormat, FName);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return FName;
        //}


        //public static string GenerarExcel_EnDisco(string stored, string nomtb, string rpt, string stored2, string nomtb2)
        //{
        //    string Reporte;
        //    string FName = string.Empty;
        //    DataSet ds = new DataSet();
        //    DataTable DT = new DataTable();
        //    try
        //    {
        //        string PathEnviar = "C:\\WINDOWS\\Temp";
        //        int NumAleatorio;
        //        Random random = new Random();
        //        NumAleatorio = random.Next(1000000, 9999999);
        //        FName = PathEnviar + "\\Rep_" + NumAleatorio + ".xls";

        //        DT = ObtenerTablaDeQuery(stored);
        //        DT.TableName = nomtb;
        //        Reporte = HttpContext.Current.Server.MapPath(rpt).Replace("\\", "\\\\");
        //        ds.Tables.Add(DT);

        //        if (stored2.ToString().Length > 0)
        //        {
        //            DT = new DataTable();
        //            DT = ObtenerTablaDeQuery(stored2);  //"exec spq_RecepcionOrdenCompraDetalleIndirecto 19"
        //            DT.TableName = nomtb2; //"tblRecepcionOrdenCompraDetalleIndirecto";
        //            ds.Tables.Add(DT);
        //        }

        //        ReportDocument cr = new ReportDocument();
        //        string ReportPath = Reporte;
        //        cr.Load(ReportPath);
        //        cr.SetDataSource(ds);
        //        cr.Refresh();
        //        cr.ExportToDisk(ExportFormatType.Excel, FName);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return FName;
        //}

        //public static string GenerarPDF_Array_EnDisco(string[] stored, string[] nomtb, string rpt)
        //{
        //    string Reporte;
        //    string FName = string.Empty;
        //    DataSet ds = new DataSet();
        //    DataTable DT = null;
        //    try
        //    {
        //        string PathEnviar = "C:\\WINDOWS\\Temp";
        //        int NumAleatorio;
        //        Random random = new Random();
        //        NumAleatorio = random.Next(1000000, 9999999);
        //        FName = PathEnviar + "\\Rep_" + NumAleatorio + ".pdf";
        //        Reporte = HttpContext.Current.Server.MapPath(rpt).Replace("\\", "\\\\");

        //        for (int i = 0; i < stored.Length; i++)
        //        {
        //            DT = new DataTable();
        //            DT = ObtenerTablaDeQuery(stored[i]);
        //            DT.TableName = nomtb[i];
        //            ds.Tables.Add(DT);
        //        }

        //        ReportDocument cr = new ReportDocument();
        //        string ReportPath = Reporte;
        //        cr.Load(ReportPath);
        //        cr.SetDataSource(ds);
        //        cr.Refresh();
        //        cr.ExportToDisk(ExportFormatType.PortableDocFormat, FName);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return FName;
        //}

        //public static string GenerarPDF_EnDiscoDesdeTabla(DataTable DT, string nomtb, string rpt)
        //{
        //    string Reporte;
        //    string FName = string.Empty;
        //    DataSet ds = new DataSet();
        //    //DataTable DT = new DataTable();
        //    DataTable dtEstructura = new DataTable();
        //    try
        //    {
        //        dtEstructura = DT;

        //        string PathEnviar = "C:\\WINDOWS\\Temp";
        //        int NumAleatorio;
        //        Random random = new Random();
        //        NumAleatorio = random.Next(1000000, 9999999);
        //        FName = PathEnviar + "\\Rep_" + NumAleatorio + ".pdf";

        //        //DT = ObtenerTablaDeQuery(stored);
        //        dtEstructura.TableName = nomtb;
        //        Reporte = HttpContext.Current.Server.MapPath(rpt).Replace("\\", "\\\\");
        //        ds.Tables.Add(dtEstructura.Copy());


        //        ReportDocument cr = new ReportDocument();
        //        string ReportPath = Reporte;
        //        cr.Load(ReportPath);
        //        cr.SetDataSource(ds);
        //        cr.Refresh();
        //        cr.ExportToDisk(ExportFormatType.PortableDocFormat, FName);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        dtEstructura.Dispose();
        //    }
        //    return FName;
        //}
        //public static string GenerarExcel_EnDiscoDesdeTabla(DataTable DT, string nomtb, string rpt)
        //{
        //    string Reporte;
        //    string FName = string.Empty;
        //    DataSet ds = new DataSet();
        //    DataTable dtEstructura = new DataTable();
        //    try
        //    {
        //        dtEstructura = DT;

        //        string PathEnviar = "C:\\WINDOWS\\Temp";
        //        int NumAleatorio;
        //        Random random = new Random();
        //        NumAleatorio = random.Next(1000000, 9999999);
        //        FName = PathEnviar + "\\Rep_" + NumAleatorio + ".xls";

        //        //DT = ObtenerTablaDeQuery(stored);
        //        dtEstructura.TableName = nomtb;
        //        Reporte = HttpContext.Current.Server.MapPath(rpt).Replace("\\", "\\\\");
        //        ds.Tables.Add(dtEstructura);

        //        ReportDocument cr = new ReportDocument();
        //        string ReportPath = Reporte;
        //        cr.Load(ReportPath);
        //        cr.SetDataSource(ds);
        //        cr.Refresh();
        //        cr.ExportToDisk(ExportFormatType.Excel, FName);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        dtEstructura.Dispose();
        //    }
        //    return FName;
        //}






        public static DataTable ObtenerTablaDeQuery(string query)
        {
            DataTable dt = null;
            SqlConnection conn = null;
            string cnn = ConfigurationManager.ConnectionStrings["cnn"].ToString();
            try
            {
                conn = new SqlConnection(cnn);
                dt = new DataTable();

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dt.Load(dr);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }
        public static DataSet ObtenerDataSetDeQuery(string query)
        {
            DataSet ds = null;
            SqlConnection conn = null;
            string cnn = ConfigurationManager.ConnectionStrings["cnn"].ToString();
            try
            {
                conn = new SqlConnection(cnn);
                ds = new DataSet();

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                conn.Open();
                da.Fill(ds);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ds;
        }

        public static string GenerarNombreArchivo()
        {
            Random obj = new Random();
            string posibles = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            int longitud = posibles.Length;
            char letra;
            int longitudnuevacadena = 5;
            string nuevacadena = "";
            try
            {
                for (int i = 0; i < longitudnuevacadena; i++)
                {
                    letra = posibles[obj.Next(longitud)];
                    nuevacadena += letra.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return nuevacadena;
        }



    }
