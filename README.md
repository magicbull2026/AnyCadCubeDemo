# AnyCadCubeDemo

使用 [AnyCAD Rapid SDK](http://www.anycad.net)（NuGet 包 `AnyCAD.Rapid.NET`）在 WinForms 三维视图中生成并显示一个立方体。

## 环境要求

- Windows x64
- .NET Framework 4.8（项目目标框架 `net48`，AnyCAD 同时提供 net48 / net6 / net8 / net10 版本）
- Visual Studio 2019 及以上，或 .NET SDK 5.0 及以上（命令行 `dotnet build` 也可）
- NuGet 包 `AnyCAD.Rapid.NET` 2026.10.24.1110（已写入 csproj，恢复时自动下载）

> 说明：如果改用 net8.0-windows，需要 Visual Studio 2022（17.8+）或 .NET SDK 8，VS 2019 内置的 MSBuild 会报 NETSDK1045。

## 构建与运行

```bash
dotnet restore
dotnet build -c Debug
dotnet run
```

或直接用 Visual Studio 2019 打开 `AnyCadCubeDemo.csproj` 后 F5。
启动后会弹出一个三维窗口，里面是边长为 50 的蓝色立方体，可用鼠标旋转、缩放查看。

## 关键代码

立方体由 `ShapeBuilder.MakeBox` 创建（参考官方文档《几何造型》2.1 三维基本体）：

```csharp
TopoShape cube = ShapeBuilder.MakeBox(GP.XOY(), 50, 50, 50);
mRenderView.ShowSceneNode(BrepSceneNode.Create(cube, ColorTable.Blue, true));
```

- `GP.XOY()`：以 XOY 平面为基准
- 三个 50：立方体在 X、Y、Z 方向的尺寸
- `BrepSceneNode.Create`：把拓扑对象包装成可显示的场景节点

完整的初始化流程见 [Program.cs](Program.cs)（`GlobalInstance.Initialize()` 必须先于控件创建），窗体与立方体代码见 [Form1.cs](Form1.cs)。

## 编码约定

`.cs` 文件统一使用 **UTF-8 with BOM**，由 [.editorconfig](.editorconfig) 的 `charset = utf-8-bom` 约束，避免中文注释在旧版 MSBuild / 编辑器中乱码。

## 参考文档

- AnyCAD 快速上手：http://www.anycad.net/guide/guide-01-start.html
- 几何造型：http://www.anycad.net/guide/guide-11-geometry-modeling.html
- 官方示例仓库：https://github.com/anycad/anycad.rapid.net.sample

## 目录结构

```
AnyCadCubeDemo/
├── AnyCadCubeDemo.csproj   # 项目文件（net48 + x64，引用 AnyCAD.Rapid.NET）
├── Program.cs              # 程序入口：初始化 AnyCAD 运行时
├── Form1.cs                # 主窗体：创建 RenderControl 并生成立方体
├── Form1.Designer.cs       # 窗体设计器代码
└── .editorconfig           # C# 文件编码约定（UTF-8 BOM）
```
