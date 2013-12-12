using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

/// <summary>
/// Summary description for tyontekija
/// </summary>
[Serializable()]
public class tyontekija
{
    [XmlElement("etunimi")]
    public string etunimi {get;set;}
    [XmlElement("sukunimi")]
    public string sukunimi {get;set;}
    [XmlElement("numero")]
    public int numero {get;set;}
    [XmlElement("tyosuhde")]
    public string tyosuhde {get;set;}
    [XmlElement("palkka")]
    public int palkka { get; set; }

	public tyontekija()
	{

	}
}