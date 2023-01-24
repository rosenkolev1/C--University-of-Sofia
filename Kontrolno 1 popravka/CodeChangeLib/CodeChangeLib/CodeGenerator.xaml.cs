using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace CodeChangeLib
{
    /// <summary>
    /// Interaction logic for CodeGenerator.xaml
    /// </summary>
    public partial class CodeGenerator : UserControl
    {
        private Random rnd;

        private static readonly char[] BULGARIAN_ALPHABET = 
        { 
            'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ь', 'Ю', 'Я' 
        };

        public event EventHandler<CodeChangeEventArgs> CodeChange;

        public CodeGenerator()
        {
            InitializeComponent();
            this.rnd = new Random();
        }

        private void ButtonClearInput_Click(object sender, RoutedEventArgs e)
        {
            generatorBox.Text = "";
        }

        private void ButtonQuit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private List<string> GenerateRandomPairs()
        {
            List<string> result = new List<string>();

            for (int i = 0; i < 60; i++)
            {
                int firstLetterInt = rnd.Next(0, 30);
                int secondLetterInt = firstLetterInt + rnd.Next(1, 4);

                if (secondLetterInt >= 30) secondLetterInt -= 30;

                char firstLetter = BULGARIAN_ALPHABET[firstLetterInt];
                char secondLetter = BULGARIAN_ALPHABET[secondLetterInt];

                //Here is an alternative way where you do not have to create your own alphabet array. But this one contains cyrillic letters that are not in the Bulgarian alphabet

                //int firstLetterInt = rnd.Next('А', 'Я');
                // int secondLetterInt = firstLetterInt + rnd.Next(1, 4);
                //if (secondLetterInt >= 'Я') secondLetterInt -= 'Я' - 'А';

                //char firstLetter = (char)firstLetterInt; 
                //char secondLetter = (char)secondLetterInt;

                result.Add($"{firstLetter}{secondLetter}");
            }

            return result;
        }

        private void ButtonGenerateCode_Click(object sender, RoutedEventArgs e)
        {
            List<string> generatedPairs = GenerateRandomPairs();

            generatorBox.Text += string.Join("", generatedPairs.Select(x => $"{x} ").ToList());
            
            if (CodeChange != null)
            {
                var listOfLetters = generatorBox.Text.Split(" ").Where(x => !string.IsNullOrEmpty(x)).ToList();
                var codeChangedArgs = new CodeChangeEventArgs(listOfLetters);

                CodeChange?.Invoke(this, codeChangedArgs);
            }

        }
    }
}
