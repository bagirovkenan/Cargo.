var Categories = 
[
    {
        Id: "1",
        CategoryName: "Butun Kateqorialar",
        Side:
            [
                {
                    Id: "1",
                    ShopName: "Nike",
                    LogoPath: "nike.png"
                },
                {
                    Id: "2",
                    ShopName: "Pier Cardin",
                    LogoPath: "prcr.png"
                },
                {
                    Id: "3",
                    ShopName: "Flo",
                    LogoPath: "flo.png"

                },
                {
                    Id: "4",
                    ShopName: "LC Waikiki",
                    LogoPath: "lcw.png"
                },
            ]
    },
    {
        Id: "2",
        CategoryName: "Ayaqqabi",
        Side:
            [
                {
                    Id: "1",
                    ShopName: "Nike",
                    LogoPath: "nike.png"
                },

                {
                    Id: "2",
                    ShopName: "Flo",
                    LogoPath: "flo.png"

                },
                {
                    Id: "3",
                    ShopName: "LC Waikiki",
                    LogoPath: "lcw.png"
                },
            ]
    },
    {
        Id: "3",
        CategoryName: "Geyim",
        Side:
        [
            {
                Id: "1",
                ShopName: "Nike",
                LogoPath: "nike.png"
            },

            {
                Id: "2",
                ShopName: "Flo",
                LogoPath: "flo.png"

            },
            
        ]
    }
]

AddCategories();
ShowCategories();
ShowCategories2();
ChangCategory();


/////////////////////////////////////////////////////////////////////////////////////////////////////////

function AddCategories() {

    for (var i = 0; i < Categories.length; i++) {


        var Cat = '<div class="col-lg-12 col-md-12 col-12 categoryTitetelColDiv" id="' + Categories[i].Id + '"><h3>' + Categories[i].CategoryName + '</h3></div>'
        $(".CategoryisTitelsRowDiv").append(Cat);
       
       
  
    }
    for (var l = 0; l < Categories[0].Side.length; l++) {
        var shop = '<div class="col-lg-3 col-md-3 col-12 shopName" id="' + Categories[0].Side[l].Id + '">'
            +'<div class="logoDiv">'
            + '<img src="' + Categories[0].Side[l].LogoPath + '">'
            + '<h3>' + Categories[0].Side[l].ShopName + '</h3></div></div>'


            $(".sideBlogRightRowDiv").append(shop);
    }

}

/////////////////////////////////////////////////////

function ChangCategory(a) {
 $(".categoryTitetelColDiv").click(function () {     
    $(".sideBlogRightRowDiv").html("")
        a=$(this).attr('id')-1;
        
            for (var l = 0; l < Categories[a].Side.length; l++) {
                var shop = '<div class="col-lg-3 col-md-3 col-12 shopName" id="' + Categories[a].Side[l].Id + '">'
                    +'<div class="logoDiv">'
                    + '<img src="' + Categories[a].Side[l].LogoPath + '">'
                    + '<h3>' + Categories[a].Side[l].ShopName + '</h3></div></div>'


                    $(".sideBlogRightRowDiv").append(shop);
            }



    })
}
//////////////////////////////////////////////////////
function ShowCategories() {
    $("#CategoryMenyuButton").click(function () {
        $(".categoryTitetelColDiv").toggle(500);
    })
}
/////////////////////////////////////////////////////
function ShowCategories2() {
    $(".CategoryTitelColDiv").click(function () {
        $(this).parent().children()[0].innerHtml
        $(".categoryTitetelColDiv").show(500);
    })
}

// src="~/Image/Carusel/sl1_20190331183742328.jpg"