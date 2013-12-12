using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

/// <summary>
/// Summary description for Kayttaja
/// </summary>
[Serializable()]
public class Kayttaja
{
    [XmlElement("UserName")]
    public string UserName { get; set; }
    [XmlElement("Password")]
    public string Password { get; set; }

	public Kayttaja()
	{

	}
}