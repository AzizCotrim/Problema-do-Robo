using ProblemaRobos.Grid;
using ProblemaRobos.Robo;

string Entrada = Console.ReadLine();
Planalto planalto = new Planalto(Entrada);

string posicao = Console.ReadLine();
Robo robo = new Robo(posicao, planalto);

string movimentos = Console.ReadLine();
robo.LerInstrucao(movimentos);





