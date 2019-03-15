using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.PAY.Application.Alipay.Model
{
    /// <summary>
    ///  统一收单下单并支付页面接口请求参数
    /// </summary>
    public class Trade_PageInput
    {
        /// <summary>
        /// 支付宝分配给开发者的应用ID	
        /// 示例 2014072300007148
        /// 长度 32
        /// </summary>
        public string app_id { get; set; }
        /// <summary>
        ///  接口名称 alipay.trade.page.pay	
        /// 示例   alipay.trade.page.pay
        /// 长度 128
        /// </summary>
        public string method { get; set; }
        /// <summary>
        /// 示例   "json"
        /// 长度 40
        /// </summary>
        public string format { get; set; }
        /// <summary>
        /// HTTP/HTTPS开头字符串
        /// 示例   https://m.alipay.com/Gk8NF23
        /// 长度 256	
        /// </summary>
        public string return_url { get; set; }
        /// <summary>
        /// 请求使用的编码格式，如utf-8, gbk, gb2312等 utf-8
        /// 长度 10
        /// </summary>
        public string charset { get; set; }
        /// <summary>
        /// 商户生成签名字符串所使用的签名算法类型，目前支持RSA2和RSA，推荐使用RSA2 RSA2
        /// 长度 10
        /// </summary>
        public string sign_type { get; set; }
        /// <summary>
        /// 商户请求参数的签名串，详见签名 详见示例
        /// 长度344
        /// </summary>
        public string sign { get; set; }
        /// <summary>
        /// 发送请求的时间，格式"yyyy-MM-dd HH:mm:ss"
        /// 示例 2014-07-24 03:07:50
        /// 长度 19
        /// </summary>
        public string timestamp { get; set; }
        /// <summary>
        /// 调用的接口版本，固定为：1.0	1.0
        /// 长度 3
        /// </summary>
        public string version { get; set; }
        /// <summary>
        /// 支付宝服务器主动通知商户服务器里指定的页面http/https路径。
        /// 示例 http://api.test.alipay.net/atinterface/receive_notify.htm
        /// 长度 256
        /// </summary>
        public string notify_url { get; set; }
        /// <summary>
        /// 详见应用授权概述
        /// 长度 40
        /// </summary>
        public string app_auth_token { get; set; }
        /// <summary>
        /// 请求参数的集合，最大长度不限，除公共参数外所有请求参数都必须放在这个参数中传递，具体参照各产品快速接入文档
        /// </summary>
        public string biz_content { get; set; }

        /// <summary>
        /// 商户订单号,64个字符以内、可包含字母、数字、下划线；需保证在商户端不重复	
        /// 示例 20150320010101001
        /// 长度 64
        /// </summary>
        public string out_trade_no { get; set; }
        /// <summary>
        /// 销售产品码，与支付宝签约的产品码名称。
        /// 必选	64
        /// 注：目前仅支持FAST_INSTANT_TRADE_PAY FAST_INSTANT_TRADE_PAY
        /// </summary>
        public string product_code { get; set; }
        /// <summary>
        /// 订单总金额，单位为元，精确到小数点后两位，取值范围[0.01, 100000000]。
        /// 必选	
        /// 长度 11	
        /// 示例 88.88
        /// </summary>
        public double total_amount { get; set; }
        /// <summary>
        /// 订单标题
        /// 示例 Iphone6 16G
        ///  必选	
        ///  长度 256	 	 
        /// </summary>
        public string subject { get; set; }
        /// <summary>
        /// 订单描述 
        /// 示例 Iphone6 16G
        /// 长度 128
        /// </summary>
        public string body { get; set; }
        /// <summary>
        /// 绝对超时时间，格式为yyyy-MM-dd HH:mm
        /// 2016-12-31 10:05
        /// 长度 32
        /// </summary>
        public string time_expire { get; set; }
        /// <summary>
        /// 订单包含的商品列表信息，json格式，其它说明详见商品明细说明
        /// </summary>
        public List<GoodsDetail> goods_detail { get; set; }
        /// <summary>
        /// 公用回传参数，如果请求时传递了该参数，则返回给商户时会回传该参数。支付宝只会在同步返回（包括跳转回商户网站）和异步通知时将该参数原样返回。本参数必须进行UrlEncode之后才可以发送给支付宝。	
        /// 示例 merchantBizType%3d3C%26merchantBizNo%3d2016010101111
        /// 长度 512
        /// </summary>
        public string passback_params { get; set; }
        /// <summary>
        /// 业务扩展参数
        /// </summary>
        public ExtendParams extend_params { get; set; }
        /// <summary>
        /// 商品主类型 :0-虚拟类商品,1-实物类商品
        /// 长度 2
        /// 注：虚拟类商品不支持使用花呗渠道	0
        /// </summary>
        public string goods_type { get; set; }

        /// <summary>
        /// 该笔订单允许的最晚付款时间，逾期将关闭交易。取值范围：1m～15d。m-分钟，h-小时，d-天，1c-当天（1c-当天的情况下，无论交易何时创建，都在0点关闭）。
        /// 该参数数值不接受小数点， 如 1.5h，可转换为 90m	
        /// 90m
        /// 长度 6
        /// </summary>
        public int timeout_express { get; set; }
        /// <summary>
        /// 优惠参数
        /// 长度 512
        /// 注：仅与支付宝协商后可用	{"storeIdType":"1"}
        /// </summary>
        public string promo_params { get; set; }

        /// <summary>
        /// 描述分账信息，json格式，详见分账参数说明
        /// </summary>
        public RoyaltyInfo royalty_info { get; set; }
        /// <summary>
        /// 间连受理商户信息体，当前只对特殊银行机构特定场景下使用此字段
        /// </summary>
        public SubMerchant sub_merchant { get; set; }
        /// <summary>
        /// 可用渠道,用户只能在指定渠道范围内支付，多个渠道以逗号分割
        /// 长度 128
        /// 注，与disable_pay_channels互斥
        /// 渠道列表：https://docs.open.alipay.com/common/wifww7	pcredit,moneyFund,debitCardExpress
        /// </summary>
        public string enable_pay_channels { get; set; }
        /// <summary>
        /// 商户门店编号 NJ_001
        /// 长度32
        /// </summary>
        public string store_id { get; set; }
        /// <summary>
        /// 禁用渠道,用户不可用指定渠道支付，多个渠道以逗号分割
        /// 长度 128
        /// 注，与enable_pay_channels互斥
        ///渠道列表：https://docs.open.alipay.com/common/wifww7	pcredit,moneyFund,debitCardExpress
        /// </summary>
        public string disable_pay_channels { get; set; }
        /// <summary>
        /// PC扫码支付的方式，支持前置模式和跳转模式。 
        ///前置模式是将二维码前置到商户
        ///的订单确认页的模式。需要商户在
        ///自己的页面中以 iframe 方式请求
        ///支付宝页面。具体分为以下几种： 
        ///0：订单码-简约前置模式，对应 iframe 宽度不能小于600px，高度不能小于300px；
        ///1：订单码-前置模式，对应iframe 宽度不能小于 300px，高度不能小于600px； 
        ///3：订单码-迷你前置模式，对应 iframe 宽度不能小于 75px，高度不能小于75px； 
        ///4：订单码-可定义宽度的嵌入式二维码，商户可根据需要设定二维码的大小。 
        ///
        ///跳转模式下，用户的扫码界面是由支付宝生成的，不在商户的域名下。 
        ///2：订单码-跳转模式	1
        ///长度2
        /// </summary>
        public string qr_pay_mode { get; set; }
        /// <summary>
        /// 商户自定义二维码宽度
        /// 长度 4
        /// 注：qr_pay_mode=4时该参数生效	100
        /// </summary>
        public decimal qrcode_width { get; set; }
        /// <summary>
        /// 描述结算信息，json格式，详见结算参数说明
        /// </summary>
        public SettleInfo settle_info { get; set; }
        /// <summary>
        ///  开票信息
        /// </summary>
        public InvoiceInfo invoice_info { get; set; }
        /// <summary>
        ///  签约参数，支付后签约场景使用
        /// </summary>
        public AgreementSignParams agreement_sign_params { get; set; }
        /// <summary>
        /// 请求后页面的集成方式。 
        /// 长度 16
        /// 取值范围： 
        ///1. ALIAPP：支付宝钱包内 
        ///2. PCWEB：PC端访问
        ///默认值为PCWEB。	PCWEB
        /// </summary>
        public string integration_type { get; set; }
        /// <summary>
        /// 请求来源地址。如果使用ALIAPP的集成方式，用户中途取消支付会返回该地址。	https://
        /// 长度 256
        /// </summary>
        public string request_from_url { get; set; }
        /// <summary>
        /// 商户传入业务信息，具体值要和支付宝约定，应用于安全，营销等参数直传场景，格式为json格式	{"data":"123"}
        /// 长度 512
        /// </summary>
        public string business_params { get; set; }
        /// <summary>
        /// 外部指定买家
        /// </summary>
        public ExtUserInfo ext_user_info { get; set; }
    }


    #region 订单包含的商品列表信息，json格式，其它说明详见商品明细说明
    /// <summary>
    /// 订单包含的商品列表信息，json格式，其它说明详见商品明细说明
    /// </summary>
    public class GoodsDetail
    {
        /// <summary>
        /// 商品的编号 apple-01
        /// </summary>
        public string goods_id { get; set; }
        /// <summary>
        /// 支付宝定义的统一商品编号	20010001
        /// </summary>
        public string alipay_goods_id { get; set; }
        /// <summary>
        /// 商品名称 ipad
        /// </summary>
        public string goods_name { get; set; }
        /// <summary>
        /// 商品数量	1
        /// </summary>
        public string quantity { get; set; }
        /// <summary>
        /// 商品单价，单位为元	2000
        /// </summary>
        public double price { get; set; }
        /// <summary>
        ///  商品类目	34543238
        /// </summary>
        public string goods_category { get; set; }
        /// <summary>
        ///  商品描述信息 特价手机
        /// </summary>
        public string body { get; set; }
        /// <summary>
        ///  商品的展示地址 http://www.alipay.com/xxx.jpg
        /// </summary>
        public string show_url { get; set; }

    }
    #endregion

    #region 业务扩展参数
    /// <summary>
    /// 业务扩展参数
    /// </summary>
    public class ExtendParams
    {
        /// <summary>
        ///     系统商编号
        ///该参数作为系统商返佣数据提取的依据，请填写系统商签约协议的PID	2088511833207846
        /// </summary>
        public string sys_service_provider_id { get; set; }
        /// <summary>
        /// 使用花呗分期要进行的分期数	3
        /// </summary>
        public string hb_fq_num { get; set; }

        /// <summary>
        /// 使用花呗分期需要卖家承担的手续费比例的百分值，传入100代表100%	100
        /// </summary>
        public string hb_fq_seller_percent { get; set; }
        /// <summary>
        /// 行业数据回流信息, 详见：地铁支付接口参数补充说明	{\"scene_code\":\"metro_tradeorder\",\"channel\":\"xxxx\",\"scene_data\":{\"asset_name\":\"ALIPAY\"}}
        /// </summary>
        public string industry_reflux_info { get; set; }
        /// <summary>
        /// 卡类型 S0JP0000
        /// </summary>
        public string card_type { get; set; }

    } 
    #endregion

    #region 描述分账信息，json格式，详见分账参数说明
    /// <summary>
    /// 描述分账信息，json格式，详见分账参数说明
    /// </summary>
    public class RoyaltyInfo
    {
        /// <summary>
        /// 分账类型
        /// 长度 150
        /// 卖家的分账类型，目前只支持传入ROYALTY（普通分账类型）。	ROYALTY
        /// </summary>
        public string royalty_type { get; set; }

        /// <summary>
        /// 分账明细的信息，可以描述多条分账指令，json数组。
        /// 长度 2500
        /// </summary>
        public List<RoyaltyDetailInfo> royalty_detail_infos { get; set; }
        /// <summary>
        /// 分账明细的信息
        /// </summary>
        public class RoyaltyDetailInfo
        {
            /// <summary>
            /// 分账序列号，表示分账执行的顺序，必须为正整数	1
            /// </summary>
            public int serial_no { get; set; }
            /// <summary>
            /// 接受分账金额的账户类型： 
            ///userId：支付宝账号对应的支付宝唯一用户号。 
            ///bankIndex：分账到银行账户的银行编号。目前暂时只支持分账到一个银行编号。 
            ///storeId：分账到门店对应的银行卡编号。 
            ///默认值为userId。	userId
            /// </summary>
            public string trans_in_type { get; set; }
            /// <summary>
            /// 分账批次号
            ///分账批次号。 
            ///目前需要和转入账号类型为bankIndex配合使用。	123
            /// </summary>
            public string batch_no { get; set; }
            /// <summary>
            /// 商户分账的外部关联号，用于关联到每一笔分账信息，商户需保证其唯一性。 
            ///如果为空，该值则默认为“商户网站唯一订单号+分账序列号”	20131124001
            /// </summary>
            public string out_relation_id { get; set; }
            /// <summary>
            /// 要分账的账户类型。 
            /// 目前只支持userId：支付宝账号对应的支付宝唯一用户号。 
            ///默认值为userId。	userId
            /// </summary>
            public string trans_out_type { get; set; }
            /// <summary>
            /// 如果转出账号类型为userId，本参数为要分账的支付宝账号对应的支付宝唯一用户号。以2088开头的纯16位数字。	2088101126765726
            /// </summary>
            public string trans_out { get; set; }
            /// <summary>
            /// 如果转入账号类型为userId，本参数为接受分账金额的支付宝账号对应的支付宝唯一用户号。以2088开头的纯16位数字。 
            ///如果转入账号类型为bankIndex，本参数为28位的银行编号（商户和支付宝签约时确定）。 
            ///如果转入账号类型为storeId，本参数为商户的门店ID。	2088101126708402
            /// </summary>
            public string trans_in { get; set; }
            /// <summary>
            /// 分账的金额，单位为元	0.1
            /// </summary>
            public double amount { get; set; }
            /// <summary>
            /// 分账描述信息 分账测试1
            /// </summary>
            public string desc { get; set; }
            /// <summary>
            /// 分账的比例，值为20代表按20%的比例分账	100
            /// </summary>
            public string amount_percentage { get; set; }
        }
    }
    #endregion

    #region 间连受理商户信息体，当前只对特殊银行机构特定场景下使用此字段
    /// <summary>
    /// 间连受理商户信息体，当前只对特殊银行机构特定场景下使用此字段
    /// </summary>
    public class SubMerchant
    {
        /// <summary>
        /// 间连受理商户的支付宝商户编号，通过间连商户入驻后得到。间连业务下必传，并且需要按规范传递受理商户编号。	
        /// 示例 19023454
        /// 长度 11
        /// </summary>
        public string merchant_id { get; set; }
        /// <summary>
        /// 商户id类型，	alipay: 支付宝分配的间连商户编号, merchant: 商户端的间连商户编号
        /// 长度 32
        /// </summary>
        public string merchant_type { get; set; }
    } 
    #endregion

    #region 描述结算信息，json格式，详见结算参数说明
    /// <summary>
    /// 描述结算信息，json格式，详见结算参数说明
    /// </summary>
    public class SettleInfo
    {
        /// <summary>
        /// 结算详细信息，json数组，目前只支持一条。
        /// </summary>
        public List<settle_detail_info> settle_detail_infos { get; set; }
    }
    /// <summary>
    /// 结算详细信息，json数组，目前只支持一条。
    /// </summary>
    public class settle_detail_info
    {
        /// <summary>
        /// 结算收款方的账户类型。 
        ///cardSerialNo：结算收款方的银行卡编号; 
        ///userId：表示是支付宝账号对应的支付宝唯一用户号; 
        ///loginName：表示是支付宝登录号；	cardSerialNo
        ///长度 64
        /// </summary>
        public string trans_in_type { get; set; }
        /// <summary>
        /// 结算收款方。当结算收款方类型是cardSerialNo时，本参数为用户在支付宝绑定的卡编号；结算收款方类型是userId时，本参数为用户的支付宝账号对应的支付宝唯一用户号，
        /// 以2088开头的纯16位数字；当结算收款方类型是loginName时，本参数为用户的支付宝登录号 A0001
        /// 长度 64
        /// </summary>
        public string trans_in { get; set; }
        /// <summary>
        /// 结算汇总维度，按照这个维度汇总成批次结算，由商户指定。 
        /// 目前需要和结算收款方账户类型为cardSerialNo配合使用 A0001
        /// 长度64
        /// </summary>
        public string summary_dimension { get; set; }

        /// <summary>
        /// 结算主体标识。当结算主体类型为SecondMerchant时，为二级商户的SecondMerchantID；当结算主体类型为Store时，为门店的外标。	2088xxxxx;ST_0001
        /// 示例 64
        /// </summary>
        public string settle_entity_id { get; set; }
        /// <summary>
        /// 结算主体类型。 
        ///二级商户:SecondMerchant;商户或者直连商户门店:Store SecondMerchant、Store
        ///长度 32
        /// </summary>
        public string settle_entity_type { get; set; }
        /// <summary>
        /// 结算的金额，单位为元。目前必须和交易金额相同 0.1
        /// 长度9
        /// </summary>
        public double amount { get; set; }		
    }
    #endregion

    #region 开票信息
    /// <summary>
    /// 开票信息
    /// </summary>
    public class InvoiceInfo
    {
       
        /// <summary>
        /// 开票关键信息
        /// </summary>
        public key_info key_Info { get; set; }
        /// <summary>
        /// 开票内容
        /// 长度 400
        /// 注：json数组格式[{"code":"100294400","name":"服饰","num":"2","sumPrice":"200.00","taxRate":"6%"}]
        /// </summary>
        public string details { get; set; }

        /// <summary>
        /// 开票关键信息
        /// </summary>
        public class key_info
        {
            /// <summary>
            /// 该交易是否支持开票
            /// 长度 5
            /// </summary>
            public bool is_support_invoice { get; set; }
            /// <summary>
            /// 开票商户名称：商户品牌简称|商户门店简称 ABC|003
            /// 长度 80
            /// </summary>
            public string invoice_merchant_nam { get; set; }
            /// <summary>
            /// 税号	
            /// 示例 1464888883494
            /// 长度 30
            /// </summary>
            public string tax_num { get; set; }

        }

    }
    #endregion

    #region 签约参数，支付后签约场景使用
    /// <summary>
    /// 签约参数，支付后签约场景使用
    /// </summary>
    public class AgreementSignParams
    {
        /// <summary>
        /// 个人签约产品码，商户和支付宝签约时确定。	GENERAL_WITHHOLDING_P
        /// 长度64
        /// </summary>
        public string personal_product_code { get; set; }
        /// <summary>
        /// 协议签约场景，商户和支付宝签约时确定。
        /// 长度 64
        /// 当传入商户签约号external_agreement_no时，场景不能为默认值DEFAULT|DEFAULT。	INDUSTRY|CARRENTAL
        /// </summary>
        public string sign_scene { get; set; }
        /// <summary>
        /// 商户签约号，代扣协议中标示用户的唯一签约号（确保在商户系统中唯一）。 
        ///格式规则：支持大写小写字母和数字，最长32位。 
        ///商户系统按需传入，如果同一用户在同一产品码、同一签约场景下，签订了多份代扣协议，那么需要指定并传入该值。	test
        ///长度 32
        /// </summary>
        public string external_agreement_no { get; set; }
        /// <summary>
        /// 用户在商户网站的登录账号，用于在签约页面展示，如果为空，则不展示	
        /// 示例 13852852877
        /// 长度 100
        /// </summary>
        public string external_logon_id { get; set; }
        /// <summary>
        /// 当前用户签约请求的协议有效周期。 
        ///整形数字加上时间单位的协议有效期，从发起签约请求的时间开始算起。 
        ///目前支持的时间单位： 
        ///1. d：天 
        ///2. m：月
        ///如果未传入，默认为长期有效。	2m
        /// </summary>
        public string sign_validity_period { get; set; }
        /// <summary>
        /// 签约第三方主体类型。对于三方协议，表示当前用户和哪一类的第三方主体进行签约。
        /// 取值范围： 
        ///1. PARTNER（平台商户）; 
        ///2. MERCHANT（集团商户），集团下子商户可共享用户签约内容; 
        ///默认为PARTNER。	PARTNER
        ///长度32
        /// </summary>
        public string third_party_type { get; set; }
        /// <summary>
        /// 商户在芝麻端申请的appId	
        /// 示例 1001164
        /// 长度 64
        /// </summary>
        public string buckle_app_id { get; set; }
        /// <summary>
        /// 商户在芝麻端申请的merchantId
        /// 示例 268820000000414397785
        /// 长度 64
        /// </summary>
        public string buckle_merchant_id { get; set; }
        /// <summary>
        /// 签约营销参数，此值为json格式；具体的key需与营销约定	{"key","value"}
        /// 长度 512
        /// </summary>
        public string promo_params { get; set; }
    }
    #endregion

    #region 外部指定买家
    /// <summary>
    /// 外部指定买家
    /// </summary>
    public class ExtUserInfo
    {
        /// <summary>
        /// 姓名
        /// 注： need_check_info=T时该参数才有效 李明
        /// 长度 16
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 手机号
        /// 注：该参数暂不校验	16587658765
        /// 长度 20
        /// </summary>
        public string mobile { get; set; }
        /// <summary>
        /// 身份证：IDENTITY_CARD、护照：PASSPORT、军官证：OFFICER_CARD、士兵证：SOLDIER_CARD、户口本：HOKOU等。如有其它类型需要支持，请与蚂蚁金服工作人员联系。
        /// 注： need_check_info=T时该参数才有效 IDENTITY_CARD
        /// 长度 32
        /// </summary>
        public string cert_type { get; set; }

        /// <summary>
        /// 证件号
        /// 注：need_check_info=T时该参数才有效	362334768769238881
        /// 长度 64
        /// </summary>
        public string cert_no { get; set; }

        /// <summary>
        /// 允许的最小买家年龄，买家年龄必须大于等于所传数值
        /// 注： 
        ///1. need_check_info=T时该参数才有效 
        ///2. min_age为整数，必须大于等于0	18
        ///长度 3
        /// </summary>
        public int min_age { get; set; }
        /// <summary>
        /// 是否强制校验付款人身份信息
        /// T:强制校验，F：不强制 F
        /// 长度：8
        /// </summary>
        public bool fix_buyer { get; set; }
        /// <summary>
        /// 是否强制校验身份信息
        /// T:强制校验，F：不强制 F
        /// </summary>
        public bool need_check_info { get; set; }

    }
    #endregion
}
