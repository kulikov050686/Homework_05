using System;

namespace Homework_05.View
{
    public class MenuController
    {
        /// <summary>
        /// Меню приложения
        /// </summary>
        protected Menu Menu;

        /// <summary>
        /// Количество пунктов меню
        /// </summary>
        protected int SizeMenu;

        /// <summary>
        /// Создание нового контроллера меню
        /// </summary>
        /// <param name="itemsMenu"> Массив названий пунктов меню </param>
        public MenuController(string[] itemsMenu)
        {
            SizeMenu = itemsMenu.Length;
            Menu = new Menu(itemsMenu);
        }

        /// <summary>
        /// Выбор пункта меню
        /// </summary>
        /// <returns> Номер выбранного пункта меню </returns>
        public int selectedMenuItem()
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
        protected void PrintMenu(int selection)
        {
            Console.Clear();

            for (int i = 0; i < SizeMenu; i++)
            {
                if (i == selection)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
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
        /// Вывод строки по центру экрана
        /// </summary>
        /// <param name="line"> Строка </param>
        protected void Center(string line)
        {
            for (int i = 0, release = 0; i < line.Length; i += release)
            {
                if (line.Length - release < Console.WindowWidth)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - (line.Length - release) / 2, Console.CursorTop);
                    Console.WriteLine(line.Substring(release));
                    release = line.Length;
                }
                else
                {
                    Console.WriteLine(line.Substring(release, Console.WindowWidth));
                    release += Console.WindowWidth;
                }
            }
        }
    }
}
