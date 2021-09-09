# 项目简介
<b>本项目开源但不允许商用，仅用于学习交流。</b><br/>
项目名字一看其实就可以知道，学习MVC，不过准确来说是ASP.Net Core MVC(.net5.0)，所以项目不是很大 <br/>
后端主要用的EFCore （简单用本机电脑配置了一个简单的读写分离）  <br/>
数据库Sqlsever 暂时没有写支持其他数据库扩展  <br/>
前端用的Vue.js Element UI  <br/>
简单的一个登录 成功后界面展示，对应权限给对应的页面  <br/>
下面各个部分简单描述一下(项目里面会有惊喜哦，突然触发的那种)
# 登录
![image](https://user-images.githubusercontent.com/87634542/131846986-3debb16a-d9ce-458c-943f-5cf86f4abefe.png)
基础账号是：1314520 或者用姓名：小杰 <br/>
密码：123456  <br/>
密码这里用到了MD5加密，验证码用的Drawing画的，这个是我网上找资料搬运而来 <br/>
表单前端的element UI 的表单验证<br/>
还有我们后端MVC的模型验证，因为后面用会身份验证给每个控制器的action加不同权限设计内容较多，登录暂时写的还比较将就 <br/>
前端也用的axios用了vue肯定用它了 <br/>
还有一些细节大家项目里面自己看 <br/>

# 主界面
![image](https://user-images.githubusercontent.com/87634542/132249799-1e9168c1-6bbb-45fc-8b51-87074380adce.png)
界面改了一天的美观这个颜色还是挺不错的<br/>
右边闹钟网上借鉴大佬写的css3画布,我没这么好的css功底了<br/>
# 代码分层的介绍
![image](https://user-images.githubusercontent.com/87634542/131849035-a7a7a045-4772-49a0-bd23-5907102975d8.png)<br/>
我用经典的三层文件夹包裹这样大家更能看懂<br/>
<br/>
![image](https://user-images.githubusercontent.com/87634542/131849369-749de6cc-d7d9-4b98-9f6a-122691afa6ba.png)<br/>
那么这里我们的MVC就当成UI界面使用<br/>
<br/>
![image](https://user-images.githubusercontent.com/87634542/131849472-5427d1db-46df-4a9f-866e-39f6dce3ff80.png)<br/>
逻辑层主要是写的抽象和对应的实现<br/>
<br/>
![image](https://user-images.githubusercontent.com/87634542/131849569-c2dcfe99-fb99-471d-ad1c-3ac6bad6c84f.png)<br/>
工具层和模型我放在一起在公共设施，也就是大家都用的，数据访问层EFCore的配置<br/>
# 项目运行
首先一定要改你的数据库连接字符串在appsettings.json里面
![image](https://user-images.githubusercontent.com/87634542/131850131-ceae546c-3d6b-4131-820c-fb6689608e26.png)<br/>
write里面是写库 read里面是读库 我用的轮询策略，读写分离会有延时的哦<br/>
箭头指这个字段意思是是否读写分离，会配置的小伙伴选择true，sqlsever发布订阅一下比较简单，<br/>
对应字符串也比较明显项目默认写了EFCoreapi生成数据库<br/>
有问题自己查资料<br/>
# 项目心得 
其实用的知识不多，本质上还是玩增删改查操作表多了一点，看情况升级项目，看了这么多，<b>孩子想要star</b><br/>
# 项目胎教
有机会分享项目逻辑一些技术的使用<br/>
比如<br/>
1.过滤器怎么用，全局配置 <br/>
2.core里面的依赖注入，项目用的autofac<br/>
3.花式读配置文件<br/>
4.一些中间件的使用<br/>
5.efcore花式封装分页<br/>
6.efcore事务的使用<br/>
7.ef优化小技巧<br/>
8.identitySever基本使用<br/>
9.权限设计表的设计思路<br/>
10.vue和element ui的一点小坑<br/>
11.axios各种请求问题<br/>
...........<br/>
# 项目状态
<b>停更</b><br/>
大致功能都写好了，剩下的只是单表增删改查了，项目只适合小型的管理系统借鉴<br/>
如果相对复杂建议前后端分离，前端配置相对简单（复杂我就前后端分离了）
