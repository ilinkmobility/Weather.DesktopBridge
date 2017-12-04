using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Storage;

namespace Weather.WinForm
{
    public class CompilerHelper
    {
        private static CompilerHelper instance;

        private CodeDomProvider codeProvider;

        public string CompiledDllPath { get; set; }

        private CompilerHelper()
        {
            codeProvider = CodeDomProvider.CreateProvider("CSharp");
        }

        public static CompilerHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CompilerHelper();
                }
                return instance;
            }
        }
        public string Compile(string source)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;

            CompiledDllPath = localFolder.Path + @"\DynamicAssembly.dll";

            CompilerParameters parameters = new CompilerParameters
            {
                GenerateExecutable = false,
                GenerateInMemory = true,
                OutputAssembly = CompiledDllPath
                //OutputAssembly = @"C:\Users\ramanans\Documents\DLL\DynamicAssembly.dll"
            };

            parameters.ReferencedAssemblies.Add("System.dll");
            parameters.ReferencedAssemblies.Add("System.Core.dll");
            parameters.ReferencedAssemblies.Add("System.Drawing.dll");
            parameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");

            CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, source);

            string result = string.Empty;

            if (results.Errors.Count > 0)
            {
                foreach (CompilerError CompErr in results.Errors)
                {
                    result += "Line number " + CompErr.Line
                        + ", Error Number: " + CompErr.ErrorNumber
                        + ", '" + CompErr.ErrorText + ";\n\n";
                };

                return result;
            }
            else
            {
                //CompiledDllPath = results.CompiledAssembly.CodeBase.Replace("file:///", "");

                //MessageBox.Show(CompiledDllPath, "Compiled Path", MessageBoxButtons.OK);

                return CompiledDllPath;
            }
        }

        public Type GetAssembly()
        {
            var assembly = Assembly.LoadFile(CompiledDllPath);

            return assembly.GetTypes()[0];
        }

        public void InvokeConstructor()
        {
            try
            {
                Type type = GetAssembly();
                ConstructorInfo ctor = type.GetConstructor(Type.EmptyTypes);
                ctor.Invoke(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK);
            }
        }
    }
}
