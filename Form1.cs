using AnyCAD.Foundation;
using AnyCAD.Forms;

namespace AnyCadCubeDemo;

/// <summary>
/// 主窗体：内嵌 AnyCAD 三维视图，生成并显示一个立方体。
/// </summary>
public partial class Form1 : Form
{
    private readonly RenderControl mRenderView;

    // 立方体边长
    private const double CubeSize = 50;

    public Form1()
    {
        InitializeComponent();

        Text = "AnyCAD 立方体示例";
        StartPosition = FormStartPosition.CenterScreen;
        ClientSize = new Size(960, 640);

        // 创建三维渲染控件并铺满窗体
        mRenderView = new RenderControl(this)
        {
            Dock = DockStyle.Fill
        };
        Controls.Add(mRenderView);

        CreateCube();
    }

    /// <summary>
    /// 用 ShapeBuilder 生成立方体并显示。
    /// 参考官方文档：TopoShape MakeBox(GAx2 ax, double dx, double dy, double dz)
    /// </summary>
    private void CreateCube()
    {
        // 以 XOY 平面为基准创建长宽高均为 CubeSize 的立方体
        TopoShape cube = ShapeBuilder.MakeBox(GP.XOY(), CubeSize, CubeSize, CubeSize);

        // 显示到场景中（新版接口：BrepSceneNode.Create(shape, color, true)）
        mRenderView.ShowSceneNode(BrepSceneNode.Create(cube, ColorTable.Blue, true));

        // 缩放到合适视图并立即重绘
        mRenderView.ZoomAll();
        mRenderView.RequestDraw();
    }
}
