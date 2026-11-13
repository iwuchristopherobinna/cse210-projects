/*
 * I added an external scripture loading feature.
 * my program reads scriptures from an external
 * text file called scriptures.txt,the file contains scriptures from the book of mormon
 *d&c the bible and the pearl of great price
 *
 * It uses File.ReadAllLines() to read the file
 * and separates each scripture into its reference
 * and text.
 * The program also randomly selects a scripture
 * from the external scripture library.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
       
        string filePath = Path.Combine(
            AppContext.BaseDirectory,
            "scriptures.txt"
        );

        List<Scripture> scriptureLibrary = LoadScriptures(filePath);

        if (scriptureLibrary.Count == 0)
        {
            Console.WriteLine("No scriptures were loaded.");
            Console.WriteLine("Please check your scriptures.txt file.");
            return;
        }

        Random random = new Random();

        Scripture scripture = scriptureLibrary[
            random.Next(scriptureLibrary.Count)
        ];

       Console.WriteLine();

        Console.WriteLine("==================================");
        Console.WriteLine("       SCRIPTURE MEMORIZER");
        Console.WriteLine("==================================");
        Console.WriteLine();

        Console.WriteLine("Memorize the scripture by hiding words each time you press Enter.");
        Console.WriteLine();

        Console.WriteLine(scripture.GetDisplayText());

        Console.WriteLine();
        Console.WriteLine("Press Enter to hide words.");
        Console.WriteLine("Type 'quit' to exit.");

        while (!scripture.IsCompletelyHidden())
        {
            string input = Console.ReadLine() ?? "";

            if (input.Trim().ToLower() == "quit")
            {
                Console.WriteLine("Thank you for practicing!");
                return;
            }

            scripture.HideRandomWords(3);

            Console.WriteLine();

            Console.WriteLine("==================================");
            Console.WriteLine("       SCRIPTURE MEMORIZER");
            Console.WriteLine("==================================");
            Console.WriteLine();

            Console.WriteLine(scripture.GetDisplayText());

            int hidden = scripture.GetHiddenWordCount();
            int total = scripture.GetWordCount();

            Console.WriteLine();
            Console.WriteLine($"Words hidden: {hidden} out of {total}");

            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.WriteLine();
            Console.WriteLine("Press Enter to hide more words.");
            Console.WriteLine("Type 'quit' to exit.");
        }

        Console.WriteLine();

        Console.WriteLine(scripture.GetDisplayText());

        Console.WriteLine();
        Console.WriteLine("Congratulations!");
        Console.WriteLine("You memorized the scripture!");
    }

    static List<Scripture> LoadScriptures(string filePath)
    {
        List<Scripture> scriptures = new List<Scripture>();

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Scripture file was not found!");
            return scriptures;
        }

        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            string[] parts = line.Split('|', 5);

            if (parts.Length != 5)
            {
                Console.WriteLine("Invalid scripture format. Skipping line.");
                continue;
            }

            if (!int.TryParse(parts[1], out int chapter) ||
                !int.TryParse(parts[2], out int startVerse) ||
                !int.TryParse(parts[3], out int endVerse))
            {
                Console.WriteLine("Invalid scripture numbers. Skipping line.");
                continue;
            }

            if (chapter <= 0 || startVerse <= 0 ||
                endVerse < startVerse || string.IsNullOrWhiteSpace(parts[4]))
            {
                Console.WriteLine("Invalid scripture information. Skipping line.");
                continue;
            }

            Reference reference = new Reference(
                parts[0],
                chapter,
                startVerse,
                endVerse
            );

            Scripture scripture = new Scripture(reference, parts[4]);

            scriptures.Add(scripture);
        }

        return scriptures;
    }
}

class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = verse;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        if (_startVerse == _endVerse)
        {
            return $"{_book} {_chapter}:{_startVerse}";
        }

        return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
    }
}

class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return new string('_', _text.Length);
        }

        return _text;
    }
}

class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;

        _words = text.Split(' ')
            .Select(word => new Word(word))
            .ToList();
    }

    public void HideRandomWords(int numberToHide)
    {

        List<Word> visibleWords = _words
            .Where(word => !word.IsHidden())
            .ToList();

        for (int i = 0; i < numberToHide && visibleWords.Count > 0; i++)
        {
            int index = _random.Next(visibleWords.Count);

            visibleWords[index].Hide();

            visibleWords.RemoveAt(index);
        }
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }

    public int GetHiddenWordCount()
    {
        return _words.Count(word => word.IsHidden());
    }

    public int GetWordCount()
    {
        return _words.Count;
    }

    public string GetDisplayText()
    {
        string displayedWords = string.Join(
            " ",
            _words.Select(word => word.GetDisplayText())
        );

        return $"{_reference.GetDisplayText()} {displayedWords}";
    }
}

