namespace MarketAbuse.Sorts
{
    public class SortEventArgs
    {
        public SortEventArgs(AbstractSort sort)
        {
            Sort = sort;
        }

        public AbstractSort Sort { get; set; }
    }
}
