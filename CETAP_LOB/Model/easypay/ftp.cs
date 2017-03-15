// Decompiled with JetBrains decompiler
// Type: LOB.Model.easypay.ftp
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace CETAP_LOB.Model.easypay
{
  public class ftp
  {
    private int bufferSize = 2048;
    private string host;
    private string user;
    private string pass;
    private FtpWebRequest ftpRequest;
    private FtpWebResponse ftpResponse;
    private Stream ftpStream;

    public ftp(string hostIP, string userName, string password)
    {
      this.host = "ftp://" + hostIP;
      this.user = userName;
      this.pass = password;
    }

    public async Task downloadAsync(string remoteFile, string localFile)
    {
      try
      {
        this.ftpRequest = (FtpWebRequest) WebRequest.Create(this.host + "/" + remoteFile);
        this.ftpRequest.Credentials = (ICredentials) new NetworkCredential(this.user, this.pass);
        this.ftpRequest.UseBinary = true;
        this.ftpRequest.UsePassive = true;
        this.ftpRequest.KeepAlive = true;
        this.ftpRequest.Method = "RETR";
        this.ftpResponse = (FtpWebResponse) this.ftpRequest.GetResponse();
        this.ftpStream = this.ftpResponse.GetResponseStream();
        FileStream localFileStream = new FileStream(localFile, FileMode.Create);
        byte[] byteBuffer = new byte[this.bufferSize];
        int bytesRead = await this.ftpStream.ReadAsync(byteBuffer, 0, this.bufferSize);
        try
        {
          for (; bytesRead > 0; bytesRead = await this.ftpStream.ReadAsync(byteBuffer, 0, this.bufferSize))
            await localFileStream.WriteAsync(byteBuffer, 0, bytesRead);
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.ToString());
        }
        localFileStream.Close();
        this.ftpStream.Close();
        this.ftpResponse.Close();
        this.ftpRequest = (FtpWebRequest) null;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
    }

    public void upload(string remoteFile, string localFile)
    {
      try
      {
        this.ftpRequest = (FtpWebRequest) WebRequest.Create(this.host + "/" + remoteFile);
        this.ftpRequest.Credentials = (ICredentials) new NetworkCredential(this.user, this.pass);
        this.ftpRequest.UseBinary = true;
        this.ftpRequest.UsePassive = true;
        this.ftpRequest.KeepAlive = true;
        this.ftpRequest.Method = "STOR";
        this.ftpStream = this.ftpRequest.GetRequestStream();
        FileStream fileStream = new FileStream(localFile, FileMode.Open);
        byte[] buffer = new byte[this.bufferSize];
        int count = fileStream.Read(buffer, 0, this.bufferSize);
        try
        {
          for (; count != 0; count = fileStream.Read(buffer, 0, this.bufferSize))
            this.ftpStream.Write(buffer, 0, count);
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.ToString());
        }
        fileStream.Close();
        this.ftpStream.Close();
        this.ftpRequest = (FtpWebRequest) null;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
    }

    public void delete(string deleteFile)
    {
      try
      {
        this.ftpRequest = (FtpWebRequest) WebRequest.Create(this.host + "/" + deleteFile);
        this.ftpRequest.Credentials = (ICredentials) new NetworkCredential(this.user, this.pass);
        this.ftpRequest.UseBinary = true;
        this.ftpRequest.UsePassive = true;
        this.ftpRequest.KeepAlive = true;
        this.ftpRequest.Method = "DELE";
        this.ftpResponse = (FtpWebResponse) this.ftpRequest.GetResponse();
        this.ftpResponse.Close();
        this.ftpRequest = (FtpWebRequest) null;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
    }

    public void rename(string currentFileNameAndPath, string newFileName)
    {
      try
      {
        this.ftpRequest = (FtpWebRequest) WebRequest.Create(this.host + "/" + currentFileNameAndPath);
        this.ftpRequest.Credentials = (ICredentials) new NetworkCredential(this.user, this.pass);
        this.ftpRequest.UseBinary = true;
        this.ftpRequest.UsePassive = true;
        this.ftpRequest.KeepAlive = true;
        this.ftpRequest.Method = "RENAME";
        this.ftpRequest.RenameTo = newFileName;
        this.ftpResponse = (FtpWebResponse) this.ftpRequest.GetResponse();
        this.ftpResponse.Close();
        this.ftpRequest = (FtpWebRequest) null;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
    }

    public void createDirectory(string newDirectory)
    {
      try
      {
        this.ftpRequest = (FtpWebRequest) WebRequest.Create(this.host + "/" + newDirectory);
        this.ftpRequest.Credentials = (ICredentials) new NetworkCredential(this.user, this.pass);
        this.ftpRequest.UseBinary = true;
        this.ftpRequest.UsePassive = true;
        this.ftpRequest.KeepAlive = true;
        this.ftpRequest.Method = "MKD";
        this.ftpResponse = (FtpWebResponse) this.ftpRequest.GetResponse();
        this.ftpResponse.Close();
        this.ftpRequest = (FtpWebRequest) null;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
    }

    public string getFileCreatedDateTime(string fileName)
    {
      try
      {
        this.ftpRequest = (FtpWebRequest) WebRequest.Create(this.host + "/" + fileName);
        this.ftpRequest.Credentials = (ICredentials) new NetworkCredential(this.user, this.pass);
        this.ftpRequest.UseBinary = true;
        this.ftpRequest.UsePassive = true;
        this.ftpRequest.KeepAlive = true;
        this.ftpRequest.Method = "MDTM";
        this.ftpResponse = (FtpWebResponse) this.ftpRequest.GetResponse();
        this.ftpStream = this.ftpResponse.GetResponseStream();
        StreamReader streamReader = new StreamReader(this.ftpStream);
        string str = (string) null;
        try
        {
          str = streamReader.ReadToEnd();
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.ToString());
        }
        streamReader.Close();
        this.ftpStream.Close();
        this.ftpResponse.Close();
        this.ftpRequest = (FtpWebRequest) null;
        return str;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
      return "";
    }

    public string getFileSize(string fileName)
    {
      try
      {
        this.ftpRequest = (FtpWebRequest) WebRequest.Create(this.host + "/" + fileName);
        this.ftpRequest.Credentials = (ICredentials) new NetworkCredential(this.user, this.pass);
        this.ftpRequest.UseBinary = true;
        this.ftpRequest.UsePassive = true;
        this.ftpRequest.KeepAlive = true;
        this.ftpRequest.Method = "SIZE";
        this.ftpResponse = (FtpWebResponse) this.ftpRequest.GetResponse();
        this.ftpStream = this.ftpResponse.GetResponseStream();
        StreamReader streamReader = new StreamReader(this.ftpStream);
        string str = (string) null;
        try
        {
          while (streamReader.Peek() != -1)
            str = streamReader.ReadToEnd();
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.ToString());
        }
        streamReader.Close();
        this.ftpStream.Close();
        this.ftpResponse.Close();
        this.ftpRequest = (FtpWebRequest) null;
        return str;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
      return "";
    }

    public string[] directoryListSimple(string directory)
    {
      try
      {
        FtpWebRequest ftpWebRequest = (FtpWebRequest) WebRequest.Create(this.host);
        ftpWebRequest.Credentials = (ICredentials) new NetworkCredential(this.user, this.pass);
        ftpWebRequest.UseBinary = true;
        ftpWebRequest.UsePassive = true;
        ftpWebRequest.KeepAlive = true;
        ftpWebRequest.Method = "NLST";
        this.ftpResponse = (FtpWebResponse) ftpWebRequest.GetResponse();
        this.ftpStream = this.ftpResponse.GetResponseStream();
        StreamReader streamReader = new StreamReader(this.ftpStream);
        string str = (string) null;
        try
        {
          while (streamReader.Peek() != -1)
            str = str + streamReader.ReadLine() + "|";
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.ToString());
        }
        streamReader.Close();
        this.ftpStream.Close();
        this.ftpResponse.Close();
        try
        {
          return str.Split("|".ToCharArray());
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.ToString());
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
      return new string[1]{ "" };
    }

    public string[] directoryListDetailed(string directory)
    {
      try
      {
        this.ftpRequest = (FtpWebRequest) WebRequest.Create(this.host + "/" + directory);
        this.ftpRequest.Credentials = (ICredentials) new NetworkCredential(this.user, this.pass);
        this.ftpRequest.UseBinary = true;
        this.ftpRequest.UsePassive = true;
        this.ftpRequest.KeepAlive = true;
        this.ftpRequest.Method = "LIST";
        this.ftpResponse = (FtpWebResponse) this.ftpRequest.GetResponse();
        this.ftpStream = this.ftpResponse.GetResponseStream();
        StreamReader streamReader = new StreamReader(this.ftpStream);
        string str = (string) null;
        try
        {
          while (streamReader.Peek() != -1)
            str = str + streamReader.ReadLine() + "|";
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.ToString());
        }
        streamReader.Close();
        this.ftpStream.Close();
        this.ftpResponse.Close();
        this.ftpRequest = (FtpWebRequest) null;
        try
        {
          return str.Split("|".ToCharArray());
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.ToString());
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
      return new string[1]{ "" };
    }
  }
}
