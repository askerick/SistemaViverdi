using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;
using System.Text;

/// <summary>
/// Summary description for UploadFile
/// </summary>
public class UploadFile
{
    public UploadFile()
    {
        // Get the object used to communicate with the server.  
        FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp.souvenir.mx");
        request.Method = WebRequestMethods.Ftp.UploadFile;

        // This example assumes the FTP site uses anonymous logon.  
        request.Credentials = new NetworkCredential("articul4", "Wn9y2%m0");

        // Copy the contents of the file to the request stream.  
        StreamReader sourceStream = new StreamReader("testfile.txt");
        byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
        sourceStream.Close();
        request.ContentLength = fileContents.Length;

        Stream requestStream = request.GetRequestStream();
        requestStream.Write(fileContents, 0, fileContents.Length);
        requestStream.Close();

        FtpWebResponse response = (FtpWebResponse)request.GetResponse();

        Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);

        response.Close();
    }
}
