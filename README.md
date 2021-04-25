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

## Future Tags

* foreach
* while
* for
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
