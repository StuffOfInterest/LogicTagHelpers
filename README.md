# LogicTagHelpers

## Planned tags
* if
  * then
  * else
* switch
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
