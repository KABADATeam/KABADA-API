using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
    public class DocBookmark
    {
        public BookmarkStart bms;
        public BookmarkEnd bme;
        protected BLontext context;
        public DocBookmark(BLontext context) { this.context = context; }
        public void find(IEnumerable<BookmarkStart> bookmarkStarts, IEnumerable<BookmarkEnd> bookmarkEnds, string name)
        {
            bms = getbmStart(bookmarkStarts, name);
            var error = String.Format("Word template error! Bookmark {0} not found", name);
            if (bms == null) { context.logError(error);  }
            else {
                error = String.Format("Word template error! BookmarkEnd not found (name: {0}, id: {1})", bms.Name, bms.Id);
                bme = getbmEnd(bookmarkEnds, bms.Id);
                if (bme == null) { context.logError(error);  }              
            }
        }
        private BookmarkStart getbmStart(IEnumerable<BookmarkStart> bookmarks, string name) { return bookmarks.Where(i => i.Name == name).FirstOrDefault(); }
        private BookmarkEnd getbmEnd(IEnumerable<BookmarkEnd> bookmarks, string id) { return bookmarks.Where(i => i.Id == id).FirstOrDefault(); }

    }
}
