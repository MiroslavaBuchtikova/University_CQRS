public struct ResultDto
{
    public ResultDto(bool isSuccess)
    {
        IsSuccess = isSuccess;
    }
    public bool IsSuccess { get; }
}
