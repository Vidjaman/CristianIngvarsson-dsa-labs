using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DSA.Lab05
{
    /// <summary>
    /// Iterative graph traversals.
    ///
    /// Complete these methods after the adjacency representation is working.
    /// Think in terms of:
    /// frontier + visited + neighbors.
    /// </summary>
    public static class GraphTraversal
    {

        
        public static IReadOnlyList<string> BreadthFirstOrder(
            AdjacencyGraph graph,
            string start)
        {
            HashSet<string> visited = new HashSet<string>();
            Queue<string> frontier = new Queue<string>();
            
            frontier.Enqueue(start);
            visited.Add(start);
         
            while (frontier.Count>0)
            {
                string current=frontier.Dequeue();
                foreach (var next in graph.GetNeighbors(current))
                {
                    if (visited.Add(next))
                    {
                        frontier.Enqueue(next);
                    }
                   
                }
               
                
            }

            return visited.ToList();
            
        }

        public static IReadOnlyList<string> DepthFirstOrder(
            AdjacencyGraph graph,
            string start)
        {
            HashSet<string> visited = new HashSet<string>();
            Stack<string> frontier = new Stack<string>();


            frontier.Push(start);
            
            while (frontier.Count > 0)
            {
                string current = frontier.Pop();
                foreach (var next in graph.GetNeighbors(current).Reverse())
                {
                    if (!visited.Contains(next))
                    {
                        frontier.Push(next);
                    }

                }


                visited.Add(current);

            }
            

            return visited.ToList();
        }

        public static List<string> ReconstructPath(string start,Dictionary<string,string> cameFrom)
        {
            List<string> result=new List<string>();
            result.Add(start);
            string current=start;
            while (cameFrom.ContainsKey(current))
            {
                current= cameFrom[current];
                result.Add(current);
            }
            result.Reverse();
            return result;
        }
        public static bool IsReachableBfs(
            AdjacencyGraph graph,
            string start,
            string target)
        {

            HashSet<string> visited = new HashSet<string>();
            Queue<string> frontier = new Queue<string>();
            string current;

            frontier.Enqueue(start);
           
            while (frontier.Count > 0)
            {
                current = frontier.Dequeue();
                if (current==target)
                    return true;
                foreach (var next in graph.GetNeighbors(current))
                {
                    if (!visited.Contains(next))
                    {
                        frontier.Enqueue(next);
                    }

                }
                visited.Add(current);
            }
            return false;
        }
        public static bool IsReachableBfs(
            AdjacencyGraph graph,
            string start,
            string target, out List<string> path)
        {
            Dictionary<string, string> cameFrom=new Dictionary<string, string>();
            HashSet<string> visited = new HashSet<string>();
            Queue<string> frontier = new Queue<string>();
            string current;

            frontier.Enqueue(start);

            while (frontier.Count > 0)
            {
                current = frontier.Dequeue();
                if (current == target)
                {
                    path = ReconstructPath(target,cameFrom);
                    return true;
                }
                    
                foreach (var neighbor in graph.GetNeighbors(current))
                {
                    if (!visited.Contains(neighbor))
                    {
                        if (!cameFrom.ContainsKey(neighbor))
                       
                        {
                            cameFrom.Add(neighbor, current);
                        }
                        frontier.Enqueue(neighbor);
                    }

                }
                visited.Add(current);
            }
            path = new List<string>();
            return false;
        }

    }
}
