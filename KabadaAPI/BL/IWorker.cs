using System.Threading;
using System.Threading.Tasks;

namespace KabadaAPI {
  public interface IWorker {
    Task DoWork(CancellationToken cancellationToken);
    }
  }
