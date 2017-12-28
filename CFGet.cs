using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CF
{
    class CFGet 
    {
        string csesso="F";
        string path;

        public CFGet(string pathCatastali)
        {
            path = pathCatastali;
        }

        private string GetVocals(string testo)
        {
            var newvoc = new StringBuilder();
            string vocals = "AEIOUaeiou";
            for (int i=0; i<testo.Length; i++)
            {
                if (vocals.Contains(testo[i]))
                {
                    newvoc.Append(testo[i]);
                }
            }

            return newvoc.ToString().ToUpper();
        }

        private string GetConsonants(string testo)
        {
            var newcons = new StringBuilder();
            string cons = "BCDFGHJKLMNPQRSTVWXYZbcdfghjklmnpqrstvwxyz";
            for (int i = 0; i < testo.Length; i++)
            {
                if (cons.Contains(testo[i]))
                {
                    newcons.Append(testo[i]);
                }
            }

            return newcons.ToString().ToUpper();
        }

        public string GetSurname(string testo)
        {
            var tvoc = new StringBuilder();
            string testoc = GetConsonants(testo);
            if (testoc.Length >= 3)
            {
                testoc = testoc.Substring(0, 3);
                return testoc;
            }

            if (testoc.Length < 3)
            {
                tvoc.Append(testoc);
                tvoc.Append(GetVocals(testo));

                if (tvoc.Length >= 3)
                {
                    return tvoc.ToString().ToUpper().Substring(0,3);
                }
                else
                {
                    tvoc.Append("XXX");
                    return tvoc.ToString().Substring(0, 3);
                }
            }

            return "XXX";


        }

        public string GetName(string testo)
        {
            var tvoc = new StringBuilder();
            string testoc = GetConsonants(testo);
            if (testoc.Length > 3)
            {
                var testo4 = new StringBuilder();
                testo4.Append(testoc[0]);
                testo4.Append(testoc[1]);
                testo4.Append(testoc[3]);
                return testo4.ToString().ToUpper();
            }

            if (testoc.Length == 3)
            {
                testoc = testoc.Substring(0, 3);
                return testoc;
            }

            if (testoc.Length < 3)
            {
                tvoc.Append(testoc);
                tvoc.Append(GetVocals(testo));

                if (tvoc.Length >= 3)
                {
                    return tvoc.ToString().ToUpper().Substring(0, 3);
                }
                else
                {
                    tvoc.Append("XXX");
                    return tvoc.ToString().Substring(0, 3);
                }
            }

            return "XXX";
        }

        public string GetDate(DateTime data)
        {

            //ottengo il giorno
            string giorno = "";
            string anno;

            if (data.Day.ToString().Length == 1)
            {
                giorno = "0" + data.Day;
            }
            else
            {
                giorno = data.Day.ToString();
            }

            if (csesso == "F")
            {
                giorno = (int.Parse(giorno) + 40).ToString();
            }

            //ottengo il mese
            Dictionary<int, string> months = new Dictionary<int, string>();
            months.Add(1, "A");
            months.Add(2, "B");
            months.Add(3, "C");
            months.Add(4, "D");
            months.Add(5, "E");
            months.Add(6, "H");
            months.Add(7, "L");
            months.Add(8, "M");
            months.Add(9, "P");
            months.Add(10, "R");
            months.Add(11, "S");
            months.Add(12, "T");

            anno = data.Year.ToString().Substring(2,2);
            return (anno + months[data.Month] + giorno);
        }

        public string GetCF(string cognome, string nome, string sesso, DateTime data, string comune)
        {
            csesso = sesso.ToUpper();
            try
            {
                string fullCode = ((GetSurname(cognome) + GetName(nome) + GetDate(data) + GetCity(comune)).ToUpper());
                return fullCode + GetCIN(fullCode);
            }
            catch
            {
                throw new Exception("Impossibile generare il codice fiscale: alcuni dati non potrebbero essere indicati correttamente");
            }
        }

        public string GetCity(string city)
        {
            city = city.ToLower();
                StreamReader sr = new StreamReader(path);
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().ToLower().Split(';');
                    if (line[0] == city)
                    {
                        return line[2].ToUpper();
                    }
                }
            return "0000";
        }

        public string GetCIN(string code)
        {
            Dictionary<string, int> pairs = new Dictionary<string, int>();
            pairs.Add("0", 0);
            pairs.Add("1", 1);
            pairs.Add("2", 2);
            pairs.Add("3", 3);
            pairs.Add("4", 4);
            pairs.Add("5", 5);
            pairs.Add("6", 6);
            pairs.Add("7", 7);
            pairs.Add("8", 8);
            pairs.Add("9", 9);
            pairs.Add("A", 0);
            pairs.Add("B", 1);
            pairs.Add("C", 2);
            pairs.Add("D", 3);
            pairs.Add("E", 4);
            pairs.Add("F", 5);
            pairs.Add("G", 6);
            pairs.Add("H", 7);
            pairs.Add("I", 8);
            pairs.Add("J", 9);
            pairs.Add("K", 10);
            pairs.Add("L", 11);
            pairs.Add("M", 12);
            pairs.Add("N", 13);
            pairs.Add("O", 14);
            pairs.Add("P", 15);
            pairs.Add("Q", 16);
            pairs.Add("R", 17);
            pairs.Add("S", 18);
            pairs.Add("T", 19);
            pairs.Add("U", 20);
            pairs.Add("V", 21);
            pairs.Add("W", 22);
            pairs.Add("X", 23);
            pairs.Add("Y", 24);
            pairs.Add("Z", 25);

            Dictionary<string, int> odds = new Dictionary<string, int>();
            odds.Add("0", 1);
            odds.Add("1", 0);
            odds.Add("2", 5);
            odds.Add("3", 7);
            odds.Add("4", 9);
            odds.Add("5", 13);
            odds.Add("6", 15);
            odds.Add("7", 17);
            odds.Add("8", 19);
            odds.Add("9", 21);
            odds.Add("A", 1);
            odds.Add("B", 0);
            odds.Add("C", 5);
            odds.Add("D", 7);
            odds.Add("E", 9);
            odds.Add("F", 13);
            odds.Add("G", 15);
            odds.Add("H", 17);
            odds.Add("I", 19);
            odds.Add("J", 21);
            odds.Add("K", 2);
            odds.Add("L", 4);
            odds.Add("M", 18);
            odds.Add("N", 20);
            odds.Add("O", 11);
            odds.Add("P", 3);
            odds.Add("Q", 6);
            odds.Add("R", 8);
            odds.Add("S", 12);
            odds.Add("T", 14);
            odds.Add("U", 16);
            odds.Add("V", 10);
            odds.Add("W", 22);
            odds.Add("X", 25);
            odds.Add("Y", 24);
            odds.Add("Z", 23);

            Dictionary<int, string> cin = new Dictionary<int, string>();
            cin.Add(0, "A");
            cin.Add(1, "B");
            cin.Add(2, "C");
            cin.Add(3, "D");
            cin.Add(4, "E");
            cin.Add(5, "F");
            cin.Add(6, "G");
            cin.Add(7, "H");
            cin.Add(8, "I");
            cin.Add(9, "J");
            cin.Add(10, "K");
            cin.Add(11, "L");
            cin.Add(12, "M");
            cin.Add(13, "N");
            cin.Add(14, "O");
            cin.Add(15, "P");
            cin.Add(16, "Q");
            cin.Add(17, "R");
            cin.Add(18, "S");
            cin.Add(19, "T");
            cin.Add(20, "U");
            cin.Add(21, "V");
            cin.Add(22, "W");
            cin.Add(23, "X");
            cin.Add(24, "Y");
            cin.Add(25, "Z");

            var strPair = new StringBuilder();
            var strOdd = new StringBuilder();
            int Pair = 0;
            int Odd = 0;
            for (int i=0; i<15; i=i+2)
            {
                Odd = Odd + odds[code[i].ToString()];
                strPair.Append(code[i]);
            }
            for (int j=1; j<14; j=j+2)
            {
                Pair = Pair + pairs[code[j].ToString()];
            }
            int allCode = Odd + Pair;
            return cin[(allCode % 26)];
        }
    }
}
