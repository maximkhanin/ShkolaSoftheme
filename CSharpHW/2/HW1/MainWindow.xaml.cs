﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace HW1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private string GetRange(string type)
        {
            var myTypeTest = Type.GetType(type);
            var result = GetValueByField("MaxValue", myTypeTest) 
                         + GetValueByField("MinValue", myTypeTest);
            return result;
        }

        private static string GetValueByField(string field, Type myTypeTest)
        {
            var fi = myTypeTest.GetField(field);
            var value = fi.GetRawConstantValue();
            var result = field + ": " + value + '\n';
            return result;
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            foreach (var radioButton in RadioButtonPanel.Children)
            {
                var item = (RadioButton) radioButton;
                if (item.IsChecked != null && (bool)item.IsChecked)
                {
                    ResultText.Text = GetRange(item.ToolTip.ToString());
                }
            }
        }
    }
}
