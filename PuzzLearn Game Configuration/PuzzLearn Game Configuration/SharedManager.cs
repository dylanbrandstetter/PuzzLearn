using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzLearn_Game_Configuration
{
    public class SharedManager : ISharedManager
    {
        public SharedManager() { }

        private bool validDescChar(char c)
        {
            return c != ',' && c <= (char)127;
        }

        private bool validHexChar(char c)
        {
            return Regex.IsMatch(c.ToString(), "[0-9a-fA-F\b]");
        }

        private bool validSqlChar(char c)
        {
            return c <= (char)127;
        }

        public void DescriptionPressCheck(KeyPressEventArgs e)
        {
            if (!validDescChar(e.KeyChar))
                e.Handled = true;
        }

        public void HexPressCheck(KeyPressEventArgs e)
        {
            if (!validHexChar(e.KeyChar))
                e.Handled = true;
            else
                e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        public void SqlPressCheck(KeyPressEventArgs e)
        {
            if (!validSqlChar(e.KeyChar))
                e.Handled = true;
        }

        public void DescriptionDownCheck(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                string paste = Clipboard.GetText();
                string newPaste = "";

                foreach (char c in paste)
                {
                    if (validDescChar(c))
                        newPaste += c;
                }

                if (paste != newPaste)
                {
                    e.SuppressKeyPress = true;

                    TextBox tb = (TextBox)sender;
                    int selStart = tb.SelectionStart;
                    int selLength = tb.SelectionLength;

                    string newText = tb.Text.Remove(selStart, selLength)
                        .Insert(selStart, newPaste);
                    if (newText.Length > 32)
                        newText = newText.Substring(0, 32);

                    tb.Text = newText;

                    int newStart = selStart + newPaste.Length;
                    if (newStart > 32)
                        tb.SelectionStart = 32;
                    else
                        tb.SelectionStart = newStart;

                    tb.SelectionLength = 0;
                }
            }
        }

        public void HexDownCheck(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                string paste = Clipboard.GetText();
                string newPaste = "";

                foreach (char c in paste)
                {
                    if (validHexChar(c))
                        newPaste += char.ToUpper(c);
                }

                if (paste != newPaste)
                {
                    e.SuppressKeyPress = true;

                    TextBox tb = (TextBox)sender;
                    int selStart = tb.SelectionStart;
                    int selLength = tb.SelectionLength;

                    string newText = tb.Text.Remove(selStart, selLength)
                        .Insert(selStart, newPaste);
                    if (newText.Length > 8)
                        newText = newText.Substring(0, 8);

                    tb.Text = newText;

                    int newStart = selStart + newPaste.Length;
                    if (newStart > 8)
                        tb.SelectionStart = 8;
                    else
                        tb.SelectionStart = newStart;

                    tb.SelectionLength = 0;
                }
            }
        }

        public void SqlDownCheck(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                string paste = Clipboard.GetText();
                string newPaste = "";

                foreach (char c in paste)
                {
                    if (validSqlChar(c))
                        newPaste += c;
                }

                if (paste != newPaste)
                {
                    e.SuppressKeyPress = true;

                    TextBox tb = (TextBox)sender;
                    int selStart = tb.SelectionStart;
                    int selLength = tb.SelectionLength;

                    string newText = tb.Text.Remove(selStart, selLength)
                        .Insert(selStart, newPaste);
                    if (newText.Length > 32)
                        newText = newText.Substring(0, 32);

                    tb.Text = newText;

                    int newStart = selStart + newPaste.Length;
                    if (newStart > 32)
                        tb.SelectionStart = 32;
                    else
                        tb.SelectionStart = newStart;

                    tb.SelectionLength = 0;
                }

            }
        }
    }
}
