Delegate : Its a signature of a function/method.
```csharp

//defining a delegate
public delegate void DoSomething(int num);

//Just a normal function which has the signature similar to our delegate
private void myFunction(int num){
    Console.WriteLine("Hey there");
}

//Object of delegate. this can refer to any function which matches the signature of delegate
public DoSomething fun;

//Assigning a function to delegate object
fun = myFunction;

//Invoking the delegate obj
if(fun!=null) fun(5);
//Another way to invoke delegate object. (using null propagation )
fun?.Invoke();

```

We can assign multiple functions to the delegate object(Subscribing)
```csharp

private void myFunction2(int num){
    Console.WriteLine("Hey there Again");
}

//Assigning multiple functions to delegate object. use (+=) operator
fun += myFunction2;

```

Action : is a delegate with `return type void`.
```csharp
public Action<int> fun;

fun += myFunction1;
fun += myFunction2;

fun(3)

```

Event keyword : It locks down some functionality of our delegate/action. Using the `event` keyword before `Action` makes sure that it can never be assigned any value. It can only be subscribed.
Also it also makes sure that the action is not being invoked from other class than the class in which it has been defined.

So our event/action can obly be subscribed from other classed and it can only be invoked from the creator class.
