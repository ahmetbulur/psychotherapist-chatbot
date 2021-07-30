using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psychotherapist
{
    class Program
    {
        static void Main(string[] args)
        {
            // change background and foreground color
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            char[] punctuations = {'.', ',', ';', '’','”', '?', '!', '-', '{', '}', '(', ')', '[', ']'};

            string[] negative_words = {"stress", "depression", "sad", "angry", "hate", "pain", "abnormal", "abort", "abuse","brittle","hurt",
                                       "scared", "afraid", "upset", "confused", "lonely", "tired", "vulnerable", "guilty", "anxiety","disappointment",
                                       "regret", "awful", "sick", "regretful", "unhappy", "sorrowful", "troubled", "worried", "annoyed"};

            string[] stop_words = {"a", "after", "again", "all", "am", "and", "any", "are", "as", "at", "be", "been", "before","between", "both",
                                   "but", "by", "can", "could", "for", "from", "had", "has", "he", "her", "here", "him", "in", "into","ı",
                                   "is", "it", "me", "my", "of", "on", "our", "she", "so", "such", "than", "that", "the", "then", "they",
                                   "this", "to", "until", "we", "was", "were", "with", "you"};
            
            // additional array
            string[] question_words = { "why", "who", "when", "where", "what", "how" };

            // random choose answer
            Random r = new Random();

            // continue dialogue

            bool dialogue = true;
            while (dialogue)
            {
                // take input from user
                Console.Write("User : ");
                string str = Console.ReadLine();
                string input = str.ToLower();
                
                int random = r.Next(1,3);


                // rule 1
                bool rule1 = false;
                bool flag = true;
                
                  // determine words of entered sentence(s)
                string[] words = input.Split(' ');
                
                  // compare words; if a word appears more than 2 times in the text, write
                for (int i = 0; i < words.Length; i++)
                {
                    for (int j = i+1; j < words.Length; j++)
                    {
                        for (int k = i+2; k < words.Length; k++)
                        {
                            if (!(stop_words.Contains(words[i])))
                            {
                                if (words[i] == words[j]  && words[i] == words[k])
                                {
                                    rule1 = true;
                                    Console.WriteLine("Program : Do you love " + words[i] + "?");
                                    flag = false; break;
                                }
                            }

                        }
                        if (flag == false)
                            break;
                    }
                    if (flag == false)
                        break;
                }


                // rule 2
                bool rule2 = false;
                for (int i = 0; i < question_words.Length; i++)
                {
                    if (input.Contains(question_words[i]))
                    {
                        rule2 = true;
                        // random choose answer
                        switch (random)
                        {
                            case 1: Console.WriteLine("Program : Do you often think about this question?"); break;
                            case 2: Console.WriteLine("Program : Why do you want to know?"); break;
                        }
                    }
                }

                // rule 3
                bool rule3 = false;
                for (int i = 0; i < negative_words.Length; i++)
                {
                    if (input.Contains(negative_words[i]))
                    {
                        rule3 = true;
                        Console.WriteLine("Program : Being " + negative_words[i] + " is bad for your health. How long do you feel " + negative_words[i] + "? Why do you feel " + negative_words[i] + "?");
                    }
                }


                // finish dialogue and exit
                bool exit = false;
                if (input.Contains("ı have to go now."))
                {
                    exit = true;
                    dialogue = false;
                }

                // rule 4
                string[] sentences = input.Split('.','!','?');
                    // if sentences doesnt have rules(1,2,3 or exit), apply rule 4 
                if (sentences.Length > 1 && rule1 == false && rule2 == false && rule3 == false && exit == false)
                {
                    // determine words of the last sentence
                    string[] subwords = sentences[sentences.Length - 2].Split(' ');

                    for (int i = 0; i < subwords.Length; i++)
                    {
                        switch (subwords[i])
                        {
                            case "ı": subwords[i] = "you"; break;
                            case "my": subwords[i] = "your"; break;
                            case "myself": subwords[i] = "yourself"; break;
                            case "am": subwords[i] = "are"; break;
                            case "me": subwords[i] = "you"; break;
                        }    
                    }
                    
                    // random choose answer
                    if(random == 1 || input.Contains("hello") )
                    {
                        Console.Write("Program :");
                        if (input.Contains("hello"))
                            Console.Write(" Hello.");
                        for (int i = 0; i < subwords.Length; i++)
                        {
                            Console.Write(subwords[i]+" ");
                        }
                        Console.WriteLine(", right?");
                    }
                    else
                    {
                        Console.Write("Program : You say ");
                        for (int i = 0; i < subwords.Length; i++)
                        {
                            Console.Write(subwords[i] + " ");
                        }
                        Console.WriteLine("?");
                    }
                }
                
                // additional conditions
                if (input == "")
                {
                    Console.WriteLine("Program : Be relax. You can write anything you want.");
                }
                if (input != "" && sentences.Length == 1)
                {
                    Console.WriteLine("Program : You didn't write a sentence.");
                }
            }
        }
    }
}
