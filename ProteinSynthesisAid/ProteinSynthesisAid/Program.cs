using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.VisualBasic;

namespace ProteinSynthesisAid
{
    class Program
    {
        static void Main(string[] args)
        {
            var phe = "UUC";
            var leu = "UUG";
            var ile = "AUC";
            var met = "AUG";
            var val = "GUC";
            var ser = "UCG";
            var pro = "CCG";
            var thr = "ACC";
            var ala = "GCA";
            var tyr = "UAU";
            var stop = "UAG";
            var hsi = "CAC";
            var gln = "CAG";
            var asn = "AAC";
            var lys = "AAA";
            var asp = "GAU";
            var glu = "GAG";
            var cys = "UGC";
            var trp = "UGG";
            var arg = "CGG";
            var gly = "GGG";

            var krt31 = new List<string>()
            {
               "krt31", met, phe, pro, tyr, asn, cys, asp, gln, glu, leu, ser, hsi, val, stop
            };
            var tuba8 = new List<string>()
            {
               "tuba8", met, ile, lys, phe, thr, ala, cys, gly, trp, arg, pro, tyr, ser, asp, gln, stop
            };
            var gloverin = new List<string>()
            {
               "gloverin", met, gln, ser, tyr, leu, ala, hsi, arg, asn, trp, cys, val, pro, gln, stop
            };
            var myosinI = new List<string>()
            {
               "myosinI", met, hsi, tyr, leu,  ser, trp, lys, phe, thr, glu, cys, stop
            };
            var coro1A = new List<string>()
            {
               "coro1A", met, asn, glu, gly, asp, pro, gln, cys, lys, phe, trp, ala, tyr, stop
            };
            var cadherin = new List<string>()
            {
               "cadherin", met, lys, ala, glu, arg, trp, ile, val, asp, lys, pro, trp, phe, stop
            };
            var ependymin = new List<string>()
            {
               "ependymin", met, tyr, trp, asp, ala, arg, asn, phe, pro, lys, cys, tyr, stop
            };
            var scramblase = new List<string>()
            {
               "scramblase", met, hsi, lys, trp, tyr, thr, pro, leu, cys, asn, hsi, ser, asp, stop
            };
            var neurophysin = new List<string>()
            {
               "neurophysin", met, cys, hsi, pro, phe, tyr, ala, arg, trp, stop
            };
            var foxg1 = new List<string>()
            {
               "foxg1", met, val, tyr, trp, hsi, asn, arg, ala, pro, thr, lys, cys, stop
            };
            var srrt = new List<string>()
            {
               "srrt", met, hsi, trp, tyr, lys, glu, gln, cys, val, gly, thr, hsi, glu, asp, stop
            };
            var ferritin = new List<string>()
            {
               "ferritin", met, glu, tyr, val, hsi, cys, lys, trp, ala, gly, asn, asp, lys, gln, stop
            };
            var groel = new List<string>()
            {
               "groel", met, val, hsi, lys, cys, glu, gly, lys, leu, hsi, asp, ala, asn, stop
            };

            var proteinList = new List<List<string>>()
            {
                krt31, tuba8, gloverin, myosinI, coro1A, cadherin, ependymin, scramblase, neurophysin, foxg1, srrt, ferritin, groel
            };

            Console.WriteLine();
            Console.WriteLine("Please, enter the name of a protein, or a codon sequence.");
            var userInput = Console.ReadLine();

            var codon = FindCodon(userInput, proteinList);

            if (FindCodon(userInput, proteinList) != "error")
            {
                Console.WriteLine("The following is the sequence of protein " + userInput + ": " + codon);
                Console.WriteLine("The anticodon of the protein sequence is " + FindAnticodon(codon));
            }
            else
            {
                codon = userInput;

                Console.WriteLine("The sequence you entered corresponds with the protein : " + IsProtein(userInput, proteinList));
                Console.WriteLine("The anticodon of that protein is: " + FindAnticodon(codon));
            }
        }

        static string FindCodon(string userInput, List<List<string>> proteinList)
        {
            var proteinReturn = "error";

            for (int i = 0; i < proteinList.Count - 1; i++)
            {
                if (userInput == proteinList[i][0])
                {
                    proteinReturn = string.Join("", proteinList[i].Skip(1));
                }
            }

            return proteinReturn;
        }

        static string IsProtein(string userInput, List<List<string>> proteinList)
        {
            var proteinReturn = "no proteins.";

            for (int i = 0; i < proteinList.Count - 1; i++)
            {
                if (userInput.Contains(string.Join("", proteinList[i].Skip(1))))
                {
                    proteinReturn = proteinList[i][0];
                }
            }

            return proteinReturn;
        }

        static string FindAnticodon(string codon)
        {
            var anticodon = "";
            var counter = 0;

            foreach (var character in codon)
            {
                switch (character)
                {
                    case 'A':
                        anticodon = anticodon.Insert(counter, "U");
                        break;
                    case 'C':
                        anticodon = anticodon.Insert(counter, "G");
                        break;
                    case 'G':
                        anticodon = anticodon.Insert(counter, "C");
                        break;
                    case 'U':
                        anticodon = anticodon.Insert(counter, "A");
                        break;
                }

                counter++;
            }

            return anticodon;
        }
    }
}
