using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using stdole;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AE_RendererDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //打开Mxd地图文档
            OpenMxd();
            ThimaticMapKeys(false);
        }
        //用于控制“添加地图元素”的方法
        private void ThimaticMapKeys(bool Flag)
        {
            添加地图元素ToolStripMenuItem.Enabled = Flag;
            图例ToolStripMenuItem.Enabled = Flag;
            指北针ToolStripMenuItem.Enabled = Flag;
            比例尺ToolStripMenuItem.Enabled = Flag;
            文本ToolStripMenuItem.Enabled = Flag;
        }

        /// <summary>
        /// 打开Mxd地图文档
        /// </summary>
        private void OpenMxd()
        {
            IMapDocument mapDocument = new MapDocumentClass();
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "打开地图文档";
                ofd.Filter = "map documents(*.mxd)|*.mxd";
                ofd.InitialDirectory = Application.StartupPath + @"\Data";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string pFileName = ofd.FileName;
                    //filePath——地图文档的路径, ""——赋予默认密码
                    mapDocument.Open(pFileName, "");
                    for (int i = 0; i < mapDocument.MapCount; i++)
                    {
                        //通过get_Map(i)方法逐个加载
                        axMapControl1.Map = mapDocument.get_Map(i);
                    }
                    axMapControl1.Refresh();
                }
                else
                {
                    mapDocument = null;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        #region 各类专题图均用的函数
        /// <summary>
        /// 获得颜色的函数
        /// </summary>
        /// <param name="r">红色Red</param>
        /// <param name="g">绿色Green</param>
        /// <param name="b">蓝色Blue</param>
        /// <returns>返回颜色</returns>
        private IRgbColor getRGB(int r, int g, int b)
        {
            IRgbColor pColor = new RgbColorClass();
            pColor.Red = r;
            pColor.Green = g;
            pColor.Blue = b;
            return pColor;
        }
        /// <summary>
        /// 获取渲染图层
        /// </summary>
        /// <param name="layerName">图层名字</param>
        /// <returns>图层</returns>
        private IGeoFeatureLayer getGeoLayer(string layerName)
        {
            ILayer pLayer; //定义图层
            IGeoFeatureLayer pGeoFeatureLayer; //定义要素图层  Geo？
            //遍历图层
            for (int i = 0; i < axMapControl1.LayerCount; i++)
            {
                pLayer = axMapControl1.get_Layer(i);
                //若当前图层不为空且与与layerName的值相同
                if (pLayer != null && pLayer.Name == layerName)
                {
                    //强转成IGeoFeatureLayer
                    pGeoFeatureLayer = pLayer as IGeoFeatureLayer;
                    //返回pGeoFeatureLayer对象
                    return pGeoFeatureLayer;
                }
            }
            return null; //返回null
        }

        #endregion

        /// <summary>
        /// 简单符号法渲染器(SimpleRenderer), 用同一个符号绘制所有特征
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 简单符号法渲染ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //实例化ISimpleFillSysmbol变量, 提供简单的填充符号类型
            ISimpleFillSymbol pSimpleFillSymbol = new SimpleFillSymbolClass();
            //设置填充符号的样式——为呈45度的交叉线(xxx)
            ///Horizontal and vertical crosshatch ++++++.
            pSimpleFillSymbol.Style = esriSimpleFillStyle.esriSFSCross;
            //设置填充符号的颜色——红色
            pSimpleFillSymbol.Color = getRGB(96, 96, 96);
            //创建边线符号变量, 提供简单的线条符号类型
            ISimpleLineSymbol pSimpleLineSymbol = new SimpleLineSymbolClass();
            //设置线符号样式——线呈交替虚线和双点(_.._.._)
            //The line has alternating dashes and double dots _.._.._.
            pSimpleLineSymbol.Style = esriSimpleLineStyle.esriSLSDashDotDot;
            //设置线符号颜色——绿色
            pSimpleLineSymbol.Color = getRGB(255, 0, 0);
            //设置线符号宽度——1.5
            pSimpleLineSymbol.Width = 1.5;
            //将线符号强转成ISymbol符号变量
            ISymbol pSymbol = pSimpleLineSymbol as ISymbol;
            //设置符号属性ROP2为二元栅格esriROPNotXOrPen
            pSymbol.ROP2 = esriRasterOpCode.esriROPNotXOrPen;
            //设置填充符号外边界的样式为pSimpleLineSymbol
            pSimpleFillSymbol.Outline = pSimpleLineSymbol;
            //实例化简单渲染变量
            ISimpleRenderer pSimpleRender = new SimpleRendererClass();
            //设置pSimpleRender的符号样式
            pSimpleRender.Symbol = pSimpleFillSymbol as ISymbol;
            //设置标签名称, 用于设置图例
            pSimpleRender.Label = "北部湾";
            //设置符号描述, 用于设置图例
            pSimpleRender.Description = "简单渲染";
            //定义IGeoFeatureLayer变量, 提供一个要素图层对成员控制地理特征渲染的入口, 即Renderer属性
            IGeoFeatureLayer pGeoFeatureLayer;
            //调用函数获取渲染图层
            pGeoFeatureLayer = getGeoLayer("北部湾");
            if (pGeoFeatureLayer != null)
            {
                //调用Renderer属性, 具体说明如何通过图层要素渲染器渲染图层
                pGeoFeatureLayer.Renderer = pSimpleRender as IFeatureRenderer;
            }
            axMapControl1.Refresh(); //刷新axMapControl1
            axTOCControl1.Update(); //更新axTOCControl1
        }
        /// <summary>
        /// 分等级法渲染器(ClassBreakRenderer), 可以用分级的颜色和符号来绘制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 分等级法渲染ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //数据分成10个等级
            int classCount = 10;
            //声明一个ITableHistogram变量
            //该变量用于控制从表格中生成的直方图的样式
            ITableHistogram pTableHistogram;
            //声明一个IBasicHistogram变量
            //该变量用于控制从不同数据源中生成的直方图
            IBasicHistogram pBasicHistogram;
            //实例化表格对象
            ITable pTable;
            //获取生成分级专题图的目标图层
            IGeoFeatureLayer pGeoFeatureLayer;
            //获取渲染图层
            pGeoFeatureLayer = getGeoLayer("北部湾");
            //将pGeoFeatureLayer强转成ILayer
            ILayer pLayer = pGeoFeatureLayer as ILayer;
            //将目标图层(要素类)的属性表强转成ITable
            pTable = pLayer as ITable;
            //实例化
            //BasicTableHistogram采用表对象输入数据的结构(如自然断点、分位数)生成直方图。
            pTableHistogram = new BasicTableHistogramClass();
            //赋值pTableHistogram的Table属性字段
            pTableHistogram.Table = pTable;
            //确定分级字段
            pTableHistogram.Field = "年";
            //pTableHistogram强制转换为IBasicHistogram
            pBasicHistogram = pTableHistogram as IBasicHistogram;
            //先统计每个值出现的次数, 输出结果赋予values, frequencys
            object values;
            object frequencys;
            //out参数可以在一个方法中返回多个不同类型的值
            pBasicHistogram.GetHistogram(out values, out frequencys);
            //创建平均分级对象
            IClassifyGEN pClassifyGEN = new QuantileClass();
            //用统计结果(values——值, frequences——出现频率)进行分级, 级别数目为classCount
            pClassifyGEN.Classify(values, frequencys, ref classCount);
            double[] classes;
            classes = pClassifyGEN.ClassBreaks as double[];

            //获得分级结果, 是个双精度类型数组
            //注意：获得双精度数组记录条数出现不可修复性错误, 故使用以下代码修复该错误
            double[] myclasses;
            myclasses = new double[classCount];
            //当classes不为null时
            if (classes != null)
            {
                //遍历classes, 从后往前移一位
                for (int j = 0; j < classCount; j++)
                {
                    myclasses[j] = classes[j + 1];
                }
            }
            //定义一个颜色枚举变量, 通过函数获取颜色带
            IEnumColors pEnumColors = CreateAlgorithmicColorRamp(myclasses.Length).Colors;
            IColor color;
            //声明并实例化分级渲染器对象类
            //该变量提供成员控制渐变色、渐变符号专题图的制作
            IClassBreaksRenderer classBreaksRenderer = new ClassBreaksRendererClass();
            //确定分级渲染的属性字段
            classBreaksRenderer.Field = "年";
            //分级数量
            classBreaksRenderer.BreakCount = classCount;
            //指示该专题图是否按升序显示
            classBreaksRenderer.SortClassesAscending = true;
            //简单填充符号(ISimpleFillSymbol)
            //该变量提供对成员的访问, 控制简单的填充符号
            ISimpleFillSymbol simpleFillSymbol;
            //通过一个循环, 给所有渲染的等级附上渲染颜色
            for (int i = 0; i < myclasses.Length; i++)
            {
                color = pEnumColors.Next();
                simpleFillSymbol = new SimpleFillSymbolClass();
                simpleFillSymbol.Color = color;
                //设置填充的样式(Style)为实体填充
                simpleFillSymbol.Style = esriSimpleFillStyle.esriSFSSolid;
                //指定分级渲染的符号(Symbol)
                classBreaksRenderer.set_Symbol(i, simpleFillSymbol as ISymbol);
                //按照分级进行渲染
                classBreaksRenderer.set_Break(i, myclasses[i]);
            }
            if (pGeoFeatureLayer != null)
            {
                //调用Renderer属性, 具体说明如何通过图层要素渲染器绘制图层
                pGeoFeatureLayer.Renderer = classBreaksRenderer as IFeatureRenderer;
            }
            axMapControl1.Refresh(); //刷新axMapControl1
            axTOCControl1.Update(); //更新axTOCControl1

        }

        /// <summary>
        /// 创建规则的颜色带
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private IColorRamp CreateAlgorithmicColorRamp(int count)
        {
            //创建一个新渐变色带(AlgorithmicColorRampClass)对象
            IAlgorithmicColorRamp algColorRamp = new AlgorithmicColorRampClass();
            IRgbColor fromColor = new RgbColorClass();
            IRgbColor toColor = new RgbColorClass();
            //创建其实颜色对象, 采用三原色定律
            fromColor.Red = 255;
            fromColor.Green = 235;
            fromColor.Blue = 214;
            //创建终止颜色对象
            toColor.Red = 196;
            toColor.Green = 10;
            toColor.Blue = 10;
            //设置AlgorithmicColorRampClass的起止颜色属性
            algColorRamp.ToColor = toColor;
            algColorRamp.FromColor = fromColor;
            //设置梯度类型
            algColorRamp.Algorithm = esriColorRampAlgorithm.esriCIELabAlgorithm;
            //设置颜色带颜色数量
            algColorRamp.Size = count;
            //创建颜色带
            bool bture = true;
            algColorRamp.CreateRamp(out bture);
            return algColorRamp;
        }
        /// <summary>
        /// 唯一值法渲染器(UniqueValueRender)——根据特征的某不同属性值来绘制该特征的符号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 唯一值法渲染ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //定义IGeoFeatureLayer变量, 提供一个要素图层对成员控制地理特征的入口
            IGeoFeatureLayer geoFeatureLayer = getGeoLayer("北部湾");
            //使用查询的方式, 获得参与渲染的记录条数
            int get_Count = geoFeatureLayer.FeatureClass.FeatureCount(null);
            //提供操作唯一值的相关成员
            IUniqueValueRenderer uniqueValueRenderer = new UniqueValueRendererClass();
            //设置渲染的字段个数范围：0~3个
            //这里仅设置1个字段
            uniqueValueRenderer.FieldCount = 1;
            //设置渲染字段, 并制定到索引处
            //索引从0开始; 设定渲染字段为"地市名"
            uniqueValueRenderer.set_Field(0, "地市名");
            //简单填充符号
            ISimpleFillSymbol simpleFillSymbol;
            //获得指向渲染要素的游标
            IFeatureCursor pFtCursor = geoFeatureLayer.FeatureClass.Search(null, false);
            IFeature pFeature;
            if (pFtCursor != null)
            {
                //定义枚举颜色带, 调用函数, 生成随机颜色带
                IEnumColors enumColors = CreateRandomColorRamp(get_Count).Colors;
                //查找到"地市名"字段的索引(index)
                int fieldIndex = geoFeatureLayer.FeatureClass.Fields.FindField("地市名");
                while ((pFeature = pFtCursor.NextFeature()) != null)
                {
                    //获取要素值
                    string nameValue = pFeature.get_Value(fieldIndex).ToString();

                    //实例化填充符号
                    //使用填充符号来赋值地图的背景值
                    simpleFillSymbol = new SimpleFillSymbolClass();
                    //给要素附上样式
                    simpleFillSymbol.Style = esriSimpleFillStyle.esriSFSSolid;
                    //给要素附上颜色
                    simpleFillSymbol.Color = enumColors.Next() as IColor;
                    //值和符号对应
                    uniqueValueRenderer.AddValue(nameValue, "地市", simpleFillSymbol as ISymbol);
                }
            }
            //赋值目标图层的渲染器属性
            geoFeatureLayer.Renderer = uniqueValueRenderer as IFeatureRenderer;
            axMapControl1.Refresh(); //刷新axMapControl1
            axTOCControl1.Update(); //更新axTOCControl1
        }
        /// <summary>
        /// 创建随机的颜色条带
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        private IColorRamp CreateRandomColorRamp(int Number)
        {
            //请注意色度、饱和度、最大值、最小值、随机种子数等参数的设定
            //参数不同, 所产生的色带也不同
            IRandomColorRamp pRandomColorRamp = new RandomColorRampClass();
            pRandomColorRamp.StartHue = 0;  //开始色度
            pRandomColorRamp.EndHue = 360;
            pRandomColorRamp.MinValue = 99;
            pRandomColorRamp.MaxValue = 100;
            pRandomColorRamp.MinSaturation = 15;    //最小饱和度
            pRandomColorRamp.MaxSaturation = 30;    //最大饱和度
            pRandomColorRamp.Size = Number; //设置颜色带数量
            pRandomColorRamp.Seed = 23; //随机数种子
            bool bture = true;
            pRandomColorRamp.CreateRamp(out bture);
            return pRandomColorRamp;
        }
        /// <summary>
        /// 比例符号法渲染器(ProportionalSymbolRenderer)——用不同大小的符号绘制要素, 其大小对应某一字段值的比例。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 比例符号法渲染ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //声明IGeoFeatureLayer变量, 提供一个要素图层对成员控制地理特征的入口
            IGeoFeatureLayer geoFeatureLayer;
            //声明要素图层
            IFeatureLayer pFtLayer;
            //声明专题图变量
            //在利用该方法进行着色时, 需获得最大和最小标识符号所代表的字段及其各个数值, 还需要确定每个字段数值所匹配的着色符号。
            IProportionalSymbolRenderer proportionalSymbolRenderer;
            //声明表格
            ITable table;
            //声明游标
            ICursor cursor;
            //用于统计变量
            IDataStatistics dataStatistics;
            //用于存放统计结果
            IStatisticsResults statisticsResults;
            //声明一个字体对象
            stdole.IFontDisp fontDisp;
            //获取图层
            geoFeatureLayer = getGeoLayer("北部湾");
            //强转为要素图层
            pFtLayer = geoFeatureLayer as IFeatureLayer;
            //图层类型转换成表
            table = geoFeatureLayer as ITable;
            //获取游标
            cursor = table.Search(null, true);
            //实例化数据统计对象
            dataStatistics = new DataStatisticsClass();
            //赋游标给数据统计对象的游标
            dataStatistics.Cursor = cursor;
            //获取图层要素中进行专题地图制图的字段名称, 此实例中所用的数据中字段名为"年"(2010年GDP增长速率)
            dataStatistics.Field = "年";
            //存放统计结果为统计对象的统计数据
            statisticsResults = dataStatistics.Statistics;
            //如果统计结果不为空
            if (statisticsResults != null)
            {
                //简单填充符号
                IFillSymbol fillSymbol = new SimpleFillSymbolClass();
                //设置颜色
                fillSymbol.Color = getRGB(195, 255, 255);
                //设置简单线型符号
                ISimpleLineSymbol SLS = new SimpleLineSymbolClass();
                SLS.Color = getRGB(196, 196, 196);//颜色
                SLS.Width = 1.5;//宽度
                fillSymbol.Outline = SLS;//外边界线
                //利用ESRI特殊符号调用成员进行填充
                ICharacterMarkerSymbol characterMarkerSymbol = new CharacterMarkerSymbolClass();
                fontDisp = new stdole.StdFontClass() as stdole.IFontDisp;
                //调用指定子库(ESRI Default Marker是子库名称)
                fontDisp.Name = "ESRI Default Marker";

                //对characterMarkerSymbol的font属性
                characterMarkerSymbol.Font = fontDisp;
                //特征标记符号(Character Marker Symbol)的索引值
                //0xB6是C#特殊的16进制表示方法, 换算为十进制值182
                characterMarkerSymbol.CharacterIndex = 0xB6;
                //特征标记符号的颜色
                characterMarkerSymbol.Color = getRGB(253, 191, 110);
                //设计特征标记符号的尺寸
                characterMarkerSymbol.Size = 18;
                //实例化一个比例符号渲染器
                proportionalSymbolRenderer = new ProportionalSymbolRendererClass();
                proportionalSymbolRenderer.ValueUnit = esriUnits.esriUnknownUnits;
                //获取渲染字段
                proportionalSymbolRenderer.Field = "年";
                //是否启用颜色补偿(默认为否)
                proportionalSymbolRenderer.FlanneryCompensation = false;
                //赋值统计数据(比例符号渲染器)            
                //MinDataValue获取数据中最小值
                proportionalSymbolRenderer.MinDataValue = statisticsResults.Minimum;
                //获取数据中最大值
                proportionalSymbolRenderer.MaxDataValue = statisticsResults.Maximum;
                //在多边形特征上绘制比例标记符号时使用的背景填充符号
                proportionalSymbolRenderer.BackgroundSymbol = fillSymbol;
                //用于绘制具有规格化最小数据值的特征的符号。
                proportionalSymbolRenderer.MinSymbol = characterMarkerSymbol as ISymbol;
                //目录和图例中显示的符号数为3
                proportionalSymbolRenderer.LegendSymbolCount = 3;
                //创建图例, 设置完所有属性后调用。
                proportionalSymbolRenderer.CreateLegendSymbols();
                //赋值目标图层的渲染器属性
                geoFeatureLayer.Renderer = proportionalSymbolRenderer as IFeatureRenderer;
            }
            axMapControl1.Refresh(); //刷新axMapControl1
            axTOCControl1.Update(); //更新axTOCControl1

        }
        /// <summary>
        /// 点状密度法渲染器(DotDensityRenderer)——在多边形特征中绘制不同密度的点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 点状密度法渲染ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //声明IGeoFeatureLayer变量, 提供一个要素图层对成员控制地理特征的入口
            IGeoFeatureLayer geoFeatureLayer;
            //定义点密度填充符号变量, 控制点符号的属性
            IDotDensityFillSymbol dotDensityFillSymbol;
            //定义点密度渲染对象
            IDotDensityRenderer dotDensityRenderer;
            //获取渲染图层
            geoFeatureLayer = getGeoLayer("北部湾");
            //实例化点密度渲染对象
            dotDensityRenderer = new DotDensityRendererClass();
            //强转点密度渲染对象并强转成渲染字段对象
            IRendererFields rendererFields = dotDensityRenderer as IRendererFields;
            //设置渲染字段
            string field1 = "年";
            //向渲染器添加字段(字段名、别名)
            rendererFields.AddField(field1, field1);
            //实例化点密度填充符号
            dotDensityFillSymbol = new DotDensityFillSymbolClass();
            dotDensityFillSymbol.DotSize = 4;//设置点的大小
            dotDensityFillSymbol.Color = getRGB(0, 255, 0);//设置点的颜色

            //将点密度填充符号强转为符号数组成员
            ISymbolArray symbolArray = dotDensityFillSymbol as ISymbolArray;
            //实例化简单标记符号
            ISimpleMarkerSymbol simpleMarkerSymbol = new SimpleMarkerSymbolClass();
            //设置点的符号为圆圈
            simpleMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSCircle;
            simpleMarkerSymbol.Size = 4;//设置大小
            simpleMarkerSymbol.Color = getRGB(0, 255, 0);//设置颜色
            //点符号的外边不填充颜色
            simpleMarkerSymbol.OutlineColor = getNoRGB();
            //将简单标记符号样式增加到符号数组成员中
            symbolArray.AddSymbol(simpleMarkerSymbol as ISymbol);
            //赋值点密度渲染(dotDensityRenderer)的点密度符号(DotDensitySymbol)属性
            dotDensityRenderer.DotDensitySymbol = dotDensityFillSymbol;
            //设置渲染密度
            dotDensityRenderer.DotValue = 0.003;
            //设置点密度填充符号的背景色
            dotDensityFillSymbol.BackgroundColor = getRGB(255, 255, 255);
            //创建图例
            dotDensityRenderer.CreateLegend();
            //赋值目标图层的渲染器属性
            geoFeatureLayer.Renderer = dotDensityRenderer as IFeatureRenderer;
            axMapControl1.Refresh(); //刷新axMapControl1
            axTOCControl1.Update(); //更新axTOCControl1

        }
        /// <summary>
        /// 不填充颜色
        /// </summary>
        /// <returns></returns>
        private IColor getNoRGB()
        {
            IRgbColor pColor = new RgbColorClass();
            //.NullColor指示此颜色是否为空。true表明颜色为空
            pColor.NullColor = true;
            return pColor;//返回pColor
        }
        /// <summary>
        /// 添加地图元素
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 添加地图元素ToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //排除数据视图下不能插入
            if (tabControl1.SelectedIndex == 0)
            {
                return;
            }
            //使用UID识别操作命令
            UID uid = new UIDClass();
            if (e.ClickedItem.Text != "")
            {
                //e是鼠标操作所返回的对象, 携带了相关的操作信息
                switch (e.ClickedItem.Text)
                {
                    case "图例":
                        //定义好UID的样式为Carto.legend
                        uid.Value = "ESRICarto.legend";
                        //调用自定义方法AddElementInpageLayer, 下同
                        AddElementInPageLayer(uid);
                        break;
                    case "指北针":
                        //定义好UID的样式为Carto.MarkerNorthArrow
                        uid.Value = "ESRICarto.MarkerNorthArrow";
                        AddElementInPageLayer(uid);
                        break;
                    case "比例尺":
                        //定义好UID的样式为ESRICarto.ScaleLine ??
                        AddScalebar(axPageLayoutControl1.PageLayout, axPageLayoutControl1.ActiveView.FocusMap);
                        break;
                    case "文本":
                        TextInput txtInput = new TextInput();
                        txtInput.ShowDialog();
                        //调用自定义方法加入图名
                        AddTextElement(axPageLayoutControl1, txtInput.Fontsize, txtInput.ThimaticMapName);
                        break;
                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// 添加文本
        /// </summary>
        /// <param name="axPageLayoutControl1">目标PageLayoutControl的Name属性</param>
        /// <param name="fontsize">字体尺寸</param>
        /// <param name="thimaticMapName">图名</param>
        private void AddTextElement(AxPageLayoutControl axPageLayoutControl1, decimal fontsize, string thimaticMapName)
        {
            //创建PageLayout对象
            IPageLayout pPageLayout = axPageLayoutControl1.PageLayout;
            //将PageLayout强转成IActiveView
            IActiveView pAV = (IActiveView)pPageLayout;
            //将PageLayout强转成IGraphicsContainer
            IGraphicsContainer graphicsContainer = (IGraphicsContainer)pPageLayout;
            //实例化文本元素
            ITextElement pTextElement = new TextElementClass();
            //实例化字体元素
            IFontDisp pFont = new StdFontClass() as IFontDisp;
            pFont.Bold = true;
            pFont.Name = "宋体";
            pFont.Size = fontsize;
            //实例化IRgbColor
            IRgbColor pColor = new RgbColorClass();
            pColor.Red = 0;
            pColor.Green = 0;
            pColor.Blue = 0;
            //实例化文本符号
            ITextSymbol pTextSymbol = new TextSymbolClass();
            pTextSymbol.Color = (IColor)pColor;
            pTextSymbol.Font = pFont;
            //赋值元素文本和符号
            pTextElement.Text = thimaticMapName;
            pTextElement.Symbol = pTextSymbol;
            //实例化一个点
            IPoint pPoint = new PointClass();
            pPoint.X = 1;
            pPoint.Y = 1;
            //实例化一个元素
            IElement pElement = (IElement)pTextElement;
            pElement.Geometry = (IGeometry)pPoint;
            graphicsContainer.AddElement(pElement, 0);
            //真正实现部分刷新
            pAV.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        /// <summary>
        /// 添加比例尺
        /// </summary>
        /// <param name="pageLayout"></param>
        /// <param name="map"></param>
        private void AddScalebar(IPageLayout pageLayout, IMap map)
        {
            if (pageLayout == null || map == null)
            {
                return;//当pageLayerout和map为空时返回
            }
            //实例化一个包络线
            IEnvelope envelope = new EnvelopeClass();
            //设定坐标
            envelope.PutCoords(1, 1, 3, 2);
            //实例化一个uid
            IUID uid = new UIDClass();
            //将uid设置为ESRICarto.scalebar
            uid.Value = "ESRICarto.scalebar";
            //提供对控制图形容器的成员的访问
            IGraphicsContainer graphicsContainer = pageLayout as IGraphicsContainer;
            //查找map中指定对象的框架
            IMapFrame mapFrame = graphicsContainer.FindFrame(map) as IMapFrame;
            //创建基于当前地图框下的一个新地图环绕元素
            IMapSurroundFrame mapSurroundFrame = mapFrame.CreateSurroundFrame(uid as UID, null);
            //元素属性
            IElementProperties pElePro;
            //实例化一个比例尺对象
            IScaleBar markerScaleBar = new AlternatingScaleBarClass();
            //可以有多种比例尺类型
            markerScaleBar.Division = 2;
            markerScaleBar.Divisions = 2;
            markerScaleBar.LabelPosition = esriVertPosEnum.esriAbove;
            markerScaleBar.Map = map;
            markerScaleBar.Subdivisions = 2;
            markerScaleBar.UnitLabel = "";
            markerScaleBar.UnitLabelGap = 4;
            markerScaleBar.UnitLabelPosition = esriScaleBarPos.esriScaleBarAbove; //位于比例尺上方
            markerScaleBar.Units = esriUnits.esriKilometers; //千米
            mapSurroundFrame.MapSurround = markerScaleBar;
            //将mapSurroundFrame强转为IElementProperties
            pElePro = mapSurroundFrame as IElementProperties;
            //设置元素Name属性
            pElePro.Name = "my scale";
            //添加元素至axPageLayoutControl1
            axPageLayoutControl1.AddElement(mapSurroundFrame as IElement, envelope, Type.Missing, Type.Missing, 0);
            //部分刷新
            axPageLayoutControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, Type.Missing, null);
        }

        /// <summary>
        /// 添加图例或指北针——根据UID元素添加相应的元素
        /// </summary>
        /// <param name="uid"></param>
        private void AddElementInPageLayer(UID uid)
        {
            //提供对控制图形容器的成员的访问。
            IGraphicsContainer graphicsContainer = axPageLayoutControl1.PageLayout as IGraphicsContainer;
            //提供对成员的访问, 控制map元素的对象, IMapFrame是地图浏览栏对象的默认接口
            //通过FindFrame方法, 查找axPageLayoutControl1中屏幕包含指定对象的框架
            IMapFrame mapFrame = graphicsContainer.FindFrame(axPageLayoutControl1.ActiveView.FocusMap) as IMapFrame;
            //提供对成员的访问, 控制地图环绕元素映射的接口, 是附属物框架的对象的默认接口
            //通过CreateSurroundFrame方法创建基于当前地图框下的一个新地图环绕元素(如图例、指北针)
            IMapSurroundFrame mapSurroundFrame = mapFrame.CreateSurroundFrame(uid, null);
            //IElement是所有图形元素和框架元素类都要实现的接口
            //将mapSurroundFrame强转成IElement类型
            IElement element = mapSurroundFrame as IElement;
            //实例化一个包络线
            IEnvelope envelope = new EnvelopeClass();
            //设定坐标
            envelope.PutCoords(1, 1, 2, 2);
            //设置元素中的几何形状
            element.Geometry = envelope;
            try
            {
                //提供对控制图例的成员的访问。
                ILegend legend = (ILegend)mapSurroundFrame.MapSurround;
                legend.Title = "图例";
            }
            catch
            { }
            graphicsContainer.AddElement(element, 0);
            //设置元素将在axPageLayoutControl屏幕上显示图形
            element.Activate(axPageLayoutControl1.ActiveView.ScreenDisplay);
            //部分刷新
            axPageLayoutControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }
        /// <summary>
        /// 用来控制“添加地图要素”的控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            axMapControl1.CurrentTool = null;
            axPageLayoutControl1.CurrentTool = null;
            synchronization();
            if(tabControl1.SelectedIndex==1)
            {
                ThimaticMapKeys(true);
            }
            else
            {
                ThimaticMapKeys(false);
            }
         
        }
        /// <summary>
        /// 实现MapControl与Pagelayout的同步方法
        /// </summary>
        private void synchronization()
        {
            IObjectCopy objectCopy = new ObjectCopyClass();
            object copyFromMap = axMapControl1.Map;
            object copyMap = objectCopy.Copy(copyFromMap);
            object copyToMap = axPageLayoutControl1.ActiveView.FocusMap;
            objectCopy.Overwrite(copyMap, ref copyToMap);
        }
    }
}
