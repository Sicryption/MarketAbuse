namespace MarketAbuse.Filters
{
    public class FilterEventArgs
    {
        public FilterEventArgs(AbstractFilter filter)
        {
            Filter = filter;
        }

        public AbstractFilter Filter { get; set; }
    }
}
