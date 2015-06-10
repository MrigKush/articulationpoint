using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace articulationpoint
{
    //public class graph
    //{
    //    int[][] childNodes;
    //    public  graph(int[][] childNodes)
    //    {
    //        this.childNodes = childNodes;
    //    }
    //}
   public class Graph
    {
        int V;    // No. of vertices
        List<List<int>> adj = new List<List<int>>();    // A dynamic array of adjacency lists
        static   int time = 0;
        public Graph(int V)   // Constructor
        {
            //this.V = V;
            adj = new List<List<int>>();
        }

        public void addEdge(int v, List<int> w)  // function to add an edge to graph
        {
            adj.Add(w);
        }

        public void bridge()    // prints all bridges
        {
            V = adj.Count;
            // Mark all the vertices as not visited
            bool[] visited = new bool[V];
            int[] disc = new int[V];
            int[] low = new int[V];
            int[] parent = new int[V];

            // Initialize parent and visited arrays
            for (int i = 0; i < V; i++)
            {
                parent[i] = -1;
                visited[i] = false;
            }

            // Call the recursive helper function to find Bridges
            // in DFS tree rooted with vertex 'i'
            for (int i = 0; i < V; i++)
                if (visited[i] == false)
                    bridgeUtil(i, visited, disc, low, parent);
        }

        public void bridgeUtil(int u, bool[] visited, int[] disc, int[] low, int[] parent)
        {
            //// Mark the current node as visited
            visited[u] = true;

            //// Initialize discovery time and low value
            disc[u] = low[u] = ++time;

            ////// Go through all vertices aadjacent to this
            for (int i = 0; i != adj[u].Count; ++i)
            {
                int v = adj[u][i]; // v is current adjacent of u
              // If v is not visited yet, then recur for it
                if (!visited[v])
                {
                    parent[v] = u;
                    bridgeUtil(v, visited, disc, low, parent);
                    // Check if the subtree rooted with v has a connection to
                    // one of the ancestors of u
                    low[u] = min(low[u], low[v]);
                     // If the lowest vertex reachable from subtree under v is 
                    // below u in DFS tree, then u-v is a bridge
                    if (low[v] > disc[u])
                        Console.WriteLine(u + " " + v);
                }

            //    // Update low value of u for parent function calls.
                else if (v != parent[u])
                    low[u] = min(low[u], disc[v]);
            }
        }

        private int min(int p, int p_2)
        {
            return p > p_2 ? p_2 : p;
        }   

    }
    class Program
    {
        static void Main(string[] args)
        {
            Graph g1=new Graph(5);
            //g1.addEdge(0, new List<int> { 1, 3 });
            //g1.addEdge(1, new List<int> { 0, 2 });
            //g1.addEdge(2, new List<int> { 0, 1 });
            //g1.addEdge(3, new List<int> { 0, 4 });
            //g1.addEdge(4, new List<int> { 3 });
            //g1.bridge();


            //g1.addEdge(0, new List<int> { 1, 2 });
            //g1.addEdge(1, new List<int> { 0, 2, 3, 4, 6 });
            //g1.addEdge(2, new List<int> { 0, 1 });
            //g1.addEdge(3, new List<int> { 0, 5 });
            //g1.addEdge(4, new List<int> { 0, 5 });
            //g1.addEdge(5, new List<int> { 3, 4 });
            //g1.addEdge(6, new List<int> { 1 });
            //g1.bridge();



            g1.addEdge(0, new List<int> { 1,4 });
            g1.addEdge(1, new List<int> { 0, 2 });
            g1.addEdge(2, new List<int> { 1, 3 });
            g1.addEdge(3, new List<int> { 2, 4 });
            g1.addEdge(4, new List<int> { 0,3});

            g1.bridge();
            
            Console.ReadLine();
        }
    }
}
