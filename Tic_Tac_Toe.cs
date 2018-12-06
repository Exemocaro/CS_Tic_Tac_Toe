using System;

namespace ConsoleApp4
{
    class Program
    {
        public static bool came_from_settings = false;
        public static int difficulty = 2;
        public static bool time = true;
        public static bool sounds = true;
        public static bool invalid_input = false;
        public static bool beg = true;
        public static bool beginning = true;

        static void Main()
        {
            beginning = true; // esta variável vai deixar mudar o jogador mudar o seu nome no loop do jogo. Eu não quero que o jogador tenha que meter o seu
            // nome sempre que jogue, logo só vai pedir para mudar o nome quando regressar ao menu principal.

            //String[] play_list = ["play", "p", ""]; // A dificuldade do jogo.

            Console.Clear(); // para apagar o que está na consola.
            if (beg == true)
            {
                Console.Write("\nInitializing");
                System.Threading.Thread.Sleep(350);
                Console.Write(".");
                System.Threading.Thread.Sleep(350);
                Console.Write(".");
                System.Threading.Thread.Sleep(350);
                Console.Write(".\n\n");
                System.Threading.Thread.Sleep(250);
            }

            if (invalid_input == true) // criei esta variável só para aparecer esta mensagem.
            {
                Console.WriteLine("Invalid Input! Try again.\n");
                invalid_input = false;
            }

            if (beg == true)
            {
                Console.WriteLine("Welcome to the game of Tic Tac Toe! ( \"Jogo do Galo\" )");
            }
            else
            {
                Console.WriteLine("##        Tic Tac Toe | Jogo do Galo         ##");
            }
            Console.WriteLine("\n## Press \"p\" to play.                        ##");
            Console.WriteLine("## Press \"h\" to help.                        ##");
            Console.WriteLine("## Press \"s\" to settings.                    ##");
            Console.WriteLine("## Press \"q\" to quit the game.               ##");
            Console.Write("-->");
            String main_input = Console.ReadLine();
            Console.Clear();

            beg = false;

            switch (main_input)
            {
                case "p":
                    Console.WriteLine();
                    Game();
                    break;

                case "h":
                    Console.WriteLine();
                    Help();
                    break;

                case "s":
                    Console.WriteLine();
                    Settings();
                    break;

                case "q":
                    Console.Write("\nClosing");
                    System.Threading.Thread.Sleep(350);
                    Console.Write(".");
                    System.Threading.Thread.Sleep(350);
                    Console.Write(".");
                    System.Threading.Thread.Sleep(350);
                    Console.Write(".");
                    System.Threading.Thread.Sleep(350);
                    break;
                default:
                    invalid_input = true;
                    if (sounds == true)
                    {
                        Console.Beep(2000, 100);
                    }
                    Main();
                    break;
            }
        }

        static void Help()
        {
            Console.Clear();
            Console.WriteLine("## Help:\n");
            Console.WriteLine("You are going to play against the AI and who wins receives 1 point.");
            Console.WriteLine("To make a move write a number between 1 and 9 to play in the respective block, just like this:");
            Console.WriteLine("( or like the numbers on a phone lol )\n");
            Console.WriteLine("  1  |  2  |  3  ");
            Console.WriteLine(" --- |---- |--- ");
            Console.WriteLine("  4  |  5  |  6  ");
            Console.WriteLine("---- |---- |----");
            Console.WriteLine("  7  |  8  |  9  ");
            Console.WriteLine("\n## Press Enter to go to the main menu.");
            Console.ReadLine();
            Main();
        }

        static void Settings()
        {
            if (came_from_settings == false)
            {
                Console.Clear();
            }
            Console.WriteLine("## Settings:");
            Console.WriteLine("\n## Press \"d\" to change the difficulty.");
            if (time == true)
            {
                Console.WriteLine("## Press \"t\" to disable the AI \"Thinking...\".");
            }
            else
            {
                Console.WriteLine("## Press \"t\" to enable the AI \"Thinking...\".");
            }
            if (sounds == true)
            {
                Console.WriteLine("## Press \"s\" to disable the sounds.");
            }
            else
            {
                Console.WriteLine("## Press \"s\" to enable the sounds.");
            }
            Console.WriteLine("## Press \"q\" to quit and go to the main menu.");
            Console.Write("-->");
            String iinput = Console.ReadLine(); // tem mesmo de ser "iinput" para não confundir com o "input" dentro do switch.
            Console.Clear();

            switch (iinput)
            {
                case "d":
                    Console.WriteLine("Choose your difficulty between 1 and 3, but don't regret it...");
                    Console.WriteLine("1 --> Easy");
                    Console.WriteLine("2 --> Medium");
                    Console.WriteLine("3 --> Extreme");
                    int input = Convert.ToInt32(Console.ReadLine());
                    switch (input)
                    {
                        case 1:
                            difficulty = 1;
                            break;
                        case 2:
                            difficulty = 2;
                            break;
                        case 3:
                            difficulty = 3;
                            break;
                        default:
                            difficulty = 2;
                            break;
                    }
                    Settings();
                    break;
                case "q":
                    Main();
                    break;
                case "t":
                    if (time == false)
                    {
                        time = true;
                    }
                    else
                    {
                        time = false;
                    }

                    Settings();
                    break;
                case "s":
                    if (sounds == false)
                    {
                        Console.Beep(2000, 100);
                        sounds = true;
                    }
                    else
                    {
                        sounds = false;
                    }

                    Settings();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Wrong Input! Try again.");
                    if (sounds == true)
                    {
                        Console.Beep(2000, 100);
                    }
                    came_from_settings = true;
                    Settings();
                    break;
            }
        }

        static void Repeat_Text()
        {
            Console.Write("\nPress Enter to Repeat the Program, anything else to return to the main screen: -->");
        }

        static void Game()
        {
            string player_name = "";
            int p_points = 0;
            int ai_points = 0;
            // int difficulty = 2; // A dificuldade do jogo. ----------> não pode estar aqui.
            int cnt = 0; // Para contar o número de rondas jogadas e para ajudar o AI.
            int result = 0;
            String[] blocks = { "", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", }; // isto é uma array, equivalente a uma lista em python.
            // o index 0 não serve para nada e eu não o vou usar para não confundir com os blocos numerados de 1 a 9.

            void Map()
            {
                Console.WriteLine(" {0} | {1} | {2} ", blocks[1], blocks[2], blocks[3]);
                Console.WriteLine(" --- |---- |--- ");
                Console.WriteLine(" {0} | {1} | {2} ", blocks[4], blocks[5], blocks[6]);
                Console.WriteLine("---- |---- |----");
                Console.WriteLine(" {0} | {1} | {2} ", blocks[7], blocks[8], blocks[9]);
            }

            void ScoreUI()
            {
                Console.WriteLine(" \n## SCORE: ");
                Console.WriteLine(" {0}: {1}  |  AI: {2}", player_name, Convert.ToString(p_points), Convert.ToString(ai_points));
            }

            bool Check_Tile_Availability(String block)
            {
                if (block == "   ")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            void Change_Block_Player(int block_number)
            {
                blocks[block_number] = " X ";
            }

            void Change_Block_AI(int block_number)
            {
                blocks[block_number] = " O ";
            }

            void Player_Move()
            {
                bool player_played = false;
                while (player_played == false)
                {
                    Console.Write("\nYour turn --> ");
                    int move_player = Convert.ToInt32(Console.ReadLine());
                    if (Check_Tile_Availability(blocks[move_player]))
                    {
                        Change_Block_Player(move_player);
                        player_played = true;
                    }
                    else
                    {
                        Console.WriteLine("The tile is occupied! Try again.");
                        continue;
                    }
                }
            }

            void AI_Move()
            {
                Random rnd = new Random();
                void Play_Normal_Move()
                {
                    switch (cnt) // criei uma estratégia para o AI que vai segui-la até à 4ª jogada, e se não ganhar até lá então vai jogar à sorte, visto que provavelmente vai ser empate.
                    {
                        case 1:
                            if (difficulty == 3)
                            {
                                if (Check_Tile_Availability(blocks[5]))
                                {
                                    Change_Block_AI(5);
                                }
                                else
                                {
                                    Change_Block_AI(1);
                                }
                            }
                            if (difficulty == 2)
                            {
                                if (Check_Tile_Availability(blocks[3]))
                                {
                                    Change_Block_AI(3);
                                }
                                else
                                {
                                    Change_Block_AI(1);
                                }
                            }
                            break;
                        case 2:
                            if (difficulty == 3)
                            {
                                // se bot jogou no meio
                                if (Equals(blocks[5], " O "))
                                {
                                    if (Equals(blocks[1], blocks[2]) && Equals(blocks[2], " X ") && Check_Tile_Availability(blocks[3])) // Para defesa
                                    {
                                        Change_Block_AI(3);
                                    }
                                    else if (Equals(blocks[2], blocks[3]) && Equals(blocks[2], " X ") && Check_Tile_Availability(blocks[1])) // Para defesa
                                    {
                                        Change_Block_AI(1);
                                    }
                                    else if (Equals(blocks[1], blocks[3]) && Equals(blocks[1], " X ") && Check_Tile_Availability(blocks[2])) // Para defesa
                                    {
                                        Change_Block_AI(2);
                                    }
                                    else if (Equals(blocks[5], blocks[2]) && Equals(blocks[2], " X ") && Check_Tile_Availability(blocks[8])) // Para defesa
                                    {
                                        Change_Block_AI(8);
                                    }
                                    else if (Equals(blocks[5], blocks[4]) && Equals(blocks[4], " X ") && Check_Tile_Availability(blocks[6])) // para defesa
                                    {
                                        Change_Block_AI(6);
                                    }
                                    else if (Equals(blocks[5], blocks[8]) && Equals(blocks[5], " X ") && Check_Tile_Availability(blocks[2])) // para defesa
                                    {
                                        Change_Block_AI(2);
                                    }
                                    else if (Equals(blocks[5], blocks[6]) && Equals(blocks[5], " X ") && Check_Tile_Availability(blocks[4])) // para defesa
                                    {
                                        Change_Block_AI(4);
                                    }
                                    else if (Equals(blocks[7], blocks[9]) && Equals(blocks[7], " X ") && Check_Tile_Availability(blocks[8])) // para defesa
                                    {
                                        Change_Block_AI(8);
                                    }
                                    else if (Equals(blocks[7], blocks[8]) && Equals(blocks[8], " X ") && Check_Tile_Availability(blocks[9])) // para defesa
                                    {
                                        Change_Block_AI(9);
                                    }
                                    else if (Equals(blocks[8], blocks[9]) && Equals(blocks[8], " X ") && Check_Tile_Availability(blocks[7])) // para defesa
                                    {
                                        Change_Block_AI(7);
                                    }
                                    else if (Equals(blocks[3], blocks[5]) && Equals(blocks[3], " X ") && Check_Tile_Availability(blocks[7])) // para defesa diagonal
                                    {
                                        Change_Block_AI(7);
                                    }
                                    else if (Equals(blocks[3], blocks[7]) && Equals(blocks[3], " X ") && Check_Tile_Availability(blocks[5])) // para defesa diagonal
                                    {
                                        Change_Block_AI(5);
                                    }
                                    else if (Equals(blocks[7], blocks[5]) && Equals(blocks[7], " X ") && Check_Tile_Availability(blocks[3])) // para defesa diagonal
                                    {
                                        Change_Block_AI(3);
                                    }
                                    else if (Equals(blocks[1], blocks[5]) && Equals(blocks[5], " X ") && Check_Tile_Availability(blocks[9])) // para defesa diagonal
                                    {
                                        Change_Block_AI(9);
                                    }
                                    else if (Equals(blocks[1], blocks[9]) && Equals(blocks[9], " X ") && Check_Tile_Availability(blocks[5])) // para defesa diagonal
                                    {
                                        Change_Block_AI(5);
                                    }
                                    else if (Equals(blocks[9], blocks[5]) && Equals(blocks[5], " X ") && Check_Tile_Availability(blocks[1])) // para defesa diagonal
                                    {
                                        Change_Block_AI(1);
                                    }
                                    else if (Equals(blocks[1], blocks[7]) && Equals(blocks[1], " X ") && Check_Tile_Availability(blocks[4])) // para defesa vertical
                                    {
                                        Change_Block_AI(4);
                                    }
                                    else if (Equals(blocks[1], blocks[4]) && Equals(blocks[1], " X ") && Check_Tile_Availability(blocks[7])) // para defesa vertical
                                    {
                                        Change_Block_AI(7);
                                    }
                                    else if (Equals(blocks[4], blocks[7]) && Equals(blocks[7], " X ") && Check_Tile_Availability(blocks[4])) // para defesa vertical
                                    {
                                        Change_Block_AI(4);
                                    }
                                    else if (Equals(blocks[3], blocks[9]) && Equals(blocks[3], " X ") && Check_Tile_Availability(blocks[6])) // para defesa vertical
                                    {
                                        Change_Block_AI(6);
                                    }
                                    else if (Equals(blocks[6], blocks[9]) && Equals(blocks[6], " X ") && Check_Tile_Availability(blocks[3])) // para defesa vertical
                                    {
                                        Change_Block_AI(3);
                                    }
                                    else if (Equals(blocks[3], blocks[6]) && Equals(blocks[3], " X ") && Check_Tile_Availability(blocks[9])) // para defesa vertical
                                    {
                                        Change_Block_AI(9);
                                    }
                                    //difficulty 3 ataque
                                    else if (Check_Tile_Availability(blocks[2]))
                                    {
                                        Change_Block_AI(2);
                                    }
                                    else if (Check_Tile_Availability(blocks[4]))
                                    {
                                        Change_Block_AI(4);
                                    }
                                    else if (Check_Tile_Availability(blocks[6]))
                                    {
                                        Change_Block_AI(6);
                                    }
                                    else if (Check_Tile_Availability(blocks[8]))
                                    {
                                        Change_Block_AI(8);
                                    }
                                }
                                else if (Equals(blocks[1], " O "))
                                {
                                    if (Equals(blocks[1], blocks[2]) && Equals(blocks[2], " X ") && Check_Tile_Availability(blocks[3])) // Para defesa
                                    {
                                        Change_Block_AI(3);
                                    }
                                    else if (Equals(blocks[2], blocks[3]) && Equals(blocks[2], " X ") && Check_Tile_Availability(blocks[1])) // Para defesa
                                    {
                                        Change_Block_AI(1);
                                    }
                                    else if (Equals(blocks[1], blocks[3]) && Equals(blocks[1], " X ") && Check_Tile_Availability(blocks[2])) // Para defesa
                                    {
                                        Change_Block_AI(2);
                                    }
                                    else if (Equals(blocks[5], blocks[2]) && Equals(blocks[2], " X ") && Check_Tile_Availability(blocks[8])) // Para defesa
                                    {
                                        Change_Block_AI(8);
                                    }
                                    else if (Equals(blocks[5], blocks[4]) && Equals(blocks[4], " X ") && Check_Tile_Availability(blocks[6])) // para defesa
                                    {
                                        Change_Block_AI(6);
                                    }
                                    else if (Equals(blocks[5], blocks[8]) && Equals(blocks[5], " X ") && Check_Tile_Availability(blocks[2])) // para defesa
                                    {
                                        Change_Block_AI(2);
                                    }
                                    else if (Equals(blocks[5], blocks[6]) && Equals(blocks[5], " X ") && Check_Tile_Availability(blocks[4])) // para defesa
                                    {
                                        Change_Block_AI(4);
                                    }
                                    else if (Equals(blocks[7], blocks[9]) && Equals(blocks[7], " X ") && Check_Tile_Availability(blocks[8])) // para defesa
                                    {
                                        Change_Block_AI(8);
                                    }
                                    else if (Equals(blocks[7], blocks[8]) && Equals(blocks[8], " X ") && Check_Tile_Availability(blocks[9])) // para defesa
                                    {
                                        Change_Block_AI(9);
                                    }
                                    else if (Equals(blocks[8], blocks[9]) && Equals(blocks[8], " X ") && Check_Tile_Availability(blocks[7])) // para defesa
                                    {
                                        Change_Block_AI(7);
                                    }
                                    else if (Equals(blocks[3], blocks[5]) && Equals(blocks[3], " X ") && Check_Tile_Availability(blocks[7])) // para defesa diagonal
                                    {
                                        Change_Block_AI(7);
                                    }
                                    else if (Equals(blocks[3], blocks[7]) && Equals(blocks[3], " X ") && Check_Tile_Availability(blocks[5])) // para defesa diagonal
                                    {
                                        Change_Block_AI(5);
                                    }
                                    else if (Equals(blocks[7], blocks[5]) && Equals(blocks[7], " X ") && Check_Tile_Availability(blocks[3])) // para defesa diagonal
                                    {
                                        Change_Block_AI(3);
                                    }
                                    else if (Equals(blocks[1], blocks[5]) && Equals(blocks[5], " X ") && Check_Tile_Availability(blocks[9])) // para defesa diagonal
                                    {
                                        Change_Block_AI(9);
                                    }
                                    else if (Equals(blocks[1], blocks[9]) && Equals(blocks[9], " X ") && Check_Tile_Availability(blocks[5])) // para defesa diagonal
                                    {
                                        Change_Block_AI(5);
                                    }
                                    else if (Equals(blocks[9], blocks[5]) && Equals(blocks[5], " X ") && Check_Tile_Availability(blocks[1])) // para defesa diagonal
                                    {
                                        Change_Block_AI(1);
                                    }
                                    else if (Equals(blocks[1], blocks[7]) && Equals(blocks[1], " X ") && Check_Tile_Availability(blocks[4])) // para defesa vertical
                                    {
                                        Change_Block_AI(4);
                                    }
                                    else if (Equals(blocks[1], blocks[4]) && Equals(blocks[1], " X ") && Check_Tile_Availability(blocks[7])) // para defesa vertical
                                    {
                                        Change_Block_AI(7);
                                    }
                                    else if (Equals(blocks[4], blocks[7]) && Equals(blocks[7], " X ") && Check_Tile_Availability(blocks[4])) // para defesa vertical
                                    {
                                        Change_Block_AI(4);
                                    }
                                    else if (Equals(blocks[3], blocks[9]) && Equals(blocks[3], " X ") && Check_Tile_Availability(blocks[6])) // para defesa vertical
                                    {
                                        Change_Block_AI(6);
                                    }
                                    else if (Equals(blocks[6], blocks[9]) && Equals(blocks[6], " X ") && Check_Tile_Availability(blocks[3])) // para defesa vertical
                                    {
                                        Change_Block_AI(3);
                                    }
                                    else if (Equals(blocks[3], blocks[6]) && Equals(blocks[3], " X ") && Check_Tile_Availability(blocks[9])) // para defesa vertical
                                    {
                                        Change_Block_AI(9);
                                    }
                                    //difficulty 3 ataque
                                    else if (Check_Tile_Availability(blocks[3]))
                                    {
                                        Change_Block_AI(3);
                                    }
                                    else if (Check_Tile_Availability(blocks[7]))
                                    {
                                        Change_Block_AI(7);
                                    }
                                    else if (Check_Tile_Availability(blocks[9]))
                                    {
                                        Change_Block_AI(9);
                                    }
                                }
                            }
                            if (difficulty == 2)
                            {
                                if (Equals(blocks[1], blocks[2]) && Equals(blocks[2], " X ") && Check_Tile_Availability(blocks[3])) // Para defesa
                                {
                                    Change_Block_AI(3);
                                }
                                else if (Equals(blocks[2], blocks[3]) && Equals(blocks[2], " X ") && Check_Tile_Availability(blocks[1])) // Para defesa
                                {
                                    Change_Block_AI(1);
                                }
                                else if (Equals(blocks[1], blocks[3]) && Equals(blocks[1], " X ") && Check_Tile_Availability(blocks[2])) // Para defesa
                                {
                                    Change_Block_AI(2);
                                }
                                else if (Equals(blocks[5], blocks[2]) && Equals(blocks[2], " X ") && Check_Tile_Availability(blocks[8])) // Para defesa
                                {
                                    Change_Block_AI(8);
                                }
                                else if (Equals(blocks[5], blocks[4]) && Equals(blocks[4], " X ") && Check_Tile_Availability(blocks[6])) // para defesa
                                {
                                    Change_Block_AI(6);
                                }
                                else if (Equals(blocks[5], blocks[8]) && Equals(blocks[5], " X ") && Check_Tile_Availability(blocks[2])) // para defesa
                                {
                                    Change_Block_AI(2);
                                }
                                else if (Equals(blocks[5], blocks[6]) && Equals(blocks[5], " X ") && Check_Tile_Availability(blocks[4])) // para defesa
                                {
                                    Change_Block_AI(4);
                                }
                                else if (Equals(blocks[7], blocks[9]) && Equals(blocks[7], " X ") && Check_Tile_Availability(blocks[8])) // para defesa
                                {
                                    Change_Block_AI(8);
                                }
                                else if (Equals(blocks[7], blocks[8]) && Equals(blocks[8], " X ") && Check_Tile_Availability(blocks[9])) // para defesa
                                {
                                    Change_Block_AI(9);
                                }
                                else if (Equals(blocks[8], blocks[9]) && Equals(blocks[8], " X ") && Check_Tile_Availability(blocks[7])) // para defesa
                                {
                                    Change_Block_AI(7);
                                }
                                else if (Equals(blocks[3], blocks[5]) && Equals(blocks[3], " X ") && Check_Tile_Availability(blocks[7])) // para defesa diagonal
                                {
                                    Change_Block_AI(7);
                                }
                                else if (Equals(blocks[3], blocks[7]) && Equals(blocks[3], " X ") && Check_Tile_Availability(blocks[5])) // para defesa diagonal
                                {
                                    Change_Block_AI(5);
                                }
                                else if (Equals(blocks[7], blocks[5]) && Equals(blocks[7], " X ") && Check_Tile_Availability(blocks[3])) // para defesa diagonal
                                {
                                    Change_Block_AI(3);
                                }
                                else if (Equals(blocks[1], blocks[5]) && Equals(blocks[5], " X ") && Check_Tile_Availability(blocks[9])) // para defesa diagonal
                                {
                                    Change_Block_AI(9);
                                }
                                else if (Equals(blocks[1], blocks[9]) && Equals(blocks[9], " X ") && Check_Tile_Availability(blocks[5])) // para defesa diagonal
                                {
                                    Change_Block_AI(5);
                                }
                                else if (Equals(blocks[9], blocks[5]) && Equals(blocks[5], " X ") && Check_Tile_Availability(blocks[1])) // para defesa diagonal
                                {
                                    Change_Block_AI(1);
                                }
                                else if (Equals(blocks[1], blocks[7]) && Equals(blocks[1], " X ") && Check_Tile_Availability(blocks[4])) // para defesa vertical
                                {
                                    Change_Block_AI(4);
                                }
                                else if (Equals(blocks[1], blocks[4]) && Equals(blocks[1], " X ") && Check_Tile_Availability(blocks[7])) // para defesa vertical
                                {
                                    Change_Block_AI(7);
                                }
                                else if (Equals(blocks[4], blocks[7]) && Equals(blocks[7], " X ") && Check_Tile_Availability(blocks[4])) // para defesa vertical
                                {
                                    Change_Block_AI(4);
                                }
                                else if (Equals(blocks[6], blocks[9]) && Equals(blocks[6], " X ") && Check_Tile_Availability(blocks[3])) // para defesa vertical
                                {
                                    Change_Block_AI(3);
                                }
                                else if (Equals(blocks[3], blocks[6]) && Equals(blocks[3], " X ") && Check_Tile_Availability(blocks[9])) // para defesa vertical
                                {
                                    Change_Block_AI(9);
                                }
                                else if (Check_Tile_Availability(blocks[1]))
                                {
                                    Change_Block_AI(1);
                                }
                                else if (Check_Tile_Availability(blocks[3]))
                                {
                                    Change_Block_AI(3);
                                }
                                else if (Check_Tile_Availability(blocks[7]))
                                {
                                    Change_Block_AI(7);
                                }
                                else if (Check_Tile_Availability(blocks[5]))
                                {
                                    Change_Block_AI(5);
                                }
                                else
                                {
                                    Play_Random_Move();
                                }

                            }
                            break;
                        case 3:

                            // Dar prioridade a ganhar o jogo do que defender.
                            if (difficulty == 2)
                            {
                                if (Equals(blocks[3], blocks[9]) && Equals(blocks[3], " O ") && Check_Tile_Availability(blocks[6]))
                                {
                                    Change_Block_AI(6);
                                }
                                else if (Equals(blocks[1], blocks[3]) && Equals(blocks[1], " O ") && Check_Tile_Availability(blocks[2]))
                                {
                                    Change_Block_AI(2);
                                }
                                else if (Equals(blocks[1], blocks[4]) && Equals(blocks[1], " O ") && Check_Tile_Availability(blocks[7]))
                                {
                                    Change_Block_AI(7);
                                }
                                else if (Equals(blocks[3], blocks[6]) && Equals(blocks[3], " O ") && Check_Tile_Availability(blocks[9]))
                                {
                                    Change_Block_AI(9);
                                }
                                else if (Equals(blocks[3], blocks[7]) && Equals(blocks[3], " O ") && Check_Tile_Availability(blocks[5]))
                                {
                                    Change_Block_AI(5);
                                }
                                else if (Equals(blocks[1], blocks[7]) && Equals(blocks[1], " O ") && Check_Tile_Availability(blocks[4]))
                                {
                                    Change_Block_AI(4);
                                }
                                else if (Equals(blocks[1], blocks[5]) && Equals(blocks[1], " O ") && Check_Tile_Availability(blocks[9]))
                                {
                                    Change_Block_AI(9);
                                }
                                else if (Equals(blocks[3], blocks[5]) && Equals(blocks[3], " O ") && Check_Tile_Availability(blocks[7]))
                                {
                                    Change_Block_AI(7);
                                }
                                else if (Equals(blocks[1], blocks[2]) && Equals(blocks[2], " X ") && Check_Tile_Availability(blocks[3])) // Para defesa
                                {
                                    Change_Block_AI(3);
                                }
                                else if (Equals(blocks[2], blocks[3]) && Equals(blocks[2], " X ") && Check_Tile_Availability(blocks[1])) // Para defesa
                                {
                                    Change_Block_AI(1);
                                }
                                else if (Equals(blocks[1], blocks[3]) && Equals(blocks[1], " X ") && Check_Tile_Availability(blocks[2])) // Para defesa
                                {
                                    Change_Block_AI(2);
                                }
                                else if (Equals(blocks[5], blocks[2]) && Equals(blocks[2], " X ") && Check_Tile_Availability(blocks[8])) // Para defesa
                                {
                                    Change_Block_AI(8);
                                }
                                else if (Equals(blocks[5], blocks[4]) && Equals(blocks[4], " X ") && Check_Tile_Availability(blocks[6])) // para defesa
                                {
                                    Change_Block_AI(6);
                                }
                                else if (Equals(blocks[5], blocks[8]) && Equals(blocks[5], " X ") && Check_Tile_Availability(blocks[2])) // para defesa
                                {
                                    Change_Block_AI(2);
                                }
                                else if (Equals(blocks[5], blocks[6]) && Equals(blocks[5], " X ") && Check_Tile_Availability(blocks[4])) // para defesa
                                {
                                    Change_Block_AI(4);
                                }
                                else if (Equals(blocks[7], blocks[9]) && Equals(blocks[7], " X ") && Check_Tile_Availability(blocks[8])) // para defesa
                                {
                                    Change_Block_AI(8);
                                }
                                else if (Equals(blocks[7], blocks[8]) && Equals(blocks[8], " X ") && Check_Tile_Availability(blocks[9])) // para defesa
                                {
                                    Change_Block_AI(9);
                                }
                                else if (Equals(blocks[8], blocks[9]) && Equals(blocks[8], " X ") && Check_Tile_Availability(blocks[7])) // para defesa
                                {
                                    Change_Block_AI(7);
                                }
                                else if (Equals(blocks[3], blocks[5]) && Equals(blocks[3], " X ") && Check_Tile_Availability(blocks[7])) // para defesa diagonal
                                {
                                    Change_Block_AI(7);
                                }
                                else if (Equals(blocks[3], blocks[7]) && Equals(blocks[3], " X ") && Check_Tile_Availability(blocks[5])) // para defesa diagonal
                                {
                                    Change_Block_AI(5);
                                }
                                else if (Equals(blocks[7], blocks[5]) && Equals(blocks[7], " X ") && Check_Tile_Availability(blocks[3])) // para defesa diagonal
                                {
                                    Change_Block_AI(3);
                                }
                                else if (Equals(blocks[1], blocks[5]) && Equals(blocks[5], " X ") && Check_Tile_Availability(blocks[9])) // para defesa diagonal
                                {
                                    Change_Block_AI(9);
                                }
                                else if (Equals(blocks[1], blocks[9]) && Equals(blocks[9], " X ") && Check_Tile_Availability(blocks[5])) // para defesa diagonal
                                {
                                    Change_Block_AI(5);
                                }
                                else if (Equals(blocks[9], blocks[5]) && Equals(blocks[5], " X ") && Check_Tile_Availability(blocks[1])) // para defesa diagonal
                                {
                                    Change_Block_AI(1);
                                }
                                else if (Equals(blocks[1], blocks[7]) && Equals(blocks[1], " X ") && Check_Tile_Availability(blocks[4])) // para defesa vertical
                                {
                                    Change_Block_AI(4);
                                }
                                else if (Equals(blocks[1], blocks[4]) && Equals(blocks[1], " X ") && Check_Tile_Availability(blocks[7])) // para defesa vertical
                                {
                                    Change_Block_AI(7);
                                }
                                else if (Equals(blocks[4], blocks[7]) && Equals(blocks[7], " X ") && Check_Tile_Availability(blocks[4])) // para defesa vertical
                                {
                                    Change_Block_AI(4);
                                }
                                else if (Equals(blocks[3], blocks[9]) && Equals(blocks[3], " X ") && Check_Tile_Availability(blocks[6])) // para defesa vertical
                                {
                                    Change_Block_AI(6);
                                }
                                else if (Equals(blocks[6], blocks[9]) && Equals(blocks[6], " X ") && Check_Tile_Availability(blocks[3])) // para defesa vertical
                                {
                                    Change_Block_AI(3);
                                }
                                else if (Equals(blocks[3], blocks[6]) && Equals(blocks[3], " X ") && Check_Tile_Availability(blocks[9])) // para defesa vertical
                                {
                                    Change_Block_AI(9);
                                }
                                else if (Check_Tile_Availability(blocks[1]))
                                {
                                    Change_Block_AI(1);
                                }
                                else if (Check_Tile_Availability(blocks[3]))
                                {
                                    Change_Block_AI(3);
                                }
                                else if (Check_Tile_Availability(blocks[7]))
                                {
                                    Change_Block_AI(7);
                                }
                                else if (Check_Tile_Availability(blocks[5]))
                                {
                                    Change_Block_AI(5);
                                }
                                else if (Check_Tile_Availability(blocks[9]))
                                {
                                    Change_Block_AI(9);
                                }
                                else
                                {
                                    Play_Random_Move();
                                }
                            }
                            if (difficulty == 3)
                            {
                                //ataque caso 3
                                if (Equals(blocks[3], blocks[9]) && Equals(blocks[3], " O ") && Check_Tile_Availability(blocks[6]))
                                {
                                    Change_Block_AI(6);
                                }
                                else if (Equals(blocks[1], blocks[3]) && Equals(blocks[1], " O ") && Check_Tile_Availability(blocks[2]))
                                {
                                    Change_Block_AI(2);
                                }
                                else if (Equals(blocks[1], blocks[4]) && Equals(blocks[1], " O ") && Check_Tile_Availability(blocks[7]))
                                {
                                    Change_Block_AI(7);
                                }
                                else if (Equals(blocks[3], blocks[6]) && Equals(blocks[3], " O ") && Check_Tile_Availability(blocks[9]))
                                {
                                    Change_Block_AI(9);
                                }
                                else if (Equals(blocks[3], blocks[7]) && Equals(blocks[3], " O ") && Check_Tile_Availability(blocks[5]))
                                {
                                    Change_Block_AI(5);
                                }
                                else if (Equals(blocks[1], blocks[7]) && Equals(blocks[1], " O ") && Check_Tile_Availability(blocks[4]))
                                {
                                    Change_Block_AI(4);
                                }
                                else if (Equals(blocks[1], blocks[5]) && Equals(blocks[1], " O ") && Check_Tile_Availability(blocks[9]))
                                {
                                    Change_Block_AI(9);
                                }
                                else if (Equals(blocks[3], blocks[5]) && Equals(blocks[3], " O ") && Check_Tile_Availability(blocks[7]))
                                {
                                    Change_Block_AI(7);
                                }
                                //horizontal meio
                                else if (Equals(blocks[2], blocks[8]) && Equals(blocks[2], " O ") && Check_Tile_Availability(blocks[5]))
                                {
                                    Change_Block_AI(5);
                                }
                                else if (Equals(blocks[4], blocks[5]) && Equals(blocks[4], " O ") && Check_Tile_Availability(blocks[6]))
                                {
                                    Change_Block_AI(6);
                                }
                                else if (Equals(blocks[4], blocks[6]) && Equals(blocks[4], " O ") && Check_Tile_Availability(blocks[5]))
                                {
                                    Change_Block_AI(5);
                                }
                                //vertical meio
                                else if (Equals(blocks[5], blocks[6]) && Equals(blocks[6], " O ") && Check_Tile_Availability(blocks[4]))
                                {
                                    Change_Block_AI(4);
                                }
                                else if (Equals(blocks[2], blocks[5]) && Equals(blocks[2], " O ") && Check_Tile_Availability(blocks[8]))
                                {
                                    Change_Block_AI(8);
                                }
                                else if (Equals(blocks[8], blocks[5]) && Equals(blocks[5], " O ") && Check_Tile_Availability(blocks[2]))
                                {
                                    Change_Block_AI(2);
                                }
                                //ataque 
                                else if (Equals(blocks[3], blocks[9]) && Equals(blocks[3], " O ") && Check_Tile_Availability(blocks[6]))
                                {
                                    Change_Block_AI(6);
                                }
                                else if (Equals(blocks[1], blocks[3]) && Equals(blocks[1], " O ") && Check_Tile_Availability(blocks[2]))
                                {
                                    Change_Block_AI(2);
                                }
                                else if (Equals(blocks[1], blocks[4]) && Equals(blocks[1], " O ") && Check_Tile_Availability(blocks[7]))
                                {
                                    Change_Block_AI(7);
                                }
                                else if (Equals(blocks[3], blocks[6]) && Equals(blocks[3], " O ") && Check_Tile_Availability(blocks[9]))
                                {
                                    Change_Block_AI(9);
                                }
                                else if (Equals(blocks[3], blocks[7]) && Equals(blocks[3], " O ") && Check_Tile_Availability(blocks[5]))
                                {
                                    Change_Block_AI(5);
                                }
                                else if (Equals(blocks[1], blocks[7]) && Equals(blocks[1], " O ") && Check_Tile_Availability(blocks[4]))
                                {
                                    Change_Block_AI(4);
                                }
                                else if (Equals(blocks[1], blocks[5]) && Equals(blocks[1], " O ") && Check_Tile_Availability(blocks[9]))
                                {
                                    Change_Block_AI(9);
                                }
                                else if (Equals(blocks[3], blocks[5]) && Equals(blocks[3], " O ") && Check_Tile_Availability(blocks[7]))
                                {
                                    Change_Block_AI(7);
                                }
                                //defesa caso 3
                                else if (Equals(blocks[5], blocks[2]) && Equals(blocks[2], " X ") && Check_Tile_Availability(blocks[8])) // Para defesa
                                {
                                    Change_Block_AI(8);
                                }
                                else if (Equals(blocks[1], blocks[2]) && Equals(blocks[2], " X ") && Check_Tile_Availability(blocks[3])) // Para defesa
                                {
                                    Change_Block_AI(3);
                                }
                                else if (Equals(blocks[2], blocks[3]) && Equals(blocks[2], " X ") && Check_Tile_Availability(blocks[1])) // Para defesa
                                {
                                    Change_Block_AI(1);
                                }
                                else if (Equals(blocks[1], blocks[3]) && Equals(blocks[1], " X ") && Check_Tile_Availability(blocks[2])) // Para defesa
                                {
                                    Change_Block_AI(2);
                                }
                                else if (Equals(blocks[5], blocks[4]) && Equals(blocks[4], " X ") && Check_Tile_Availability(blocks[6])) // para defesa
                                {
                                    Change_Block_AI(6);
                                }
                                else if (Equals(blocks[5], blocks[8]) && Equals(blocks[5], " X ") && Check_Tile_Availability(blocks[2])) // para defesa
                                {
                                    Change_Block_AI(2);
                                }
                                else if (Equals(blocks[5], blocks[6]) && Equals(blocks[5], " X ") && Check_Tile_Availability(blocks[4])) // para defesa
                                {
                                    Change_Block_AI(4);
                                }
                                else if (Equals(blocks[7], blocks[9]) && Equals(blocks[7], " X ") && Check_Tile_Availability(blocks[8])) // para defesa
                                {
                                    Change_Block_AI(8);
                                }
                                else if (Equals(blocks[7], blocks[8]) && Equals(blocks[8], " X ") && Check_Tile_Availability(blocks[9])) // para defesa
                                {
                                    Change_Block_AI(9);
                                }
                                else if (Equals(blocks[8], blocks[9]) && Equals(blocks[8], " X ") && Check_Tile_Availability(blocks[7])) // para defesa
                                {
                                    Change_Block_AI(7);
                                }
                                else if (Equals(blocks[3], blocks[5]) && Equals(blocks[3], " X ") && Check_Tile_Availability(blocks[7])) // para defesa diagonal
                                {
                                    Change_Block_AI(7);
                                }
                                else if (Equals(blocks[3], blocks[7]) && Equals(blocks[3], " X ") && Check_Tile_Availability(blocks[5])) // para defesa diagonal
                                {
                                    Change_Block_AI(5);
                                }
                                else if (Equals(blocks[7], blocks[5]) && Equals(blocks[7], " X ") && Check_Tile_Availability(blocks[3])) // para defesa diagonal
                                {
                                    Change_Block_AI(3);
                                }
                                else if (Equals(blocks[1], blocks[5]) && Equals(blocks[5], " X ") && Check_Tile_Availability(blocks[9])) // para defesa diagonal
                                {
                                    Change_Block_AI(9);
                                }
                                else if (Equals(blocks[1], blocks[9]) && Equals(blocks[9], " X ") && Check_Tile_Availability(blocks[5])) // para defesa diagonal
                                {
                                    Change_Block_AI(5);
                                }
                                else if (Equals(blocks[9], blocks[5]) && Equals(blocks[5], " X ") && Check_Tile_Availability(blocks[1])) // para defesa diagonal
                                {
                                    Change_Block_AI(1);
                                }
                                else if (Equals(blocks[1], blocks[7]) && Equals(blocks[1], " X ") && Check_Tile_Availability(blocks[4])) // para defesa vertical
                                {
                                    Change_Block_AI(4);
                                }
                                else if (Equals(blocks[1], blocks[4]) && Equals(blocks[1], " X ") && Check_Tile_Availability(blocks[7])) // para defesa vertical
                                {
                                    Change_Block_AI(7);
                                }
                                else if (Equals(blocks[4], blocks[7]) && Equals(blocks[7], " X ") && Check_Tile_Availability(blocks[4])) // para defesa vertical
                                {
                                    Change_Block_AI(4);
                                }
                                else if (Equals(blocks[3], blocks[9]) && Equals(blocks[3], " X ") && Check_Tile_Availability(blocks[6])) // para defesa vertical
                                {
                                    Change_Block_AI(6);
                                }
                                else if (Equals(blocks[6], blocks[9]) && Equals(blocks[6], " X ") && Check_Tile_Availability(blocks[3])) // para defesa vertical
                                {
                                    Change_Block_AI(3);
                                }
                                else if (Equals(blocks[3], blocks[6]) && Equals(blocks[3], " X ") && Check_Tile_Availability(blocks[9])) // para defesa vertical
                                {
                                    Change_Block_AI(9);
                                }
                                //ataque normal 
                                else if (Check_Tile_Availability(blocks[2]) && Equals(blocks[5], " O "))
                                {
                                    Change_Block_AI(2);
                                }
                                else if (Check_Tile_Availability(blocks[4]) && Equals(blocks[5], " O "))
                                {
                                    Change_Block_AI(4);
                                }
                                else if (Check_Tile_Availability(blocks[6]) && Equals(blocks[5], " O "))
                                {
                                    Change_Block_AI(6);
                                }
                                else if (Check_Tile_Availability(blocks[8]) && Equals(blocks[5], " O "))
                                {
                                    Change_Block_AI(8);
                                }
                                else if (Check_Tile_Availability(blocks[3]) && Equals(blocks[5], " O "))
                                {
                                    Change_Block_AI(3);
                                }
                                else if (Check_Tile_Availability(blocks[7]) && Equals(blocks[5], " O "))
                                {
                                    Change_Block_AI(7);
                                }
                                else if (Check_Tile_Availability(blocks[9]) && Equals(blocks[5], " O "))
                                {
                                    Change_Block_AI(9);
                                }
                            }
                            break;
                        case 4:
                            if (Equals(blocks[3], blocks[9]) && Equals(blocks[3], " O ") && Check_Tile_Availability(blocks[6]))
                            {
                                Change_Block_AI(6);
                            }
                            else if (Equals(blocks[1], blocks[3]) && Equals(blocks[1], " O ") && Check_Tile_Availability(blocks[2]))
                            {
                                Change_Block_AI(2);
                            }
                            else if (Equals(blocks[3], blocks[7]) && Equals(blocks[3], " O ") && Check_Tile_Availability(blocks[5]))
                            {
                                Change_Block_AI(5);
                            }
                            else if (Equals(blocks[1], blocks[7]) && Equals(blocks[1], " O ") && Check_Tile_Availability(blocks[4]))
                            {
                                Change_Block_AI(4);
                            }
                            else if (Equals(blocks[1], blocks[5]) && Equals(blocks[1], " O ") && Check_Tile_Availability(blocks[9]))
                            {
                                Change_Block_AI(9);
                            }
                            else if (Equals(blocks[3], blocks[5]) && Equals(blocks[3], " O ") && Check_Tile_Availability(blocks[7]))
                            {
                                Change_Block_AI(7);
                            }
                            else if (Equals(blocks[7], blocks[5]) && Equals(blocks[7], " O ") && Check_Tile_Availability(blocks[3]))
                            {
                                Change_Block_AI(3);
                            }
                            else if (Equals(blocks[3], blocks[9]) && Equals(blocks[3], " O ") && Check_Tile_Availability(blocks[6]))
                            {
                                Change_Block_AI(6);
                            }
                            else if (Equals(blocks[1], blocks[2]) && Equals(blocks[2], " X ") && Check_Tile_Availability(blocks[3])) // Para defesa
                            {
                                Change_Block_AI(3);
                            }
                            else if (Equals(blocks[2], blocks[3]) && Equals(blocks[2], " X ") && Check_Tile_Availability(blocks[1])) // Para defesa
                            {
                                Change_Block_AI(1);
                            }
                            else if (Equals(blocks[1], blocks[3]) && Equals(blocks[1], " X ") && Check_Tile_Availability(blocks[2])) // Para defesa
                            {
                                Change_Block_AI(2);
                            }
                            else if (Equals(blocks[5], blocks[2]) && Equals(blocks[2], " X ") && Check_Tile_Availability(blocks[8])) // Para defesa
                            {
                                Change_Block_AI(8);
                            }
                            else if (Equals(blocks[5], blocks[4]) && Equals(blocks[4], " X ") && Check_Tile_Availability(blocks[6])) // para defesa
                            {
                                Change_Block_AI(6);
                            }
                            else if (Equals(blocks[5], blocks[8]) && Equals(blocks[5], " X ") && Check_Tile_Availability(blocks[2])) // para defesa
                            {
                                Change_Block_AI(2);
                            }
                            else if (Equals(blocks[5], blocks[6]) && Equals(blocks[5], " X ") && Check_Tile_Availability(blocks[4])) // para defesa
                            {
                                Change_Block_AI(4);
                            }
                            else if (Equals(blocks[7], blocks[9]) && Equals(blocks[7], " X ") && Check_Tile_Availability(blocks[8])) // para defesa
                            {
                                Change_Block_AI(8);
                            }
                            else if (Equals(blocks[7], blocks[8]) && Equals(blocks[8], " X ") && Check_Tile_Availability(blocks[9])) // para defesa
                            {
                                Change_Block_AI(9);
                            }
                            else if (Equals(blocks[8], blocks[9]) && Equals(blocks[8], " X ") && Check_Tile_Availability(blocks[7])) // para defesa
                            {
                                Change_Block_AI(7);
                            }
                            else if (Equals(blocks[3], blocks[5]) && Equals(blocks[3], " X ") && Check_Tile_Availability(blocks[7])) // para defesa diagonal
                            {
                                Change_Block_AI(7);
                            }
                            else if (Equals(blocks[3], blocks[7]) && Equals(blocks[3], " X ") && Check_Tile_Availability(blocks[5])) // para defesa diagonal
                            {
                                Change_Block_AI(5);
                            }
                            else if (Equals(blocks[7], blocks[5]) && Equals(blocks[7], " X ") && Check_Tile_Availability(blocks[3])) // para defesa diagonal
                            {
                                Change_Block_AI(3);
                            }
                            else if (Equals(blocks[1], blocks[5]) && Equals(blocks[5], " X ") && Check_Tile_Availability(blocks[9])) // para defesa diagonal
                            {
                                Change_Block_AI(9);
                            }
                            else if (Equals(blocks[1], blocks[9]) && Equals(blocks[9], " X ") && Check_Tile_Availability(blocks[5])) // para defesa diagonal
                            {
                                Change_Block_AI(5);
                            }
                            else if (Equals(blocks[9], blocks[5]) && Equals(blocks[5], " X ") && Check_Tile_Availability(blocks[1])) // para defesa diagonal
                            {
                                Change_Block_AI(1);
                            }
                            else if (Equals(blocks[1], blocks[7]) && Equals(blocks[1], " X ") && Check_Tile_Availability(blocks[4])) // para defesa vertical
                            {
                                Change_Block_AI(4);
                            }
                            else if (Equals(blocks[1], blocks[4]) && Equals(blocks[1], " X ") && Check_Tile_Availability(blocks[7])) // para defesa vertical
                            {
                                Change_Block_AI(7);
                            }
                            else if (Equals(blocks[4], blocks[7]) && Equals(blocks[7], " X ") && Check_Tile_Availability(blocks[4])) // para defesa vertical
                            {
                                Change_Block_AI(4);
                            }
                            else if (Equals(blocks[3], blocks[9]) && Equals(blocks[3], " X ") && Check_Tile_Availability(blocks[6])) // para defesa vertical
                            {
                                Change_Block_AI(6);
                            }
                            else if (Equals(blocks[6], blocks[9]) && Equals(blocks[6], " X ") && Check_Tile_Availability(blocks[3])) // para defesa vertical
                            {
                                Change_Block_AI(3);
                            }
                            else if (Equals(blocks[3], blocks[6]) && Equals(blocks[3], " X ") && Check_Tile_Availability(blocks[9])) // para defesa vertical
                            {
                                Change_Block_AI(9);
                            }
                            else if (Check_Tile_Availability(blocks[1]))
                            {
                                Change_Block_AI(1);
                            }
                            else if (Check_Tile_Availability(blocks[3]))
                            {
                                Change_Block_AI(3);
                            }
                            else if (Check_Tile_Availability(blocks[7]))
                            {
                                Change_Block_AI(7);
                            }
                            else
                            {
                                Play_Random_Move();
                            }
                            break;
                        default:
                            Play_Random_Move();
                            break;
                    }
                }
                void Play_Random_Move()
                {
                    bool ai_played = false;
                    while (ai_played == false)
                    {
                        int move_ai = rnd.Next(1, 10); // Vai escolher ao acaso uma das casas, e se estiver livre vai jogar lá, porque se não vai escolher de novo.

                        if (Check_Tile_Availability(blocks[move_ai]))
                        {
                            Change_Block_AI(move_ai);
                            ai_played = true;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                if (difficulty == 1)
                {
                    Play_Random_Move();
                }
                else if (difficulty == 2)
                {
                    Play_Normal_Move();
                }
                else if (difficulty == 3)
                {
                    Play_Normal_Move();
                }
            }

            bool Check_Tie() // tenho que meter o empate separado da função abaixo porque não consegui incluir este código dentro dessa função sem bugar o programa.
            {
                bool isTie = false;

                // !(String.Equals(Check_Tile_Availability(blocks[1]), "  ") && String.Equals(Check_Tile_Availability(blocks[2]), "   ") && String.Equals(Check_Tile_Availability(blocks[3]), "   ") && String.Equals(Check_Tile_Availability(blocks[4]), "   ") && String.Equals(Check_Tile_Availability(blocks[5]), "   ") && String.Equals(Check_Tile_Availability(blocks[6]), "   ") && String.Equals(Check_Tile_Availability(blocks[7]), "   ") && String.Equals(Check_Tile_Availability(blocks[8]), "   ") && String.Equals(Check_Tile_Availability(blocks[9]), "   "))
                // tava a tentar fazer isto em cima xD
                if (!(String.Equals(blocks[1], "   ")) && !(String.Equals(blocks[2], "   ")) && !(String.Equals(blocks[3], "   ")) && !(String.Equals(blocks[4], "   ")) && !(String.Equals(blocks[5], "   ")) && !(String.Equals(blocks[6], "   ")) && !(String.Equals(blocks[7], "   ")) && !(String.Equals(blocks[8], "   ")) && !(String.Equals(blocks[9], "   ")))
                {
                    if (result == 0)
                    {
                        isTie = true;
                    }
                    else
                    {
                        isTie = false;
                    }
                }
                else
                {
                    isTie = false;
                }
                if (isTie)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            int IsLine(int index0, int index1, int index2, String piece, String piece2)
            {
                if (Equals(blocks[index0], piece) && Equals(blocks[index1], piece) && Equals(blocks[index2], piece))
                {
                    return 1;
                }
                else if (Equals(blocks[index0], piece2) && Equals(blocks[index1], piece2) && Equals(blocks[index2], piece2))
                {
                    return 2;
                }
                else
                {
                    return 0;
                }
            }

            int IsAnyLine(int index0, int index1, int index2)
            {
                return IsLine(index0, index1, index2, " X ", " O ");
            }

            int Check_Victory() // Para ver se ganhamos ou não
            {
                if (IsAnyLine(1, 2, 3) == 1 || IsAnyLine(4, 5, 6) == 1 || IsAnyLine(7, 8, 9) == 1 || IsAnyLine(1, 5, 9) == 1 || IsAnyLine(7, 5, 3) == 1 || IsAnyLine(1, 4, 7) == 1 || IsAnyLine(2, 5, 8) == 1 || IsAnyLine(3, 6, 9) == 1)
                {
                    return 1;
                }
                else if (IsAnyLine(1, 2, 3) == 2 || IsAnyLine(4, 5, 6) == 2 || IsAnyLine(7, 8, 9) == 2 || IsAnyLine(1, 5, 9) == 2 || IsAnyLine(7, 5, 3) == 2 || IsAnyLine(1, 4, 7) == 2 || IsAnyLine(2, 5, 8) == 2 || IsAnyLine(3, 6, 9) == 2)
                {
                    return 2;
                }
                else
                {
                    return 0;
                }

            }

            while (true) // O game loop
            {
                if (beginning == true)
                {
                    Console.Write("Enter in your name: ");
                    player_name = Console.ReadLine();
                    Console.Clear(); // para apagar o que está na consola.
                    Console.WriteLine("Hello {0}!", player_name);
                    Console.WriteLine("Press Enter or anything to begin.");
                    Console.ReadLine();
                    Console.Clear();
                    beginning = false;
                }

                // mudar a variável "result" de acordo com o resultado do jogo
                cnt += 1;
                void Update_Victory()
                {
                    if (Check_Victory() == 1)
                    {
                        result = 1;
                    }
                    if (Check_Victory() == 2)
                    {
                        result = 2;
                    }
                    Check_Tie();
                    if (Check_Tie())
                    {
                        result = 3;
                    }
                }

                Console.WriteLine();
                Map();
                Player_Move();
                // Ver se ganhaste o jogo, e se sim sair do loop.
                Update_Victory();
                if (result == 1)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Map();
                    Console.WriteLine("\nYou Won!");
                    p_points += 1;
                    ScoreUI();
                    break;
                }
                if (result == 2)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Map();
                    Console.WriteLine("\nYou Lost!");
                    ai_points += 1;
                    ScoreUI();
                    break;
                }
                if (result == 3)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Map();
                    Console.WriteLine("\nIt's a draw!");
                    ScoreUI();
                    break;
                }

                // simular pensamento se a variável time for verdadeira.
                if (time == true)
                {
                    Console.Write("\nThinking");
                    Random rnd = new Random();
                    int ai_time = rnd.Next(300, 600);
                    System.Threading.Thread.Sleep(ai_time);
                    Console.Write(".");
                    System.Threading.Thread.Sleep(ai_time);
                    Console.Write(".");
                    System.Threading.Thread.Sleep(ai_time);
                    Console.Write(".\n");
                    System.Threading.Thread.Sleep(250);
                }
                if (sounds == true) // se os sons estiverem ligados então vai fazer este som antes de jogar.
                {
                    Console.Beep(3000, 350); // frequência de 3000Hz (???) e uma duração de 350 ms (0,35s)
                }

                AI_Move();

                // Ver se perdeste o jogo, e se sim sair do loop.
                Update_Victory();
                if (result == 1)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Map();
                    Console.WriteLine("\nYou Won!");
                    p_points += 1;
                    ScoreUI();
                    break;
                }
                if (result == 2)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Map();
                    Console.WriteLine("\nYou Lost!");
                    ai_points += 1;
                    ScoreUI();
                    break;
                }
                if (result == 3)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Map();
                    Console.WriteLine("\nIt's a draw! No one won points.");
                    ScoreUI();
                    break;
                }

                Console.Clear();
            }

            Repeat_Text();
            String repeat = Console.ReadLine();
            Console.Clear();
            if (repeat == "")
            {
                Console.WriteLine();
                Game();
            }
            else
            {
                Main();
            }
        }
    }
}

