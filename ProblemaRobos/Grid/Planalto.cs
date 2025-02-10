using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemaRobos.Grid {
    internal class Planalto {
        private int X { get; set; }
        private int Y { get; set; }

        public Planalto(string entrada) {
            (X, Y) = Converter(entrada);
        }

        public (int , int) Converter(string Entrada) {
            string[] Numeros = Entrada.Split(' ');
            int[] Nums = Array.ConvertAll(Numeros, int.Parse);
            int x = Nums[0];
            int y = Nums[1];
            return (x, y);
        }

        public int getX() {
            return X;
        }
        public int getY() {
            return Y;
        }
    }


}
