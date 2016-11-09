using System;
using System.Linq;

namespace Algorithms
{
    //Ориентированный граф. Поиск в глубину
    public class Task11
    {
        public class DFS
        {
            bool[,] MatSmeg { get; set; }
            bool[] ArrVersh { get; set; }
            int N { get; set; }

            public DFS(int n)
            {
                this.N = n;
                this.MatSmeg = new bool[N, N];
                this.ArrVersh = new bool[N];
                var rand = new Random();
                for (var i = 0; i < N; i++)
                    for (var j = 0; j < N; j++)
                        this.MatSmeg[i, j] = Convert.ToBoolean(rand.Next(1));
            }

            public void DFS_Start()
            {
                for (var i = 0; i < N; i++)
                {
                    DFS_Do(i);
                }
            }

            private void DFS_Do(int i)
            {
                this.ArrVersh[i] = true;
                for (var j = 0; j < N; j++)
                {
                    if(!this.ArrVersh[j] && this.MatSmeg[i,j])
                        DFS_Do(j);
                }
            }

            public bool Chech()
            {
                return this.ArrVersh.All(versh => versh);
            }
        }        
    }
}