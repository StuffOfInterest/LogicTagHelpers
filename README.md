# Logic Tag Helpers

| CI Build | Publish Build |
| -------- | ------------- |
| [![.NET](https://github.com/StuffOfInterest/LogicTagHelpers/actions/workflows/build-test.yml/badge.svg)](https://github.com/StuffOfInterest/LogicTagHelpers/actions/workflows/build-test.yml) | [![.NET](https://github.com/StuffOfInterest/LogicTagHelpers/actions/workflows/build-test-publish.yml/badge.svg)](https://github.com/StuffOfInterest/LogicTagHelpers/actions/workflows/build-test-publish.yml) |

## Completed Tags

* [if](#if)
  * then
  * else
* [switch](#switch)
  * case
* [foreach](#foreach)
* [while](#while)
* [for](#for)

## Future Tags

* do

## Installation

Following line must be added to the `_ViewImports.cshtml` file for the logic tag helpers to be available.

```
@addTagHelper *, LogicTagHelpers
```

## Tags

### if

```html
<if condition="(boolean)">
   <then>(content to display if condition matched)</then>
   <else>(content to display if condition not matched)</else>
</if>
```

```html
<if condition="(boolean)" direct="true">
   (content to display if condition matched)
</if>
```

### switch

```html
<switch expression="(variable)">
   <case value="(value)">(content to display on value match)</case>
   <case value="(value)">(content to display on value match)</case>
   <default>(content to display if no value match)</default>
</switch>
```

### foreach

```html
@{ var context = new ForeachContext<(type)>((values-of-type)); }
<foreach iterator="context">
   (content to display for each item in collection)
</foreach>
```

### while

```html
@{ var x = 0; }
<while condition="() => x < 10">
   (content to display while condition is true)
   @{ x++; }
</while>
```

### for
```html
@{ int x = default; }
<for initialize="() => x = 0" condition="() => x < 10" update="() => x++">
   (content to display while condition is true)
</for>
```