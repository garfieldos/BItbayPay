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
        public ErrorReason Reason { get; set; }
    }

    public enum ErrorReason
    {
        AUTHENTICATION_FAILED,
        FORBIDDEN,
        MARKET_DOES_NOT_EXIST,
        CURRENCY_DOES_NOT_EXIST,
        NOT_ALLOWED_CURRENCY,
        STORE_IS_INACTIVE,
        SOURCE_CURRENCY_MUST_BE_SET,
        DESTINATION_CURRENCY_MUST_BE_SET,
        WRONG_PAYMENT_ADDRESS,
        WITHDRAWAL_NOT_ALLOWED,
        OPERATION_ALREADY_PERFORMED,
        WITHDRAWAL_AMOUNT_SMALLER_THAN_FEE,
        FETCHING_CURRENCIES_ERROR,
        ACCESS_DENIED,
        PAYMENT_DOES_NOT_EXIST,
        INVALID_URL
    }

    public enum ResponseStatus
    {
        Fail,
        OK
    }
}