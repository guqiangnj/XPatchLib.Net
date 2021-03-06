#### 4.1.0.6

* 修正 - FixBugs。

#### 4.1.0.5

* 修正 - 将附加空白增量文档或文档内容为空时会抛出异常修改为返回当前附加增量的原始对象实例（如果对象为null，则返回该类型空构造函数返回的实例）。

#### 4.1.0.4

* 增加 - 增加支持 `CultureInfo` 类型。

#### 4.1.0.3

* 修正 - 修正对于 同名属性被多次定义在不同的接口中的实现对象 的增量处理，及 泛型集合中定义泛型为接口 的问题。

#### 4.1.0.2

* 重构 - 重构 `FileInfo`、`DriviInfo`、`DirectoryInfo` 相关代码。

#### 4.1.0.1

* 重构 - 合并 `ICombine`、`IDivide` 接口的实现。

#### 4.0.2.8

* 重构 - 修改 `IDivide` 接口定义。

#### 4.0.2.7

* 重构 - `ICombine` 接口 更名为 `ICombine`。

#### 4.0.2.6

* 重构 - 重构非标准类型的产生增量和合并增量的代码。参考 `Regex` 类型的实现（`CombineOtherObjectBase`、`DivideOtherObjectBase`、`OtherCombineContainer`、`OtherDivideContainer`）。 

* 修正 - 修正 `Regex` 的问题。 

#### 4.0.2.4

* 修正 - 修正 `FileInfo`、`DriviInfo`、`DirectoryInfo` 的问题。

#### 4.0.2.3

* 重构 - `Serializer` 增加 `IDisposable` 接口。 

#### 4.0.2.2

* 修正 - `XmlSerializeSetting.Clone()` 方法。 

#### 4.0.2.1

* 重构 - 将 `IgnoreAttributeType` 由 `ITextWriter` 移动至 `ISerializeSetting`。 

#### 4.0.1.1

* 增加 - 增加支持 `DefaultValueAttribute` 特性，标记了该特性的属性会采用标记值作为默认值而不是类型的默认值。

#### 4.0.0.4

* 修正 - 修正产生增量时集合元素为 `Nullable<T>` 类型时的无法正确获取到默认值的问题。

#### 4.0.0.3

* 修正 - 合并增量 `IDictionary<T,W>` 类型实例时，如果W与T类型不同时的问题G。

* 修正 - `Serializer` 构造函数传入传入的类型为接口时的问题。

#### 4.0.0.1

* 修正 - 合并增量 [Queue](https://msdn.microsoft.com/zh-cn/library/7977ey2c(v=vs.110).aspx)。

* 修正 - 合并增量 [Stack](https://msdn.microsoft.com/zh-cn/library/3278tedw(v=vs.110).aspx)。

#### 3.0.5.14

* 修正 - 合并增量 [ConcurrentBag](https://msdn.microsoft.com/zh-cn/library/dd381779(v=vs.110).aspx)。

* 修正 - 合并增量 [ConcurrentQueue](https://msdn.microsoft.com/zh-cn/library/dd267265(v=vs.110).aspx)。

* 修正 - 合并增量 [ConcurrentStack](https://msdn.microsoft.com/zh-cn/library/dd267331(v=vs.110).aspx)。

#### 3.0.5.12

* 修正 - 合并增量 [ConcurrentDictionary](https://msdn.microsoft.com/zh-cn/library/dd287191(v=vs.110))。*会跳过 `OnDeserialized`,`OnSerializing`*

#### 3.0.5.12

* 重构 - 支持 [.NET Core 2.0](https://github.com/dotnet/core/blob/master/release-notes/2.0/2.0.0.md)。

#### 3.0.5.11

* 优化 - 优化增量增量合并性能。

#### 3.0.5.9

* 修正 - 修正在采用非合并原始数据实例方式合并增量时，如果使用了非初始的动作特性描述符属性时，无法正常解析动作特性的异常。

#### 3.0.5.8

* 重构 - 重构 `ITextReader` 。修改 `GetAttributes` 方法签名（恢复3.0.5.5版本之前）。

* 优化 - 优化增量增量合并性能。

#### 3.0.5.6

* 修正 - 修正合并增量分析节点特性时可能遇到主键值为 `null` 的问题。

#### 3.0.5.5

* 重构 - 重构 `ITextReader` 。修改 `GetAttributes` 方法签名。

#### 3.0.5.4

* 修正 - 修正合并增量时可能无法正确初始化节点特性的问题。

#### 3.0.5.3

* 重构 - 重构 `ITextReader` 。修改 `GetAttributes` 方法签名及取消 `HasAttribute` 属性，同时修改相应实现。

#### 3.0.5.2

* 修正 - 修正 `DynamicObject` 对象实例中包含普通属性或参数时的拆分和合并问题。

#### 3.0.5.1

* 新增 - 新增对 [DynamicObject](https://msdn.microsoft.com/zh-cn/library/system.dynamic.dynamicobject.aspx) 的支持。

#### 3.0.4.4

* 修正 - 修正对序列化实例中如果有循环引用时的异常处理。

#### 3.0.4.3

* 修正 - 修正 `XmlTextReader` 的文档注释。

#### 3.0.4.2

* 修正 - 修正部分代码的文档注释。

#### 3.0.4.1

* 重构 - 支持 .NET Standard 1.0。

#### 3.0.3.2

* 修正 - 修正 `Serializer.RegisterType` 方法签名。

#### 3.0.3.1

* 新增 - 支持选择不同访问修饰符成员的序列化或反序列化 [Private](https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/private)
，[Protected](https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/protected)
，[Internal](https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/internal) 。

* 新增 - 支持选择序列化或反序列化 [属性](https://docs.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/properties)
，[字段](https://docs.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/fields) 。

#### 3.0.2.8

* 修正 - 修正 3.0.2.7 版本带来的BUG。

#### 3.0.2.7

* 重构 - 重构 `XmlSerializeSetting` ，增加基类 `SerializeSetting` 。

#### 3.0.2.6

* 优化 - 优化增量反序列化性能。

#### 3.0.2.5

* 优化 - 优化增量反序列化性能。

#### 3.0.2.4

* 优化 - 修改部分异常提示。

#### 3.0.2.3

* 重构 - 重构 `XmlTextReader` 。使用 `XmlReader` 作为读取器。

#### 3.0.1.8

* 优化 - 优化合并增量文档时调用对象方法的性能。

#### 3.0.1.7

* 新增 - 新增对 [ISerializable](https://msdn.microsoft.com/zh-cn/library/system.runtime.serialization.iserializable(v=vs.110).aspx) 的支持。

#### 3.0.1.6

* 修正 - 判断类型是否为ICollection时，如果遇到不是泛型集合时会报 `System.InvalidOperationException 当前对象不是泛型类型`。

#### 3.0.1.5

* 新增 - 新增对 [OnSerializingAttribute](https://msdn.microsoft.com/zh-cn/library/system.runtime.serialization.onserializingattribute(v=vs.110).aspx)
，[OnSerializedAttribute](https://msdn.microsoft.com/zh-cn/library/system.runtime.serialization.onserializedattribute(v=vs.110).aspx)
，[OnDeserializingAttribute](https://msdn.microsoft.com/zh-cn/library/system.runtime.serialization.ondeserializingattribute(v=vs.110).aspx)
，[OnDeserializedAttribute](https://msdn.microsoft.com/zh-cn/library/system.runtime.serialization.ondeserializedattribute(v=vs.110).aspx) 特性的支持。

#### 3.0.1.4

* 优化 - 修改原有的对象比较方式。

* 优化 - 修改 `ITextWriter` 接口，增加部分属性。

* 优化 - 增加 `Serializer` 构造函数的参数异常判断。

* 新增 - 新增对 [Nullable](https://msdn.microsoft.com/zh-cn/library/system.nullable.aspx) 类型的支持。

* 重构 - 重构 `XmlTextWriter` 。

#### 3.0.0.27

* 优化 - 减少产生基础类型对象增量内容时对类型的判断次数。

* 优化 - 修改原有调用构造函数时的异常处理方式，改为先找构造函数。

#### 3.0.0.26

* 优化 - 优化生成增量文档时生成开始节点的性能。

#### 3.0.0.25

* 修正 - 修正获取多语言时使用的是 [CurrentUICulture](https://msdn.microsoft.com/zh-cn/library/system.globalization.cultureinfo.currentuiculture(v=vs.110).aspx)。

* 修正 - 修正当集合类型可能是接口类型（如 `IList<T>`），调用指定方法时，如果无法在当前类型上找到方法，所以还可以根据实例的类型来查找指定方法。

* 修正 - 修正在指定类型上查找指定方法时，如果遇到当前类型的基础类型为空的情况下会死循环的问题。(.NET Standard 2.0 以下版本)

#### 3.0.0.24

* 修正 - 修正合并增量时，如果增量只有一个单独的根节点，会无法合并增量。

#### 3.0.0.23

* 修正 - 修正Struct类型（`Size`,`Point`,`Rectangle`等）对象做增量序列化时会报 [System.Security.VerificationException](https://msdn.microsoft.com/zh-cn/library/system.security.verificationexception(v=vs.110).aspx) 异常。

#### 3.0.0.22

* 修正 - 修正值类型对象数组做增量反序列化时的错误。

#### 3.0.0.21

* 新增 - 新增对 [Uri](https://msdn.microsoft.com/zh-cn/library/system.uri(v=vs.110).aspx) 类型的支持。

#### 3.0.0.20

* 新增 - 新增对 [BigInteger](https://msdn.microsoft.com/zh-cn/library/system.numerics.biginteger(v=vs.110).aspx) 类型的支持。

#### 3.0.0.19

* 新增 - 新增对 [DateTimeOffset](https://msdn.microsoft.com/library/system.datetimeoffset.aspx) 类型的支持。

#### 3.0.0.18

* 新增 - 新增对 [TimeSpan](https://msdn.microsoft.com/zh-cn/library/system.timespan.aspx) 类型的支持。
