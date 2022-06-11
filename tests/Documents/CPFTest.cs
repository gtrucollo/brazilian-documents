namespace Tests.Documents;

public class CPFTest
{
    [Fact(DisplayName = "Shoud all caracteres are equal is valid")]
    public void TestShouldAllCharactersAreEqualIsValid()
    {
        CPF document = new CPF("11111111111");

        Assert.True(document.IsValid());
    }

    [Fact(DisplayName = "Shoud be return correctly masked value")]
    public void TestSholdBeReturnCorrectlyMaskedValue()
    {
        CPF document = new CPF("11111111111");

        Assert.Equal("111.111.111-11", document.Mask());
    }

    [Fact(DisplayName = "Shoud be return invalid to a incorrect document")]
    public void TestSholdBeReturnInvalidToIncorrectDocument()
    {
        CPF document = new CPF("375.441.950-00");

        Assert.False(document.IsValid());
    }

    [Fact(DisplayName = "Shoud be return valid to a correctly document")]
    public void TestSholdBeReturnValidToCorrectlyDocument()
    {
        CPF document = new CPF("375.441.950-15");

        Assert.True(document.IsValid());
    }

    [Fact(DisplayName = "Shoud be return valid to a faked document")]
    public void TestSholdBeReturnValidToFakedDocument()
    {
        CPF document = new CPF(string.Empty);

        string fakeDocument = document.Generate();

        document = new CPF(fakeDocument);

        Assert.True(document.IsValid());
    }
}