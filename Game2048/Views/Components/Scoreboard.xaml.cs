﻿using System;
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

namespace Game2048.Views.Components
{
    /// <summary>
    /// Логика взаимодействия для Scoreboard.xaml
    /// </summary>
    public partial class Scoreboard : UserControl
    {
        //public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof(Title), typeof(string), typeof(Scoreboard));
        public Scoreboard()
        {
            InitializeComponent();
        }

        //public string Title
        //{
        //    get => (string)GetValue(TitleProperty);
        //    set => SetValue(TitleProperty, value);
        //}
    }
}
