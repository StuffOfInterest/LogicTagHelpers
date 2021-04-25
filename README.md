# Logic Tag Helpers

| CI Build | Publish Build |
| -------- | ------------- |
| [![.NET](https://github.com/StuffOfInterest/LogicTagHelpers/actions/workflows/build-test.yml/badge.svg)](https://github.com/StuffOfInterest/LogicTagHelpers/actions/workflows/build-test.yml) | [![.NET](https://github.com/StuffOfInterest/LogicTagHelpers/actions/workflows/build-test-publish.yml/badge.svg)](https://github.com/StuffOfInterest/LogicTagHelpers/actions/workflows/build-test-publish.yml) |

## Planned tags

* [if](#if)
  * then
  * else
* [switch](#switch)
  * case
* foreach
* while
* for
* do

### if

```html
<if condition="(boolean)">
   <then>(markup to display if condition matched)</then>
   <else>(markup to display if condition not matched)</else>
</if>
```

```html
<if condition="(boolean)" direct="true">
   (markup to display if condition matched)
</if>
```

### switch

```html
<switch expression="(variable)">
   <case value="(value)"></case>
   <case value="(value)"></case>
   <default></default>
</switch>
```
