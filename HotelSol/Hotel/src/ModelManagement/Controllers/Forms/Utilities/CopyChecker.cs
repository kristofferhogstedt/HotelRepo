namespace Hotel.src.ModelManagement.Controllers.Forms.Utilities
{
    public class CopyChecker
    {
        public static bool CheckCopyValue(object value)
        {
            return value.ToString() == "-1";
        }
    }
}
