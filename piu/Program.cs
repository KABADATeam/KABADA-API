using System.Threading.Tasks;

namespace piu {
  class Program {
    static async Task Main(string[] args) {
      await new Performer().go(args);
      }
    }
  }
