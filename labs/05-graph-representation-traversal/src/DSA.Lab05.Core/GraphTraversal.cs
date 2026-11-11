using System;
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
        public static IReadOnlyList<string> BreadthFirstOrder(AdjacencyGraph graph, string start)
        {
            HashSet<string> visited = new HashSet<string>();
            Queue<string> frontier = new Queue<string>();
            List<string> order = new List<string>();

            visited.Add(start);
            frontier.Enqueue(start);

            while (frontier.Count > 0)
            {
                string current = frontier.Dequeue();
                order.Add(current);

                foreach (string neighbor in graph.GetNeighbors(current))
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        frontier.Enqueue(neighbor);
                    }
                }
            }

            return order;

        }

        public static IReadOnlyList<string> DepthFirstOrder(AdjacencyGraph graph, string start)
        {
            HashSet<string> visited = new HashSet<string>();
            Stack<string> frontier = new Stack<string>();
            List<string> order = new List<string>();

            visited.Add(start);
            frontier.Push(start);

            while (frontier.Count > 0)
            {
                string current = frontier.Pop();
                order.Add(current);

                foreach (string neighbor in graph.GetNeighbors(current).Reverse())
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        frontier.Push(neighbor);
                    }
                }
            }
            //throw new NotImplementedException();
            return order;
        }

        public static bool IsReachableBfs(AdjacencyGraph graph, string start, string target)
        {
            HashSet<string> visited = new HashSet<string>();
            Queue<string> frontier = new Queue<string>();

            visited.Add(start);
            frontier.Enqueue(start);

            while (frontier.Count > 0)
            {
                string current = frontier.Dequeue();

                if (current == target)
                {
                    return true;
                }
                
                foreach (string neighbor in graph.GetNeighbors(current))
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        frontier.Enqueue(neighbor);
                    }
                }
            }
            //throw new NotImplementedException();
            return false;
        }
    }
}
