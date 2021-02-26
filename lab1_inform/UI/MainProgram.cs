using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab1_inform.UI.Pages;

namespace lab1_inform.UI
{
    public class MainProgram : EasyConsoleCore.Program
    {
        public MainProgram()
        : base("EasyConsole Demo", breadcrumbHeader: true)
        {
            AddPage(new MainPage(this));
            AddPage(new EntitySelectionPage(this));
            AddPage(new CSVConnectionProposal(this));
            AddPage(new SQLConnectionPoposal(this));
            AddPage(new DataViewPage(this));
            AddPage(new DeleteRecordPage(this));
            AddPage(new EditRecordPage(this));

            SetPage<MainPage>();
        }
    }
}
