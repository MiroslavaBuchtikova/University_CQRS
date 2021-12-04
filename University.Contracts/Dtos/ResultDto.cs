
public struct ResultDto
{
    public ResultDto(long id, bool isSuccess)
    {
        Id = id;
        IsSuccess = isSuccess;
    }

    public long Id { get; }
    public bool IsSuccess { get; }
}
