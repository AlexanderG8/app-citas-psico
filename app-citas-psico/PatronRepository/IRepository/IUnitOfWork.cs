namespace app_citas_psico.PatronRepository.IRepository
{
    /*
     IDisposable se utiliza para liberar de manera explícita recursos no administrados, 
     como archivos, conexiones a bases de datos o manejadores de red. Implementar IDisposable en una clase permite que 
     los recursos se liberen de forma controlada y oportuna mediante el método Dispose(), en lugar de depender únicamente 
     del recolector de basura, que puede no liberar los recursos de inmediato.
     */
    public interface IUnitOfWork : IDisposable
    {
        IOpcionesRepository Opciones { get; }
        IRolRepository Rol { get; }
        Task SaveAsync();
    }
}
