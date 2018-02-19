using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            var autori = new List<string>();
            autori.Add("Cristi Voievod");
            Carte carte = new Carte("Baba cloanta", autori);

            var sectiune = new Sectiune("Sectiune 1");
            sectiune.Add(new Paragraf("Paragraful intai"));
            sectiune.Add(new Tabel("Tipuri de mancaruri"));
            var image = new ImageProxy("Image1");               //proxy care adauga o imagine concreta
            var image2 = new Image("Image2");
            Tabel tab = new Tabel("Tabel1");

            carte.AddContinut(sectiune);
            carte.AddContinut(tab);
            carte.AddContinut(image);
            carte.AddContinut(image2);

            carte.Print();                          //initializeaza imaginea concreta din ImageProxy

            
            var dsv = new DocumentStateVisitor(); //visitor numara elementele din carte
            carte.AcceptVisitor(dsv);
            dsv.PrintStatistics();
            

            
            var paragraf = new Paragraf("Paragraf");
            paragraf.SetAlign("center");
            paragraf.Print();
            paragraf.SetAlign("left");
            paragraf.Print();
            paragraf.SetAlign("right");             //stabileste strategia de aliniare a paragrafului
            paragraf.Print();
            

            

            Console.WriteLine();
        }
    }
}
