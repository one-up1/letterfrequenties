using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Letterfrequenties
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            // Type parameters moeten toch classes zijn? (<Character, Integer>) ?
            Dictionary<char, int> letterCounts = new Dictionary<char, int>();
            int total = 0, ignored = 0;

            foreach (char c in textBox.Text)
            {
                // In de opdracht staat "letters" dus andere tekens gaan we negeren.
                if (!Char.IsLetter(c))
                {
                    ignored++;
                    continue;
                }
                total++;

                // Als "case sensitive" niet is aangevinkt
                // doen we alsof alle letters kleine letters zijn.
                char letter = cbCaseSensitive.Checked ? c : Char.ToLower(c);

                // C# doet alsof Dictionary een primitieve array is?
                letterCounts[letter] = letterCounts.ContainsKey(letter) ?
                    letterCounts[letter] + 1 : 1;
            }

            if (total == 0)
            {
                MessageBox.Show("Geen letters gevonden!");
                return;
            }

            // Wel leuk om de letters te sorteren.
            List<Char> letters = letterCounts.Keys.ToList();
            letters.Sort();

            StringBuilder sb = new StringBuilder(letters.Count +
                " verschillende letters gevonden in " + textBox.TextLength + " tekens.");
            sb.AppendLine();
            sb.Append(total + " letters in totaal, " + ignored + " tekens genegeerd.");
            sb.AppendLine();
            foreach (char letter in letters)
            {
                sb.AppendLine();
                sb.Append(letter + ": " + letterCounts[letter]);
            }
            MessageBox.Show(sb.ToString());
        }
    }
}
