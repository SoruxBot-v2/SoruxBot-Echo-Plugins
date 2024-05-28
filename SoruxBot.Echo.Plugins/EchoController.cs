using SoruxBot.SDK.Attribute;
using SoruxBot.SDK.Model.Attribute;
using SoruxBot.SDK.Model.Message;
using SoruxBot.SDK.Plugins.Model;
using SoruxBot.SDK.Plugins.Service;

namespace SoruxBot.Echo.Plugins;

public class EchoController(ILoggerService loggerService, ICommonApi bot)
{
    [MessageEvent(MessageType.PrivateMessage)]
    [Command(CommandPrefixType.Single, "echo [content]")]
    public PluginFlag EchoInPrivate(MessageContext ctx, string content)
    {
        loggerService.Info("EchoInPrivate", 
            $"Receive a message from framework, echo it: {content}");
        var msg = MessageBuilder.PrivateMessage(ctx.TriggerId, "QQ")
            .Text(content)
            .Build();
        ctx.MessageChain = msg;
        bot.SendMessage(ctx);
        return PluginFlag.MsgIntercepted;
    }
    
    [MessageEvent(MessageType.GroupMessage)]
    [Command(CommandPrefixType.Single, "echo [content]")]
    public PluginFlag EchoInGroup(MessageContext ctx, string content)
    {
        loggerService.Info("EchoInPrivate", 
            $"Receive a message from framework, echo it: {content}");
        var msg = MessageBuilder.GroupMessage(ctx.TriggerPlatformId, "QQ")
            .Text(content)
            .Build();
        ctx.MessageChain = msg;
        bot.SendMessage(ctx);
        return PluginFlag.MsgIntercepted;
    }
}