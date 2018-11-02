using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AsyncAwaitAnalysisCommon;

namespace WebApplicationNet461
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TestCase.RunTestTaskAsync().GetAwaiter().GetResult();
        }
    }
}