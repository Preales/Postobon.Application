using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Application.Common.Utility
{
    public static class Reflexion
    {
        public static PropertyInfo[] ListOfPropertiesFromInstance(Type AType)
        {
            return AType.GetProperties(BindingFlags.Public);
        }

        public static PropertyInfo[] ListOfPropertiesFromInstance(object InstanceOfAType)
        {
            if (InstanceOfAType == null) return null;
            Type TheType = InstanceOfAType.GetType();
            return TheType.GetProperties(BindingFlags.Public);
        }

        public static List<T> ListStaticValuesFromInstance<T>(this Type type)
        {
            return type
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(fi => fi.IsLiteral && !fi.IsInitOnly && fi.FieldType == typeof(T))
                .Select(x => (T)x.GetRawConstantValue())
                .ToList();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Tuple<string, string> GetCurrentMethod()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(1);

            return new Tuple<string, string>(sf.GetMethod().Name, sf.GetMethod().DeclaringType.FullName);
        }
    }
}
