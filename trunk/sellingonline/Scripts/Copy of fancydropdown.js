var currentRating = 0; function over(a) { var selectedItem = $(a).attr("title"); for (var i = 1; i <= selectedItem; i++) { $("img#rating" + i).attr("src", "/Content/images/star-yes.gif"); } } function out() { if (currentRating == 0) { $("div.rating1 img").attr("src", "/Content/images/star-no.gif"); } else { for (var j = 5; j > currentRating; j--) { $("img#rating" + j).attr("src", "/Content/images/star-no.gif"); } } } $(document).ready(function () {
$(".BoxImageInParagraph img").click(function (){var proId = '347'; var name = 'Nokia N81'; showModel3DMaster(proId, name); }); $("div.node-childrent").each(function () { if ($.trim($(this).text()).length == 0) { $(this).remove(); } }); $("#tagproductName").click(function () {
var productId = $(this).attr("class"); var productName = $(this).attr("title"); showProductDetails(productId, productName); return false;
}); $("a#ViewModel3DTab").click(function (){var productId = $(this).attr("title"); var productName = $(this).attr("rel"); showProductDetails(productId, productName);
}); $("div.rating1 img").click(function () {currentRating = $(this).attr("title"); out();}); $("div.rating1 img").hover(function () { over(this); }, function () { out(); }); $("img#ratiingcancel").hover(function () { $(this).attr("src", "/Content/images/cancel-on.gif"); }, function () { $(this).attr("src", "/Content/images/cancel-off.gif"); });
$("img#ratiingcancel").click(function () { currentRating = 0; out(); });}); var ewidth, eheight, eheightScence; function SetDemension() {ewidth = $(window).width() - 40; eheight = $(window).height() - 40;
eheightScence = eheight + 12;} function showProductDetails(productId, productName) { ShowModel3DAdvanced(productId, productName); return false; } function addComment() {
var sTitle = $("input[class=text-header-comment]").val();if ($.trim(sTitle).length == 0) { RequireInput("input[class=text-header-comment]"); return false; } var sMessage = $("textarea[class=text-message-rating]").val(); if ($.trim(sMessage).length == 0) {
RequireInput("textarea[class=text-message-rating]");return false;} $("button.submitBtn").attr("disabled", "disabled"); var currentProduct = '347'; $.post("/WebForms/PageGetModel3DAjax.aspx", { productId: currentProduct, title: sTitle, message: sMessage, rating: currentRating, save: true }, function (data) {
$("button.submitBtn").attr("disabled", ""); alert($("div.thank").html()); window.location.href = window.location.href;});} var seedRequireInput; var timeRequireInput = 0;var lcolor = true; function RequireInput(cl) {
if (seedRequireInput != 0) { this.clearTimeout(seedRequireInput); } if (timeRequireInput >= 1000) {this.clearTimeout(seedRequireInput);timeRequireInput = 0; $(cl).css("background-color", "#ffffff"); $(cl).focus(); lcolor = true;
} else {if (lcolor) {$(cl).css("background-color", "#8D2023"); lcolor = false;} else { $(cl).css("background-color", "#ffffff"); lcolor = true; } seedRequireInput = this.setTimeout("RequireInput('" + cl + "')", 100); timeRequireInput += 100;
}}function scroll() { $(document).scrollTop(0); } function showDetailPageProduct(destination) { window.location.href = destination; }</script><script language="javascript" type="text/javascript">
$(document).ready(function () {$("a.tab-item").click(function () {if ($(this).attr("id").indexOf("tab") != -1) {//reset all tab
for (var i = 1; i <= 4; i++) {$("div.Content-" + i.toString()).hide();$("a#tab" + i.toString()).removeAttr("style");}//change current tab
var currentTabId = $("div.tab-view-active-product-detail-center-current a.tab-item").attr("id"); $("div.tab-view-active-product-detail-open").removeClass().addClass("tab-view-active-product-detail-open-" + currentTabId);
$("div.tab-view-active-product-detail-center-current").removeClass().addClass("tab-view-active-product-detail-center-" + currentTabId);
$("div.tab-view-active-product-detail-close-current").removeClass().addClass("tab-view-active-product-detail-close-" + currentTabId);
$("div.tab-view-active-product-detail-open-" + $(this).attr("id")).removeClass().addClass("tab-view-active-product-detail-open");
$("div.tab-view-active-product-detail-center-" + $(this).attr("id")).removeClass().addClass("tab-view-active-product-detail-center-current");
$("div.tab-view-active-product-detail-close-" + $(this).attr("id")).removeClass().addClass("tab-view-active-product-detail-close-current");//display panel current tab
$("div." + $(this).attr("rev")).fadeIn("slow");}else {var productId = $(this).attr("id");var productName = $(this).attr("rev");Show3D(productId, productName);
}});$("a.button-view-3d-product-detail").click(function () { var productId = $(this).attr("id"); var productName = $(this).attr("rev"); Show3D(productId, productName); });
$("div.product-detail-product-description img").each(function () {var alt = $(this).attr("alt");$(this).attr("title", alt);});});function Show3D(id, name) { showProductDetails(id, name); }

