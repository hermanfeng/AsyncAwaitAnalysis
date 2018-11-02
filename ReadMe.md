主题
为什么会产生死锁？  
如何解决死锁？  
Asp.net Core中会死锁吗  

内容  
Async Await本质  
不使用AsyncAwait重现死锁   
SynchronizationContext  
ConfigureAwait  
Thread and Thread Pool  
  
如何解决死锁？  
注意事项及最佳实践  



https://www.cnblogs.com/chenjiang/archive/2013/06/11/3131948.html
使用特定线程执行委托	独占（一次执行一个委托）	有序（委托按队列顺序执行）	Send 可以直接调用委托	Post 可以直接调用委托
Windows 窗体	能	能	能	如果从 UI 线程调用	從不
WPF/Silverlight	能	能	能	如果从 UI 线程调用	從不
默认	不能	不能	不能	Always	從不
ASP.NET	不能	能	不能	Always	Always

