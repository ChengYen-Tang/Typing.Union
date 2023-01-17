using System;

namespace Typing
{
    public abstract class Union<T1, T2, T3, T4, T5, T6, T7>
    {
        public T1 Value1 { get; private set; }
        public T2 Value2 { get; private set; }
        public T3 Value3 { get; private set; }
        public T4 Value4 { get; private set; }
        public T5 Value5 { get; private set; }
        public T6 Value6 { get; private set; }
        public T7 Value7 { get; private set; }
        public Type Type { get; private set; }
        public abstract void MatchAction(Action<T1> action1, Action<T2> action2, Action<T3> action3, Action<T4> action4, Action<T5> action5, Action<T6> action6, Action<T7> action7);
        public abstract T MatchFunc<T>(Func<T1, T> func1, Func<T2, T> func2, Func<T3, T> func3, Func<T4, T> func4, Func<T5, T> func5, Func<T6, T> func6, Func<T7, T> func7);

        public Union(T1 value)
            => (Value1, Type) = (value, typeof(T1));

        public Union(T2 value)
            => (Value2, Type) = (value, typeof(T2));

        public Union(T3 value)
            => (Value3, Type) = (value, typeof(T3));

        public Union(T4 value)
            => (Value4, Type) = (value, typeof(T4));

        public Union(T5 value)
            => (Value5, Type) = (value, typeof(T5));

        public Union(T6 value)
            => (Value6, Type) = (value, typeof(T6));

        public Union(T7 value)
            => (Value7, Type) = (value, typeof(T7));

        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T1 value)
            => new Case1(value);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T2 value)
            => new Case2(value);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T3 value)
            => new Case3(value);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T4 value)
            => new Case4(value);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T5 value)
            => new Case5(value);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T6 value)
            => new Case6(value);
        public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7>(T7 value)
            => new Case7(value);

        internal sealed class Case1 : Union<T1, T2, T3, T4, T5, T6, T7>
        {
            public Case1(T1 item) : base(item) { }
            public override void MatchAction(Action<T1> action1, Action<T2> action2, Action<T3> action3, Action<T4> action4, Action<T5> action5, Action<T6> action6, Action<T7> action7)
                => action1?.Invoke(Value1);
            public override T MatchFunc<T>(Func<T1, T> func1, Func<T2, T> func2, Func<T3, T> func3, Func<T4, T> func4, Func<T5, T> func5, Func<T6, T> func6, Func<T7, T> func7)
                => func1(Value1);
        }

        internal sealed class Case2 : Union<T1, T2, T3, T4, T5, T6, T7>
        {
            public Case2(T2 item) : base(item) { }
            public override void MatchAction(Action<T1> action1, Action<T2> action2, Action<T3> action3, Action<T4> action4, Action<T5> action5, Action<T6> action6, Action<T7> action7)
                => action2?.Invoke(Value2);
            public override T MatchFunc<T>(Func<T1, T> func1, Func<T2, T> func2, Func<T3, T> func3, Func<T4, T> func4, Func<T5, T> func5, Func<T6, T> func6, Func<T7, T> func7)
                => func2(Value2);
        }

        internal sealed class Case3 : Union<T1, T2, T3, T4, T5, T6, T7>
        {
            public Case3(T3 item) : base(item) { }
            public override void MatchAction(Action<T1> action1, Action<T2> action2, Action<T3> action3, Action<T4> action4, Action<T5> action5, Action<T6> action6, Action<T7> action7)
                => action3?.Invoke(Value3);
            public override T MatchFunc<T>(Func<T1, T> func1, Func<T2, T> func2, Func<T3, T> func3, Func<T4, T> func4, Func<T5, T> func5, Func<T6, T> func6, Func<T7, T> func7)
                => func3(Value3);
        }

        internal sealed class Case4 : Union<T1, T2, T3, T4, T5, T6, T7>
        {
            public Case4(T4 item) : base(item) { }
            public override void MatchAction(Action<T1> action1, Action<T2> action2, Action<T3> action3, Action<T4> action4, Action<T5> action5, Action<T6> action6, Action<T7> action7)
                => action4?.Invoke(Value4);
            public override T MatchFunc<T>(Func<T1, T> func1, Func<T2, T> func2, Func<T3, T> func3, Func<T4, T> func4, Func<T5, T> func5, Func<T6, T> func6, Func<T7, T> func7)
                => func4(Value4);
        }

        internal sealed class Case5 : Union<T1, T2, T3, T4, T5, T6, T7>
        {
            public Case5(T5 item) : base(item) { }
            public override void MatchAction(Action<T1> action1, Action<T2> action2, Action<T3> action3, Action<T4> action4, Action<T5> action5, Action<T6> action6, Action<T7> action7)
                => action5?.Invoke(Value5);
            public override T MatchFunc<T>(Func<T1, T> func1, Func<T2, T> func2, Func<T3, T> func3, Func<T4, T> func4, Func<T5, T> func5, Func<T6, T> func6, Func<T7, T> func7)
                => func5(Value5);
        }

        internal sealed class Case6 : Union<T1, T2, T3, T4, T5, T6, T7>
        {
            public Case6(T6 item) : base(item) { }
            public override void MatchAction(Action<T1> action1, Action<T2> action2, Action<T3> action3, Action<T4> action4, Action<T5> action5, Action<T6> action6, Action<T7> action7)
                => action6?.Invoke(Value6);
            public override T MatchFunc<T>(Func<T1, T> func1, Func<T2, T> func2, Func<T3, T> func3, Func<T4, T> func4, Func<T5, T> func5, Func<T6, T> func6, Func<T7, T> func7)
                => func6(Value6);
        }

        internal sealed class Case7 : Union<T1, T2, T3, T4, T5, T6, T7>
        {
            public Case7(T7 item) : base(item) { }
            public override void MatchAction(Action<T1> action1, Action<T2> action2, Action<T3> action3, Action<T4> action4, Action<T5> action5, Action<T6> action6, Action<T7> action7)
                => action7?.Invoke(Value7);
            public override T MatchFunc<T>(Func<T1, T> func1, Func<T2, T> func2, Func<T3, T> func3, Func<T4, T> func4, Func<T5, T> func5, Func<T6, T> func6, Func<T7, T> func7)
                => func7(Value7);
        }
    }
}
