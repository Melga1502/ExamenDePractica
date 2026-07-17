namespace Whoop.HardwareTelemetry.Platform.u202315165.Shared.Application.Model;

/// <summary>
///     Represents an operation result with a value or an error.
/// </summary>
/// <typeparam name="T">Type of the returned value.</typeparam>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public class Result<T>
{
    protected Result(bool isSuccess, T? value, string message, Enum? error)
    {
        IsSuccess = isSuccess;
        Value = value;
        Message = message;
        Error = error;
    }

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public T? Value { get; }
    public string Message { get; }
    public Enum? Error { get; }

    /// <summary>
    ///     Creates a successful result.
    /// </summary>
    /// <param name="value">Returned value.</param>
    /// <returns>A successful result.</returns>
    public static Result<T> Success(T value)
    {
        return new Result<T>(true, value, string.Empty, null);
    }

    /// <summary>
    ///     Creates a failed result.
    /// </summary>
    /// <param name="error">Error code.</param>
    /// <param name="message">Error message.</param>
    /// <returns>A failed result.</returns>
    public static Result<T> Failure(Enum error, string message)
    {
        return new Result<T>(false, default, message, error);
    }
}

/// <summary>
///     Represents an operation result without a value.
/// </summary>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public class Result : Result<object>
{
    private Result(bool isSuccess, string message, Enum? error) : base(isSuccess, null, message, error)
    {
    }

    /// <summary>
    ///     Creates a successful result.
    /// </summary>
    /// <returns>A successful result.</returns>
    public static Result Success()
    {
        return new Result(true, string.Empty, null);
    }

    /// <summary>
    ///     Creates a failed result.
    /// </summary>
    /// <param name="error">Error code.</param>
    /// <param name="message">Error message.</param>
    /// <returns>A failed result.</returns>
    public new static Result Failure(Enum error, string message)
    {
        return new Result(false, message, error);
    }
}
