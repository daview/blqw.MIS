# blqw.UIF
Universal Interface Framework
通用接口框架

# 说明
该项目目前还处于设想阶段,我的想法是先做一个服务接口框架;  
将服务接口的功能抽象出来,业务代码直接写成类库的形式;
通过特性/配置文件/IOC或者其他形式注入服务框架,服务容器可以基于该框架适配;  
如此,即可使业务与服务容器之间解耦,切换服务容器也不需要修改业务代码; 
例如:  
同一套业务代码可以同时寄存于wcf,iis,以及各种rpc和aoc容器运行  

# 概念
## 1. 接口(Api)  
对应代码中的一个被`ApiAttribute`特性标注的公开实例方法
## 2. 容器(Container)  
服务与接口的集合  
接口在定义时可以设置应用到指定容器,部分容器或所有容器
服务实现`SupportContainers`属性,定义支持的容器  
容器的唯一表示是名称,且不区分大小写
## 3. 适配器(Adapter)  
用于适配指定服务器宿主程序调用指定容器中的接口和服务的行为  
一个适配器实例只能支持适配一种容器  
## 4. 请求参数(Parameter)  
对应接口的参数
## 5. 请求属性(Property)  
对应接口所在类的公开实例属性
## 6. 过滤器(Filter)  
`ApiFilterAttribute`过滤器,用于实现接口的AOP注入和短路
## 7. 服务(Service)  
对于框架中特定行为的抽象,可重写,可替换

# 待完成功能
1. 设计数据变更器描述属性
1. 完成基本过滤器(Log,Authorization,User等)
1. 单元测试支持
1. MVC支持
1. WCF支持
1. Console支持
1. Remoting支持
1. 内部异常处理
1. 日志记录
1. 实体参数支持
1. 自定义格式化参数支持
1. 完整事件支持
1. ~~设计会话保持实现~~
1. ~~完成基本数据变更器(Trim,Correct等)~~
1. ~~实现 ApiGlobal~~

# 更新日志
## [0.0.8] 2016.12.17
* `Session`功能设计编码完成
* 优化框架部分结构

## [0.0.7] 2016.12.12
* 实现数据变更器`Trim`, `NoTrim`, `Correct`
* 实现 `ApiGlobal`
* 项目改名为`UIF`(Universal Interface Framework)

## [0.0.6] 2016.12.11
* 优化验证器验证部分代码
* 增加数据变更器调用实现

## [0.0.5] 2016.12.10
* 增加一组验证器

## [0.0.4] 2016.12.09
* 框架支持对过滤器的处理
* 框架支持对数据变更器的处理
* 框架支持对参数验证器的处理

## [0.0.3] 2016.12.08
* 删除`ApiSetting`类,改为使用拓展方法提供字典操作的支持
* 增加过滤器`ApiFilterAttribute`
* 增加数据变更器`DataModification`
* 增加Api调用上下文`ApiCallContext`
* 增加Api全局操作`ApiGlobal`

## [0.0.2] 2016.12.04
* 优化文件结构,框架拆分为2个项目,一个提供特性描述,另一个提供容器操作

## [0.0.1] 2016.12.02
* 主功能实现
