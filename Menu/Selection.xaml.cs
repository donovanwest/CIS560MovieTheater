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
    /// <summary>
    /// Interaction logic for Selection.xaml
    /// </summary>
    public partial class Selection : UserControl
    {

        private OrderControl orderControl;
        public Selection()
        {



            InitializeComponent();



            SearchForMovieByTitle.Click += OnSearchForMovieByTitleClicked;
            NewestMovie.Click += OnNewestMovieClicked;
            Topten.Click += OnToptenClicked;
            HighestGrossingShows.Click += OnHighestGrossingShowsClicked;
            HighestPaidEmployees.Click += OnHighestPaidEmployeesClicked;
            SearchForShowingsByTitle.Click += OnSearchForShowingsByTitleClicked;
            TheaterAmmenities.Click += OnTheaterAmmenitiesClicked;
            SearchForTheaterByID.Click += OnSearchForTheaterByIDClicked;
            OldestMovies.Click += OnOldestMoviesClicked;
            MostProfits.Click += OnMostProfitsClicked;
            MostTotalPay.Click += OnMostTotalPayClicked;
            DirectorsMostShowing.Click += OnDirectorsMostShowingClicked;
            ProfitsLost.Click += OnProfitsLostClicked;
            SearchForEmployeeByName.Click += OnSearchForEmployeeByNameClicked;
            InsertNewEmployee.Click += OnInsertNewEmployeeClicked;
        }
        
            
            void OnSearchForMovieByTitleClicked(object sender, RoutedEventArgs e)
            {
            orderControl = this.FindAncestor<OrderControl>();
            orderControl.SwapScreen(new SearchForMovieByTitle());

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
        void OnHighestGrossingShowsClicked(object sender, RoutedEventArgs e)
        {
            orderControl = this.FindAncestor<OrderControl>();
            orderControl.SwapScreen(new HighestGrossingShows());

        }
        void OnHighestPaidEmployeesClicked(object sender, RoutedEventArgs e)
        {
            orderControl = this.FindAncestor<OrderControl>();
            orderControl.SwapScreen(new HighestPaidEmployees());

        }
        void OnSearchForShowingsByTitleClicked(object sender, RoutedEventArgs e)
        {
            orderControl = this.FindAncestor<OrderControl>();
            orderControl.SwapScreen(new SearchForShowingsByTitle());

        }
        void OnTheaterAmmenitiesClicked(object sender, RoutedEventArgs e)
        {
            orderControl = this.FindAncestor<OrderControl>();
            orderControl.SwapScreen(new TheaterAmmenities());

        }
        void OnSearchForTheaterByIDClicked(object sender, RoutedEventArgs e)
        {
            orderControl = this.FindAncestor<OrderControl>();
            orderControl.SwapScreen(new SearchForTheaterByID());

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

        void OnSearchForEmployeeByNameClicked(object sender, RoutedEventArgs e)
        {
            
            orderControl = this.FindAncestor<OrderControl>();
            orderControl.SwapScreen(new SearchForEmployeeByName());

        }

        void OnInsertNewEmployeeClicked(object sender, RoutedEventArgs e)
        {

            orderControl = this.FindAncestor<OrderControl>();
            orderControl.SwapScreen(new InsertNewEmployee());

        }



    }
}
