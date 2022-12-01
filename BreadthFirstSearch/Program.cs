using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BreadthFirstSearch;
class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, List<string>> graph = new()
        {
            { "you", new List<string>{"alice", "bob", "claire" } },
            { "bob",  new List<string>{"anuj", "peggy" } },
            { "alice",  new List<string>{ "peggy" } },
            { "claire",  new List<string>{ "thom", "jonny" } },
            { "anuj",  new List<string>() },
            { "peggy",  new List<string>() },
            { "thom",  new List<string>() },
            { "jonny",  new List<string>() }
        };
        BreadthFirstSearch("you", graph);

        Console.ReadLine();
    }
    static bool BreadthFirstSearch(string name, Dictionary<string, List<string>> graph)
    {
        Queue<string> searchQueue = new();
        List<string> searched = new();
        graph[name].ForEach(x => searchQueue.Enqueue(x));
        while (searchQueue.Count > 0)
        {
            string person = searchQueue.Dequeue();
            if (NotInSearched(searched, person))
            {
                if (FindMangoSeller(person))
                {
                    Console.WriteLine($"{person} is Mango seller.");
                    return true;
                }
                else
                {
                    graph[person].ForEach(x => searchQueue.Enqueue(x));
                    searched.Add(person);
                }
            }
        }
        return false;
    }

    private static bool NotInSearched(List<string> searched, string person)
    {
        return !searched.Any(x => x.Equals(person));
    }

    static bool FindMangoSeller(string person)
    {
        return person.EndsWith("m");
    }
    static async void ReadCharacters()
    {
        StringBuilder stringToRead = new StringBuilder();
        stringToRead.AppendLine("Characters in 1st line to read");
        stringToRead.AppendLine("and 2nd line");
        stringToRead.AppendLine("and the end");

        using (StringReader reader = new StringReader(stringToRead.ToString()))
        {
            string? readText = await reader.ReadLineAsync();
            Console.WriteLine(readText);
        }
    }
}