<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Home.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="Styles/Home.css" rel="stylesheet" type="text/css" />
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
                console.log(ProductIndex);
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

        /*
        show chi tiết sản phẩm khi vào đó
        */

    });
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="ProductResult" runat="server">
        <div class="home_menu_ajax">
            <div>
                <ul>
                    <li id="pro_bestseller" class="menu_ajax_select"><a href="javascript:;"><span>Sản phẩm
                        bán chạy</span></a></li>
                    <li id="promotion" class="menu_ajax_select"><a href="javascript:;"><span>Sản phẩm
                        khuyến mại</span></a></li>
                </ul>
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="AdditionalContent" ContentPlaceHolderID="AdditionalContent" Runat="Server">
    <div id='NewsContent'>
        <div class="right242">
            <div class="div4px"></div>
            <div class="top_bg_safeoff_p">
                <div class="title_top_right">
                    <a class="link_hone_new" href="#">Bản tin </a>
                </div>
            </div>
            <br class="clearfloat"/>
			<div class="box_news_safeoff_b">
				<ul class="list_p_filter_r2">
				   <li> <a href="/tin-tuc/1446/Ngay-Vang-sieu-giam-gia-tai-Tran-Anh-Dien-may-May-tinh.htm" title="Sự kiện đang được người tiêu dùng chờ đón là những sản phẩm khuyến mại siêu “hot” của Trần Anh Điện máy – Máy tính bán trong ngày vàng Tháng khuyến mại Hà Nội 2011. Đáp ứng mong mỏi của khách hàng, từ 11/11 – 17/11, rất nhiều sản phẩm thuộc các ngành hàng khác nhau từ điện tử, điện lạnh, gia dụng… đến thiết bị số được Trần Anh bán với giá rất hấp dẫn.">Ngày Vàng siêu giảm giá tại Trần Anh Điện máy – Máy tính </a> </li><li> <a href="/tin-tuc/1438/Tran-Anh-Dien-May-May-Tinh-khuyen-mai-toi-50-trong-thang-khuyen-mai.htm" title="Hưởng ứng Tháng khuyến mại Hà Nội 2011, từ ngày 01/11 – 30/11/2011, Quý khách hàng tới mua hàng tại Trần Anh Điện máy – Máy tính sẽ có cơ hội sở hữu những sản phẩm có giá trị lớn như hàng điện tử, điện lạnh, điện máy, kỹ thuật số... với giá khuyến mại hấp dẫn, giảm giá từ 10% đến 50% các mặt hàng đang có bán tại Trần Anh.">Trần Anh Điện Máy – Máy Tính khuyến mại tới 50% trong tháng khuyến mại </a> </li><li> <a href="/tin-tuc/1437/San-pham-hot-ket-thuc-Thang-tri-an-khach-hang.htm" title="Tháng 10, “Tháng tri ân khách hàng” của Trần Anh Điện máy – Máy tính đã đem lại cho khách hàng những lợi ích thiết thực. Kết thúc chương trình, hơn 3.000 máy tính đã được bảo trì bảo dưỡng miễn phí, 2.000 quà tặng đã được Trần Anh trao cho các khách hàng có hóa đơn mua hàng từ 500.000đ trở lên. Đặc biệt, hàng nghìn sản phẩm khuyến mại với giá tri ân được bán cho khách hàng, trong đó có những sản phẩm giảm giá gần 50% so với giá bán ngày thường.">Sản phẩm “hot” kết thúc “Tháng tri ân khách hàng” </a> </li><li> <a href="/tin-tuc/1434/ASUS-Eee-PC-X101,-netbook-sieu-mong-nhe-nhat-the-gioi-da-co-mat-tai-Tran-Anh.htm" title="Trong chương trình “Tháng tri ân khách hàng” diễn ra vào tháng 10, từ 21/10 – 27/10 Trần Anh Điện máy – Máy tính gửi tới quý khách hàng các sản phẩm khuyến mại hấp dẫn. Dẫn đầu trong list sản phẩm tri ân tuần này là ASUS Eee PC X101 - netbook siêu mỏng và nhẹ nhất thế giới với kích thước ấn tượng (mỏng chỉ 17,6mm và trọng lượng 0,9kg). Hiện Asus X101 được bán duy nhất tại Trần Anh với giá 4.599.000đ. Bên cạnh siêu phẩm này, laptop Acer Aspire 4750  với chip i5 thế hệ 2 mới nhất được Trần Anh giảm 1 triệu đồng, chỉ còn 10.999.000đ.">ASUS Eee PC X101, netbook siêu mỏng &amp; nhẹ nhất thế giới đã có mặt tại Trần Anh </a> </li><li> <a href="/tin-tuc/1426/Hang-nghin-san-pham-tri-an-khach-hang-tai-Dien-may-May-tinh-Tran-Anh.htm" title="Tuần lễ tri ân từ 07/10 – 13/10 đã có hàng nghìn sản phẩm được bán khuyến mại cho khách hàng. Trong đó, ti vi LCD 32&quot; thương hiệu Nhật Bản, máy giặt Midea lồng đứng 7,5kg, lò vi sóng Sharp R-209VN (W), laptop Asus A43 là những sản phẩm có sức hút mạnh, thu hút khách hàng tới mua sắm nhiều nhất.">Hàng nghìn sản phẩm tri ân khách hàng tại Điện máy – Máy tính Trần Anh </a> </li><li> <a href="/tin-tuc/Tin-khuyen-mai/219.htm" title="Tin-khuyen-mai"><strong> Xem tiếp &gt;&gt;&gt;&gt;&gt; </strong></a> </li>
				</ul>
			</div>

        </div>
    </div>
</asp:Content>