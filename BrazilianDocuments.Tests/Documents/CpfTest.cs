namespace Tests.Documents;

public class CpfTest
{
    [Theory(DisplayName = "Shoud all caracteres are equal is valid")]
    [InlineData("11111111111")]
    [InlineData("22222222222")]
    [InlineData("33333333333")]
    [InlineData("44444444444")]
    [InlineData("55555555555")]
    [InlineData("66666666666")]
    [InlineData("77777777777")]
    [InlineData("88888888888")]
    [InlineData("99999999999")]
    public void TestShouldAllCharactersAreEqualIsValid(string value)
    {
        Cpf document = new Cpf(value);

        Assert.True(document.IsValid());
    }

    [Theory(DisplayName = "Shoud be return correctly masked value")]
    [InlineData("11111111111", "111.111.111-11")]
    [InlineData("37544195015", "375.441.950-15")]

    public void TestSholdBeReturnCorrectlyMaskedValue(string unmask, string expected)
    {
        Cpf document = new Cpf(unmask);

        Assert.Equal(expected, document.Mask());
    }

    [Fact(DisplayName = "Shoud be return invalid to a incorrect document")]
    public void TestSholdBeReturnInvalidToIncorrectDocument()
    {
        Cpf document = new Cpf("375.441.950-00");

        Assert.False(document.IsValid());
    }

    [Fact(DisplayName = "Shoud be return valid to a correctly document")]
    public void TestSholdBeReturnValidToCorrectlyDocument()
    {
        Cpf document = new Cpf("375.441.950-15");

        Assert.True(document.IsValid());
    }

    [Fact(DisplayName = "Shoud be return valid to a faked document")]
    public void TestSholdBeReturnValidToFakedDocument()
    {
        Cpf document = new Cpf(string.Empty);

        string fakeDocument = document.Generate();

        document = new Cpf(fakeDocument);

        Assert.True(document.IsValid());
    }
}