namespace Tests.Documents;

public class CnpjTest
{
    [Theory(DisplayName = "Shoud all caracteres are equal is valid")]
    [InlineData("11111111111111")]
    [InlineData("22222222222222")]
    [InlineData("33333333333333")]
    [InlineData("44444444444444")]
    [InlineData("55555555555555")]
    [InlineData("66666666666666")]
    [InlineData("77777777777777")]
    [InlineData("88888888888888")]
    [InlineData("99999999999999")]
    public void TestShouldAllCharactersAreEqualIsValid(string value)
    {
        Cnpj document = new Cnpj(value);

        Assert.True(document.IsValid());
    }

    [Theory(DisplayName = "Shoud be return correctly masked value")]
    [InlineData("11111111111111", "11.111.111/1111-11")]
    [InlineData("43055166000118", "43.055.166/0001-18")]

    public void TestSholdBeReturnCorrectlyMaskedValue(string unmask, string expected)
    {
        Cnpj document = new Cnpj(unmask);

        Assert.Equal(expected, document.Mask());
    }

    [Fact(DisplayName = "Shoud be return invalid to a incorrect document")]
    public void TestSholdBeReturnInvalidToIncorrectDocument()
    {
        Cnpj document = new Cnpj("43.055.166/0001-00");

        Assert.False(document.IsValid());
    }

    [Fact(DisplayName = "Shoud be return valid to a correctly document")]
    public void TestSholdBeReturnValidToCorrectlyDocument()
    {
        Cnpj document = new Cnpj("43.055.166/0001-18");

        Assert.True(document.IsValid());
    }

    [Fact(DisplayName = "Shoud be return valid to a faked document")]
    public void TestSholdBeReturnValidToFakedDocument()
    {
        Cnpj document = new Cnpj(string.Empty);

        string fakeDocument = document.Generate();

        document = new Cnpj(fakeDocument);

        Assert.True(document.IsValid());
    }
}