using System;

namespace AdamAsmaca
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 1. Bir kelime grubundan rastgele bir kelime seç. (ayna)
             * 2. Seçtiğin bu kelimenin her harfini * işaretine dönüştür
             * 3. Bu bulmacayı ekranda göster. (****)
             * 4. Oyuncudan harf iste 
             * 5. Harf kelimede var mı kontrol et.
             * 6. a. Eğer varsa, o harfin bulunduğu * işaretlerini harfe çevir (Örnek a**a)
             *    b. Yoksa bir hakkını azalt
             * 7. Oyuncudan kelimeyi tahmin etmesini iste
             *    Bilirse oyunu bitir
             *    Bilemezse 3. adıma dön
             */

            bool isGameOver = false;
            string[] words = { "ayna", "masa", "tarantula", "endoplazmikretikulum" };
            while (!isGameOver)
            {
             
                string selectedWord = chooseWord(words);
                string puzzle = replaceToStar(selectedWord);

                Console.WriteLine(puzzle);
                bool isWordFinding = false;
                while (!isWordFinding)
                {
                    Console.WriteLine("Bir harf giriniz");
                    string letter = Console.ReadLine();
                    bool isLetterExistInWord = checkLetterInWord(selectedWord, letter);
                    if (isLetterExistInWord)
                    {
                        puzzle = replaceStarToLetter(selectedWord, puzzle, letter);
                        Console.WriteLine(puzzle);
                    }
                   
                    Console.WriteLine("Kelimeyi tahmin etmek ister misin? (E/H)");
                    string answerForGuess = Console.ReadLine();
                    if (answerForGuess.ToUpper() == "E")
                    {
                        Console.WriteLine("Tahmininizi giriniz:");
                        string guess = Console.ReadLine();
                        isWordFinding = compareGuessAndSelectedWord(guess, selectedWord);

                    } 
                }
                //Console.WriteLine(puzzle);
                Console.WriteLine("Oyuna devam mı (E/H)?");
                isGameOver = Console.ReadLine().ToUpper() == "H";
            }
        }

        private static bool compareGuessAndSelectedWord(string guess, string selectedWord)
        {
            return guess == selectedWord;
        }


        /// <summary>
        /// Belirli kelimelerin içinden rastgele kelime seçer
        /// </summary>
        /// <param name="words">kelimelerin bulunduğu koleksiyon</param>
        /// <returns></returns>
        static string chooseWord(string[] words)
        {
            Random random = new Random();
            string word = words[random.Next(0, words.Length)];
            return word;
        }

        private static string replaceToStar(string selectedWord)
        {
            string puzzleResult = string.Empty;
            for (int i = 0; i < selectedWord.Length; i++)
            {
                puzzleResult += "*";
            }
            return puzzleResult;
        }

        /// <summary>
        /// Bu metod ile bir kelimede bir harf olup olmadığını bulursunuz.
        /// </summary>
        /// <param name="selectedWord">Kaynak kelime</param>
        /// <param name="letter">Aranacak harf</param>
        /// <returns></returns>
        private static bool checkLetterInWord(string selectedWord, string letter)
        {
            return selectedWord.Contains(letter);
        }

        private static string replaceStarToLetter(string selectedWord, string puzzle, string letter)
        {
            int startIndex = 0;
            char[] puzzleStars = puzzle.ToCharArray();
            while (selectedWord.IndexOf(letter,startIndex) != -1)
            {
                int findingIndex = selectedWord.IndexOf(letter, startIndex);
                puzzleStars[findingIndex] = Convert.ToChar(letter);
                startIndex = findingIndex + 1;

            }

            string result = string.Empty;
            foreach (var item in puzzleStars)
            {
                result += item.ToString();
            }

            return result;

        }
    }
}
