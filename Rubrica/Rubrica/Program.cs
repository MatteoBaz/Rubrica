using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Rubrica
{
    class Program
    {
        static void Main(string[] args)
        {
            //RUBRICA: Registrare, cercare, visualizzare, eliminare, fine

            //DICHIARAZIONE VARIABILI
            const int DIM = 5;
            int x = 10;
            int y = 5;
            string cellulare = "Agenda";
            int i = 0;

            //COLORI
            ConsoleColor coloreTitolo = ConsoleColor.White;
            ConsoleColor coloreOpzioni = ConsoleColor.White;
            ConsoleColor sfondoMenu = ConsoleColor.Black;
            
            //PROGRAMMA
            string[] opzioni = new string[] { "Inserimento", "Ricerca", "Visualizza", "Rimuovi", "Fine" } ;
            string[] persone = new string[DIM];

            Menu(opzioni, cellulare, x, y, coloreTitolo, coloreOpzioni, sfondoMenu);

            int scelta = Convert.ToInt32(Console.ReadLine());
            switch (scelta)
            {
                case 1:
                    if (numeroPersone>DIM)
                    {
                        Console.WriteLine("Rubrica piena");
                    }
                    else
                    {
                        Console.Write("Inserire il cognome: ");
                        persone[i] = Console.ReadLine();
                        Console.Write("Inserire il nome: ");
                        persone[i] += " " + Console.ReadLine();
                    }
                    break;
            }
        }

        static string ScriviNelPannello(int x, int y, int lunghezzaPannello, ConsoleColor colorePannello)
        {
            ConsoleKeyInfo tasto;
            int cnt = 0;
            string frase = "";

            //creo il pannello
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = colorePannello;
            for (int i = x; i < x + lunghezzaPannello; i++)
                Console.Write(" ");

            Console.SetCursorPosition(x, y);
            do
            {
                tasto = Console.ReadKey(true);

                if (cnt < lunghezzaPannello)
                {
                    Console.Write(tasto.KeyChar);
                    frase += tasto.KeyChar;
                    cnt++;
                }
            } while (tasto.Key != ConsoleKey.Enter);

            return frase;
        }
        static void PosizionaStringa(string frase, int x, int y, ConsoleColor coloreCarattere, ConsoleColor coloreSfondo)
        {
            ConsoleColor sfondoConsole = Console.BackgroundColor;
            ConsoleColor caratteriConsole = Console.ForegroundColor;
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = coloreSfondo;
            Console.ForegroundColor = coloreCarattere;
            Console.WriteLine(frase);
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = sfondoConsole;
            Console.ForegroundColor = caratteriConsole;
        }

        static int Menu(string[] vett, string intestazione, int x, int y, ConsoleColor coloreTitolo, ConsoleColor coloreOpzioni, ConsoleColor sfondoMenu)
        {
            int scelta = 0;
            const string SEGNALAZIONERRORE = "Errore: le opzioni vanno da 1 a 5";

            //set colori
            Console.BackgroundColor = sfondoMenu;
            Console.ForegroundColor = coloreTitolo;
            Console.SetCursorPosition(x, y);

            Console.WriteLine("======= {0} =======", intestazione);

            Console.ForegroundColor = coloreOpzioni;
            for (int i = 0; i < vett.Length; i++)
            {
                y = y + 2;
                Console.SetCursorPosition(x, y);
                Console.WriteLine("[{0}] - {1}", i + 1, vett[i]);
            }
            y = y + 2;

            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = coloreTitolo;

            for (int i = 0; i < intestazione.Length + 14; i++)
                Console.Write("=");

            y = y + 2;

            do
            {
                Console.ForegroundColor = coloreTitolo;
                Console.SetCursorPosition(x, y);
                Console.Write("Inserisci la tua scelta: ");
                scelta = Convert.ToInt32(Console.ReadLine());
                if (scelta > vett.Length || scelta < 0)
                {
                    y = y + 3;
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(SEGNALAZIONERRORE + " " + vett.Length);
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(x, y);
                    for (int i = 0; i < SEGNALAZIONERRORE.Length + 2; i++)
                        Console.Write(" ");
                    y = y - 2;
                    Console.SetCursorPosition(x, y);
                    Console.Write(" ");
                    y = y - 1;
                }

            } while (scelta > vett.Length || scelta < 0);

            return scelta;
        }
    }
}
