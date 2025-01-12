namespace Hotel.src.ModelManagement.Utilities.Displayers
{
    public class ModelInfoDisplayer
    {
        public static void DisplayModelInfo<T>(T model)
        {
            Console.WriteLine("Model Info:");
            Console.WriteLine("Type: " + model.GetType().Name);
            Console.WriteLine("Properties:");
            foreach (var prop in model.GetType().GetProperties())
            {
                Console.WriteLine(prop.Name + ": " + prop.GetValue(model));
            }
        }
    }
}
