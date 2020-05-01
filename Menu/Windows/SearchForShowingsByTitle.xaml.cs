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
    public partial class SearchForShowingsByTitle : UserControl
    {
        public SearchForShowingsByTitle()
        {
            InitializeComponent();
            SearchButton.Click += OnSearchButtonClicked;
        }

        public void OnSearchButtonClicked(object sender, RoutedEventArgs e)
        {
            if (ItemToAdd.Text is string data)
            {

                IReadOnlyList<String> items = Queries.SearchForShowingsByTitle("Server=mssql.cs.ksu.edu;Database=donovanwest;User Id=donovanwest;Password=Donnybob185;", data);

                for (int i = 0; i < items.Count; i++)
                {
                    YourListBox.Items.Add(items[i]);
                }

            }
        }


    }
}
