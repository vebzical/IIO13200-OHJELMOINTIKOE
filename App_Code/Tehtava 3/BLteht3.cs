using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Serialization;

/// <summary>
/// Summary description for BLteht3
/// </summary>
public class BLteht3
{
    public static void SerialisoiKayttajat(string tiedosto, Kayttajat users)
    {
        XmlSerializer xs = new XmlSerializer(users.GetType());
        TextWriter tw = new StreamWriter(tiedosto);
        try
        {
            xs.Serialize(tw, users);
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            tw.Close();
        }
    }
    public static void DeSerialisoiKayttajat(string filePath, ref Kayttajat users)
    {
        XmlSerializer deserializer = new XmlSerializer(typeof(Kayttajat));
        try
        {
            FileStream xmlFile = new FileStream(filePath, FileMode.Open);
            users = (Kayttajat)deserializer.Deserialize(xmlFile);
            xmlFile.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }

    }

    public static void SerialisoiKirjanpito(string tiedosto, Kirjanpito merkinnat)
    {
        XmlSerializer xs = new XmlSerializer(merkinnat.GetType());
        TextWriter tw = new StreamWriter(tiedosto);
        try
        {
            xs.Serialize(tw, merkinnat);
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            tw.Close();
        }
    }
    public static void DeSerialisoiKirjanpito(string filePath, ref Kirjanpito merkinnat)
    {
        XmlSerializer deserializer = new XmlSerializer(typeof(Kirjanpito));
        try
        {
            FileStream xmlFile = new FileStream(filePath, FileMode.Open);
            merkinnat = (Kirjanpito)deserializer.Deserialize(xmlFile);
            xmlFile.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }

    }


    public static List<Merkinta> HaeAutot()
    {
        string path = ConfigurationManager.AppSettings["path_teht3_merkinnat"];

        Kirjanpito autot = new Kirjanpito();
        List<Merkinta> autoLista = new List<Merkinta>();

        BLteht3.DeSerialisoiKirjanpito(path, ref autot);

        for (int i = 0; i < autot.merkinnat.Count; i++)
        {
            autoLista.Add(autot.merkinnat[i]);
        }
        return autoLista;
    }
    public static void VieAutot(List<Merkinta> autoLista)
    {
        string path = ConfigurationManager.AppSettings["path_teht3_merkinnat"];

        Kirjanpito autot = new Kirjanpito();
        List<Merkinta> autoLista1 = new List<Merkinta>();

        autoLista1 = HaeAutot();

        foreach (Merkinta item in autoLista1)
        {
            autot.merkinnat.Add(item);
        }

        foreach (Merkinta item in autoLista)
        {
            if (!autot.merkinnat.Contains(item))
            {
                autot.merkinnat.Add(item);
            }
        }

        BLteht3.SerialisoiKirjanpito(path, autot);
    }
    public static List<Merkinta> SortList(List<Merkinta> autoLista, string GridViewSortExpression, string SortDirection)
    {
        if (autoLista != null)
        {
            if (GridViewSortExpression != string.Empty)
            {
                if (SortDirection == "ASC")
                {
                    autoLista = autoLista.OrderBy
                        (a => a.GetType().GetProperty(GridViewSortExpression)
                            .GetValue(a, null)).ToList();
                }
                else
                {
                    autoLista = autoLista.OrderByDescending
                        (a => a.GetType().GetProperty(GridViewSortExpression)
                            .GetValue(a, null)).ToList();
                }
            }
            return autoLista;
        }
        else
        {
            return autoLista;
        }
    }
    public static string regexString(string tarkistettava, string kohde)
    {
        Regex regDate = new Regex(@"^\d{1,2}\.\d{1,2}\.\d{4}$");
        Regex regTime = new Regex(@"^\d{1,2}\:\d{1,2}$");
        Regex regUserName = new Regex(@"^[a-zA-Z0-9]{1,15}$");
        Regex regPassword = new Regex(@"^[\S*\s*]{1,20}$");

        switch (kohde)
        {
            case "Date":
                return regDate.Match(tarkistettava).ToString();
            case "Time":
                return regTime.Match(tarkistettava).ToString();
            case "userName":
                return regUserName.Match(tarkistettava).ToString();
            case "password":
                return regPassword.Match(tarkistettava).ToString();
            default:
                return "Tapahtui virhe";
        }
    }
    public static bool authenticateUser(string userName, string passWord)
    {
        string path = ConfigurationManager.AppSettings["path_teht3_kayttajat"];

        Kayttajat kayttajat = new Kayttajat();

        BLteht3.DeSerialisoiKayttajat(path, ref kayttajat);

        byte[] saltBytes = new byte[] { 12, 254, 62, 6, 7, 42, 2, 96 };
        byte[] saltedHashBytesUserName = new HMACMD5(saltBytes).ComputeHash(Encoding.UTF8.GetBytes(userName));
        byte[] saltedHashBytesPassword = new HMACMD5(saltBytes).ComputeHash(Encoding.UTF8.GetBytes(passWord));

        string saltedHashStringUserName = Convert.ToBase64String(saltedHashBytesUserName);
        string saltedHashStringPassword = Convert.ToBase64String(saltedHashBytesPassword);

        for (int i = 0; i < kayttajat.User.Count; i++)
        {
            if (saltedHashStringUserName == kayttajat.User[i].UserName && saltedHashStringPassword == kayttajat.User[i].Password)
            {
                return true;
            }
        }
        return false;
    }
}