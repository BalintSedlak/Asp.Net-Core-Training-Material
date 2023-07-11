using System;

namespace Restaurant.DDD.SharedKernel.Monads;

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

    /// <summary>
    /// Converts value into the result.
    /// </summary>
    /// <param name="value">The result to be converted.</param>
    /// <returns>The result representing <paramref name="value"/> value.</returns>
    public static implicit operator Result<TValue, TError>(TValue value) => new(value);

    /// <summary>
    /// Converts error into the result.
    /// </summary>
    /// <param name="error">The result to be converted.</param>
    /// <returns>The result representing <paramref name="error"/> value.</returns>
    public static implicit operator Result<TValue, TError>(TError error) => new(error);

    /// <summary>
    /// Indicates that the result is successful.
    /// </summary>
    /// <param name="result">The result to check.</param>
    /// <returns><see langword="true"/> if this result is successful; <see langword="false"/> if this result represents exception.</returns>
    public static bool operator true(Result<TValue, TError> result) => result._error is null;
    
    /// <summary>
    /// Indicates that the result represents error.
    /// </summary>
    /// <param name="result">The result to check.</param>
    /// <returns><see langword="false"/> if this result is successful; <see langword="true"/> if this result represents exception.</returns>
    public static bool operator false(in Result<TValue, TError> result) => result._error is not null;

    /// <summary>
    /// Extracts actual result.
    /// </summary>
    /// <param name="result">The result object.</param>
    public static explicit operator TValue(Result<TValue, TError> result) => result._value;

    /// <summary>
    /// Gets the associated <see cref="TError"/> with this result.
    /// </summary>
    public TError? Error => _error;

    public static Result<TValue, TError> Success(TValue value)
    {
        return new Result<TValue, TError>(value);
    }

    public static Result<TValue, TError> Failure(TError error)
    {
        return new Result<TValue, TError>(error);
    }

    /// <summary>
    /// Returns textual representation of this object.
    /// </summary>
    /// <returns>The textual representation of this object.</returns>
    public override string ToString() => _error?.ToString() ?? _value?.ToString() ?? "<NULL>";

    /// <summary>
    /// Matches the success status of the result to the corresponding functions.
    /// </summary>
    public TResult Match<TResult>(
        Func<TValue, TResult> success,
        Func<TError, TResult> failure)
    { 
        return !IsError ? success(_value!) : failure(_error!);
    }

    public Result<TResult, TError> Bind<TResult>(Func<TValue, Result<TResult, TError>> func)
    {
        if (IsSuccess)
            return func(_value);

        return _error;
    }
}
