# EventBus.AspNetCore

## EventBus 的.Net Core 封装。后续会增加 RabbitMq,ServiceBus的封装。

添加方法十分简单：

1  下载安装包  `Install-Package EventBus.AspNetCore`。

2  public void ConfigureServices(IServiceCollection services)  
   {  
      services.AddMvc();  
      services.AddMemoryEventBus();  
   }  
  
3  public void Configure(IApplicationBuilder app, IHostingEnvironment env)  
   {  
      var sub = app.ApplicationServices.GetRequiredService<IEventBusSubscriptionsManager>();  
     sub.AddSubscription<UserUpdateEvent, UserUpdateEventHandler>();  
      ........  
   }  
