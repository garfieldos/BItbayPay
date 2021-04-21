namespace BitBayPayClient.Model
{
    public class BitBayPayResponse<T> where T : class
    {
        public T? Data { get; set; }
        public ResponseStatus Status { get; set; }
        public BitBayPayResponseError[] Errors { get; set; }
    }

    public class BitBayPayResponseError
    {
        public string Reason { get; set; }
    }


    public enum ResponseStatus
    {
        Fail,
        OK
    }
}