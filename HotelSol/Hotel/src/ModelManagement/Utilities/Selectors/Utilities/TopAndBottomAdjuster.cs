namespace Hotel.src.ModelManagement.Utilities.Selectors.Utilities
{
    public class TopAndBottomAdjuster
    {
        /// To Adjust for if index goes outside the bounds of the list(Array)
        public static void AdjustTopBottom(ref int selectedIndex, int listLength)
        {
            if (selectedIndex < 0)
            {
                selectedIndex = listLength - 1;
            }
            else if (selectedIndex >= listLength)
            {
                selectedIndex = 0;
            }
        }
    }
}
