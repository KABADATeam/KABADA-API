using KabadaAPI.BL;

namespace KabadaAPI.ViewModels {
  partial class ResourceSubType {

    internal void fill(Tertex tvo) {
      id=tvo.me.Id;
      title=tvo.me.Value;
      }
    }
  }
