using System.Numerics;

namespace A01_CRIPTOGRAFIA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string paraulaClau = "Marc";
            int m = 2;
            string missatge = "Jose Mourinho";
            string missatgeEncriptat = Encriptacio(m, paraulaClau, missatge);
            Console.WriteLine(missatgeEncriptat);
        }

        public static string Encriptacio(int m, string paraulaClau, string missatge)
        {
            paraulaClau = paraulaClau.ToLower();
            missatge = missatge.Replace(" ", "");
            m = missatge.Length / paraulaClau.Length;
            char[,] matriu = new char[m, paraulaClau.Length];
            int[] clau = new int[paraulaClau.Length];
            char[] msgSeparat = new char[missatge.Length];
            for (int i = 0; i < missatge.Length; i++)
            {
                msgSeparat[i] = missatge[i];
            }
            int k = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < paraulaClau.Length; j++)
                {
                    matriu[i, (char)j] = msgSeparat[k];
                    k++;
                }
            }
            int[] ordenat = new int[paraulaClau.Length];
            List<char> sortedChars = paraulaClau.ToList();
            sortedChars.Sort();

            for (int i = 0; i < ordenat.Length; i++)
            {
                char currentChar = paraulaClau[i];
                int position = sortedChars.IndexOf(currentChar) + 1;
                ordenat[i] = position;
            }
            string missatgeEncriptat = "";
            for (int i = 1; i <= paraulaClau.Length; i++)
            {
                int colIndex = Array.IndexOf(ordenat, i);
                for (int j = 0; j < m; j++)
                {
                    missatgeEncriptat += matriu[j, colIndex];
                }
            }
            return missatgeEncriptat;
        }
    }
}
