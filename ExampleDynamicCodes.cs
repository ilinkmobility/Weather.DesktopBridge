using System;
using System.Windows.Forms;

namespace Weather.WinForm
{
	public class DynamicClass
	{
		public string Name = "DynamicClass";
		
		public DynamicClass()
		{
			MessageBox.Show("Example", "Info", MessageBoxButtons.OK);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

using Weather.WinForm;

namespace Weather.WinForm
{
	public class DynamicClass
	{
		public string Name = "DynamicClass";
		
		public DynamicClass()
		{
			try
			{				
				List<Assembly> assembliesLoadedBefore = AppDomain.CurrentDomain.GetAssemblies().ToList<Assembly>();
				
				string all = string.Empty;
				
				foreach(var assembly in assembliesLoadedBefore)
				{
					all += assembly.FullName + "\n\n";
				}
				
				MessageBox.Show(all, "Info", MessageBoxButtons.OK);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK);
			}
		}
	}
}

using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Policy;

using Weather.WinForm;

namespace Weather.WinForm
{
	public class DynamicClass
	{
		public string Name = "DynamicClass";
		
		public DynamicClass()
		{
			try
			{
				AppDomain currentDomain = AppDomain.CurrentDomain;
				
				Evidence asEvidence = currentDomain.Evidence;
				
				currentDomain.Load("DynamicClass", asEvidence);
				
				//List<Assembly> assembliesLoadedBefore = AppDomain.CurrentDomain.GetAssemblies().ToList<Assembly>();
				
				//string all = string.Empty;
				
				//foreach(var assembly in assembliesLoadedBefore)
				//{
				//	all += assembly.FullName + "\n\n";
				//}
				
				MessageBox.Show("Test", "Info", MessageBoxButtons.OK);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK);
			}
		}
	}
}

using System;

using Weather.WinForm;

public class Test
{
	public Test()
	{
		var name = "dynamic";
		
		var weather = Weather();
	}
}










using System;
using System.Windows.Forms;
using System.Drawing;

public class MyForm
{
    public MyForm()
    {
		Form myFrm = new Form();
        myFrm.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        myFrm.ClientSize = new System.Drawing.Size(292, 273);
        myFrm.Text = "My First Windows Application";
        myFrm.ResumeLayout(false);
        Application.Run(myFrm);
    }
}


