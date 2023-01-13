using System;

namespace Type
{
    public abstract class Union<T1, T2, T3>
    {
        public abstract void MatchAction(Action<T1> action1, Action<T2> action2, Action<T3> action3);
        public abstract T MatchFunc<T>(Func<T1, T> func1, Func<T2, T> func2, Func<T3, T> func3);

        public static implicit operator Union<T1, T2, T3>(T1 value)
            => new Case1(value);
        public static implicit operator Union<T1, T2, T3>(T2 value)
            => new Case2(value);
        public static implicit operator Union<T1, T2, T3>(T3 value)
            => new Case3(value);

        internal sealed class Case1 : Union<T1, T2, T3>
        {
            public readonly T1 item;
            public Case1(T1 item) : base() => this.item = item;
            public override void MatchAction(Action<T1> action1, Action<T2> action2, Action<T3> action3)
                => action1?.Invoke(item);
            public override T MatchFunc<T>(Func<T1, T> func1, Func<T2, T> func2, Func<T3, T> func3)
                => func1(item);
        }

        internal sealed class Case2 : Union<T1, T2, T3>
        {
            public readonly T2 item;
            public Case2(T2 item) : base() => this.item = item;
            public override void MatchAction(Action<T1> action1, Action<T2> action2, Action<T3> action3)
                => action2?.Invoke(item);
            public override T MatchFunc<T>(Func<T1, T> func1, Func<T2, T> func2, Func<T3, T> func3)
                => func2(item);
        }

        internal sealed class Case3 : Union<T1, T2, T3>
        {
            public readonly T3 item;
            public Case3(T3 item) : base() => this.item = item;
            public override void MatchAction(Action<T1> action1, Action<T2> action2, Action<T3> action3)
                => action3?.Invoke(item);
            public override T MatchFunc<T>(Func<T1, T> func1, Func<T2, T> func2, Func<T3, T> func3)
                => func3(item);
        }
    }
}
