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
    }
}
