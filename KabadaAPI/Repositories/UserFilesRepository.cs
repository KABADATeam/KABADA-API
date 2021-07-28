﻿using System.Linq;

namespace KabadaAPI {
  public class UserFilesRepository : BaseRepository {
        public UserFilesRepository(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) {}

     protected override object[] getAll4snap() { return daContext.UserFiles.ToArray(); }
    }
  }
