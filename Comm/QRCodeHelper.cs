
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ThoughtWorks.QRCode.Codec;

namespace Comm
{
  
    public class QRCodeHelper
    {
        #region 生成二维码一
        public static void GetQrcode(string url)
        {
            string path = "F:/Readme/WebApplication1/Asp.NetApp/QrcodeImage/";    //文件目录  
            string filePath = Path.Combine(path + Guid.NewGuid() + ".jpg");                                        //二维码文件名  

            if (Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            // string filePath = "../../QrcodeImage";
            if (Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);
            // 生成二维码的内容
            string strCode = url;// "http://c7.gg/aeGWU";
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(strCode, QRCodeGenerator.ECCLevel.Q);
            QRCode qrcode = new QRCode(qrCodeData);

            // qrcode.GetGraphic 方法可参考最下发“补充说明”
            Bitmap qrCodeImage = qrcode.GetGraphic(5, Color.Black, Color.White, null, 15, 6, false);
            MemoryStream ms = new MemoryStream();
            qrCodeImage.Save(ms, ImageFormat.Jpeg);

            //// 如果想保存图片 可使用 
            qrCodeImage.Save(filePath);

            //// 响应类型
            //context.Response.ContentType = "image/Jpeg";
            ////输出字符流
            //context.Response.BinaryWrite(ms.ToArray());
        }

        /// <summary>  
        /// 创建二维码  
        /// </summary>  
        /// <param name="QRString">二维码字符串</param>  
        /// <param name="QRCodeEncodeMode">二维码编码(Byte、AlphaNumeric、Numeric)</param>  
        /// <param name="QRCodeScale">二维码尺寸(Version为0时，1：26x26，每加1宽和高各加25</param>  
        /// <param name="QRCodeVersion">二维码密集度0-40</param>  
        /// <param name="QRCodeErrorCorrect">二维码纠错能力(L：7% M：15% Q：25% H：30%)</param>  
        /// <param name="filePath">保存路径</param>  
        /// <param name="hasLogo">是否有logo(logo尺寸50x50，QRCodeScale>=5，QRCodeErrorCorrect为H级)</param>  
        /// <param name="logoFilePath">logo路径</param>  
        /// <returns></returns>  
        public static bool CreateQRCode(string QRString, string QRCodeEncodeMode, short QRCodeScale, int QRCodeVersion, string QRCodeErrorCorrect, string filePath, bool hasLogo, string logoFilePath)
        {
            bool result = true;

            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();

            switch (QRCodeEncodeMode)
            {
                case "Byte":
                    qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                    break;
                case "AlphaNumeric":
                    qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.ALPHA_NUMERIC;
                    break;
                case "Numeric":
                    qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.NUMERIC;
                    break;
                default:
                    qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                    break;
            }

            qrCodeEncoder.QRCodeScale = QRCodeScale;
            qrCodeEncoder.QRCodeVersion = QRCodeVersion;

            switch (QRCodeErrorCorrect)
            {
                case "L":
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
                    break;
                case "M":
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                    break;
                case "Q":
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.Q;
                    break;
                case "H":
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H;
                    break;
                default:
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H;
                    break;
            }

            try
            {

                Image image = qrCodeEncoder.Encode(QRString, System.Text.Encoding.UTF8);
                System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
                image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                fs.Close();

                if (hasLogo)
                {
                    Image copyImage = System.Drawing.Image.FromFile(logoFilePath);
                    Graphics g = Graphics.FromImage(image);
                    int x = image.Width / 2 - copyImage.Width / 2;
                    int y = image.Height / 2 - copyImage.Height / 2;
                    g.DrawImage(copyImage, new Rectangle(x, y, copyImage.Width, copyImage.Height), 0, 0, copyImage.Width, copyImage.Height, GraphicsUnit.Pixel);
                    g.Dispose();

                    image.Save(filePath);
                    copyImage.Dispose();
                }
                image.Dispose();

            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        /// 生成二维码图片
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="size">图片大小</param>
        /// <param name="path">图片位置 
        /// 例如  /abc/abc/
        /// </param>
        /// <returns>返回生成的二维码图片路径</returns>
        public static string Create(string str, int size, string path)
        {
            try
            {

                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                //设置编码模式
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                //设置编码测量度
                qrCodeEncoder.QRCodeScale = size;
                //设置编码版本
                qrCodeEncoder.QRCodeVersion = 8;
                //设置编码错误纠正
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                string filename = "~" + path + Guid.NewGuid() + ".jpg";
                using (System.Drawing.Image image = qrCodeEncoder.Encode(str, Encoding.UTF8))
                {

                    image.Save(filename);
                    image.Dispose();
                }

                return filename.Replace("~", "");
            }
            catch (Exception ex)
            {

                return "";
            }

        }

        /// <summary>    
        /// 调用此函数后使此两种图片合并，类似相册，有个    
        /// 背景图，中间贴自己的目标图片    
        /// </summary>    
        /// <param name="imgBack">粘贴的源图片</param>    
        /// <param name="destImg">粘贴的目标图片</param>    
        public static Image CombinImage(Image imgBack, string destImg)
        {
            Image img = Image.FromFile(destImg);        //照片图片      
            if (img.Height != 65 || img.Width != 65)
            {
                img = KiResizeImage(img, 65, 65, 0);
            }
            Graphics g = Graphics.FromImage(imgBack);

            g.DrawImage(imgBack, 0, 0, imgBack.Width, imgBack.Height);      //g.DrawImage(imgBack, 0, 0, 相框宽, 相框高);     

            //g.FillRectangle(System.Drawing.Brushes.White, imgBack.Width / 2 - img.Width / 2 - 1, imgBack.Width / 2 - img.Width / 2 - 1,1,1);//相片四周刷一层黑色边框    

            //g.DrawImage(img, 照片与相框的左边距, 照片与相框的上边距, 照片宽, 照片高);    

            g.DrawImage(img, imgBack.Width / 2 - img.Width / 2, imgBack.Width / 2 - img.Width / 2, img.Width, img.Height);
            GC.Collect();
            return imgBack;
        }

        /// <summary>    
        /// Resize图片    
        /// </summary>    
        /// <param name="bmp">原始Bitmap</param>    
        /// <param name="newW">新的宽度</param>    
        /// <param name="newH">新的高度</param>    
        /// <param name="Mode">保留着，暂时未用</param>    
        /// <returns>处理以后的图片</returns>    
        public static Image KiResizeImage(Image bmp, int newW, int newH, int Mode)
        {
            try
            {
                Image b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);
                // 插值算法的质量    
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                g.Dispose();
                return b;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region 生成二维码二

////        接口B：适用于需要的码数量极多，或仅临时使用的业务场景

////接口地址：https://api.weixin.qq.com/wxa/getwxacodeunlimit?access_token=ACCESS_TOKEN
 
////注意：通过该接口生成的小程序码，永久有效，数量暂无限制。用户扫描该码进入小程序后，开发者需在对应页面获取的码中 scene 字段的值，再做处理逻辑。使用如下代码可以获取到二维码中的 scene 字段的值。调试阶段可以使用开发工具的条件编译自定义参数 scene = xxxx 进行模拟，开发工具模拟时的 scene 的参数值需要进行 urlencode

////// 这是首页的 js
////        Page({
////        onLoad: function(options) {
////                // options 中的 scene 需要使用 decodeURIComponent 才能获取到生成二维码时传入的 scene
////                var scene = decodeURIComponent(options.scene)
////        }
////        })
 
////详情可见小程序开发文档：https://mp.weixin.qq.com/debug/wxadoc/dev/api/qrcode.html

        /// <summary>
        /// B接口-微信小程序带参数二维码的生成
        /// </summary>
        /// <param name="MicroId"></param>
        /// <returns></returns>
        public static string CreateWxCode(int MicroId, int UserId, int CardLevel)
        {
            string ret = string.Empty;
            try
            {
                string DataJson = string.Empty;
                string url = "https://api.weixin.qq.com/wxa/getwxacodeunlimit?access_token=*****************";
                DataJson = "{";
                DataJson += string.Format("\"scene\":\"{0}\",", "所传参数内容1,所传参数内容2");//所要传的参数用,分看
                DataJson += string.Format("\"width\":\"{0}\",", 124);
                DataJson += string.Format("\"page\":\"{0}\",", "pages/index/index");//扫码所要跳转的地址，根路径前不要填加'/',不能携带参数（参数请放在scene字段里），如果不填写这个字段，默认跳主页面
                DataJson += "\"line_color\":{";
                DataJson += string.Format("\"r\":\"{0}\",", "0");
                DataJson += string.Format("\"g\":\"{0}\",", "0");
                DataJson += string.Format("\"b\":\"{0}\"", "0");
                DataJson += "}";
                DataJson += "}";
                //DataJson的配置见小程序开发文档，B接口：https://mp.weixin.qq.com/debug/wxadoc/dev/api/qrcode.html
                ret = PostMoths(url, DataJson);
                if (ret.Length > 0)
                {
                    //对图片进行存储操作，下次可直接调用你存储的图片，不用再调用接口
                }
            }
            catch (Exception e)
            { ret = e.Message; }
            return ret;//返回图片地址
        }

        //请求处理，返回二维码图片
        public static string PostMoths(string url, string param)
        {
            string strURL = url;
            System.Net.HttpWebRequest request;
            request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";
            string paraUrlCoded = param;
            byte[] payload;
            payload = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);
            request.ContentLength = payload.Length;
            Stream writer = request.GetRequestStream();
            writer.Write(payload, 0, payload.Length);
            writer.Close();
            System.Net.HttpWebResponse response;
            response = (System.Net.HttpWebResponse)request.GetResponse();
            System.IO.Stream s;
            s = response.GetResponseStream();//返回图片数据流
            byte[] tt = StreamToBytes(s);//将数据流转为byte[]

            //在文件名前面加上时间，以防重名
            string imgName = DateTime.Now.ToString("yyyyMMddhhmmss") + ".jpg";
            //文件存储相对于当前应用目录的虚拟目录
            string path = "/image/";
            //获取相对于应用的基目录,创建目录
            string imgPath = System.AppDomain.CurrentDomain.BaseDirectory + path;     //通过此对象获取文件名
            //StringHelper.CreateDirectory(imgPath);
            System.IO.File.WriteAllBytes(HttpContext.Current.Server.MapPath(path + imgName), tt);//讲byte[]存储为图片
            return "/image/" + imgName;
        }
        ///将数据流转为byte[]
        public static byte[] StreamToBytes(Stream stream)
        {
            List<byte> bytes = new List<byte>();
            int temp = stream.ReadByte();
            while (temp != -1)
            {
                bytes.Add((byte)temp);
                temp = stream.ReadByte();
            }
            return bytes.ToArray();
        }
        #endregion

    }
}
