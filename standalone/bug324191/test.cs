/// <summary>Some generic class.</summary>
/// <typeparam name="T">Some arbitrary type.</typeparam>
public class G<T>
{
}

/// <summary>Test class.</summary>
/// <remarks>
/// <para>
/// Compiler objects to this cref attribute: <see cref="G {T}" />.
/// </para>
/// <para>
/// Compiler objects to this cref attribute: <see cref="G &lt;T&gt;" />.
/// </para>
/// </remarks>
public class Test
{
}
