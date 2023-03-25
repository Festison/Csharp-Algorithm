using System;
using System.Collections.Generic;

namespace Exercise
{
    class Graph
    {
        int[,] adj = new int[6, 6]
        {
            { -1, 15, -1, 35, -1, -1 },
            { 15, -1, 05, 10, -1, -1 },
            { -1, 05, -1, -1, -1, -1 },
            { 35, 10, -1, -1, -05, -1 },
            { -1, -1, -1, 05, -1, 05 },
            { -1, -1, -1, -1, 05,- 1 },
        };

        public void Dijikstra(int start)
        {
            bool[] visited = new bool[6];
            int[] distance = new int[6];
            int[] parent = new int[6];
            Array.Fill(distance, Int32.MaxValue);

            distance[start] = 0;
            parent[start] = start;

            while (true)
            {
                // 제일 좋은 후보를 찾는다.

                // 가장 유력한 후보의 거리와 번호를 저장한다.
                int closest = Int32.MaxValue;
                int now = -1;

                for (int i = 0; i < 6; i++)
                {
                    // 이미 방문한 정점은 스킵
                    if (visited[i])
                    {
                        continue;
                    }
                    // 아직 발견된 적잉 없거나 기존 후보보다 멀리 있으면 스킵
                    if (distance[i] == Int32.MaxValue || distance[i] >= closest)
                    {
                        continue;
                    }
                    // 지금까지 발견한 가장 좋은 후보 (정보를 갱신)
                    closest = distance[i];
                    now = i;
                }

                // 다음 후보가 하나도 없다 -> 종료
                if (now == -1)
                {
                    break;
                }

                // 제일 좋은 후보를 찾았으니까 방문
                visited[now] = true;

                // 방문한 정점과 인접한 정점들을 조사해 상황에 따라 발견한 최단거리를 갱신
                for (int next = 0; next < 6; next++)
                {
                    // 연결되지 않은 정점 스킵
                    if (adj[now, next] == -1)
                    {
                        continue;
                    }
                    // 이미 방문한 정점은 스킵
                    if (visited[next])
                    {
                        continue;
                    }

                    // 새로 조사된 정점의 최단거리를 계산한다
                    int nextDist = distance[now] + adj[now, next];
                    // 만약에 기존에 발견한 최단거리가 새로 조사된최단거리보다 크면, 정보를 갱신
                    if (nextDist < distance[next])
                    {
                        distance[next] = nextDist;
                        parent[start] = now;
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 다익스트라 알고리즘 : 가중치를 이용
        }
    }
}
