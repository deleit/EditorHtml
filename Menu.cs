using System;

namespace EditorHtml
{
    public static class Menu
    {
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;

            DrawScreen(30, 10);
            WriteOptions();

            var option = short.Parse(Console.ReadLine());
            HandleMenuOption(option);
        }

        public static void DrawScreen(int numberOfColumns, int numberOfLines)
        {
            DrawLines(numberOfColumns);
            DrawColumns(numberOfColumns, numberOfLines);
            DrawLines(numberOfColumns);

            static void DrawLines(int numberOfColumns)
            {
                Console.Write("+");
                for (int i = 0; i <= numberOfColumns; i++)
                    Console.Write("-");
                Console.Write("+");
                Console.Write("\n");
            }

            static void DrawColumns(int numberOfColumns, int numberOfLines)
            {
                for (int lines = 0; lines <= numberOfLines; lines++)
                {
                    Console.Write("|");
                    for (int columns = 0; columns <= numberOfColumns; columns++)
                        Console.Write(" ");

                    Console.Write("|");
                    Console.Write("\n");
                }
            }
        }

        public static void WriteOptions()
        {
            Console.SetCursorPosition(3, 2);
            Console.WriteLine("Editor HTML");
            Console.SetCursorPosition(3, 3);
            Console.WriteLine("===========");
            Console.SetCursorPosition(3, 4);
            Console.WriteLine("Slecione uma opção abaixo:");
            Console.SetCursorPosition(3, 6);
            Console.WriteLine("1 - Novo arquivo");
            Console.SetCursorPosition(3, 7);
            Console.WriteLine("2 - Abrir");
            Console.SetCursorPosition(3, 8);
            Console.WriteLine("0 - Sair");
            Console.SetCursorPosition(3, 10);
            Console.Write("Opção: ");
        }

        public static void HandleMenuOption(short option)
        {
            switch (option)
            {
                case 1: Editor.Show(); break;
                case 2: Viewer.Show(); break;
                case 0:
                    {
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    }
                default: Show(); break;
            }
        }
    }
}