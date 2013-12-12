using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

/// <summary>
/// Summary description for Kirjanpito
/// </summary>
[Serializable()]
[XmlRoot("Kirjanpito")]
public class Kirjanpito
{
    [XmlElement("Merkinta")]
    public List<Merkinta> merkinnat { get; set; }

	public Kirjanpito()
	{
        merkinnat = new List<Merkinta>();
	}
}