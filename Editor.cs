using System;
using System.IO;
using System.Text;

namespace EditorHtml
{
    public static class Editor
    {
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("Modo editor - Pressione ESC para sair");
            Console.WriteLine("-------------");
            Start();
        }

        public static void Start()
        {
            var file = new StringBuilder();

            do
            {
                file.Append(Console.ReadLine());
                file.Append(Environment.NewLine);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            Console.WriteLine("-------------");
            Console.WriteLine(">Deseja salvar o arquivo? S/N");
            char res = char.Parse(Console.ReadLine());

            switch (char.ToLower(res))
            {
                case 's':
                    {
                        Salvar(file.ToString());
                        Menu.Show();
                        break;
                    }
                case 'n': Menu.Show(); break;
                default: Menu.Show(); break;
            }
        }

        private static void Salvar(string text)
        {
            Console.Clear();
            Console.WriteLine("Qual caminho para salvar o arquivo?");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            Console.WriteLine($"Arquivo salvo em {path} com sucesso!");
            Console.WriteLine("");
            Console.WriteLine("Deseja abrir o arquivo agora? S/N");
            char res = char.Parse(Console.ReadLine());

            switch (char.ToLower(res))
            {
                case 's':
                    {
                        using (var file = new StreamReader(path))
                        {
                            string textFile = file.ReadToEnd();
                            Viewer.Replace(textFile);
                        }

                        Console.WriteLine("----------");
                        Console.ReadLine();
                        Menu.Show();
                        break;
                    }
                case 'n': Menu.Show(); break;
                default: Menu.Show(); break;
            }

        }
    }
}