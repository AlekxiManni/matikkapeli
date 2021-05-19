using System;


namespace Matikkapeli
{
    class Program
    {

        /// <summary>
        /// Päätetään mihin laskutoimitukseen halutaan edetä. Jokaiselle valinnalle on annettu switch casessa int 2, mikä annetaan Valikko() metodille.
        /// Pistelasku tapahtuu sen jälkeen, kun kaikki pelit on pelattu. Jokaisesta pelistä palautetaan int 1 tai 0. Nämä lasketaan yhteen josta muodostuu pisteet.
        /// </summary>
        /// <param name="taulukko"></param>
        static void MatikkapeliLoop(int[] taulukko)
        {
            int yhteenLasku, vahennusLasku, kertoLasku, jakoLasku;
            yhteenLasku = 2;
            vahennusLasku = 2;
            kertoLasku = 2;
            jakoLasku = 2;
            ConsoleKeyInfo syote;
            char valinta;
            Console.WriteLine();
            bool peli = true;
            do
            {
                Valikko(yhteenLasku, vahennusLasku, kertoLasku, jakoLasku);
                syote = Console.ReadKey();
                valinta = syote.KeyChar;
                Console.WriteLine();
                peli = true;
                switch (valinta)
                {
                    case '1':
                        Console.WriteLine("Valitsit yhteenlaskun");
                        yhteenLasku = YhteenLasku(taulukko);
                        break;
                    
                    case '2':
                        Console.WriteLine("Valitsit vähennyslaskun");
                        vahennusLasku = Program.VahennusLasku(taulukko);
                        break;

                    case '3':
                        Console.WriteLine("Valitsit kertolaskun");
                        kertoLasku = KertoLasku(taulukko);
                        break;

                    case '4':
                        Console.WriteLine("Valitsit jakolaskun");
                        jakoLasku = JakoLasku(taulukko);
                        break;

                    case 'q':
                    case 'Q':
                        Console.WriteLine("Lopetat pelaamisen");
                        peli = false;
                        break;

                    default:
                        Console.WriteLine("Et valinnut mitään, yritä uudelleen");
                        Console.WriteLine();
                        break;
                }
                if (yhteenLasku <= 1 && vahennusLasku <= 1 && kertoLasku <= 1 && jakoLasku <= 1)
                {
                    peli = false;
                }
            } while (peli);

            if (peli == false)
            {
                int pisteet = yhteenLasku + vahennusLasku + kertoLasku + jakoLasku;
                Console.WriteLine();
                if (pisteet == 4)
                {
                    Console.WriteLine("Pisteesi: " + pisteet + ", Onneksi olkoon, sait parhaaan palkinnon! :-)");
                }
                else if (pisteet == 3)
                {
                    Console.WriteLine("Pisteesi: " + pisteet + ", Onneksi olkoon, sait toisiksi parhaimman palkinnon!");
                }
                else if (pisteet < 3)
                {
                    Console.WriteLine("Pisteesi: " + pisteet + ", Valitettavasti jäit tällä kertaa ilman palkintoa :-(");
                }
            }
        }

        /// <summary>
        /// Valitsee mihin laskutoimitukseen halutaan mennä. Jos on jokin peli pelattu, se ei näy enää valikossa
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        static void Valikko(int a, int b, int c, int d) 
        {
            Console.WriteLine();
            Console.WriteLine("Valitse peli kirjoittamalla vastaava numero");
            Console.WriteLine("Paina Q jos haluat lopettaa");
            Console.WriteLine();
            if (a == 2)
            {
                Console.WriteLine("1. Yhteenlasku"); 
            }
            if (b == 2)
            {
                Console.WriteLine("2. Vähennyslasku"); 
            }
            if (c == 2)
            {
                Console.WriteLine("3. Kertolasku"); ;
            }
            if (d == 2)
            {
                Console.WriteLine("4. Jakolasku"); 
            }
        }
        /// <summary>
        /// Taulukko tuodaan vaikeustason mukaan jokaiseen laskutoimituspeliin. Taulukko arpoo yhteensä 4 eri lukua.
        /// Jokaisessa laskutoimituspelissä arvotaan vielä taulukon arvo uudelleen, ettei tule samoja kysymyksiä useasti peräkkäin muihin laskupeleihin
        /// </summary>
        /// <param name="taulukko"></param>
        /// <returns></returns>
        static int YhteenLasku(int[] taulukko)
        {
            Random arvottu = new Random();
            int x,y;
            x = arvottu.Next(1, 4);
            y = arvottu.Next(1, 4);
            int vastaus;
            Console.WriteLine();
            Console.WriteLine("Paljonko on " + taulukko[x] + " + " + taulukko[y] + "  ? ");
            Console.Write("> ");
            try
            {

                vastaus = int.Parse(Console.ReadLine());
                if (vastaus == taulukko[x] + taulukko[y])
                {
                    Console.WriteLine("Oikea vastaus!");
                    return 1;
                }
                else
                {
                    Console.WriteLine("Väärä vastaus!");
                    return 0;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Et antanut numeroa, yritä uudelleen");
                return 2;
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Et antanut mitään, yritä uudelleen");
                return 2;
            }
        }
        /// <summary>
        /// Lue metodin YhteenLasku summary
        /// </summary>
        /// <param name="taulukko"></param>
        /// <returns></returns>
        static int VahennusLasku(int[] taulukko)
        {
            Random arvottu = new Random();
            int x, y;
            x = arvottu.Next(1, 4);
            y = arvottu.Next(1, 4);
            int vastaus;
            Console.WriteLine();
            Console.WriteLine("Paljonko on " + taulukko[x] + " - " + taulukko[y] + "  ? ");
            Console.Write("> ");
            try
            {
                vastaus = int.Parse(Console.ReadLine());
                if (taulukko[x] - taulukko[y] == vastaus)
                {
                    Console.WriteLine("Oikea vastaus!");
                    return 1;
                }
                else
                {
                    Console.WriteLine("Väärä vastaus!");
                    return 0;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Et antanut numeroa, yritä uudelleen");
                return 2;
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Et antanut mitään, yritä uudelleen");
                return 2;
            }
        }
        /// <summary>
        /// Lue metodin YhteenLasku summary
        /// </summary>
        /// <param name="taulukko"></param>
        /// <returns></returns>
        static int KertoLasku(int[] taulukko)
        {
            Random arvottu = new Random();
            int x, y;
            x = arvottu.Next(1, 4);
            y = arvottu.Next(1, 4);
            int vastaus;
            Console.WriteLine();
            Console.WriteLine("Paljonko on " + taulukko[x] + " * " + taulukko[y] + "  ? ");
            Console.Write("> ");
            try
            {
                vastaus = int.Parse(Console.ReadLine());
                if (taulukko[x] * taulukko[y] == vastaus)
                {
                    Console.WriteLine("Oikea vastaus!");
                    return 1;
                }
                else
                {
                    Console.WriteLine("Väärä vastaus!");
                    return 0;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Et antanut numeroa, yritä uudelleen");
                return 2;
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Et antanut mitään, yritä uudelleen");
                return 2;
            }
        }
        /// <summary>
        /// Sama käytäntö kuin muissa laskupeleissä, mutta kysymyksen ensimmäinen muuttuja taulukko[0] on vakiona sen vuoksi, ettei tule nollalla jakoja. En lisännyt DividedByZeroExeptionia sen takia.
        /// </summary>
        /// <param name="taulukko"></param>
        /// <returns></returns>
        static int JakoLasku(int[] taulukko)
        {
            Random arvottu = new Random();
            int x, y;
            x = arvottu.Next(1, 4);
            y = arvottu.Next(1, 4);
            int vastaus;
            Console.WriteLine();
            Console.WriteLine("Paljonko on " + taulukko[0] + " / " + taulukko[y] + "  ? ");
            Console.Write("> ");
            try
            {
                vastaus = int.Parse(Console.ReadLine());
                if (taulukko[0] / taulukko[y] == vastaus)
                {
                    Console.WriteLine("Oikea vastaus!");
                    return 1;
                }
                else
                {
                    Console.WriteLine("Väärä vastaus!");
                    return 0;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Et antanut numeroa, yritä uudelleen");
                return 2;
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Et antanut mitään, yritä uudelleen");
                return 2;
            }
        }
        /// <summary>
        /// Valitaan vaikeusaste. Palautetaan string -muuttuja uuteen metodiin mikä arpoo luvut peleihin
        /// </summary>
        /// <returns></returns>
        static string VaikeusTaso()
        {
            string pelivalinta = "";
            string helppo = "";
            string keskivaikea = "";
            string vaikea = "";
            Console.WriteLine("Tervetuloa matikkapeliin");
            Console.WriteLine();
            Console.WriteLine("Valitse vaikeustaso");
            Console.WriteLine("1. HELPPO");
            Console.WriteLine("2. KESKIVAIKEA");
            Console.WriteLine("3. VAIKEA");
            ConsoleKeyInfo syote;
            char valinta;
            bool peli;
            do
            {

                //muista laittaa aina do whilen sisään käyttäjän syötteet, että saadaan looppi toimimaan
                syote = Console.ReadKey();
                valinta = syote.KeyChar;
                Console.WriteLine();
                peli = true;
                switch (valinta)
                {
                    case '1':
                        helppo = "helppo";
                        return helppo;
                    case '2':
                        keskivaikea = "keskivaikea";
                        return keskivaikea;
                    case '3':
                        vaikea = "vaikea";
                        return vaikea;
                    default:
                        Console.WriteLine("Yritä uudelleen");
                        peli = true;
                        continue;
                }
            } while (peli);
            return pelivalinta;
        }

        /// <summary>
        /// Metodin idea on se että ottaa vastaan vaikeustason ja vaikeustason perusteella arvotaan erikokoisia random -lukuja riippuen siitä miten vaikea se on. 
        /// Tallennetaan luvut taulukkon. Arvotut luvut palautetaan taulukossa
        /// </summary>
        /// <param name="vaikeustaso"></param>
        static int[] VaikeustasoValittu(string vaikeustaso)
        {
            Random numero1 = new Random();
            int[] taulukko = new int[4];

            switch (vaikeustaso)
            {
                case "helppo":
                    Console.WriteLine("VALITSIT HELPON VAIKEUSASTEEN");
                    taulukko[0] = numero1.Next(1, 5);
                    taulukko[1] = numero1.Next(6, 11);
                    taulukko[2] = numero1.Next(1, 7);
                    taulukko[3] = numero1.Next(8, 12);
                    return taulukko;

                case "keskivaikea":
                    Console.WriteLine("VALITSIT KESKIVAIKEAN VAIKEUSASTEEN");
                    taulukko[0] = numero1.Next(1, 20);
                    taulukko[1] = numero1.Next(-5, 2);
                    taulukko[2] = numero1.Next(15, 36);
                    taulukko[3] = numero1.Next(-4, 16);
                    return taulukko;

                case "vaikea":
                    Console.WriteLine("VALITSIT VAIKEAN VAIKEUSASTEEN");
                    taulukko[0] = numero1.Next(1, 101);
                    taulukko[1] = numero1.Next(-101, 101);
                    taulukko[2] = numero1.Next(-50, 151);
                    taulukko[3] = numero1.Next(-100, -51);
                    return taulukko;
            }
            return taulukko;
        }

        static void Main(string[] args)
        {
            int[] taulukko = new int[4];
            string vaikeustaso = VaikeusTaso();
            taulukko = VaikeustasoValittu(vaikeustaso);
            MatikkapeliLoop(taulukko);
        }
    }
}
