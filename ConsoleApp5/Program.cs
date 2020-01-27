using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp5
{
    class Program
    {
        static int kredithoehe = 15000;
        static bool b = true;
        static bool a = true;
        static double konto = 0;
        static double bar = 0;
        static double schulden = 0;
        static string[] item = new string[12];
        static int counter = 0;
        static double[] itemprice = new double[12];
        static string[] storeitem = new string[] { "TV        ", "Computer  ", "Laptop    ", "Bürotisch ", "Bürostuhl ", "Sofa      ", "Hi-Fi     ", "Radio     ", "Lampe     ", "Bett      ", "Kissen    ",
        "Topf      ", "Buch      ", "Ofen      ", "Besen     ", "Auto      ", "Haus      ", "Wohnung   ", "Velo      ", "Mofa      ", "PrivatJet "};
        static double[] storeprice = new double[] {3000, 1700, 1900, 750, 300, 2500, 1300, 100, 70, 900, 50, 35, 29, 2700, 20, 30000, 1000000, 500000, 600, 1200, 5000000};
        

        static void Main(string[] args)
        {
            while (a)
            {
                win();
                try
                {
                    menu();
                    auswahl(Convert.ToInt32(Console.ReadLine()));
                }

                catch(FormatException)
                {
                    Console.WriteLine("Eingabe nicht Korrekt");
                    Console.ReadKey();
                    continue;
                }
            } 
        }
        static void auswahl(int eingabe)
        {
            if (eingabe == 1)
            {
                Console.Clear();
                Console.WriteLine("Wie viel wollen sie einzahlen:");
                barcontrolle(Convert.ToDouble(Console.ReadLine()));
            }
            else if (eingabe == 2)
            {
                Console.Clear();
                Console.WriteLine("Wie viel wollen sie abheben:");
                kontocontrolle(Convert.ToDouble(Console.ReadLine()));
            }
            else if (eingabe == 3)
            {
                Console.Clear();
                if (konto > kredithoehe)
                {
                    kredithoehe += kredithoehe;
                }
                Console.WriteLine("Wie viel Kredit wollen sie haben: \n\rDein Kredit wird mit 10% Zins verrechnet. \n\rIhr Kreditlimit: " + kredithoehe);
                addbar(Convert.ToDouble(Console.ReadLine()));
            }
            else if (eingabe == 4)
            {
                Console.Clear();
                Console.WriteLine("Wie viel wollen sie zurückbezahlen:");
                dropbar(Convert.ToDouble(Console.ReadLine()));
            }
            else if (eingabe == 5)
            {
                string punkt = ".";
                string abstand = " ";
                Console.Clear();
                Console.Write("Sie werden zum Shop weitergeleitet");
                for(int i = 0; i < 10; i++)
                {
                    Console.Write(punkt);
                    abstand += punkt;
                    Thread.Sleep(150);
                }
                b = true;
                shopmenu();

            }
            else if (eingabe == 6)
            {
                a = false;
            }
            else
            {
                Console.WriteLine("Eingabe nicht Korrekt");
                Console.ReadKey();
            }
        }
        static void auswahlshop(int auswahl)
        {
            if (auswahl == 1)
            {
                while (true)
                {
                    string ein = "kaufen";
                    Console.Clear();
                    DateTime aDateTime = DateTime.Now;
                    Console.WriteLine(aDateTime +"\n\rBargeld " + bar + " CHF");
                    Console.WriteLine("Welches Item möchten sie kaufen.");
                    einkauf();
                    if (more(ein) == true)
                    {
                        
                    }
                    else
                    {
                        break;
                    }
                    
                }
                
            }
            else if (auswahl == 2)
            {
                while (true)
                {
                    string aus = "verkaufen";
                    Console.Clear();
                    DateTime aDateTime = DateTime.Now;
                    Console.WriteLine(aDateTime + "\n\rBargeld " + bar + " CHF");
                    Console.WriteLine("Welches Item möchten sie verkaufen.");
                    verkauf();
                    if (more(aus) == true)
                    {

                    }
                    else
                    {
                        break;
                    }
                }
            }
            else if (auswahl == 3)
            {
                Console.WriteLine("Sie verlassen den Shop...");
                Console.ReadKey();
                b = false;
            }
            else
            {
                Console.WriteLine("Eingabe nicht korrekt.");
                Console.ReadKey();
            }
        }
        static void auswahleinkauf(int auswahl)
        {
            if (auswahl <= storeitem.Length && auswahl >= 0)
            {
                if (storeprice[auswahl - 1] > bar)
                {
                    Console.WriteLine("Sie haben zu wenig Bargeld um das zu Kaufen.");
                    Console.ReadKey();
                }
                else
                {
                    
                        while (true)
                        {
                            if ((counter) == item.Length)
                            { 
                                counter = 0;
                            }
                            else if (itemprice[counter] == 0)
                            {
                            
                                item[counter] = storeitem[auswahl - 1];
                                itemprice[counter] = (storeprice[auswahl - 1] / 100 * 15) + storeprice[auswahl - 1];
                                bar -= storeprice[auswahl - 1];
                                counter++;
                                break;
                            }
                            else
                            {
                                counter++;
                            }

                        }
                  
                    
                }
            }
            else
            {
                Console.WriteLine("Eingabe nicht korrekt");
                Console.ReadKey();
            }
        }
        static bool more(string einver)
        {
            Console.WriteLine("Möchten sie noch was " + einver + " (j) ja (n) nein");
            try
            {
                if (Console.ReadLine() == "j")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Eingabe nicht Korrekt");
                return false;
            }
            
        }
        static void auswahlverkauf(int auswahl)
        {
            try
            {
                if (itemprice[auswahl - 1] != 0)
                {
                    Console.WriteLine("Du hast " + item[auswahl - 1] + " für " + itemprice[auswahl - 1] + " verkauft.");
                    item[auswahl - 1] = null;
                    bar += itemprice[auswahl - 1];
                    itemprice[auswahl - 1] = 0;
                }
                else
                {
                    Console.WriteLine("An diesem Slot ist kein Item.");
                    Console.ReadKey();
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("An diesem Slot ist kein Item.");
                Console.ReadKey();
            }
            catch (FormatException)
            {
                Console.WriteLine("Eingabe nicht korrekt.");
                Console.ReadKey();
            }
        }
        static void menu()
        { 

            DateTime aDateTime = DateTime.Now;
            Console.Clear();
            Console.WriteLine("Das ist ihre Investment Firma\n\r" + aDateTime + "\n\rSchaffen Sie 10 Mio auf dem Konto und 0 Schulden");
            Console.WriteLine("Dein Kontostand: {0} CHF \n\rDein Bargeld: {1} CHF \n\rDeine Schulden: {2} CHF\n\r", konto, bar, schulden);
            Console.WriteLine("(1) Geld einzahlen \n\r(2) Geld auszahlen \n\r(3) Kredit beantragen \n\r(4) Kredit zurück zahlen \n\r(5) Zum Shop \n\r(6) Beenden.."); 
        }
        static void shopmenu()
        {
            while (b)
            {
                try
                {
                    Console.Clear();
                    DateTime aDateTime = DateTime.Now;
                    Console.WriteLine(aDateTime + "\n\rBargeld " + bar + " CHF");
                    Console.WriteLine("(1) Einkaufen \n\r(2) Verkaufen \n\r(3) Shop verlassen");
                    auswahlshop(Convert.ToInt32(Console.ReadLine()));
                }
                catch (FormatException)
                {
                    Console.WriteLine("Eingabe nicht korrekt.");
                    Console.ReadKey();
                    continue;
                }
            }
        }
        static void verkauf()
        {
            for (int i = 0; i < item.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + item[i] + "\t" + itemprice[i] + " CHF");
            }
            itemselectionverkauf();
        }
        static void einkauf()
        { 
            for (int i = 0; i < storeitem.Length; i++)
            {
                Console.WriteLine((i+1) + ". " + storeitem[i] + "\t" + storeprice[i] + " CHF");
            }
            itemselectioneinkauf();
        }
        static void itemselectioneinkauf()
        {
            try
            {
                Console.WriteLine("Was möchten sie kaufen:");
                auswahleinkauf(Convert.ToInt32(Console.ReadLine()));
            }
            catch(FormatException)
            {
                Console.WriteLine("Eingabe nicht korrekt");
            }

        }
        static void itemselectionverkauf()
        {
            try
            {
                Console.WriteLine("Was möchten sie verkaufen:");
                auswahlverkauf(Convert.ToInt32(Console.ReadLine()));
            }
            catch (FormatException)
            {
                Console.WriteLine("Eingabe nicht korrekt");
            }
        }
        static void barcontrolle(double geld)
        {
            if (geld > bar)
            {
                Console.WriteLine("Der eingebene Betrag ist höher wie ihr Barvermögen");
                Console.ReadKey();
            }
            else
            {
                addgeld(geld);
            }
        }
        static void kontocontrolle(double geld)
        {
            if (geld > konto)
            {
                Console.WriteLine("Der eingegebene Betrag ist höher als der Kontostand");
                Console.ReadKey();
            }
            else
            {
                dropgeld(geld);
            }
        }
        static void addgeld(double geld)
        {
            konto += geld;
            bar -= geld;
        }
        static void dropgeld(double geld)
        {
            konto -= geld;
            bar += geld;
        }
        static void addbar(double geld)
        {
            if (geld > kredithoehe)
            {
                Console.WriteLine("Ihre Anfrage übersteigt ihre Liquidät");
                Console.ReadKey();
            }
            else
            {
                bar += geld;
                kreditzins(geld);
            }
        }
        static void dropbar(double geld)
        {
            if (geld > bar)
            {
                Console.WriteLine("Sie haben zu wenig Bargeld");
                Console.ReadKey();
            }
            else
            {
                if ((schulden - geld) < 0)
                {
                    Console.WriteLine("Die Eingabe übersteigt ihre Schuld.");
                    Console.ReadKey();
                }
                else
                {
                    schulden -= geld;
                    bar -= geld;
                }
            }  
        }      
        static void kreditzins(double kredit)
        {
            kredit += kredit / 100 * 10;
            schulden += kredit;
        }
        static bool win()
        {
            if(konto == 10000000 && schulden == 0)
            {
                return a = false;
            }
            else
            {
                return a;
            }
        }
    }
}
