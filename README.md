# Logic Tag Helpers

Tag helpers to provide control logic inside of cshtml pages.

| CI Build | Publish Build | NuGet Package |
| :------: | :-----------: | :-----------: |
| [![.NET](https://github.com/StuffOfInterest/LogicTagHelpers/actions/workflows/build-test.yml/badge.svg)](https://github.com/StuffOfInterest/LogicTagHelpers/actions/workflows/build-test.yml) | [![.NET](https://github.com/StuffOfInterest/LogicTagHelpers/actions/workflows/build-test-publish.yml/badge.svg)](https://github.com/StuffOfInterest/LogicTagHelpers/actions/workflows/build-test-publish.yml) | [![NuGet](https://img.shields.io/nuget/v/LogicTagHelpers.svg)](https://www.nuget.org/packages/LogicTagHelpers/) |

## Introduction

[Tag Helpers](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/intro) bring integration of server side code and HTML rendering.
One thing missing is the ability to control logic flow (branching and looping) without falling back on embedded C# code inside of the HTML markup,
via CSHTML. **Logic Tag Helpers** provides two selection ("if" and "switch") and four iteration ("while", "do", "for", and "foreach") tags that can
allow creation of complex CSHTML pages with minimal embedded C# code.

Use of these tags is simple. First, import the [NuGet package](https://www.nuget.org/packages/LogicTagHelpers/). Next, [add one line](#installation)
to the `_ViewImports.cshtml` file. Finally, add [the tags](#tag-definitions).  The branch tags require no external C# code, although expressions can
be used for setitng conditions. The looping tags will require at least one line to setup a variable, but most logic can be defined with
[lambda expressions](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions) instead of function references.

## Tags

All six tags are derived from their C# language definitions.

* Selection Statements
  * [if](#if) ([reference](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/if-else))
    * then
    * else
  * [switch](#switch) ([reference](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/switch))
    * case
* Iteration Statements
  * [while](#while) ([reference](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/while))
  * [do](#do) ([reference](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/do))
  * [for](#for) ([reference](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/for))
  * [foreach](#foreach) ([reference](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/foreach-in))

## Installation

Following line must be added to the `_ViewImports.cshtml` file for the logic tag helpers to be available.

```
@addTagHelper *, LogicTagHelpers
```

## Tag Definitions

Below are simple examples for each of the logic tags.

### if

Basic if/then/else may have at most one `then` and one `else` tag inside the `if` tag.

```cshtml
<if condition="Model.IsApproved">
   <then><p>The purchase was approved.</p></then>
   <else><p>The vendor declined your purchase.</p></else>
</if>
```

It is also possible to do an `if` tag with content directly nested inside.  However, if this is done the inner content will be evaluated
although it may not be displayed if the condition is false.  To avoid this behavior, add the `direct="true"` attribute to the `if` tag 
to prevent evaulation unless the condition is met.

```cshtml
@{ var isCanceled = Model.IsOrdered && !Model.IsPaid; }
<if condition="isCanceled" direct="true">
   <p>Order was canceled due to non-payment on @Model.CancelDate.</p>
</if>
```

### switch

There are two restrictions for the `switch` tag.  First, the value attribute on the `case` tags must be of the same type as what the
expression attribute on the `switch` tag evaluates to.  Second, the value for each `case` tag may only appear once, which includes the
catch all in the `default` tag.

```cshtml
<switch expression="Model.OrderStatusId">
   <case value="1"><p>Your order has been placed.</p></case>
   <case value="2"><p>Your order has been shipped.</p></case>
   <default><p>We don't know what happened to your order!</p></default>
</switch>
```

### while

For a `while` loop, a control variable needs to be established outside of the loop and then a function,
usually presented as a lambda expression, is evaluated before each pass through the loop.

```cshtml
@{ var x = 0; }
<while condition="() => x < 10">
   <p>This is line @x.</p>
   @{ x++; }
</while>
```

### do

For a `do` loop, a control variable needs to be established outside of the loop and then a function,
usually presented as a lambda expression, is evaluated after each pass through the loop.

```cshtml
@{ var x = 0; }
<do condition="() => x < 10">
   @{ x++; }
   <p>This is line @x.</p>
</do>
```

### for

A `for` loop contains three attributes, an initialization, a condition test, and an update. Only the condition test is 
required as there is no way to exit the loop without one.

```cshtml
@{ int x = default; }
<for initialize="() => x = 0" condition="() => x < 10" update="() => x++">
   <span>content to display while condition is true</span>
</for>
```

### foreach

The `foreach` requires a context object in order to hanlde iteration across a set of values. The context, a `ForeachContext` 
object, must be initialized before the loop and passed in as the `iterator` attribute. Inside of the loop, the `Item` property 
will be updated with the current item from the collection to operator on.

```cshtml
@{ var context = new ForeachContext<int>(Model.Numbers); }
<foreach iterator="context">
   <p>This is line @context.Item.</p>
</foreach>
```

## Future

The only future features which may be added are a `continue` and a `break` tag for the loops to implement
the same logic available in the C# language.

## Contributing

If you wish to help with this project, you may [submit an issue](https://github.com/StuffOfInterest/LogicTagHelpers/issues)
to let me know what needs fixed or added to the library.  You may also
[submit a pull request](https://github.com/StuffOfInterest/LogicTagHelpers/pulls) if you want to make any improvements.

## Author

This project was created by [Delbert Matlock](https://github.com/StuffOfInterest).
