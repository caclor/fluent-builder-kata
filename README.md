C# Fluent Builder Kata
============================

This repository contains the code for a 2-hour code Kata in C#.

It's a simple project and a test suite, with all passing tests.<br />
The goal is to refactor the tests code by using a [Fluent Builder](http://arialdomartini.github.io/fluent-builder.html), converting one test after the other, in order, and increasingly enhance the resulting builder.

The tests have been divided into 3 sections, in 3 separate files:


| Test collection                                                                                                                                                           | Content                                                                                           |
| --------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------- |
| [`TransactionFieldsTest.cs`](https://github.com/tcpos-learning/fluent-builder-kata/blob/master/FluentBuilderKata.Test/TransactionFieldsTest.cs)                           | this covers the fields of the entity `Transaction`                                                |
| [`TransactionNestedEntitiesTest.cs`](https://github.com/tcpos-learning/fluent-builder-kata/blob/master/FluentBuilderKata.Test/TransactionNestedEntitiesTest.cs)           | this collection leads to the introduction of the nested builders for `Article` and for `Customer` |
| [`TransactionTwiceNestedEntitiesTest.cs`](https://github.com/tcpos-learning/fluent-builder-kata/blob/master/FluentBuilderKata.Test/TransactionTwiceNestedEntitiesTest.cs) | the last collection leads to the development of a twice-nested builder.                           |



While converting the tests and developing the fluent builder, all the tests should be kept passing.


## Solution
You can find in the branch [`solution`](https://github.com/tcpos-learning/fluent-builder-kata/tree/solution) a possible builder implementation.

## Code refactoring
The productive code in the class [`Logic`](https://github.com/tcpos-learning/fluent-builder-kata/blob/master/FluentBuilderKata/Logic.cs) is pretty convoluted and fragile. As an extra step, for a separate Kata, refactor its code, reducing the branching complexity.
