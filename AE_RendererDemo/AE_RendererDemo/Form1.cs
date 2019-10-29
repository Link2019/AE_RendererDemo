using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
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
            IFeatureLayer pFtLayer;
            //声明专题图变量
            IProportionalSymbolRenderer proportionalSymbolRenderer;
            ITable table;
            ICursor cursor;
            //统计变量
            IDataStatistics dataStatistics;
            //存放统计结果
            IStatisticsResults statisticsResults;
            //声明一个字体对象
            stdole.IFontDisp fontDisp;
            //获取图层Continents
            geoFeatureLayer = getGeoLayer("北部湾");//北部湾是实例中用到的数据图层名
            pFtLayer = geoFeatureLayer as IFeatureLayer;
            //图层类型转换成表
            table = geoFeatureLayer as ITable;
            cursor = table.Search(null, true);
            dataStatistics = new DataStatisticsClass();
            dataStatistics.Cursor = cursor;
            //获取图层要素中进行专题地图制图的字段名称, 此实例中所用的数据中字段名为"年"(2010年GDP增长速率)
            dataStatistics.Field = "年";
            statisticsResults = dataStatistics.Statistics;
            if (statisticsResults != null)
            {
                //设置背景(Backgroup)的颜色值
                IFillSymbol fillSymbol = new SimpleFillSymbolClass();
                fillSymbol.Color = getRGB(195, 255, 255);
                //设置背景(Backgroud)的线型
                ISimpleLineSymbol SLS = new SimpleLineSymbolClass();
                SLS.Color = getRGB(196, 196, 196);
                SLS.Width = 1.5;
                fillSymbol.Outline = SLS;
                //注释：以下提供两种方法进行符号填充。
                //方法一：利用ESRI特殊符号调用成员进行填充;
                //方法二:利用简单标记符号(ISimpleMarkerSymol)进行填充
                ICharacterMarkerSymbol characterMarkerSymbol = new CharacterMarkerSymbolClass();
                //如ESRI Default Marker是子库名称
                fontDisp = new stdole.StdFontClass() as stdole.IFontDisp;
                //调用指定子库


            }

        }
    }
}
