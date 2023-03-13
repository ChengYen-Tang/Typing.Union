using System;

namespace Typing
{
    public abstract class Union<T1, T2, T3>
    {
        public T Item { get; private set; }
        public T1 Value1 { get; private set; }
        public T2 Value2 { get; private set; }
        public T3 Value3 { get; private set; }
        public Type Type { get; private set; }
        public abstract void MatchAction(Action<T1> action1, Action<T2> action2, Action<T3> action3);
        public abstract T MatchFunc<T>(Func<T1, T> func1, Func<T2, T> func2, Func<T3, T> func3);

        public Union(T1 value)
            => (Value1, Type, Item) = (value, typeof(T1), T.T1);

        public Union(T2 value)
            => (Value2, Type, Item) = (value, typeof(T2), T.T2);

        public Union(T3 value)
            => (Value3, Type, Item) = (value, typeof(T3), T.T3);

        public static implicit operator Union<T1, T2, T3>(T1 value)
            => new Case1(value);
        public static implicit operator Union<T1, T2, T3>(T2 value)
            => new Case2(value);
        public static implicit operator Union<T1, T2, T3>(T3 value)
            => new Case3(value);

        internal sealed class Case1 : Union<T1, T2, T3>
        {
            public Case1(T1 item) : base(item) { }
            public override void MatchAction(Action<T1> action1, Action<T2> action2, Action<T3> action3)
                => action1?.Invoke(Value1);
            public override T MatchFunc<T>(Func<T1, T> func1, Func<T2, T> func2, Func<T3, T> func3)
                => func1(Value1);
        }

        internal sealed class Case2 : Union<T1, T2, T3>
        {
            public Case2(T2 item) : base(item) { }
            public override void MatchAction(Action<T1> action1, Action<T2> action2, Action<T3> action3)
                => action2?.Invoke(Value2);
            public override T MatchFunc<T>(Func<T1, T> func1, Func<T2, T> func2, Func<T3, T> func3)
                => func2(Value2);
        }

        internal sealed class Case3 : Union<T1, T2, T3>
        {
            public Case3(T3 item) : base(item) { }
            public override void MatchAction(Action<T1> action1, Action<T2> action2, Action<T3> action3)
                => action3?.Invoke(Value3);
            public override T MatchFunc<T>(Func<T1, T> func1, Func<T2, T> func2, Func<T3, T> func3)
                => func3(Value3);
        }

        public enum T
        {
            T1 = 0,
            T2,
            T3
        }
    }
}
