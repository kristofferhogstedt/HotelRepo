namespace Hotel.src.ModelManagement.Services.Interfaces
{
    internal interface IInstantiatable<T>
    {
        T Instance { get; set; }
    }
}
