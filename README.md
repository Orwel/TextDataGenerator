[![AppVeyor](https://img.shields.io/appveyor/ci/gruntjs/grunt.svg)](https://ci.appveyor.com/project/Orwel/textdatagenerator)

Text Data Generator
===
The Text Data Builder can build text from a template. The data can be random number, date time, line in a file...

The format of data can be SQL insert, XML, CSV, ... The limit is the generated data is in plain text.

Short example:
--
This template :
```
This is random integer @{Integer Max=7}.
This is random decimal @{Double Max=100, Min=-100, Format=.00}.
This is random date time @{DateTime Min=10-12-2015, Max=15-12-2015 14:12:03, Format=s}
This is a repeat :
@{Repeat Min=5, Max=7}
@{TextLine Path=.\rsc\NamesList.txt,Encoding=ANSI} are you ok?
@{EndRepeat}
```

Result :
```
This is random integer 0.
This is random decimal 81.60.
This is random date time 2015-08-11T16:53:51
This is a repeat :
Marc LAURENT are you ok?
Cédric VERNOU are you ok?
Laurie TARO are you ok?
Laurie TARO are you ok?
Marc LAURENT are you ok?
Marc LAURENT are you ok?
```

Template
--
The template define the generated text data. It is a combinaison of plain text and tag. The template is parsed by the application. 

Tag
---
The tags are replaced by the generated texts. It has the structure @{Prototype Parameter1=Value2, Parameter2=Value2}.

It begin with "@{" and end with "}". The first word is the prototype name, follow by the prototype parameters.

It has two type of tag. The builder tag and the data tag.


Data tag
---
Data tag are just replaced by text data.

|Prototype|Parameter|Required|Default|
|---------|---------|--------|-------|
|Integer|Min|No|0|
| |Max|No|int.Max|
| |Format|No|  |
|Double|Min|No|0|
| |Max|No|double.Max|
| |Format|No| |
|DateTime|Min|Yes|DateTime.MinValue|
| |Max|Yes|DateTime.MaxValue|
| |Format|No| |
|TextLine|Path|Yes| |
| |Encoding|No| |
|Text|MinParagraph|No|0|
| |MaxParagraph|No|10|
| |MinSentence|No|1|
| |MaxSentence|No|10|
| |MinWord|No|10|
| |MaxWord|No|100|

Builder tag
---
Builder tag generate more complex text data. It is composed of tag with a end tag. All text and tags in the builder can be altered by the builder.

For example, the repeat builder will generate X time the text data. Then the tags in the Repeat will be replaced X time by the builder.

|Prototype|End Tag|Parameter|Required|Default|
|---------|-------|---------|--------|-------|
|Repeat|EndRepeat|Min|Yes| |
| | |Max|No|10|
