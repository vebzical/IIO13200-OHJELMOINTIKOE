using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

/// <summary>
/// Summary description for Kayttajat
/// </summary>
[Serializable()]
[XmlRoot("Kayttajat")]
public class Kayttajat
{
    [XmlElement("Kayttaja")]
    public List<Kayttaja> User { get; set; }

	public Kayttajat()
	{
        User = new List<Kayttaja>();
	}
}