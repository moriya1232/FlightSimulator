﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using FlightSimulator.Model;
using FlightSimulator.ViewModels;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for MazeBoard.xaml
    /// </summary>
    public partial class FlightBoard : UserControl
    {
        private FlightBoardViewModel vm;
        ObservableDataSource<Point> planeLocations = null;
        public FlightBoard()
        {
            InitializeComponent();
            this.vm = new FlightBoardViewModel();
            vm.PropertyChanged += Vm_PropertyChanged;
            DataContext = vm;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            planeLocations = new ObservableDataSource<Point>();
            // Set identity mapping of point in collection to point on plot
            planeLocations.SetXYMapping(p => p);

            plotter.AddLineGraph(planeLocations, 2, "Route");
        }

        private void Vm_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName.Equals("Lat") || e.PropertyName.Equals("Lon"))
            {
                if (vm.Lat != null && vm.Lon != null)
                {
                    Point p1 = new Point((float) vm.Lat, (float) vm.Lon);
                    planeLocations.AppendAsync(Dispatcher, p1);
                }
            }
        }

    }

}

