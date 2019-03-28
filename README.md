# YummyIssues
一些有趣好玩的问题，尝试把他们做出来

1.正整数相加。
    将两个正整数相加后得到结果，以任意方式输出结果，注意：两个数字有可能很小，也有可能非常巨大，巨大到无法直接存在常见数字类型中，例如int或者double，非常大的数字相加，如何实现呢？

2.好看的数字。
    一个很长的数字，例如数字num = 1234567890.123456，为了让这个数字美观，小数位可以四舍五入只保留n位小数，整数位则三位一个逗号隔开。例如用保留2位小数则,a可以美化为1,234,567,890.12
    
    另一中美化的方式常见于计算机中，用字母后缀表示数据位数，整数位保留3位数字，小数位保留n位，例如1000 可以用1k表示，1000 000可以用1M来表示，1000 000 000可以用1G表示,1234567可以用1.235M来表示。1500可以用1.5K来表示
    现在已知 var si = [
      { value: 1, symbol: "" },
      { value: 1E3, symbol: "k" },
      { value: 1E6, symbol: "M" },
      { value: 1E9, symbol: "G" },
      { value: 1E12, symbol: "T" },
      { value: 1E15, symbol: "P" },
      { value: 1E18, symbol: "E" }
    ];
    请将小于22位的数字a，小数点后保留3位小数，去掉小数部分多余的0，使用上述转化关系，将它转换位一个好看的数字
    
3.糟糕的数据库设计
    有时候我们会把json数据存放在数据库的字符串类型的字段中，用于存储一个结构不太稳定且通常只用来显示的数据，随着客户需求的变更，现在我们需要进行查询筛选，筛选的字段正好在json中存放，这该怎么实现查询呢？
    例如：表table_a字段包含Id int, createdDate DateTime,creator string,TempData string。
    数据为 
    1,2018-03-28,张三,"{age:18,sex:1,weight:75,description:'abcdefg'}"
    2,2018-03-27,李四,"{age:21,sex:0,tall:166,description:'12345678',favoriteSport:'football,basketball,swim'}"
    3,2018-03-28,王五,"{age:18,sex:0}"
    4,2018-03-28,王五,"{age:21,sex:1,weight:77,description:'abcdefg',tall:178}"
    查询条件为时间段startDate,endDate,创建人creatorName,年龄age,性别sex,描述description
    该如何实现对数据的查询呢？
    
