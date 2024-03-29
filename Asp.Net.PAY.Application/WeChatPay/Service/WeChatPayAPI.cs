﻿using Asp.Net.PAY.Application.WeChatPay.Model;
using System;

namespace Asp.Net.PAY.Application.WeChatPay.Service
{
    public class WeChatPayAPI
    {

        /// <summary>
        /// 调用统一下单，获得下单结果
        /// @return 统一下单结果
        /// @失败时抛异常WeChatPayException
        /// </summary>
        /// <returns></returns>
        public WeChatPayData GetUnifiedOrderResult(int total_fee, string openid)
        {
            //统一下单
            WeChatPayData data = new WeChatPayData();
            string str = GenerateOutTradeNo();
            data.SetValue("body", "");
            data.SetValue("attach", "");
            data.SetValue("out_trade_no", str);
            data.SetValue("total_fee", total_fee);
            data.SetValue("time_start", DateTime.Now.ToString("yyyyMMddHHmmss"));
            data.SetValue("time_expire", DateTime.Now.AddMinutes(10).ToString("yyyyMMddHHmmss"));
            data.SetValue("goods_tag", "WXG");
            data.SetValue("trade_type", "JSAPI");
            data.SetValue("openid", openid);

            WeChatPayData result = UnifiedOrder(data);
            if (!result.IsSet("appid") || !result.IsSet("prepay_id") || result.GetValue("prepay_id").ToString() == "")
            {
                LogHelper.Error(this.GetType().ToString(), "UnifiedOrder response error!");
                throw new WeChatPayException("UnifiedOrder response error!");
            }


            return result;
        }

        /// <summary>
        /// 提交被扫支付API
        /// 收银员使用扫码设备读取微信用户刷卡授权码以后，二维码或条码信息传送至商户收银台，
        /// 由商户收银台或者商户后台调用该接口发起支付。
        /// @param WeChatPayData inputObj 提交给被扫支付API的参数
        /// @param int timeOut 超时时间
        /// @throws WeChatPayException
        /// @return 成功时返回调用结果，其他抛异常/
        /// </summary>
        /// <param name="inputObj"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static WeChatPayData Micropay(WeChatPayData inputObj, int timeOut = 10)
        {
            string url = "https://api.mch.weixin.qq.com/pay/micropay";
            //检测必填参数
            if (!inputObj.IsSet("body"))
            {
                throw new WeChatPayException("提交被扫支付API接口中，缺少必填参数body！");
            }
            else if (!inputObj.IsSet("out_trade_no"))
            {
                throw new WeChatPayException("提交被扫支付API接口中，缺少必填参数out_trade_no！");
            }
            else if (!inputObj.IsSet("total_fee"))
            {
                throw new WeChatPayException("提交被扫支付API接口中，缺少必填参数total_fee！");
            }
            else if (!inputObj.IsSet("auth_code"))
            {
                throw new WeChatPayException("提交被扫支付API接口中，缺少必填参数auth_code！");
            }

            inputObj.SetValue("spbill_create_ip", WeChatPayConfig.IP);//终端ip
            inputObj.SetValue("appid", WeChatPayConfig.APPID);//公众账号ID
            inputObj.SetValue("mch_id", WeChatPayConfig.MCHID);//商户号
            inputObj.SetValue("nonce_str", Guid.NewGuid().ToString().Replace("-", ""));//随机字符串
            inputObj.SetValue("sign", inputObj.MakeSign());//签名
            string xml = inputObj.ToXml();

            var start = DateTime.Now;//请求开始时间

            LogHelper.Debug("WeChatPayAPI", "MicroPay request : " + xml);
            string response = HttpService.Post(xml, url, false, timeOut);//调用HTTP通信接口以提交数据到API
            LogHelper.Debug("WeChatPayAPI", "MicroPay response : " + response);

            var end = DateTime.Now;
            int timeCost = (int)((end - start).TotalMilliseconds);//获得接口耗时

            //将xml格式的结果转换为对象以返回
            WeChatPayData result = new WeChatPayData();
            result.FromXml(response);

            ReportCostTime(url, timeCost, result);//测速上报

            return result;
        }


        /// <summary>
        /// 查询订单
        /// @param WeChatPayData inputObj 提交给查询订单API的参数
        /// @param int timeOut 超时时间
        /// @throws WeChatPayException
        /// @return 成功时返回订单查询结果，其他抛异常
        /// </summary>
        /// <param name="inputObj"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static WeChatPayData OrderQuery(WeChatPayData inputObj, int timeOut = 6)
        {
            string url = "https://api.mch.weixin.qq.com/pay/orderquery";
            //检测必填参数
            if (!inputObj.IsSet("out_trade_no") && !inputObj.IsSet("transaction_id"))
            {
                throw new WeChatPayException("订单查询接口中，out_trade_no、transaction_id至少填一个！");
            }

            inputObj.SetValue("appid", WeChatPayConfig.APPID);//公众账号ID
            inputObj.SetValue("mch_id", WeChatPayConfig.MCHID);//商户号
            inputObj.SetValue("nonce_str", WeChatPayAPI.GenerateNonceStr());//随机字符串
            inputObj.SetValue("sign", inputObj.MakeSign());//签名

            string xml = inputObj.ToXml();

            var start = DateTime.Now;

            LogHelper.Debug("WeChatPayAPI", "OrderQuery request : " + xml);
            string response = HttpService.Post(xml, url, false, timeOut);//调用HTTP通信接口提交数据
            LogHelper.Debug("WeChatPayAPI", "OrderQuery response : " + response);

            var end = DateTime.Now;
            int timeCost = (int)((end - start).TotalMilliseconds);//获得接口耗时

            //将xml格式的数据转化为对象以返回
            WeChatPayData result = new WeChatPayData();
            result.FromXml(response);

            ReportCostTime(url, timeCost, result);//测速上报

            return result;
        }


        /// <summary>
        /// 撤销订单API接口
        /// @param WeChatPayData inputObj 提交给撤销订单API接口的参数，out_trade_no和transaction_id必填一个
        /// @param int timeOut 接口超时时间
        /// @throws WeChatPayException
        /// @return 成功时返回API调用结果，其他抛异常
        /// </summary>
        /// <param name="inputObj"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static WeChatPayData Reverse(WeChatPayData inputObj, int timeOut = 6)
        {
            string url = "https://api.mch.weixin.qq.com/secapi/pay/reverse";
            //检测必填参数
            if (!inputObj.IsSet("out_trade_no") && !inputObj.IsSet("transaction_id"))
            {
                throw new WeChatPayException("撤销订单API接口中，参数out_trade_no和transaction_id必须填写一个！");
            }

            inputObj.SetValue("appid", WeChatPayConfig.APPID);//公众账号ID
            inputObj.SetValue("mch_id", WeChatPayConfig.MCHID);//商户号
            inputObj.SetValue("nonce_str", GenerateNonceStr());//随机字符串
            inputObj.SetValue("sign", inputObj.MakeSign());//签名
            string xml = inputObj.ToXml();

            var start = DateTime.Now;//请求开始时间

            LogHelper.Debug("WeChatPayAPI", "Reverse request : " + xml);

            string response = HttpService.Post(xml, url, true, timeOut);

            LogHelper.Debug("WeChatPayAPI", "Reverse response : " + response);

            var end = DateTime.Now;
            int timeCost = (int)((end - start).TotalMilliseconds);

            WeChatPayData result = new WeChatPayData();
            result.FromXml(response);

            ReportCostTime(url, timeCost, result);//测速上报

            return result;
        }


        /// <summary>
        /// 申请退款
        /// @param WeChatPayData inputObj 提交给申请退款API的参数
        /// @param int timeOut 超时时间
        /// @throws WeChatPayException
        /// @return 成功时返回接口调用结果，其他抛异常
        /// </summary>
        /// <param name="inputObj"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static WeChatPayData Refund(WeChatPayData inputObj, int timeOut = 6)
        {
            string url = "https://api.mch.weixin.qq.com/secapi/pay/refund";
            //检测必填参数
            if (!inputObj.IsSet("out_trade_no") && !inputObj.IsSet("transaction_id"))
            {
                throw new WeChatPayException("退款申请接口中，out_trade_no、transaction_id至少填一个！");
            }
            else if (!inputObj.IsSet("out_refund_no"))
            {
                throw new WeChatPayException("退款申请接口中，缺少必填参数out_refund_no！");
            }
            else if (!inputObj.IsSet("total_fee"))
            {
                throw new WeChatPayException("退款申请接口中，缺少必填参数total_fee！");
            }
            else if (!inputObj.IsSet("refund_fee"))
            {
                throw new WeChatPayException("退款申请接口中，缺少必填参数refund_fee！");
            }
            else if (!inputObj.IsSet("op_user_id"))
            {
                throw new WeChatPayException("退款申请接口中，缺少必填参数op_user_id！");
            }

            inputObj.SetValue("appid", WeChatPayConfig.APPID);//公众账号ID
            inputObj.SetValue("mch_id", WeChatPayConfig.MCHID);//商户号
            inputObj.SetValue("nonce_str", Guid.NewGuid().ToString().Replace("-", ""));//随机字符串
            inputObj.SetValue("sign", inputObj.MakeSign());//签名

            string xml = inputObj.ToXml();
            var start = DateTime.Now;

            LogHelper.Debug("WeChatPayAPI", "Refund request : " + xml);
            string response = HttpService.Post(xml, url, true, timeOut);//调用HTTP通信接口提交数据到API
            LogHelper.Debug("WeChatPayAPI", "Refund response : " + response);

            var end = DateTime.Now;
            int timeCost = (int)((end - start).TotalMilliseconds);//获得接口耗时

            //将xml格式的结果转换为对象以返回
            WeChatPayData result = new WeChatPayData();
            result.FromXml(response);

            ReportCostTime(url, timeCost, result);//测速上报

            return result;
        }


        /// <summary>
        /// 查询退款
        /// 提交退款申请后，通过该接口查询退款状态。退款有一定延时，
        /// 用零钱支付的退款20分钟内到账，银行卡支付的退款3个工作日后重新查询退款状态。
        /// out_refund_no、out_trade_no、transaction_id、refund_id四个参数必填一个
        /// @param WeChatPayData inputObj 提交给查询退款API的参数
        /// @param int timeOut 接口超时时间
        /// @throws WeChatPayException
        /// @return 成功时返回，其他抛异常
        /// </summary>
        /// <param name="inputObj"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static WeChatPayData RefundQuery(WeChatPayData inputObj, int timeOut = 6)
        {
            string url = "https://api.mch.weixin.qq.com/pay/refundquery";
            //检测必填参数
            if (!inputObj.IsSet("out_refund_no") && !inputObj.IsSet("out_trade_no") &&
                !inputObj.IsSet("transaction_id") && !inputObj.IsSet("refund_id"))
            {
                throw new WeChatPayException("退款查询接口中，out_refund_no、out_trade_no、transaction_id、refund_id四个参数必填一个！");
            }

            inputObj.SetValue("appid", WeChatPayConfig.APPID);//公众账号ID
            inputObj.SetValue("mch_id", WeChatPayConfig.MCHID);//商户号
            inputObj.SetValue("nonce_str", GenerateNonceStr());//随机字符串
            inputObj.SetValue("sign", inputObj.MakeSign());//签名

            string xml = inputObj.ToXml();

            var start = DateTime.Now;//请求开始时间

            LogHelper.Debug("WeChatPayAPI", "RefundQuery request : " + xml);
            string response = HttpService.Post(xml, url, false, timeOut);//调用HTTP通信接口以提交数据到API
            LogHelper.Debug("WeChatPayAPI", "RefundQuery response : " + response);

            var end = DateTime.Now;
            int timeCost = (int)((end - start).TotalMilliseconds);//获得接口耗时

            //将xml格式的结果转换为对象以返回
            WeChatPayData result = new WeChatPayData();
            result.FromXml(response);

            ReportCostTime(url, timeCost, result);//测速上报

            return result;
        }


        /// <summary>
        /// 下载对账单
        /// @param WeChatPayData inputObj 提交给下载对账单API的参数
        /// @param int timeOut 接口超时时间
        /// @throws WeChatPayException
        /// @return 成功时返回，其他抛异常
        /// </summary>
        /// <param name="inputObj"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static WeChatPayData DownloadBill(WeChatPayData inputObj, int timeOut = 6)
        {
            string url = "https://api.mch.weixin.qq.com/pay/downloadbill";
            //检测必填参数
            if (!inputObj.IsSet("bill_date"))
            {
                throw new WeChatPayException("对账单接口中，缺少必填参数bill_date！");
            }

            inputObj.SetValue("appid", WeChatPayConfig.APPID);//公众账号ID
            inputObj.SetValue("mch_id", WeChatPayConfig.MCHID);//商户号
            inputObj.SetValue("nonce_str", GenerateNonceStr());//随机字符串
            inputObj.SetValue("sign", inputObj.MakeSign());//签名

            string xml = inputObj.ToXml();

            LogHelper.Debug("WeChatPayAPI", "DownloadBill request : " + xml);
            string response = HttpService.Post(xml, url, false, timeOut);//调用HTTP通信接口以提交数据到API
            LogHelper.Debug("WeChatPayAPI", "DownloadBill result : " + response);

            WeChatPayData result = new WeChatPayData();
            //若接口调用失败会返回xml格式的结果
            if (response.Substring(0, 5) == "<xml>")
            {
                result.FromXml(response);
            }
            //接口调用成功则返回非xml格式的数据
            else
                result.SetValue("result", response);

            return result;
        }


        /// <summary>
        /// 转换短链接
        /// 该接口主要用于扫码原生支付模式一中的二维码链接转成短链接(weixin://wxpay/s/XXXXXX)，
        /// 减小二维码数据量，提升扫描速度和精确度。
        /// @param WeChatPayData inputObj 提交给转换短连接API的参数
        /// @param int timeOut 接口超时时间
        /// @throws WeChatPayException
        /// @return 成功时返回，其他抛异常
        /// </summary>
        /// <param name="inputObj"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static WeChatPayData ShortUrl(WeChatPayData inputObj, int timeOut = 6)
        {
            string url = "https://api.mch.weixin.qq.com/tools/shorturl";
            //检测必填参数
            if (!inputObj.IsSet("long_url"))
            {
                throw new WeChatPayException("需要转换的URL，签名用原串，传输需URL encode！");
            }

            inputObj.SetValue("appid", WeChatPayConfig.APPID);//公众账号ID
            inputObj.SetValue("mch_id", WeChatPayConfig.MCHID);//商户号
            inputObj.SetValue("nonce_str", GenerateNonceStr());//随机字符串	
            inputObj.SetValue("sign", inputObj.MakeSign());//签名
            string xml = inputObj.ToXml();

            var start = DateTime.Now;//请求开始时间

            LogHelper.Debug("WeChatPayAPI", "ShortUrl request : " + xml);
            string response = HttpService.Post(xml, url, false, timeOut);
            LogHelper.Debug("WeChatPayAPI", "ShortUrl response : " + response);

            var end = DateTime.Now;
            int timeCost = (int)((end - start).TotalMilliseconds);

            WeChatPayData result = new WeChatPayData();
            result.FromXml(response);
            ReportCostTime(url, timeCost, result);//测速上报

            return result;
        }


        /// <summary>
        /// 统一下单
        /// @param WeChatPayData inputObj 提交给统一下单API的参数
        /// @param int timeOut 超时时间
        /// @throws WeChatPayException
        /// @return 成功时返回，其他抛异常
        /// </summary>
        /// <param name="inputObj"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static WeChatPayData UnifiedOrder(WeChatPayData inputObj, int timeOut = 6)
        {
            string url = "https://api.mch.weixin.qq.com/pay/unifiedorder";
            //检测必填参数
            if (!inputObj.IsSet("out_trade_no"))
            {
                throw new WeChatPayException("缺少统一支付接口必填参数out_trade_no！");
            }
            else if (!inputObj.IsSet("body"))
            {
                throw new WeChatPayException("缺少统一支付接口必填参数body！");
            }
            else if (!inputObj.IsSet("total_fee"))
            {
                throw new WeChatPayException("缺少统一支付接口必填参数total_fee！");
            }
            else if (!inputObj.IsSet("trade_type"))
            {
                throw new WeChatPayException("缺少统一支付接口必填参数trade_type！");
            }

            //关联参数
            if (inputObj.GetValue("trade_type").ToString() == "JSAPI" && !inputObj.IsSet("openid"))
            {
                throw new WeChatPayException("统一支付接口中，缺少必填参数openid！trade_type为JSAPI时，openid为必填参数！");
            }
            if (inputObj.GetValue("trade_type").ToString() == "NATIVE" && !inputObj.IsSet("product_id"))
            {
                throw new WeChatPayException("统一支付接口中，缺少必填参数product_id！trade_type为JSAPI时，product_id为必填参数！");
            }

            //异步通知url未设置，则使用配置文件中的url
            if (!inputObj.IsSet("notify_url"))
            {
                inputObj.SetValue("notify_url", WeChatPayConfig.NOTIFY_URL);//异步通知url
            }

            inputObj.SetValue("appid", WeChatPayConfig.APPID);//公众账号ID
            inputObj.SetValue("mch_id", WeChatPayConfig.MCHID);//商户号
            inputObj.SetValue("spbill_create_ip", WeChatPayConfig.IP);//终端ip	  	    
            inputObj.SetValue("nonce_str", GenerateNonceStr());//随机字符串

            //签名
            inputObj.SetValue("sign", inputObj.MakeSign());
            string xml = inputObj.ToXml();

            var start = DateTime.Now;

            LogHelper.Debug("WeChatPayAPI", "UnfiedOrder request : " + xml);
            string response = HttpService.Post(xml, url, false, timeOut);
            LogHelper.Debug("WeChatPayAPI", "UnfiedOrder response : " + response);

            var end = DateTime.Now;
            int timeCost = (int)((end - start).TotalMilliseconds);

            WeChatPayData result = new WeChatPayData();
            result.FromXml(response);

            ReportCostTime(url, timeCost, result);//测速上报

            return result;
        }


        /// <summary>
        /// 关闭订单
        /// @param WeChatPayData inputObj 提交给关闭订单API的参数
        /// @param int timeOut 接口超时时间
        /// @throws WeChatPayException
        /// @return 成功时返回，其他抛异常
        /// </summary>
        /// <param name="inputObj"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static WeChatPayData CloseOrder(WeChatPayData inputObj, int timeOut = 6)
        {
            string url = "https://api.mch.weixin.qq.com/pay/closeorder";
            //检测必填参数
            if (!inputObj.IsSet("out_trade_no"))
            {
                throw new WeChatPayException("关闭订单接口中，out_trade_no必填！");
            }

            inputObj.SetValue("appid", WeChatPayConfig.APPID);//公众账号ID
            inputObj.SetValue("mch_id", WeChatPayConfig.MCHID);//商户号
            inputObj.SetValue("nonce_str", GenerateNonceStr());//随机字符串		
            inputObj.SetValue("sign", inputObj.MakeSign());//签名
            string xml = inputObj.ToXml();

            var start = DateTime.Now;//请求开始时间

            string response = HttpService.Post(xml, url, false, timeOut);

            var end = DateTime.Now;
            int timeCost = (int)((end - start).TotalMilliseconds);

            WeChatPayData result = new WeChatPayData();
            result.FromXml(response);

            ReportCostTime(url, timeCost, result);//测速上报

            return result;
        }


        /// <summary>
        ///测速上报
        ///@param string interface_url 接口URL
        ///@param int timeCost 接口耗时
        ///@param WeChatPayData inputObj参数数组
        /// </summary>
        /// <param name="interface_url"></param>
        /// <param name="timeCost"></param>
        /// <param name="inputObj"></param>
        private static void ReportCostTime(string interface_url, int timeCost, WeChatPayData inputObj)
        {
            //如果不需要进行上报
            if (WeChatPayConfig.REPORT_LEVENL == 0)
            {
                return;
            }

            //如果仅失败上报
            if (WeChatPayConfig.REPORT_LEVENL == 1 && inputObj.IsSet("return_code") && inputObj.GetValue("return_code").ToString() == "SUCCESS" &&
             inputObj.IsSet("result_code") && inputObj.GetValue("result_code").ToString() == "SUCCESS")
            {
                return;
            }

            //上报逻辑
            WeChatPayData data = new WeChatPayData();
            data.SetValue("interface_url", interface_url);
            data.SetValue("execute_time_", timeCost);
            //返回状态码
            if (inputObj.IsSet("return_code"))
            {
                data.SetValue("return_code", inputObj.GetValue("return_code"));
            }
            //返回信息
            if (inputObj.IsSet("return_msg"))
            {
                data.SetValue("return_msg", inputObj.GetValue("return_msg"));
            }
            //业务结果
            if (inputObj.IsSet("result_code"))
            {
                data.SetValue("result_code", inputObj.GetValue("result_code"));
            }
            //错误代码
            if (inputObj.IsSet("err_code"))
            {
                data.SetValue("err_code", inputObj.GetValue("err_code"));
            }
            //错误代码描述
            if (inputObj.IsSet("err_code_des"))
            {
                data.SetValue("err_code_des", inputObj.GetValue("err_code_des"));
            }
            //商户订单号
            if (inputObj.IsSet("out_trade_no"))
            {
                data.SetValue("out_trade_no", inputObj.GetValue("out_trade_no"));
            }
            //设备号
            if (inputObj.IsSet("device_info"))
            {
                data.SetValue("device_info", inputObj.GetValue("device_info"));
            }

            try
            {
                Report(data);
            }
            catch (WeChatPayException ex)
            {
                //不做任何处理
            }
        }


        /// <summary>
        /// 测速上报接口实现
        /// @param WeChatPayData inputObj 提交给测速上报接口的参数
        /// @param int timeOut 测速上报接口超时时间
        /// @throws WeChatPayException
        /// @return 成功时返回测速上报接口返回的结果，其他抛异常
        /// </summary>
        /// <param name="inputObj"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static WeChatPayData Report(WeChatPayData inputObj, int timeOut = 1)
        {
            string url = "https://api.mch.weixin.qq.com/payitil/report";
            //检测必填参数
            if (!inputObj.IsSet("interface_url"))
            {
                throw new WeChatPayException("接口URL，缺少必填参数interface_url！");
            }
            if (!inputObj.IsSet("return_code"))
            {
                throw new WeChatPayException("返回状态码，缺少必填参数return_code！");
            }
            if (!inputObj.IsSet("result_code"))
            {
                throw new WeChatPayException("业务结果，缺少必填参数result_code！");
            }
            if (!inputObj.IsSet("user_ip"))
            {
                throw new WeChatPayException("访问接口IP，缺少必填参数user_ip！");
            }
            if (!inputObj.IsSet("execute_time_"))
            {
                throw new WeChatPayException("接口耗时，缺少必填参数execute_time_！");
            }

            inputObj.SetValue("appid", WeChatPayConfig.APPID);//公众账号ID
            inputObj.SetValue("mch_id", WeChatPayConfig.MCHID);//商户号
            inputObj.SetValue("user_ip", WeChatPayConfig.IP);//终端ip
            inputObj.SetValue("time", DateTime.Now.ToString("yyyyMMddHHmmss"));//商户上报时间	 
            inputObj.SetValue("nonce_str", GenerateNonceStr());//随机字符串
            inputObj.SetValue("sign", inputObj.MakeSign());//签名
            string xml = inputObj.ToXml();

            LogHelper.Info("WeChatPayAPI", "Report request : " + xml);

            string response = HttpService.Post(xml, url, false, timeOut);

            LogHelper.Info("WeChatPayAPI", "Report response : " + response);

            WeChatPayData result = new WeChatPayData();
            result.FromXml(response);
            return result;
        }

        /// <summary>
        ///根据当前系统时间加随机序列来生成订单号
        /// @return 订单号
        /// </summary>
        /// <returns></returns>
        public static string GenerateOutTradeNo()
        {
            var ran = new Random();
            return string.Format("{0}{1}{2}", WeChatPayConfig.MCHID, DateTime.Now.ToString("yyyyMMddHHmmss"), ran.Next(999));
        }

        /// <summary>
        /// 生成时间戳，标准北京时间，时区为东八区，自1970年1月1日 0点0分0秒以来的秒数
        ///  @return 时间戳
        /// </summary>
        /// <returns></returns>
        public static string GenerateTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }


        /// <summary>
        /// 生成随机串，随机串包含字母或数字
        /// @return 随机串
        /// </summary>
        /// <returns></returns>
        public static string GenerateNonceStr()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }

    }
}
