using AnyCAD.Foundation;

namespace AnyCadCubeDemo;

static class Program
{
    /// <summary>
    /// 应用程序主入口：初始化 AnyCAD 运行时后再启动窗体。
    /// </summary>
    [STAThread]
    static void Main()
    {
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        // 初始化 AnyCAD 内核与文件交换模块
        GlobalInstance.Initialize();
        ExchangeInstance.Initialize();

        Application.Run(new Form1());

        GlobalInstance.Destroy();
    }
}
