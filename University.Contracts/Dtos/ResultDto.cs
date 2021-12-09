
public struct ResultDto
{
    public ResultDto(long id, bool isSuccess)
    {
        StudentId = id;
        IsSuccess = isSuccess;
    }

    public long StudentId { get; }
    public bool IsSuccess { get; }
}
