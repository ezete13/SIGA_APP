namespace SIGA.Application.Common;

public class AppResult<T>
{
    public bool IsSuccesss { get; set; }
    public T? Value { get; set; }

    public string? Error { get; set; }

    public static AppResult<T> Success(T value) =>
        new AppResult<T> { IsSuccesss = true, Value = value };

    public static AppResult<T> Failure(string error) =>
        new AppResult<T> { IsSuccesss = false, Error = error };
}
