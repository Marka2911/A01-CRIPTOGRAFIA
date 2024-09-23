using System.Numerics;

namespace A01_CRIPTOGRAFIA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vols encriptar o desencriptar? (E/D)");
            string opcio = Console.ReadLine().ToUpper();

            Console.Write("Introdueix la paraula clau: ");
            string paraulaClau = Console.ReadLine();
            Console.Write("Introdueix el missatge: ");
            string missatge = Console.ReadLine();

            if (opcio == "E")
            {
                string missatgeEncriptat = Encriptacio(paraulaClau, missatge);
                Console.WriteLine($"Missatge encriptat: {missatgeEncriptat}");
            }
            else if (opcio == "D")
            {
                string missatgeDesencriptat = Desencriptar(paraulaClau, missatge);
                Console.WriteLine($"Missatge desencriptat: {missatgeDesencriptat}");
            }
            else
            {
                Console.WriteLine("Opció no vàlida.");
            }
        }

        public static string Encriptacio(string paraulaClau, string missatge)
        {
            paraulaClau = paraulaClau.ToLower();
            missatge = missatge.Replace(" ", "");
            int m = missatge.Length / paraulaClau.Length;
            char[,] matriu = new char[m, paraulaClau.Length];
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

        public static string Desencriptar(string paraulaClau, string missatge)
        {
            paraulaClau = paraulaClau.ToLower();
            int m = (int)Math.Ceiling((double)missatge.Length / paraulaClau.Length);
            char[,] matriu = new char[m, paraulaClau.Length];
            int[] ordenat = new int[paraulaClau.Length];
            char[] clauAmbIndex = new char[paraulaClau.Length];

            for (int i = 0; i < paraulaClau.Length; i++)
            {
                clauAmbIndex[i] = paraulaClau[i];
                ordenat[i] = i; 
            }

            Array.Sort(clauAmbIndex, ordenat, 0, paraulaClau.Length);

            int index = 0;
            foreach (int col in ordenat)
            {
                for (int j = 0; j < m; j++)
                {
                    if (index < missatge.Length)
                    {
                        matriu[j, col] = missatge[index];
                        index++;
                    }
                }
            }

            string missatgeDesencriptat = "";
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < paraulaClau.Length; j++)
                {
                    if (matriu[i, j] != '\0')
                    {
                        missatgeDesencriptat += matriu[i, j];
                    }
                }
            }

            return missatgeDesencriptat;
        }
    }
}
