namespace TumblrClient.Core.Utils
{
    public class ViewModelResult<T>
    {
        public T Value { get; private set; }

        public ViewModelResult(T value)
        {
            Value = value;
        }
    }
}
