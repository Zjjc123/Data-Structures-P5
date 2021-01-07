using System;
using System.IO;

namespace Lesson5ClassWork
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter writer = new StreamWriter("../../../result.csv");
            StreamReader reader = new StreamReader("../../../beads.txt");

            int linesProcessed = 0;
            int zeroBeads = 0;
            int oneBeads = 0;
            int separatorBeads = 0;

            using (writer)
            {
                writer.WriteLine("Message,Zeros,Ones,Separators");
                using (reader)
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        int[] beadCounts = new int[3];
                        linesProcessed++;

                        char[] characters = line.ToCharArray();

                        for (int i = 0; i < line.Length; i++)
                        {
                            char[] binaryCharacters = Convert.ToString((int)characters[i], toBase: 2).ToCharArray();

                            for (int j = 0; j < binaryCharacters.Length; j++)
                            {
                                if (binaryCharacters[j] == '0')
                                    beadCounts[0]++;
                                else
                                    beadCounts[1]++;
                            }
                            beadCounts[0]++;
                            beadCounts[2]++;
                        }

                        beadCounts[2]--;

                        zeroBeads += beadCounts[0];
                        oneBeads += beadCounts[1];
                        separatorBeads += beadCounts[2];

                        writer.WriteLine("{0}, {1}, {2}, {3}", line, beadCounts[0], beadCounts[1], beadCounts[2]);
                        Console.WriteLine(line);
                    }
                }
                writer.WriteLine(", {0}, {1}, {2}", zeroBeads, oneBeads, separatorBeads);
            }

            Console.WriteLine("======= Results =======");
            Console.WriteLine("Lines Processed: {0}", linesProcessed);
            Console.WriteLine("Total Zero Beads: {0}", zeroBeads);
            Console.WriteLine("Total One Beads: {0}", oneBeads);
            Console.WriteLine("Total Separator Beads: {0}", separatorBeads);
            Console.ReadLine();
        }
    }
}
