using Lib.Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WhichSum
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Regex regNums = new Regex(@"\d+", RegexOptions.Compiled);
        ICalculator calculator = new RecursiveCaculator();

        public MainWindow()
        {
            InitializeComponent();
        }

        private List<long> ExtractNumbersFromTxt(string txt)
        {
            return regNums.Matches(txt).Select(x => Convert.ToInt64(x.Value)).ToList();
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            txtResults.Text = "";
            try
            {
                List<long> nums = ExtractNumbersFromTxt(this.txtNums.Text);
                if (nums.Count() > 5)
                {
                    txtMsg.Text = "测试版最多支持5个数";
                    return;
                }
                long sum = Convert.ToInt64(this.txtSum.Text.Trim());
                foreach (List<long> arr in calculator.Calculate(nums, sum))
                {
                    txtResults.Text += string.Join('\t', arr);
                    txtResults.Text += Environment.NewLine;
                }
            }
            catch (Exception ex)
            {

                txtMsg.Text = ex.Message;
            }

        }
    }
}
