using System;

namespace WeChatEntity
{
    public class RefundParamer
    {
        /// <summary>
        /// 公众账号ID 
        /// 微信分配的公众账号ID（企业号corpid即为此appId）
        /// </summary>
        public string appid { get; set; }

        /// <summary>
        /// 商户号
        /// 微信支付分配的商户号
        /// </summary>
        public string mch_id { get; set; }

        /// <summary>
        /// 随机字符串 
        /// 示例 5K8264ILTKCH16CQ2502SI8ZNMTM67VS 
        /// 随机字符串，不长于32位。推荐随机数生成算法
        /// </summary>
        public string nonce_str { get; set; }
        /// <summary>
        /// 签名
        /// C380BEC2BFD727A4B6845133519F3AD6 
        /// 签名，详见签名生成算法
        /// </summary>
        public string sign { get; set; }
        /// <summary>
        /// 签名类型
        ///  HMAC-SHA256 签名类型，目前支持HMAC-SHA256和MD5，默认为MD5
        /// </summary>
        public string sign_type { get; set; }
        /// <summary>
        /// 微信订单号
        /// 1217752501201407033233368018
        /// 微信生成的订单号，在支付通知中有返回
        /// </summary>
        public string transaction_id { get; set; }
        /// <summary>
        /// 商户订单号
        /// 1217752501201407033233368018	
        /// 商户系统内部订单号，要求32个字符内，只能是数字、大小写字母_-|*@ ，且在同一个商户号下唯一。
        /// </summary>
        public string out_trade_no { get; set; }
        /// <summary>
        /// 商户退款单号
        ///  1217752501201407033233368018	
        ///  商户系统内部的退款单号，商户系统内部唯一，只能是数字、大小写字母_-|*@ ，同一退款单号多次请求只退一笔。
        /// </summary>
        public string out_refund_no { get; set; }
        /// <summary>
        /// 订单金额
        /// 100
        /// 订单总金额，单位为分，只能为整数，详见支付金额
        /// </summary>
        public int total_fee { get; set; }
        /// <summary>
        /// 退款金额
        /// 100	
        /// 退款总金额，订单总金额，单位为分，只能为整数，详见支付金额
        /// </summary>
        public int refund_fee { get; set; }
        /// <summary>
        /// 退款货币种类
        ///  CNY 
        ///  退款货币类型，需与支付一致，或者不填。符合ISO 4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        /// </summary>
        public string refund_fee_type { get; set; }
        /// <summary>
        /// 退款原因
        /// 
        /// 商品已售完
        ///若商户传入，会在下发给用户的退款消息中体现退款原因

        ///注意：若订单退款金额≤1元，且属于部分退款，则不会在退款消息中体现退款原因
        ///退款资金来源
        /// </summary>
        public string refund_desc { get; set; }
        /// <summary>
        /// 退款资金来源
        /// REFUND_SOURCE_RECHARGE_FUNDS   仅针对老资金流商户使用   
        /// REFUND_SOURCE_UNSETTLED_FUNDS  ---未结算资金退款（默认使用未结算资金退款）   
        /// REFUND_SOURCE_RECHARGE_FUNDS---可用余额退款   退款结果通知url
        /// </summary>
        public string refund_account { get; set; }

        /// <summary>
        /// 退款结果通知url
        ///  https://weixin.qq.com/notify/	
        ///  异步接收微信支付退款结果通知的回调地址，通知URL必须为外网可访问的url，不允许带参数 
        ///  如果参数中传了notify_url，则商户平台上配置的回调地址将不会生效。
        /// </summary>
        public string notify_url { get; set; }
    }
}
