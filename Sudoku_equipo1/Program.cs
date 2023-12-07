namespace ASR1
{
    class Program
    {
       /* The above code is a C# program that implements a Sudoku game. It declares a 2D array called
       "sudoku" to store the Sudoku board, a dictionary called "colores" to store colors for the
       console output, and a random number generator. It also declares a boolean variable "jugar" to
       control the game loop. */
        static string[,] sudoku = new string[10,10];
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
   /// <summary>
   /// The function "IniciarJuego" displays instructions for playing a Sudoku game and prompts the
   /// player to make a decision.
   /// </summary>
        static void IniciarJuego()
        {
            Console.WriteLine("!!!BIENVENIDO AL JUEGO DEL SUDOKU!!!");
            Console.WriteLine("PARA JUGAR TIENES QUE INGRESAR UN NUMERO DE 3 DIGITOS");
            Console.WriteLine("EL PRIMER NUMERO ES EL NUMERO A COLOCAR, EL 0 NO JUEGA");
            Console.WriteLine("EL SEGUNDO ES EL NUMERO DE COLUMNA");
            Console.WriteLine("EL TERCERO ES EL NUMERO DE FILA");
            Console.WriteLine("511 COLOCARIA EL NUMERO 5 EN LA POSICION 1,1");
            DesicionJugador();
        }
       /// <summary>
       /// The function "DesicionJugador" prompts the user to decide whether they want to start playing
       /// a game or not, and then performs different actions based on their choice.
       /// </summary>
        static void DesicionJugador()
        {
            Console.WriteLine("QUIERES INICIAR?");
            Console.WriteLine("A) SI");
            Console.WriteLine("B) NO");
            string opcion = Console.ReadLine();
            switch (opcion.ToLower())
            {
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
        /// <summary>
        /// The function "Jugar" prompts the user to make a move and then calls another function to
        /// validate the input.
        /// </summary>
        static void Jugar()
        {
            Console.WriteLine("Realiza el un movimiento...");
            string input = "";
            input = Console.ReadLine();
            ComprobacionInputJugador(input);
        }
        static void ComprobacionInputJugador(string input)
        {
            /* The above code is checking the length of the input string. If the length is greater than
            3 or less than 3, it will display an error message and call the Jugar() method again. */
            if (input.Length > 3 || input.Length < 3)
            {
                Console.WriteLine("Numero ingresado erroneo, reintentalo...");
                Jugar();
            }
            /* The above code is a part of a larger program written in C#. It is an else block that is
            executed when certain conditions are not met. */
            else
            {
               /* The above code is checking the validity of user input in a game. It checks if the
               first character of the input is a number between 1 and 9. If it is not, it displays
               an error message and calls the `Jugar()` function again. */
                string pos1 = input[0].ToString();
                string pos2 = input[1].ToString();
                string pos3 = input[2].ToString();
                if (pos1 != "1" && pos1 != "2" && pos1 != "3" && pos1 != "4" && pos1 != "5" && pos1 != "6" && pos1 != "7" && pos1 != "8" && pos1 != "9")
                {
                    Console.WriteLine("Numero ingresado erroneo, reintentalo...");
                    Jugar();
                }
                if ((pos2 != "1" && pos2 != "2" && pos2 != "3" && pos2 != "4" && pos2 != "5" && pos2 != "6" && pos2 != "7" && pos2 != "8" && pos2 != "9") ||
                    (pos3 != "1" && pos3 != "2" && pos3 != "3" && pos3 != "4" && pos3 != "5" && pos3 != "6" && pos3 != "7" && pos3 != "8" && pos3 != "9"))
                {
                    Console.WriteLine("Posicion incorrecta, reintentalo...");
                    Jugar();
                }
                VerificarInpunt(pos1, int.Parse(pos2), int.Parse(pos3), true);
            }
        }
       /* The above code is a method called "VerificarInpunt" in C#. It takes in a string "numero", and
       integer positions "posX" and "posY", and a boolean "isPlayer". */
        static bool VerificarInpunt(string numero, int posX, int posY, bool isPlayer)
        {
            bool error = false;
           /* The above code is a C# program that implements a Sudoku game. It includes a function
           called "Jugar" which is responsible for validating the user's input and updating the
           Sudoku board accordingly. The code checks if the entered number already exists in the
           same row or column, and if it does, it displays an error message and prompts the user to
           try again. It also checks if the entered number violates the rules of the Sudoku game
           within the specific color-coded regions of the board. If the entered number violates any
           of the rules, it displays an error message and prompts the user to try again. */
            for (int i = 1; i < 10; i++)
            {
                if (sudoku[posX, i] == numero || sudoku[i, posY] == numero)
                {
                    error = true;
                    if (isPlayer)
                    {
                        Console.WriteLine("Accion incorrecta, vuelve a intentarlo");
                        Jugar();
                    }
                    else
                    {
                        return error;
                    }
                }
            }
            if (!error)

            {
                string pos = posX.ToString();
                pos += posY.ToString();
                ConsoleColor colorPos = colores[pos];
                switch (colorPos)
                {
                    case ConsoleColor.Green:
                        for (int i = 10; i < 31; i += 10)
                        {
                            for (int j = 1; j < 4; j++)
                            {
                                string newPos = (i + j).ToString();
                                if (sudoku[int.Parse(newPos[0].ToString()), int.Parse(newPos[1].ToString())] == numero)
                                {
                                    error = true;
                                    if (isPlayer)
                                    {
                                        Console.WriteLine("Accion incorrecta, vuelve a intentarlo");
                                        Jugar();
                                    }
                                }
                            }
                        }
                        break;
                    case ConsoleColor.Yellow:
                        for (int i = 10; i < 31; i += 10)
                        {
                            for (int j = 4; j < 7; j++)
                            {
                                string newPos = (i + j).ToString();
                                if (sudoku[int.Parse(newPos[0].ToString()), int.Parse(newPos[1].ToString())] == numero)
                                {
                                    error = true;
                                    if (isPlayer)
                                    {
                                        Console.WriteLine("Accion incorrecta, vuelve a intentarlo");
                                        Jugar();
                                    }
                                }
                            }
                        }
                        break;
                    case ConsoleColor.Red:
                        for (int i = 10; i < 31; i += 10)
                        {
                            for (int j = 7; j < 10; j++)
                            {
                                string newPos = (i + j).ToString();
                                if (sudoku[int.Parse(newPos[0].ToString()), int.Parse(newPos[1].ToString())] == numero)
                                {
                                    error = true;
                                    if (isPlayer)
                                    {
                                        Console.WriteLine("Accion incorrecta, vuelve a intentarlo");
                                        Jugar();
                                    }
                                }
                            }
                        }
                        break;
                    case ConsoleColor.Cyan:
                        for (int i = 40; i < 61; i += 10)
                        {
                            for (int j = 1; j < 4; j++)
                            {
                                string newPos = (i + j).ToString();
                                if (sudoku[int.Parse(newPos[0].ToString()), int.Parse(newPos[1].ToString())] == numero)
                                {
                                    error = true;
                                    if (isPlayer)
                                    {
                                        Console.WriteLine("Accion incorrecta, vuelve a intentarlo");
                                        Jugar();
                                    }
                                }
                            }
                        }
                        break;
                    case ConsoleColor.Magenta:
                        for (int i = 40; i < 61; i += 10)
                        {
                            for (int j = 4; j < 7; j++)
                            {
                                string newPos = (i + j).ToString();
                                if (sudoku[int.Parse(newPos[0].ToString()), int.Parse(newPos[1].ToString())] == numero)
                                {
                                    error = true;
                                    if (isPlayer)
                                    {
                                        Console.WriteLine("Accion incorrecta, vuelve a intentarlo");
                                        Jugar();
                                    }
                                }
                            }
                        }
                        break;
                    case ConsoleColor.Blue:
                        for (int i = 40; i < 61; i += 10)
                        {
                            for (int j = 7; j < 10; j++)
                            {
                                string newPos = (i + j).ToString();
                                if (sudoku[int.Parse(newPos[0].ToString()), int.Parse(newPos[1].ToString())] == numero)
                                {
                                    error = true;
                                    if (isPlayer)
                                    {
                                        Console.WriteLine("Accion incorrecta, vuelve a intentarlo");
                                        Jugar();
                                    }
                                }
                            }
                        }
                        break;
                    case ConsoleColor.DarkMagenta:
                        for (int i = 70; i < 91; i += 10)
                        {
                            for (int j = 1; j < 4; j++)
                            {
                                string newPos = (i + j).ToString();
                                if (sudoku[int.Parse(newPos[0].ToString()), int.Parse(newPos[1].ToString())] == numero)
                                {
                                    error = true;
                                    if (isPlayer)
                                    {
                                        Console.WriteLine("Accion incorrecta, vuelve a intentarlo");
                                        Jugar();
                                    }
                                }
                            }
                        }
                        break;
                    case ConsoleColor.DarkCyan:
                        for (int i = 70; i < 91; i += 10)
                        {
                            for (int j = 4; j < 7; j++)
                            {
                                string newPos = (i + j).ToString();
                                if (sudoku[int.Parse(newPos[0].ToString()), int.Parse(newPos[1].ToString())] == numero)
                                {
                                    error = true;
                                    if (isPlayer)
                                    {
                                        Console.WriteLine("Accion incorrecta, vuelve a intentarlo");
                                        Jugar();
                                    }
                                }
                            }
                        }
                        break;
                    case ConsoleColor.DarkYellow:
                        for (int i = 70; i < 91; i += 10)
                        {
                            for (int j = 7; j < 10; j++)
                            {
                                string newPos = (i + j).ToString();
                                if (sudoku[int.Parse(newPos[0].ToString()), int.Parse(newPos[1].ToString())] == numero)
                                {
                                    error = true;
                                    if (isPlayer)
                                    {
                                        Console.WriteLine("Accion incorrecta, vuelve a intentarlo");
                                        Jugar();
                                    }
                                }
                            }
                        }
                        break;
                    case ConsoleColor.White:
                        if (isPlayer)
                        {
                            Console.WriteLine("Los numeros en blanco no se pueden modificar, ingresa otra coordenada");
                            Jugar();
                        }
                        else
                        {
                            error = true;
                            return error;
                        }
                        break;

                }
            }
            /* The code is checking if there is no error and if the player is currently playing. If
            both conditions are true, it assigns a value to a position in a sudoku array, prints the
            sudoku, and then calls the Jugar() function. Finally, it returns the value of the error
            variable. If the conditions are not met, it simply returns the value of the error
            variable. */
            if (!error && isPlayer)
            {
                sudoku[posX, posY] = numero;
                ImprimirSudoku();
                Jugar();
                return error;
            }
            return error;
        }
        static void ImprimirSudoku()
        {
            Console.Clear();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("");
                for(int j = 0; j<10; j++)
                {
                    string pos = i.ToString();
                    pos += j.ToString();
                    Console.ForegroundColor = colores[pos];
                    Console.Write(" "+sudoku[i,j]);
                }
            }
            Console.WriteLine("");
        }
        /// <summary>
        /// The PrimordialState function initializes a Sudoku grid with numbers and empty spaces.
        /// </summary>
        static void PrimordialState()
        {
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
        }
       /// <summary>
       /// The function "AsignarColores" assigns specific ConsoleColor values to different keys in a
       /// dictionary called "colores".
       /// </summary>
        static void AsignarColores()
        {
            colores.Add("00", ConsoleColor.White);
            colores.Add("01", ConsoleColor.White);
            colores.Add("02", ConsoleColor.White);
            colores.Add("03", ConsoleColor.White);
            colores.Add("04", ConsoleColor.White);
            colores.Add("05", ConsoleColor.White);
            colores.Add("06", ConsoleColor.White);
            colores.Add("07", ConsoleColor.White);
            colores.Add("08", ConsoleColor.White);
            colores.Add("09", ConsoleColor.White);
            colores.Add("10", ConsoleColor.White);
            colores.Add("20", ConsoleColor.White);
            colores.Add("30", ConsoleColor.White);
            colores.Add("40", ConsoleColor.White);
            colores.Add("50", ConsoleColor.White);
            colores.Add("60", ConsoleColor.White);
            colores.Add("70", ConsoleColor.White);
            colores.Add("80", ConsoleColor.White);
            colores.Add("90", ConsoleColor.White);
            colores.Add("11", ConsoleColor.Green);
            colores.Add("12", ConsoleColor.Green);
            colores.Add("13", ConsoleColor.Green);
            colores.Add("21", ConsoleColor.Green);
            colores.Add("22", ConsoleColor.Green);
            colores.Add("23", ConsoleColor.Green);
            colores.Add("31", ConsoleColor.Green);
            colores.Add("32", ConsoleColor.Green);
            colores.Add("33", ConsoleColor.Green);
            colores.Add("14", ConsoleColor.Yellow);
            colores.Add("15", ConsoleColor.Yellow);
            colores.Add("16", ConsoleColor.Yellow);
            colores.Add("24", ConsoleColor.Yellow);
            colores.Add("25", ConsoleColor.Yellow);
            colores.Add("26", ConsoleColor.Yellow);
            colores.Add("34", ConsoleColor.Yellow);
            colores.Add("35", ConsoleColor.Yellow);
            colores.Add("36", ConsoleColor.Yellow);
            colores.Add("17", ConsoleColor.Red);
            colores.Add("18", ConsoleColor.Red);
            colores.Add("19", ConsoleColor.Red);
            colores.Add("27", ConsoleColor.Red);
            colores.Add("28", ConsoleColor.Red);
            colores.Add("29", ConsoleColor.Red);
            colores.Add("37", ConsoleColor.Red);
            colores.Add("38", ConsoleColor.Red);
            colores.Add("39", ConsoleColor.Red);
            colores.Add("41", ConsoleColor.Cyan);
            colores.Add("42", ConsoleColor.Cyan);
            colores.Add("43", ConsoleColor.Cyan);
            colores.Add("51", ConsoleColor.Cyan);
            colores.Add("52", ConsoleColor.Cyan);
            colores.Add("53", ConsoleColor.Cyan);
            colores.Add("61", ConsoleColor.Cyan);
            colores.Add("62", ConsoleColor.Cyan);
            colores.Add("63", ConsoleColor.Cyan);
            colores.Add("44", ConsoleColor.Magenta);
            colores.Add("45", ConsoleColor.Magenta);
            colores.Add("46", ConsoleColor.Magenta);
            colores.Add("54", ConsoleColor.Magenta);
            colores.Add("55", ConsoleColor.Magenta);
            colores.Add("56", ConsoleColor.Magenta);
            colores.Add("64", ConsoleColor.Magenta);
            colores.Add("65", ConsoleColor.Magenta);
            colores.Add("66", ConsoleColor.Magenta);
            colores.Add("47", ConsoleColor.Blue);
            colores.Add("48", ConsoleColor.Blue);
            colores.Add("49", ConsoleColor.Blue);
            colores.Add("57", ConsoleColor.Blue);
            colores.Add("58", ConsoleColor.Blue);
            colores.Add("59", ConsoleColor.Blue);
            colores.Add("67", ConsoleColor.Blue);
            colores.Add("68", ConsoleColor.Blue);
            colores.Add("69", ConsoleColor.Blue);
            colores.Add("71", ConsoleColor.DarkMagenta);
            colores.Add("72", ConsoleColor.DarkMagenta);
            colores.Add("73", ConsoleColor.DarkMagenta);
            colores.Add("81", ConsoleColor.DarkMagenta);
            colores.Add("82", ConsoleColor.DarkMagenta);
            colores.Add("83", ConsoleColor.DarkMagenta);
            colores.Add("91", ConsoleColor.DarkMagenta);
            colores.Add("92", ConsoleColor.DarkMagenta);
            colores.Add("93", ConsoleColor.DarkMagenta);
            colores.Add("74", ConsoleColor.DarkCyan);
            colores.Add("75", ConsoleColor.DarkCyan);
            colores.Add("76", ConsoleColor.DarkCyan);
            colores.Add("84", ConsoleColor.DarkCyan);
            colores.Add("85", ConsoleColor.DarkCyan);
            colores.Add("86", ConsoleColor.DarkCyan);
            colores.Add("94", ConsoleColor.DarkCyan);
            colores.Add("95", ConsoleColor.DarkCyan);
            colores.Add("96", ConsoleColor.DarkCyan);
            colores.Add("77", ConsoleColor.DarkYellow);
            colores.Add("78", ConsoleColor.DarkYellow);
            colores.Add("79", ConsoleColor.DarkYellow);
            colores.Add("87", ConsoleColor.DarkYellow);
            colores.Add("88", ConsoleColor.DarkYellow);
            colores.Add("89", ConsoleColor.DarkYellow);
            colores.Add("97", ConsoleColor.DarkYellow);
            colores.Add("98", ConsoleColor.DarkYellow);
            colores.Add("99", ConsoleColor.DarkYellow);
        }
       /// <summary>
       /// The function initializes random numbers and positions in a Sudoku grid.
       /// </summary>
        static void InicializarNumerosAleatorios()
        {
            int numeroAleatorio, randomXPos, randomYPos;
            for (int i = 0; i < 15; i++)
            {
                numeroAleatorio = random.Next(1, 9);
                randomXPos = random.Next(1, 9);
                randomYPos = random.Next(1, 9);
                bool error;
                error = VerificarInpunt(numeroAleatorio.ToString(), randomXPos, randomYPos, false);
                while (error)
                {
                    randomXPos = random.Next(1, 9);
                    randomYPos = random.Next(1, 9);
                    error = VerificarInpunt(numeroAleatorio.ToString(), randomXPos, randomYPos, false);
                }
                sudoku[randomXPos, randomYPos] = numeroAleatorio.ToString();
                string pos = randomXPos.ToString();
                pos += randomYPos.ToString();
                colores[pos] = ConsoleColor.White;
            }
        }
    }
}