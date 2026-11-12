using System;
using System.Collections.Generic;

namespace DSA.Lab06
{
    public sealed class DijkstraRouteFinder
    {
        public RouteResult FindRoute(WeightedGraph graph, string start, string goal)
        {
            if (graph == null)
            {
                throw new ArgumentNullException(nameof(graph));
            }

            if (!graph.ContainsNode(start) || !graph.ContainsNode(goal))
            {
                return RouteResult.NotFound(0);
            }

            if (start == goal)
            {
                return RouteResult.Success(new[] { start }, 0, 0);
            }

            var bestCost = new Dictionary<string, int>();
            var cameFrom = new Dictionary<string, string>();
            var frontier = new MinFrontier<string>();

            bestCost[start] = 0;
            frontier.Enqueue(start, 0);

            int expandedNodes = 0;

            // TODO Lab 6A:
            while (frontier.Count > 0)
            {
                MinFrontier<string>.Entry current = frontier.Dequeue();
               
                if (current.Priority > bestCost[current.Value])
                    continue;
                if (current.Value == goal)
                {
                    //reconstruct path and return
                    string currentEnd = goal;
                    List<string> result = new List<string>();
                    result.Add(currentEnd);
                    while (currentEnd != start)
                    {
                        result.Add(cameFrom[currentEnd]);
                        currentEnd = cameFrom[currentEnd];
                    }


                    result.Reverse();
                    return RouteResult.Success(result, bestCost[goal], expandedNodes);
                }

                expandedNodes++;
                foreach (var edge in graph.GetOutgoing(current.Value))
                {
                    
                    int candidate = bestCost[current.Value] + edge.Cost;
                    if (!bestCost.ContainsKey(edge.To) || candidate < bestCost[edge.To])
                    {
                        bestCost[edge.To] = candidate;
                        cameFrom[edge.To] = current.Value;
                        frontier.Enqueue(edge.To, candidate);
                    }   
                }  
            }
            return RouteResult.NotFound(expandedNodes);
        }
    }
}
