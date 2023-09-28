using System.Reflection.Metadata;

namespace Monad.Monads;

//Value Semantics: structs have value semantics, which means they are copied when passed as arguments or assigned to new variables.
//This behavior is suitable for monads like Maybe because it ensures that you work with independent copies of the monad, avoiding unintended side effects.

// Lightweight: structs are typically more memory-efficient than classes because they don't involve reference overhead.
// This can be beneficial when you're creating and working with many instances of the Maybe monad.

//Nullability Handling: In the Maybe monad example, the goal is to handle nullable or optional values.
//Struct makes it clear that the Maybe instance itself is not nullable (unlike a reference type where the instance itself can be null),
//but the Maybe can represent either a value or no value. This aligns with the goal of explicitly handling nullability.

//Maybe<number> = a number or nothing
//Maybe<User> = a User or nothing

//Aka Option, Nullable

// !!! When null is not allowed, any API contract gets more explicit: either you return type T and it’s always going to be filled, or you return Maybe<T>.
//The client will see that Maybe type is used, so it will be forced to handle the case of absent value.
public struct Maybe<TValue>
{
    private readonly TValue _value;
    private readonly bool _hasValue;

    private Maybe(TValue value)
    {
        _value = value;
        _hasValue = true;
    }

    public static Maybe<TValue> Some(TValue value)
    {
        return new Maybe<TValue>(value);
    }

    public static Maybe<TValue> None()
    {
        return new Maybe<TValue>();
    }

    public bool HasValue => _hasValue;

    public TResult Match<TResult>(Func<TValue, TResult> some, Func<TResult> none)
    {
        return _hasValue ? some(_value) : none();
    }

    public Maybe<TResult> Bind<TResult>(Func<TValue, Maybe<TResult>> func)
    {
        return _hasValue ? func(_value) : Maybe<TResult>.None();
    }

    public Maybe<TResult> Map<TResult>(Func<TValue, TResult> transform)
    {
        if (_hasValue)
        {
            return Maybe<TResult>.Some(transform(_value));
        }
        else
        {
            return Maybe<TResult>.None();
        }
    }

    public TValue Reduce(TValue defaultValue) => _value ?? defaultValue;
}
