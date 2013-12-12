using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

/// <summary>
/// Summary description for BLteht2
/// </summary>
public class BLteht2
{
    public static void SerialisoiXml(string tiedosto, tyontekijat tekijat)
    {
        XmlSerializer xs = new XmlSerializer(tekijat.GetType());
        TextWriter tw = new StreamWriter(tiedosto);
        try
        {
            xs.Serialize(tw, tekijat);
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

    public static void DeSerialisoiXml(string filePath, ref tyontekijat tekijat)
    {
        XmlSerializer deserializer = new XmlSerializer(typeof(tyontekijat));
        try
        {
            FileStream xmlFile = new FileStream(filePath, FileMode.Open);
            tekijat = (tyontekijat)deserializer.Deserialize(xmlFile);
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

}