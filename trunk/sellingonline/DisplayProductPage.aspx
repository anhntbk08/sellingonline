<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="DisplayProductPage.aspx.cs" Inherits="DisplayProductPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="Styles/DisplayProduct.css" rel="stylesheet" type="text/css" />
    <link href="Styles/x3dom.css" rel="stylesheet" type="text/css" />
    <link href="Styles/prettyPhoto.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.7.js" type="text/javascript"></script>
    <script type="text/javascript" src="Scripts/jquery.tooltip.js"></script>
    <script type="text/javascript" src="Scripts/x3dom.js"></script>
    <script type="text/javascript" src="Scripts/jquery.prettyPhoto.js"></script>

    <style type="text/css">
        .style1
        {
            width: 728px;
            height: 701px;
        }
        .style6
        {
            height:5%;
            width:20%;
        }
        .style7
        {
        }
        .style7
        {
            width:30%px;
        }
        </style>
        <script type="text/javascript" src="Scripts/jquery.cookie.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var i = $.cookie('ProductCode');
            var j = $.cookie('ProductNumber');

            if (i = 'null' || i == null) {
                $.cookie('ProductCode', "");
                $.cookie('ProductNumber', 0);
                $.cookie('ProductIndex', "");
            }
            /*
            Show sản phẩm 3d
            */
            $("a[rel^='prettyPhoto']").prettyPhoto();
            console.log($.prettyPhoto.toString);
            
            /*******************************/
            $('.order').bind("click", function () {
                /* lấy loại hàng hiện tại
                Lấy số hàng mỗi loại
                */
                var code = $.cookie('ProductCode');
                var index = $.cookie('ProductIndex');

                // cho vào mảng
                var ProductArr = code.split(" ");
                var ProductIndex = index.split(" ");

                // Lấy mã của hàng hiện tại
                var key = $(this).attr('keyproduct');

                /*
                nếu trong danh sách đã có mã hàng này rồi
                tăng index của mã hàng đó lên và ko add thêm vào
                mảng loại hàng nữa - ngược lại add thêm mã vào
                và thêm chi số 1
                */
                var duplicated = false;
                for (var k = 0; k < ProductArr.length; k++) {
                    if (key == ProductArr[k]) {
                        duplicated = true;
                        break;
                    }
                }

                if (duplicated) {
                    ProductIndex[k]++;
                    index = ProductIndex.join(" ");
                    $.cookie('ProductIndex', index);
                }
                else {
                    ProductArr[ProductArr.length] = key;
                    ProductIndex[ProductIndex.length] = 1;
                    code = ProductArr.join(" ");
                    index = ProductIndex.join(" ");
                    $.cookie('ProductCode', code);
                    $.cookie('ProductIndex', index);
                }
                var m = $.cookie('ProductNumber');
                m++;
                $.cookie('ProductNumber', m);
                console.log(code);
            });
            /*
            slideToggle menu item when move to
            */
            $('.dropdown').each(function () {
                $(this).parent().eq(0).hoverIntent({
                    timeout: 100,
                    over: function () {
                        var current = $('.dropdown:eq(0)', this);
                        current.slideDown(100);
                    },
                    out: function () {
                        var current = $('.dropdown:eq(0)', this);
                        current.fadeOut(200);
                    }
                });
            });

            $('.dropdown a').hover(function () {
                $(this).stop(true).animate({ paddingLeft: '35px' }, { speed: 100, easing: 'easeOutBack' });
            }, function () {
                $(this).stop(true).animate({ paddingLeft: '0' }, { speed: 100, easing: 'easeOutBounce' });
            });

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id='ProductHeader' runat="server">   
        
    </div>
    <div id='ProductDetail' runat="server" style='clear: both;margin-top: 50px;float: left;border: 1px solid gray;width: 80%;height: 700px;'>
        
        <div class="top_p_desctiption_bg">
            <div class="lbl_c_p_d">
                Thông số</div>
            <table class="style1" style="overflow: hidden;">
                <tr>
                    <td rowspan="8" 
                        style="margin: 10px 0px 0px 0px; font-weight: bold; font-size: larger; top: 5px; clip: rect(5px, auto, auto, auto);">
                        &nbsp;
                        Giải trí&nbsp;
                    </td>
                    <td class="style6">
                        &nbsp;Music</td>
                    <td class="style8" id="tdMusic" runat="server">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style6">
                        &nbsp;Camera</td>
                    <td class="style8" id="tdCamera" runat="server">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style6">
                        Java
                    </td>
                    <td class="style8" id="tdJava" runat="server">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style6">
                        <span class="Apple-style-span" 
                            style="color: rgb(112, 112, 112); font-family: Tahoma; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: 20px; orphans: 2; text-align: justify; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(252, 252, 252); font-size: small; display: inline !important; float: none; ">
                        FM radio</span></td>
                    <td class="style8" id="tdFm" runat="server">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style6">
                        <span class="Apple-style-span" 
                            style="color: rgb(112, 112, 112); font-family: Tahoma; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: 20px; orphans: 2; text-align: justify; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(252, 252, 252); font-size: small; display: inline !important; float: none; ">
                        Xem Tivi</span></td>
                    <td class="style8" id="tdTivi" runat="server">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style6">
                        <span class="Apple-style-span" 
                            style="color: rgb(112, 112, 112); font-family: Tahoma; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: 20px; orphans: 2; text-align: justify; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(252, 252, 252); font-size: small; display: inline !important; float: none; ">
                        Ghi âm cuộc gọii</span></td>
                    <td class="style8" id="tdRecord" runat="server">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style6">
                        <span class="Apple-style-span" 
                            style="color: rgb(112, 112, 112); font-family: Tahoma; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: 20px; orphans: 2; text-align: justify; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(252, 252, 252); font-size: small; display: inline !important; float: none; ">
                        Xem phim</span></td>
                    <td class="style8" id="tdFilm" runat="server">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style6">
                        <span class="Apple-style-span" 
                            style="color: rgb(112, 112, 112); font-family: Tahoma; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: 20px; orphans: 2; text-align: justify; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(252, 252, 252); font-size: small; display: inline !important; float: none; ">
                        Videocall</span></td>
                    <td class="style8" id="tdVideoCall" runat="server">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style7" width="30%" rowspan="10" 
                        style="font-weight: bold; font-size: larger; ">
                        &nbsp;Cấu hình</td>
                    <td class="style6" width="40%" >
                        Hệ điều hành</td>
                    <td class="style8" id="tdOs" runat="server">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style6">
                        Chip</td>
                    <td class="style8" id="tdChip" runat="server">
                        </td>    
                </tr>
                <tr>
                    <td class="style6">
                        GPU</td>
                    <td class="style8" id="tdGpu" runat="server">
                        </td>    
                </tr>
                <tr>
                    <td class="style6">
                        3G</td>
                    <td class="style8" id="td3g" runat="server">
                        </td>    
                </tr>
                <tr>
                    <td class="style6">
                        Bluetooth</td>
                    <td class="style8" id="tdBluetooth" runat="server">
                        </td>    
                </tr>
                <tr>
                    <td class="style6">
                        Wifi</td>
                    <td class="style8" id="tdWifi" runat="server">
                        </td>    
                </tr>
                <tr>
                    <td class="style6">
                        Pin</td>
                    <td class="style8" id="tdPin" runat="server">
                        </td>    
                </tr>
                <tr>
                    <td class="style6">
                        Bộn nhớ trong</td>
                    <td class="style8" id="tdInnerMemory" runat="server">
                        </td>    
                </tr>
                <tr>
                    <td class="style6">
                        Thẻ nhớ hỗ trợ tối đa</td>
                    <td class="style8" id="tdFlashMemory" runat="server">
                        </td>    
                </tr>
                <tr>
                    <td class="style6">
                        Băng tần</td>
                    <td class="style8" id="tdFrequence" runat="server">
                        </td>    
                </tr>
            </table>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="AdditionalContent" runat="Server">
</asp:Content>
