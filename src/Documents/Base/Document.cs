namespace src.Documents.Base;

public abstract class Document
{
    public virtual int GetDigitFromMod11(string value, int[] weights)
    {
        int sum = 0;
        for (int i = 0; i < weights.Length; ++i)
        {
            sum += weights[i] * int.Parse(value[i].ToString());
        }

        int digit = sum % 11;

        return digit < 2 ? 0 : (11 - digit);
    }

    public virtual string RandomDigits(int length)
    {
        Random rand = new Random();

        string randomDigits = string.Empty;
        for (int i = 0; i < length; i++)
        {
            randomDigits += rand.Next(0, 9);
        }

        return randomDigits;
    }
}