var News =
    [
        {
            Id: "1",
            NewsTitele: "Odeme qaydalarinda yenilik",
            NewsContent: "Dəyərli müştərilərimiz, 01.01.2019-cu il tarixindən etibarən ödəmə qaydalarında dəyişikliklər qüvvəyə minmişdir. Belə ki, artıq siz yalnız seçmiş olduğunuz məhsul linklərinə birbaşa ödəniş  edə bilərsiniz və məhsul linkləri üçün ödənişləri yalnız online qaydada ödəyə bilərsiniz",
            NewsNote: "xidmətlər üçün ödənişlər bölməsinə yalnız xidmət haqqını ödəməlisiniz.",
            NewsImagePath: "indir.jpg",
            NewsDate:"10.02.2016"
        },
        {
            Id: "2",
            NewsTitele: "Turkiyedeki Unvan deyisdi",
            NewsContent: "Dəyərli müştərilərimiz, 01.01.2019-cu il tarixindən etibarən ödəmə qaydalarında dəyişikliklər qüvvəyə minmişdir. Belə ki, artıq siz yalnız seçmiş olduğunuz məhsul linklərinə birbaşa ödəniş  edə bilərsiniz və məhsul linkləri üçün ödənişləri yalnız online qaydada ödəyə bilərsiniz",
            NewsNote: "xidmətlər üçün ödənişlər bölməsinə yalnız xidmət haqqını ödəməlisiniz.",
            NewsImagePath: "indir.jpg",
            NewsDate:"10.02.2016"
        },
        {
            Id: "3",
            NewsTitele: "Kuriyer Sifaris Edin",
            NewsContent: "Dəyərli müştərilərimiz, 01.01.2019-cu il tarixindən etibarən ödəmə qaydalarında dəyişikliklər qüvvəyə minmişdir. Belə ki, artıq siz yalnız seçmiş olduğunuz məhsul linklərinə birbaşa ödəniş  edə bilərsiniz və məhsul linkləri üçün ödənişləri yalnız online qaydada ödəyə bilərsiniz",
            NewsNote: "xidmətlər üçün ödənişlər bölməsinə yalnız xidmət haqqını ödəməlisiniz.",
            NewsImagePath: "indir.jpg",
            NewsDate:"10.02.2016"
        },
        {
            Id: "4",
            NewsTitele: "Online Alis Veris",
            NewsContent: "Dəyərli müştərilərimiz, 01.01.2019-cu il tarixindən etibarən ödəmə qaydalarında dəyişikliklər qüvvəyə minmişdir. Belə ki, artıq siz yalnız seçmiş olduğunuz məhsul linklərinə birbaşa ödəniş  edə bilərsiniz və məhsul linkləri üçün ödənişləri yalnız online qaydada ödəyə bilərsiniz",
            NewsNote: "xidmətlər üçün ödənişlər bölməsinə yalnız xidmət haqqını ödəməlisiniz.",
            NewsImagePath: "indir.jpg",
            NewsDate:"10.02.2016"
        }
    ]

    ShowDetails();

////////////////////////////////////////////////////////////////////////////////////

function ShowDetails()
{
$("a").click(function(){
    event.preventDefault();
    a = $(this).parent().attr("id")-1;
    console.log(a);


   
    var details = 
   '<a id="BackToMainNews" href="file:///C:/Users/code/Desktop/P504-Final/ViewFerid/Home/News/News.html" alt="">Xəbərlər Əsas Səhifə</a>'
      +'<div class="NewsDetailsShowNewsMainDiv">'
     +'<div class="NewsDetailsNewsDiv">'
     +'<h2>'+News[a].NewsTitele+'</h2>'
     +'<h6>'+News[a].NewsDate+'</h6>'
     +'<h3>'+News[a].NewsContent+'</h3>'
     +'<h3></h3>'
     +'<h3>Qeyd:'+News[a].NewsNote+'</h3></div></div>'

     $(".leftText h1").text(News[a].NewsTitele);
     $(".NewsLeftBlogMainColDiv").html("");
     $(".NewsLeftBlogMainColDiv").append(details);

    
});
}

    
