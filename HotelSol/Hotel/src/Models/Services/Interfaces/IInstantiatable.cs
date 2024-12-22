namespace Hotel.src.Models.Services.Interfaces
{
    internal interface IInstantiatable<T>
    {
        T Instance { get; set; }
    }
}
