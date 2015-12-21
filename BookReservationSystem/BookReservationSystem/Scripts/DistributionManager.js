var onStartDistributeButtonClicked = function(orderId) {
    $.ajax({
        url: "/Home/StartDistribute",
        method: "POST",
        data: { orderId :orderId},
        success: function(recivedContent) {
            if (recivedContent.success) {
                alert(recivedContent.message);
            } else {
                alert("操作失败");
            }

            window.location.reload();
        }
    });
}