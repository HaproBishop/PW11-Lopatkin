using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace PW11
{
    /// <summary>
    /// Практическая работа №11. Лопаткин Сергей ИСП-31. 8. Дана строка 'ab abab abab abababab abea'. Напишите регулярное выражение, которое 
    /// найдет строки 'ab' повторяется 1 или более раз.
    /// Дана строка 'a.a aba aea'.Напишите регулярное выражение, которое найдет
    /// строку a.a, не захватив остальные.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Findab_Click(object sender, RoutedEventArgs e)
        {
            Regex findab = new Regex("(ab)+");//Задаем параметры поиска, создаем новое регулярное выражение
            string firstmainstring = FirstMainString.Text;//Извлечение данной строки из элемента интерфейса TextBox
            MatchCollection result = findab.Matches(firstmainstring);//Коллекционируем найденное для последующего отображения как результата проделанной работы
            Countab.Text = result.Count.ToString();//Вывод количества найденных ab
            for (int i = 0; i < result.Count; i++)
            {
                FirstResultOfRegex.Items.Add(result[i]);//Занесение элементов в listbox
            }
            Findab.IsEnabled = false;
            FindabMenu.IsEnabled = false;//Изменение свойства IsEnabled для некоторых элементов относительно логики взаимодействия с программой
            Clear.IsEnabled = true;
            ClearMenu.IsEnabled = true;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Countab.Clear();//Используется очистка текущих результатов
            Countaa.Clear();
            FirstResultOfRegex.Items.Clear();
            SecondResultOfRegex.Items.Clear();
            Findab.IsEnabled = true;//Изменение свойства IsEnabled для некоторых элементов относительно логики взаимодействия с программой
            FindabMenu.IsEnabled = true;
            Findaa.IsEnabled = true;
            FindaaMenu.IsEnabled = true;
            Clear.IsEnabled = false;
            ClearMenu.IsEnabled = false;
        }

        private void Support_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Особенностями данной программы является:\n" +
                "1) Нельзя редактировать поля\n" +
                "2) Данная програма позволяет увидеть работу класса Regex\n" +
                "3) '.' - означает любой символ\n" +
                "4) Быстрый выход из программы может быть осуществлен при помощи клавиши Esc", "Справка", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void AboutProgram_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Практическая работа №11. Лопаткин Сергей ИСП-31. 8. Дана строка 'ab abab abab abababab abea'. Напишите регулярное выражение, которое" +
                " найдет строки 'ab' повторяется 1 или более раз." +
                " Дана строка 'a.a aba aea'.Напишите регулярное выражение, которое найдет " +
                "строку a.a, не захватив остальные.", "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Findaa_Click(object sender, RoutedEventArgs e)
        {
            Regex findaa = new Regex(@"a\.a");//Задаем параметры поиска, создаем новое регулярное выражение
            string secondmainstring = SecondMainString.Text;
            MatchCollection result = findaa.Matches(secondmainstring);//Коллекционируем найденное для последующего отображения как результата проделанной работы
            Countaa.Text = result.Count.ToString();//Вывод количества найденных a.a
            for (int i = 0; i < result.Count; i++)
            {
                SecondResultOfRegex.Items.Add(result[i]);//Занесение элементов в listbox
            }
            Findaa.IsEnabled = false;
            FindaaMenu.IsEnabled = false;
            Clear.IsEnabled = true;//Для правильной логики работы с программой
            ClearMenu.IsEnabled = true;
        }
    }
}
