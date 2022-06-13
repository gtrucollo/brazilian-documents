namespace BrazilianDocuments.Documents.Base;

public interface IDocument
{
    /// <summary>
    /// Do document validaton
    /// </summary>
    /// <returns>True if is valid</returns>
    public abstract bool IsValid();

    /// <summary>
    /// Do document mask
    /// </summary>
    /// <returns>Document correctly masked</returns>
    public abstract string Mask();

    /// <summary>
    /// Generate valid fake document
    /// </summary>
    /// <returns>A new valid fake document</returns>
    public abstract string Generate();
}