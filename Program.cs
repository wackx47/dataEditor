using System.ComponentModel;
using System.Reflection;

namespace dataEditor
{
    public static class PropertyDescriptorExtensions
    {
        public static void SetReadOnlyAttribute(this PropertyDescriptor p, bool value)
        {
            var attributes = p.Attributes.Cast<Attribute>()
                .Where(x => !(x is ReadOnlyAttribute)).ToList();
            attributes.Add(new ReadOnlyAttribute(value));
            typeof(MemberDescriptor).GetProperty("AttributeArray",
                BindingFlags.Instance | BindingFlags.NonPublic)
                .SetValue((MemberDescriptor)p, attributes.ToArray());
        }
    }

    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }



        public partial class NativeMethods
        {
            public static Int32 STD_OUTPUT_HANDLE = -11;

            [System.Runtime.InteropServices.DllImportAttribute("kernel32.dll", EntryPoint = "GetStdHandle")]
            public static extern System.IntPtr GetStdHandle(Int32 nStdHandle);

            [System.Runtime.InteropServices.DllImportAttribute("kernel32.dll", EntryPoint = "AllocConsole")]
            [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
            public static extern bool AllocConsole();
        }


    }
}