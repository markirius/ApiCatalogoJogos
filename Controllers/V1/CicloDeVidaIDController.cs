using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CicloDeVidaIDController : ControllerBase
    {
        public readonly ISingleton _exemploSingleton1;
        public readonly ISingleton _exemploSingleton2;

        public readonly IScoped _exemploScoped1;
        public readonly IScoped _exemploScoped2;

        public readonly ITransient _exemploTransient1;
        public readonly ITransient _exemploTransient2;

        public CicloDeVidaIDController(ISingleton exemploSingleton1,
                                       ISingleton exemploSingleton2,
                                       IScoped exemploScoped1,
                                       IScoped exemploScoped2,
                                       ITransient exemploTransient1,
                                       ITransient exemploTransient2)
        {
            _exemploSingleton1 = exemploSingleton1;
            _exemploSingleton2 = exemploSingleton2;
            _exemploScoped1 = exemploScoped1;
            _exemploScoped2 = exemploScoped2;
            _exemploTransient1 = exemploTransient1;
            _exemploTransient2 = exemploTransient2;
        }

        [HttpGet]
        public Task<string> Get()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Singleton 1: {_exemploSingleton1.Id}");
            stringBuilder.AppendLine($"Singleton 2: {_exemploSingleton2.Id}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"Scoped 1: {_exemploScoped1.Id}");
            stringBuilder.AppendLine($"Scoped 2: {_exemploScoped2.Id}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"Transient 1: {_exemploTransient1.Id}");
            stringBuilder.AppendLine($"Transient 2: {_exemploTransient2.Id}");

            return Task.FromResult(stringBuilder.ToString());
        }

    }

    public interface IGeral
    {
        public Guid Id { get; }
    }

    public interface ISingleton :IGeral
    { }

    public interface IScoped : IGeral
    { }

    public interface ITransient : IGeral
    { }

    public class CicloDeVida : ISingleton, IScoped, ITransient
    {
        private readonly Guid _guid;

        public CicloDeVida()
        {
            _guid = Guid.NewGuid();
        }

        public Guid Id => _guid;
    }

}
