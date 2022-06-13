namespace Tests.Documents;

public class CpfTest
{
    [Fact(DisplayName = "Shoud all caracteres are equal is valid")]
    public void TestShouldAllCharactersAreEqualIsValid()
    {
        Cpf document = new Cpf("11111111111");

        Assert.True(document.IsValid());
    }

    [Fact(DisplayName = "Shoud be return correctly masked value")]
    public void TestSholdBeReturnCorrectlyMaskedValue()
    {
        Cpf document = new Cpf("11111111111");

        Assert.Equal("111.111.111-11", document.Mask());
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