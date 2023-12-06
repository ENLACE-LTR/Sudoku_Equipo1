﻿/*Emil: Interfaz grafica del sudoku

 ﻿/*Emil: Interfaz grafica del sudoku
 namespace ASR1
{
    class Program
    {

        static string[,] sudoku = new string[10, 10];      //limita el lumero de casillas por juego  
        static Dictionary<string, ConsoleColor> colores = new Dictionary<string, ConsoleColor>();
        static Random random = new Random();
        static bool jugar = true;
        static void Main()
        {
            PrimordialState();
            while (jugar)
            {
                IniciarJuego();
            }
        }
        static void IniciarJuego()
        {
        // inicia con una breve presentacion para el jugador de como jugar el juego
        
            Console.WriteLine("!!!BIENVENIDO AL JUEGO DEL SUDOKU!!!");   //saludo al jugador 
            Console.WriteLine("PARA JUGAR TIENES QUE INGRESAR UN NUMERO DE 3 DIGITOS"); // instrucciones de juego 
            Console.WriteLine("EL PRIMER NUMERO ES EL NUMERO A COLOCAR, EL 0 NO JUEGA");
            Console.WriteLine("EL SEGUNDO ES EL NUMERO DE COLUMNA");
            Console.WriteLine("EL TERCERO ES EL NUMERO DE FILA");
            Console.WriteLine("511 COLOCARIA EL NUMERO 5 EN LA POSICION 1,1"); // finalisacion de instrucciones 
            DesicionJugador();
        }
        static void DesicionJugador()
        {
        // Da la opcion al jugador para avandonar el juego o seguir adelante 
            Console.WriteLine("QUIERES INICIAR?");
            Console.WriteLine("A) SI");
            Console.WriteLine("B) NO");
            string opcion = Console.ReadLine();
            switch (opcion.ToLower())
            {
            // dependiendo de la elecciion del jugador se activara alguno de low siguientes acciones.
                case "a":
                    InicializarNumerosAleatorios();
                    ImprimirSudoku();
                    Jugar();
                    break;
                case "b":
                    Console.WriteLine("GRACIAS POR JUGAR, VUELVA PRONTO...");
                    jugar = false;
                    break;
                default:
                    Console.WriteLine("OPCION INCORRECTA, REINTENTALO...");
                    DesicionJugador();
                    break;
            }
        }
 static void ImprimirSudoku()
 {
     Console.Clear();
     for (int i = 0; i < 10; i++)
     {
         Console.WriteLine("");
         for (int j = 0; j < 10; j++)
         {
             string pos = i.ToString();
             pos += j.ToString();
             Console.ForegroundColor = colores[pos];
             Console.Write(" " + sudoku[i, j]);
         }
     }
     Console.WriteLine("");
 }
 static void PrimordialState()
 {
 // escritura de las casillas de sudoku 
     sudoku[0, 0] = " ";
     sudoku[0, 1] = "1";
     sudoku[0, 2] = "2";
     sudoku[0, 3] = "3";
     sudoku[0, 4] = "4";
     sudoku[0, 5] = "5";
     sudoku[0, 6] = "6";
     sudoku[0, 7] = "7";
     sudoku[0, 8] = "8";
     sudoku[0, 9] = "9";
     sudoku[1, 0] = "1";
     sudoku[1, 1] = "_";
     sudoku[1, 2] = "_";
     sudoku[1, 3] = "_";
     sudoku[1, 4] = "_";
     sudoku[1, 5] = "_";
     sudoku[1, 6] = "_";
     sudoku[1, 7] = "_";
     sudoku[1, 8] = "_";
     sudoku[1, 9] = "_";
     sudoku[2, 0] = "2";
     sudoku[2, 1] = "_";
     sudoku[2, 2] = "_";
     sudoku[2, 3] = "_";
     sudoku[2, 4] = "_";
     sudoku[2, 5] = "_";
     sudoku[2, 6] = "_";
     sudoku[2, 7] = "_";
     sudoku[2, 8] = "_";
     sudoku[2, 9] = "_";
     sudoku[3, 0] = "3";
     sudoku[3, 1] = "_";
     sudoku[3, 2] = "_";
     sudoku[3, 3] = "_";
     sudoku[3, 4] = "_";
     sudoku[3, 5] = "_";
     sudoku[3, 6] = "_";
     sudoku[3, 7] = "_";
     sudoku[3, 8] = "_";
     sudoku[3, 9] = "_";
     sudoku[4, 0] = "4";
     sudoku[4, 1] = "_";
     sudoku[4, 2] = "_";
     sudoku[4, 3] = "_";
     sudoku[4, 4] = "_";
     sudoku[4, 5] = "_";
     sudoku[4, 6] = "_";
     sudoku[4, 7] = "_";
     sudoku[4, 8] = "_";
     sudoku[4, 9] = "_";
     sudoku[5, 0] = "5";
     sudoku[5, 1] = "_";
     sudoku[5, 2] = "_";
     sudoku[5, 3] = "_";
     sudoku[5, 4] = "_";
     sudoku[5, 5] = "_";
     sudoku[5, 6] = "_";
     sudoku[5, 7] = "_";
     sudoku[5, 8] = "_";
     sudoku[5, 9] = "_";
     sudoku[6, 0] = "6";
     sudoku[6, 1] = "_";
     sudoku[6, 2] = "_";
     sudoku[6, 3] = "_";
     sudoku[6, 4] = "_";
     sudoku[6, 5] = "_";
     sudoku[6, 6] = "_";
     sudoku[6, 7] = "_";
     sudoku[6, 8] = "_";
     sudoku[6, 9] = "_";
     sudoku[7, 0] = "7";
     sudoku[7, 1] = "_";
     sudoku[7, 2] = "_";
     sudoku[7, 3] = "_";
     sudoku[7, 4] = "_";
     sudoku[7, 5] = "_";
     sudoku[7, 6] = "_";
     sudoku[7, 7] = "_";
     sudoku[7, 8] = "_";
     sudoku[7, 9] = "_";
     sudoku[8, 0] = "8";
     sudoku[8, 1] = "_";
     sudoku[8, 2] = "_";
     sudoku[8, 3] = "_";
     sudoku[8, 4] = "_";
     sudoku[8, 5] = "_";
     sudoku[8, 6] = "_";
     sudoku[8, 7] = "_";
     sudoku[8, 8] = "_";
     sudoku[8, 9] = "_";
     sudoku[9, 0] = "9";
     sudoku[9, 1] = "_";
     sudoku[9, 2] = "_";
     sudoku[9, 3] = "_";
     sudoku[9, 4] = "_";
     sudoku[9, 5] = "_";
     sudoku[9, 6] = "_";
     sudoku[9, 7] = "_";
     sudoku[9, 8] = "_";
     sudoku[9, 9] = "_";
     AsignarColores();
     {
    
 }

 
 * Aztlan: Generacion de numeros al azar del sudoku
 *Diego: Colores numeros sudoku
 *Andres: Validacion de numeros del sudoku.
 */
