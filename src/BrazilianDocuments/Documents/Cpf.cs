using BrazilianDocuments.Documents.Base;

namespace BrazilianDocuments.Documents;

public class Cpf : Document, IDocument
{
    private readonly string _value;

    private readonly int[] _verify_digits_weights = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

    public Cpf(string value)
    {
        _value = value.RemoveMask();
    }

    public virtual bool IsValid()
    {
        if (string.IsNullOrWhiteSpace(_value))
        {
            return false;
        }

        if (_value.Length != 11)
        {
            return false;
        }

        if (_value.AllCharactersAreEqual())
        {
            return true;
        }

        int firstDigit = this.GetDigitFromMod11(_value.Substring(0, 9), _verify_digits_weights.Skip(1).ToArray());

        int seconDigit = this.GetDigitFromMod11(_value.Substring(0, 10), _verify_digits_weights);

        string document = string.Format("{0}{1}{2}", _value.Substring(0, 9), firstDigit, seconDigit);

        return _value.Equals(document);
    }

    public virtual string Mask()
    {
        if (!this.IsValid())
        {
            return string.Empty;
        }

        return string.Format("{0:000\\.000\\.000-00}", Convert.ToInt64(_value));
    }

    public virtual string Generate()
    {
        string fakeDocument = this.RandomDigits(9);

        int firstDigit = this.GetDigitFromMod11(fakeDocument, _verify_digits_weights.Skip(1).ToArray());

        int seconDigit = this.GetDigitFromMod11(string.Format("{0}{1}", fakeDocument, firstDigit), _verify_digits_weights);

        return string.Format("{0}{1}{2}", fakeDocument.Substring(0, 9), firstDigit, seconDigit);
    }
}