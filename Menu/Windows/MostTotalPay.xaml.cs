﻿using System;
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
    public partial class MostTotalPay : UserControl
    {
        public MostTotalPay()
        {
            InitializeComponent();
            IReadOnlyList<String> items = Queries.MostPaidEmployees("Server=mssql.cs.ksu.edu;Database=donovanwest;User Id=donovanwest;Password=temppassword123;");

            for (int i = 0; i < items.Count; i++)
            {
                YourListBox.Items.Add(items[i]);
            }
        }
    }
}
