# Logic Tag Helpers

Tag helpers to provide control logic inside of cshtml pages.

| CI Build | Publish Build |
| -------- | ------------- |
| [![.NET](https://github.com/StuffOfInterest/LogicTagHelpers/actions/workflows/build-test.yml/badge.svg)](https://github.com/StuffOfInterest/LogicTagHelpers/actions/workflows/build-test.yml) | [![.NET](https://github.com/StuffOfInterest/LogicTagHelpers/actions/workflows/build-test-publish.yml/badge.svg)](https://github.com/StuffOfInterest/LogicTagHelpers/actions/workflows/build-test-publish.yml) |

## Tags

* [if](#if)
  * then
  * else
* [switch](#switch)
  * case
* [while](#while)
* [do](#do)
* [for](#for)
* [foreach](#foreach)

## Installation

Following line must be added to the `_ViewImports.cshtml` file for the logic tag helpers to be available.

```
@addTagHelper *, LogicTagHelpers
```

## Tag Examples

### if

```html
<if condition="(boolean)">
   <then><span>content to display if condition matched</span></then>
   <else><span>content to display if condition not matched</span></else>
</if>
```

```html
<if condition="(boolean)" direct="true">
   <span>content to display if condition matched</span>
</if>
```

### switch

```html
<switch expression="(variable)">
   <case value="(value)"><span>content to display on value match</span></case>
   <case value="(value)"><span>content to display on value match</span></case>
   <default><span>content to display if no value match</span></default>
</switch>
```

### while

```html
@{ var x = 0; }
<while condition="() => x < 10">
   <span>content to display while condition is true</span>
   @{ x++; }
</while>
```

### do

```html
@{ var x = 0; }
<while condition="() => x < 10">
   @{ x++; }
   <span>content to display until condition is not true</span>
</while>
```

### for
```html
@{ int x = default; }
<for initialize="() => x = 0" condition="() => x < 10" update="() => x++">
   <span>content to display while condition is true</span>
</for>
```

### foreach

```html
@{ var context = new ForeachContext<(type)>((values-of-type)); }
<foreach iterator="context">
   <span>content to display for each item in collection</span>
</foreach>
```