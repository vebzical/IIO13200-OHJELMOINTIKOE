using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

/// <summary>
/// Summary description for tyontekijat
/// </summary>
[Serializable()]
[XmlRoot("tyontekijat")]
public class tyontekijat
{
    [XmlElement("tyontekija")]
    public List<tyontekija> tekija { get; set; }

	public tyontekijat()
	{
        tekija = new List<tyontekija>();
	}
}