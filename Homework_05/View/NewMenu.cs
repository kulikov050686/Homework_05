using System;

namespace Homework_05.View
{
    public class NewMenu : MenuController
    {
        /// <summary>
        /// Текст заголовка меню
        /// </summary>
        string Text;        

        /// <summary>
        /// Конструктор создания нового меню
        /// </summary>
        /// <param name="itemsMenu"> Массив названий пунктов меню </param>
        /// <param name="_text"> Текст заголовка меню </param>
        public NewMenu(string[] itemsMenu, string _text) : base(itemsMenu)
        {
            Text = _text;            
        }

        /// <summary>
        /// Выбор пункта меню
        /// </summary>        
        new public int selectedMenuItem()
        {
            ConsoleKeyInfo keypress;
            int selection = 0;

            PrintMenu(selection);
            do
            {
                keypress = Console.ReadKey();

                if (keypress.Key == ConsoleKey.DownArrow)
                {
                    if (selection < SizeMenu - 1) selection++;
                }

                if (keypress.Key == ConsoleKey.UpArrow)
                {
                    if (selection > 0) selection--;
                }

                PrintMenu(selection);
            }
            while (keypress.Key != ConsoleKey.Enter);

            return selection;
        }

        /// <summary>
        /// Печать пунктов меню
        /// </summary>
        /// <param name="selection"> Подсветка соответствующего пункта меню </param>
        new void PrintMenu(int selection)
        {
            Console.Clear();

            startScreensaver();

            Console.WriteLine();


            for (int i = 0; i < SizeMenu; i++)
            {
                if (i == selection)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Center("->" + Menu.getItemMenu(i));
                    Console.ResetColor();
                }
                else
                {
                    Center(Menu.getItemMenu(i));
                }
            }
        }

        /// <summary>
        /// Вывод текстовой информации в заголовок меню
        /// </summary>
        void startScreensaver()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Center(Text);
            Console.ResetColor();
        }        
    }
}
