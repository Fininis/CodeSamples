using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernUINavigationApp.NewsApp {
    class DirectoryListing {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string Path { get; set; }

        public DirectoryListing(string Name, string Title, string Date, string Path) {
            this.Name = Name;
            this.Title = Title;
            this.Date = Date;
            this.Path = Path;
        }
    }
}
