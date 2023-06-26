namespace Restaurant.DDD.SharedKernel;

public class Result<TValue, TError>
{
    private readonly TValue? _value;
    private readonly TError? _error;

    public bool IsError { get; init; }
    public bool IsSuccess => !IsError;

    public Result(TValue value)
    {
        IsError = false;
        _value = value;
        _error = default;
    }

    public Result(TError error)
    {
        IsError = true;
        _value = default;
        _error = error;
    }

    public static implicit operator Result<TValue, TError>(TValue value) => new(value);
    public static implicit operator Result<TValue, TError>(TError error) => new(error);

    /// <summary>
    /// Matches the success status of the result to the corresponding functions.
    /// </summary>
    public TResult Match<TResult>(
        Func<TValue, TResult> success,
        Func<TError, TResult> failure) =>
        !IsError ? success(_value!) : failure(_error!);
}
