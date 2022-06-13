using BrazilianDocuments.Documents.Base;

namespace BrazilianDocuments.Documents;

public class Cnpj : Document, IDocument
{
    private readonly string _value;

    private readonly int[] _verify_digits_weights = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

    public Cnpj(string value)
    {
        _value = value.RemoveMask();
    }

    public virtual bool IsValid()
    {
        if (string.IsNullOrWhiteSpace(_value))
        {
            return false;
        }

        if (_value.Length != 14)
        {
            return false;
        }

        if (_value.AllCharactersAreEqual())
        {
            return true;
        }

        int firstDigit = this.GetDigitFromMod11(_value.Substring(0, 12), _verify_digits_weights.Skip(1).ToArray());

        int seconDigit = this.GetDigitFromMod11(_value.Substring(0, 13), _verify_digits_weights);

        string document = string.Format("{0}{1}{2}", _value.Substring(0, 12), firstDigit, seconDigit);

        return _value.Equals(document);
    }

    public virtual string Mask()
    {
        if (!this.IsValid())
        {
            return string.Empty;
        }

        return string.Format("{0:00\\.000\\.000/0000-00}", Convert.ToInt64(_value));
    }

    public virtual string Generate()
    {
        string fakeDocument = this.RandomDigits(12);

        int firstDigit = this.GetDigitFromMod11(fakeDocument, _verify_digits_weights.Skip(1).ToArray());

        int seconDigit = this.GetDigitFromMod11(string.Format("{0}{1}", fakeDocument, firstDigit), _verify_digits_weights);

        return string.Format("{0}{1}{2}", fakeDocument, firstDigit, seconDigit);
    }
}