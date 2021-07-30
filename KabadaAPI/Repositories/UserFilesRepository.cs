﻿using System;
using System.Linq;

namespace KabadaAPI {
  public class UserFilesRepository : BaseRepository {
        public UserFilesRepository(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) {}

    protected override object[] getAll4snap() { return daContext.UserFiles.ToArray(); }
    protected override string myTable => "UserFiles";

    protected override bool loadData(string json, bool overwrite, bool oldDeleted) {
      return loadDataRow<KabadaAPIdao.UserFile, Guid>(daContext.UserFiles, json, overwrite, oldDeleted);
      }

    //protected override bool loadData(string json, bool overwrite) {
    //  var o=Newtonsoft.Json.JsonConvert.DeserializeObject<KabadaAPIdao.UserFile>(json);
    //  daContext.UserFiles.Add(o);
    //  return true;
    //  }
    }
  }