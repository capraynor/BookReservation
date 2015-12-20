//$("#buyBooksModal").click(function () {
//    var currentBookTitle = $()
//    $("#currentBookTitle").html("");
//})
var onPurchaseButtonClicked = function (bookId, bookISBN, bookTitle) {
    $("#currentBookTitle").html(bookTitle);
    $("#currentBookISBN").html(bookISBN);
//    console.log(bookTitle);
}

$("#confirmPurchase").click(function () {
    var currentBookISBN = $("#currentBookISBN").html();
    var quantity = $("#currentBookQuantity").val();
    $.ajax({
        url: "/Home/SubmitOrder",
        method: "POST",
        data: {
            ISBN: currentBookISBN,
            Quantity: quantity
        },

        success: function(recivedContent) {
            if (!recivedContent.Success) {
                return alert("购买失败 原因是： " + recivedContent.Message);
            }

            alert(recivedContent.Message);
            $("#buyBooksModal").modal("hide");
            window.location.reload();
        }
    });
    
})