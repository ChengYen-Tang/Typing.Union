using System;

namespace Typing
{
    public abstract class Union<T1, T2, T3, T4>
    {
        public T1 Value1 { get; private set; }
        public T2 Value2 { get; private set; }
        public T3 Value3 { get; private set; }
        public T4 Value4 { get; private set; }
        public Type Type { get; private set; }
        public abstract void MatchAction(Action<T1> action1, Action<T2> action2, Action<T3> action3, Action<T4> action4);
        public abstract T MatchFunc<T>(Func<T1, T> func1, Func<T2, T> func2, Func<T3, T> func3, Func<T4, T> func4);

        public Union(T1 value)
            => (Value1, Type) = (value, typeof(T1));

        public Union(T2 value)
            => (Value2, Type) = (value, typeof(T2));

        public Union(T3 value)
            => (Value3, Type) = (value, typeof(T3));

        public Union(T4 value)
            => (Value4, Type) = (value, typeof(T4));

        public static implicit operator Union<T1, T2, T3, T4>(T1 value)
            => new Case1(value);
        public static implicit operator Union<T1, T2, T3, T4>(T2 value)
            => new Case2(value);
        public static implicit operator Union<T1, T2, T3, T4>(T3 value)
            => new Case3(value);
        public static implicit operator Union<T1, T2, T3, T4>(T4 value)
            => new Case4(value);

        internal sealed class Case1 : Union<T1, T2, T3, T4>
        {
            public Case1(T1 item) : base(item) { }
            public override void MatchAction(Action<T1> action1, Action<T2> action2, Action<T3> action3, Action<T4> action4)
                => action1?.Invoke(Value1);
            public override T MatchFunc<T>(Func<T1, T> func1, Func<T2, T> func2, Func<T3, T> func3, Func<T4, T> func4)
                => func1(Value1);
        }

        internal sealed class Case2 : Union<T1, T2, T3, T4>
        {
            public Case2(T2 item) : base(item) { }
            public override void MatchAction(Action<T1> action1, Action<T2> action2, Action<T3> action3, Action<T4> action4)
                => action2?.Invoke(Value2);
            public override T MatchFunc<T>(Func<T1, T> func1, Func<T2, T> func2, Func<T3, T> func3, Func<T4, T> func4)
                => func2(Value2);
        }

        internal sealed class Case3 : Union<T1, T2, T3, T4>
        {
            public Case3(T3 item) : base(item) { }
            public override void MatchAction(Action<T1> action1, Action<T2> action2, Action<T3> action3, Action<T4> action4)
                => action3?.Invoke(Value3);
            public override T MatchFunc<T>(Func<T1, T> func1, Func<T2, T> func2, Func<T3, T> func3, Func<T4, T> func4)
                => func3(Value3);
        }

        internal sealed class Case4 : Union<T1, T2, T3, T4>
        {
            public Case4(T4 item) : base(item) { }
            public override void MatchAction(Action<T1> action1, Action<T2> action2, Action<T3> action3, Action<T4> action4)
                => action4?.Invoke(Value4);
            public override T MatchFunc<T>(Func<T1, T> func1, Func<T2, T> func2, Func<T3, T> func3, Func<T4, T> func4)
                => func4(Value4);
        }
    }
}
