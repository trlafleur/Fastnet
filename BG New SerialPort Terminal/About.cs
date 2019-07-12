#region Namespace Inclusions
using System;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
#endregion

namespace BGTerminal
{
  public partial class frmAbout : Form
  {
    private string TempFile = Path.GetTempFileName();

      public frmAbout()
      {
          InitializeComponent();
      }

      
      
  }
}