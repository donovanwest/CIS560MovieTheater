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
    
    public partial class InsertNewEmployee : UserControl
    {
        public InsertNewEmployee()
        {
            InitializeComponent();
            SearchButton.Click += OnSearchButtonClicked;
        }

        public void OnSearchButtonClicked(object sender, RoutedEventArgs e)
        {
            if (ItemToAdd.Text is string data)
            {
                string[] name = data.Split(' ');

                Queries.InsertEmployee("Server=mssql.cs.ksu.edu;Database=donovanwest;User Id=donovanwest;Password=Donnybob185;", Convert.ToDouble(name[0]), name[1], name[2], Convert.ToDateTime(name[3]));

                ConfirmBox.Text = "Successful Add";
                
            }
        }

    }
}
