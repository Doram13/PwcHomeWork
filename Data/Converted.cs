   /* 
    Licensed under the Apache License, Version 2.0
    
    http://www.apache.org/licenses/LICENSE-2.0
    */
using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Xml2CSharp
{
    [XmlRoot(ElementName = "szamla", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
    public class Converted { 

    [XmlRoot(ElementName = "fejlec", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
    public class Fejlec
    {
        [XmlElement(ElementName = "szlasorszam", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public string Szlasorszam { get; set; }
        [XmlElement(ElementName = "szlatipus", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public string Szlatipus { get; set; }
        [XmlElement(ElementName = "szladatum", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public string Szladatum { get; set; }
        [XmlElement(ElementName = "teljdatum", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public string Teljdatum { get; set; }
    }

    [XmlRoot(ElementName = "cim", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
    public class Cim
    {
        [XmlElement(ElementName = "iranyitoszam", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public string Iranyitoszam { get; set; }
        [XmlElement(ElementName = "telepules", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public string Telepules { get; set; }
        [XmlElement(ElementName = "kozterulet_neve", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public string Kozterulet_neve { get; set; }
    }

    [XmlRoot(ElementName = "szamlakibocsato", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
    public class Szamlakibocsato
    {
        [XmlElement(ElementName = "adoszam", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public string Adoszam { get; set; }
        [XmlElement(ElementName = "nev", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public string Nev { get; set; }
        [XmlElement(ElementName = "cim", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public Cim Cim { get; set; }
    }

    [XmlRoot(ElementName = "vevo", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
    public class Vevo
    {
        [XmlElement(ElementName = "adoszam", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public string Adoszam { get; set; }
        [XmlElement(ElementName = "nev", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public string Nev { get; set; }
        [XmlElement(ElementName = "cim", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public Cim Cim { get; set; }
    }

    [XmlRoot(ElementName = "termek_szolgaltatas_tetelek", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
    public class Termek_szolgaltatas_tetelek
    {
        [XmlElement(ElementName = "termeknev", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public string Termeknev { get; set; }
        [XmlElement(ElementName = "menny", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public string Menny { get; set; }
        [XmlElement(ElementName = "mertekegys", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public string Mertekegys { get; set; }
        [XmlElement(ElementName = "nettoar", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public string Nettoar { get; set; }
        [XmlElement(ElementName = "nettoegysar", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public string Nettoegysar { get; set; }
        [XmlElement(ElementName = "adokulcs", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public string Adokulcs { get; set; }
        [XmlElement(ElementName = "adoertek", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public string Adoertek { get; set; }
    }

    [XmlRoot(ElementName = "nem_kotelezo", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
    public class Nem_kotelezo
    {
        [XmlElement(ElementName = "penznem", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public string Penznem { get; set; }
    }

    [XmlRoot(ElementName = "vegosszeg", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
    public class Vegosszeg
    {
        [XmlElement(ElementName = "nettoarossz", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public string Nettoarossz { get; set; }
        [XmlElement(ElementName = "afaertekossz", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public string Afaertekossz { get; set; }
        [XmlElement(ElementName = "bruttoarossz", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public string Bruttoarossz { get; set; }
    }

    [XmlRoot(ElementName = "osszesites", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
    public class Osszesites
    {
        [XmlElement(ElementName = "vegosszeg", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public Vegosszeg Vegosszeg { get; set; }
    }

    [XmlRoot(ElementName = "szamla", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
    public class Szamla
    {
        [XmlElement(ElementName = "fejlec", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public Fejlec Fejlec { get; set; }
        [XmlElement(ElementName = "szamlakibocsato", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public Szamlakibocsato Szamlakibocsato { get; set; }
        [XmlElement(ElementName = "vevo", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public Vevo Vevo { get; set; }
        [XmlElement(ElementName = "termek_szolgaltatas_tetelek", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public List<Termek_szolgaltatas_tetelek> Termek_szolgaltatas_tetelek { get; set; }
        [XmlElement(ElementName = "nem_kotelezo", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public Nem_kotelezo Nem_kotelezo { get; set; }
        [XmlElement(ElementName = "osszesites", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public Osszesites Osszesites { get; set; }
        [XmlElement(ElementName = "modosito_szla", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public Modosito_szla Modosito_szla { get; set; }
    }

    [XmlRoot(ElementName = "modosito_szla", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
    public class Modosito_szla
    {
        [XmlElement(ElementName = "eredeti_sorszam", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public string Eredeti_sorszam { get; set; }
    }

    [XmlRoot(ElementName = "szamlak", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
    public class Szamlak
    {
        [XmlElement(ElementName = "export_datuma", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public string Export_datuma { get; set; }
        [XmlElement(ElementName = "export_szla_db", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public string Export_szla_db { get; set; }
        [XmlElement(ElementName = "kezdo_ido", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public string Kezdo_ido { get; set; }
        [XmlElement(ElementName = "zaro_ido", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public string Zaro_ido { get; set; }
        [XmlElement(ElementName = "kezdo_szla_szam", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public string Kezdo_szla_szam { get; set; }
        [XmlElement(ElementName = "zaro_szla_szam", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public string Zaro_szla_szam { get; set; }
        [XmlElement(ElementName = "szamla", Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
        public List<Szamla> Szamla { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
        [XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsd { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
    }
    }
}
