
$(function () {

    $(document).ready(function () {
        $(".FaqHiddeColDiv").hide(),
            $(".ShowFaqtitleFaq").click(function () {

                var HiddendDiv = $(this).parent().children(".FaqHiddeColDiv");
                var c = $(this).parent().children(".FaqHiddeColDiv").children("p").css("height")
                var HiddenDivDisplay = $(this).parent().children(".FaqHiddeColDiv").css("display");

                if (HiddenDivDisplay === "none") 
                {
                    $(this).addClass("yourClass");
                    HiddendDiv.show(1000)
                }
                else 
                {
                    $(this).removeClass("yourClass");
                    HiddendDiv.hide(1000)
                }
            })
    })
})