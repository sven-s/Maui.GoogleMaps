using Android.Runtime;

namespace Maui.GoogleMaps.Android.Extensions;

internal static class EnumerableExtensions
{
    public static JavaList<T> ToJavaList<T>(this IEnumerable<T> self)
    {
        var array = new JavaList<T>();
        foreach (var item in self ?? Array.Empty<T>())
        {
            array.Add(item);
        }

        return array;
    }
}