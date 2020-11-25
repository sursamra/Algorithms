namespace Algorithms
{
    //Not working very well.
    class Dijkstras_printing_paths
    {


        public static void Test()
        {
            int[] preD = new int[5];
            int min = 999, nextNode = 0; // min holds the minimum value, nextNode holds the value for the next node. 
            System.Random random = new System.Random();
            int[] distance = new int[5]; // the distance matrix 
            int[][] matrix = new int[][]
                {
                     new int[] {0,0,0,0,0},
                     new int[] {0,0,0,0,0},
                     new int[] {0,0,0,0,0},
                     new int[] {0,0,0,0,0},
                     new int[] {0,0,0,0,0},

                }; // the actual matrix 
            int[] visited = new int[5]; // the visited array 

            //System.out.println("Enter the cost matrix");

            for (int i = 0; i < distance.Length; i++)
            {
                visited[i] = 0; //initialize visited array to zeros 
                preD[i] = 0;
                for (int j = 0; j < distance.Length; j++)
                {
                    matrix[i][j] = random.Next(0, 999); //fill the matrix 
                    if (matrix[i][j] == 0)
                        matrix[i][j] = 999; // make the zeros as 999 
                }
            }

            distance = matrix[0]; //matrix[0]; //initialize the distance array 
            visited[0] = 1; //set the source node as visited 
            distance[0] = 0; //set the distance from source to source to zero which is the starting point 

            for (int counter = 0; counter < 5; counter++)
            {
                min = 999;
                for (int i = 0; i < 5; i++)
                {
                    if (min > distance[i] && visited[i] != 1)
                    {
                        min = distance[i];
                        nextNode = i;
                    }
                }

                visited[nextNode] = 1;
                for (int i = 0; i < 5; i++)
                {
                    if (visited[i] != 1)
                    {
                        if (min + matrix[nextNode][i] < distance[i])
                        {
                            distance[i] = min + matrix[nextNode][i];
                            preD[i] = nextNode;
                        }

                    }

                }

            }

            for (int i = 0; i < 5; i++)
                System.Console.WriteLine("|" + distance[i]);

            System.Console.WriteLine("|");

            int jj;
            for (int i = 0; i < 5; i++)
            {
                if (i != 0)
                {

                    System.Console.WriteLine("Path = " + i);
                    jj = i;
                    do
                    {
                        jj = preD[jj];
                        System.Console.WriteLine(" <- " + jj);
                    }
                    while (jj != 0);
                }
                System.Console.WriteLine();
            }
        }
    }
}

