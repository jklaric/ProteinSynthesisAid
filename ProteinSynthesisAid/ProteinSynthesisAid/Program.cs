using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

            //foreach (var aminoAcid in foxg1)
            //{
            //    Console.Write(aminoAcid);
            //} 
            //this is used for getting a valid sequence for debugging

            Console.WriteLine();
            Console.WriteLine("Please, enter an amino-acid sequence in codone triplets.");
            var userInput = Console.ReadLine();

            Console.WriteLine("The entered sequence corresponds with " + isProtein(userInput, proteinList));

        }

        static string isProtein(string userInput, List<List<string>> proteinList)
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
    }
}
