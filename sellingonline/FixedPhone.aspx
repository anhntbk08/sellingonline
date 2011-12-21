<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="FixedPhone.aspx.cs" Inherits="FixedPhone" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
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
                    ob.css('position', 'relative');
                    ob.css('float', 'left');
                    var title = $("<div/>").html("<b>Sản phẩm này của tuấn anh đẻ ra<b>");
                    title.css('position', 'relative');
                    title.css('background-color', 'gray');
                    title.css('color', 'blue');
                    var textcontent = $("<span/>").html('Sản phẩm này vô giá thưa các cụ');
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
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="top_bg_p_c">
        <div class="title_box_home">
            <h1>
                <strong style="font-size: 18px; color: #FFFFFF">Điện thoại bàn  </strong>
            </h1>
        </div>
    </div>
    <div id="divFixedPhoneDisplay" runat="server" style="background: url('/SellingOnline/img/p_safeoff_bg_c.png') repeat-y; height:800px;">
    
    </div>
</asp:Content>

<asp:Content ID="AdditionalContent" ContentPlaceHolderID="AdditionalContent" Runat="Server">
    <div id='NewsContent'>
        <div class="right242">
            <div class="div4px"></div>
            <div class="top_bg_safeoff_p">
                <div class="title_top_right">
                    <a class="link_hone_new" href="#">Tìm theo giá </a>
                </div>
            </div>
            <br class="clearfloat"/>
			<div class="box_news_safeoff_b">
				<ul class="list_p_filter_r2">
                    <li><a href="" >Dưới 500 nghìn đồng" </a></li>
				   <li><a href="" >Từ 500 nghìn đến 1 triệu đồng </a></li>
                   <li><a href="" >Từ 1 triệu  đến 1,5 triệu đồng </a></li>
                   <li><a href="" >Từ 1,5 triệu đến 2 triệu đồng </a></li>
                   <li><a href="" >Từ 2 triệu đến 2,5 triệu đồng </a></li>
                   <li><a href="" >Từ 2.5 triệu đến 3 triệu đồng </a></li>
                   <li><a href="" >Từ 3 triệu đến 3.5 triệu đồng </a></li>
                   <li><a href="" >Từ 3.5 triệu đến 4 triệu đồng </a></li>
                   <li><a href="" >Trên 4 triệu </a></li>
				</ul>
			</div>

        </div>
    </div>
</asp:Content>


