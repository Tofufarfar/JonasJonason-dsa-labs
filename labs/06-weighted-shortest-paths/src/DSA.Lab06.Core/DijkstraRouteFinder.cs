using System;
using System.Collections.Generic;
using System.Linq;

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

            Dictionary<string, int> bestCost = new();
            Dictionary<string, string> cameFrom = new();
            MinFrontier<string> frontier = new();

            bestCost[start] = 0;
            frontier.Enqueue(start, 0);

            int expandedNodes = 0;

            // TODO Lab 6A:
            // 1. Repeatedly remove the smallest-priority frontier candidate.
            while (frontier.Count > 0)
            {
                MinFrontier<string>.Entry currentNode = frontier.Dequeue();

                if (!bestCost.ContainsKey(currentNode.Value) || currentNode.Priority > bestCost[currentNode.Value])
                {
                    continue;
                }
                
                expandedNodes++;
                
                if (currentNode.Value == goal)
                {
                    return RouteResult.Success(GetPath(), bestCost.GetValueOrDefault(goal), expandedNodes);
                }
                foreach (WeightedEdge edge in graph.GetOutgoing(currentNode.Value))
                {
                    int currentCost = bestCost[edge.From] + edge.Cost;
                    if (!bestCost.ContainsKey(edge.To) || bestCost[edge.To] > currentCost)
                    {
                        bestCost[edge.To] = currentCost;
                        cameFrom[edge.To] = currentNode.Value;
                        frontier.Enqueue(edge.To,currentCost);
                    }
                    
                }
                
            }

            IReadOnlyList<string> GetPath()
            {
                List<string> path = new();
                string current = goal;
                
                path.Add(current);
                
                while (current != start)
                {
                    current = cameFrom[current];
                    path.Add(current);
                }

                path.Reverse();
                
                return path;
            }

            
            // 2. Ignore stale entries when a cheaper cost is already known.
            // 3. Finalize/expand the current node.
            // 4. If it is the goal, reconstruct the route using cameFrom.
            // 5. Relax each outgoing edge:
            //      candidate = bestCost[current] + edge.Cost
            //    If candidate improves the known cost, update both bestCost and cameFrom,
            //    then enqueue the neighbor with the improved total cost.
            //
            // Implement one small piece at a time and run the relevant tests.

            return RouteResult.NotFound(expandedNodes);
        }
    }
}
