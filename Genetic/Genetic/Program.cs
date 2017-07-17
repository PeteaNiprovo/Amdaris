using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_algorithms
{
    class Family : IComparable<Family>
    {
        public string Combination { get; set; }
        public float Fitness { get; set; }
        public Family(string comb)
        {
            Combination = comb;
        }

        public int CompareTo(Family f)
        {
            return Fitness.CompareTo(f.Fitness);
        }
    }
    class Sentence
    {
        private List<Family> population = new List<Family>();
        private string options = " abcdefghijklmnopqrstuvwxyz";
        private readonly string sentence;
        private Random random;

        public int PopulationSize { get; set; }
        public int MutationPercentage { get; set; }
        public int SentenceLength { get; set; }

        public Sentence(int pop, int mutation, int sentenceLength, string goal)
        {
            PopulationSize = pop;
            MutationPercentage = mutation;
            SentenceLength = sentenceLength;

            random = new Random();
            for (int i = 0; i < PopulationSize; i++)
            {
                string temp = "";
                for (int j = 0; j < SentenceLength; j++)
                {
                    temp += GetRandomCharacter(options, random);
                }
                population.Add(new Family(temp));
            }
            sentence = goal;
        }
        public static char GetRandomCharacter(string text, Random rng)
        {
            int index = rng.Next(text.Length);
            return text[index];
        }
        public void ShowPopulation()
        {
            foreach (var item in population)
            {
                Console.WriteLine($"{item.Combination}    Fitness -> {item.Fitness}");
            }
        }

        public void CalculateFitness()
        {
            foreach (var item in population)
            {
                float count = 0;
                for (int j = 0; j < item.Combination.Length; j++)
                {   
                    if (item.Combination[j] == sentence[j])
                    {
                        count++;
                    }
                }
                item.Fitness = (float)count / (float)SentenceLength;
            }
        }
        public void Reproduce()
        {
            population.Sort();
            population.Reverse(); ///
            int k = PopulationSize - 1; ;
            for (int i = 0; i < PopulationSize/2; i += 2)
            {
                string temp1 = population[i].Combination.Substring(0, SentenceLength / 2);
                string temp2 = population[i].Combination.Substring(SentenceLength / 2, SentenceLength/2);
                string temp3 = population[i+1].Combination.Substring(0, SentenceLength / 2);
                string temp4 = population[i+1].Combination.Substring(SentenceLength / 2, SentenceLength/2);

                population[k--].Combination = temp1 + temp4;
                int t = random.Next(0, 100);
                if (t <= MutationPercentage)
                {
                    int position = random.Next(0, SentenceLength - 1);
                    char charater = options[random.Next(0, options.Length - 1)];
                    string temp = population[k + 1].Combination.Remove(position, 1);
                    population[k + 1].Combination = temp.Insert(position, charater.ToString());
                }

                population[k--].Combination = temp3 + temp2;
                if (t <= MutationPercentage)
                {
                    int position = random.Next(0, SentenceLength - 1);
                    char charater = options[random.Next(0, options.Length - 1)];
                    string temp = population[k + 1].Combination.Remove(position, 1);
                    population[k + 1].Combination = temp.Insert(position, charater.ToString());
                }
            }
        }

        public int Selection()
        {
            for (int i = 0; i < PopulationSize; i++)
            {
                if (population[i].Fitness == 1) return i;
            }
            return -1;
        }
        public void Automotize()
        {
            int generation = 0;
            CalculateFitness();
            int index;
            while ((index = Selection()) == -1)
            {
                Console.WriteLine(generation);
                Reproduce();
                CalculateFitness();
                generation++;
            }
            ShowPopulation();
            Console.WriteLine("*********************");
            Console.WriteLine(population[index].Combination + " in " + generation + " generatii");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string text = "to be or not to be";
            Sentence s = new Sentence(1000, 20, text.Length, text);
            s.Automotize();
        }
    }       // de modificat posibilitatea unui strign cu numar impar de caractere
}