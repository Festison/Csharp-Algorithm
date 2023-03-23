using System;
using System.Collections.Generic;

namespace Exercise
{
    // 스택 : LIFO(후입 선출)
    // 큐 : FIFO(선입 선출)
    class Graph
    {
        int[,] adj = new int[6, 6]
        {
            { 0,1,0,1,0,0 },
            { 1,0,1,1,0,0 },
            { 0,1,0,0,0,0 },
            { 1,1,0,0,1,0 },
            { 0,0,0,1,0,1 },
            { 0,0,0,0,1,0 },
        };

        List<int>[] adj2 = new List<int>[]
        {
            new List<int>() { 1,3 },
            new List<int>() { 0,2,3 },
            new List<int>() { 1 },
            new List<int>() { 0,1,4 },
            new List<int>() { 3,5 },
            new List<int>() { 4 },
        };

        bool[] visited = new bool[6];

        public void DFS(int now)
        {
            Console.WriteLine(now);
            visited[now] = true; // now부터 방문

            for (int next = 0; next < 6; next++)
            {
                if (adj[now, next] == 0) // 연결되어 있지 않으면 스킵
                {
                    continue;
                }
                if (visited[next])  // 이미 방문 했으면 스킵
                {
                    continue;
                }
                DFS(next);
            }
        }

        public void DFS2(int now)
        {
            Console.WriteLine(now);
            visited[now] = true; // now부터 방문

            foreach (int next in adj2[now]) // 연결되어 있지 않으면 스킵
            {
                if (visited[next]) // 이미 방문 했으면 스킵
                {
                    continue;
                }
                DFS2(next);
            }
        }

        public void SearchAll()
        {
            visited = new bool[6];
            for (int now = 0; now < 6; now++)
            {
                if (visited[now]=false)
                {
                    DFS(now);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // DFS (Depth First Search 깊이 우선 탐색)
            // BFS (Breadth First Search 너비 우선 탐색)

            Graph graph = new Graph();
            graph.DFS2(0);
        }
    }
}
