// See https://aka.ms/new-console-template for more information
using System.ComponentModel.Design;Console.WriteLine("Hello, World!");int totalJugador ;int totalDealer ;int num;string controlOtraCarta = "";string message = "";string switchControl = "menu"; //cambiar a 21 para que jugeue blackjackSystem.Random random = new System.Random();int platziCoins;bool isNumeric;int number;string[] choices = { "piedra", "papel", "tijeras" };int apuesta;while (true){    Console.WriteLine("\nWelcome al c a s i n o!");    Console.WriteLine("¿Cuantos creditos desea comprar?\nRecuerda ingresar numeros interos\n Y que necesitas una por ronda juego.");    Console.WriteLine("¿Cuántas veces quiere jugar? (PARA SALIR escribe cualquier cosa que no sea un número)");    string input_game = Console.ReadLine();
    
    isNumeric = int.TryParse(input_game, out number);    if (isNumeric && number !=0 )
    {
        //platziCoins = int.Parse(Console.ReadLine()); //Opción 1
        platziCoins = Convert.ToInt32(input_game); //Opcion 2
    }    else
    {
        Console.WriteLine("El valor ingresado no es un número entero válido o es 0, por favor vuelva a iniciar el juego desde la consola...");
        break;
    }    

    for (int i = platziCoins; i > 0 ; i--)
    {
        
        totalJugador = 0;
        totalDealer = 0;

        switch (switchControl)
        {
            
            case "menu":
                Console.WriteLine("Escriba '21' para jugar al 21");
                Console.WriteLine("Escriba 'yankenpon' para jugar al piedra-papel-tijeras");
                switchControl = Console.ReadLine();
                i = i + 1;
                break;
            //number = "One";
            case "21":
                Console.WriteLine($"Tienes {i} créditos.");
                Console.WriteLine("¿Cuantos creditos apuestas por este juego?");
                apuesta = Convert.ToInt32(Console.ReadLine());
                do
                {

                    num = random.Next(1, 12);
                    totalJugador = totalJugador + num;
                    Console.WriteLine("Toma tu carta jugador,");
                    Console.WriteLine($"Te salió la carta: {num}");
                    Console.WriteLine("¿Deseas otra Carta? (si o no)");
                    controlOtraCarta = Console.ReadLine();
                } while (controlOtraCarta == "si" ||
                    controlOtraCarta == "SI" ||
                    controlOtraCarta == "YES");

                totalDealer = random.Next(14, 21);
                Console.WriteLine("El total tuyo es: " + totalJugador);
                Console.WriteLine("El total del Dealer es: " + totalDealer);
                if (totalJugador > totalDealer && totalJugador <= 21)
                {
                    message = "Venciste al dealer, felicidades!! :D \n";
                    i = i + 1 + apuesta;
                }
                else if (totalJugador > 21)
                {
                    message = "Perdiste versus el dealer, Te pasaste de 21 :c \n";
                    i = i + 1 - apuesta;
                }
                else if (totalJugador <= totalDealer)
                {
                    message = "Perdiste versus el dealer, lo siento :c \n";
                    i = i + 1 - apuesta;
                }
                else
                {
                    message = "Condición no válida \n";
                }

                //Imprimir resultado de condicional
                Console.WriteLine(message);
                //Reseteo variable switch control
                switchControl = "menu";
                break;

            case "yankenpon":
                Console.WriteLine("Bienvenido a Piedra Papel o Tijeras!");
                Console.WriteLine($"Tienes {i} créditos.");
                Console.WriteLine("¿Cuantos creditos apuestas por este juego?");
                apuesta = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Elige tu opción");
                string opcionJugador = Console.ReadLine().ToLower();
                if (!Array.Exists(choices, element => element == opcionJugador))
                {
                    Console.WriteLine("Elección inválida. Intenta de nuevo.");
                    continue;
                }

                int opcionDealer = random.Next(choices.Length);
                string eleccionDealer = choices[opcionDealer];
                Console.WriteLine($"El dealer eligió: {eleccionDealer}");
                if (opcionJugador == eleccionDealer)
                {
                    Console.WriteLine("Es un Empate! \n");
                    i = i + 1;
                }
                else if ((opcionJugador == "piedra" && eleccionDealer == "tijeras") ||
                     (opcionJugador == "papel" && eleccionDealer == "piedra") ||
                     (opcionJugador == "tijeras" && eleccionDealer == "papel"))
                {
                    Console.WriteLine("GANASTE! \n");
                    i = i + 1 + apuesta;
                }
                else 
                {
                    Console.WriteLine("Perdiste :c \n");
                    i = i + 1 - apuesta;
                }
                switchControl = "menu";
                break;

            default:
                Console.WriteLine("Valor Default, tu valor ingresado no es válido en el casino");
                break;
        }
    }}