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

namespace Menu
{
    /// <summary>
    /// Interaction logic for OrderControl.xaml
    /// </summary>
    public partial class OrderControl : UserControl
    {
        public OrderControl()
        {
            InitializeComponent();
            BackToMain.Click += BackToMainClicked;
        }


        public void SwapScreen(UIElement element)
        {
            Container.Child = element;
        }

        void BackToMainClicked(object sender, RoutedEventArgs e)
        {
            SwapScreen(new Selection());

        }
    }
}
