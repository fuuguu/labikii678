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

namespace labiki678
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<int> mas=new List<int>();
        private List<double> masReal=new List<double>();
        private Queue<double> queueReal=new Queue<double>();
        private NodeStack<Monitor> stack=new NodeStack<Monitor> ();
        private OurQueue<double> doubleQeeue=new OurQueue<double> ();
        private OurList<int> intList=new OurList<int> ();
        public MainWindow()
        {
            InitializeComponent();
           // lbLab8.ItemsSource = intList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtInterMass.Text.Length != 0)
            {
                string str = txtInterMass.Text;
                if (str[str.Length-1]==',') str=str.Substring(0,str.Length-1);
                string[] strmas = str.Split(',');
                string res = "";
                foreach (var item in strmas)
                {
                    mas.Add(int.Parse(item));
                    res += item + " ";
                }
                tbMassive.Text = res;
            }
            else
            {
                MessageBox.Show("Введите элементы массива", "Сообщение",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            double result;
            double allnums=0;
            foreach (int i in mas)
            {
                allnums += i;
            }
            result = allnums / mas.Count;
            tbResult.Text = result.ToString();
            //int P = 1;
            //foreach (var item in mas)
            //{
            //    if (item >= 2 && item < 8) P *= item;
            //}
            //tbResult.Text = "Прозведение элементов от [2,8) равно:" + P.ToString();
        }

        private void txtInterMass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key == Key.OemComma||
                e.Key==Key.Back||e.Key==Key.OemMinus)
                return;
            e.Handled = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            mas.Clear();
            txtInterMass.Clear();
            tbMassive.Text = "";
            tbResult.Text = "";
        }

        







        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            //Stack<double> kretin = new Stack<double>();


            string str = nameMonitor.Text;
            if (str[str.Length - 1] == ',') str = str.Substring(0, str.Length - 1);
            string[] strmas = str.Split(',');
            int[] Price = new int[strmas.Length];
            for (int i = 0; i < strmas.Length; i++)
            {
                Price[i] = int.Parse(strmas[i]);
            }
            Monitor monitor = new Monitor(Price);
            stack.Push(monitor);
            TreeViewItem item = new TreeViewItem();
            item.Tag ="Запись "+stack.Count;
            item.Header = "Запись " + stack.Count;
            //item.Items.Add(masss.Name);
            //item.Items.Add(monitor.Diagonal);
            for(int i = 0; i < Price.Length; i++)
            {
                item.Items.Add(monitor.Price[i]);
            }

            double max = Price[0];
            for(int i = 1; i < strmas.Length; i++)
            {
                if (Price[i] > max)
                {
                    max = Price[i];
                }
            }
            string maxnum = $"Максимальный элемент стека: {max}";
            item.Items.Add(maxnum);
            treeList.Items.Add(item);
            nameMonitor.Clear();
            //это стэк, честно((
        }







        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            int n=int.Parse(txtLab8.Text);
            intList.Add(n);
            UpdateIntList();
            txtLab8.Clear();
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            //int index = -1;
            //int i = 0;
            //foreach (int item in intList)
            //{
            //    if (item > 10)
            //    {
            //        index = i;
            //        break;
            //    }
            //    i++;
            //}

            intList.RemoveAt((intList.IndexOf(55))-1);
            UpdateIntList();
        }
        private void UpdateIntList()
        {
            lbLab8.Items.Clear();
            foreach (int item in intList)
            {
                lbLab8.Items.Add(item);
            }
            //lbLab8.Items.Refresh();
        }

    }
}
