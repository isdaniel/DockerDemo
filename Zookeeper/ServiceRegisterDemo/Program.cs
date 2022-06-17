
using System.Text;
using org.apache.zookeeper;
using org.apache.zookeeper.data;

string serverName = args[0];
string conn = "127.0.0.1:2181";
int timeout = 2000;
ManualResetEvent manualResetEvent = new ManualResetEvent(false);
//args[0]
var watcher= new subscriber(serverName, manualResetEvent);
ZooKeeper zooKeeper = new ZooKeeper(conn , timeout , watcher);

while (zooKeeper.getState() == ZooKeeper.States.CONNECTING)
{
    Console.WriteLine("等待 Zookeeper 連接!!...");
    Thread.Sleep(1000);
}

string path_prefix = "/ServerList";
List<ACL> acl = ZooDefs.Ids.OPEN_ACL_UNSAFE;
{
    var serverRoot = await zooKeeper.existsAsync(path_prefix, true);
    if (serverRoot == null) {
        await zooKeeper.createAsync(path_prefix, Encoding.UTF8.GetBytes("Root"), acl, CreateMode.PERSISTENT);
    }
}

{
    var data = Encoding.UTF8.GetBytes(serverName);
    await zooKeeper.createAsync($"{path_prefix}/{serverName}", data, acl, CreateMode.EPHEMERAL);
    Console.WriteLine($"{serverName} 上線");
}

while (true)
{
    var children = await zooKeeper.getChildrenAsync($"/ServerList", true);
    Console.WriteLine(string.Join(",", children.Children));
    manualResetEvent.WaitOne();
    manualResetEvent.Reset();
}



class subscriber : Watcher
{
    private readonly ManualResetEvent _manualResetEvent;

    public string Name { get; private set; }
    public subscriber(string name, ManualResetEvent manualResetEvent)
    {
        this.Name = name;
        this._manualResetEvent = manualResetEvent;
    }

    public override Task process(WatchedEvent e)
    {
        if (e.get_Type() == Event.EventType.NodeChildrenChanged)
        {
            Console.WriteLine("ServerList 異動!!");
            _manualResetEvent.Set();
        }
        return Task.CompletedTask;
    }
}
