# blqw.MIS 方法即服务
> ### Method Is Service


# 说明
框架的目标是完全解耦 *(隔离)* **业务开发人员**和**服务器宿主程序**之间的联系  
业务人员只需要关心**业务逻辑实现**,而不需要在意代码是运行哪个种宿主中  
只需要关心**业务的方法定义**,而不需要在意需要以何种协议调用  
只需要关心**业务的参数**,而不需要在意参数如何传入(转换/验证)  

---
例如:
我定义了一个方法 
```csharp
public class UserManager
{
    [Api]
    public User Get([Positive]int id)
    {
        return ...;
    }
}
```
那么在iis中它有可能是这样的 `xxx.com/usermanager/get?id=1`  
在owin中它可能是这样的 `xxx.com/user/1`  
甚至在console中你可以这样调用 `xxx.exe c:UserMager m:Get args:id1`   
还有thrift,grpc,wcf,asp.net core,自定义tcp协议,想怎么玩就怎么玩

---

# 概念
## * 宿主(Host)
> 在计算机环境下，软件赖以生存的软件环境被称作是宿主环境,比如：asp需要运行在IIS里,IIS就是宿主程序
## * 接口(API)  
> 接口泛指实体把自己提供给外界的一种抽象化物（可以为另一实体），用以由内部操作分离出外部沟通方法，使其能被修改内部而不影响外界其他实体与其交互的方式。  
> 在计算机中，接口是计算机系统中两个独立的部件进行信息交换的共享边界。

在框架设计中,任意一个被标注特性`ApiAttribute`的`public`方法都属于接口,即能被外部系统调用  
*ps: API可以是实例方法也可以是静态方法*

## * 参数(Parameter)  
接口的方法参数

## * 属性(Property)  
接口的实例方法所在类的`public`属性  
接口如果是静态方法,则没有属性  

## * 描述(Descriptor)
用于阐述API的各种信息,包括API的命名空间,类型,方法名,参数,属性,返回值等  

## * 选择器(Selector)
用于提供选择接口的功能

## * 转换器(Converter)
用于转换传入参数和返回值

## * 调用器(Invoker)
用于调用指定API对应的方法并获取返回值

## * 过滤器(Filter)  
用于实现接口的AOP和短路

## * 容器(Container)  
包含接口的集合
接口在默认情况下支持所有容器  
在特殊情况下接口可以有选择支持的特定容器或部分容器  
容器的唯一标识是名称,名称不区分大小写

## * 适配器(Adapter)  
包含宿主框架,选择器,转换器,调用器,容器

## * 请求(Request)
包含请求的二进制流,对应的字符串,实际请求对象

## * 响应(Response)
包含响应的二进制流,对应的字符串,实际响应对象

# 设计图示
https://www.processon.com/view/link/58bab468e4b09b24d6e9cb08

# 待完成功能
支持实体参数
支持事件
支持过滤器
支持日志
支持Session
验证器
数据变更器



# 更新日志

## [0.1.0]
* 第二次重构,之前更新日志作废
* 精简核心库的功能,将第一版设计中的验证器,数据变更器,Session都从核心库中移除
* 移除原有的`ApiSettings`的默认解析方式,但功能保留
* 暂时删除了事件,日志,过滤器
* 重构代码运行流程,更合理,去掉了第一版中一些蹩脚和奇怪的设计
* Owin实现基础功能完成,单元测试完成