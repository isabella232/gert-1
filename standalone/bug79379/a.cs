public interface IA<T> where T : IA<T>
{
}

public interface IB<T> : IA<T> where T : IA<T>
{
}

public struct S<T> : IB<S<T>>
{
}
