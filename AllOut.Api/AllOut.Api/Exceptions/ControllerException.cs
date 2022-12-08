namespace Puregold.API.Exceptions
{
    [Serializable]
    public class ControllerException : Exception
    {
        public ControllerException() { }
        public ControllerException(string message) : base(message) { }
    }
}
