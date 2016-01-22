using System.Resources;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Markup;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Gu.Units.Wpf")]
[assembly: AssemblyDescription("IValueConverters for Gu.Units as MarkupExtensions")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Johan Larsson")]
[assembly: AssemblyProduct("Gu.Units.Wpf")]
[assembly: AssemblyCopyright("Copyright ©  2015")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("ea4bce51-a58d-4fa7-bba4-6f0056d753ca")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("0.7.3.0")]
[assembly: AssemblyFileVersion("0.7.3.0")]
[assembly:InternalsVisibleTo("Gu.Units.Wpf.Tests", AllInternalsVisible = true)]

[assembly: XmlnsDefinition("http://Gu.com/Units", clrNamespace: "Gu.Units", AssemblyName = "Gu.Units")]
[assembly: XmlnsDefinition("http://Gu.com/Units", clrNamespace: "Gu.Units.Wpf", AssemblyName = "Gu.Units.Wpf")]
[assembly: XmlnsPrefix("http://Gu.com/Units", "units")]
[assembly: NeutralResourcesLanguage("en")]