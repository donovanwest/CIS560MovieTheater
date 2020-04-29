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


namespace Menu
{
    /// <summary>
    /// Interaction logic for Selection.xaml
    /// </summary>
    public partial class Selection : UserControl
    {

        private OrderControl orderControl;
        public Selection()
        {



            InitializeComponent();



            TodayShowings.Click += OnTodayShowingsClicked;
            NewestMovie.Click += OnNewestMovieClicked;
            Topten.Click += OnToptenClicked;
            FullTheaters.Click += OnFullTheatersClicked;
            HighestPaidEmployees.Click += OnHighestPaidEmployeesClicked;
            DirectorsLongestMovies.Click += OnDirectorsLongestMoviesClicked;
            HandicapAccessibleTheaters.Click += OnHandicapAccessibleTheatersClicked;
            EmployeesNotWorking.Click += OnEmployeesNotWorkingClicked;
            OldestMovies.Click += OnOldestMoviesClicked;
            MostProfits.Click += OnMostProfitsClicked;
            MostTotalPay.Click += OnMostTotalPayClicked;
            DirectorsMostShowing.Click += OnDirectorsMostShowingClicked;
            ProfitsLost.Click += OnProfitsLostClicked;
        }
        
            
            void OnTodayShowingsClicked(object sender, RoutedEventArgs e)
            {
            orderControl = this.FindAncestor<OrderControl>();
            orderControl.SwapScreen(new TodayShowings());

            }

        void OnNewestMovieClicked(object sender, RoutedEventArgs e)
        {
            orderControl = this.FindAncestor<OrderControl>();
            orderControl.SwapScreen(new NewestMovie());

        }
        void OnToptenClicked(object sender, RoutedEventArgs e)
        {
            orderControl = this.FindAncestor<OrderControl>();
            orderControl.SwapScreen(new Topten());

        }
        void OnFullTheatersClicked(object sender, RoutedEventArgs e)
        {
            orderControl = this.FindAncestor<OrderControl>();
            orderControl.SwapScreen(new FullTheaters());

        }
        void OnHighestPaidEmployeesClicked(object sender, RoutedEventArgs e)
        {
            orderControl = this.FindAncestor<OrderControl>();
            orderControl.SwapScreen(new HighestPaidEmployees());

        }
        void OnDirectorsLongestMoviesClicked(object sender, RoutedEventArgs e)
        {
            orderControl = this.FindAncestor<OrderControl>();
            orderControl.SwapScreen(new DirectorsLongestMovies());

        }
        void OnHandicapAccessibleTheatersClicked(object sender, RoutedEventArgs e)
        {
            orderControl = this.FindAncestor<OrderControl>();
            orderControl.SwapScreen(new HandicapAccessibleTheaters());

        }
        void OnEmployeesNotWorkingClicked(object sender, RoutedEventArgs e)
        {
            orderControl = this.FindAncestor<OrderControl>();
            orderControl.SwapScreen(new EmployeesNotWorking());

        }
        void OnOldestMoviesClicked(object sender, RoutedEventArgs e)
        {
            orderControl = this.FindAncestor<OrderControl>();
            orderControl.SwapScreen(new OldestMovies());

        }
        void OnMostProfitsClicked(object sender, RoutedEventArgs e)
        {
            orderControl = this.FindAncestor<OrderControl>();
            orderControl.SwapScreen(new MostProfits());

        }
        void OnMostTotalPayClicked(object sender, RoutedEventArgs e)
        {
            orderControl = this.FindAncestor<OrderControl>();
            orderControl.SwapScreen(new MostTotalPay());

        }
        void OnDirectorsMostShowingClicked(object sender, RoutedEventArgs e)
        {
            orderControl = this.FindAncestor<OrderControl>();
            orderControl.SwapScreen(new DirectorsMostShowing());

        }
        void OnProfitsLostClicked(object sender, RoutedEventArgs e)
        {
            orderControl = this.FindAncestor<OrderControl>();
            orderControl.SwapScreen(new ProfitsLost());

        }



    }
}
