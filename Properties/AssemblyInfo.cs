using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Better Ingots")]
[assembly: AssemblyDescription("A mod based on ideas and assets from MoreIngots that adds more ingots to Subnautica, but with proper prefabs (3D objects).")]
[assembly: AssemblyCompany("https://github.com/Lord-of-the-Galaxy")]
[assembly: AssemblyProduct("Better Ingots")]
[assembly: AssemblyCopyright("Copyright ©  2020 Lord of Galaxy")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("080c0cc9-2c98-496f-b49f-bb79d52e906c")]

// Version information for this assembly consists of the following three values:
//
//      Major Version
//      Minor Version
//      Patch
[assembly: AssemblyVersion("1.0")] //major.minor
[assembly: AssemblyFileVersion("1.0.1")] //major.minor.patch
[assembly: AssemblyInformationalVersion("1.0.1a")] //major.minor[.patch[alpha/beta]]
/* Expect (not guaranteed):
 * Major version change: possibly broken backwards compatibility
 * Minor version change: the vanilla version is backwards compatible, but any derivatives of the mod may be broken
 * Patch change: should be interchangeable for the most part
 */
