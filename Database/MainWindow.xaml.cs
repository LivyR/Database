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
using Database.DataSet1TableAdapters;

namespace Database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        private GameTableAdapter GTA = new GameTableAdapter();
        private DataSet1 DS = new DataSet1();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GTA.Fill(DS.Game);
            DataContext = DS.Game;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            GTA.Update(DS);
        }
    }
}
