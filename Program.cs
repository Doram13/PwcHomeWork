using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Diagnostics;
using System.Collections;
using System.Collections.Specialized;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.IO;
using System.Threading;
using System.Reflection;
using OfficeOpenXml;


namespace Solution
{
    class Program
    {
        //gyűjtsd ki egy Excel sheetre az összes olyanszámlát, amelynek a végösszegben 
        //szereplő áfája eléri vagy meghaladja a 100 ezer HUF-t.
        //A sheet struktúrája legyen: Vevő adószáma, Számlaszám, Nettó végösszeg, Áfa

        public static List<Szamla.szamlakSzamla> szamlakSzamlaList = new List<Szamla.szamlakSzamla>();


        static string path = @"C:\Users\doram\Downloads\pwc\PwCHomework\Solution\Data\source.xml";
        static void Main(string[] args)
        {
            Szamla.szamlak Invoices = DeserializeXml();

            // List every szamla in deserialized source

            foreach (Szamla.szamlakSzamla szamlakSzamla in Invoices.szamla)
            {
                szamlakSzamlaList.Add(szamlakSzamla);

            }

            //List every vegosszek in the list of szamlas

            List<Szamla.szamlakSzamlaOsszesites> osszesitesList = new List<Szamla.szamlakSzamlaOsszesites>();


            //100.000-nél nagyobb áfás számlák listája és feltöltése

            List<Szamla.szamlakSzamla> afasSzamla = GetInvoicesOver100KVat(osszesitesList);

            Console.WriteLine(afasSzamla.ToString());
            //Console.Read();

            //Creating Excel sheets

            using (ExcelPackage results = new ExcelPackage())
            {
                results.Workbook.Worksheets.Add("FirstAnswer");
                //results.Workbook.Worksheets.Add("SecondAnswer");
                //results.Workbook.Worksheets.Add("ThirdAnser");



                //Select first worksheet
                var excelWorksheet = results.Workbook.Worksheets["FirstAnswer"];

                //Add header row
                List<string[]> headerRow = new List<string[]>()
                {
                    new string[] { "Vevő adószáma", "Számlaszám", "Nettó végösszeg", "Áfa" }

                };
                // Determine the header range (e.g. A1:E1)
                string headerRange = "A1:" + Char.ConvertFromUtf32(headerRow[0].Length + 64) + "1";

                // Popular header row data
                excelWorksheet.Cells[headerRange].LoadFromArrays(headerRow);

                FillAdoszamRowWithResult(afasSzamla, excelWorksheet);
                FillSzámlaszámRowWithResult(afasSzamla, excelWorksheet);
                FillNettoVegRowWithResult(afasSzamla, excelWorksheet);
                FillAfaRowWithResult(afasSzamla, excelWorksheet);
                FileInfo excelFile = new FileInfo(@"C:\Users\doram\Downloads\pwc\PwCHomework\Solution\Data\results.xlsx");
                results.SaveAs(excelFile);
            }
        }

        private static void FillAfaRowWithResult(List<Szamla.szamlakSzamla> afasSzamla, ExcelWorksheet excelWorksheet)
        {
            var cellData = new List<string>();
            int counter = 0;
            string[] afas = new string[afasSzamla.Count];
            foreach (var szamla in afasSzamla)
            {
                afas[counter] = szamla.osszesites.vegosszeg.afaertekossz.ToString();
                counter++;

            }
            foreach (var afa in afas)
            {
                cellData.Add(afa);
            }
            int counterOfCellData = 0;

            for (int i = 2; i < cellData.Count; i++)
            {

                var oneCell = cellData[counterOfCellData];
                excelWorksheet.Cells[i, 4].LoadFromText(oneCell);
                counterOfCellData++;
            }
        }

        private static void FillNettoVegRowWithResult(List<Szamla.szamlakSzamla> afasSzamla, ExcelWorksheet excelWorksheet)
        {
            var cellData = new List<string>();
            int counter = 0;
            string[] vegosszegs = new string[afasSzamla.Count];
            foreach (var szamla in afasSzamla)
            {
                vegosszegs[counter] = szamla.osszesites.vegosszeg.nettoarossz.ToString();
                counter++;

            }
            foreach (var vegosszeg in vegosszegs)
            {
                cellData.Add(vegosszeg);
            }
            int counterOfCellData = 0;

            for (int i = 2; i < cellData.Count; i++)
            {

                var oneCell = cellData[counterOfCellData];
                excelWorksheet.Cells[i, 3].LoadFromText(oneCell);
                counterOfCellData++;
            }
        }

        private static void FillAdoszamRowWithResult(List<Szamla.szamlakSzamla> afasSzamla, ExcelWorksheet excelWorksheet)
        {
            var cellData = new List<string>();
            int counter = 0;
            string[] adoszams = new string[afasSzamla.Count];
            foreach (var szamla in afasSzamla)
            {
                adoszams[counter] = szamla.vevo.adoszam;
                counter++;

            }
            foreach (var adoszam in adoszams)
            {
                cellData.Add(adoszam);
            }
            int counterOfCellData = 0;

            for (int i = 2; i < cellData.Count; i++)
            {

                var oneCell = cellData[counterOfCellData];
                excelWorksheet.Cells[i, 1].LoadFromText(oneCell);
                counterOfCellData++;
            }
            
        }private static void FillSzámlaszámRowWithResult(List<Szamla.szamlakSzamla> afasSzamla, ExcelWorksheet excelWorksheet)
        {
            var cellData = new List<string>();
            int counter = 0;
            string[] szamlaszams = new string[afasSzamla.Count];
            foreach (var szamla in afasSzamla)
            {
                szamlaszams[counter] = szamla.fejlec.szlasorszam;
                counter++;
            }
            foreach (var szamlaszam in szamlaszams)
            {
                cellData.Add(szamlaszam);
            }
            int counterOfCellData = 0;

            for (int i = 2; i < cellData.Count; i++)
            {

                var oneCell = cellData[counterOfCellData];
                excelWorksheet.Cells[i, 2].LoadFromText(oneCell);
                counterOfCellData++;
            }
            
        }

        private static List<Szamla.szamlakSzamla> GetInvoicesOver100KVat(List<Szamla.szamlakSzamlaOsszesites> osszesitesList)
        {
            List<Szamla.szamlakSzamla> afasSzamla = new List<Szamla.szamlakSzamla>();

            foreach (Szamla.szamlakSzamla oneSzamla in szamlakSzamlaList)
            {
                osszesitesList.Add(oneSzamla.osszesites);

                if (oneSzamla.osszesites.vegosszeg.afaertekossz >= 100000)
                {
                    afasSzamla.Add(oneSzamla);

                }
            }

            return afasSzamla;
        }

        private static Szamla.szamlak DeserializeXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Szamla.szamlak));
            Szamla.szamlak Invoices;

            // Deserialize whole source.xml

            using (XmlReader reader = XmlReader.Create(path))
            {

                Invoices = (Szamla.szamlak)serializer.Deserialize(reader);
            }

            return Invoices;
        }
    }
}
