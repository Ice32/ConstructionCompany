using System.Windows.Forms;

namespace ConstructionCompanyWinDesktop.Util
{
    public class ValidationUtil
    {
        private readonly ErrorProvider _errorProvider;

        public ValidationUtil(ErrorProvider errorProvider)
        {
            _errorProvider = errorProvider;
        }
        public bool AssertLength(int length, TextBox textBox, System.ComponentModel.CancelEventArgs e)
        {
            if (textBox.Text.Length < length)
            {
                _errorProvider.SetError(textBox, "Unesite validnu vrijednost");
                e.Cancel = true;
                return false;
            }

            _errorProvider.SetError(textBox, null);
            return true;
        }
        
        public bool AssertItemSelected(ListBox listBox, System.ComponentModel.CancelEventArgs e)
        {
            if (listBox.SelectedItems.Count == 0)
            {
                _errorProvider.SetError(listBox, "Odaberite bar jednu vrijednost");
                e.Cancel = true;
                return false;
            }

            _errorProvider.SetError(listBox, null);
            return true;
        }

        public bool AssertItemSelected(ComboBox comboBox, System.ComponentModel.CancelEventArgs e)
        {
            if (comboBox.SelectedValue == default)
            {
                _errorProvider.SetError(comboBox, "Odaberi vrijednost");
                e.Cancel = true;
                return false;
            }

            _errorProvider.SetError(comboBox, null);
            return true;
        }
    }
}
