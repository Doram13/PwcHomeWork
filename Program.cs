using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using OfficeOpenXml;


namespace Solution
{
    class Program
    {
        //gyűjtsd ki egy Excel sheetre az összes olyanszámlát, amelynek a végösszegben 
        //szereplő áfája eléri vagy meghaladja a 100 ezer HUF-t.
        //A sheet struktúrája legyen: Vevő adószáma, Számlaszám, Nettó végösszeg, Áfa

        public static List<Szamla.szamlakSzamla> szamlakSzamlaList = new List<Szamla.szamlakSzamla>();
        
        //This path should be give by command-line argument, or env variable... 
        static string path = @"C:\Users\doram\Downloads\pwc\PwCHomework\Solution\Data\source.xml";


        static void Main(string[] args)
        {
            Szamla.szamlak Invoices = DeserializeXml();

            // List every szamla in deserialized source

            foreach (Szamla.szamlakSzamla szamlakSzamla in Invoices.szamla)
            {
                szamlakSzamlaList.Add(szamlakSzamla);

            }

            //100.000-nél nagyobb áfás számlák listája és feltöltése

            List<Szamla.szamlakSzamla> afasSzamla = GetInvoicesOver100KVat();


            //Creating Excel sheets for 1st question

            FirstQuestion(afasSzamla);


            //Second Question

            List<Szamla.szamlakSzamla> secondQuestionInvoices = GetSecondQuestionList();
            List<Szamla.szamlakSzamla> ListOfSecondAnswer = FindSecondAnswer(secondQuestionInvoices);

            //Creating Excel sheet for 2nd question

            SecondQuestion(ListOfSecondAnswer);

        }

        private static List<Szamla.szamlakSzamla> FindSecondAnswer(List<Szamla.szamlakSzamla> secondQuestionInvoices)
        {

            List<Szamla.szamlakSzamla> SecondAnswerList = new List<Szamla.szamlakSzamla>();
            //iterate through our collected invoices for the 2nd question

            foreach (var invoice in secondQuestionInvoices)
            {

                // Iterate through the items (Tételek) of one invoice 
                int summedItem = 0;
                foreach (var item in invoice.termek_szolgaltatas_tetelek)
                {
                    

                    // If the item is under 100K tax
                    if (item.adoertek < 100000)
                    {
                        // but the different items together are equal or bigger than 100K tax: 
                        
                        summedItem += item.adoertek;
                        if (summedItem >= 100000)
                        {
                            SecondAnswerList.Add(invoice);
                            break;
                        }
                    }
                    //volt legalább egy olyan számla, amely önmagában elérte a 100 HUF áfát. Ebben az esetben itt aggregálva
                    //azoknak a tételeknek kell szerepelniük, amelyek önmagukban nem érik el a 100 ezer HUF áfát
                    
               /* if (item.adoertek > 100 & item.adoertek < 100000)
                    {
                        SecondAnswerList.Add(invoice);
                    }
                   */ 

                }
            }
            return SecondAnswerList;
        }

        private static void FirstQuestion(List<Szamla.szamlakSzamla> afasSzamla)
        {
            using (ExcelPackage results = new ExcelPackage())
            {
                results.Workbook.Worksheets.Add("FirstQuestion");
                
                //Select first worksheet
                var excelWorksheet = results.Workbook.Worksheets["FirstQuestion"];

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
                FileInfo excelFile = new FileInfo(@"C:\Users\doram\Downloads\pwc\PwCHomework\Solution\Data\result1.xlsx");
                results.SaveAs(excelFile);
            }
        }

        private static void SecondQuestion(List<Szamla.szamlakSzamla> answers)
        {
            using (ExcelPackage results = new ExcelPackage())
            {

                results.Workbook.Worksheets.Add("SecondQuestion");
                //Select second worksheet
                var excelWorksheet = results.Workbook.Worksheets["SecondQuestion"];

                //Add header row
                List<string[]> headerRow = new List<string[]>()
                {
                    new string[] { "Adószám", "Nettó végösszeg aggregálva" }
                };
                // Determine the header range (e.g. A1:E1)
                string headerRange = "A1:" + Char.ConvertFromUtf32(headerRow[0].Length + 64) + "1";

                // Popular header row data
                excelWorksheet.Cells[headerRange].LoadFromArrays(headerRow);

                FillAdoszam(answers, excelWorksheet);
                FillVegosszeg(answers, excelWorksheet);
                
                FileInfo excelFile = new FileInfo(@"C:\Users\doram\Downloads\pwc\PwCHomework\Solution\Data\result2.xlsx");
                results.SaveAs(excelFile);
            }
        }

        private static void FillVegosszeg(List<Szamla.szamlakSzamla> answers, ExcelWorksheet excelWorksheet)
        {
            var cellData = new List<string>();
            int counter = 0;
            string[] vegosszegArray = new string[answers.Count];
            foreach (var szamla in answers)
            {
                vegosszegArray[counter] = szamla.osszesites.vegosszeg.nettoarossz.ToString();
                counter++;
            }
            foreach (var osszeg in vegosszegArray)
            {
                cellData.Add(osszeg);
            }

            int i = 2;
            foreach (var data in cellData)
            {
                excelWorksheet.Cells[i, 2].LoadFromText(data);
                i++;
            }

        }

        private static void FillAdoszam(List<Szamla.szamlakSzamla> answers, ExcelWorksheet excelWorksheet)
        {
            var cellData = new List<string>();
            int counter = 0;
            string[] adoszamArray = new string[answers.Count];
            foreach (var szamla in answers)
            {
                adoszamArray[counter] = szamla.szamlakibocsato.adoszam.ToString();
                counter++;
            }
            foreach (var adoszam in adoszamArray)
            {
                cellData.Add(adoszam);
            }

            int i = 2;
            foreach (var data in cellData)
            {
                excelWorksheet.Cells[i, 1].LoadFromText(data);
                i++;
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

            int i = 2;
            foreach (var data in cellData)
            {
                excelWorksheet.Cells[i, 4].LoadFromText(data);
                i++;
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

            int i = 2;
            foreach (var data in cellData)
            {
                excelWorksheet.Cells[i, 3].LoadFromText(data);
                i++;
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

            int i = 2;
            foreach (var data in cellData)
            {
                excelWorksheet.Cells[i, 1].LoadFromText(data);
                i++;
            }

        }
        private static void FillSzámlaszámRowWithResult(List<Szamla.szamlakSzamla> afasSzamla, ExcelWorksheet excelWorksheet)
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


            int i = 2;
            foreach (var data in cellData)
            {
                excelWorksheet.Cells[i, 2].LoadFromText(data);
                i++;
            }
        }

        private static List<Szamla.szamlakSzamla> GetInvoicesOver100KVat()
        {
            //Create List to give back with results
            List<Szamla.szamlakSzamla> afasSzamla = new List<Szamla.szamlakSzamla>();

            //Iterate through all the invoices

            foreach (Szamla.szamlakSzamla oneSzamla in szamlakSzamlaList)
            {
                

                if (oneSzamla.osszesites.vegosszeg.afaertekossz >= 100000)
                {
                    afasSzamla.Add(oneSzamla);

                }
            }

            return afasSzamla;
        }
        private static List<Szamla.szamlakSzamla> GetSecondQuestionList()
        {
            //Create List to give back with results
            List<Szamla.szamlakSzamla> collectedInvoices = new List<Szamla.szamlakSzamla>();


            //Aggregate invoices based on szamlakibocsato.adoszam
            List<string> adoszamList = new List<string>();
            //Iterate through all the invoices and collect the szamla kibocsatos

            foreach (Szamla.szamlakSzamla oneSzamla in szamlakSzamlaList)
            {
                string adoszam = oneSzamla.szamlakibocsato.adoszam;
                
                // If it's a unique szamlakibocsato (unique adoszam) add to collections
                
                if (!adoszamList.Contains(oneSzamla.szamlakibocsato.adoszam))
                {
                    adoszamList.Add(oneSzamla.szamlakibocsato.adoszam);
                    collectedInvoices.Add(oneSzamla);
                }

                // If it's not a unique szamlakibocsato (Not unique adoszam) then aggregate the Tetelek to a single szamlakibocsato
                
                else
                {
                    //find the first invoice's index
                    int index = collectedInvoices.FindIndex(x => x.szamlakibocsato.adoszam.Contains(adoszam));

                    //Create a Tetelek List of Arrays where we can collect the diferent Tetelek of one TaxNumber to one Invoice
                    
                    List<Szamla.szamlakSzamlaTermek_szolgaltatas_tetelek[]> Tetelek = new List<Szamla.szamlakSzamlaTermek_szolgaltatas_tetelek[]>();

                    Tetelek.Add(collectedInvoices[index].termek_szolgaltatas_tetelek);
                    Tetelek.Add(oneSzamla.termek_szolgaltatas_tetelek);

                    //Replace original Tetelek to the new aggregated one

                    Szamla.szamlakSzamlaTermek_szolgaltatas_tetelek[] ujTetel = new Szamla.szamlakSzamlaTermek_szolgaltatas_tetelek[Tetelek.Count()];
                    int counter = 0;
                    for (int i = 0; i < ujTetel.Count(); i++)
                    {
                        Szamla.szamlakSzamlaTermek_szolgaltatas_tetelek[] oneTetel = new Szamla.szamlakSzamlaTermek_szolgaltatas_tetelek[1];
                        oneTetel = Tetelek[i];
                        ujTetel[i] = oneTetel[0];
                        counter++;
                    }
                    collectedInvoices[index].termek_szolgaltatas_tetelek = ujTetel;

                }
            }
            return collectedInvoices;
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
