using System;

namespace Homework_05.View
{
    public class Menu
    {
        /// <summary>
        /// Количество пунктов меню
        /// </summary>
        int SizeMenu = 1;

        /// <summary>
        /// Название пункта меню
        /// </summary>
        string[] NameItem;

        /// <summary>
        /// Конструктор нового меню
        /// </summary>
        /// <param name="nameItemsMenu"> Массив названий пунктов меню </param>
        /// <param name="numberMenuItems"> Количество пунктов меню </param>
        public Menu(string[] nameItemsMenu)
        {
            SizeMenu = nameItemsMenu.Length;
            NameItem = new string[SizeMenu];

            for (int i = 0; i < SizeMenu; i++)
            {
                NameItem[i] = nameItemsMenu[i];
            }
        }

        /// <summary>
        /// Получить название пункта меню по номеру
        /// </summary>
        /// <param name="menuItemNumber"> Номер пункта меню </param>        
        public string getItemMenu(int menuItemNumber)
        {
            if (menuItemNumber < SizeMenu)
            {
                return NameItem[menuItemNumber];
            }
            else
            {
                throw new ArgumentException("Несоответствие индекса!!!");
            }
        }
    }
}
