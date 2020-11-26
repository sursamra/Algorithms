using System;
using System.Collections.Generic;

namespace Algorithms
{
    class Dijkstras_shortest_path_greedy
    {
        public static void RunDijkstra()
        {
            /*
             * see the image dijkstras-shortest-path-algorithm-greedy-algo2.png
             * following graph says for element at 0, there are only  2 possible paths go to vertices
             * 1 with distance / edge 4 hence (0,4) ie from 0 to go to 1 there is distance of 4
             * then all other next possible path is to vertices 7 with distance of 8. As all other verticies are 
             * not reachable form location 0 hence they are zero. then repeat
             * 
             */
            int[,] graph = new int[,] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                                      { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                                      { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                                      { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                                      { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                                      { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                                      { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                                      { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                                      { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };
            GFG t = new GFG();
            Logger.Init("Dijkstras_shortest_path_greedy");
            t.dijkstra(graph, 0);
            Logger.Flush();
        }
    }
    class GFG
    {
        static List<string> list = new List<string>();
        // A utility function to find the 
        // vertex with minimum distance 
        // value, from the set of vertices 
        // not yet included in shortest 
        // path tree 
        static int V = 9;
        int minDistance(int[] dist,
                        bool[] visited)
        {
            // Initialize min value 
            Logger.Log(1, $"minDistance for 0-9");
            Logger.Log(2, dist);
            Logger.Log(2, visited);
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < V; v++)
            {
                Logger.Log(3, $"v-> {v}");
                Logger.Log(4, $"if visited[v] == false {visited[v]} == false && dist[v] <= min {dist[v]} <= {min}");
                if (visited[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                    Logger.Log(5, $" min {min} min_index {min_index}");
                }
            }
            return min_index;
        }

        // A utility function to print 
        // the constructed distance array 
        void printSolution(int[] dist)
        {
            Console.Write("Vertex \t\t Distance "
                          + "from Source\n");
            list.Add("Vertex \t\t Distance "
                          + "from Source\n");
            for (int i = 0; i < V; i++)
            {
                Console.Write(i + " \t\t " + dist[i] + "\n");
                list.Add(i + " \t\t " + dist[i] + "\n");
            }
        }

        // Funtion that implements Dijkstra's 
        // single source shortest path algorithm 
        // for a graph represented using adjacency 
        // matrix representation 
        public void dijkstra(int[,] graph, int src)
        {
            int[] dist = new int[V]; // The output array. dist[i] 
                                     // will hold the shortest 
                                     // distance from src to i 

            // visited[i] will true if vertex 
            // i is included in shortest path 
            // tree or shortest distance from 
            // src to i is finalized 
            bool[] visited = new bool[V];

            // Initialize all distances as 
            // INFINITE and stpSet[] as false 
            for (int i = 0; i < V; i++)
            {
                dist[i] = int.MaxValue;
                visited[i] = false;
            }

            // Distance of source vertex 
            // from itself is always 0 
            dist[src] = 0;

            // Find shortest path for all vertices 
            for (int vertice = 0; vertice < V - 1; vertice++)
            {
                Logger.Log(0, $"vertice {vertice}");
                // Pick the minimum distance vertex 
                // from the set of vertices not yet 
                // processed. u is always equal to 
                // src in first iteration. 
                int u = minDistance(dist, visited);

                Logger.Log(1, $"minDistance = {u}");
                // Mark the picked vertex as processed 
                visited[u] = true;

                Logger.Log(1, $"visited[u] = {visited[u]}");
                // Update dist value of the adjacent 
                // vertices of the picked vertex. 
                Logger.Log(2, $"update the distance array dist[u] of min distance");
                for (int v = 0; v < V; v++)
                {
                    // Update dist[v] only if is not in 
                    // visited, there is an edge from u 
                    // to v, and total weight of path 
                    // from src to v through u is smaller 
                    // than current value of dist[v] 
                    Logger.Log(3, $" u -> {u} v -> {v}");
                    Logger.Log(4, $"!visited[v] = !{visited[v]} && graph[u, v] != 0 {graph[u, v]} != 0  && dist[u] != int.MaxValue {dist[u]} !={int.MaxValue} && dist[u] + graph[u, v] < dist[v] {dist[u]} + {graph[u, v]} < {dist[v]} ");
                    //if a vertex is not processed and vertex is reachable from source and distance of vertex is not infinite
                    // distance from source is less than existing path then update distance as new shortest path.
                    if (!visited[v] && graph[u, v] != 0 && dist[u] != int.MaxValue
                            && dist[u] + graph[u, v] < dist[v])
                    {

                        dist[v] = dist[u] + graph[u, v];
                        Logger.Log(5, $"dist[v] = dist[u] + graph[u, v] {dist[v]} = {dist[u]} + {graph[u, v]}");
                    }
                }
            }

            // print the constructed distance array 
            printSolution(dist);

        }

        // Driver Code 

    }
}
