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

namespace KeySignatures
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KeySignature[] keySignatures = new KeySignature[15];
        int currentKeySignature = -1;
        Random r = new Random();

        public MainWindow()
        {
            InitializeComponent();

            int i = 0;
            keySignatures[i++] = new KeySignature("No sharps or flats", "C Major", "A Minor");
            keySignatures[i++] = new KeySignature("1 Sharp", "G Major", "E Minor");
            keySignatures[i++] = new KeySignature("2 Sharps", "D Major", "B Minor");
            keySignatures[i++] = new KeySignature("3 Sharps", "A Major", "F sharp Minor");
            keySignatures[i++] = new KeySignature("4 Sharps", "E Major", "C sharp Minor");
            keySignatures[i++] = new KeySignature("5 Sharps", "B Major", "G sharp Minor");
            keySignatures[i++] = new KeySignature("6 Sharps", "F sharp Major", "D sharp Minor");
            keySignatures[i++] = new KeySignature("7 Sharps", "C sharp Major", "A sharp Minor");
            keySignatures[i++] = new KeySignature("7 Flats", "C flat Major", "A flat Minor");
            keySignatures[i++] = new KeySignature("6 Flats", "G flat Major", "E flat Minor");
            keySignatures[i++] = new KeySignature("5 Flats", "D flat Major", "B flat Minor");
            keySignatures[i++] = new KeySignature("4 Flats", "A flat Major", "F Minor");
            keySignatures[i++] = new KeySignature("3 Flats", "E flat Major", "C Minor");
            keySignatures[i++] = new KeySignature("2 Flats", "B flat Major", "G Minor");
            keySignatures[i++] = new KeySignature("1 Flat", "F Major", "D Minor");

            foreach (string major in new SortedSet<string>(keySignatures.Select((key, index) => key.MajorKey)))
            {
                MajorsList.Items.Add(major);
            }

            foreach (string minor in new SortedSet<string>(keySignatures.Select((key, index) => key.MinorKey)))
            {
                MinorsList.Items.Add(minor);
            }

            resetTest();

        }

        private void resetTest()
        {
            currentKeySignature = r.Next(0, keySignatures.Length);
            TargetText.Text = keySignatures[currentKeySignature].Name;
            HintTextBlock.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MajorsList.SelectedItems.Count == 1 &&
                MinorsList.SelectedItems.Count == 1 &&
                MajorsList.SelectedItem.Equals(keySignatures[currentKeySignature].MajorKey) && MinorsList.SelectedItem.Equals(keySignatures[currentKeySignature].MinorKey))
            {
                MessageBox.Show("Correct");
                
            } else
            {
                MessageBox.Show("Try Again");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            resetTest();
        }

        private void HintButton_Click(object sender, RoutedEventArgs e)
        {
            HintTextBlock.Text = keySignatures[currentKeySignature].MajorKey + "\n" + keySignatures[currentKeySignature].MinorKey;
        }
    }
}
