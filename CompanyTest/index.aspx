<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CompanyTest.index" %>

<!DOCTYPE html>
<html>
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1, user-scalable=no">
    <meta charset="UTF-8">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <meta name="description" content="">
    <meta name="keywords" content="">
    <title>测试题-恒银</title>
    <link rel="stylesheet" type="text/css" href="css/common.css" />
    <link rel="stylesheet" type="text/css" href="css/style.css" />
    <script src="js/jquery-3.1.1.min.js"></script>
    <script src="js/font-size1.js"></script>
</head>
<body>
    <div class="wrap">
        <div id="web_bg">
            <img src="./images/bg.png" />
        </div>
        <div class="page2_box">
            <div>
                <input type="text" class="name" name="name" id="tel" value="" placeholder="请输入您的手机号" maxlength="11"/>
            </div>
            <a class="submit tijiao" title="点击量" id="sub_apply">
                <img src="./images/button.png" />
            </a>
        </div>
    </div>


    <input type="hidden" id="txtcode" value="<%= code %>" />


</body>


<script type="text/javascript">
    function is_weixin() {
        var ua = navigator.userAgent.toLowerCase();
        if (ua.match(/MicroMessenger/i) == "micromessenger") {
            return true;
        } else {
            return false;
        }
    }
    var isWeixin = is_weixin();
    var winHeight = typeof window.innerHeight != 'undefined' ? window.innerHeight : document.documentElement.clientHeight;
    function loadHtml() {
        var div = document.createElement('div');
        div.id = 'weixin-tip';
        div.innerHTML = '<p><img src="./images/live_weixin.png" alt="微信打开"/></p>';
        document.body.appendChild(div);
    }

    function loadStyleText(cssText) {
        var style = document.createElement('style');
        style.rel = 'stylesheet';
        style.type = 'text/css';
        try {
            style.appendChild(document.createTextNode(cssText));
        } catch (e) {
            style.styleSheet.cssText = cssText; //ie9以下
        }
        var head = document.getElementsByTagName("head")[0]; //head标签之间加上style样式
        head.appendChild(style);
    }
    var cssText = "#weixin-tip{position: fixed; left:0; top:0; background: rgba(0,0,0,0.8); filter:alpha(opacity=80); width: 100%; height:100%; z-index: 100;} #weixin-tip p{text-align: center; margin-top: 10%; padding:0 5%;}";
    if (isWeixin) {
        loadHtml();
        loadStyleText(cssText);
    }
</script>
<script type="text/javascript">
    $(function () {
        $('#sub_apply').click(function () {
            var bank = "";
            var name = "";
            var tel = $('#tel').val();
            var code = $('#txtcode').val();
            if(!(/^1(3|4|5|7|8)\d{9}$/.test(tel))){ 
			    alert("手机号码有误，请重填");  
			    return false; 
            }  

            location.href = "index.aspx?action=submit&mobile=" + tel + "&code=" + code; 

        });
    })
</script>
</html>

