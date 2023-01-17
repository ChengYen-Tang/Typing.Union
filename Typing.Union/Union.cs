using System;

namespace Typing
{
    public abstract class Union<T1, T2>
    {
        public T1 Value1 { get; private set; }
        public T2 Value2 { get; private set; }
        public Type Type { get; private set; }
        public abstract void MatchAction(Action<T1> action1, Action<T2> action2);
        public abstract T MatchFunc<T>(Func<T1, T> func1, Func<T2, T> func2);

        public Union(T1 value)
            => (Value1, Type) = (value, typeof(T1));

        public Union(T2 value)
            => (Value2, Type) = (value, typeof(T2));

        public static implicit operator Union<T1, T2>(T1 value)
            => new Case1(value);
        public static implicit operator Union<T1, T2>(T2 value)
            => new Case2(value);

        internal sealed class Case1 : Union<T1, T2>
        {
            public Case1(T1 item) : base(item) { }
            public override void MatchAction(Action<T1> action1, Action<T2> action2)
                => action1?.Invoke(Value1);
            public override T MatchFunc<T>(Func<T1, T> func1, Func<T2, T> func2)
                => func1(Value1);
        }

        internal sealed class Case2 : Union<T1, T2>
        {
            public Case2(T2 item) : base(item) { }
            public override void MatchAction(Action<T1> action1, Action<T2> action2)
                => action2?.Invoke(Value2);
            public override T MatchFunc<T>(Func<T1, T> func1, Func<T2, T> func2)
                => func2(Value2);
        }
    }
}
