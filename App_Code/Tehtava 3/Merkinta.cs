using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

/// <summary>
/// Summary description for Merkinta
/// </summary>
[Serializable()]
public class Merkinta
{
    [XmlElement("username")]
    public string username { get; set; }
    [XmlElement("date")]
    public string date { get; set; }
    [XmlElement("time")]
    public string time { get; set; }

	public Merkinta()
	{

	}
}