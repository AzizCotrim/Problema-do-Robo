using ProblemaRobos.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ProblemaRobos.Robo {
    internal class Robo {
        private int hr {  get; set; }
        private int vt { get; set; }
        private int direcao { get; set; }
        private readonly Planalto planalto;

        public Robo(string texto, Planalto planalto) {
            this.planalto = planalto;
            var (x,y,z) = ConverterPosicao(texto);
            VerificarCoord(x,y);
            Orientacao(z);
        }

        public (int, int, string) ConverterPosicao(string Entrada) {
            string[] separar = Entrada.Split(' ');
            int x = int.Parse(separar[0]);
            int y = int.Parse(separar[1]);
            //char z = char.Parse();
            return(x,y, separar[2]);
        }

        public void VerificarCoord(int x, int y) {
            if (x > planalto.getX()) {
                throw new ArgumentException("Posição X maior que o comprimento do planalto");
            }
            if (y > planalto.getY()) {
                throw new ArgumentException("Posição Y maior que a largura do planalto");
            }

            hr = x;
            vt = y;
        }

        public void LerInstrucao(string escrita) {
            escrita = escrita.ToUpper();
            string[] instrucao = new string[escrita.Length];
            for (int i = 0; i < escrita.Length; i++) {
                instrucao[i] = escrita[i].ToString();
            }

            foreach (string c in instrucao) {
                switch (c) {
                    case "M":
                        Andar();
                        break;

                    case "N" or "E" or "S" or "W":
                        Orientacao(c);
                        break;

                    case "L":
                        VirarEsquerda();
                        break;

                    case "R":
                        VirarDireita();
                        break;

                    default:
                        Console.WriteLine($"O caracter {c} não corresponde com nenhuma letra de comando");
                        break;
                }
                
            }
            MostrarPosicao();
        }

        public void Orientacao(string direcao) {
            direcao = direcao.ToUpper();

            switch (direcao) {

                case "N":
                   this.direcao = 0;
                    break;

                case "E":
                   this.direcao = 1;
                    break;

                case "S":
                    this.direcao = 2;
                    break;

                case "W":
                    this.direcao = 3;
                    break;

                default:
                    Console.WriteLine("A letra digitada nao corresponde a uma direcao, ou esta em letra minuscula");
                    break;
            }

        }

        public void Andar() {
            
            switch (direcao) {

                case 0:
                    if(vt < planalto.getY())
                        vt++;
                    break;

                case 1:
                    if (hr < planalto.getX())
                        hr++;
                    break;

                case 2:
                    if (vt > 0)
                        vt--;
                    break;

                case 3:
                    if (hr > 0)
                        hr--;
                    break;
            }
            
        }

        public void VirarDireita() {
            this.direcao = (direcao + 1) % 4;
        }

        public void VirarEsquerda() {
            this.direcao = (direcao - 1 + 4) % 4;
        }

        public void MostrarPosicao() {
            string[] direcoes = { "N", "L", "S", "O" };
            Console.WriteLine($"Posição: ({hr},{vt},{direcoes[direcao]})");
        }
    }
}
