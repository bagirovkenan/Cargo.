
// Add link
$("#AddLink").click(function () {

    var newFormInput = $(".orderFormInputMainDiv").children()[0].outerHTML;
    var DeleteBtn = '<button type=button id="removform" class="btn btn-danger">Sil</button>';
    $(".orderFormInputMainDiv").append(newFormInput);
    $(".orderFormInputMainDiv").append(DeleteBtn);
})
/////////////////////////////////////////////////////////////////////////////////////////////////
// Delete link
$(".orderFormInputMainDiv").on("click", "#removform", function () {
    var DeleteBtn = $(this);
    var DeleteDiv = DeleteBtn.parent().children()[DeleteBtn.index() - 1];
    DeleteDiv.remove();
    DeleteBtn.remove()
})

