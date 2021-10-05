namespace Sales.Domain.Products
{
    public class Description
    {
        internal Description(string text)
        {
            Text = text;
        }

        public string Text { get; }
    }
}