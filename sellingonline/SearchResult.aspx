﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SearchResult.aspx.cs" Inherits="SearchResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="Styles/FixedPhone.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Scripts/jquery.tooltip.js"></script>
    <script type="text/javascript" src="Scripts/jquery.cookie.js"></script>
    <script type="text/javascript" src="Scripts/quickpager.jquery.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var i = $.cookie('ProductCode');
            var j = $.cookie('ProductNumber');
            $("ul.list-product").quickPager({
                pageSize: 5,
                currentPage: 1,
                pagerLocation: "after"
            });

            if (i = 'null' || i == null) {
                $.cookie('ProductCode', "", { expires: 7, path: '/' });
                $.cookie('ProductNumber', 0, { expires: 7, path: '/' });
                $.cookie('ProductIndex', "", { expires: 7, path: '/' });
            }

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
            show a tool tip of a product
            */

            $(".producting").tooltip({
                delay: 0,
                showURL: false,
                bodyHandler: function () {
                    var ob = $("<img/>").attr("src", this.src);
                    var name = $(this).attr("imgName");
                    ob.css('position', 'relative');
                    ob.css('float', 'left');
                    var title = $("<div/>").html("<b>" + name + "<b>");
                    title.css('position', 'relative');
                    title.css('background-color', 'gray');
                    title.css('color', 'blue');
                    var textcontent = $("<span/>").html('');
                    $.merge(title, ob);
                    $.merge(title, textcontent);
                    return title;
                }
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
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="top_bg_p_c">
        <div class="title_box_home">
            <h1>
                <strong style="font-size: 18px; color: #FFFFFF">Kết quả tìm kiếm </strong>
            </h1>
        </div>
     </div>  
    <div id="divSearchDisplay" runat="server">
      </div>     
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="AdditionalContent" Runat="Server">
</asp:Content>

