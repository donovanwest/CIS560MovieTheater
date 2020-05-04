using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Menu.Extentions;
using DataAccessDemo.Data;

namespace Menu
{
    public partial class SearchForEmployeeByName : UserControl
    {
        public SearchForEmployeeByName()
        {
            InitializeComponent();
            SearchButton.Click += OnSearchButtonClicked;
        }
        public void OnSearchButtonClicked(object sender, RoutedEventArgs e)
        {
            if (ItemToAdd.Text is string data)
            {
                string[] name = data.Split(' ');
                IReadOnlyList<String> items = Queries.SearchForEmployeeByName("Server=mssql.cs.ksu.edu;Database=donovanwest;User Id=donovanwest;Password=********;", name[0], name[1]);

                for (int i = 0; i < items.Count; i++)
                {
                    YourListBox.Items.Add(items[i]);
                }

            }
        }

    }
}
