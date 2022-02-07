using System.Windows;

namespace EdagTeszt2
{

    public partial class MainWindow : Window
    {
        private Grafika grafikak;
        private int koordinataEll = 2;
        public MainWindow()
        {
            InitializeComponent();
            grafikak = new Grafika(canvasPanel);
        }

        private void runButton_Click(object sender, RoutedEventArgs e)
        {
            scrollBar.Value = 0;
            scbDoboz.Text = "0";
            grafikak.Clear();

            string[] aPontokStr = haromszogAOldal.Text.Split(',');
            string[] bPontokStr = haromszogBOldal.Text.Split(',');
            string[] cPontokStr = haromszogCOldal.Text.Split(',');
            int[] aPontokInt = new int[aPontokStr.Length];
            int[] bPontokInt = new int[bPontokStr.Length];
            int[] cPontokInt = new int[cPontokStr.Length];

            if (aPontokInt.Length != koordinataEll || bPontokInt.Length != koordinataEll || cPontokInt.Length != koordinataEll)
            {
                MessageBox.Show("Nem megfelelő koordináta formátum!");
                return;
            }

            for (int i = 0; i < koordinataEll; i++)
            {
                int.TryParse(aPontokStr[i], out int numA);
                aPontokInt[i] = numA;
                int.TryParse(bPontokStr[i], out int numB);
                bPontokInt[i] = numB;
                int.TryParse(cPontokStr[i], out int numC);
                cPontokInt[i] = numC;
            }

            var aPont = new Point(aPontokInt[0], aPontokInt[1]);
            var bPont = new Point(bPontokInt[0], bPontokInt[1]);
            var cPont = new Point(cPontokInt[0], cPontokInt[1]);

            grafikak.Rajz(aPont, bPont, cPont);

            scbDoboz.IsEnabled = true;
            scrollBar.IsEnabled = true;
            forgatasGomb.IsEnabled = true;
        }

        private void onScroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
            grafikak.haromszogForgatas(scrollBar.Value);
            var s = $"{scrollBar.Value:0.00}";
            scbDoboz.Text = s;

        }

        private void forgatasGomb_Click(object sender, RoutedEventArgs e)
        {
            double forgatasiSzog = 0.0;
            double.TryParse(scbDoboz.Text, out forgatasiSzog);

            if (forgatasiSzog < 0)
            {
                forgatasiSzog = 0;
                scbDoboz.Text = forgatasiSzog.ToString();
            }
            else if (forgatasiSzog > 180)
            {
                forgatasiSzog = 180;
                scbDoboz.Text = forgatasiSzog.ToString();
            }

            grafikak.haromszogForgatas(forgatasiSzog);
            scrollBar.Value = forgatasiSzog;
        }
    }
}
