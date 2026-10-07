using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace RaceWinners;

/// <summary>
/// The starting point of the application.
/// </summary>
public class Program
{
    /// <summary>
    /// The first method that runs when the program starts.
    /// </summary>
    /// <remarks>
    /// <para>
    /// <c>Main</c> is marked <c>async Task</c> so that it can <c>await</c> other async
    /// methods, such as <see cref="DataService.GetGroupRanksAsync"/>.
    /// </para>
    /// <para>
    /// Notice that <c>Main</c> does not know <i>where</i> the race data comes from. It asks
    /// its dependency, the <see cref="DataService"/>, for the data and then works with
    /// whatever comes back.
    /// </para>
    /// </remarks>
    /// <param name="args">Command-line arguments (not used by this program).</param>
    static async Task Main(string[] args)
    {
        // Create the service this program depends on.
        DataService dataService = new DataService();

        // Ask the service for the data. "await" pauses here until the data is ready.
        var groups = await dataService.GetGroupRanksAsync();

        // Print each group and its runners' overall finishing places.
        foreach (var group in groups)
        {
            // string.Join glues the numbers together with ", " between them.
            var ranks = string.Join(", ", group.Ranks);

            Console.WriteLine($"{group.Name} - [{ranks}]");
        }

        // YOUR TURN: Rank each group from first to last place.
        int g1 = 0;
        int g2 = 0;
        int g3 = 0;
        int g4 = 0;
        int i = 0;
        foreach (var group in groups) {
            int average = 0;
            int count = 0;
            i++;
            foreach (int rank in group.Ranks)
            {
                average += rank;
                count++;
            }
            if (i == 1) g1 = average / count;
            else if (i == 2) g2 = average / count;
            else if (i == 3) g3 = average / count;
            else g4 = average / count;
        }
         /* if (g1 < g2 && g1 < g3 && g1 < g4) Console.WriteLine("Class A is 1st place!") {
            if (g2 < g3 && g2 < g4) Console.WriteLine("Class B is 2nd place!");
            else if (g3 < g2 && g3 < g4) Console.WriteLine("Class C is 2nd place!");
            else Console.WriteLine("Class D is 2nd place!");
        }
        if (g2 < g1 && g2 < g3 && g2 < g4) Console.WriteLine("Class B is 1st place!");
        if (g3 < g1 && g3 < g2 && g3 < g4) Console.WriteLine("Class C is 1st place!");
        if (g4 < g1 && g4 < g2 && g4 < g3) Console.WriteLine("Class D is 1st place!"); */
            
         var scores = new Dictionary<string, int> {
        { "Class A", g1 },
        { "Class B", g2 },
        { "Class C", g3 },
        { "Class D", g4 } };
        

            var ranked = scores.OrderBy(score => score.Value).ToList();
            string[] suffix = { "1st", "2nd", "3rd", "4th" };
        for (int place = 0; place < ranked.Count; place++)
            {   
                Console.WriteLine($"{ranked[place].Key} is {suffix[place]} place!");
            } 

        // Decide what "fair" means before you start writing code!

        // find the Standard deviation and try to make a standarized score, I can't even think of the code to do that.
    }
}
