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
using DataAccessDemo.Data;

namespace Menu
{
    public partial class SearchForMovieByTitle : UserControl
    {
        public SearchForMovieByTitle()
        {
            InitializeComponent();
            SearchButton.Click += OnSearchButtonClicked;
        }

        public void OnSearchButtonClicked(object sender, RoutedEventArgs e)
        {
            if (ItemToAdd.Text is string data)
            {
                
                IReadOnlyList<String> items = Queries.SearchForMovieByTitle("Server=mssql.cs.ksu.edu;Database=donovanwest;User Id=donovanwest;Password=********;", data);

                for (int i = 0; i < items.Count; i++)
                {
                    YourListBox.Items.Add(items[i]);
                }
                
            }
        }
    }
}
