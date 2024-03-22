using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
public class SearchWordApp
{
    public struct Vect
    {
        public int yr;
        public int xc;
    }

    static public List<Vect> directions = new List<Vect>()
    {
            new Vect { xc =  1, yr =  0 },
            new Vect { xc =  1, yr = -1 },
            new Vect { xc =  0, yr = -1 },
            new Vect { xc = -1, yr = -1 },
            new Vect { xc = -1, yr =  0 },
            new Vect { xc = -1, yr =  1 },
            new Vect { xc =  0, yr =  1 },
            new Vect { xc =  1, yr =  1 },
    };

    static bool check_RowLim(int r_ind, int r_dim)
    {
        if (r_ind > -1 && r_ind < r_dim)
            return true;
        else
            return false;
    }

    static bool check_ColLim(int c_ind, int c_dim)
    {
        if (c_ind > -1 && c_ind < c_dim)
            return true;
        else
            return false;
    }

    static void PrintResult(List<Vect> rslt, List<List<char>> m)
    {
        // create empty result matrix
        List<List<char>> matrixRslt = new List<List<char>>();
        for (int row = 0; row < m.Count; row++)
        {
            List<char> line = new List<char>();
            for (int col = 0; col < m[0].Count; col++)
            {
                line.Add(' ');
            }
            matrixRslt.Add(line);
        }
        // fill on desired places found chars
        for (int i = 0; i < rslt.Count; i++)
        {
            matrixRslt[rslt[i].yr][rslt[i].xc] = m[rslt[i].yr][rslt[i].xc];
        }

        // prepare line strings and print out
        for (int row = 0; row < m.Count; row++)
        {
            string line  = "";
            for (int col = 0; col < m[0].Count; col++)
            {
                line += matrixRslt[row][col];
            }
            Console.WriteLine(line);
        }
    }

    // retutn true if word was found; else return false;
    static bool SearchWord(string word, int r, int c, List<List<char>> m, out List<Vect> remember)
    {
        // remember coordinates of found characters
        remember = new List<Vect>();
        string foundWord = "";

        int xc = c;
        int yr = r;

        char ch = Char.ToUpper(word[0]);

        if (ch == m[r][c])
        {
            remember.Add(new Vect { xc = c, yr = r });
            foundWord += ch;

            for (int j = 0; j < directions.Count; j++)
            {
                int new_yr = r + directions[j].yr;
                int new_xc = c + directions[j].xc;

                if (check_RowLim(new_yr, m.Count) && check_ColLim(new_xc, m[0].Count))
                {
                    int wordCharInd = 1;
                    ch = Char.ToUpper(word[wordCharInd]);
                    if (ch == m[new_yr][new_xc])
                    {
                        remember.Add(new Vect { xc = new_xc, yr = new_yr });
                        foundWord += ch;

                        while (wordCharInd < word.Length - 1)
                        {
                            new_yr += directions[j].yr;
                            new_xc += directions[j].xc;
                            wordCharInd++;
                            if (check_RowLim(new_yr, m.Count) && check_ColLim(new_xc, m[0].Count))
                            {
                                ch = Char.ToUpper(word[wordCharInd]);
                                if (ch == m[new_yr][new_xc])
                                {
                                    remember.Add(new Vect { xc = new_xc, yr = new_yr });
                                    foundWord += ch;
                                }
                                else
                                {
                                    remember.RemoveRange(1, remember.Count - 1);
                                    foundWord = foundWord.Remove(1, foundWord.Length - 1);
                                    break;
                                }
                            }
                            else
                            {
                                remember.RemoveRange(1, remember.Count - 1);
                                foundWord = foundWord.Remove(1, foundWord.Length - 1);
                                break;
                            }
                        }
                        if (string.Equals(foundWord, word, StringComparison.OrdinalIgnoreCase))
                            return true;
                        else
                            continue;
                    }
                }
            }
            return false;
        }
        else
            return false;
    }

    // main entry point
    static public void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine());
        List<List<char>> matrix = new List<List<char>>();
        List<string> words;
        List<Vect> AllChars = new List<Vect>();
        List<Vect> WordChars = new List<Vect>();

        for (int i = 0; i < size; i++)
        {
            string ROW = Console.ReadLine();
            List<char> row_char = new List<char>(ROW.ToCharArray());
            matrix.Add(row_char);
        }
        string clues = Console.ReadLine();
        words = new List<string>(clues.Split(' '));

        // To debug: Console.Error.WriteLine("Debug messages...");
        for (int i = 0; i < words.Count; i++)
        {
            bool foundWord = false;
            //Console.Error.WriteLine(words[i]);
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    //Console.Error.WriteLine(matrix[row][col]);
                    foundWord = SearchWord(words[i], row, col, matrix, out WordChars);
                    if (foundWord)
                    {
                        AllChars.AddRange(WordChars);
                        break;
                    }
                }
                if (foundWord)
                    break;
            }
        }
        // Write an answer using Console.WriteLine()
        PrintResult(AllChars, matrix);
    }
}