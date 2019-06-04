using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Szamla
{
    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.nav.gov.hu/2013/szamla", IsNullable = false)]
    public partial class szamlak
    {

        private System.DateTime export_datumaField;

        private byte export_szla_dbField;

        private System.DateTime kezdo_idoField;

        private System.DateTime zaro_idoField;

        private string kezdo_szla_szamField;

        private string zaro_szla_szamField;

        private szamlakSzamla[] szamlaField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime export_datuma
        {
            get
            {
                return this.export_datumaField;
            }
            set
            {
                this.export_datumaField = value;
            }
        }

        /// <remarks/>
        public byte export_szla_db
        {
            get
            {
                return this.export_szla_dbField;
            }
            set
            {
                this.export_szla_dbField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime kezdo_ido
        {
            get
            {
                return this.kezdo_idoField;
            }
            set
            {
                this.kezdo_idoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime zaro_ido
        {
            get
            {
                return this.zaro_idoField;
            }
            set
            {
                this.zaro_idoField = value;
            }
        }

        /// <remarks/>
        public string kezdo_szla_szam
        {
            get
            {
                return this.kezdo_szla_szamField;
            }
            set
            {
                this.kezdo_szla_szamField = value;
            }
        }

        /// <remarks/>
        public string zaro_szla_szam
        {
            get
            {
                return this.zaro_szla_szamField;
            }
            set
            {
                this.zaro_szla_szamField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("szamla")]
        public szamlakSzamla[] szamla
        {
            get
            {
                return this.szamlaField;
            }
            set
            {
                this.szamlaField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
    public partial class szamlakSzamla
    {

        private szamlakSzamlaFejlec fejlecField;

        private szamlakSzamlaSzamlakibocsato szamlakibocsatoField;

        private szamlakSzamlaVevo vevoField;

        private szamlakSzamlaTermek_szolgaltatas_tetelek[] termek_szolgaltatas_tetelekField;

        private szamlakSzamlaModosito_szla modosito_szlaField;

        private szamlakSzamlaNem_kotelezo nem_kotelezoField;

        private szamlakSzamlaOsszesites osszesitesField;

        /// <remarks/>
        public szamlakSzamlaFejlec fejlec
        {
            get
            {
                return this.fejlecField;
            }
            set
            {
                this.fejlecField = value;
            }
        }

        /// <remarks/>
        public szamlakSzamlaSzamlakibocsato szamlakibocsato
        {
            get
            {
                return this.szamlakibocsatoField;
            }
            set
            {
                this.szamlakibocsatoField = value;
            }
        }

        /// <remarks/>
        public szamlakSzamlaVevo vevo
        {
            get
            {
                return this.vevoField;
            }
            set
            {
                this.vevoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("termek_szolgaltatas_tetelek")]
        public szamlakSzamlaTermek_szolgaltatas_tetelek[] termek_szolgaltatas_tetelek
        {
            get
            {
                return this.termek_szolgaltatas_tetelekField;
            }
            set
            {
                this.termek_szolgaltatas_tetelekField = value;
            }
        }

        /// <remarks/>
        public szamlakSzamlaModosito_szla modosito_szla
        {
            get
            {
                return this.modosito_szlaField;
            }
            set
            {
                this.modosito_szlaField = value;
            }
        }

        /// <remarks/>
        public szamlakSzamlaNem_kotelezo nem_kotelezo
        {
            get
            {
                return this.nem_kotelezoField;
            }
            set
            {
                this.nem_kotelezoField = value;
            }
        }

        /// <remarks/>
        public szamlakSzamlaOsszesites osszesites
        {
            get
            {
                return this.osszesitesField;
            }
            set
            {
                this.osszesitesField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
    public partial class szamlakSzamlaFejlec
    {

        private string szlasorszamField;

        private byte szlatipusField;

        private System.DateTime szladatumField;

        private System.DateTime teljdatumField;

        /// <remarks/>
        public string szlasorszam
        {
            get
            {
                return this.szlasorszamField;
            }
            set
            {
                this.szlasorszamField = value;
            }
        }

        /// <remarks/>
        public byte szlatipus
        {
            get
            {
                return this.szlatipusField;
            }
            set
            {
                this.szlatipusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime szladatum
        {
            get
            {
                return this.szladatumField;
            }
            set
            {
                this.szladatumField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime teljdatum
        {
            get
            {
                return this.teljdatumField;
            }
            set
            {
                this.teljdatumField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
    public partial class szamlakSzamlaSzamlakibocsato
    {

        private string adoszamField;

        private string nevField;

        private szamlakSzamlaSzamlakibocsatoCim cimField;

        /// <remarks/>
        public string adoszam
        {
            get
            {
                return this.adoszamField;
            }
            set
            {
                this.adoszamField = value;
            }
        }

        /// <remarks/>
        public string nev
        {
            get
            {
                return this.nevField;
            }
            set
            {
                this.nevField = value;
            }
        }

        /// <remarks/>
        public szamlakSzamlaSzamlakibocsatoCim cim
        {
            get
            {
                return this.cimField;
            }
            set
            {
                this.cimField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
    public partial class szamlakSzamlaSzamlakibocsatoCim
    {

        private ushort iranyitoszamField;

        private string telepulesField;

        private string kozterulet_neveField;

        /// <remarks/>
        public ushort iranyitoszam
        {
            get
            {
                return this.iranyitoszamField;
            }
            set
            {
                this.iranyitoszamField = value;
            }
        }

        /// <remarks/>
        public string telepules
        {
            get
            {
                return this.telepulesField;
            }
            set
            {
                this.telepulesField = value;
            }
        }

        /// <remarks/>
        public string kozterulet_neve
        {
            get
            {
                return this.kozterulet_neveField;
            }
            set
            {
                this.kozterulet_neveField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
    public partial class szamlakSzamlaVevo
    {

        private string adoszamField;

        private string nevField;

        private szamlakSzamlaVevoCim cimField;

        /// <remarks/>
        public string adoszam
        {
            get
            {
                return this.adoszamField;
            }
            set
            {
                this.adoszamField = value;
            }
        }

        /// <remarks/>
        public string nev
        {
            get
            {
                return this.nevField;
            }
            set
            {
                this.nevField = value;
            }
        }

        /// <remarks/>
        public szamlakSzamlaVevoCim cim
        {
            get
            {
                return this.cimField;
            }
            set
            {
                this.cimField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
    public partial class szamlakSzamlaVevoCim
    {

        private ushort iranyitoszamField;

        private string telepulesField;

        private string kozterulet_neveField;

        /// <remarks/>
        public ushort iranyitoszam
        {
            get
            {
                return this.iranyitoszamField;
            }
            set
            {
                this.iranyitoszamField = value;
            }
        }

        /// <remarks/>
        public string telepules
        {
            get
            {
                return this.telepulesField;
            }
            set
            {
                this.telepulesField = value;
            }
        }

        /// <remarks/>
        public string kozterulet_neve
        {
            get
            {
                return this.kozterulet_neveField;
            }
            set
            {
                this.kozterulet_neveField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
    public partial class szamlakSzamlaTermek_szolgaltatas_tetelek
    {

        private string termeknevField;

        private ushort mennyField;

        private string mertekegysField;

        private int nettoarField;

        private int nettoegysarField;

        private byte adokulcsField;

        private int adoertekField;

        /// <remarks/>
        public string termeknev
        {
            get
            {
                return this.termeknevField;
            }
            set
            {
                this.termeknevField = value;
            }
        }

        /// <remarks/>
        public ushort menny
        {
            get
            {
                return this.mennyField;
            }
            set
            {
                this.mennyField = value;
            }
        }

        /// <remarks/>
        public string mertekegys
        {
            get
            {
                return this.mertekegysField;
            }
            set
            {
                this.mertekegysField = value;
            }
        }

        /// <remarks/>
        public int nettoar
        {
            get
            {
                return this.nettoarField;
            }
            set
            {
                this.nettoarField = value;
            }
        }

        /// <remarks/>
        public int nettoegysar
        {
            get
            {
                return this.nettoegysarField;
            }
            set
            {
                this.nettoegysarField = value;
            }
        }

        /// <remarks/>
        public byte adokulcs
        {
            get
            {
                return this.adokulcsField;
            }
            set
            {
                this.adokulcsField = value;
            }
        }

        /// <remarks/>
        public int adoertek
        {
            get
            {
                return this.adoertekField;
            }
            set
            {
                this.adoertekField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
    public partial class szamlakSzamlaModosito_szla
    {

        private string eredeti_sorszamField;

        /// <remarks/>
        public string eredeti_sorszam
        {
            get
            {
                return this.eredeti_sorszamField;
            }
            set
            {
                this.eredeti_sorszamField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
    public partial class szamlakSzamlaNem_kotelezo
    {

        private string penznemField;

        /// <remarks/>
        public string penznem
        {
            get
            {
                return this.penznemField;
            }
            set
            {
                this.penznemField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
    public partial class szamlakSzamlaOsszesites
    {

        private szamlakSzamlaOsszesitesVegosszeg vegosszegField;

        /// <remarks/>
        public szamlakSzamlaOsszesitesVegosszeg vegosszeg
        {
            get
            {
                return this.vegosszegField;
            }
            set
            {
                this.vegosszegField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.nav.gov.hu/2013/szamla")]
    public partial class szamlakSzamlaOsszesitesVegosszeg
    {

        private decimal nettoarosszField;

        private decimal afaertekosszField;

        private int bruttoarosszField;

        /// <remarks/>
        public decimal nettoarossz
        {
            get
            {
                return this.nettoarosszField;
            }
            set
            {
                this.nettoarosszField = value;
            }
        }

        /// <remarks/>
        public decimal afaertekossz
        {
            get
            {
                return this.afaertekosszField;
            }
            set
            {
                this.afaertekosszField = value;
            }
        }

        /// <remarks/>
        public int bruttoarossz
        {
            get
            {
                return this.bruttoarosszField;
            }
            set
            {
                this.bruttoarosszField = value;
            }
        }
    }
}
