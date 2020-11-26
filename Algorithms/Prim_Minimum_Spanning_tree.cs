using System;

namespace Algorithms
{



    // Spanning Tree (MST) algorithm. 
    // The program is for adjacency 
    // matrix representation of the graph 
    class Prim_Minimum_Spanning_tree
    {


        // Number of vertices in the graph 
        static int V = 5;

        // A utility function to find 
        // the vertex with minimum key 
        // value, from the set of vertices 
        // not yet included in MST 
        static int minKey(int[] minWeightEdges, bool[] visited)
        {

            // Initialize min value 
            int min = int.MaxValue, min_index = -1;
            Logger.Log(2, $"Find minKey by visiting each neighbouring node and checking if node is already visited and its the minimum");
            Logger.Log(3, minWeightEdges);
            Logger.Log(3, visited);
            for (int v = 0; v < V; v++)
                if (visited[v] == false && minWeightEdges[v] < min)
                {
                    min = minWeightEdges[v];
                    min_index = v;
                    Logger.Log(3, $"minIndex {v} min  {min} min_index {min_index}");
                }

            return min_index;
        }

        // A utility function to print 
        // the constructed MST stored in 
        // parent[] 
        static void printMST(int[] parent, int[,] graph)
        {
            Console.WriteLine("Edge \tWeight");
            Logger.Log(0, "Edge \tWeight");
            for (int i = 1; i < V; i++)
            {
                Console.WriteLine(parent[i] + " - " + i + "\t" + graph[i, parent[i]]);
                Logger.Log(1, $"{parent[i] + " - " + i + "\t" + graph[i, parent[i]]}");
            }
        }

        // Function to construct and 
        // print MST for a graph represented 
        // using adjacency matrix representation 
        static void primMST(int[,] graph)
        {

            // Array to store constructed MST 
            int[] parent = new int[V];

            // Key values used to pick 
            // minimum weight edge in cut 
            int[] minWeightEdge = new int[V];

            // To represent set of vertices 
            // included in MST 
            bool[] mstSet = new bool[V];

            // Initialize all keys 
            // as INFINITE 
            for (int i = 0; i < V; i++)
            {
                minWeightEdge[i] = int.MaxValue;
                mstSet[i] = false;
            }

            // Always include first 1st vertex in MST. 
            // Make key 0 so that this vertex is 
            // picked as first vertex 
            // First node is always root of MST 
            minWeightEdge[0] = 0;
            parent[0] = -1;

            // The MST will have V vertices 
            Logger.Log(0, "visit each vertice");
            for (int row = 0; row < V - 1; row++)
            {
                Logger.Log(1, $" row {row}");
                // Pick thd minimum key vertex 
                // from the set of vertices 
                // not yet included in MST 
                int minRow = minKey(minWeightEdge, mstSet);

                // Add the picked vertex 
                // to the MST Set 
                mstSet[minRow] = true;

                // Update key value and parent 
                // index of the adjacent vertices 
                // of the picked vertex. Consider 
                // only those vertices which are 
                // not yet included in MST 
                for (int col = 0; col < V; col++)

                // graph[u][v] is non zero only 
                // for adjacent vertices of m 
                // mstSet[v] is false for vertices 
                // not yet included in MST Update 
                // the key only if graph[u][v] is 
                // smaller than key[v] 

                {
                    Logger.Log(2, $"col {col}");
                    Logger.Log(3, $"check if graph[minRow, col] graph[{minRow}, {col}] !=0 i.e. {graph[minRow, col]} !=0 and " +
                        $"{graph[minRow, col]} < minWeightEdge at {col} i.e. {minWeightEdge[col]} and {col} is not visited");
                    if (graph[minRow, col] != 0 && mstSet[col] == false
                            && graph[minRow, col] < minWeightEdge[col])
                    {
                        Logger.Log(4, $"if above is true then ");
                        Logger.Log(5, $"update parent[col] = minRow i.e. parent at {col} with {minRow}");
                        Logger.Log(5, $"update minWeightEdge[row] = graph[col, row] i.e. minWeightEdge at {col} with {graph[minRow, col]}");

                        parent[col] = minRow;
                        minWeightEdge[col] = graph[minRow, col];
                        Logger.Log(6, "Parent array is");
                        Logger.Log(6, parent);

                        Logger.Log(6, "MinWeightEdge array is");
                        Logger.Log(6, minWeightEdge);
                    }
                }
            }

            // print the constructed MST 
            printMST(parent, graph);
        }

        // Driver Code 
        public static void Test()
        {

            /* Let us create the following graph 
            2 3 
            (0)--(1)--(2) 
            | / \ | 
            6| 8/ \5 |7 
            | / \ | 
            (3)-------(4) 
                9 */

            Logger.Init("Prim_Minimum_Spanning_tree");

            int[,] graph = new int[,] { { 0, 2, 0, 6, 0 },
                                      { 2, 0, 3, 8, 5 },
                                      { 0, 3, 0, 0, 7 },
                                      { 6, 8, 0, 0, 9 },
                                      { 0, 5, 7, 9, 0 } };

            // Print the solution 
            primMST(graph);
            Logger.Flush();
        }
    }
}

