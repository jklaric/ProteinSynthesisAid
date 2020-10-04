using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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
               met, phe, pro, tyr, asn, cys, asp, gln, glu, leu, ser, hsi, val, stop
            };
            var tuba8 = new List<string>()
            {
               met, ile, lys, phe, thr, ala, cys, gly, trp, arg, pro, tyr, ser, asp, gln, stop
            };
            var gloverin = new List<string>()
            {
               met, gln, ser, tyr, leu, ala, hsi, arg, asn, trp, cys, val, pro, gln, stop
            };
            var myosinI = new List<string>()
            {
               met, hsi, tyr, leu,  ser, trp, lys, phe, thr, glu, cys, stop
            };
            var coro1A = new List<string>()
            {
               met, asn, glu, gly, asp, pro, gln, cys, lys, phe, trp, ala, tyr, stop
            };
            var cadherin = new List<string>()
            {
               met, lys, ala, glu, arg, trp, ile, val, asp, lys, pro, trp, phe, stop
            };
            var ependymin = new List<string>()
            {
               met, tyr, trp, asp, ala, arg, asn, phe, pro, lys, cys, tyr, stop
            };
            var scramblase = new List<string>()
            {
               met, hsi, lys, trp, tyr, thr, pro, leu, cys, asn, hsi, ser, asp, stop
            };
            var neurophysin = new List<string>()
            {
               met, cys, hsi, pro, phe, tyr, ala, arg, trp, stop
            };
            var foxg1 = new List<string>()
            {
               met, val, tyr, trp, hsi, asn, arg, ala, pro, thr, lys, cys, stop
            };
            var srrt = new List<string>()
            {
               met, hsi, trp, tyr, lys, glu, gln, cys, val, gly, thr, hsi, glu, asp, stop
            };
            var ferritin = new List<string>()
            {
               met, glu, tyr, val, hsi, cys, lys, trp, ala, gly, asn, asp, lys, gln, stop
            };
            var groel = new List<string>()
            {
               met, val, hsi, lys, cys, glu, gly, lys, leu, hsi, asp, ala, asn, stop
            };

            var proteinNames = new Dictionary<string, List<string>>();
            proteinNames.Add("krt31", krt31);
            proteinNames.Add("tuba8", tuba8);
            proteinNames.Add("gloverin", gloverin);
            proteinNames.Add("myosinI", myosinI);
            proteinNames.Add("coro1A", coro1A);
            proteinNames.Add("cadherin", cadherin);
            proteinNames.Add("ependymin", ependymin);
            proteinNames.Add("scramblase", scramblase);
            proteinNames.Add("neurophysin",neurophysin);
            proteinNames.Add("foxg1", foxg1);
            proteinNames.Add("srrt", srrt);
            proteinNames.Add("ferritin", ferritin);
            proteinNames.Add("groel", groel);

            var proteinList = new List<List<string>>()
            {
                krt31, tuba8, gloverin, myosinI, coro1A, cadherin, ependymin, scramblase, neurophysin, foxg1, srrt, ferritin, groel
            };

            Console.WriteLine();
            Console.WriteLine("Please, enter the name of a protein, or a codon sequence.");
            var userInput = Console.ReadLine();

            var codon = FindCodon(userInput, proteinList, proteinNames);

            if (FindCodon(userInput, proteinList, proteinNames) != "error")
            {
                Console.WriteLine("The following is the sequence of protein " + userInput + ": " + codon);
                Console.WriteLine("The anticodon of the protein sequence is " + FindAnticodon(codon));
            }
            else
            {
                codon = userInput;

                Console.WriteLine("The sequence you entered corresponds with the protein : " + IsProtein(userInput, proteinList, proteinNames));
                Console.WriteLine("The anticodon of that protein is: " + FindAnticodon(codon));
            }
        }

        static string FindCodon(string userInput, List<List<string>> proteinList, Dictionary<string, List<string>> proteinNames)
        {
            var proteinReturn = "error";

                if (proteinNames.ContainsKey(userInput))
                {
                    proteinReturn = string.Join("", proteinNames[userInput]);
                }

            return proteinReturn;
        }

        static string IsProtein(string userInput, List<List<string>> proteinList, Dictionary<string, List<string>> proteinNames)
        {
            var proteinReturn = "no proteins.";

            foreach (var value in proteinNames)
            {
                if (string.Join("", value.Value) == userInput)
                {
                    proteinReturn = value.Key;
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
