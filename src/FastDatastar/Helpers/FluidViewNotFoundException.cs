namespace FastDatastar.Helpers;

[Serializable]
public class FluidViewNotFoundException : Exception
{
    public FluidViewNotFoundException()
    {
    }

    public FluidViewNotFoundException(string? message) : base(message)
    {
    }

    public FluidViewNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}